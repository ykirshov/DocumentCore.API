using DocumentCore.API.Helpers;
using DocumentCore.API.Models;
using DocumentCore.API.Models.Requests;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DocumentCore.API.Controllers
{
    /// <summary>
    /// File Converter
    /// </summary>
    public class ConverterController : ApiController
    {
        /// <summary>
        /// Convert File to Pdf
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/Converter/ConvertToPdf")]
        [ResponseType(typeof(ExtendedResponse<byte[]>))]
        [HttpPost]
        public async Task<IHttpActionResult> ConvertToPdf([FromBody] ConverterInputRequest request)
        {
            ExtendedResponse<byte[]> response = new ExtendedResponse<byte[]>
            {
                ResultCode = 0
            };
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException();
                }
                response.Response = await PdfHelper.Instance.ConvertDocToPdfAsync(request.Data, request.GetDocumentFormat());
            }
            catch (Exception ex)
            {
                response.ResultCode = 1;
                response.ErrorMessage = ex.ToString();
            }
            return Json(response);
        }

        /// <summary>
        /// Convert Pdf to Jpeg
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Route("api/Converter/ConvertPdfToJpeg")]
        [ResponseType(typeof(ExtendedResponse<byte[]>))]
        [HttpPost]
        public async Task<IHttpActionResult> ConvertPdfToJpeg([FromBody] ConvertPdfToJpegRequest request)
        {
            ExtendedResponse<byte[]> response = new ExtendedResponse<byte[]>
            {
                ResultCode = 0
            };
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException();
                }
                response.Response = await PdfHelper.Instance.ConvertPdfToJpegAsync(request.Data);
            }
            catch (Exception ex)
            {
                response.ResultCode = 1;
                response.ErrorMessage = ex.ToString();
            }
            return Json(response);
        }
    }
}