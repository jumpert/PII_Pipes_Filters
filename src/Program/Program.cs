using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\jpere\OneDrive - Universidad Católica del Uruguay\Segundo Semestre\Programación 2\repos\PII_Pipes_Filters\src\Program\beer.jpg");

            PipeNull pipe_Null = new PipeNull();
            FilterNegative filtroNegativo = new FilterNegative();
            PipeSerial pipeSerial1 = new PipeSerial(filtroNegativo,pipe_Null);
            FilterGreyscale filtroGrises = new FilterGreyscale();
            PipeSerial pipeSerial2 = new PipeSerial(filtroGrises, pipe_Null);
            
            
            picture = pipeSerial1.Send(picture); //guarda los cambios de filtro negativo
            
            picture = pipeSerial2.Send(picture); //guarda los cambios de filtros de grises
            
            provider.SavePicture(picture, @"C:\Users\jpere\OneDrive - Universidad Católica del Uruguay\Segundo Semestre\Programación 2\repos\PII_Pipes_Filters\src\Program\final_beer.jpg");  
            //provider.ShowPicture();  //Para ver la secuencia de fotos almacenadas
        }
    }
}
