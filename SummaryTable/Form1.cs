using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SummaryTable.Helper;

namespace SummaryTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialSectionSelect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new RegexConfigurer().temptest();
            this.textBox1.Text= GetFilePath();
        }

        private string GetFilePath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.textBox2.AppendText("你所选择的材料文件夹目录是："+foldPath+"\r\n");
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return foldPath;
            }
            return "";
        }
        /// <summary>
        /// 一键生成汇总表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //得到报告筛选规则
            RuleConfigHelper ruleConfigHelper = new RuleConfigHelper();
            RuleConfigHelper.ReadConfig();

            //wordlist用于存储评估报告文档文件信息集合
            List<FileInfo> wordlist = new List<FileInfo>();
            //获取所有类型的文件
            List<FileInfo> fileNames = ToolSet.TogetFile(this.textBox1.Text,2);

            this.textBox2.AppendText("目录包含以下Word评估报告：\r\n");
            foreach (FileInfo fileName in fileNames)
            {
                //过滤非评估报告类的文件
                if (fileName.Extension.Contains("doc")&&(fileName.Name.ToUpper().Contains(RuleConfigHelper.FileName1) || fileName.Name.ToUpper().Contains(RuleConfigHelper.FileName2)))
                {
                    this.textBox2.AppendText(" -- "+fileName.Name + "\r\n");
                    wordlist.Add(fileName);
                }
            }
            this.textBox2.AppendText($"共计{wordlist.Count()}个\r\n");

            //调用汇总方法
            string workinfo = ToolSet.StartSummary(wordlist);
            this.textBox2.AppendText(workinfo);
            //this.textBox2.AppendText(ToolSet.information);
        }

        /// <summary>
        /// 清空提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
        }
        /// <summary>
        /// 初始化模板下拉框
        /// </summary>
        private void InitialSectionSelect()
        {
            RegexConfigurer myRegexConfigurer = new RegexConfigurer();
            string[] sectionNames = myRegexConfigurer.GetAllSectionList().ToArray();
            this.SectionSelect.Items.AddRange(sectionNames);
        }
    }
}
