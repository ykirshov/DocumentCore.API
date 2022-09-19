using DevExpress.XtraRichEdit;
using DocumentCore.API.Enums;

namespace DocumentCore.API.Models.Requests
{
    /// <summary>
    /// Input Document Model
    /// </summary>
    public class ConverterInputRequest
    {
        /// <summary>
        /// Format Input File
        /// </summary>
        public FileFormat Format { get; set; }

        /// <summary>
        /// Data in bytes of file
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Return XtraRichEdit.DocumentFormat from File Format
        /// </summary>
        /// <returns></returns>
        public DocumentFormat GetDocumentFormat()
        {
            DocumentFormat documentFormat;
            switch (Format)
            {
                case FileFormat.Doc:
                    documentFormat = DocumentFormat.Doc;
                    break;
                case FileFormat.ePub:
                    documentFormat = DocumentFormat.ePub;
                    break;
                case FileFormat.Html:
                    documentFormat = DocumentFormat.Html;
                    break;
                case FileFormat.Mht:
                    documentFormat = DocumentFormat.Mht;
                    break;
                case FileFormat.OpenDocument:
                    documentFormat = DocumentFormat.OpenDocument;
                    break;
                case FileFormat.OpenXml:
                    documentFormat = DocumentFormat.OpenXml;
                    break;
                case FileFormat.PlainText:
                    documentFormat = DocumentFormat.PlainText;
                    break;
                case FileFormat.Rtf:
                    documentFormat = DocumentFormat.Rtf;
                    break;
                case FileFormat.Undefined:
                    documentFormat = DocumentFormat.Undefined;
                    break;
                case FileFormat.WordML:
                    documentFormat = DocumentFormat.WordML;
                    break;
                default:
                    documentFormat = DocumentFormat.Undefined;
                    break;
            }
            return documentFormat;
        }
    }
}