
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Buffalo.DBTools
{
    /// <summary>
    /// 版本信息
    /// </summary>
    public class ToolVersionInfo
    {
        
        /// <summary>
        /// 获取软件标题
        /// </summary>
        /// <param name="defaultTitle">默认标题</param>
        /// <param name="ass"></param>
        /// <returns></returns>
        public static string GetTitle(string defaultTitle,Assembly ass)
        {
            string title = defaultTitle;
            
            return GetToolVerInfo(title, ass);
        }

        /// <summary>
        /// 软件标题版本信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="ass"></param>
        /// <returns></returns>
        public static string GetToolVerInfo(string title, Assembly ass)
        {

            string ver = ass.GetName().Version.ToString();
            StringBuilder sbInfo = new StringBuilder();
            sbInfo.Append(title);
            sbInfo.Append("   [v");
            sbInfo.Append(ver);
            sbInfo.Append("]");
            return sbInfo.ToString();
        }
        
    }
}
