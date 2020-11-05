namespace FPD
{
    partial class Form_Communication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CRC = new System.Windows.Forms.Button();
            this.tb_crc_result = new System.Windows.Forms.TextBox();
            this.tb_command = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lb_file = new System.Windows.Forms.Label();
            this.tb_filepath = new System.Windows.Forms.TextBox();
            this.dgv_datamap = new System.Windows.Forms.DataGridView();
            this.Data_col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_col15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_command_type = new System.Windows.Forms.ComboBox();
            this.lb_datacount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_addr = new System.Windows.Forms.Label();
            this.tb_datacount = new System.Windows.Forms.TextBox();
            this.tb_addr = new System.Windows.Forms.TextBox();
            this.btn_sent_SDP = new System.Windows.Forms.Button();
            this.btn_SDP_disconnect = new System.Windows.Forms.Button();
            this.btn_SDP_Connect = new System.Windows.Forms.Button();
            this.rt_log = new System.Windows.Forms.RichTextBox();
            this.btn_BL_connet = new System.Windows.Forms.Button();
            this.btn_BL_disconnect = new System.Windows.Forms.Button();
            this.btn_send_BL = new System.Windows.Forms.Button();
            this.tb_BL_para1 = new System.Windows.Forms.TextBox();
            this.tb_BL_para2 = new System.Windows.Forms.TextBox();
            this.lb_BL_para1 = new System.Windows.Forms.Label();
            this.lb_BL_command_type = new System.Windows.Forms.Label();
            this.lb_BL_para2 = new System.Windows.Forms.Label();
            this.cb_BL_command_type = new System.Windows.Forms.ComboBox();
            this.tb_BL_filepath = new System.Windows.Forms.TextBox();
            this.btn_BL_browse = new System.Windows.Forms.Button();
            this.pBar_1 = new System.Windows.Forms.ProgressBar();
            this.gb_SDP = new System.Windows.Forms.GroupBox();
            this.gb_BL = new System.Windows.Forms.GroupBox();
            this.lb_BL_filepath = new System.Windows.Forms.Label();
            this.gb_CRC = new System.Windows.Forms.GroupBox();
            this.btn_onekeyupdate = new System.Windows.Forms.Button();
            this.gb_FWUpgrade = new System.Windows.Forms.GroupBox();
            this.btn_allinone_browse = new System.Windows.Forms.Button();
            this.lb_allinone = new System.Windows.Forms.Label();
            this.tb_allinone_path = new System.Windows.Forms.TextBox();
            this.gb_CDC = new System.Windows.Forms.GroupBox();
            this.btn_enterFU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datamap)).BeginInit();
            this.gb_SDP.SuspendLayout();
            this.gb_BL.SuspendLayout();
            this.gb_CRC.SuspendLayout();
            this.gb_FWUpgrade.SuspendLayout();
            this.gb_CDC.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "CRC Result :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "Command :";
            // 
            // btn_CRC
            // 
            this.btn_CRC.Location = new System.Drawing.Point(85, 109);
            this.btn_CRC.Name = "btn_CRC";
            this.btn_CRC.Size = new System.Drawing.Size(81, 30);
            this.btn_CRC.TabIndex = 38;
            this.btn_CRC.Text = "CRC";
            this.btn_CRC.UseVisualStyleBackColor = true;
            this.btn_CRC.Click += new System.EventHandler(this.btn_CRC_Click);
            // 
            // tb_crc_result
            // 
            this.tb_crc_result.Location = new System.Drawing.Point(85, 79);
            this.tb_crc_result.Name = "tb_crc_result";
            this.tb_crc_result.Size = new System.Drawing.Size(89, 22);
            this.tb_crc_result.TabIndex = 36;
            // 
            // tb_command
            // 
            this.tb_command.Location = new System.Drawing.Point(85, 40);
            this.tb_command.Name = "tb_command";
            this.tb_command.Size = new System.Drawing.Size(89, 22);
            this.tb_command.TabIndex = 37;
            this.tb_command.Text = "5a a4 0c 00 07 00 00 02 01 00 00 00 00 00 00 00";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(97, 204);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 35;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lb_file
            // 
            this.lb_file.AutoSize = true;
            this.lb_file.Location = new System.Drawing.Point(37, 181);
            this.lb_file.Name = "lb_file";
            this.lb_file.Size = new System.Drawing.Size(54, 12);
            this.lb_file.TabIndex = 34;
            this.lb_file.Text = "File Path : ";
            // 
            // tb_filepath
            // 
            this.tb_filepath.Location = new System.Drawing.Point(97, 178);
            this.tb_filepath.Name = "tb_filepath";
            this.tb_filepath.Size = new System.Drawing.Size(251, 22);
            this.tb_filepath.TabIndex = 33;
            // 
            // dgv_datamap
            // 
            this.dgv_datamap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datamap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data_col1,
            this.Data_col2,
            this.Data_col3,
            this.Data_col4,
            this.Data_col5,
            this.Data_col6,
            this.Data_col7,
            this.Data_col8,
            this.Data_col9,
            this.Data_col10,
            this.Data_col11,
            this.Data_col12,
            this.Data_col13,
            this.Data_col14,
            this.Data_col15});
            this.dgv_datamap.Location = new System.Drawing.Point(6, 584);
            this.dgv_datamap.Name = "dgv_datamap";
            this.dgv_datamap.RowTemplate.Height = 24;
            this.dgv_datamap.Size = new System.Drawing.Size(947, 275);
            this.dgv_datamap.TabIndex = 32;
            // 
            // Data_col1
            // 
            this.Data_col1.Frozen = true;
            this.Data_col1.HeaderText = "1";
            this.Data_col1.Name = "Data_col1";
            this.Data_col1.Width = 60;
            // 
            // Data_col2
            // 
            this.Data_col2.Frozen = true;
            this.Data_col2.HeaderText = "2";
            this.Data_col2.Name = "Data_col2";
            this.Data_col2.Width = 60;
            // 
            // Data_col3
            // 
            this.Data_col3.Frozen = true;
            this.Data_col3.HeaderText = "3";
            this.Data_col3.Name = "Data_col3";
            this.Data_col3.Width = 60;
            // 
            // Data_col4
            // 
            this.Data_col4.Frozen = true;
            this.Data_col4.HeaderText = "4";
            this.Data_col4.Name = "Data_col4";
            this.Data_col4.Width = 60;
            // 
            // Data_col5
            // 
            this.Data_col5.Frozen = true;
            this.Data_col5.HeaderText = "5";
            this.Data_col5.Name = "Data_col5";
            this.Data_col5.Width = 60;
            // 
            // Data_col6
            // 
            this.Data_col6.Frozen = true;
            this.Data_col6.HeaderText = "6";
            this.Data_col6.Name = "Data_col6";
            this.Data_col6.Width = 60;
            // 
            // Data_col7
            // 
            this.Data_col7.Frozen = true;
            this.Data_col7.HeaderText = "7";
            this.Data_col7.Name = "Data_col7";
            this.Data_col7.Width = 60;
            // 
            // Data_col8
            // 
            this.Data_col8.Frozen = true;
            this.Data_col8.HeaderText = "8";
            this.Data_col8.Name = "Data_col8";
            this.Data_col8.Width = 60;
            // 
            // Data_col9
            // 
            this.Data_col9.Frozen = true;
            this.Data_col9.HeaderText = "9";
            this.Data_col9.Name = "Data_col9";
            this.Data_col9.Width = 60;
            // 
            // Data_col10
            // 
            this.Data_col10.Frozen = true;
            this.Data_col10.HeaderText = "A";
            this.Data_col10.Name = "Data_col10";
            this.Data_col10.Width = 60;
            // 
            // Data_col11
            // 
            this.Data_col11.Frozen = true;
            this.Data_col11.HeaderText = "B";
            this.Data_col11.Name = "Data_col11";
            this.Data_col11.Width = 60;
            // 
            // Data_col12
            // 
            this.Data_col12.Frozen = true;
            this.Data_col12.HeaderText = "C";
            this.Data_col12.Name = "Data_col12";
            this.Data_col12.Width = 60;
            // 
            // Data_col13
            // 
            this.Data_col13.Frozen = true;
            this.Data_col13.HeaderText = "D";
            this.Data_col13.Name = "Data_col13";
            this.Data_col13.Width = 60;
            // 
            // Data_col14
            // 
            this.Data_col14.Frozen = true;
            this.Data_col14.HeaderText = "E";
            this.Data_col14.Name = "Data_col14";
            this.Data_col14.Width = 60;
            // 
            // Data_col15
            // 
            this.Data_col15.Frozen = true;
            this.Data_col15.HeaderText = "F";
            this.Data_col15.Name = "Data_col15";
            this.Data_col15.Width = 60;
            // 
            // cb_command_type
            // 
            this.cb_command_type.FormattingEnabled = true;
            this.cb_command_type.Items.AddRange(new object[] {
            "DCD_WRITE",
            "ERROR_STATUS",
            "JUMP_ADDRESS",
            "READ_REGISTER",
            "WRITE_FILE",
            "WRITE_REGISTER"});
            this.cb_command_type.Location = new System.Drawing.Point(97, 96);
            this.cb_command_type.Name = "cb_command_type";
            this.cb_command_type.Size = new System.Drawing.Size(121, 20);
            this.cb_command_type.TabIndex = 31;
            // 
            // lb_datacount
            // 
            this.lb_datacount.AutoSize = true;
            this.lb_datacount.Location = new System.Drawing.Point(29, 153);
            this.lb_datacount.Name = "lb_datacount";
            this.lb_datacount.Size = new System.Drawing.Size(64, 12);
            this.lb_datacount.TabIndex = 30;
            this.lb_datacount.Text = "DataCount : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Command_Type :";
            // 
            // lb_addr
            // 
            this.lb_addr.AutoSize = true;
            this.lb_addr.Location = new System.Drawing.Point(58, 125);
            this.lb_addr.Name = "lb_addr";
            this.lb_addr.Size = new System.Drawing.Size(35, 12);
            this.lb_addr.TabIndex = 28;
            this.lb_addr.Text = "addr : ";
            // 
            // tb_datacount
            // 
            this.tb_datacount.Location = new System.Drawing.Point(97, 150);
            this.tb_datacount.Name = "tb_datacount";
            this.tb_datacount.Size = new System.Drawing.Size(100, 22);
            this.tb_datacount.TabIndex = 27;
            this.tb_datacount.Text = "4";
            // 
            // tb_addr
            // 
            this.tb_addr.Location = new System.Drawing.Point(97, 122);
            this.tb_addr.Name = "tb_addr";
            this.tb_addr.Size = new System.Drawing.Size(100, 22);
            this.tb_addr.TabIndex = 26;
            this.tb_addr.Text = "20208200";
            // 
            // btn_sent_SDP
            // 
            this.btn_sent_SDP.Location = new System.Drawing.Point(267, 135);
            this.btn_sent_SDP.Name = "btn_sent_SDP";
            this.btn_sent_SDP.Size = new System.Drawing.Size(81, 30);
            this.btn_sent_SDP.TabIndex = 25;
            this.btn_sent_SDP.Text = "Sent_SDP";
            this.btn_sent_SDP.UseVisualStyleBackColor = true;
            this.btn_sent_SDP.Click += new System.EventHandler(this.btn_sent_SDP_Click);
            // 
            // btn_SDP_disconnect
            // 
            this.btn_SDP_disconnect.Location = new System.Drawing.Point(98, 45);
            this.btn_SDP_disconnect.Name = "btn_SDP_disconnect";
            this.btn_SDP_disconnect.Size = new System.Drawing.Size(107, 34);
            this.btn_SDP_disconnect.TabIndex = 24;
            this.btn_SDP_disconnect.Text = "SDP_Disconnect";
            this.btn_SDP_disconnect.UseVisualStyleBackColor = true;
            this.btn_SDP_disconnect.Click += new System.EventHandler(this.btn_SDP_disconnect_Click);
            // 
            // btn_SDP_Connect
            // 
            this.btn_SDP_Connect.Location = new System.Drawing.Point(10, 45);
            this.btn_SDP_Connect.Name = "btn_SDP_Connect";
            this.btn_SDP_Connect.Size = new System.Drawing.Size(82, 34);
            this.btn_SDP_Connect.TabIndex = 23;
            this.btn_SDP_Connect.Text = "SDP_Connect";
            this.btn_SDP_Connect.UseVisualStyleBackColor = true;
            this.btn_SDP_Connect.Click += new System.EventHandler(this.btn_SDP_Connect_Click);
            // 
            // rt_log
            // 
            this.rt_log.Location = new System.Drawing.Point(6, 363);
            this.rt_log.Margin = new System.Windows.Forms.Padding(2);
            this.rt_log.Name = "rt_log";
            this.rt_log.Size = new System.Drawing.Size(905, 187);
            this.rt_log.TabIndex = 41;
            this.rt_log.Text = "";
            // 
            // btn_BL_connet
            // 
            this.btn_BL_connet.Location = new System.Drawing.Point(30, 46);
            this.btn_BL_connet.Name = "btn_BL_connet";
            this.btn_BL_connet.Size = new System.Drawing.Size(82, 34);
            this.btn_BL_connet.TabIndex = 23;
            this.btn_BL_connet.Text = "BL_Connect";
            this.btn_BL_connet.UseVisualStyleBackColor = true;
            this.btn_BL_connet.Click += new System.EventHandler(this.btn_BL_connet_Click);
            // 
            // btn_BL_disconnect
            // 
            this.btn_BL_disconnect.Location = new System.Drawing.Point(118, 46);
            this.btn_BL_disconnect.Name = "btn_BL_disconnect";
            this.btn_BL_disconnect.Size = new System.Drawing.Size(107, 34);
            this.btn_BL_disconnect.TabIndex = 24;
            this.btn_BL_disconnect.Text = "BL_Disconnect";
            this.btn_BL_disconnect.UseVisualStyleBackColor = true;
            this.btn_BL_disconnect.Click += new System.EventHandler(this.btn_BL_disconnect_Click);
            // 
            // btn_send_BL
            // 
            this.btn_send_BL.Location = new System.Drawing.Point(267, 136);
            this.btn_send_BL.Name = "btn_send_BL";
            this.btn_send_BL.Size = new System.Drawing.Size(81, 30);
            this.btn_send_BL.TabIndex = 25;
            this.btn_send_BL.Text = "Sent_BL";
            this.btn_send_BL.UseVisualStyleBackColor = true;
            this.btn_send_BL.Click += new System.EventHandler(this.btn_send_BL_Click);
            // 
            // tb_BL_para1
            // 
            this.tb_BL_para1.Location = new System.Drawing.Point(117, 123);
            this.tb_BL_para1.Name = "tb_BL_para1";
            this.tb_BL_para1.Size = new System.Drawing.Size(100, 22);
            this.tb_BL_para1.TabIndex = 26;
            this.tb_BL_para1.Text = "1";
            // 
            // tb_BL_para2
            // 
            this.tb_BL_para2.Location = new System.Drawing.Point(117, 151);
            this.tb_BL_para2.Name = "tb_BL_para2";
            this.tb_BL_para2.Size = new System.Drawing.Size(100, 22);
            this.tb_BL_para2.TabIndex = 27;
            this.tb_BL_para2.Text = "0";
            // 
            // lb_BL_para1
            // 
            this.lb_BL_para1.AutoSize = true;
            this.lb_BL_para1.Location = new System.Drawing.Point(23, 126);
            this.lb_BL_para1.Name = "lb_BL_para1";
            this.lb_BL_para1.Size = new System.Drawing.Size(35, 12);
            this.lb_BL_para1.TabIndex = 28;
            this.lb_BL_para1.Text = "addr : ";
            // 
            // lb_BL_command_type
            // 
            this.lb_BL_command_type.AutoSize = true;
            this.lb_BL_command_type.Location = new System.Drawing.Point(23, 100);
            this.lb_BL_command_type.Name = "lb_BL_command_type";
            this.lb_BL_command_type.Size = new System.Drawing.Size(90, 12);
            this.lb_BL_command_type.TabIndex = 29;
            this.lb_BL_command_type.Text = "Command_Type :";
            // 
            // lb_BL_para2
            // 
            this.lb_BL_para2.AutoSize = true;
            this.lb_BL_para2.Location = new System.Drawing.Point(23, 154);
            this.lb_BL_para2.Name = "lb_BL_para2";
            this.lb_BL_para2.Size = new System.Drawing.Size(64, 12);
            this.lb_BL_para2.TabIndex = 30;
            this.lb_BL_para2.Text = "DataCount : ";
            // 
            // cb_BL_command_type
            // 
            this.cb_BL_command_type.FormattingEnabled = true;
            this.cb_BL_command_type.Items.AddRange(new object[] {
            "FlashEraseRegion",
            "ReadMemory",
            "WriteMemory",
            "FillMemory",
            "GetProperty",
            "Reset",
            "FlashReadOnce",
            "ConfigureQuadSPI"});
            this.cb_BL_command_type.Location = new System.Drawing.Point(117, 97);
            this.cb_BL_command_type.Name = "cb_BL_command_type";
            this.cb_BL_command_type.Size = new System.Drawing.Size(121, 20);
            this.cb_BL_command_type.TabIndex = 31;
            this.cb_BL_command_type.SelectedIndexChanged += new System.EventHandler(this.cb_BL_command_type_SelectedIndexChanged);
            // 
            // tb_BL_filepath
            // 
            this.tb_BL_filepath.Location = new System.Drawing.Point(80, 179);
            this.tb_BL_filepath.Name = "tb_BL_filepath";
            this.tb_BL_filepath.Size = new System.Drawing.Size(268, 22);
            this.tb_BL_filepath.TabIndex = 33;
            // 
            // btn_BL_browse
            // 
            this.btn_BL_browse.Location = new System.Drawing.Point(80, 205);
            this.btn_BL_browse.Name = "btn_BL_browse";
            this.btn_BL_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_BL_browse.TabIndex = 35;
            this.btn_BL_browse.Text = "Browse";
            this.btn_BL_browse.UseVisualStyleBackColor = true;
            this.btn_BL_browse.Click += new System.EventHandler(this.btn_BL_browse_Click);
            // 
            // pBar_1
            // 
            this.pBar_1.Location = new System.Drawing.Point(6, 555);
            this.pBar_1.Name = "pBar_1";
            this.pBar_1.Size = new System.Drawing.Size(904, 23);
            this.pBar_1.Step = 1;
            this.pBar_1.TabIndex = 42;
            // 
            // gb_SDP
            // 
            this.gb_SDP.Controls.Add(this.btn_browse);
            this.gb_SDP.Controls.Add(this.lb_file);
            this.gb_SDP.Controls.Add(this.tb_filepath);
            this.gb_SDP.Controls.Add(this.cb_command_type);
            this.gb_SDP.Controls.Add(this.lb_datacount);
            this.gb_SDP.Controls.Add(this.label1);
            this.gb_SDP.Controls.Add(this.lb_addr);
            this.gb_SDP.Controls.Add(this.tb_datacount);
            this.gb_SDP.Controls.Add(this.tb_addr);
            this.gb_SDP.Controls.Add(this.btn_sent_SDP);
            this.gb_SDP.Controls.Add(this.btn_SDP_disconnect);
            this.gb_SDP.Controls.Add(this.btn_SDP_Connect);
            this.gb_SDP.Location = new System.Drawing.Point(916, 81);
            this.gb_SDP.Name = "gb_SDP";
            this.gb_SDP.Size = new System.Drawing.Size(363, 239);
            this.gb_SDP.TabIndex = 43;
            this.gb_SDP.TabStop = false;
            this.gb_SDP.Text = "SDP Control";
            // 
            // gb_BL
            // 
            this.gb_BL.Controls.Add(this.lb_BL_filepath);
            this.gb_BL.Controls.Add(this.btn_BL_browse);
            this.gb_BL.Controls.Add(this.tb_BL_filepath);
            this.gb_BL.Controls.Add(this.cb_BL_command_type);
            this.gb_BL.Controls.Add(this.lb_BL_para2);
            this.gb_BL.Controls.Add(this.lb_BL_command_type);
            this.gb_BL.Controls.Add(this.lb_BL_para1);
            this.gb_BL.Controls.Add(this.tb_BL_para2);
            this.gb_BL.Controls.Add(this.tb_BL_para1);
            this.gb_BL.Controls.Add(this.btn_send_BL);
            this.gb_BL.Controls.Add(this.btn_BL_disconnect);
            this.gb_BL.Controls.Add(this.btn_BL_connet);
            this.gb_BL.Location = new System.Drawing.Point(916, 339);
            this.gb_BL.Name = "gb_BL";
            this.gb_BL.Size = new System.Drawing.Size(363, 239);
            this.gb_BL.TabIndex = 44;
            this.gb_BL.TabStop = false;
            this.gb_BL.Text = "BL Control";
            // 
            // lb_BL_filepath
            // 
            this.lb_BL_filepath.AutoSize = true;
            this.lb_BL_filepath.Location = new System.Drawing.Point(23, 182);
            this.lb_BL_filepath.Name = "lb_BL_filepath";
            this.lb_BL_filepath.Size = new System.Drawing.Size(54, 12);
            this.lb_BL_filepath.TabIndex = 36;
            this.lb_BL_filepath.Text = "File Path : ";
            // 
            // gb_CRC
            // 
            this.gb_CRC.Controls.Add(this.label2);
            this.gb_CRC.Controls.Add(this.label3);
            this.gb_CRC.Controls.Add(this.btn_CRC);
            this.gb_CRC.Controls.Add(this.tb_crc_result);
            this.gb_CRC.Controls.Add(this.tb_command);
            this.gb_CRC.Location = new System.Drawing.Point(1087, 699);
            this.gb_CRC.Name = "gb_CRC";
            this.gb_CRC.Size = new System.Drawing.Size(192, 160);
            this.gb_CRC.TabIndex = 45;
            this.gb_CRC.TabStop = false;
            this.gb_CRC.Text = "CRC32 / MPEG2";
            // 
            // btn_onekeyupdate
            // 
            this.btn_onekeyupdate.Location = new System.Drawing.Point(6, 80);
            this.btn_onekeyupdate.Name = "btn_onekeyupdate";
            this.btn_onekeyupdate.Size = new System.Drawing.Size(75, 23);
            this.btn_onekeyupdate.TabIndex = 46;
            this.btn_onekeyupdate.Text = "All-in-One";
            this.btn_onekeyupdate.UseVisualStyleBackColor = true;
            this.btn_onekeyupdate.Click += new System.EventHandler(this.btn_onekeyupdate_Click);
            // 
            // gb_FWUpgrade
            // 
            this.gb_FWUpgrade.Controls.Add(this.btn_allinone_browse);
            this.gb_FWUpgrade.Controls.Add(this.lb_allinone);
            this.gb_FWUpgrade.Controls.Add(this.tb_allinone_path);
            this.gb_FWUpgrade.Controls.Add(this.btn_onekeyupdate);
            this.gb_FWUpgrade.Location = new System.Drawing.Point(12, 12);
            this.gb_FWUpgrade.Name = "gb_FWUpgrade";
            this.gb_FWUpgrade.Size = new System.Drawing.Size(406, 185);
            this.gb_FWUpgrade.TabIndex = 47;
            this.gb_FWUpgrade.TabStop = false;
            this.gb_FWUpgrade.Text = "FW Upgrade";
            // 
            // btn_allinone_browse
            // 
            this.btn_allinone_browse.Location = new System.Drawing.Point(259, 80);
            this.btn_allinone_browse.Name = "btn_allinone_browse";
            this.btn_allinone_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_allinone_browse.TabIndex = 49;
            this.btn_allinone_browse.Text = "Browse";
            this.btn_allinone_browse.UseVisualStyleBackColor = true;
            this.btn_allinone_browse.Click += new System.EventHandler(this.btn_allinone_browse_Click);
            // 
            // lb_allinone
            // 
            this.lb_allinone.AutoSize = true;
            this.lb_allinone.Location = new System.Drawing.Point(9, 42);
            this.lb_allinone.Name = "lb_allinone";
            this.lb_allinone.Size = new System.Drawing.Size(54, 12);
            this.lb_allinone.TabIndex = 48;
            this.lb_allinone.Text = "File Path : ";
            // 
            // tb_allinone_path
            // 
            this.tb_allinone_path.Location = new System.Drawing.Point(66, 39);
            this.tb_allinone_path.Name = "tb_allinone_path";
            this.tb_allinone_path.Size = new System.Drawing.Size(268, 22);
            this.tb_allinone_path.TabIndex = 47;
            // 
            // gb_CDC
            // 
            this.gb_CDC.Controls.Add(this.btn_enterFU);
            this.gb_CDC.Location = new System.Drawing.Point(916, 12);
            this.gb_CDC.Name = "gb_CDC";
            this.gb_CDC.Size = new System.Drawing.Size(363, 61);
            this.gb_CDC.TabIndex = 47;
            this.gb_CDC.TabStop = false;
            this.gb_CDC.Text = "CDC";
            // 
            // btn_enterFU
            // 
            this.btn_enterFU.Location = new System.Drawing.Point(5, 21);
            this.btn_enterFU.Name = "btn_enterFU";
            this.btn_enterFU.Size = new System.Drawing.Size(352, 23);
            this.btn_enterFU.TabIndex = 46;
            this.btn_enterFU.Text = "Enter FW Upgrade Mode";
            this.btn_enterFU.UseVisualStyleBackColor = true;
            // 
            // Form_Communication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 871);
            this.ControlBox = false;
            this.Controls.Add(this.gb_CDC);
            this.Controls.Add(this.gb_FWUpgrade);
            this.Controls.Add(this.gb_CRC);
            this.Controls.Add(this.gb_BL);
            this.Controls.Add(this.gb_SDP);
            this.Controls.Add(this.pBar_1);
            this.Controls.Add(this.rt_log);
            this.Controls.Add(this.dgv_datamap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Communication";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datamap)).EndInit();
            this.gb_SDP.ResumeLayout(false);
            this.gb_SDP.PerformLayout();
            this.gb_BL.ResumeLayout(false);
            this.gb_BL.PerformLayout();
            this.gb_CRC.ResumeLayout(false);
            this.gb_CRC.PerformLayout();
            this.gb_FWUpgrade.ResumeLayout(false);
            this.gb_FWUpgrade.PerformLayout();
            this.gb_CDC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CRC;
        private System.Windows.Forms.TextBox tb_crc_result;
        private System.Windows.Forms.TextBox tb_command;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lb_file;
        private System.Windows.Forms.TextBox tb_filepath;
        private System.Windows.Forms.DataGridView dgv_datamap;
        private System.Windows.Forms.ComboBox cb_command_type;
        private System.Windows.Forms.Label lb_datacount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_addr;
        private System.Windows.Forms.TextBox tb_datacount;
        private System.Windows.Forms.TextBox tb_addr;
        private System.Windows.Forms.Button btn_sent_SDP;
        private System.Windows.Forms.Button btn_SDP_disconnect;
        private System.Windows.Forms.Button btn_SDP_Connect;
        private System.Windows.Forms.RichTextBox rt_log;
        private System.Windows.Forms.Button btn_BL_connet;
        private System.Windows.Forms.Button btn_BL_disconnect;
        private System.Windows.Forms.Button btn_send_BL;
        private System.Windows.Forms.TextBox tb_BL_para1;
        private System.Windows.Forms.TextBox tb_BL_para2;
        private System.Windows.Forms.Label lb_BL_para1;
        private System.Windows.Forms.Label lb_BL_command_type;
        private System.Windows.Forms.Label lb_BL_para2;
        private System.Windows.Forms.ComboBox cb_BL_command_type;
        private System.Windows.Forms.TextBox tb_BL_filepath;
        private System.Windows.Forms.Button btn_BL_browse;
        private System.Windows.Forms.ProgressBar pBar_1;
        private System.Windows.Forms.GroupBox gb_SDP;
        private System.Windows.Forms.GroupBox gb_BL;
        private System.Windows.Forms.GroupBox gb_CRC;
        private System.Windows.Forms.Label lb_BL_filepath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_col15;
        private System.Windows.Forms.Button btn_onekeyupdate;
        private System.Windows.Forms.GroupBox gb_FWUpgrade;
        private System.Windows.Forms.Button btn_allinone_browse;
        private System.Windows.Forms.Label lb_allinone;
        private System.Windows.Forms.TextBox tb_allinone_path;
        private System.Windows.Forms.GroupBox gb_CDC;
        private System.Windows.Forms.Button btn_enterFU;
    }
}