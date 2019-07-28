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
        //主键
        public string ID { get; set; }
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
    }
}
