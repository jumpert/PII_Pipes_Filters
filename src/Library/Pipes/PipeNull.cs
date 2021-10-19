﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Pipes
{
    public class PipeNull : IPipe
    {   
        //public List<IPicture> persistencia = new List<IPicture>();
        IPicture image;
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        
        PictureProvider p = new PictureProvider();
        
        public IPicture Send(IPicture picture)
        {
            this.image = picture;
            
            return this.image;
        }
        
    }
}
