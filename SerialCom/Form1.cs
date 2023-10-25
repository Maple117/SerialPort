using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Web;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Runtime.InteropServices.ComTypes;

namespace SerialCom
{
    public partial class MainForm : Form
    {

        //实例化串口对象
        SerialPort serialPort = new SerialPort();

        String saveDataFile = null;
        FileStream saveDataFS = null;
        String openserialport =null;
        string spsidata=null;
        int ymodemflag = 0;
        const byte SOH = 1;  // Start of TeXt 128
        const byte STX = 2;  // Start of TeXt 1024
        const byte EOT = 4;  // End Of Transmission
        const byte ACK = 6;  // Positive AC knowledgement
        const byte C = 67;   // capital letter C
        const byte NAK = 21;
        int DataVolume = 0;
        string content1 = string.Empty;
        public delegate void Displaydelegate(byte[] InputBuf);
        public Displaydelegate disp_delegate;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取串口完整名字（包括驱动名字）
        /// 如果找不到类，需要添加System.Management引用，添加引用->程序集->System.Management
        /// </summary>
        Dictionary<String, String> coms = new Dictionary<String, String>();
        private void getPortDeviceName()
        {

            coms.Clear();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher
            ("select * from Win32_PnPEntity where Name like '%(COM%'"))
            {
                var hardInfos = searcher.Get();
                foreach (var hardInfo in hardInfos)
                {
                    if (hardInfo.Properties["Name"].Value != null)
                    {
                        string deviceName = hardInfo.Properties["Name"].Value.ToString();
                        int startIndex = deviceName.IndexOf("(");
                        int endIndex = deviceName.IndexOf(")");
                        string key = deviceName.Substring(startIndex + 1, deviceName.Length - startIndex - 2);
                        string name = deviceName.Substring(0, startIndex - 1);
                        //Console.WriteLine("key:" + key + ",name:" + name + ",deviceName:" + deviceName);
                        coms.Add(key, name);
                    }
                }

                //创建一个用来更新UI的委托 (主线程更新)
                this.Invoke(
                     new Action(() =>
                     {
                         comboBoxCom.Items.Clear();
                         foreach (KeyValuePair<string, string> kvp in coms)
                         {
                             comboBoxCom.Items.Add(kvp.Key + ":"+" " + kvp.Value);//更新下拉列表中的串口
                         }

                     })
                 );

            }

        }

        public const int WM_DEVICE_CHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;


