using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Benchmark.Sincronizador.Optimizado
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            string pathOrigen = @"C:\Test\DesempeñoSistemas\Origen";
            string pathDestino = @"C:\Test\DesempeñoSistemas\Destino";
            
            var filesPath = Directory.GetFiles(pathOrigen, "*.pdf");

            Parallel.ForEach(filesPath, x => {
                var FileName = Path.GetFileNameWithoutExtension(x);
                var PathFileDestiny = $"{pathDestino}\\{FileName}.jpg";
                DocumentConverter.PDFConvert.PdfToImageConvert(x, PathFileDestiny, "jpg");
            });
            
            timeMeasure.Stop();
            Console.WriteLine($"Tiempo transcurrido: {timeMeasure.ElapsedMilliseconds} milisegundos");
            Console.ReadKey();
        }
    }
}
