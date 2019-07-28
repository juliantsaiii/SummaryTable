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
        public static void StartSummary(List<FileInfo> wordlist)
        {
            WordHelper wordHelper = new WordHelper();
            List<ReportTemplate> reportlist = new List<ReportTemplate>();//报告抓取结果集合
            foreach (FileInfo wordinfo in wordlist)
            {
                wordHelper.OpenWord(wordinfo.FullName);
                string wordContent = wordHelper.getWordContent();
                if (wordContent.Length > 10)//过滤打开的运行时文件或不正常文件
                {
                    ReportTemplate report = GetEntityValue(wordContent);
                    reportlist.Add(report);
                }
            }
        }
        /// <summary>
        /// 抓取字符串中的有效信息并赋值给实体类
        /// </summary>
        /// <param name="content">word字符流</param>
        /// <returns></returns>
        public static ReportTemplate GetEntityValue(string content)
        {
            ReportTemplate report = new ReportTemplate();

            report.Code = GetUsefulContent.getCode(content);
            report.ValueTime = GetUsefulContent.getValueTime(content);
            report.Customer = GetUsefulContent.getCustomer(content);


            return report;
        }

    }
}
