namespace FPD
{
    partial class Form_ROIC
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
            System.Windows.Forms.GroupBox gb_Positional_notation;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rb_bin = new System.Windows.Forms.RadioButton();
            this.rb_dec = new System.Windows.Forms.RadioButton();
            this.rb_hex = new System.Windows.Forms.RadioButton();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.lb_address = new System.Windows.Forms.Label();
            this.tb_wvalue = new System.Windows.Forms.TextBox();
            this.lb_wvalue = new System.Windows.Forms.Label();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_write = new System.Windows.Forms.Button();
            this.tb_rvalue = new System.Windows.Forms.TextBox();
            this.lb_rvalue = new System.Windows.Forms.Label();
            this.rt_script = new System.Windows.Forms.RichTextBox();
            this.rt_log = new System.Windows.Forms.RichTextBox();
            this.lb_Command_script = new System.Windows.Forms.Label();
            this.lb_log = new System.Windows.Forms.Label();
            this.btn_script_load = new System.Windows.Forms.Button();
            this.btn_script_save = new System.Windows.Forms.Button();
            this.btn_script_start = new System.Windows.Forms.Button();
            this.rt_rule = new System.Windows.Forms.RichTextBox();
            this.lb_rule = new System.Windows.Forms.Label();
            this.dgv_seq_data = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_seq_addr = new System.Windows.Forms.TextBox();
            this.tb_seq_len = new System.Windows.Forms.TextBox();
            this.lb_seq_addr = new System.Windows.Forms.Label();
            this.lb_seq_len = new System.Windows.Forms.Label();
            this.btn_seq_read = new System.Windows.Forms.Button();
            this.btn_seq_write = new System.Windows.Forms.Button();
            this.cb_detail_log = new System.Windows.Forms.CheckBox();
            this.btn_script_clear = new System.Windows.Forms.Button();
            this.gb_Byte_detail = new System.Windows.Forms.GroupBox();
            this.cb_byte_7 = new System.Windows.Forms.CheckBox();
            this.cb_byte_6 = new System.Windows.Forms.CheckBox();
            this.cb_byte_3 = new System.Windows.Forms.CheckBox();
            this.cb_byte_5 = new System.Windows.Forms.CheckBox();
            this.cb_byte_2 = new System.Windows.Forms.CheckBox();
            this.cb_byte_4 = new System.Windows.Forms.CheckBox();
            this.cb_byte_1 = new System.Windows.Forms.CheckBox();
            this.cb_byte_0 = new System.Windows.Forms.CheckBox();
            this.tb_command_delay = new System.Windows.Forms.TextBox();
            this.lb_command_delay = new System.Windows.Forms.Label();
            this.gb_script = new System.Windows.Forms.GroupBox();
            this.gb_Seq = new System.Windows.Forms.GroupBox();
            gb_Positional_notation = new System.Windows.Forms.GroupBox();
            gb_Positional_notation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seq_data)).BeginInit();
            this.gb_Byte_detail.SuspendLayout();
            this.gb_script.SuspendLayout();
            this.gb_Seq.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Positional_notation
            // 
            gb_Positional_notation.Controls.Add(this.rb_bin);
            gb_Positional_notation.Controls.Add(this.rb_dec);
            gb_Positional_notation.Controls.Add(this.rb_hex);
            gb_Positional_notation.Location = new System.Drawing.Point(12, 126);
            gb_Positional_notation.Name = "gb_Positional_notation";
            gb_Positional_notation.Size = new System.Drawing.Size(205, 51);
            gb_Positional_notation.TabIndex = 9;
            gb_Positional_notation.TabStop = false;
            gb_Positional_notation.Text = "Positional notation";
            // 
            // rb_bin
            // 
            this.rb_bin.AutoSize = true;
            this.rb_bin.Location = new System.Drawing.Point(145, 21);
            this.rb_bin.Name = "rb_bin";
            this.rb_bin.Size = new System.Drawing.Size(40, 16);
            this.rb_bin.TabIndex = 11;
            this.rb_bin.Text = "Bin";
            this.rb_bin.UseVisualStyleBackColor = true;
            this.rb_bin.CheckedChanged += new System.EventHandler(this.PN_Change);
            // 
            // rb_dec
            // 
            this.rb_dec.AutoSize = true;
            this.rb_dec.Location = new System.Drawing.Point(84, 21);
            this.rb_dec.Name = "rb_dec";
            this.rb_dec.Size = new System.Drawing.Size(41, 16);
            this.rb_dec.TabIndex = 10;
            this.rb_dec.Text = "Dec";
            this.rb_dec.UseVisualStyleBackColor = true;
            this.rb_dec.CheckedChanged += new System.EventHandler(this.PN_Change);
            // 
            // rb_hex
            // 
            this.rb_hex.AutoSize = true;
            this.rb_hex.Checked = true;
            this.rb_hex.Location = new System.Drawing.Point(23, 21);
            this.rb_hex.Name = "rb_hex";
            this.rb_hex.Size = new System.Drawing.Size(42, 16);
            this.rb_hex.TabIndex = 9;
            this.rb_hex.TabStop = true;
            this.rb_hex.Text = "Hex";
            this.rb_hex.UseVisualStyleBackColor = true;
            this.rb_hex.CheckedChanged += new System.EventHandler(this.PN_Change);
            // 
            // tb_address
            // 
            this.tb_address.Location = new System.Drawing.Point(12, 41);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(100, 22);
            this.tb_address.TabIndex = 0;
            this.tb_address.Text = "0";
            this.tb_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_address
            // 
            this.lb_address.AutoSize = true;
            this.lb_address.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_address.Location = new System.Drawing.Point(12, 22);
            this.lb_address.Name = "lb_address";
            this.lb_address.Size = new System.Drawing.Size(49, 16);
            this.lb_address.TabIndex = 1;
            this.lb_address.Text = "Address :";
            // 
            // tb_wvalue
            // 
            this.tb_wvalue.Location = new System.Drawing.Point(12, 98);
            this.tb_wvalue.Name = "tb_wvalue";
            this.tb_wvalue.Size = new System.Drawing.Size(100, 22);
            this.tb_wvalue.TabIndex = 1;
            this.tb_wvalue.Text = "0";
            this.tb_wvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_wvalue
            // 
            this.lb_wvalue.AutoSize = true;
            this.lb_wvalue.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_wvalue.Location = new System.Drawing.Point(12, 80);
            this.lb_wvalue.Name = "lb_wvalue";
            this.lb_wvalue.Size = new System.Drawing.Size(38, 16);
            this.lb_wvalue.TabIndex = 1;
            this.lb_wvalue.Text = "Value :";
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(137, 34);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(80, 37);
            this.btn_read.TabIndex = 2;
            this.btn_read.Text = "Read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_write
            // 
            this.btn_write.Location = new System.Drawing.Point(137, 89);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(80, 37);
            this.btn_write.TabIndex = 3;
            this.btn_write.Text = "Write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // tb_rvalue
            // 
            this.tb_rvalue.Location = new System.Drawing.Point(237, 80);
            this.tb_rvalue.Name = "tb_rvalue";
            this.tb_rvalue.ReadOnly = true;
            this.tb_rvalue.Size = new System.Drawing.Size(100, 22);
            this.tb_rvalue.TabIndex = 0;
            this.tb_rvalue.Text = "0";
            this.tb_rvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_rvalue
            // 
            this.lb_rvalue.AutoSize = true;
            this.lb_rvalue.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rvalue.Location = new System.Drawing.Point(234, 61);
            this.lb_rvalue.Name = "lb_rvalue";
            this.lb_rvalue.Size = new System.Drawing.Size(63, 16);
            this.lb_rvalue.TabIndex = 1;
            this.lb_rvalue.Text = "Read Value :";
            // 
            // rt_script
            // 
            this.rt_script.AcceptsTab = true;
            this.rt_script.Location = new System.Drawing.Point(69, 220);
            this.rt_script.Name = "rt_script";
            this.rt_script.Size = new System.Drawing.Size(223, 561);
            this.rt_script.TabIndex = 18;
            this.rt_script.Text = "";
            // 
            // rt_log
            // 
            this.rt_log.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rt_log.Location = new System.Drawing.Point(360, 41);
            this.rt_log.Name = "rt_log";
            this.rt_log.ReadOnly = true;
            this.rt_log.Size = new System.Drawing.Size(422, 134);
            this.rt_log.TabIndex = 30;
            this.rt_log.Text = "";
            // 
            // lb_Command_script
            // 
            this.lb_Command_script.AutoSize = true;
            this.lb_Command_script.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Command_script.Location = new System.Drawing.Point(69, 197);
            this.lb_Command_script.Name = "lb_Command_script";
            this.lb_Command_script.Size = new System.Drawing.Size(78, 20);
            this.lb_Command_script.TabIndex = 4;
            this.lb_Command_script.Text = "Command :";
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_log.Location = new System.Drawing.Point(356, 19);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(40, 20);
            this.lb_log.TabIndex = 4;
            this.lb_log.Text = "Log :";
            // 
            // btn_script_load
            // 
            this.btn_script_load.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_load.Location = new System.Drawing.Point(329, 316);
            this.btn_script_load.Name = "btn_script_load";
            this.btn_script_load.Size = new System.Drawing.Size(80, 37);
            this.btn_script_load.TabIndex = 15;
            this.btn_script_load.Text = "Load";
            this.btn_script_load.UseVisualStyleBackColor = true;
            this.btn_script_load.Click += new System.EventHandler(this.btn_script_load_Click);
            // 
            // btn_script_save
            // 
            this.btn_script_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_save.Location = new System.Drawing.Point(440, 316);
            this.btn_script_save.Name = "btn_script_save";
            this.btn_script_save.Size = new System.Drawing.Size(80, 37);
            this.btn_script_save.TabIndex = 16;
            this.btn_script_save.Text = "Save";
            this.btn_script_save.UseVisualStyleBackColor = true;
            this.btn_script_save.Click += new System.EventHandler(this.btn_script_save_Click);
            // 
            // btn_script_start
            // 
            this.btn_script_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_start.Location = new System.Drawing.Point(329, 220);
            this.btn_script_start.Name = "btn_script_start";
            this.btn_script_start.Size = new System.Drawing.Size(80, 37);
            this.btn_script_start.TabIndex = 14;
            this.btn_script_start.Text = "Start";
            this.btn_script_start.UseVisualStyleBackColor = true;
            this.btn_script_start.Click += new System.EventHandler(this.btn_script_start_Click);
            // 
            // rt_rule
            // 
            this.rt_rule.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rt_rule.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rt_rule.Location = new System.Drawing.Point(8, 49);
            this.rt_rule.Name = "rt_rule";
            this.rt_rule.ReadOnly = true;
            this.rt_rule.Size = new System.Drawing.Size(566, 138);
            this.rt_rule.TabIndex = 19;
            this.rt_rule.Text = "";
            // 
            // lb_rule
            // 
            this.lb_rule.AutoSize = true;
            this.lb_rule.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rule.Location = new System.Drawing.Point(8, 26);
            this.lb_rule.Name = "lb_rule";
            this.lb_rule.Size = new System.Drawing.Size(44, 20);
            this.lb_rule.TabIndex = 4;
            this.lb_rule.Text = "Rule :";
            // 
            // dgv_seq_data
            // 
            this.dgv_seq_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_seq_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_seq_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_seq_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_seq_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_seq_data.Location = new System.Drawing.Point(2, 72);
            this.dgv_seq_data.MultiSelect = false;
            this.dgv_seq_data.Name = "dgv_seq_data";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_seq_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_seq_data.RowTemplate.Height = 24;
            this.dgv_seq_data.Size = new System.Drawing.Size(631, 424);
            this.dgv_seq_data.TabIndex = 20;
            this.dgv_seq_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seq_data_CellEndEdit);
            this.dgv_seq_data.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seq_data_CellEnter);
            // 
            // Column0
            // 
            this.Column0.HeaderText = "0";
            this.Column0.Name = "Column0";
            this.Column0.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "3";
            this.Column3.Name = "Column3";
            this.Column3.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "4";
            this.Column4.Name = "Column4";
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "5";
            this.Column5.Name = "Column5";
            this.Column5.Width = 30;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "6";
            this.Column6.Name = "Column6";
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "7";
            this.Column7.Name = "Column7";
            this.Column7.Width = 30;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "8";
            this.Column8.Name = "Column8";
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "9";
            this.Column9.Name = "Column9";
            this.Column9.Width = 30;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "A";
            this.Column10.Name = "Column10";
            this.Column10.Width = 30;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "B";
            this.Column11.Name = "Column11";
            this.Column11.Width = 30;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "C";
            this.Column12.Name = "Column12";
            this.Column12.Width = 30;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "D";
            this.Column13.Name = "Column13";
            this.Column13.Width = 30;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "E";
            this.Column14.Name = "Column14";
            this.Column14.Width = 30;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "F";
            this.Column15.Name = "Column15";
            this.Column15.Width = 30;
            // 
            // tb_seq_addr
            // 
            this.tb_seq_addr.Location = new System.Drawing.Point(2, 44);
            this.tb_seq_addr.Name = "tb_seq_addr";
            this.tb_seq_addr.Size = new System.Drawing.Size(100, 22);
            this.tb_seq_addr.TabIndex = 4;
            this.tb_seq_addr.Text = "0";
            this.tb_seq_addr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_seq_len
            // 
            this.tb_seq_len.Location = new System.Drawing.Point(127, 44);
            this.tb_seq_len.Name = "tb_seq_len";
            this.tb_seq_len.Size = new System.Drawing.Size(100, 22);
            this.tb_seq_len.TabIndex = 5;
            this.tb_seq_len.Text = "0";
            this.tb_seq_len.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_seq_addr
            // 
            this.lb_seq_addr.AutoSize = true;
            this.lb_seq_addr.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_seq_addr.Location = new System.Drawing.Point(2, 25);
            this.lb_seq_addr.Name = "lb_seq_addr";
            this.lb_seq_addr.Size = new System.Drawing.Size(49, 16);
            this.lb_seq_addr.TabIndex = 1;
            this.lb_seq_addr.Text = "Address :";
            // 
            // lb_seq_len
            // 
            this.lb_seq_len.AutoSize = true;
            this.lb_seq_len.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_seq_len.Location = new System.Drawing.Point(127, 26);
            this.lb_seq_len.Name = "lb_seq_len";
            this.lb_seq_len.Size = new System.Drawing.Size(41, 16);
            this.lb_seq_len.TabIndex = 1;
            this.lb_seq_len.Text = "Length :";
            // 
            // btn_seq_read
            // 
            this.btn_seq_read.Location = new System.Drawing.Point(247, 29);
            this.btn_seq_read.Name = "btn_seq_read";
            this.btn_seq_read.Size = new System.Drawing.Size(80, 37);
            this.btn_seq_read.TabIndex = 6;
            this.btn_seq_read.Text = "Read";
            this.btn_seq_read.UseVisualStyleBackColor = true;
            this.btn_seq_read.Click += new System.EventHandler(this.btn_seq_read_Click);
            // 
            // btn_seq_write
            // 
            this.btn_seq_write.Location = new System.Drawing.Point(350, 29);
            this.btn_seq_write.Name = "btn_seq_write";
            this.btn_seq_write.Size = new System.Drawing.Size(80, 37);
            this.btn_seq_write.TabIndex = 7;
            this.btn_seq_write.Text = "Write";
            this.btn_seq_write.UseVisualStyleBackColor = true;
            this.btn_seq_write.Click += new System.EventHandler(this.btn_seq_write_Click);
            // 
            // cb_detail_log
            // 
            this.cb_detail_log.AutoSize = true;
            this.cb_detail_log.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_detail_log.Location = new System.Drawing.Point(440, 281);
            this.cb_detail_log.Name = "cb_detail_log";
            this.cb_detail_log.Size = new System.Drawing.Size(82, 19);
            this.cb_detail_log.TabIndex = 13;
            this.cb_detail_log.Text = "Detail Log";
            this.cb_detail_log.UseVisualStyleBackColor = true;
            // 
            // btn_script_clear
            // 
            this.btn_script_clear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_clear.Location = new System.Drawing.Point(329, 270);
            this.btn_script_clear.Name = "btn_script_clear";
            this.btn_script_clear.Size = new System.Drawing.Size(80, 37);
            this.btn_script_clear.TabIndex = 17;
            this.btn_script_clear.Text = "Clear";
            this.btn_script_clear.UseVisualStyleBackColor = true;
            this.btn_script_clear.Click += new System.EventHandler(this.btn_script_clear_Click);
            // 
            // gb_Byte_detail
            // 
            this.gb_Byte_detail.Controls.Add(this.cb_byte_7);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_6);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_3);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_5);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_2);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_4);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_1);
            this.gb_Byte_detail.Controls.Add(this.cb_byte_0);
            this.gb_Byte_detail.Enabled = false;
            this.gb_Byte_detail.Location = new System.Drawing.Point(639, 72);
            this.gb_Byte_detail.Name = "gb_Byte_detail";
            this.gb_Byte_detail.Size = new System.Drawing.Size(97, 297);
            this.gb_Byte_detail.TabIndex = 21;
            this.gb_Byte_detail.TabStop = false;
            this.gb_Byte_detail.Text = "Byte Operation";
            // 
            // cb_byte_7
            // 
            this.cb_byte_7.AutoSize = true;
            this.cb_byte_7.Location = new System.Drawing.Point(16, 33);
            this.cb_byte_7.Name = "cb_byte_7";
            this.cb_byte_7.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_7.TabIndex = 22;
            this.cb_byte_7.Text = "[7]";
            this.cb_byte_7.UseVisualStyleBackColor = true;
            this.cb_byte_7.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_6
            // 
            this.cb_byte_6.AutoSize = true;
            this.cb_byte_6.Location = new System.Drawing.Point(16, 65);
            this.cb_byte_6.Name = "cb_byte_6";
            this.cb_byte_6.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_6.TabIndex = 23;
            this.cb_byte_6.Text = "[6]";
            this.cb_byte_6.UseVisualStyleBackColor = true;
            this.cb_byte_6.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_3
            // 
            this.cb_byte_3.AutoSize = true;
            this.cb_byte_3.Location = new System.Drawing.Point(16, 161);
            this.cb_byte_3.Name = "cb_byte_3";
            this.cb_byte_3.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_3.TabIndex = 26;
            this.cb_byte_3.Text = "[3]";
            this.cb_byte_3.UseVisualStyleBackColor = true;
            this.cb_byte_3.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_5
            // 
            this.cb_byte_5.AutoSize = true;
            this.cb_byte_5.Location = new System.Drawing.Point(16, 97);
            this.cb_byte_5.Name = "cb_byte_5";
            this.cb_byte_5.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_5.TabIndex = 24;
            this.cb_byte_5.Text = "[5]";
            this.cb_byte_5.UseVisualStyleBackColor = true;
            this.cb_byte_5.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_2
            // 
            this.cb_byte_2.AutoSize = true;
            this.cb_byte_2.Location = new System.Drawing.Point(16, 193);
            this.cb_byte_2.Name = "cb_byte_2";
            this.cb_byte_2.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_2.TabIndex = 27;
            this.cb_byte_2.Text = "[2]";
            this.cb_byte_2.UseVisualStyleBackColor = true;
            this.cb_byte_2.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_4
            // 
            this.cb_byte_4.AutoSize = true;
            this.cb_byte_4.Location = new System.Drawing.Point(16, 129);
            this.cb_byte_4.Name = "cb_byte_4";
            this.cb_byte_4.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_4.TabIndex = 25;
            this.cb_byte_4.Text = "[4]";
            this.cb_byte_4.UseVisualStyleBackColor = true;
            this.cb_byte_4.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_1
            // 
            this.cb_byte_1.AutoSize = true;
            this.cb_byte_1.Location = new System.Drawing.Point(16, 225);
            this.cb_byte_1.Name = "cb_byte_1";
            this.cb_byte_1.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_1.TabIndex = 28;
            this.cb_byte_1.Text = "[1]";
            this.cb_byte_1.UseVisualStyleBackColor = true;
            this.cb_byte_1.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // cb_byte_0
            // 
            this.cb_byte_0.AutoSize = true;
            this.cb_byte_0.Location = new System.Drawing.Point(16, 257);
            this.cb_byte_0.Name = "cb_byte_0";
            this.cb_byte_0.Size = new System.Drawing.Size(38, 16);
            this.cb_byte_0.TabIndex = 29;
            this.cb_byte_0.Text = "[0]";
            this.cb_byte_0.UseVisualStyleBackColor = true;
            this.cb_byte_0.CheckedChanged += new System.EventHandler(this.Byte_op_checkchange);
            // 
            // tb_command_delay
            // 
            this.tb_command_delay.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_command_delay.Location = new System.Drawing.Point(440, 233);
            this.tb_command_delay.Name = "tb_command_delay";
            this.tb_command_delay.Size = new System.Drawing.Size(80, 21);
            this.tb_command_delay.TabIndex = 12;
            this.tb_command_delay.Text = "0";
            this.tb_command_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_command_delay
            // 
            this.lb_command_delay.AutoSize = true;
            this.lb_command_delay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_command_delay.Location = new System.Drawing.Point(438, 214);
            this.lb_command_delay.Name = "lb_command_delay";
            this.lb_command_delay.Size = new System.Drawing.Size(41, 15);
            this.lb_command_delay.TabIndex = 10;
            this.lb_command_delay.Text = "Delay:";
            // 
            // gb_script
            // 
            this.gb_script.Controls.Add(this.lb_command_delay);
            this.gb_script.Controls.Add(this.tb_command_delay);
            this.gb_script.Controls.Add(this.cb_detail_log);
            this.gb_script.Controls.Add(this.lb_rule);
            this.gb_script.Controls.Add(this.lb_Command_script);
            this.gb_script.Controls.Add(this.rt_rule);
            this.gb_script.Controls.Add(this.rt_script);
            this.gb_script.Controls.Add(this.btn_script_start);
            this.gb_script.Controls.Add(this.btn_script_clear);
            this.gb_script.Controls.Add(this.btn_script_save);
            this.gb_script.Controls.Add(this.btn_script_load);
            this.gb_script.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_script.Location = new System.Drawing.Point(788, 12);
            this.gb_script.Name = "gb_script";
            this.gb_script.Size = new System.Drawing.Size(589, 796);
            this.gb_script.TabIndex = 31;
            this.gb_script.TabStop = false;
            this.gb_script.Text = "Script";
            // 
            // gb_Seq
            // 
            this.gb_Seq.Controls.Add(this.gb_Byte_detail);
            this.gb_Seq.Controls.Add(this.dgv_seq_data);
            this.gb_Seq.Controls.Add(this.btn_seq_write);
            this.gb_Seq.Controls.Add(this.btn_seq_read);
            this.gb_Seq.Controls.Add(this.lb_seq_len);
            this.gb_Seq.Controls.Add(this.lb_seq_addr);
            this.gb_Seq.Controls.Add(this.tb_seq_len);
            this.gb_Seq.Controls.Add(this.tb_seq_addr);
            this.gb_Seq.Location = new System.Drawing.Point(10, 196);
            this.gb_Seq.Name = "gb_Seq";
            this.gb_Seq.Size = new System.Drawing.Size(772, 510);
            this.gb_Seq.TabIndex = 32;
            this.gb_Seq.TabStop = false;
            this.gb_Seq.Text = "Sequential";
            this.gb_Seq.Visible = false;
            // 
            // Form_ROIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 838);
            this.Controls.Add(this.gb_Seq);
            this.Controls.Add(this.gb_script);
            this.Controls.Add(gb_Positional_notation);
            this.Controls.Add(this.lb_log);
            this.Controls.Add(this.rt_log);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.lb_wvalue);
            this.Controls.Add(this.lb_rvalue);
            this.Controls.Add(this.lb_address);
            this.Controls.Add(this.tb_wvalue);
            this.Controls.Add(this.tb_rvalue);
            this.Controls.Add(this.tb_address);
            this.Name = "Form_ROIC";
            this.Text = "Form_ROIC";
            gb_Positional_notation.ResumeLayout(false);
            gb_Positional_notation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seq_data)).EndInit();
            this.gb_Byte_detail.ResumeLayout(false);
            this.gb_Byte_detail.PerformLayout();
            this.gb_script.ResumeLayout(false);
            this.gb_script.PerformLayout();
            this.gb_Seq.ResumeLayout(false);
            this.gb_Seq.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.TextBox tb_wvalue;
        private System.Windows.Forms.Label lb_wvalue;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.TextBox tb_rvalue;
        private System.Windows.Forms.Label lb_rvalue;
        private System.Windows.Forms.RichTextBox rt_script;
        private System.Windows.Forms.RichTextBox rt_log;
        private System.Windows.Forms.Label lb_Command_script;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.Button btn_script_load;
        private System.Windows.Forms.Button btn_script_save;
        private System.Windows.Forms.Button btn_script_start;
        private System.Windows.Forms.RichTextBox rt_rule;
        private System.Windows.Forms.Label lb_rule;
        private System.Windows.Forms.RadioButton rb_bin;
        private System.Windows.Forms.RadioButton rb_dec;
        private System.Windows.Forms.RadioButton rb_hex;
        private System.Windows.Forms.DataGridView dgv_seq_data;
        private System.Windows.Forms.TextBox tb_seq_addr;
        private System.Windows.Forms.TextBox tb_seq_len;
        private System.Windows.Forms.Label lb_seq_addr;
        private System.Windows.Forms.Label lb_seq_len;
        private System.Windows.Forms.Button btn_seq_read;
        private System.Windows.Forms.Button btn_seq_write;
        private System.Windows.Forms.CheckBox cb_detail_log;
        private System.Windows.Forms.Button btn_script_clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.GroupBox gb_Byte_detail;
        private System.Windows.Forms.CheckBox cb_byte_7;
        private System.Windows.Forms.CheckBox cb_byte_6;
        private System.Windows.Forms.CheckBox cb_byte_3;
        private System.Windows.Forms.CheckBox cb_byte_5;
        private System.Windows.Forms.CheckBox cb_byte_2;
        private System.Windows.Forms.CheckBox cb_byte_4;
        private System.Windows.Forms.CheckBox cb_byte_1;
        private System.Windows.Forms.CheckBox cb_byte_0;
        private System.Windows.Forms.TextBox tb_command_delay;
        private System.Windows.Forms.Label lb_command_delay;
        private System.Windows.Forms.GroupBox gb_script;
        private System.Windows.Forms.GroupBox gb_Seq;
    }
}