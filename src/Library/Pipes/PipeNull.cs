using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeNull : IPipe
    {   
        public List<IPicture> persistencia = new List<IPicture>();
        IPicture image;
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public IPicture Send(IPicture picture)
        {
            this.image = picture;
            this.persistencia.Add(picture);
            count++;
            PictureProvider p = new PictureProvider();
            p.SavePicture(picture, $@"C:\Users\jpere\OneDrive - Universidad Católica del Uruguay\Segundo Semestre\Programación 2\repos\PII_Pipes_Filters\src\Program\filtro{count}.jpg");

            return this.image;
        }
        public static int count; 

    }
}
