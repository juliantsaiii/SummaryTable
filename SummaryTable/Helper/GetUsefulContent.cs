using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SummaryTable.Helper
{
    /// <summary>
    /// 用于抓取报告中的有效内容
    /// </summary>
    public static class GetUsefulContent
    {

        public static RegexWord regexWord;
        public static RegexRule regexRule;
        /// <summary>
        /// 刷新配置文件规则
        /// </summary>
        /// <param name="sectionName"></param>
        public static void ReflushRegex(string sectionName)
        {
            RegexConfigurer regexConfigurer = new RegexConfigurer();
            regexRule = regexConfigurer.GetRegexRule(sectionName);
            regexWord = getRegexWord(sectionName);
        }

        /// <summary>
        /// 评估编号
        /// </summary>
        public static string getCode(string content){
            string result = FindByRegex(content, regexWord.Code);
            result = result.Replace(getStartAndEnd(regexRule.Code)[0], "").Replace(getStartAndEnd(regexRule.Code)[1], "");
            return result;
        }
        /// <summary>
        /// 价值时点
        /// </summary>
        public static string getValueTime(string content){
            string result = FindByRegex(content, regexWord.ValueTime);
            result = result.Replace(getStartAndEnd(regexRule.ValueTime)[0], "").Replace(getStartAndEnd(regexRule.ValueTime)[1], "");
            result = TimeConvert(result);
            return result;
        }
        /// <summary>
        /// 委托方名称
        /// </summary>
        public static string getCustomer(string content){
            string result = FindByRegex(content, regexWord.Customer);
            result = result.Replace(getStartAndEnd(regexRule.Customer)[0], "").Replace(getStartAndEnd(regexRule.Customer)[1], "");
            return result;
        }
        /// <summary>
        /// 项目坐落
        /// </summary>
        public static string getLocation(string content){
            string result = FindByRegex(content, regexWord.Location);
            result = result.Replace(getStartAndEnd(regexRule.Location)[0], "").Replace(getStartAndEnd(regexRule.Location)[1], "");
            return result;
        }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public static string getArchitecherArea(string content){
            string result = FindByRegex(content, regexWord.ArchitecherArea);
            result = result.Replace(getStartAndEnd(regexRule.ArchitecherArea)[0], "").Replace(getStartAndEnd(regexRule.ArchitecherArea)[1], "");
            return result;
        }
        /// <summary>
        /// 评估单价
        /// </summary>
        public static string getSingleValue(string content){
            string result = FindByRegex(content, regexWord.SingleValue);
            result = result.Replace(getStartAndEnd(regexRule.SingleValue)[0], "").Replace(getStartAndEnd(regexRule.SingleValue)[1], "");
            return result;
        }
        /// <summary>
        /// 评估总价 房地产市场价值为202万元
        /// </summary>
        public static string getTotalValue(string content)
        {
            string result = FindByRegex(content, regexWord.TotalValue);
            result = result.Replace(getStartAndEnd(regexRule.TotalValue)[0], "").Replace(getStartAndEnd(regexRule.TotalValue)[1], "");
            return result;
        }

        public static RegexWord getRegexWord(string sectionName)
        {
            RegexWord regexWord = new RegexWord();
            regexWord.Code = RegexAnalysis(regexRule.Code);
            regexWord.ValueTime = RegexAnalysis(regexRule.ValueTime);
            regexWord.Customer = RegexAnalysis(regexRule.Customer);
            regexWord.Location = RegexAnalysis(regexRule.Location);
            regexWord.ArchitecherArea = RegexAnalysis(regexRule.ArchitecherArea);
            regexWord.SingleValue = RegexAnalysis(regexRule.SingleValue);
            regexWord.TotalValue = RegexAnalysis(regexRule.TotalValue);
            return regexWord;
        }
        public static string RegexAnalysis(string singleRule)
        {
            string[] temp = Regex.Split(singleRule, "__");
            string result = temp[0] + "." + temp[1] + temp[2];
            return result;
        }
        public static string[] getStartAndEnd(string singleRule)
        {
            //前缀__{6,7}__后缀
            string[] temp = Regex.Split(singleRule, "__");
            string[] startAndEnd = new string[2];
            startAndEnd[0] = temp[0] == "" ? "蔡宗麟大帅逼" : temp[0] ;
            startAndEnd[1] = temp[2] == "" ? "蔡宗麟大帅逼" : temp[0];
            return startAndEnd;
        }
        /// <summary>
        /// 通过特定字符串及截取长度获取目标字符串
        /// </summary>
        /// <param name="content">全文字符串</param>
        /// <param name="StartChars">特定字符串</param>
        /// <param name="Length">截取长度</param>
        /// <returns>目标字符串</returns>
        public static string CommonMethod(string content, string StartChars, int Length)
        {
            if (content.IndexOf(StartChars) < 0)
            {
                return "";
            }
            int StartIndex = content.IndexOf(StartChars) + (StartChars).Length;

            //如果截取末尾位置索引大于全文长度则截取到全文末尾处
            int distance = content.Length - (StartIndex + Length + 1);
            if (distance < 0)
            {
                return content.Substring(StartIndex, Length + distance);
            }
            return content.Substring(StartIndex, Length);
        }

        /// <summary>
        /// 将中文格式长日期转为YYYY/MM/DD，并去除月份日份小于10的首位0
        /// </summary>
        /// <param name="OriginTime"></param>
        /// <returns></returns>
        public static string TimeConvert(string OriginTime)
        {
            char[] separators = { '年', '月', '日' };
            string[] content = OriginTime.Split(separators);
            if (content.Length < 3)
            {
                return "";
            }
            string YYYY = content[0];
            string MM = content[1];
            string DD = content[2];
            return YYYY + "/" + MM + "/" + DD;
        }


        /// <summary>
        /// 通过正则表达式找出文中符合规则的内容
        /// </summary>
        /// <param name="content">全文字符串</param>
        /// <param name="regexPattern">正则表达式</param>
        /// <returns></returns>
        public static string FindByRegex(string content, string regexPattern)
        {
            Match match = Regex.Match(content, regexPattern);
            return match.Value;
        }

    }
}
