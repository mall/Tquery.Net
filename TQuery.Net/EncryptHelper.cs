/**  功能：加密类
 *   作者：Steven_Han 
 *   MSN： Steven_Han@live.com
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace TQuery.Net
{
    public class EncryptHelper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="Str">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string Str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Str, "MD5");
        }


    }
}
