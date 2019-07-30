using Aspose.Cells;
using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryTable.Helper
{
    /// <summary>
    /// 用于导出excel项目汇总表
    /// </summary>
    public static class CreateSummary
    {
        public static void StartCreate(List<ReportTemplate> reportlist)
        {
            //将list集合转为DataTable方便模板方法使用
            ListToDataTableHelper listHelper = new ListToDataTableHelper();
            DataTable dt = listHelper.ToDataTable(reportlist);
            string basepath = Directory.GetCurrentDirectory();
            string path = $"{basepath}\\SummaryTemplate.xlsx";
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Open(path);
            designer.SetDataSource(dt);
            //根据数据源处理生成报表内容
            designer.Process();

            //保存Excel文件
            string fileToSave = GetFilePath();
            string filename = "项目统计表-江宁分公司- " + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            string fullpath = fileToSave + "\\" + filename;//完整路径
            designer.Save(fullpath, FileFormatType.Excel2003);
            
            //提示“保存成功，是否立即打开”
            if(MessageBox.Show("已为您保存至:" + fullpath + "\r\n是否立即打开？", "保存成功！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //调用系统进程打开文件
                System.Diagnostics.Process.Start(fullpath);
            }
        }

        /// <summary>
        /// 选择汇总表保存路径
        /// </summary>
        /// <returns></returns>
        private static string GetFilePath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选报告保存路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                return foldPath;
            }
            return "";
        }
    }
}
