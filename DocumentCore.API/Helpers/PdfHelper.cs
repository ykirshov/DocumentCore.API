using DevExpress.XtraRichEdit;
using System.IO;
using System.Threading.Tasks;
using DevExpress.Pdf;
using System.Drawing;
using System.Drawing.Imaging;

namespace DocumentCore.API.Helpers
{
    /// <summary>
    /// Helper working with Pdf
    /// </summary>
    public class PdfHelper
    {
        public static PdfHelper Instance { get; }

        static PdfHelper()
        {
            Instance = new PdfHelper();
        }

        /// <summary>
        /// Converts file document to Pdf
        /// </summary>
        private byte[] ConvertDocToPdf(byte[] content, DocumentFormat documentFormat)
        {
            byte[] data = null;
            using (RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer())
            {
                using (MemoryStream stream = new MemoryStream(content))
                {
                    MemoryStream streamPdf = new MemoryStream();
                    richEditDocumentServer.Document.LoadDocument(stream, documentFormat);
                    richEditDocumentServer.ExportToPdf(streamPdf);
                    data = streamPdf.ToArray();
                }
            }
            return data;
        }

        public async Task<byte[]> ConvertDocToPdfAsync(byte[] content, DocumentFormat documentFormat)
        {
            return await Task.Run(() => Instance.ConvertDocToPdf(content, documentFormat));
        }

        /// <summary>
        /// Converts file Pdf to jpeg
        /// </summary>
        private byte[] ConvertPdfToJpeg(byte[] content)
        {
            byte[] data = null;
            int largestEdgeLength = 1000;
            int pageNumber = 1;
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                using (MemoryStream stream = new MemoryStream(content))
                {
                    processor.LoadDocument(stream);

                    using (Bitmap image = processor.CreateBitmap(pageNumber, largestEdgeLength))
                    {
                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            image.Save(imageStream, ImageFormat.Jpeg);
                            data = imageStream.ToArray();
                        }
                    }
                }
            }
            return data;
        }

        public async Task<byte[]> ConvertPdfToJpegAsync(byte[] content)
        {
            return await Task.Run(() => Instance.ConvertPdfToJpeg(content));
        }
    }
}