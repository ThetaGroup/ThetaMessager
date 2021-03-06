﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThetaMessager.Commons;
using ThetaMessager.Utils;

namespace TheataMessager
{
    class ComUtils
    {
        private static string CTRLZ = ((char)26).ToString();
        private static string NEW_LINE = "\r\n";
        private static string SEND_CMD = "AT+CMGS=";
        private static string TEST_CMD = "AT+CMGF=1";
        private static string DELETE_CMD = "AT+CMGD=";
        private static string LIST_CMD = "AT+CMGL=\"REC UNREAD\"";
        private static string OK_RSP = "OK";
        private static string ERROR_RSP = "ERROR";
        private static string DETAIL_RSP = "\r\n>";
        private static string LIST_SPLIT_TAG = "+CMGL";

        private static long receivedCount = 0;
        private static int maxRetry = 1000;
        public static StringBuilder builder = new StringBuilder();
        public static StringBuilder log = new StringBuilder();

        private static SerialPort com;
        private static Queue<SendInfo> sendQueue;
        
        private static bool forceShutdown = false;
        public static bool isInit = false;
        public static bool isReady = true;        

        public static string[] searchPortNames()
        {
            return SerialPort.GetPortNames();
        }

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
            Thread.Sleep(500);
            int n = com.BytesToRead;
            byte[] buf = new byte[n];
            receivedCount += n;
            com.Read(buf, 0, n);

            string received = Encoding.ASCII.GetString(buf);
            string saved = builder.ToString();
            if (saved.Contains(OK_RSP) || saved.Contains(ERROR_RSP)|| saved.Contains(DETAIL_RSP))
            {
                log.Append(builder);
                builder.Clear();
            }
            builder.Append(received);
            string showLog = builder.ToString();      
            if (received.Contains(OK_RSP) || received.Contains(ERROR_RSP)||received.Contains(DETAIL_RSP))
            {                
                isReady = true;
            }   
        }

        public static void send(SendInfo sendInfo)
        {
            sendQueue.Enqueue(sendInfo);
        }

        private static void checkSendQueue()
        {
            int count = 0;
            while (!forceShutdown)
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

            tunnelWrite(SEND_CMD+"\""+phoneNo+"\"");
            tunnelWrite(message+CTRLZ);
        }

        private static void tunnelWrite(string cmd)
        {
            waitForReady();
            com.WriteLine(cmd);
            log.Append(cmd);
            isReady = false;
        }

        public static void clearMessage(int i)
        {
            tunnelWrite(DELETE_CMD + i);       
        }

        public static string[] listReceivedMessages()
        {
            tunnelWrite(LIST_CMD);
            waitForReady();
            string receivedListString = builder.ToString();
            string[] result = receivedListString.Split(new string[]{LIST_SPLIT_TAG},StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        private static void waitForReady()
        {
            int count = 0;
            while (!isReady && !forceShutdown)
            {

            }
            Thread.Sleep(500);
        }

        public static void Shutdown()
        {
            forceShutdown = true;
        }

        public static bool testTunnel()
        {
            bool result = false;
            tunnelWrite(TEST_CMD);
            waitForReady();
            if (builder.ToString().Contains(OK_RSP))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
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