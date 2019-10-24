using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Model
{
    public class RegexRule
    {
        /// 规则名称
        /// </summary>
        public string RuleName { get; set; }
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
    }
}
