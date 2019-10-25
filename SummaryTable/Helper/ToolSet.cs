using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Helper
{
    class ToolSet
    {
        /// <summary>
        /// 用于展示提示信息
        /// </summary>
        public static string information = "";
        public static string workinfo = "";

        /// <summary>
        /// 文件信息集合
        /// </summary>
        public static List<FileInfo> fileNames = new List<FileInfo>();


        public static List<FileInfo> TogetFile(string path,int indent)
        {
            information = "";//清空展示信息
            fileNames.Clear();//清空文件名集合

            try {
                getDirectory(path, indent);
                return fileNames;
            }
            catch
            {
                information += "扫描文件出错\r\n";
                return fileNames;
            }
            finally
            {
                information += "扫描完成\r\n";                
            }
        }

        /// <summary>
        /// 获得指定路径下所有文件名
        /// </summary>
        /// <param name="path">文件写入流</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getFileName(string path, int indent)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                for (int i = 0; i < indent; i++)
                {
                    information += "  ";
                }
                information+=f.Name+"\r\n";
                fileNames.Add(f);
            }
        }

        /// <summary>
        /// 获得指定路径下所有子目录名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getDirectory(string path, int indent)
        {
            getFileName(path, indent);
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                for (int i = 0; i < indent; i++)
                {
                    information += "  ";
                }
                information += "文件夹：" + d.Name+"\r\n";
                getDirectory(d.FullName, indent + 2);
                information += "\r\n";
            }
        }

        /// <summary>
        /// 抓取word中的文本信息并汇总至表格内
        /// </summary>
        /// <param name="wordlist"></param>
        public static string StartSummary(List<FileInfo> wordlist,string SectionName)
        {
            HouseConfigHelper.ReadConfig();//读取配置文件信息
            workinfo = "\r\n详情：\r\n";
            WordHelper wordHelper = new WordHelper();
            List<ReportTemplate> reportlist = new List<ReportTemplate>();//报告抓取结果集合
            int SuccessCount = 1,ErrorCount = 0;
            foreach (FileInfo wordinfo in wordlist)
            {
                try
                {
                    wordHelper.OpenWord(wordinfo.FullName);
                    string wordContent = wordHelper.getWordContent();
                    wordContent = wordContent.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");//去除字符串中的空格，回车，换行符，制表符
                    if (wordContent.Length > 10)//过滤打开的运行时文件或不正常文件
                    {
                        ReportTemplate report = GetEntityValue(wordContent, SectionName);
                        report.ID = SuccessCount.ToString();//ID作为计数器使用
                        reportlist.Add(report);
                        workinfo += $"{SuccessCount}:{wordinfo.Name}报告制作成功\r\n";
                        SuccessCount++;
                    }
                }
                catch (Exception e)
                {
                    ErrorCount++;
                    workinfo += $"*****{ErrorCount}:{wordinfo.Name}报告制作失败\r\n";
                }
            }
            //开始导出报告
            CreateSummary.StartCreate(reportlist);

            workinfo += $"\r\n结果：\r\n所选择的文件夹目录下共有{wordlist.Count()}份报告（.doc,.docx结尾）\r\n" +
                        $"{SuccessCount-1}份成功汇总至项目统计表；\r\n" +
                        $"{ErrorCount}份制作失败未汇总至项目统计表；\r\n" +
                        $"\r\n如制作失败，请查看上方列表中的错误提示“*****” ，生成期间请确保所有文档已关闭，防止被占用而读取失败\r\n";
            return workinfo;
        }
        /// <summary>
        /// 抓取字符串中或配置中的有效信息并赋值给实体类
        /// </summary>
        /// <param name="content">word字符流</param>
        /// <returns></returns>
        public static ReportTemplate GetEntityValue(string content,string SectionName)
        {
            ReportTemplate report = new ReportTemplate();
            //固定信息回填
            report.IssuanceDate = HouseConfigHelper.IssuanceDate;
            report.ProjectProperty = HouseConfigHelper.ProjectProperty;
            report.PurposeOfValuation = HouseConfigHelper.PurposeOfValuation;
            report.MethodOfValuation = HouseConfigHelper.MethodOfValuation;
            report.LandArea = HouseConfigHelper.LandArea;
            report.Auditors = HouseConfigHelper.Auditors;
            report.Evaluator = HouseConfigHelper.Evaluator;
            report.Valuer = HouseConfigHelper.Valuer;
            report.ProjectUndertaker = HouseConfigHelper.ProjectUndertaker;
            report.ProjectSource = HouseConfigHelper.ProjectSource;
            //抓取信息回填
            GetUsefulContent.ReflushRegex(SectionName);//刷新配置信息
            report.Code = GetUsefulContent.getCode(content);
            report.ValueTime = GetUsefulContent.getValueTime(content);
            report.Customer = GetUsefulContent.getCustomer(content);
            report.Location = GetUsefulContent.getLocation(content);
            report.ArchitecherArea = GetUsefulContent.getArchitecherArea(content);
            report.SingleValue = GetUsefulContent.getSingleValue(content);
            report.TotalValue = GetUsefulContent.getTotalValue(content);
            return report;
        }

    }
}
