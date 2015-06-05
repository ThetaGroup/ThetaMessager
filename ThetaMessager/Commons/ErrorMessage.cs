using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThetaMessager.Commons
{
    class ErrorMessage
    {
        public static string ERROR_USER_INFO_IS_WRONG = "用户名或密码错误。";

        public static string ERROR_NODE_HAS_NOT_BEEN_INITIALIZED = "该节点尚未编辑";

        public static string ERROR_MESSAGE_SEND_INFO_IS_NOT_ENOUGH = "发送信息不完全";

        public static string ERROR_COM_PORT_OPEN_FAIL = "COM端口打开失败";

        public static string NORMAL_COM_PORT_OPEN_OK = "COM端口打开成功";

        public static string EDIT_INFO_NOT_COMPLETE = "终端信息不完整";

        public static string COM_LIST_IS_EMPTY = "未搜索到可用的com端口";

        public static string MESSAGE_LIST_IS_EMPTY = "未搜索到可用的指令内容";

        public static string PASSWORD_NOT_SAME = "两次输入密码不一致请重新输入";

        public static string PASSWORD_INFO_NOT_ENOUGH = "密码信息不完整请重新输入";

        public static string OLD_PASSWORD_IS_WRONG = "旧密码不正确请重新输入";

        public static string PASSWORD_SET_SUCCESS = "密码重置成功";

        public static string OPERATION_TIMEOUT = "操作超时";

        public static string ERROR_COM_NOT_OPEN = "COM口未打开";
        
    }
}
