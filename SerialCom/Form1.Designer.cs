namespace SerialCom
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveReceiveDataToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YMODEMReceive = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetPortConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContributorSylvesterLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBoxSerialPortSetting = new System.Windows.Forms.GroupBox();
            this.checkBoxTime = new System.Windows.Forms.CheckBox();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.comboBoxCheckBit = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBit = new System.Windows.Forms.ComboBox();
            this.buttonOpenCloseCom = new System.Windows.Forms.Button();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSendSetting = new System.Windows.Forms.GroupBox();
            this.radioButtonSendDataHex = new System.Windows.Forms.RadioButton();
            this.radioButtonSendDataASCII = new System.Windows.Forms.RadioButton();
            this.groupBoxReceiveSetting = new System.Windows.Forms.GroupBox();
            this.radioButtonReceiveDataHEX = new System.Windows.Forms.RadioButton();
            this.radioButtonReceiveDataASCII = new System.Windows.Forms.RadioButton();
            this.groupBoxReceiveData = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonClearRecData = new System.Windows.Forms.Button();
            this.groupBoxSendData = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonSPSIDowm = new System.Windows.Forms.Button();
            this.ButtonSPSITop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxSerialPortSetting.SuspendLayout();
            this.groupBoxSendSetting.SuspendLayout();
            this.groupBoxReceiveSetting.SuspendLayout();
            this.groupBoxReceiveData.SuspendLayout();
            this.groupBoxSendData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuTools,
            this.MenuSetting,
            this.MenuIHelp,
            this.MenuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveReceiveDataToFileToolStripMenuItem,
            this.YMODEMReceive});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(44, 21);
            this.MenuFile.Text = "文件";
            // 
            // SaveReceiveDataToFileToolStripMenuItem
            // 
            this.SaveReceiveDataToFileToolStripMenuItem.Name = "SaveReceiveDataToFileToolStripMenuItem";
            this.SaveReceiveDataToFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.SaveReceiveDataToFileToolStripMenuItem.Text = "保存接收数据";
            this.SaveReceiveDataToFileToolStripMenuItem.Click += new System.EventHandler(this.SaveReceiveDataToFileToolStripMenuItem_Click);
            // 
            // YMODEMReceive
            // 
            this.YMODEMReceive.Name = "YMODEMReceive";
            this.YMODEMReceive.Size = new System.Drawing.Size(162, 22);
            this.YMODEMReceive.Text = "YMODEM-接收";
            this.YMODEMReceive.Click += new System.EventHandler(this.YMODEMReceive_Click);
            // 
            // MenuTools
            // 
            this.MenuTools.Name = "MenuTools";
            this.MenuTools.Size = new System.Drawing.Size(44, 21);
            this.MenuTools.Text = "工具";
            // 
            // MenuSetting
            // 
            this.MenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetPortConfToolStripMenuItem});
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(44, 21);
            this.MenuSetting.Text = "设置";
            // 
            // ResetPortConfToolStripMenuItem
            // 
            this.ResetPortConfToolStripMenuItem.Name = "ResetPortConfToolStripMenuItem";
            this.ResetPortConfToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ResetPortConfToolStripMenuItem.Text = "重置串口设置";
            this.ResetPortConfToolStripMenuItem.Click += new System.EventHandler(this.ResetPortConfToolStripMenuItem_Click);
            // 
            // MenuIHelp
            // 
            this.MenuIHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.MenuIHelp.Name = "MenuIHelp";
            this.MenuIHelp.Size = new System.Drawing.Size(44, 21);
            this.MenuIHelp.Text = "帮助";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthorToolStripMenuItem,
            this.ContributorSylvesterLiToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.AboutToolStripMenuItem.Text = "关于";
            // 
            // AuthorToolStripMenuItem
            // 
            this.AuthorToolStripMenuItem.Name = "AuthorToolStripMenuItem";
            this.AuthorToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.AuthorToolStripMenuItem.Text = "作者：LBJ (三胜团队)";
            // 
            // ContributorSylvesterLiToolStripMenuItem
            // 
            this.ContributorSylvesterLiToolStripMenuItem.Name = "ContributorSylvesterLiToolStripMenuItem";
            this.ContributorSylvesterLiToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.ContributorSylvesterLiToolStripMenuItem.Text = "贡献者：Sylvester Li / NaiHai";
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(44, 21);
            this.MenuExit.Text = "退出";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBoxSerialPortSetting
            // 
            this.groupBoxSerialPortSetting.Controls.Add(this.checkBoxTime);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxStopBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxCheckBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxDataBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.buttonOpenCloseCom);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxCom);
            this.groupBoxSerialPortSetting.Controls.Add(this.label5);
            this.groupBoxSerialPortSetting.Controls.Add(this.label4);
            this.groupBoxSerialPortSetting.Controls.Add(this.label3);
            this.groupBoxSerialPortSetting.Controls.Add(this.label2);
            this.groupBoxSerialPortSetting.Controls.Add(this.label1);
            this.groupBoxSerialPortSetting.Location = new System.Drawing.Point(12, 53);
            this.groupBoxSerialPortSetting.Name = "groupBoxSerialPortSetting";
            this.groupBoxSerialPortSetting.Size = new System.Drawing.Size(243, 292);
            this.groupBoxSerialPortSetting.TabIndex = 2;
            this.groupBoxSerialPortSetting.TabStop = false;
            this.groupBoxSerialPortSetting.Text = "串口设置";
            // 
            // checkBoxTime
            // 
            this.checkBoxTime.AutoSize = true;
            this.checkBoxTime.Location = new System.Drawing.Point(20, 262);
            this.checkBoxTime.Name = "checkBoxTime";
            this.checkBoxTime.Size = new System.Drawing.Size(63, 21);
            this.checkBoxTime.TabIndex = 10;
            this.checkBoxTime.Text = "时间戳";
            this.checkBoxTime.UseVisualStyleBackColor = true;
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Location = new System.Drawing.Point(63, 171);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(159, 25);
            this.comboBoxStopBit.TabIndex = 9;
            // 
            // comboBoxCheckBit
            // 
            this.comboBoxCheckBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckBit.FormattingEnabled = true;
            this.comboBoxCheckBit.Location = new System.Drawing.Point(63, 133);
            this.comboBoxCheckBit.Name = "comboBoxCheckBit";
            this.comboBoxCheckBit.Size = new System.Drawing.Size(159, 25);
            this.comboBoxCheckBit.TabIndex = 8;
            // 
            // comboBoxDataBit
            // 
            this.comboBoxDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBit.FormattingEnabled = true;
            this.comboBoxDataBit.Location = new System.Drawing.Point(63, 99);
            this.comboBoxDataBit.Name = "comboBoxDataBit";
            this.comboBoxDataBit.Size = new System.Drawing.Size(159, 25);
            this.comboBoxDataBit.TabIndex = 7;
            // 
            // buttonOpenCloseCom
            // 
            this.buttonOpenCloseCom.Location = new System.Drawing.Point(20, 218);
            this.buttonOpenCloseCom.Name = "buttonOpenCloseCom";
            this.buttonOpenCloseCom.Size = new System.Drawing.Size(203, 38);
            this.buttonOpenCloseCom.TabIndex = 3;
            this.buttonOpenCloseCom.Text = "打开串口";
            this.buttonOpenCloseCom.UseVisualStyleBackColor = true;
            this.buttonOpenCloseCom.Click += new System.EventHandler(this.ButtonOpenCloseCom_Click);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(63, 65);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(159, 25);
            this.comboBoxBaudRate.TabIndex = 6;
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCom.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(63, 34);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(159, 23);
            this.comboBoxCom.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "校验位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "端   口";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxSendSetting
            // 
            this.groupBoxSendSetting.Controls.Add(this.radioButtonSendDataHex);
            this.groupBoxSendSetting.Controls.Add(this.radioButtonSendDataASCII);
            this.groupBoxSendSetting.Location = new System.Drawing.Point(12, 459);
            this.groupBoxSendSetting.Name = "groupBoxSendSetting";
            this.groupBoxSendSetting.Size = new System.Drawing.Size(243, 44);
            this.groupBoxSendSetting.TabIndex = 5;
            this.groupBoxSendSetting.TabStop = false;
            this.groupBoxSendSetting.Text = "发送设置";
            // 
            // radioButtonSendDataHex
            // 
            this.radioButtonSendDataHex.AutoSize = true;
            this.radioButtonSendDataHex.Location = new System.Drawing.Point(82, 22);
            this.radioButtonSendDataHex.Name = "radioButtonSendDataHex";
            this.radioButtonSendDataHex.Size = new System.Drawing.Size(50, 21);
            this.radioButtonSendDataHex.TabIndex = 1;
            this.radioButtonSendDataHex.TabStop = true;
            this.radioButtonSendDataHex.Text = "HEX";
            this.radioButtonSendDataHex.UseVisualStyleBackColor = true;
            // 
            // radioButtonSendDataASCII
            // 
            this.radioButtonSendDataASCII.AutoSize = true;
            this.radioButtonSendDataASCII.Location = new System.Drawing.Point(19, 23);
            this.radioButtonSendDataASCII.Name = "radioButtonSendDataASCII";
            this.radioButtonSendDataASCII.Size = new System.Drawing.Size(57, 21);
            this.radioButtonSendDataASCII.TabIndex = 0;
            this.radioButtonSendDataASCII.TabStop = true;
            this.radioButtonSendDataASCII.Text = "ASCII";
            this.radioButtonSendDataASCII.UseVisualStyleBackColor = true;
            // 
            // groupBoxReceiveSetting
            // 
            this.groupBoxReceiveSetting.Controls.Add(this.radioButtonReceiveDataHEX);
            this.groupBoxReceiveSetting.Controls.Add(this.radioButtonReceiveDataASCII);
            this.groupBoxReceiveSetting.Location = new System.Drawing.Point(12, 509);
            this.groupBoxReceiveSetting.Name = "groupBoxReceiveSetting";
            this.groupBoxReceiveSetting.Size = new System.Drawing.Size(243, 42);
            this.groupBoxReceiveSetting.TabIndex = 6;
            this.groupBoxReceiveSetting.TabStop = false;
            this.groupBoxReceiveSetting.Text = "接收设置";
            // 
            // radioButtonReceiveDataHEX
            // 
            this.radioButtonReceiveDataHEX.AutoSize = true;
            this.radioButtonReceiveDataHEX.Location = new System.Drawing.Point(82, 22);
            this.radioButtonReceiveDataHEX.Name = "radioButtonReceiveDataHEX";
            this.radioButtonReceiveDataHEX.Size = new System.Drawing.Size(50, 21);
            this.radioButtonReceiveDataHEX.TabIndex = 1;
            this.radioButtonReceiveDataHEX.TabStop = true;
            this.radioButtonReceiveDataHEX.Text = "HEX";
            this.radioButtonReceiveDataHEX.UseVisualStyleBackColor = true;
            // 
            // radioButtonReceiveDataASCII
            // 
            this.radioButtonReceiveDataASCII.AutoSize = true;
            this.radioButtonReceiveDataASCII.Location = new System.Drawing.Point(19, 22);
            this.radioButtonReceiveDataASCII.Name = "radioButtonReceiveDataASCII";
            this.radioButtonReceiveDataASCII.Size = new System.Drawing.Size(57, 21);
            this.radioButtonReceiveDataASCII.TabIndex = 0;
            this.radioButtonReceiveDataASCII.TabStop = true;
            this.radioButtonReceiveDataASCII.Text = "ASCII";
            this.radioButtonReceiveDataASCII.UseVisualStyleBackColor = true;
            // 
            // groupBoxReceiveData
            // 
            this.groupBoxReceiveData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReceiveData.Controls.Add(this.richTextBox1);
            this.groupBoxReceiveData.Controls.Add(this.buttonClearRecData);
            this.groupBoxReceiveData.Location = new System.Drawing.Point(261, 53);
            this.groupBoxReceiveData.Name = "groupBoxReceiveData";
            this.groupBoxReceiveData.Size = new System.Drawing.Size(884, 387);
            this.groupBoxReceiveData.TabIndex = 7;
            this.groupBoxReceiveData.TabStop = false;
            this.groupBoxReceiveData.Text = "接收数据";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(878, 332);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // buttonClearRecData
            // 
            this.buttonClearRecData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearRecData.Location = new System.Drawing.Point(6, 360);
            this.buttonClearRecData.Name = "buttonClearRecData";
            this.buttonClearRecData.Size = new System.Drawing.Size(75, 23);
            this.buttonClearRecData.TabIndex = 1;
            this.buttonClearRecData.Text = "清空";
            this.buttonClearRecData.UseVisualStyleBackColor = true;
            this.buttonClearRecData.Click += new System.EventHandler(this.ButtonClearRecData_Click);
            // 
            // groupBoxSendData
            // 
            this.groupBoxSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSendData.Controls.Add(this.button1);
            this.groupBoxSendData.Controls.Add(this.buttonSendData);
            this.groupBoxSendData.Controls.Add(this.textBoxSend);
            this.groupBoxSendData.Location = new System.Drawing.Point(261, 448);
            this.groupBoxSendData.Name = "groupBoxSendData";
            this.groupBoxSendData.Size = new System.Drawing.Size(884, 101);
            this.groupBoxSendData.TabIndex = 8;
            this.groupBoxSendData.TabStop = false;
            this.groupBoxSendData.Text = "发送数据";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(809, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "清除发送";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonSendData
            // 
            this.buttonSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendData.Location = new System.Drawing.Point(809, 22);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(75, 23);
            this.buttonSendData.TabIndex = 1;
            this.buttonSendData.Text = "发送";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.ButtonSendData_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSend.Location = new System.Drawing.Point(6, 21);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSend.Size = new System.Drawing.Size(800, 80);
            this.textBoxSend.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonSPSIDowm);
            this.groupBox1.Controls.Add(this.ButtonSPSITop);
            this.groupBox1.Location = new System.Drawing.Point(12, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 102);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SPSI助手";
            // 
            // ButtonSPSIDowm
            // 
            this.ButtonSPSIDowm.Location = new System.Drawing.Point(112, 31);
            this.ButtonSPSIDowm.Name = "ButtonSPSIDowm";
            this.ButtonSPSIDowm.Size = new System.Drawing.Size(94, 54);
            this.ButtonSPSIDowm.TabIndex = 1;
            this.ButtonSPSIDowm.Text = "读取数据下";
            this.ButtonSPSIDowm.UseVisualStyleBackColor = true;
            this.ButtonSPSIDowm.Click += new System.EventHandler(this.ButtonSPSIDowm_Click);
            // 
            // ButtonSPSITop
            // 
            this.ButtonSPSITop.Location = new System.Drawing.Point(6, 31);
            this.ButtonSPSITop.Name = "ButtonSPSITop";
            this.ButtonSPSITop.Size = new System.Drawing.Size(100, 54);
            this.ButtonSPSITop.TabIndex = 0;
            this.ButtonSPSITop.Text = "读取数据上";
            this.ButtonSPSITop.UseVisualStyleBackColor = true;
            this.ButtonSPSITop.Click += new System.EventHandler(this.ButtonSPSITop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSendData);
            this.Controls.Add(this.groupBoxReceiveData);
            this.Controls.Add(this.groupBoxReceiveSetting);
            this.Controls.Add(this.groupBoxSendSetting);
            this.Controls.Add(this.groupBoxSerialPortSetting);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口调试软件";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxSerialPortSetting.ResumeLayout(false);
            this.groupBoxSerialPortSetting.PerformLayout();
            this.groupBoxSendSetting.ResumeLayout(false);
            this.groupBoxSendSetting.PerformLayout();
            this.groupBoxReceiveSetting.ResumeLayout(false);
            this.groupBoxReceiveSetting.PerformLayout();
            this.groupBoxReceiveData.ResumeLayout(false);
            this.groupBoxSendData.ResumeLayout(false);
            this.groupBoxSendData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuTools;
        private System.Windows.Forms.ToolStripMenuItem MenuSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuIHelp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBoxSerialPortSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.ComboBox comboBoxCheckBit;
        private System.Windows.Forms.ComboBox comboBoxDataBit;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.Button buttonOpenCloseCom;
        private System.Windows.Forms.GroupBox groupBoxSendSetting;
        private System.Windows.Forms.RadioButton radioButtonSendDataASCII;
        private System.Windows.Forms.RadioButton radioButtonSendDataHex;
        private System.Windows.Forms.GroupBox groupBoxReceiveSetting;
        private System.Windows.Forms.RadioButton radioButtonReceiveDataASCII;
        private System.Windows.Forms.RadioButton radioButtonReceiveDataHEX;
        private System.Windows.Forms.GroupBox groupBoxReceiveData;
        private System.Windows.Forms.GroupBox groupBoxSendData;
        private System.Windows.Forms.Button buttonClearRecData;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContributorSylvesterLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YMODEMReceive;
        private System.Windows.Forms.ToolStripMenuItem ResetPortConfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveReceiveDataToFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonSPSIDowm;
        private System.Windows.Forms.Button ButtonSPSITop;
        private System.Windows.Forms.CheckBox checkBoxTime;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

