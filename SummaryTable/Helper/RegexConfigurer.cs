using SummaryTable.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Helper
{
    public class RegexConfigurer
    {
        public static string iniConfigPath;//正则规则ini配置文件目录
        private IniFile IniHelper;

        public RegexConfigurer()
        {
            iniConfigPath = System.Environment.CurrentDirectory + "\\RegexRule.ini";
            IniHelper = new IniFile(iniConfigPath);
        }


        /// <summary>
        /// 获取自定义抓取规则的节点对象信息
        /// </summary>
        /// <param name="key">配置节点key值</param>
        /// <returns>包含对应节点信息的实体类对象</returns>
        public RegexRule GetRegexRule(string SectionName)
        {
            RegexRule regexRule = new RegexRule();
            regexRule.Code = IniHelper.ReadString(SectionName, "Code", "未能正确读取__(n,m)__评估编号");
            regexRule.ValueTime = IniHelper.ReadString(SectionName, "ValueTime", "未能正确读取__(n,m)__价值时点");
            regexRule.Customer = IniHelper.ReadString(SectionName, "Customer", "未能正确读取__(n,m)__委托方名称");
            regexRule.Location = IniHelper.ReadString(SectionName, "Location", "未能正确读取__(n,m)__项目坐落");
            regexRule.ArchitecherArea = IniHelper.ReadString(SectionName, "ArchitecherArea", "未能正确读取__(n,m)__建筑面积");
            regexRule.SingleValue = IniHelper.ReadString(SectionName, "SingleValue", "未能正确读取__(n,m)__评估单价");
            regexRule.TotalValue = IniHelper.ReadString(SectionName, "TotalValue", "未能正确读取__(n,m)__评估总价");
            return regexRule;
        }



        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="regexRule"></param>
        /// <returns></returns>
        public bool SetRegexRule(string SectionName,RegexRule regexRule)
        {
            try
            {
                IniHelper.WriteString(SectionName, "Code", regexRule.Code);
                IniHelper.WriteString(SectionName, "ValueTime", regexRule.ValueTime);
                IniHelper.WriteString(SectionName, "Customer", regexRule.Customer);
                IniHelper.WriteString(SectionName, "Location", regexRule.Location);
                IniHelper.WriteString(SectionName, "ArchitecherArea",regexRule.ArchitecherArea);
                IniHelper.WriteString(SectionName, "SingleValue", regexRule.SingleValue);
                IniHelper.WriteString(SectionName, "TotalValue", regexRule.TotalValue);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void temptest()
        {
            IniHelper.WriteString("正式报告模板", "报告编号0", "000000");
            IniHelper.WriteString("正式报告模板", "报告编号1", "111111");
            IniHelper.WriteString("正式报告模板", "报告编号2", "222222");

            IniHelper.WriteString("预评估", "报告编号0", "0");
            IniHelper.WriteString("预评估", "报告编号1", "1");
            IniHelper.WriteString("预评估", "报告编号2", "8888888888888");

            IniHelper.ReadString("预评估", "报告编号2","defalt");
        }

    }
}
