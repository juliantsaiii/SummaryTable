using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryTable
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            form1.FormBorderStyle = FormBorderStyle.None;
            CustomConfiguration configurationForm = new CustomConfiguration();
            panel.Controls.Clear();
            panel.Controls.Add(form1);
            form1.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            form1.FormBorderStyle = FormBorderStyle.None;
            CustomConfiguration configurationForm = new CustomConfiguration();
            panel.Controls.Clear();
            panel.Controls.Add(form1);
            form1.Show();
        }

        private void Reward_Click(object sender, EventArgs e)
        {
            Reward reward = new Reward();
            reward.TopLevel = false;
            reward.Dock = DockStyle.Fill;
            reward.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Clear();
            panel.Controls.Add(reward);
            reward.Show();
        }

        private void RuleConfig_Click(object sender, EventArgs e)
        {
            CustomConfiguration configurationForm = new CustomConfiguration();
            configurationForm.TopLevel = false;
            configurationForm.Dock = DockStyle.Fill;
            configurationForm.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Clear();
            panel.Controls.Add(configurationForm);
            configurationForm.Show();
        }

        private void PersonConfig_Click(object sender, EventArgs e)
        {
            PersonConfig personconfigform = new PersonConfig();
            personconfigform.TopLevel = false;
            personconfigform.Dock = DockStyle.Fill;
            personconfigform.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Clear();
            panel.Controls.Add(personconfigform);
            personconfigform.Show();
        }
    }
}
