using DevExpress.XtraRichEdit;
using DocumentCore.API.Extensions;
using DocumentCore.API.Helpers;
using DocumentCore.API.Models;
using DocumentCore.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DocumentCore.API.Controllers
{
    /// <summary>
    /// Test
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// Convert Rtf file to Pdf
        /// </summary>
        /// <returns></returns>
        [Route("api/Test/ConvertToPdf")]
        [HttpGet]
        public async Task<HttpResponseMessage> ConvertToPdf()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                byte[] data = File.ReadAllBytes(Path.GetFullPath("DocumentCore.API/Examples/RtfTest.rtf"));
                data = await PdfHelper.Instance.ConvertDocToPdfAsync(data, DocumentFormat.Rtf);

                response = new HttpResponseMessage();
                response.Content = new ByteArrayContent(data);
                response.StatusCode = HttpStatusCode.OK;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }
            return response;
        }

        /// <summary>
        /// Convert Pdf file to jpeg
        /// </summary>
        /// <returns></returns>
        [Route("api/Test/ConvertPdfToJpeg")]
        [HttpGet]
        public async Task<HttpResponseMessage> ConvertPdfToJpeg()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                byte[] data = File.ReadAllBytes(Path.GetFullPath("DocumentCore.API/Examples/InnTest.pdf"));
                data = await PdfHelper.Instance.ConvertPdfToJpegAsync(data);

                response = new HttpResponseMessage();
                response.Content = new ByteArrayContent(data);
                response.StatusCode = HttpStatusCode.OK;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }
            return response;
        }

        /// <summary>
        /// Create report with parameters
        /// </summary>
        /// <returns></returns>
        [Route("api/Test/CreateReport")]
        [HttpGet]
        public async Task<HttpResponseMessage> CreateReport()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                CreateReportRequest request = new CreateReportRequest()
                {
                    Rows = new List<dynamic>()
                    {
                        new { Surname = "Кіршов", Name = "Євгеній", MiddleName = "Андрійович", Position = "Senior Dev"},
                        new { Surname = "Нікітін", Name = "Роман", MiddleName = "Сергійович", Position = "Product Owner"},
                        new { Surname = "Аркуша", Name = "Юлія", MiddleName = "Василівна", Position = "QA Lead"}
                    },
                    Columns = new List<ColumnOptions>()
                    {
                        new ColumnOptions()
                        {
                            Name = "Прізвище",
                            Width = 120
                        },
                        new ColumnOptions()
                        {
                            Name = "Ім'я",
                            Width = 100
                        },
                        new ColumnOptions()
                        {
                            Name = "По-батькові",
                            Width = 120
                        },
                        new ColumnOptions()
                        {
                            Name = "Посада",
                            Width = 80
                        }
                    },
                    FileExtension = ".pdf"
                };
                byte[] data = await ReportHelper.Instance.CreateReportAsync(request);

                response = new HttpResponseMessage();
                response.Content = new ByteArrayContent(data);
                response.StatusCode = HttpStatusCode.OK;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }
            return response;
        }    
    }
}