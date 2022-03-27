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

        /// <summary>
        /// 通过特定字符串及截取长度获取目标字符串
        /// </summary>
        /// <param name="content">全文字符串</param>
        /// <param name="StartChars">特定字符串</param>
        /// <param name="Length">截取长度</param>
        /// <returns>目标字符串</returns>
        public static string CommonMethod(string content,string StartChars,int Length)
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
        public static string FindByRegex(string content,string regexPattern)
        {
            Match match = Regex.Match(content, regexPattern);
            return match.Value;
        }

        /// <summary>
        /// 评估编号
        /// </summary>
        public static string getCode(string content){
            string result = FindByRegex(content, @"估价报告编号：.{1,25}估价项目名称");//大报告模板
            result = result.Replace("估价报告编号：", "").Replace("估价项目名称", "");
            if (string.IsNullOrWhiteSpace(result))
            {
                result = CommonMethod(content, "致估价委托人函", 21);//小报告
            }
            return result;
        }
        /// <summary>
        /// 价值时点
        /// </summary>
        public static string getValueTime(string content){
            string result = CommonMethod(content, "价值时点为", 11);
            result = TimeConvert(result);
            return result;
        }
        /// <summary>
        /// 委托方名称
        /// </summary>
        public static string getCustomer(string content){
            string result = "";
            //大报告模板
            if (string.IsNullOrWhiteSpace(result) && content.Contains("房地产抵押估价报告"))
            {
                result = FindByRegex(content, @"对.{2,12}位于");
                result = result.Replace("对", "").Replace("位于", "");
            }
            //工商报告单
            if (string.IsNullOrWhiteSpace(result) && content.Contains("工商银行"))
            {
                result = FindByRegex(content, @"对.{2,12}位于");
                result = result.Replace("对", "").Replace("位于", "");
            }
            //中信报告单
            if (string.IsNullOrWhiteSpace(result) && content.Contains("中信银行"))
            {
                result = FindByRegex(content, @"对.{2,12}所属");
                result = result.Replace("对", "").Replace("所属", "");
            }
            result = result.Replace("所属", "");
            return result;
        }

        /// <summary>
        /// 项目来源
        /// </summary>
        public static string getProjectSource(string content)
        {
            string result = "";
            //大报告模板
            if (string.IsNullOrWhiteSpace(result) && content.Contains("房地产抵押估价报告"))
            {
                result = FindByRegex(content, @"估价委托人：.{10,16}房地产估价机构");
                result = result.Replace("估价委托人：", "").Replace("房地产估价机构", "");
            }
            if (string.IsNullOrWhiteSpace(result) )
            {
                result = FindByRegex(content, @"号.{10,16}：");
                result = result.Replace("号", "").Replace("：", "");
            }
            return result;
        }

        /// <summary>
        /// 项目坐落
        /// </summary>
        public static string getLocation(string content){
            string result = FindByRegex(content, @"位于.{10,40}住宅房地产");
            result = result.Replace("位于", "").Replace("住宅房地产", "");
            return result;
        }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public static string getArchitecherArea(string content){
            string result = FindByRegex(content, @"建筑面积为.{2,7}平方米");
            result = result.Replace("建筑面积为", "").Replace("平方米", "");
            return result;
        }
        /// <summary>
        /// 评估单价
        /// </summary>
        public static string getSingleValue(string content){
            string result = FindByRegex(content, @"单位面积价格为\d{2,7}元/m2");
            result = result.Replace("单位面积价格为", "").Replace("元/m2", "");
            return result;
        }
        /// <summary>
        /// 评估总价 房地产市场价值为202万元
        /// </summary>
        public static string getTotalValue(string content){
            string result = FindByRegex(content, @"￥\d{2,7}万元");//大报告模板
            result = result.Replace("￥", "").Replace("万元", "");
            if (string.IsNullOrWhiteSpace(result))
            {
                result = FindByRegex(content, @"房地产市场价值为\d{2,7}万元");
                result = result.Replace("房地产市场价值为", "").Replace("万元", "");
            }
            return result;
        }
    }
}
