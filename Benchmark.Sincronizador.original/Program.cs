using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Benchmark.Sincronizador.original
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();
            timeMeasure.Start();

            string pathOrigen  = @"C:\Test\DesempeñoSistemas\Origen";
            string pathDestino = @"C:\Test\DesempeñoSistemas\Destino";

            List<Document> FilesInMemory = new List<Document>();

            var filesPath = Directory.GetFiles(pathOrigen, "*.pdf");

            filesPath.ToList().ForEach(x => {
                FilesInMemory.Add(new Document(File.ReadAllBytes(x), x));
            });

            FilesInMemory.ForEach(f =>
            {
                var FileName = Path.GetFileNameWithoutExtension(f.Path);
                var PathFileDestiny = $"{pathDestino}\\{FileName}.jpg";
                DocumentConverter.PDFConvert.PdfToImageConvert(f.File, PathFileDestiny, "jpeg");
            });

            timeMeasure.Stop();
            Console.WriteLine($"Tiempo transcurrido: {timeMeasure.ElapsedMilliseconds} milisegundos");
            Console.ReadKey();
        }
    }
}
