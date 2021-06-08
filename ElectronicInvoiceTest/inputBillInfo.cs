using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicInvoiceTest
{
    public class inputBillInfo
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 1:门诊票  2:住院票
        /// </summary>
        public string theType { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal totalAmount { get; set; }
        /// <summary>
        /// 收款人全称
        /// </summary>
        public string recName { get; set; }
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string recAcct { get; set; }
        /// <summary>
        /// 收款人开户行
        /// </summary>
        public string recOpBk { get; set; }
        /// <summary>
        /// 交款人类型[1:个人  2:单位]
        /// </summary>
        public string payerPartyType { get; set; }
        /// <summary>
        /// 交款人代码[身份证号]
        /// </summary>
        public string payerPartyCode { get; set; }
        /// <summary>
        /// 交款人名称
        /// </summary>
        public string payerPartyName { get; set; }
        /// <summary>
        /// 性别[男/女]
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 交款人账号
        /// </summary>
        public string payerAcct { get; set; }
        /// <summary>
        /// 交款人开户行
        /// </summary>
        public string payerOpBk { get; set; }
        /// <summary>
        /// 交款方式[1-现金、2-POS刷卡、3-批量代扣、4-终端支付]
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 业务单号?
        /// </summary>
        public string businessNumber { get; set; }
        /// <summary>
        /// 开票人
        /// </summary>
        public string handlingPerson { get; set; }
        /// <summary>
        /// 复核人
        /// </summary>
        public string checker { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string patientNumber { get; set; }
        /// <summary>
        /// 就诊日期[yyyy-MM-dd]
        /// </summary>
        public string medicalDate { get; set; }
        /// <summary>
        /// 医疗机构类型
        /// </summary>
        public string orgType { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        public string medicalInsuranceType { get; set; }
        /// <summary>
        /// 医保编号
        /// </summary>
        public string medicalInsuranceID { get; set; }
        /// <summary>医保统筹基金支付
        /// 
        /// </summary>
        public decimal fundPayAmount { get; set; }
        /// <summary>
        /// 其他支付
        /// </summary>
        public decimal otherPayAmount { get; set; }
        /// <summary>
        /// 个人账户支付
        /// </summary>
        public decimal accountPayAmount { get; set; }
        /// <summary>
        /// 个人现金支付
        /// </summary>
        public decimal ownPayAmount { get; set; }
        /// <summary>
        /// 个人自付
        /// </summary>
        public decimal selfpaymentAmount { get; set; }
        /// <summary>
        /// 个人自费
        /// </summary>
        public decimal selfpaymentCost { get; set; }
        /// <summary>
        /// 病例号
        /// </summary>
        public string caseNumber { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string hospitalizationNumber { get; set; }
        /// <summary>
        /// 科别
        /// </summary>
        public string departmentName { get; set; }
        /// <summary>
        /// 住院日期[yyyy-MM-dd]
        /// </summary>
        public string inHospitalDate { get; set; }
        /// <summary>
        /// 出院日期[yyyy-MM-dd]
        /// </summary>
        public string outHospitalDate { get; set; }
        /// <summary>
        /// 预缴金额
        /// </summary>
        public decimal prepayAmount { get; set; }
        /// <summary>
        /// 补缴金额
        /// </summary>
        public decimal rechargeAmount { get; set; }
        /// <summary>
        /// 退费金额
        /// </summary>
        public decimal refundAmount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 起付标准
        /// </summary>
        public decimal spstand { get; set; }
        /// <summary>
        /// 乙类首自付
        /// </summary>
        public decimal bselfpayment { get; set; }
        /// <summary>
        /// 按比例自付
        /// </summary>
        public decimal ptnselfpayment { get; set; }
        /// <summary>
        /// 公务员补助
        /// </summary>
        public decimal civilSubsidy { get; set; }
        /// <summary>
        /// 师职补助
        /// </summary>
        public decimal teacherSubsidy { get; set; }
        /// <summary>
        /// 大额（病）保险报销
        /// </summary>
        public decimal linsuranceReimbursement { get; set; }
        /// <summary>
        /// 大病补充保险报销
        /// </summary>
        public decimal lsubsidiaryInsuranceReimbursement { get; set; }
        /// <summary>
        /// 医疗救助
        /// </summary>
        public decimal medicalHelp { get; set; }
        /// <summary>
        /// 产前检查费
        /// </summary>
        public decimal antenatalClinic { get; set; }
        /// <summary>
        /// 个性化其他项目信息
        /// </summary>
        public string selfMainExt { get; set; }
        /// <summary>
        /// 社会保障卡号
        /// </summary>
        public string medicalInsuranceNumber { get; set; }


        public List<FeesItem> items { get; set; }
        //public List<Aux> auxItems { get; set; }

        /// <summary>
        /// 收费项目门诊最多12个住院最多18个
        /// </summary>
        public class FeesItem
        {
            /// <summary>
            /// 项目编码
            /// </summary>
            public string itemCode { get; set; }
            /// <summary>
            /// 项目名称
            /// </summary>
            public string itemName { get; set; }
            /// <summary>
            /// 数量
            /// </summary>
            public decimal itemQuantity { get; set; }
            /// <summary>
            /// 标准
            /// </summary>
            public decimal itemStd { get; set; }
            /// <summary>
            /// 单位
            /// </summary>
            public string itemUnit { get; set; }
            /// <summary>
            /// 金额
            /// </summary>
            public decimal itemAmount { get; set; }
            /// <summary>
            /// 项目备注
            /// </summary>
            public string itemRemark { get; set; }

        }
        /// <summary>
        /// auxItems收费明细项目
        /// </summary>
        public class Aux
        {
            /// <summary>
            /// 对应项目编码
            /// </summary>
            public string auxItemRelatedCode { get; set; }
            /// <summary>
            /// 对应项目名称
            /// </summary>
            public string auxItemRelatedName { get; set; }
            /// <summary>
            /// 收费明细项目编码
            /// </summary>
            public string auxItemCode { get; set; }
            /// <summary>
            /// 收费明细项目名称
            /// </summary>
            public string auxItemName { get; set; }
            /// <summary>
            /// 收费明细项目数量
            /// </summary>
            public string auxItemQuantity { get; set; }
            /// <summary>
            /// 收费明细项目单位
            /// </summary>
            public string auxItemUnit { get; set; }
            /// <summary>
            /// 收费明细项目标准
            /// </summary>
            public string auxItemStd { get; set; }
            /// <summary>
            /// 收费明细项目金额
            /// </summary>
            public string auxItemAmount { get; set; }
            /// <summary>
            /// 收费明细项目备注
            /// </summary>
            public string auxItemRemark { get; set; }

        }
    }
}
