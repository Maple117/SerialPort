using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCom
{
    public class YmodemClass
    {
        /**
         * 为Byte数组计算两位CRC校验
         * @param buf（验证的byte数组）
         * @return byte[] 类型的两字节crc校验码
         */
        public static byte[] setParamCRC(byte[] buf)
        {
            int checkCode = 0;
            checkCode = crc_16_CCITT(buf, buf.Length);
            byte[] crcByte = new byte[2];
            crcByte[0] = (byte)((checkCode >> 8) & 0xff);
            crcByte[1] = (byte)(checkCode & 0xff);
            // 将新生成的byte数组添加到原数据结尾并返回
            return crcByte;
        }

        /**
         * CRC-16/CCITT x16+x12+x5+1 算法
         *
         * info
         * Name:CRC-16/CCITT
         * Width:16
         * Poly:0x1021
         * Init:0x00
         * RefIn:False
         * RefOut:False
         * XorOut:0x0000
         * @param bytes 待校验byte【】 数组
         * @param length
         * @return int类型16进制crc校验码
         */
        public static int crc_16_CCITT(byte[] bytes, int length)
        {
            int crc = 0x00; // initial value
            int polynomial = 0x1021; // poly value
            for (int index = 0; index < bytes.Length; index++)
            {
                byte b = bytes[index];
                for (int i = 0; i < 8; i++)
                {
                    Boolean bit = ((b >> (7 - i) & 1) == 1);
                    Boolean c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit)
                        crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            ////输出String字样的16进制
            //String strCrc = Integer.toHexString(crc).toUpperCase();
            //System.out.println(strCrc);
            return crc;
        }

        /**
         * 对buf中offset以前crcLen长度的字节作crc校验，返回校验结果
         * @param  buf
         * @param crcLen
         */
        private static int CalcCRC(byte[] buf, int offset, int crcLen)
        {
            int start = offset;
            int end = offset + crcLen;
            int crc = 0x00; // initial value
            int polynomial = 0x1021;
            for (int index = start; index < end; index++)
            {
                byte b = buf[index];
                for (int i = 0; i < 8; i++)
                {
                    Boolean bit = ((b >> (7 - i) & 1) == 1);
                    Boolean c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit)
                        crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            return crc;
        }

        /***
         * CRC校验是否通过
         * @param srcByte
         * @param length(验证码字节长度)
         * @return 布尔类型 校验成功-true 、 校验失败-false
         */
        public static Boolean isPassCRC(byte[] srcByte, int length)
        {

            // 取出除crc校验位的其他数组，进行计算，得到CRC校验结果
            int calcCRC = CalcCRC(srcByte, 3, srcByte.Length-length - 3);//因为我的起始标识不算入校验数据中，所以从索引为1开始计算，若是所有数据都需要计算则改成0，并且长度也不需要-1
            byte[] bytes = new byte[2];
            bytes[0] = (byte)((calcCRC >> 8) & 0xff);
            bytes[1] = (byte)(calcCRC & 0xff);

            // 取出CRC校验位，进行计算
            int i = srcByte.Length;
            byte[] b = { srcByte[i - 2], srcByte[i - 1] };

            // 比较
            return bytes[0] == b[0] && bytes[1] == b[1];
        }

        // public void YMODEM_Recive(byte[] buf)
        //{
        //    try
        //    {
                
        //        byte[] receivedData = new byte[133];//创建接收数据数组serialPort.BytesToRead
        //        serialPort.Read(receivedData, 0, receivedData.Length);//读取数据
        //        string content = string.Empty;
        //        content = Encoding.Default.GetString(receivedData);
        //        Debug.WriteLine("SJ=" + content);
        //        if (receivedData[0] == 1)
        //        {
        //            if (YmodemClass.isPassCRC(receivedData, 2))
        //            {
        //                content1 = Encoding.Default.GetString(receivedData);
        //                if (receivedData[0] == 1 & receivedData[1] == 00)
        //                {
        //                    if (NUMBER1 == 2)
        //                    {
        //                        NUMBER1 = 0;
        //                        serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据 
        //                    }
        //                    else if (NUMBER1 == 0)
        //                    {
        //                        NUMBER1 = 1;
        //                        DateTime dateTimeNow = DateTime.Now;
        //                        var n = dateTimeNow.ToString("MM-dd-HH-mm-ss");
        //                        string time = string.Format("{0}", n);
        //                        string[] inheritdata = content1.Split('\0');
        //                        string str1 = System.Environment.CurrentDirectory;
        //                        spsidata = str1 + "\\" + time + inheritdata[1].Substring(1);
        //                        fs = new FileStream(spsidata, FileMode.Append);
        //                        serialPort.Write(new byte[] { ACK, C }, 0, 2);//发送一行数据 
        //                        richTextBox2.Text = "";//清空
        //                        NUMBER3 = 1;

        //                    }
        //                    serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe
        //                }
        //                else if (receivedData[1] + receivedData[2] == 255)//(serialPort.ReadByte() != ACK)
        //                {

        //                    NUMBER2++;
        //                    NUMBER3 = 0;
        //                    if (NUMBER1 == 1)
        //                    {
        //                        NUMBER1 = 2;
        //                        content1 = Encoding.Default.GetString(receivedData, 7, receivedData.Length - 9);
        //                    }
        //                    else
        //                    {
        //                        content1 = Encoding.Default.GetString(receivedData, 3, receivedData.Length - 5);
        //                    }
        //                    richTextBox2.AppendText(content1);
        //                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
        //                    richTextBox2.ScrollToCaret();//滚动到光标处
        //                    if (NUMBER2 == 100)
        //                    {
        //                        wr = new StreamWriter(fs);
        //                        wr.Write(richTextBox2.Text);
        //                        wr.Close();
        //                        richTextBox2.Text = "";//清空
        //                        NUMBER2 = 0;
        //                    }
        //                    Thread.Sleep(100);
        //                    serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据 
        //                    NUMBER3 = 1;
        //                    serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe
        //                }
        //            }
        //            else
        //            {
        //                serialPort.Write(new byte[] { NAK }, 0, 1);//发送一行数据 
        //                serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe
        //            }
        //        }
        //        else if (receivedData[0] == EOT)//(serialPort.ReadByte() != ACK)
        //        {
        //            if (NUMBER == 0)
        //            {
        //                serialPort.Write(new byte[] { NAK }, 0, 1);//发送一行数据 
        //                NUMBER++;
        //            }
        //            else
        //            {
        //                serialPort.Write(new byte[] { ACK, C }, 0, 2);//发送一行数据 
        //                NUMBER = 0;
        //            }
        //            richTextBox1.AppendText(content + " ");
        //            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        //            richTextBox1.ScrollToCaret();//滚动到光标处
        //            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe
        //        }
        //        else if (receivedData[0] == ACK)
        //        {
        //            richTextBox1.AppendText(content + " ");
        //            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        //            richTextBox1.ScrollToCaret();//滚动到光标处
        //            ymodemflag = 0;
        //            try
        //            {
        //                wr = new StreamWriter(fs);
        //                wr.Write(richTextBox2.Text);
        //                wr.Close();
        //            }
        //            catch (Exception ex) { Console.WriteLine("exception", ex.Message); }
        //            richTextBox1.AppendText("save ok");
        //            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        //            richTextBox1.ScrollToCaret();//滚动到光标处
        //            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe
        //            timer1.Stop();
        //        }
        //        else if (receivedData[0] == NAK)//(serialPort.ReadByte() != ACK)
        //        {
        //            richTextBox1.AppendText(content + " ");
        //            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        //            richTextBox1.ScrollToCaret();//滚动到光标处
        //            serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据 
        //            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffe

        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //        richTextBox1.Text = "";//清空
        //    }

        //}


    }

}
