using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;
using CognitiveCoreUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"..\..\..\PII_Pipes_Filters\src\Program\Imagenes\luke.jpg");
            
            PipeNull pipe_Null = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial1 = new PipeSerial(filtroNegativo, pipe_Null);
            FilterGreyscale filtroGrises = new FilterGreyscale();
            picture = pipeSerial1.Send(picture);
            FilterConditional filtroCondicional = new FilterConditional();
            PipeConditional condicional = new PipeConditional(filtroCondicional, pipeSerial1, pipe_Null);
            PipeSerial pipeSerial2 = new PipeSerial(filtroGrises, condicional); // para las primeras partes
            //picture = pipeSerial1.Send(picture);
            //picture = condicional.Send(picture);   //envia foto condicional
            picture = pipeSerial2.Send(picture); //guarda los cambios de filtros de grises
            
            //picture = pipeSerial1.Send(picture); //guarda los cambios de filtro negativo
            
            
            
            
            provider.SavePicture(picture, @"..\..\..\PII_Pipes_Filters\src\Program\Imagenes\luke1.jpg");  
            
        }
    }
}
