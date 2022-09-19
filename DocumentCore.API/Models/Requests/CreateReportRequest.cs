using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentCore.API.Models.Requests
{
    public class CreateReportRequest
    {
        public List<dynamic> Rows { get; set; }
        public List<ColumnOptions> Columns { get; set; }
        public string FileExtension { get; set; }
    }

    public class ColumnOptions
    {
        public string Name { get; set; }
        public int Width { get; set; }
    }
}