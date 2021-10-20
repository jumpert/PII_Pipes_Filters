using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Pipes
{
    public class PipeSerial : IPipe
    {
        public List<IPicture> persistencia = new List<IPicture>();
        protected IFilter filtro;
        protected IPipe nextPipe;
        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeSerial(IFilter filtro, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        PictureProvider p = new PictureProvider();
        private static int count;
        public IPicture Send(IPicture picture)
        {
            count++;
            picture = this.filtro.Filter(picture);
            // Utilizando una instancia de la clase PictureProvider
            // se guarda la va imagen, que recibe como parametro la imagen y el
            // directorio donde se quiere guardar, el cual contatena un numero (count)
            // que aumenta cada vez que la se ejecuta el Send de PipeSerial
            p.SavePicture(picture, Direccion());
            persistencia.Add(picture);
            //envia automaticamente el tweet, cada vez que la imagen entra a PipeNull
            //var twitter = new TwitterImage();
            //Console.WriteLine(twitter.PublishToTwitter($"cambio de imagen {count} ",Direccion()));
            return this.nextPipe.Send(picture);
        }
        
         public string Direccion()
        {
            string direccion;
            direccion = $@"..\..\..\PII_Pipes_Filters\src\Program\Imagenes\filtro{count}.jpg";
            return direccion;
        }
    }
}
