using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </remarks>
    public class FilterConditional : IFilter
    {
        private bool isFace;
        
        public bool IsFace
        {
            get
            {
                return this.isFace;
            }
           
        }
        public IPicture Filter(IPicture image)
        {

            IPicture result = image.Clone();
            // Crea instancia de CognitiveFace y se le asigna una copia de
            // la imagen para tomar su ruta
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(result.Path); 

            // Evalua si en la imagen aprace una cara o no
            // si aparece cambia el valor de isFace a true 
            // sino aparece lo cambia a false
            if (cog.FaceFound)
            {
                this.isFace = true;
            }
            else 
            {
                this.isFace = false;
            }
            
            return result;
        }
    }
}
