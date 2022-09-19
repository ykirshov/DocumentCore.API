using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DocumentCore.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DocumentCore.API.Helpers
{
    public class ReportHelper
    {
        public static ReportHelper Instance { get; }

        static ReportHelper()
        {
            Instance = new ReportHelper();
        }

        private byte[] CreateReport(CreateReportRequest request)
        {
            if (request.Rows is null || request.Rows.Count == 0)
            {
                throw new ArgumentException("Rows are empty");
            }
            else if (string.IsNullOrEmpty(request.FileExtension))
            {
                throw new ArgumentException("FileExtension is empty");
            }
            byte[] data = null;

            using (GridControl grid = new GridControl())
            {
                using (GridView view = new GridView())
                {
                    grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[]
                    {
                        view
                    });
                    grid.MainView = view;
                    grid.BindingContext = new BindingContext();

                    view.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    view.Appearance.EvenRow.Options.UseBackColor = true;
                    view.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ControlLight;
                    view.Appearance.OddRow.Options.UseBackColor = true;
                    view.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                    view.AppearancePrint.EvenRow.Options.UseBackColor = true;

                    view.GridControl = grid;
                    grid.DataSource = request.Rows;

                    int countColumns = view.Columns.Count;
                    if (request.Columns != null)
                    {
                        for (int i = 0; i < request.Columns.Count; i++)
                        {
                            if (i < countColumns)
                            {
                                if (!string.IsNullOrWhiteSpace(request.Columns[i].Name))
                                {
                                    view.Columns[i].Caption = request.Columns[i].Name;
                                }
                                if (request.Columns[i].Width > 0)
                                {
                                    view.Columns[i].MinWidth = request.Columns[i].Width;
                                }
                            }
                        }
                    }
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        switch (request.FileExtension.ToLower())
                        {
                            case ".pdf":
                                view.ExportToPdf(ms);
                                break;
                            case ".xls":
                                view.ExportToXls(ms);
                                break;
                            case ".xlsx":
                                view.ExportToXlsx(ms);
                                break;
                            case ".csv":
                                view.ExportToCsv(ms);
                                break;
                            case ".html":
                                view.ExportToHtml(ms);
                                break;
                            case ".rtf":
                                view.ExportToRtf(ms);
                                break;
                            case ".txt":
                                view.ExportToText(ms);
                                break;
                            default:
                                throw new InvalidOperationException($"Unsupported file extension {request.FileExtension.ToLower()}");
                        }
                        data = ms.ToArray();
                    }
                }
            }
            return data;
        }

        public async Task<byte[]> CreateReportAsync(CreateReportRequest request)
        {
            return await Task.Run(() => Instance.CreateReport(request));
        }
    }
}