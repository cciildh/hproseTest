using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    /// <summary>
    /// 医保对外引用接口类
    /// </summary>
    public class CInsureShare_XYS
    {
        #region "东软新动态链接库函数声明"
        /// <summary>
        /// 动态链接库初始化函数
        /// </summary>
        /// <returns>0  - SUCCESS   -1 - FAILURE</returns>
        /// <remarks>初始化函数 检查整个运行环境：包括网络环境、运行所需文件、参数等的检查</remarks>
        [DllImport(@"D:\Client(大市新2021-5-10)\Client(大市新2020-12-10)\SiInterface.dll", EntryPoint = "INIT", CharSet = CharSet.Auto)]
        public extern static int Init(out string pErrMsg);
        //public Declare Function Init Lib "SiInterface.dll" Alias "INIT" (ByVal pErrMsg As String) As Integer, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl

        /// <summary>
        /// 交易函数
        /// </summary>
        /// <returns>0  - SUCCESS   小于1 - FAILURE</returns>
        /// <remarks>所有的医保的查询,认证,申报,交易都通过一个函数调用,根据输入的业务编号调用不同的业务处理,并且组织不同的输入参数和返回不同的数据</remarks>
        [DllImport(@"D:\Client(大市新2021-5-10)\Client(大市新2020-12-10)\SiInterface.dll", EntryPoint = "BUSINESS_HANDLE", CharSet = CharSet.Ansi)]
        public extern static int Business_Handle( string InputData, StringBuilder OutputData);
        //public Declare Function Business_Handle Lib "SiInterface.dll" Alias "BUSINESS_HANDLE" (ByVal InputData As String, ByVal OutputData As String) As Integer
        #endregion
    }
}
