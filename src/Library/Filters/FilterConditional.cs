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

            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(result.Path); 
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