        /// <summary>
        /// 检测USB串口的拔插
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE) // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICE_REMOVE_COMPLETE: // USB拔出 
                        {

                            new Thread(
                                new ThreadStart(
                                    new Action(() =>
                                    {
                                        getPortDeviceName();
                                        SerialPortDataCompareForClose();
                                    })
                                )
                            ).Start();
                        }
                        break;
                    case DBT_DEVICEARRIVAL: // USB插入获取对应串口名称     
                        {
                            new Thread(
                                new ThreadStart(
                                    new Action(() =>
                                    {
                                        getPortDeviceName(); 
                                        SerialPortDataCompareForClose();
                                        //SerialPortDataCompareForOpen();
                                    })
                                )
                            ).Start();
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }



        //初始化串口界面参数设置
        private void Init_Port_Confs()
        {
            /*------串口界面参数设置------*/

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            //string[] ss = MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");

            //comboBoxCom.Items.Add(ss);
            //添加串口
            //foreach (string s in str)
            //{
            //    //comboBoxCom.Items.Add(s);
            //    //设置默认串口选项
            //    comboBoxCom.SelectedIndex = 0;
            //}
            getPortDeviceName();

            /*------波特率设置-------*/
            string[] baudRate = { "600", "1200", "4800", "9600", "19200", "38400", "57600", "115200" };
            foreach (string s in baudRate)
            {
                comboBoxBaudRate.Items.Add(s);
            }
            comboBoxBaudRate.SelectedIndex = 7;

            /*------数据位设置-------*/
            string[] dataBit = { "5", "6", "7", "8" };
            foreach (string s in dataBit)
            {
                comboBoxDataBit.Items.Add(s);
            }
            comboBoxDataBit.SelectedIndex = 3;


            /*------校验位设置-------*/
            string[] checkBit = { "None", "Even", "Odd", "Mask", "Space" };
            foreach (string s in checkBit)
            {
                comboBoxCheckBit.Items.Add(s);
            }
            comboBoxCheckBit.SelectedIndex = 0;


            /*------停止位设置-------*/
            string[] stopBit = { "1", "1.5", "2" };
            foreach (string s in stopBit)
            {
                comboBoxStopBit.Items.Add(s);
            }
            comboBoxStopBit.SelectedIndex = 0;

            /*------数据格式设置-------*/
            radioButtonSendDataASCII.Checked = true;
            radioButtonReceiveDataASCII.Checked = true;
        }

        //加载主窗体
        private void MainForm_Load(object sender, EventArgs e)
        {

            Init_Port_Confs();

            Control.CheckForIllegalCrossThreadCalls = false;
            disp_delegate = new Displaydelegate(DispUI);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

            this.StatusDate.Text=DateTime .Now.ToShortDateString();
            this.StatusTime.Text=DateTime .Now.ToLongTimeString();
            //准备就绪              
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
            serialPort.ReadBufferSize = 40960;
            serialPort.WriteBufferSize = 40960;
            //设置数据读取超时为1秒
           // serialPort.ReadTimeout = 1000;
            timer1.Stop();
            serialPort.Close();

            buttonSendData.Enabled = false;

        }
        
        private void SerialPortDataCompareForClose()
        {
            //foreach (string data in comboBoxCom.Items)
            //{
            //    if (data == openserialport)
            //    {
            //        break;
            //    }
            //}
            SerialPortForClose();
        }
        private void SerialPortDataCompareForOpen()
        {
            Int32 num=0;
            foreach (string data in comboBoxCom.Items)
            {

                if (data == openserialport)
                {
                    comboBoxCom.SelectedIndex = num;
                    break;
                }
                num++;
            }

        }
        /// <summary>
        /// 串口关闭操作
        /// </summary>

        private void SerialPortForClose()
        {
            serialPort.Close();//关闭串口
                               //串口关闭时设置有效
            comboBoxCom.Enabled = true;
            comboBoxBaudRate.Enabled = true;
            comboBoxDataBit.Enabled = true;
            comboBoxCheckBit.Enabled = true;
            comboBoxStopBit.Enabled = true;
            radioButtonSendDataASCII.Enabled = true;
            radioButtonSendDataHex.Enabled = true;
            radioButtonReceiveDataASCII.Enabled = true;
            radioButtonReceiveDataHEX.Enabled = true;
            buttonSendData.Enabled = false;


            buttonOpenCloseCom.Text = "打开串口";
            buttonOpenCloseCom.ForeColor=Color.Black;
            if (saveDataFS != null)
            {
                saveDataFS.Close(); // 关闭文件
                saveDataFS = null;//释放文件句柄
            }
        }
        //打开串口 关闭串口
        private void ButtonOpenCloseCom_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)//串口处于关闭状态
            {

                try
                {

                    if (comboBoxCom.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error: 无效的端口,请重新选择", "Error");
                        return;
                    }
                    openserialport = comboBoxCom.SelectedItem.ToString();
                    string[] str_name = openserialport.Split(':');
                    string strSerialName = str_name[0];                     
                    string strBaudRate = comboBoxBaudRate.SelectedItem.ToString();
                    string strDataBit = comboBoxDataBit.SelectedItem.ToString();
                    string strCheckBit = comboBoxCheckBit.SelectedItem.ToString();
                    string strStopBit = comboBoxStopBit.SelectedItem.ToString();

                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDataBit = Convert.ToInt32(strDataBit);

                    serialPort.PortName = strSerialName;//串口号
                    serialPort.BaudRate = iBaudRate;//波特率
                    serialPort.DataBits = iDataBit;//数据位



                    switch (strStopBit)            //停止位
                    {
                        case "1":
                            serialPort.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            serialPort.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            serialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：停止位参数不正确!", "Error");
                            break;
                    }
                    switch (strCheckBit)             //校验位
                    {
                        case "None":
                            serialPort.Parity = Parity.None;
                            break;
                        case "Odd":
                            serialPort.Parity = Parity.Odd;
                            break;
                        case "Even":
                            serialPort.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：校验位参数不正确!", "Error");
                            break;
                    }



                    if (saveDataFile != null)
                    {
                        saveDataFS = File.Create(saveDataFile);
                    }


                    //打开串口
                    serialPort.Open();

                    //打开串口后设置将不再有效
                    comboBoxCom.Enabled = false;
                    comboBoxBaudRate.Enabled = false;
                    comboBoxDataBit.Enabled = false;
                    comboBoxCheckBit.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                    //radioButtonSendDataASCII.Enabled = false;
                    //radioButtonSendDataHex.Enabled = false;
                    //radioButtonReceiveDataASCII.Enabled = false;
                    //radioButtonReceiveDataHEX.Enabled = false;
                    buttonSendData.Enabled = true;

                    buttonOpenCloseCom.Text = "关闭串口";
                    buttonOpenCloseCom.ForeColor = Color.Red;

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
            }
            else //串口处于打开状态
            {

                SerialPortForClose();

            }
        }
        int NUMBER=0,NUMBER1=0,NUMBER2=0,NUMBER3=0;

        //接收数据
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                
                //输出当前时间
                if (checkBoxTime.Checked == true)
                {

                    DateTime dateTimeNow = DateTime.Now;
                    //dateTimeNow.GetDateTimeFormats();
                    richTextBox1.Text += string.Format("{0}\r\n", dateTimeNow);
                    //dateTimeNow.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                }
                richTextBox1.ForeColor = Color.Black;    //改变字体的颜色
                if (ymodemflag == 0)
                {
                  Thread.Sleep(50);
                  if (radioButtonReceiveDataASCII.Checked == true) //接收格式为ASCII
                  {
                    try
                    {

                        byte[] receivedData = new byte[serialPort.BytesToRead];//创建接收数据数组
                        serialPort.Read(receivedData, 0, receivedData.Length);//读取数据
                        string content = string.Empty;
                        content = Encoding.Default.GetString(receivedData);
                        richTextBox1.Text += content + "\r\n";
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "波特率是不是有问题？？？");
                        return;
                    }
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();//滚动到光标处
                    serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
                    }
                  else //接收格式为HEX
                  {
                    try
                    {
                        //string input = serialPort.ReadLine();
                        //char[] values = input.ToCharArray();
                        //foreach (char letter in values)
                        //{
                        //    // Get the integral value of the character.
                        //    int value = Convert.ToInt32(letter);
                        //    // Convert the decimal value to a hexadecimal value in string form.
                        //    string hexOutput = String.Format("{0:X}", value);
                        //    richTextBox1.AppendText(hexOutput + " ");
                        //    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        //    richTextBox1.ScrollToCaret();//滚动到光标处
                        //}
                        // save data to file
                        //if (saveDataFS != null)
                        //{
                        //    byte[] info = new UTF8Encoding(true).GetBytes(input + "\r\n");
                        //    saveDataFS.Write(info, 0, info.Length);
                        //}
                        byte[] receivedData = new byte[serialPort.BytesToRead];//创建接收数据数组
                        serialPort.Read(receivedData, 0, receivedData.Length);//读取数据
                        string content = string.Empty;
                        for (int i = 0; i < receivedData.Length; i++)
                        {
                            //ToString("X2") 为C#中的字符串格式控制符
                            //X为     十六进制
                            //2为 每次都是两位数
                            content += (receivedData[i].ToString("X2") + " ");
                        }
                        richTextBox1.AppendText(content + " ");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        richTextBox1.Text = "";//清空
                    }
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.ScrollToCaret();//滚动到光标处
                        serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
                    } 
                }
                else
                {
                    try
                    {
                        
                        Thread.Sleep(50);
                        byte[] receivedData = new byte[serialPort.BytesToRead];//创建接收数据数组
                        int datanumber = serialPort.BytesToRead;
                        if (datanumber == 133)
                        {
                            serialPort.Read(receivedData, 0, receivedData.Length);//读取数据
                            this.Invoke(disp_delegate, receivedData);

                        }
                        else if (datanumber >0)
                        {
                           serialPort.Read(receivedData,0,1);
                           switch (receivedData[0]) 
                            { 
                            case EOT:
                                if (NUMBER == 0)
                                {
                                    serialPort.Write(new byte[] { NAK }, 0, 1);//发送一行数据 
                                    NUMBER++;
                                }
                                else
                                {
                                    NUMBER=0;
                                    serialPort.Write(new byte[] { ACK, C }, 0, 2);//发送一行数据 
                                }
                                richTextBox1.AppendText("\r\n"+"EOT"+ "\r\n");
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();//滚动到光标处
                                break;
                            case NAK:
                                richTextBox1.AppendText("\r\n" + "NAK" + "\r\n");
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();//滚动到光标处
                                serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据 
                                break;
                            case ACK:
                                ymodemflag = 0; NUMBER1 = 0;
                                Debug.WriteLine(Convert.ToString(NUMBER2));
                                NUMBER2 = 0;
                                YmodemBar1.Value = 0;
                                richTextBox1.AppendText("\r\n" + "数据已经获取完毕" + "\r\n");
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();//滚动到光标处
                                timer1.Stop();
                                break;
                            }
                        }
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                    }
                    catch (Exception ex)
                    {
                       Console.WriteLine(spsidata);
                       MessageBox.Show("exception33", ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }
        string showdata = null;
        public void DispUI(byte[] receivedData)
        {
            if (YmodemClass.isPassCRC(receivedData, 2))
            {
                content1 = Encoding.Default.GetString(receivedData);
                if (receivedData[1] == 00 && NUMBER1 == 0)
                {
                    NUMBER1 = 1;
                    DateTime dateTimeNow = DateTime.Now;
                    var n = dateTimeNow.ToString("MM-dd-HH-mm-ss");
                    string time = string.Format("{0}", n);
                    string[] inheritdata = content1.Split('\0');
                    string str1 = System.Environment.CurrentDirectory;
                    DataVolume = Convert.ToInt32(inheritdata[2]);
                    spsidata = str1 + "\\" + time + inheritdata[1].Substring(1);
                   // FileStream fs = new FileStream(spsidata, FileMode.Create);
                    serialPort.Write(new byte[] { ACK, C }, 0, 2);//发送一行数据
                    richTextBox1.Text = "";//清空
                    NUMBER3 = 1;
                }
                else if (receivedData[1] + receivedData[2] == 255)//(serialPort.ReadByte() != ACK)
                {

                    NUMBER2++;
                    NUMBER3 = 1;
                    int t = DataVolume / 128;
                    if(t == 0) { t = 1; }
                    string percentage = Convert.ToString(NUMBER2*100/t);
                    if(showdata!= percentage)
                    {
                        showdata = percentage;
                        richTextBox1.Text=" ";
                        richTextBox1.AppendText("当前进度"+ showdata + "%"+ "\r\n");
                        YmodemBar1.Value= Convert.ToInt32(showdata);
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.ScrollToCaret();//滚动到光标处
                    }

                    //if (NUMBER1 == 1)
                    //{
                    //    NUMBER1 = 2;
                    //    content1 = Encoding.Default.GetString(receivedData, 3, receivedData.Length - 5);
                    //    string[] inheritdata = content1.Split('\n');
                    //    content1 = inheritdata[0];
                    //}
                    //else
                    //{

                    content1 = Encoding.Default.GetString(receivedData, 3, receivedData.Length - 5);

                    //}
                    //richTextBox1.AppendText(content1);
                    //richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    //richTextBox1.ScrollToCaret();//滚动到光标处
                    //Debug.WriteLine(content1);
                    FileStream fs = new FileStream(spsidata, FileMode.Append);
                    try
                    {
                      using (StreamWriter wr = new StreamWriter(fs))
                      {
                        wr.Write(content1);//wr.Write(content1); 
                        wr.Close();
                      }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("exception", ex.Message);
                    }
                    serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据 
                    NUMBER3 = 1;
                }
            }
            else
            {
                content1 = Encoding.Default.GetString(receivedData);
                Debug.WriteLine("NAK" + content1);
                serialPort.Write(new byte[] { NAK }, 0, 1);//发送一行数据 
            }
        }

        //发送数据
        private void ButtonSendData_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口", "Error");
                return;
            }

            String strSend = textBoxSend.Text;//发送框数据
            if (radioButtonSendDataASCII.Checked == true)//以字符串 ASCII 发送
            {
                serialPort.WriteLine(strSend);//发送一行数据 
            }
            else
            {
                //16进制数据格式 HXE 发送                
                char[] values = strSend.ToCharArray();
                foreach (char letter in values)
                {
                    // Get the integral value of the character.
                    int value = Convert.ToInt32(letter);
                    // Convert the decimal value to a hexadecimal value in string form.
                    string hexIutput = String.Format("{0:X}", value);
                    serialPort.WriteLine(hexIutput);
                }
            }
        }
        //清空接收数据框
        private void ButtonClearRecData_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        //窗体关闭时
        private void MainForm_Closing(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();//关闭串口
            }
            if (saveDataFS != null)
            {
                saveDataFS.Close(); // 关闭文件
                saveDataFS = null;//释放文件句柄
            }
        }
        //刷新串口
        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            comboBoxCom.Text = "";
            comboBoxCom.Items.Clear();
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            //添加串口
            foreach (string s in str)
            {
                comboBoxCom.Items.Add(s);
            }
            //设置默认串口
            comboBoxCom.SelectedIndex = 0;
            comboBoxBaudRate.SelectedIndex = 0;
            comboBoxDataBit.SelectedIndex = 3;
            comboBoxCheckBit.SelectedIndex = 0;
            comboBoxStopBit.SelectedIndex = 0;
        }

        // YMODEM-接收
        private void YMODEMReceive_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口", "Error");
                return;
            }
            ymodemflag = 1;
            serialPort.Write(new byte[] {C}, 0, 1);//发送一行数据 
            richTextBox1.Text += "C" + "\r\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();//滚动到光标处
            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
            timer1.Start();
        }

        // 重置串口参数设置
        private void ResetPortConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxCom.SelectedIndex = 0;
            comboBoxBaudRate.SelectedIndex = 0;
            comboBoxDataBit.SelectedIndex = 3;
            comboBoxCheckBit.SelectedIndex = 0;
            comboBoxStopBit.SelectedIndex = 0;
            radioButtonSendDataASCII.Checked = true;
            radioButtonReceiveDataASCII.Checked = true;
        }
        // 保存接收数据到文件
        private void SaveReceiveDataToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text |*.txt";
            saveFileDialog.Title = "保存接收到的数据到文件中";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false);
                streamWriter.Write(this.richTextBox1.Text);
                streamWriter.Close();
            }
        }

        private void ButtonSPSITop_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口", "Error");
                return;
            }
            String strSend = "\n" + "spsiread1";//发送框数据
            serialPort.WriteLine(strSend);//发送一行数据 
            if (checkBoxTime.Checked == true)
            {

                DateTime dateTimeNow = DateTime.Now;
                richTextBox1.Text += string.Format("{0}\r\n", dateTimeNow);
            }
            richTextBox1.Text += "spsiread1" + "\r\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();//滚动到光标处
            Thread.Sleep(1000);
            ymodemflag = 1;
            serialPort.Write(new byte[] { C }, 0, 1);//发送一行数据 
            richTextBox1.Text += "C" + "\r\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();//滚动到光标处
            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
            timer1.Start();


        }


        private void ButtonSPSIDowm_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口", "Error");
                return;
            }
            String strSend = "\n" + "spsiread2";//发送框数据
            serialPort.WriteLine(strSend);//发送一行数据 
            if (checkBoxTime.Checked == true)
            {
                DateTime dateTimeNow = DateTime.Now;
                richTextBox1.Text += string.Format("{0}\r\n", dateTimeNow);
            }
            richTextBox1.Text += "spsiread2" + "\r\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();//滚动到光标处
            Thread.Sleep(1000);
            ymodemflag = 1;
            serialPort.Write(new byte[] { C }, 0, 1);//发送一行数据 
            richTextBox1.Text += "C" + "\r\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();//滚动到光标处
            serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.StatusDate.Text = DateTime.Now.ToShortDateString();
            this.StatusTime.Text = DateTime.Now.ToLongTimeString();
        }


        //退出程序
        private void MenuExit_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();//关闭串口
            }
            if (saveDataFS != null)
            {
                saveDataFS.Close(); // 关闭文件
                saveDataFS = null;//释放文件句柄
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(NUMBER3++>50)
            {
              serialPort.Write(new byte[] { ACK }, 0, 1);//发送一行数据
              Debug.WriteLine("重新计时="+NUMBER3);
              NUMBER3 = 0;
            }
            //timer1.Interval = 500;
            
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            if ((zoom * 2 < 64) && (zoom / 2 > 0.015625))
            {
                if (e.KeyCode == Keys.Add && e.Control)
                {
                    richTextBox1.ZoomFactor = zoom * 2;
                }
                if (e.KeyCode == Keys.Subtract && e.Control)
                {
                    richTextBox1.ZoomFactor = zoom / 2;
                }
            }
        }

    }

}
