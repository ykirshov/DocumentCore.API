using System;
using System.Web.Http;
using System.Web.Http.Description;
using DocumentCore.API.Models;
using System.Threading.Tasks;
using DocumentCore.API.Helpers;
using DocumentCore.API.Models.Requests;

namespace DocumentCore.API.Controllers
{
    public class ReportController : ApiController
    {
        /// <summary>
        /// Create Report from List of objects with specific file extension
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/Report/CreateReport")]
        [ResponseType(typeof(ExtendedResponse<byte[]>))]
        [HttpPost]
        public async Task<IHttpActionResult> CreateReport([FromBody] CreateReportRequest request)
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
                response.Response = await ReportHelper.Instance.CreateReportAsync(request);
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