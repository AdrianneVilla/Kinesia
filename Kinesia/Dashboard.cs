﻿using Kinesia.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia
{
    public partial class Dashboard : Form
    {
        public string selectedButton;
  
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            PageObjects.dashboardPage = new DashboardPage();
            ContentsPanel.Controls.Add(PageObjects.dashboardPage);
            PageObjects.CurrentControl = PageObjects.dashboardPage;
        }

    }
}
