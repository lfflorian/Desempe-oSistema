using System;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DocumentConverter
{
    public static class PDFConvert
    {
        /// <summary>
        /// Convert PDF from path to any type of image
        /// </summary>
        /// <param name="PDFfilePath">Path of the file ubication</param>
        /// <param name="DestinyPath">Path to store the document</param>
        /// <param name="Format">Format of the image conversion</param>
        /// <returns>Operation result that has the status and information of the conversion</returns>
        public static OperationResult PdfToImageConvert(string PDFfilePath, string DestinyPath, string Format)
        {
            OperationResult result = new OperationResult();
            var fileName = Path.GetFileNameWithoutExtension(PDFfilePath);

            try
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(PDFfilePath);
                Bitmap image = loadedDocument.ExportAsImage(0);
                image.Save(DestinyPath, IdentifyImageFormat(Format));
                loadedDocument.Close(true);
            }
            catch (Exception es)
            {
                result.WasSuccesful = false;
                result.Message = es.Message;
                result.Error = es;
            }

            return result;
        }

        /// <summary>
        /// Convert base64 PDF string to any type of image
        /// </summary>
        /// <param name="PDFBase64">PDF in base64 string</param>
        /// <param name="Format">Format of the image conversion</param>
        /// <returns>Operation result that has the status and information of the conversion</returns>
        public static OperationResult PdfToImageConvert(byte[] file, string DestinyPath, string Format)
        {
            OperationResult result = new OperationResult();

            try
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(file, true);
                Bitmap image = loadedDocument.ExportAsImage(0);
                image.Save(DestinyPath, IdentifyImageFormat(Format));
                loadedDocument.Close(true);
            }
            catch (Exception es)
            {
                result.WasSuccesful = false;
                result.Message = es.Message;
                result.Error = es;
            }
            
            return result;
        }

        private static ImageFormat IdentifyImageFormat(string value)
        {
            switch (value.ToLower())
            {
                case "bmp":
                    return ImageFormat.Bmp;
                case "emf":
                    return ImageFormat.Emf;
                case "exif":
                    return ImageFormat.Exif;
                case "gif":
                    return ImageFormat.Gif;
                case "icon":
                    return ImageFormat.Icon;
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "memorybmp":
                    return ImageFormat.MemoryBmp;
                case "png":
                    return ImageFormat.Png;
                case "tiff":
                    return ImageFormat.Tiff;
                case "wmf":
                    return ImageFormat.Wmf;
                default:
                    throw new Exception($"Formato de conversión a imagen no valido: {value}");
            }
        }
    }
}
