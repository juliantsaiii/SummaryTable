using Aspose.Cells;
using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //D:\GitHub_Archive\SummaryTable\SummaryTable\bin\Debug
            string basepath = Directory.GetCurrentDirectory();
            string path = @"{}basepath\SummaryTemplate.xlsx";
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Open(path);
            designer.SetDataSource(dt);
            //根据数据源处理生成报表内容
            designer.Process();
            //保存Excel文件
            //string fileToSave = Server.MapPath("~/UploadFiles/Upload");
            //string filename = "党风室详情表- " + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            //designer.Save(Server.MapPath("/UploadFiles/Upload/") + filename, FileFormatType.Excel2003);
        }
    }
}
