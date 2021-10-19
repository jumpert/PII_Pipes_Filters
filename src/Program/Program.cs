using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"..\..\..\PII_Pipes_Filters\src\Program\Imagenes\beer.jpg");

            PipeNull pipe_Null = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial1 = new PipeSerial(filtroNegativo,pipe_Null);
            FilterGreyscale filtroGrises = new FilterGreyscale();
            PipeSerial pipeSerial2 = new PipeSerial(filtroGrises, pipeSerial1);
            
            picture = pipeSerial2.Send(picture); //guarda los cambios de filtros de grises
            //picture = pipeSerial1.Send(picture); //guarda los cambios de filtro negativo
            
            
            
            provider.SavePicture(picture, @"..\..\..\PII_Pipes_Filters\src\Program\Imagenes\final_beer.jpg");  
            
        }
    }
}
