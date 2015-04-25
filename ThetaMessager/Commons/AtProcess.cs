using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThetaMessager.Commons
{
    class AtProcess
    {
        public static string COM_INIT = "端口未初始化，正在初始化...";

        public static string COM_INIT_FINISH = "端口初始化成功!";

        public static string COM_OPEN = "端口正在打开...";

        public static string COM_OPEN_FINISH = "端口打开成功!";

        public static string COM_TEST = "正在发送端口测试指令...";

        public static string COM_TEST_FINISH = "端口测试指令执行成功!";

        public static string COM_MESSAGE_QUEUE_START = "发送队列开始执行...";

        public static string COM_MESSAGE_QUEUE_END = "发送队列结束执行...";

        public static string COM_MESSAGE_SINGLE_SEND_START = "单条终端指令发送开始...";

        public static string COM_MESSAGE_SINGLE_INFO_NAME = "终端名称:";

        public static string COM_MESSAGE_SINGLE_INFO_CMD = "指令内容:";

        public static string COM_MESSAGE_SINGLE_SEND_END = "单条终端指令发送结束!";

    }
}
