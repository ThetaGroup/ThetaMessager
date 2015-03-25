using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThetaMessager.Utils;

namespace TheataMessager
{
    class ComUtils
    {
        private static string CTRLZ = ((char)26).ToString();
        private static string NEW_LINE = "\r\n";
        private static string SEND_CMD = "AT+CMGS=";
        private static string TEST_CMD = "AT+CMGF=1";

        private static long receivedCount = 0;
        private static StringBuilder builder = new StringBuilder();

        private static SerialPort com;
        private static Queue<SendInfo> sendQueue;

        private static bool isInit = false;
        private static bool isReady = true;

        public static void init(string portName, int baudRate)
        {
            if (!isInit)
            {
                com = new SerialPort(portName, baudRate);
                com.NewLine = NEW_LINE;
                com.RtsEnable = true;
                com.DataReceived += comDataReceived;

                sendQueue = new Queue<SendInfo>();

                isInit = true;
            }
        }

        private static void comDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = com.BytesToRead;
            byte[] buf = new byte[n];
            receivedCount += n;
            com.Read(buf, 0, n);
            builder.Clear();
            
            builder.Append(Encoding.ASCII.GetString(buf));
            string showLog = builder.ToString();
            
            isReady = true;
        }

        public static void send(SendInfo sendInfo)
        {
            sendQueue.Enqueue(sendInfo);
        }

        private static void checkSendQueue()
        {
            while (true)
            {
                if (sendQueue.Count == 0)
                {
                    Thread.Sleep(100);
                }
                while (sendQueue.Count > 0)
                {
                    SendInfo sendInfo = sendQueue.Dequeue();
                    physicalSend(sendInfo);
                }
            }
        }

        private static void physicalSend(SendInfo sendInfo)
        {
            string phoneNo = sendInfo.phoneNo;
            string message = sendInfo.message;
            
            tunnelWrite(SEND_CMD+phoneNo);
            tunnelWrite(message+CTRLZ);
        }

        private static void tunnelWrite(string cmd)
        {
            while (!isReady)
            {

            }
            com.WriteLine(cmd);
            isReady = false;
        }

        public static void open()
        {
            if (isInit && !com.IsOpen)
            {
                com.Open();
                Thread.Sleep(1000);
                Thread sendThread = new Thread(new ThreadStart(checkSendQueue));
                sendThread.Start();
            }
        }

        public static void close()
        {
            if (isInit && com.IsOpen)
            {
                com.Close();
            }
        }

    }
}