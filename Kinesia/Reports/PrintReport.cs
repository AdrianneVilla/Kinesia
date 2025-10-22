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
        private readonly HttpClient client = ApiClient.Instance;

        public PrintReport()
        {
            InitializeComponent();

            ROMReportViewer = new ReportViewer();
            ROMReportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(ROMReportViewer);
        }

        private async void PrintReport_Load(object sender, EventArgs e)
        {
            var url1 = $"http://localhost:5000/api/assessment/generate-report?assessmentID={PageObjects.assessmentDetails.AssessmentID}";
            var response1 = await client.GetAsync(url1);

            if (response1.IsSuccessStatusCode)
            {
                var json = await response1.Content.ReadAsStringAsync();
                var assessment = JsonConvert.DeserializeObject<AssessmentReportDTO>(json);

                var assessments = new List<AssessmentReportDTO> { assessment };

                var assessmentDatasource = new ReportDataSource("AssessmentDataset", assessments);
                ROMReportViewer.LocalReport.DataSources.Add(assessmentDatasource);
            }

            var url2 = $"http://localhost:5000/api/rom/generate-report?assessmentID={PageObjects.assessmentDetails.AssessmentID}";
            var response2 = await client.GetAsync(url2);

            if (response2.IsSuccessStatusCode)
            {
                var json = await response2.Content.ReadAsStringAsync();
                var ROMs = JsonConvert.DeserializeObject<List<ROMReportDTO>>(json);

                var romDatasource = new ReportDataSource("ROMDataset", ROMs);
                ROMReportViewer.LocalReport.DataSources.Add(romDatasource);
            }

            ROMReportViewer.LocalReport.ReportEmbeddedResource = "Kinesia.Reports.RDLCs.ROMReport.rdlc";
            ROMReportViewer.RefreshReport();
        }
    }
}
