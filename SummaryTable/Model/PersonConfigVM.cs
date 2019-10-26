using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryTable.Model
{
    public class PersonConfigVM
    {
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
        /// 查询规则1
        /// </summary>
        public string FileName1 { get; set; }
        /// <summary>
        /// 查询规则2
        /// </summary>
        public string FileName2 { get; set; }
    }
}
