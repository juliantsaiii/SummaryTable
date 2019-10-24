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
            initialListItem();
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
            regexRule.RuleName = this.SectionName.Text;
            if (judgeRegex(regexRule.Code)
                && judgeRegex(regexRule.ValueTime)
                && judgeRegex(regexRule.Customer)
                && judgeRegex(regexRule.Location)
                && judgeRegex(regexRule.ArchitecherArea)
                && judgeRegex(regexRule.SingleValue)
                && judgeRegex(regexRule.TotalValue))
            {
                bool result = regexConfigurer.SetRegexRule(regexRule.RuleName, regexRule);
                if (result)
                {
                    AddRuleListItem(regexRule.RuleName);
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


        private void DeleteRule_Click(object sender, EventArgs e)
        {
            string SectionName = this.SectionName.Text;
            if (string.IsNullOrWhiteSpace(SectionName))
            {
                MessageBox.Show("请选择或输入要删除的规则！", "缺少规则名称！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string result = regexConfigurer.RemoveRegexRule(SectionName);
            if (result == "Success")
            {
                RemoveListItem(SectionName);
                MessageBox.Show("已成功删除规则"+SectionName + "！", "删除成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(result == "Error")
            {
                MessageBox.Show("系统出了点小问题，删除失败了，请稍后尝试！", "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (result == "Undifined")
            {
                MessageBox.Show("删除失败，未能找到改规则！", "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RuleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RuleList.SelectedItem != null)
            {
                this.SectionName.Text = this.RuleList.SelectedItem.ToString();
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
            }
            else
            {
                this.SectionName.Text = "";
                this.CodeRegex.Text = "";
                this.ValueTimeRegex.Text = "";
                this.CustomerRegex.Text = "";
                this.LocationRegex.Text = "";
                this.ArchitecherAreaRegex.Text = "";
                this.SingleValueRegex.Text = "";
                this.TotalValueRegex.Text = "";
            }
        }


        /// <summary>
        /// 模板列表添加新值
        /// </summary>
        /// <param name="regexRule"></param>
        private void AddRuleListItem(string RuleName)
        {
            int index = this.RuleList.FindStringExact(RuleName);
            if(index < 0)
            {
                this.RuleList.Items.Add(RuleName);
            }
        }
        /// <summary>
        /// 模板列表删除值
        /// </summary>
        /// <param name="regexRule"></param>
        private void RemoveListItem(string RuleName)
        {
            int index = this.RuleList.FindStringExact(RuleName);
            if(index >= 0)
            {
                this.RuleList.Items.RemoveAt(index);
            }
        }
        /// <summary>
        /// 窗口初始化规则列表初始化
        /// </summary>
        private void initialListItem()
        {
            List<string> sectionNames = regexConfigurer.GetAllSectionList();
            foreach(string Name in sectionNames)
            {
                this.RuleList.Items.Add(Name);
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
