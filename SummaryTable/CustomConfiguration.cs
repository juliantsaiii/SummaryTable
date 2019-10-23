using SummaryTable.Helper;
using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryTable
{
    public partial class CustomConfiguration : Form
    {
        public CustomConfiguration()
        {
            InitializeComponent();
        }
        public RegexConfigurer regexConfigurer
        {
            get;set;
        }
        /// <summary>
        /// 窗体加载时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomConfiguration_Load(object sender, EventArgs e)
        {
            RegexConfigurer myRegexConfigurer = new RegexConfigurer();
            this.regexConfigurer = myRegexConfigurer;
        }

        private void AddRule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.SectionName.Text))
            {
                MessageBox.Show("请输入模板名称，如（正式报告模板_张素萍）", "请输入模板名称", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (regexConfigurer.HasSection(this.SectionName.Text))
            {
                RegexRule regexRule = regexConfigurer.GetRegexRule(this.SectionName.Text);
                this.CodeRegex.Text = regexRule.Code;
                this.ValueTimeRegex.Text = regexRule.ValueTime;
                this.CustomerRegex.Text = regexRule.Customer;
                this.LocationRegex.Text = regexRule.Location;
                this.ArchitecherAreaRegex.Text = regexRule.ArchitecherArea;
                this.SingleValueRegex.Text = regexRule.SingleValue;
                this.TotalValueRegex.Text = regexRule.TotalValue;
            }
            else
            {
                this.CodeRegex.Text = "前缀__(n,m)__后缀";
                this.ValueTimeRegex.Text = "前缀__(n,m)__后缀";
                this.CustomerRegex.Text = "前缀__(n,m)__后缀";
                this.LocationRegex.Text = "前缀__(n,m)__后缀";
                this.ArchitecherAreaRegex.Text = "前缀__(n,m)__后缀";
                this.SingleValueRegex.Text = "前缀__(n,m)__后缀";
                this.TotalValueRegex.Text = "前缀__(n,m)__后缀";
            }
        }


        private void AddOrUpdateRule_Click(object sender, EventArgs e)
        {
            RegexRule regexRule = new RegexRule { Code = this.CodeRegex.Text, ValueTime = this.ValueTimeRegex.Text, Customer = this.CustomerRegex.Text, Location = this.LocationRegex.Text, ArchitecherArea = this.ArchitecherAreaRegex.Text, SingleValue = this.SingleValueRegex.Text, TotalValue = this.TotalValueRegex.Text };
            if (judgeRegex(regexRule.Code)
                && judgeRegex(regexRule.ValueTime)
                && judgeRegex(regexRule.Customer)
                && judgeRegex(regexRule.Location)
                && judgeRegex(regexRule.ArchitecherArea)
                && judgeRegex(regexRule.SingleValue)
                && judgeRegex(regexRule.TotalValue))
            {
                bool result = regexConfigurer.SetRegexRule(this.SectionName.Text, regexRule);
                if (result)
                {
                    MessageBox.Show("已成功更新模板匹配规则！", "更新成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("系统出了点小问题，添加失败了，请稍后尝试！", "更新失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("格式请参照（*****__(n,m)__******），\r\n【*】部分为前后内容，【n】匹配对象最短长度，【m】为匹配对象最长长度", "匹配规则不规范", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool judgeRegex(string content)
        {
            //未能正确读取__(n,m)__委托方名称
            string regexPattern = @"__\(\d,\d\)__";
            string result = Regex.Match(content, regexPattern).Value;
            if (string.IsNullOrEmpty(result))
            {
                return false;
            }
            return true;
        }
    }
}
