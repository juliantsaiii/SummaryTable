using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SummaryTable.Model;

namespace SummaryTable.Helper
{
    public class HouseConfigHelper
    {
        /// <summary>
        /// 出具日期
        /// </summary>
        public static string IssuanceDate { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public static string ProjectProperty { get; set; }
        /// <summary>
        /// 估价目的
        /// </summary>
        public static string PurposeOfValuation { get; set; }
        /// <summary>
        /// 评估方法
        /// </summary>
        public static string MethodOfValuation { get; set; }
        /// <summary>
        /// 土地面积
        /// </summary>
        public static string LandArea { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        public static string Auditors { get; set; }
        /// <summary>
        /// 评估人员
        /// </summary>
        public static string Evaluator { get; set; }
        /// <summary>
        /// 估价师
        /// </summary>
        public static string Valuer { get; set; }
        /// <summary>
        /// 项目承接人
        /// </summary>
        public static string ProjectUndertaker { get; set; }
        /// <summary>
        /// 项目来源
        /// </summary>
        public static string ProjectSource { get; set; }

        /// <summary>
        /// 初始化读取配置文件信息
        /// </summary>
        public static void ReadConfig()
        {
            IssuanceDate = ConfigurationManager.AppSettings["IssuanceDate"];
            ProjectProperty = ConfigurationManager.AppSettings["ProjectProperty"];
            PurposeOfValuation = ConfigurationManager.AppSettings["PurposeOfValuation"];
            MethodOfValuation = ConfigurationManager.AppSettings["MethodOfValuation"];
            LandArea = ConfigurationManager.AppSettings["LandArea"];
            Auditors = ConfigurationManager.AppSettings["Auditors"];
            Evaluator = ConfigurationManager.AppSettings["Evaluator"];
            Valuer = ConfigurationManager.AppSettings["Valuer"];
            ProjectUndertaker = ConfigurationManager.AppSettings["ProjectUndertaker"];
            ProjectSource = ConfigurationManager.AppSettings["ProjectSource"];
        }

        public static void UpdateHouseConfig(PersonConfigVM personConfigVM)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IssuanceDate"].Value = personConfigVM.IssuanceDate;
            config.AppSettings.Settings["ProjectProperty"].Value = personConfigVM.ProjectProperty;
            config.AppSettings.Settings["PurposeOfValuation"].Value = personConfigVM.PurposeOfValuation;
            config.AppSettings.Settings["MethodOfValuation"].Value = personConfigVM.MethodOfValuation;
            config.AppSettings.Settings["LandArea"].Value = personConfigVM.LandArea;
            config.AppSettings.Settings["Auditors"].Value = personConfigVM.Auditors;
            config.AppSettings.Settings["Valuer"].Value = personConfigVM.Valuer;
            config.AppSettings.Settings["ProjectUndertaker"].Value = personConfigVM.ProjectUndertaker;
            config.AppSettings.Settings["ProjectSource"].Value = personConfigVM.ProjectSource;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
    public static class RuleConfigHelper
    {
        //以下条件为或条件
        /// <summary>
        /// 查询规则1
        /// </summary>
        public static string FileName1 { get; set; }
        /// <summary>
        /// 查询规则2
        /// </summary>
        public static string FileName2 { get; set; }

        /// <summary>
        /// 初始化读取配置文件信息
        /// </summary>
        public static void ReadConfig()
        {
            FileName1 = ConfigurationManager.AppSettings["FileName1"];
            FileName2 = ConfigurationManager.AppSettings["FileName2"];
        }
        public static void UpdateRuleConfig(PersonConfigVM personConfigVM)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["FileName1"].Value = personConfigVM.FileName1;
            config.AppSettings.Settings["FileName2"].Value = personConfigVM.FileName2;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

