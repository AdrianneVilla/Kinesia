using KinesiaLibrary.DTOs.ReportDTOs;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Reports
{
    public partial class PrintReport : Form
    {
        private readonly ReportViewer ROMReportViewer;
        public PrintReport()
        {
            InitializeComponent();

            ROMReportViewer = new ReportViewer();
            ROMReportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(ROMReportViewer);
        }

        private async void PrintReport_Load(object sender, EventArgs e)
        {
            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/assessment/generate-report?assessmentID={"SAMPLE1"}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var assessment = JsonConvert.DeserializeObject<AssessmentReportDTO>(json);

                    var assessments = new List<AssessmentReportDTO> { assessment };

                    var assessmentDatasource = new ReportDataSource("AssessmentDataset", assessments);
                    ROMReportViewer.LocalReport.DataSources.Add(assessmentDatasource);
                }
            }

            using(var client = new HttpClient())
            {
                var url = $"https://localhost:5001/api/rom/generate-report?assessmentID={"SAMPLE1"}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var ROMs = JsonConvert.DeserializeObject<List<ROMReportDTO>>(json);

                    var romDatasource = new ReportDataSource("ROMDataset", ROMs);
                    ROMReportViewer.LocalReport.DataSources.Add(romDatasource);
                }
            }

            ROMReportViewer.LocalReport.ReportEmbeddedResource = "Kinesia.Reports.RDLCs.ROMReport.rdlc";
            ROMReportViewer.RefreshReport();
        }
    }
}
