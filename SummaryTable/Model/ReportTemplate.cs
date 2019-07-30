using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Model
{
    /// <summary>
    /// 项目统计表实体
    /// </summary>
    public class ReportTemplate
    {
        /// <summary>
        /// 主键序列
        /// </summary>
        public string ID { get; set; }

        //抓取信息
        /// <summary>
        /// 评估编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 价值时点
        /// </summary>
        public string ValueTime { get; set; }
        /// <summary>
        /// 委托方名称
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 项目坐落
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public string ArchitecherArea { get; set; }
        /// <summary>
        /// 评估单价
        /// </summary>
        public string SingleValue { get; set; }
        /// <summary>
        /// 评估总价
        /// </summary>
        public string TotalValue { get; set; }

        //固定信息
        /// <summary>
        /// 出具日期
        /// </summary>
        public string IssuanceDate { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public string ProjectProperty { get; set; }
        /// <summary>
        /// 估价目的
        /// </summary>
        public string PurposeOfValuation { get; set; }
        /// <summary>
        /// 评估方法
        /// </summary>
        public string MethodOfValuation { get; set; }
        /// <summary>
        /// 土地面积
        /// </summary>
        public string LandArea { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        public string Auditors { get; set; }
        /// <summary>
        /// 评估人员
        /// </summary>
        public string Evaluator { get; set; }
        /// <summary>
        /// 估价师
        /// </summary>
        public string Valuer { get; set; }
        /// <summary>
        /// 项目承接人
        /// </summary>
        public string ProjectUndertaker { get; set; }
        /// <summary>
        /// 项目来源
        /// </summary>
        public string ProjectSource { get; set; }
    }
}
