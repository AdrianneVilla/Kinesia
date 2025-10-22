using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class AssessmentPage : UserControl
    {
        string searchData = "";
        string currentTab = "All";

        public AssessmentPage()
        {
            this.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public DataGridView AssessmentGrid { get { return dataGridAssessments; } }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void AssessmentPage_Load(object sender, EventArgs e)
        {
            await Queries.AssessmentQueries.DisplayAssessments(searchData, currentTab, "");
        }

        private void btnAddAssessment_Click(object sender, EventArgs e)
        {
            PageObjects.addAssessment = new AddAssessment();
            PageObjects.RemoveResources(ref PageObjects.CurrentControl);
            PageObjects.dashboard.ContentsPanel.Controls.Add(PageObjects.addAssessment);
            PageObjects.CurrentControl = PageObjects.addAssessment;
        }
    }
}
