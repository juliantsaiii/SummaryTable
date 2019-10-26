using SummaryTable.Helper;
using SummaryTable.Model;
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
    public partial class PersonConfig : Form
    {
        public static PersonConfigVM personConfigVM;
        public PersonConfig()
        {
            InitializeComponent();
            InitialAllValue();
            personConfigVM = new PersonConfigVM();
        }

        private void SavePersonConfig_Click(object sender, EventArgs e)
        {
            personConfigVM.ProjectProperty = this.ProjectProperty.Text;
            personConfigVM.PurposeOfValuation = this.PurposeOfValuation.Text;
            personConfigVM.MethodOfValuation = this.MethodOfValuation.Text;
            personConfigVM.Auditors = this.Auditors.Text;
            personConfigVM.Evaluator = this.Evaluator.Text;
            personConfigVM.Valuer = this.Valuer.Text;
            personConfigVM.ProjectUndertaker = this.ProjectUndertaker.Text;
            personConfigVM.ProjectSource = this.ProjectSource.Text;
            try
            {
                HouseConfigHelper.UpdateHouseConfig(personConfigVM);
            }
            catch (Exception)
            {

                MessageBox.Show("固定信息保存失败！", "保存失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("固定信息保存成功！", "保存成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveRuleConfig_Click(object sender, EventArgs e)
        {
            personConfigVM.FileName1 = this.FileName1.Text;
            personConfigVM.FileName2 = this.FileName2.Text;
            try
            {
                RuleConfigHelper.UpdateRuleConfig(personConfigVM);
            }
            catch (Exception)
            {
                MessageBox.Show("扫描文档范围保存失败！", "保存失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("扫描文档范围保存成功！", "保存成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void InitialAllValue()
        {
            HouseConfigHelper.ReadConfig();
            this.ProjectProperty.Text=HouseConfigHelper.ProjectProperty;
             this.PurposeOfValuation.Text= HouseConfigHelper.PurposeOfValuation;
            this.MethodOfValuation.Text= HouseConfigHelper.MethodOfValuation;
            this.Auditors.Text= HouseConfigHelper.Auditors;
            this.Evaluator.Text= HouseConfigHelper.Evaluator;
            this.Valuer.Text= HouseConfigHelper.Valuer;
            this.ProjectUndertaker.Text= HouseConfigHelper.ProjectUndertaker;
            this.ProjectSource.Text= HouseConfigHelper.ProjectSource;

            RuleConfigHelper.ReadConfig();
            this.FileName1.Text = RuleConfigHelper.FileName1;
            this.FileName2.Text = RuleConfigHelper.FileName2;
        }
    }
}
