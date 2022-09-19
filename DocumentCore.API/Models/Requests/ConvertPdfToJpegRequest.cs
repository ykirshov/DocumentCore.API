using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentCore.API.Models.Requests
{
    public class ConvertPdfToJpegRequest
    {
        /// <summary>
        /// Data in bytes of file
        /// </summary>
        public byte[] Data { get; set; }
    }
}