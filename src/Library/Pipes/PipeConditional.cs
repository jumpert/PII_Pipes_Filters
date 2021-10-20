using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;
using CognitiveCoreUCU;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {   
        protected IPipe nextPipe;
        protected IPipe next2Pipe;
        protected IFilter filtro;
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public PipeConditional(IFilter filtro, IPipe nextPipe, IPipe next2Pipe)
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }

        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        public IFilter Filtro
        {
            get {return this.filtro;}   
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>

        
        PictureProvider p = new PictureProvider();
        
        public IPicture Send(IPicture picture)
        {
            // Evalua el estado de filtro para ver si su prop. IsFace
            // es true o false, si es true ejecuta filtro gris, sino el negativo
            if (filtro.IsFace)
            {
                FilterGreyscale filtroGrises = new FilterGreyscale();
                picture = filtroGrises.Filter(picture);
                return this.nextPipe.Send(picture);
            }
            else 
            {
                FilterNegative filtro = new FilterNegative();
                picture = filtro.Filter(picture);
                return this.next2Pipe.Send(picture);

            }
        }
    }
}
