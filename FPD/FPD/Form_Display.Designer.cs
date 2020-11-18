namespace FPD
{
    partial class Form_Display
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
            this.components = new System.ComponentModel.Container();
            this.btn_interrupt = new System.Windows.Forms.Button();
            this.rb_10bit = new System.Windows.Forms.RadioButton();
            this.gb_DataBit = new System.Windows.Forms.GroupBox();
            this.rb_8bit = new System.Windows.Forms.RadioButton();
            this.rt_log = new System.Windows.Forms.RichTextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.Drawpanel = new System.Windows.Forms.Panel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.SSL_Connect_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSL_Framecount = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSL_TN = new System.Windows.Forms.ToolStripStatusLabel();
            this.SSL_Save_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb_displayfunc = new System.Windows.Forms.GroupBox();
            this.rb_display_opengl = new System.Windows.Forms.RadioButton();
            this.rb_display_default = new System.Windows.Forms.RadioButton();
            this.gb_Seq_option = new System.Windows.Forms.GroupBox();
            this.cb_Display_Manul_setting = new System.Windows.Forms.CheckBox();
            this.cb_lineorsec = new System.Windows.Forms.CheckBox();
            this.nud_delay = new System.Windows.Forms.NumericUpDown();
            this.lb_Delay = new System.Windows.Forms.Label();
            this.nud_linepersec = new System.Windows.Forms.NumericUpDown();
            this.lb_LinePerSec = new System.Windows.Forms.Label();
            this.gb_PWM = new System.Windows.Forms.GroupBox();
            this.lb_spliter = new System.Windows.Forms.Label();
            this.lb_backlight = new System.Windows.Forms.Label();
            this.rb_bl_off = new System.Windows.Forms.RadioButton();
            this.rb_bl_on = new System.Windows.Forms.RadioButton();
            this.lb_PWM_op = new System.Windows.Forms.Label();
            this.lb_lmofDuty = new System.Windows.Forms.Label();
            this.lb_lmofFreq = new System.Windows.Forms.Label();
            this.tb_PWM_Duty = new System.Windows.Forms.TextBox();
            this.tb_PWM_Freq = new System.Windows.Forms.TextBox();
            this.tbar_PWM_Freq = new System.Windows.Forms.TrackBar();
            this.lb_PWM_Duty = new System.Windows.Forms.Label();
            this.lb_PWM_Freq = new System.Windows.Forms.Label();
            this.tbar_PWM_Duty = new System.Windows.Forms.TrackBar();
            this.btn_GetTest = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lb_seq_read = new System.Windows.Forms.Label();
            this.Sample_panel = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.lb_save_path = new System.Windows.Forms.Label();
            this.tb_zoominratio = new System.Windows.Forms.TextBox();
            this.lb_zoomratio = new System.Windows.Forms.Label();
            this.cb_DebugLog_Level = new System.Windows.Forms.ComboBox();
            this.lb_debugloglevel = new System.Windows.Forms.Label();
            this.btn_zommout = new System.Windows.Forms.Button();
            this.btn_zoomin = new System.Windows.Forms.Button();
            this.gb_sec_screen = new System.Windows.Forms.GroupBox();
            this.rb_sec_dynamic = new System.Windows.Forms.RadioButton();
            this.rb_sec_static = new System.Windows.Forms.RadioButton();
            this.gb_rotate = new System.Windows.Forms.GroupBox();
            this.rb_rotate_270 = new System.Windows.Forms.RadioButton();
            this.rb_rotate_180 = new System.Windows.Forms.RadioButton();
            this.rb_rotate_90 = new System.Windows.Forms.RadioButton();
            this.rb_rotate_0 = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RK_tb_copyright = new System.Windows.Forms.ToolStripTextBox();
            this.RK_tb_code = new System.Windows.Forms.ToolStripTextBox();
            this.tb_pixelinfo = new System.Windows.Forms.TextBox();
            this.tb_pinfo_x = new System.Windows.Forms.TextBox();
            this.tb_pinfo_y = new System.Windows.Forms.TextBox();
            this.lb_pixel_info = new System.Windows.Forms.Label();
            this.lb_pinfo_x = new System.Windows.Forms.Label();
            this.lb_pinfo_y = new System.Windows.Forms.Label();
            this.btn_getpixelinfo = new System.Windows.Forms.Button();
            this.cb_pixel_cursor = new System.Windows.Forms.CheckBox();
            this.lb_savecount = new System.Windows.Forms.Label();
            this.nud_save_count = new System.Windows.Forms.NumericUpDown();
            this.lb_cfb = new System.Windows.Forms.Label();
            this.num_cfb = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.num_pgagain_B = new System.Windows.Forms.NumericUpDown();
            this.lb_vos = new System.Windows.Forms.Label();
            this.num_vos = new System.Windows.Forms.NumericUpDown();
            this.gb_ROIC_op = new System.Windows.Forms.GroupBox();
            this.lb_vos_divide = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_gainAB = new System.Windows.Forms.Label();
            this.num_pgagain_A = new System.Windows.Forms.NumericUpDown();
            this.btn_changed_savepath = new System.Windows.Forms.Button();
            this.cb_ROI = new System.Windows.Forms.CheckBox();
            this.btn_Encoding = new System.Windows.Forms.Button();
            this.tb_Encoding = new System.Windows.Forms.TextBox();
            this.btn_Decoding = new System.Windows.Forms.Button();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.num_pervalue = new System.Windows.Forms.TextBox();
            this.per_label = new System.Windows.Forms.Label();
            this.num_value2 = new System.Windows.Forms.TextBox();
            this.label_value2 = new System.Windows.Forms.Label();
            this.num_value1 = new System.Windows.Forms.TextBox();
            this.label_value1 = new System.Windows.Forms.Label();
            this.btn_savelog = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.num_loop = new System.Windows.Forms.TextBox();
            this.label_Times = new System.Windows.Forms.Label();
            this.num_delay = new System.Windows.Forms.TextBox();
            this.label_delay = new System.Windows.Forms.Label();
            this.label_testitem = new System.Windows.Forms.Label();
            this.cbo_testitem = new System.Windows.Forms.ComboBox();
            this.gb_Stress = new System.Windows.Forms.GroupBox();
            this.gb_DataBit.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.gb_displayfunc.SuspendLayout();
            this.gb_Seq_option.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_linepersec)).BeginInit();
            this.gb_PWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PWM_Freq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PWM_Duty)).BeginInit();
            this.gb_sec_screen.SuspendLayout();
            this.gb_rotate.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_save_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cfb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pgagain_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_vos)).BeginInit();
            this.gb_ROIC_op.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_pgagain_A)).BeginInit();
            this.gb_Stress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_interrupt
            // 
            this.btn_interrupt.Enabled = false;
            this.btn_interrupt.Location = new System.Drawing.Point(977, 156);
            this.btn_interrupt.Margin = new System.Windows.Forms.Padding(2);
            this.btn_interrupt.Name = "btn_interrupt";
            this.btn_interrupt.Size = new System.Drawing.Size(84, 22);
            this.btn_interrupt.TabIndex = 12;
            this.btn_interrupt.Text = "Interrupt";
            this.btn_interrupt.UseVisualStyleBackColor = true;
            this.btn_interrupt.Click += new System.EventHandler(this.Btn_interrupt_Click);
            // 
            // rb_10bit
            // 
            this.rb_10bit.AutoSize = true;
            this.rb_10bit.Location = new System.Drawing.Point(4, 35);
            this.rb_10bit.Margin = new System.Windows.Forms.Padding(2);
            this.rb_10bit.Name = "rb_10bit";
            this.rb_10bit.Size = new System.Drawing.Size(76, 16);
            this.rb_10bit.TabIndex = 8;
            this.rb_10bit.TabStop = true;
            this.rb_10bit.Text = "10 Bit Data";
            this.rb_10bit.UseVisualStyleBackColor = true;
            // 
            // gb_DataBit
            // 
            this.gb_DataBit.Controls.Add(this.rb_10bit);
            this.gb_DataBit.Controls.Add(this.rb_8bit);
            this.gb_DataBit.Location = new System.Drawing.Point(1277, 194);
            this.gb_DataBit.Margin = new System.Windows.Forms.Padding(2);
            this.gb_DataBit.Name = "gb_DataBit";
            this.gb_DataBit.Padding = new System.Windows.Forms.Padding(2);
            this.gb_DataBit.Size = new System.Drawing.Size(93, 61);
            this.gb_DataBit.TabIndex = 16;
            this.gb_DataBit.TabStop = false;
            this.gb_DataBit.Text = "Data Bit";
            this.gb_DataBit.Visible = false;
            // 
            // rb_8bit
            // 
            this.rb_8bit.AutoSize = true;
            this.rb_8bit.Checked = true;
            this.rb_8bit.Location = new System.Drawing.Point(4, 17);
            this.rb_8bit.Margin = new System.Windows.Forms.Padding(2);
            this.rb_8bit.Name = "rb_8bit";
            this.rb_8bit.Size = new System.Drawing.Size(70, 16);
            this.rb_8bit.TabIndex = 9;
            this.rb_8bit.TabStop = true;
            this.rb_8bit.Text = "8 Bit Data";
            this.rb_8bit.UseVisualStyleBackColor = true;
            // 
            // rt_log
            // 
            this.rt_log.Location = new System.Drawing.Point(814, 3);
            this.rt_log.Margin = new System.Windows.Forms.Padding(2);
            this.rt_log.Name = "rt_log";
            this.rt_log.Size = new System.Drawing.Size(466, 110);
            this.rt_log.TabIndex = 15;
            this.rt_log.Text = "";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(816, 115);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(76, 65);
            this.btn_connect.TabIndex = 13;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Location = new System.Drawing.Point(977, 130);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(84, 22);
            this.btn_Start.TabIndex = 14;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // Drawpanel
            // 
            this.Drawpanel.Location = new System.Drawing.Point(10, 3);
            this.Drawpanel.Margin = new System.Windows.Forms.Padding(2);
            this.Drawpanel.Name = "Drawpanel";
            this.Drawpanel.Size = new System.Drawing.Size(800, 750);
            this.Drawpanel.TabIndex = 9;
            this.Drawpanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawpanel_MouseClick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSL_Connect_Status,
            this.SSL_Framecount,
            this.SSL_TN,
            this.SSL_Save_Status});
            this.StatusStrip.Location = new System.Drawing.Point(0, 849);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1416, 22);
            this.StatusStrip.TabIndex = 17;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // SSL_Connect_Status
            // 
            this.SSL_Connect_Status.AutoSize = false;
            this.SSL_Connect_Status.Name = "SSL_Connect_Status";
            this.SSL_Connect_Status.Size = new System.Drawing.Size(150, 17);
            this.SSL_Connect_Status.Text = "UnConnected";
            // 
            // SSL_Framecount
            // 
            this.SSL_Framecount.AutoSize = false;
            this.SSL_Framecount.Name = "SSL_Framecount";
            this.SSL_Framecount.Size = new System.Drawing.Size(150, 17);
            // 
            // SSL_TN
            // 
            this.SSL_TN.AutoSize = false;
            this.SSL_TN.Name = "SSL_TN";
            this.SSL_TN.Size = new System.Drawing.Size(170, 17);
            // 
            // SSL_Save_Status
            // 
            this.SSL_Save_Status.AutoSize = false;
            this.SSL_Save_Status.Name = "SSL_Save_Status";
            this.SSL_Save_Status.Size = new System.Drawing.Size(450, 17);
            // 
            // gb_displayfunc
            // 
            this.gb_displayfunc.Controls.Add(this.rb_display_opengl);
            this.gb_displayfunc.Controls.Add(this.rb_display_default);
            this.gb_displayfunc.Location = new System.Drawing.Point(1090, 117);
            this.gb_displayfunc.Margin = new System.Windows.Forms.Padding(2);
            this.gb_displayfunc.Name = "gb_displayfunc";
            this.gb_displayfunc.Padding = new System.Windows.Forms.Padding(2);
            this.gb_displayfunc.Size = new System.Drawing.Size(109, 61);
            this.gb_displayfunc.TabIndex = 16;
            this.gb_displayfunc.TabStop = false;
            this.gb_displayfunc.Text = "Display option";
            // 
            // rb_display_opengl
            // 
            this.rb_display_opengl.AutoSize = true;
            this.rb_display_opengl.Location = new System.Drawing.Point(4, 37);
            this.rb_display_opengl.Margin = new System.Windows.Forms.Padding(2);
            this.rb_display_opengl.Name = "rb_display_opengl";
            this.rb_display_opengl.Size = new System.Drawing.Size(63, 16);
            this.rb_display_opengl.TabIndex = 8;
            this.rb_display_opengl.TabStop = true;
            this.rb_display_opengl.Text = "OpenGL";
            this.rb_display_opengl.UseVisualStyleBackColor = true;
            this.rb_display_opengl.CheckedChanged += new System.EventHandler(this.DisplayModeChange);
            // 
            // rb_display_default
            // 
            this.rb_display_default.AutoSize = true;
            this.rb_display_default.Checked = true;
            this.rb_display_default.Location = new System.Drawing.Point(4, 17);
            this.rb_display_default.Margin = new System.Windows.Forms.Padding(2);
            this.rb_display_default.Name = "rb_display_default";
            this.rb_display_default.Size = new System.Drawing.Size(57, 16);
            this.rb_display_default.TabIndex = 9;
            this.rb_display_default.TabStop = true;
            this.rb_display_default.Text = "Default";
            this.rb_display_default.UseVisualStyleBackColor = true;
            this.rb_display_default.CheckedChanged += new System.EventHandler(this.DisplayModeChange);
            // 
            // gb_Seq_option
            // 
            this.gb_Seq_option.Controls.Add(this.cb_Display_Manul_setting);
            this.gb_Seq_option.Controls.Add(this.cb_lineorsec);
            this.gb_Seq_option.Controls.Add(this.nud_delay);
            this.gb_Seq_option.Controls.Add(this.lb_Delay);
            this.gb_Seq_option.Controls.Add(this.nud_linepersec);
            this.gb_Seq_option.Controls.Add(this.lb_LinePerSec);
            this.gb_Seq_option.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_Seq_option.Location = new System.Drawing.Point(1277, 259);
            this.gb_Seq_option.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Seq_option.Name = "gb_Seq_option";
            this.gb_Seq_option.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Seq_option.Size = new System.Drawing.Size(93, 153);
            this.gb_Seq_option.TabIndex = 16;
            this.gb_Seq_option.TabStop = false;
            this.gb_Seq_option.Text = "Display Option";
            // 
            // cb_Display_Manul_setting
            // 
            this.cb_Display_Manul_setting.Location = new System.Drawing.Point(9, 114);
            this.cb_Display_Manul_setting.Name = "cb_Display_Manul_setting";
            this.cb_Display_Manul_setting.Size = new System.Drawing.Size(80, 32);
            this.cb_Display_Manul_setting.TabIndex = 3;
            this.cb_Display_Manul_setting.Text = "Use Manul Setting";
            this.cb_Display_Manul_setting.UseVisualStyleBackColor = true;
            // 
            // cb_lineorsec
            // 
            this.cb_lineorsec.AutoSize = true;
            this.cb_lineorsec.Checked = true;
            this.cb_lineorsec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lineorsec.Location = new System.Drawing.Point(9, 93);
            this.cb_lineorsec.Name = "cb_lineorsec";
            this.cb_lineorsec.Size = new System.Drawing.Size(72, 16);
            this.cb_lineorsec.TabIndex = 2;
            this.cb_lineorsec.Text = "BySection";
            this.cb_lineorsec.UseVisualStyleBackColor = true;
            this.cb_lineorsec.CheckedChanged += new System.EventHandler(this.cb_lineorsec_CheckedChanged);
            // 
            // nud_delay
            // 
            this.nud_delay.Location = new System.Drawing.Point(36, 70);
            this.nud_delay.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_delay.Name = "nud_delay";
            this.nud_delay.Size = new System.Drawing.Size(48, 22);
            this.nud_delay.TabIndex = 1;
            this.nud_delay.ValueChanged += new System.EventHandler(this.nud_delay_ValueChanged);
            // 
            // lb_Delay
            // 
            this.lb_Delay.AutoSize = true;
            this.lb_Delay.Location = new System.Drawing.Point(7, 54);
            this.lb_Delay.Name = "lb_Delay";
            this.lb_Delay.Size = new System.Drawing.Size(32, 12);
            this.lb_Delay.TabIndex = 0;
            this.lb_Delay.Text = "Delay";
            // 
            // nud_linepersec
            // 
            this.nud_linepersec.Location = new System.Drawing.Point(36, 33);
            this.nud_linepersec.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_linepersec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_linepersec.Name = "nud_linepersec";
            this.nud_linepersec.Size = new System.Drawing.Size(48, 22);
            this.nud_linepersec.TabIndex = 1;
            this.nud_linepersec.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_linepersec.ValueChanged += new System.EventHandler(this.nud_linepersec_ValueChanged);
            // 
            // lb_LinePerSec
            // 
            this.lb_LinePerSec.AutoSize = true;
            this.lb_LinePerSec.Location = new System.Drawing.Point(7, 18);
            this.lb_LinePerSec.Name = "lb_LinePerSec";
            this.lb_LinePerSec.Size = new System.Drawing.Size(57, 12);
            this.lb_LinePerSec.TabIndex = 0;
            this.lb_LinePerSec.Text = "LinePerSec";
            // 
            // gb_PWM
            // 
            this.gb_PWM.Controls.Add(this.lb_spliter);
            this.gb_PWM.Controls.Add(this.lb_backlight);
            this.gb_PWM.Controls.Add(this.rb_bl_off);
            this.gb_PWM.Controls.Add(this.rb_bl_on);
            this.gb_PWM.Controls.Add(this.lb_PWM_op);
            this.gb_PWM.Controls.Add(this.lb_lmofDuty);
            this.gb_PWM.Controls.Add(this.lb_lmofFreq);
            this.gb_PWM.Controls.Add(this.tb_PWM_Duty);
            this.gb_PWM.Controls.Add(this.tb_PWM_Freq);
            this.gb_PWM.Controls.Add(this.tbar_PWM_Freq);
            this.gb_PWM.Controls.Add(this.lb_PWM_Duty);
            this.gb_PWM.Controls.Add(this.lb_PWM_Freq);
            this.gb_PWM.Controls.Add(this.tbar_PWM_Duty);
            this.gb_PWM.Enabled = false;
            this.gb_PWM.Location = new System.Drawing.Point(814, 184);
            this.gb_PWM.Margin = new System.Windows.Forms.Padding(2);
            this.gb_PWM.Name = "gb_PWM";
            this.gb_PWM.Padding = new System.Windows.Forms.Padding(2);
            this.gb_PWM.Size = new System.Drawing.Size(459, 177);
            this.gb_PWM.TabIndex = 16;
            this.gb_PWM.TabStop = false;
            this.gb_PWM.Text = "Backlight Control";
            // 
            // lb_spliter
            // 
            this.lb_spliter.AutoSize = true;
            this.lb_spliter.Location = new System.Drawing.Point(1, 47);
            this.lb_spliter.Name = "lb_spliter";
            this.lb_spliter.Size = new System.Drawing.Size(465, 12);
            this.lb_spliter.TabIndex = 10;
            this.lb_spliter.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // lb_backlight
            // 
            this.lb_backlight.AutoSize = true;
            this.lb_backlight.Location = new System.Drawing.Point(15, 30);
            this.lb_backlight.Name = "lb_backlight";
            this.lb_backlight.Size = new System.Drawing.Size(63, 12);
            this.lb_backlight.TabIndex = 9;
            this.lb_backlight.Text = "Back Light :";
            // 
            // rb_bl_off
            // 
            this.rb_bl_off.AutoSize = true;
            this.rb_bl_off.Location = new System.Drawing.Point(131, 28);
            this.rb_bl_off.Name = "rb_bl_off";
            this.rb_bl_off.Size = new System.Drawing.Size(39, 16);
            this.rb_bl_off.TabIndex = 7;
            this.rb_bl_off.TabStop = true;
            this.rb_bl_off.Text = "Off";
            this.rb_bl_off.UseVisualStyleBackColor = true;
            this.rb_bl_off.CheckedChanged += new System.EventHandler(this.rb_bl_CheckedChanged);
            // 
            // rb_bl_on
            // 
            this.rb_bl_on.AutoSize = true;
            this.rb_bl_on.Location = new System.Drawing.Point(80, 28);
            this.rb_bl_on.Name = "rb_bl_on";
            this.rb_bl_on.Size = new System.Drawing.Size(37, 16);
            this.rb_bl_on.TabIndex = 8;
            this.rb_bl_on.TabStop = true;
            this.rb_bl_on.Text = "On";
            this.rb_bl_on.UseVisualStyleBackColor = true;
            this.rb_bl_on.CheckedChanged += new System.EventHandler(this.rb_bl_CheckedChanged);
            // 
            // lb_PWM_op
            // 
            this.lb_PWM_op.AutoSize = true;
            this.lb_PWM_op.Location = new System.Drawing.Point(10, 59);
            this.lb_PWM_op.Name = "lb_PWM_op";
            this.lb_PWM_op.Size = new System.Drawing.Size(87, 12);
            this.lb_PWM_op.TabIndex = 5;
            this.lb_PWM_op.Text = "PWM Operation :";
            // 
            // lb_lmofDuty
            // 
            this.lb_lmofDuty.AutoSize = true;
            this.lb_lmofDuty.Location = new System.Drawing.Point(31, 138);
            this.lb_lmofDuty.Name = "lb_lmofDuty";
            this.lb_lmofDuty.Size = new System.Drawing.Size(47, 12);
            this.lb_lmofDuty.TabIndex = 3;
            this.lb_lmofDuty.Text = "(0-1023)";
            // 
            // lb_lmofFreq
            // 
            this.lb_lmofFreq.AutoSize = true;
            this.lb_lmofFreq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_lmofFreq.Location = new System.Drawing.Point(13, 95);
            this.lb_lmofFreq.Name = "lb_lmofFreq";
            this.lb_lmofFreq.Size = new System.Drawing.Size(65, 12);
            this.lb_lmofFreq.TabIndex = 3;
            this.lb_lmofFreq.Text = "(1000-8000)";
            // 
            // tb_PWM_Duty
            // 
            this.tb_PWM_Duty.Location = new System.Drawing.Point(400, 125);
            this.tb_PWM_Duty.Name = "tb_PWM_Duty";
            this.tb_PWM_Duty.Size = new System.Drawing.Size(51, 22);
            this.tb_PWM_Duty.TabIndex = 2;
            this.tb_PWM_Duty.TextChanged += new System.EventHandler(this.tb_PWM_TextChanged);
            // 
            // tb_PWM_Freq
            // 
            this.tb_PWM_Freq.Location = new System.Drawing.Point(400, 80);
            this.tb_PWM_Freq.Name = "tb_PWM_Freq";
            this.tb_PWM_Freq.Size = new System.Drawing.Size(51, 22);
            this.tb_PWM_Freq.TabIndex = 2;
            this.tb_PWM_Freq.TextChanged += new System.EventHandler(this.tb_PWM_TextChanged);
            // 
            // tbar_PWM_Freq
            // 
            this.tbar_PWM_Freq.LargeChange = 1000;
            this.tbar_PWM_Freq.Location = new System.Drawing.Point(84, 77);
            this.tbar_PWM_Freq.Maximum = 8000;
            this.tbar_PWM_Freq.Minimum = 1000;
            this.tbar_PWM_Freq.Name = "tbar_PWM_Freq";
            this.tbar_PWM_Freq.Size = new System.Drawing.Size(321, 45);
            this.tbar_PWM_Freq.SmallChange = 100;
            this.tbar_PWM_Freq.TabIndex = 1;
            this.tbar_PWM_Freq.Value = 1000;
            this.tbar_PWM_Freq.Scroll += new System.EventHandler(this.tbar_PWM_Scroll);
            // 
            // lb_PWM_Duty
            // 
            this.lb_PWM_Duty.AutoSize = true;
            this.lb_PWM_Duty.Location = new System.Drawing.Point(8, 126);
            this.lb_PWM_Duty.Name = "lb_PWM_Duty";
            this.lb_PWM_Duty.Size = new System.Drawing.Size(34, 12);
            this.lb_PWM_Duty.TabIndex = 0;
            this.lb_PWM_Duty.Text = "Duty :";
            // 
            // lb_PWM_Freq
            // 
            this.lb_PWM_Freq.AutoSize = true;
            this.lb_PWM_Freq.Location = new System.Drawing.Point(10, 80);
            this.lb_PWM_Freq.Name = "lb_PWM_Freq";
            this.lb_PWM_Freq.Size = new System.Drawing.Size(60, 12);
            this.lb_PWM_Freq.TabIndex = 0;
            this.lb_PWM_Freq.Text = "Frequency :";
            // 
            // tbar_PWM_Duty
            // 
            this.tbar_PWM_Duty.LargeChange = 128;
            this.tbar_PWM_Duty.Location = new System.Drawing.Point(84, 122);
            this.tbar_PWM_Duty.Maximum = 1023;
            this.tbar_PWM_Duty.Name = "tbar_PWM_Duty";
            this.tbar_PWM_Duty.Size = new System.Drawing.Size(321, 45);
            this.tbar_PWM_Duty.SmallChange = 8;
            this.tbar_PWM_Duty.TabIndex = 1;
            this.tbar_PWM_Duty.Value = 1;
            this.tbar_PWM_Duty.Scroll += new System.EventHandler(this.tbar_PWM_Scroll);
            // 
            // btn_GetTest
            // 
            this.btn_GetTest.Location = new System.Drawing.Point(1204, 117);
            this.btn_GetTest.Name = "btn_GetTest";
            this.btn_GetTest.Size = new System.Drawing.Size(85, 22);
            this.btn_GetTest.TabIndex = 18;
            this.btn_GetTest.Text = "Get Test Patten";
            this.btn_GetTest.UseVisualStyleBackColor = true;
            this.btn_GetTest.Visible = false;
            this.btn_GetTest.Click += new System.EventHandler(this.btn_GetTest_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Enabled = false;
            this.btn_Reset.Location = new System.Drawing.Point(898, 115);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 65);
            this.btn_Reset.TabIndex = 13;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lb_seq_read
            // 
            this.lb_seq_read.AutoSize = true;
            this.lb_seq_read.Location = new System.Drawing.Point(979, 113);
            this.lb_seq_read.Name = "lb_seq_read";
            this.lb_seq_read.Size = new System.Drawing.Size(58, 12);
            this.lb_seq_read.TabIndex = 20;
            this.lb_seq_read.Text = "Streaming :";
            // 
            // Sample_panel
            // 
            this.Sample_panel.Location = new System.Drawing.Point(817, 378);
            this.Sample_panel.Name = "Sample_panel";
            this.Sample_panel.Size = new System.Drawing.Size(400, 375);
            this.Sample_panel.TabIndex = 21;
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(10, 822);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(163, 23);
            this.btn_save.TabIndex = 23;
            this.btn_save.Text = "Save Capture Data";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lb_save_path
            // 
            this.lb_save_path.Location = new System.Drawing.Point(8, 800);
            this.lb_save_path.Name = "lb_save_path";
            this.lb_save_path.Size = new System.Drawing.Size(319, 15);
            this.lb_save_path.TabIndex = 25;
            this.lb_save_path.Text = "Save Path : ";
            // 
            // tb_zoominratio
            // 
            this.tb_zoominratio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_zoominratio.Location = new System.Drawing.Point(1234, 531);
            this.tb_zoominratio.Name = "tb_zoominratio";
            this.tb_zoominratio.ReadOnly = true;
            this.tb_zoominratio.Size = new System.Drawing.Size(39, 26);
            this.tb_zoominratio.TabIndex = 26;
            this.tb_zoominratio.Text = "1";
            this.tb_zoominratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_zoomratio
            // 
            this.lb_zoomratio.AutoSize = true;
            this.lb_zoomratio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_zoomratio.Location = new System.Drawing.Point(1222, 514);
            this.lb_zoomratio.Name = "lb_zoomratio";
            this.lb_zoomratio.Size = new System.Drawing.Size(73, 14);
            this.lb_zoomratio.TabIndex = 27;
            this.lb_zoomratio.Text = "Zoom Ratio";
            // 
            // cb_DebugLog_Level
            // 
            this.cb_DebugLog_Level.FormattingEnabled = true;
            this.cb_DebugLog_Level.Items.AddRange(new object[] {
            "Normal",
            "Infomation",
            "Successful",
            "Warning",
            "Error",
            "No Log"});
            this.cb_DebugLog_Level.Location = new System.Drawing.Point(1204, 160);
            this.cb_DebugLog_Level.Name = "cb_DebugLog_Level";
            this.cb_DebugLog_Level.Size = new System.Drawing.Size(139, 20);
            this.cb_DebugLog_Level.TabIndex = 28;
            this.cb_DebugLog_Level.SelectedIndexChanged += new System.EventHandler(this.cb_DebugLog_Level_SelectedIndexChanged);
            // 
            // lb_debugloglevel
            // 
            this.lb_debugloglevel.AutoSize = true;
            this.lb_debugloglevel.Location = new System.Drawing.Point(1203, 142);
            this.lb_debugloglevel.Name = "lb_debugloglevel";
            this.lb_debugloglevel.Size = new System.Drawing.Size(93, 12);
            this.lb_debugloglevel.TabIndex = 29;
            this.lb_debugloglevel.Text = "Debug Log Level :";
            // 
            // btn_zommout
            // 
            this.btn_zommout.BackgroundImage = global::FPD.Properties.Resources.Zoom_out;
            this.btn_zommout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_zommout.Location = new System.Drawing.Point(1271, 462);
            this.btn_zommout.Name = "btn_zommout";
            this.btn_zommout.Size = new System.Drawing.Size(40, 40);
            this.btn_zommout.TabIndex = 22;
            this.btn_zommout.UseVisualStyleBackColor = true;
            this.btn_zommout.Click += new System.EventHandler(this.btn_zommout_Click);
            // 
            // btn_zoomin
            // 
            this.btn_zoomin.BackgroundImage = global::FPD.Properties.Resources.Zoom_in;
            this.btn_zoomin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_zoomin.Location = new System.Drawing.Point(1225, 462);
            this.btn_zoomin.Name = "btn_zoomin";
            this.btn_zoomin.Size = new System.Drawing.Size(40, 40);
            this.btn_zoomin.TabIndex = 22;
            this.btn_zoomin.UseVisualStyleBackColor = true;
            this.btn_zoomin.Click += new System.EventHandler(this.btn_zoomin_Click);
            // 
            // gb_sec_screen
            // 
            this.gb_sec_screen.Controls.Add(this.rb_sec_dynamic);
            this.gb_sec_screen.Controls.Add(this.rb_sec_static);
            this.gb_sec_screen.Location = new System.Drawing.Point(826, 782);
            this.gb_sec_screen.Margin = new System.Windows.Forms.Padding(2);
            this.gb_sec_screen.Name = "gb_sec_screen";
            this.gb_sec_screen.Padding = new System.Windows.Forms.Padding(2);
            this.gb_sec_screen.Size = new System.Drawing.Size(147, 63);
            this.gb_sec_screen.TabIndex = 16;
            this.gb_sec_screen.TabStop = false;
            this.gb_sec_screen.Text = "Second Screen Source";
            // 
            // rb_sec_dynamic
            // 
            this.rb_sec_dynamic.AutoSize = true;
            this.rb_sec_dynamic.Location = new System.Drawing.Point(4, 35);
            this.rb_sec_dynamic.Margin = new System.Windows.Forms.Padding(2);
            this.rb_sec_dynamic.Name = "rb_sec_dynamic";
            this.rb_sec_dynamic.Size = new System.Drawing.Size(124, 16);
            this.rb_sec_dynamic.TabIndex = 8;
            this.rb_sec_dynamic.TabStop = true;
            this.rb_sec_dynamic.Text = "Dynamic Data Stream";
            this.rb_sec_dynamic.UseVisualStyleBackColor = true;
            this.rb_sec_dynamic.CheckedChanged += new System.EventHandler(this.second_screen_source);
            // 
            // rb_sec_static
            // 
            this.rb_sec_static.AutoSize = true;
            this.rb_sec_static.Checked = true;
            this.rb_sec_static.Location = new System.Drawing.Point(4, 17);
            this.rb_sec_static.Margin = new System.Windows.Forms.Padding(2);
            this.rb_sec_static.Name = "rb_sec_static";
            this.rb_sec_static.Size = new System.Drawing.Size(120, 16);
            this.rb_sec_static.TabIndex = 9;
            this.rb_sec_static.TabStop = true;
            this.rb_sec_static.Text = "Static Sample Picture";
            this.rb_sec_static.UseVisualStyleBackColor = true;
            this.rb_sec_static.CheckedChanged += new System.EventHandler(this.second_screen_source);
            // 
            // gb_rotate
            // 
            this.gb_rotate.Controls.Add(this.rb_rotate_270);
            this.gb_rotate.Controls.Add(this.rb_rotate_180);
            this.gb_rotate.Controls.Add(this.rb_rotate_90);
            this.gb_rotate.Controls.Add(this.rb_rotate_0);
            this.gb_rotate.Location = new System.Drawing.Point(1225, 563);
            this.gb_rotate.Name = "gb_rotate";
            this.gb_rotate.Size = new System.Drawing.Size(113, 72);
            this.gb_rotate.TabIndex = 36;
            this.gb_rotate.TabStop = false;
            this.gb_rotate.Text = "Rotate";
            // 
            // rb_rotate_270
            // 
            this.rb_rotate_270.AutoSize = true;
            this.rb_rotate_270.Location = new System.Drawing.Point(60, 43);
            this.rb_rotate_270.Name = "rb_rotate_270";
            this.rb_rotate_270.Size = new System.Drawing.Size(44, 16);
            this.rb_rotate_270.TabIndex = 0;
            this.rb_rotate_270.Text = "270°";
            this.rb_rotate_270.UseVisualStyleBackColor = true;
            this.rb_rotate_270.CheckedChanged += new System.EventHandler(this.Rotate_chenge);
            // 
            // rb_rotate_180
            // 
            this.rb_rotate_180.AutoSize = true;
            this.rb_rotate_180.Location = new System.Drawing.Point(60, 21);
            this.rb_rotate_180.Name = "rb_rotate_180";
            this.rb_rotate_180.Size = new System.Drawing.Size(44, 16);
            this.rb_rotate_180.TabIndex = 0;
            this.rb_rotate_180.Text = "180°";
            this.rb_rotate_180.UseVisualStyleBackColor = true;
            this.rb_rotate_180.CheckedChanged += new System.EventHandler(this.Rotate_chenge);
            // 
            // rb_rotate_90
            // 
            this.rb_rotate_90.AutoSize = true;
            this.rb_rotate_90.Location = new System.Drawing.Point(2, 43);
            this.rb_rotate_90.Name = "rb_rotate_90";
            this.rb_rotate_90.Size = new System.Drawing.Size(38, 16);
            this.rb_rotate_90.TabIndex = 0;
            this.rb_rotate_90.TabStop = true;
            this.rb_rotate_90.Text = "90°";
            this.rb_rotate_90.UseVisualStyleBackColor = true;
            this.rb_rotate_90.CheckedChanged += new System.EventHandler(this.Rotate_chenge);
            // 
            // rb_rotate_0
            // 
            this.rb_rotate_0.AutoSize = true;
            this.rb_rotate_0.Checked = true;
            this.rb_rotate_0.Location = new System.Drawing.Point(2, 21);
            this.rb_rotate_0.Name = "rb_rotate_0";
            this.rb_rotate_0.Size = new System.Drawing.Size(32, 16);
            this.rb_rotate_0.TabIndex = 0;
            this.rb_rotate_0.TabStop = true;
            this.rb_rotate_0.Text = "0°";
            this.rb_rotate_0.UseVisualStyleBackColor = true;
            this.rb_rotate_0.CheckedChanged += new System.EventHandler(this.Rotate_chenge);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RK_tb_copyright,
            this.RK_tb_code});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(281, 45);
            // 
            // RK_tb_copyright
            // 
            this.RK_tb_copyright.BackColor = System.Drawing.SystemColors.Window;
            this.RK_tb_copyright.Name = "RK_tb_copyright";
            this.RK_tb_copyright.ReadOnly = true;
            this.RK_tb_copyright.Size = new System.Drawing.Size(220, 23);
            this.RK_tb_copyright.Text = "Copyright © 2020 AU Optronics Corp.";
            // 
            // RK_tb_code
            // 
            this.RK_tb_code.AutoSize = false;
            this.RK_tb_code.BackColor = System.Drawing.SystemColors.Window;
            this.RK_tb_code.Font = new System.Drawing.Font("Microsoft JhengHei UI", 4F);
            this.RK_tb_code.Name = "RK_tb_code";
            this.RK_tb_code.Size = new System.Drawing.Size(220, 14);
            this.RK_tb_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RK_tb_code_KeyPress);
            // 
            // tb_pixelinfo
            // 
            this.tb_pixelinfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_pixelinfo.Location = new System.Drawing.Point(10, 763);
            this.tb_pixelinfo.Name = "tb_pixelinfo";
            this.tb_pixelinfo.ReadOnly = true;
            this.tb_pixelinfo.Size = new System.Drawing.Size(357, 26);
            this.tb_pixelinfo.TabIndex = 30;
            // 
            // tb_pinfo_x
            // 
            this.tb_pinfo_x.Location = new System.Drawing.Point(1258, 657);
            this.tb_pinfo_x.Name = "tb_pinfo_x";
            this.tb_pinfo_x.Size = new System.Drawing.Size(60, 22);
            this.tb_pinfo_x.TabIndex = 32;
            this.tb_pinfo_x.Text = "0";
            this.tb_pinfo_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_pinfo_y
            // 
            this.tb_pinfo_y.Location = new System.Drawing.Point(1258, 685);
            this.tb_pinfo_y.Name = "tb_pinfo_y";
            this.tb_pinfo_y.Size = new System.Drawing.Size(60, 22);
            this.tb_pinfo_y.TabIndex = 33;
            this.tb_pinfo_y.Text = "0";
            this.tb_pinfo_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_pixel_info
            // 
            this.lb_pixel_info.AutoSize = true;
            this.lb_pixel_info.Location = new System.Drawing.Point(1227, 638);
            this.lb_pixel_info.Name = "lb_pixel_info";
            this.lb_pixel_info.Size = new System.Drawing.Size(89, 12);
            this.lb_pixel_info.TabIndex = 31;
            this.lb_pixel_info.Text = "Pixel Infomation :";
            // 
            // lb_pinfo_x
            // 
            this.lb_pinfo_x.AutoSize = true;
            this.lb_pinfo_x.Location = new System.Drawing.Point(1230, 660);
            this.lb_pinfo_x.Name = "lb_pinfo_x";
            this.lb_pinfo_x.Size = new System.Drawing.Size(22, 12);
            this.lb_pinfo_x.TabIndex = 33;
            this.lb_pinfo_x.Text = "X : ";
            // 
            // lb_pinfo_y
            // 
            this.lb_pinfo_y.AutoSize = true;
            this.lb_pinfo_y.Location = new System.Drawing.Point(1230, 688);
            this.lb_pinfo_y.Name = "lb_pinfo_y";
            this.lb_pinfo_y.Size = new System.Drawing.Size(22, 12);
            this.lb_pinfo_y.TabIndex = 33;
            this.lb_pinfo_y.Text = "Y : ";
            // 
            // btn_getpixelinfo
            // 
            this.btn_getpixelinfo.Location = new System.Drawing.Point(1229, 735);
            this.btn_getpixelinfo.Name = "btn_getpixelinfo";
            this.btn_getpixelinfo.Size = new System.Drawing.Size(92, 23);
            this.btn_getpixelinfo.TabIndex = 34;
            this.btn_getpixelinfo.Text = "Get Pixel Detail";
            this.btn_getpixelinfo.UseVisualStyleBackColor = true;
            this.btn_getpixelinfo.Click += new System.EventHandler(this.btn_getpixelinfo_Click);
            // 
            // cb_pixel_cursor
            // 
            this.cb_pixel_cursor.AutoSize = true;
            this.cb_pixel_cursor.Location = new System.Drawing.Point(1229, 713);
            this.cb_pixel_cursor.Name = "cb_pixel_cursor";
            this.cb_pixel_cursor.Size = new System.Drawing.Size(56, 16);
            this.cb_pixel_cursor.TabIndex = 35;
            this.cb_pixel_cursor.Text = "Cursor";
            this.cb_pixel_cursor.UseVisualStyleBackColor = true;
            this.cb_pixel_cursor.CheckedChanged += new System.EventHandler(this.cb_pixel_cursor_CheckedChanged);
            // 
            // lb_savecount
            // 
            this.lb_savecount.Location = new System.Drawing.Point(179, 819);
            this.lb_savecount.Name = "lb_savecount";
            this.lb_savecount.Size = new System.Drawing.Size(48, 26);
            this.lb_savecount.TabIndex = 38;
            this.lb_savecount.Text = "Save Count :";
            // 
            // nud_save_count
            // 
            this.nud_save_count.Location = new System.Drawing.Point(233, 823);
            this.nud_save_count.Name = "nud_save_count";
            this.nud_save_count.Size = new System.Drawing.Size(47, 22);
            this.nud_save_count.TabIndex = 39;
            this.nud_save_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_save_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lb_cfb
            // 
            this.lb_cfb.AutoSize = true;
            this.lb_cfb.Location = new System.Drawing.Point(10, 21);
            this.lb_cfb.Name = "lb_cfb";
            this.lb_cfb.Size = new System.Drawing.Size(29, 12);
            this.lb_cfb.TabIndex = 40;
            this.lb_cfb.Text = "Cfb :";
            // 
            // num_cfb
            // 
            this.num_cfb.DecimalPlaces = 3;
            this.num_cfb.Increment = new decimal(new int[] {
            125,
            0,
            0,
            196608});
            this.num_cfb.Location = new System.Drawing.Point(12, 40);
            this.num_cfb.Maximum = new decimal(new int[] {
            3875,
            0,
            0,
            196608});
            this.num_cfb.Name = "num_cfb";
            this.num_cfb.Size = new System.Drawing.Size(95, 22);
            this.num_cfb.TabIndex = 41;
            this.num_cfb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "Gain :";
            // 
            // num_pgagain_B
            // 
            this.num_pgagain_B.Location = new System.Drawing.Point(155, 40);
            this.num_pgagain_B.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_pgagain_B.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pgagain_B.Name = "num_pgagain_B";
            this.num_pgagain_B.Size = new System.Drawing.Size(33, 22);
            this.num_pgagain_B.TabIndex = 43;
            this.num_pgagain_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_pgagain_B.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.num_pgagain_B.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lb_vos
            // 
            this.lb_vos.AutoSize = true;
            this.lb_vos.Location = new System.Drawing.Point(271, 20);
            this.lb_vos.Name = "lb_vos";
            this.lb_vos.Size = new System.Drawing.Size(29, 12);
            this.lb_vos.TabIndex = 44;
            this.lb_vos.Text = "Vos :";
            // 
            // num_vos
            // 
            this.num_vos.Location = new System.Drawing.Point(273, 40);
            this.num_vos.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.num_vos.Name = "num_vos";
            this.num_vos.Size = new System.Drawing.Size(44, 22);
            this.num_vos.TabIndex = 45;
            this.num_vos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_vos.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // gb_ROIC_op
            // 
            this.gb_ROIC_op.Controls.Add(this.lb_vos_divide);
            this.gb_ROIC_op.Controls.Add(this.label2);
            this.gb_ROIC_op.Controls.Add(this.lb_gainAB);
            this.gb_ROIC_op.Controls.Add(this.num_vos);
            this.gb_ROIC_op.Controls.Add(this.num_pgagain_A);
            this.gb_ROIC_op.Controls.Add(this.num_pgagain_B);
            this.gb_ROIC_op.Controls.Add(this.num_cfb);
            this.gb_ROIC_op.Controls.Add(this.lb_vos);
            this.gb_ROIC_op.Controls.Add(this.label1);
            this.gb_ROIC_op.Controls.Add(this.lb_cfb);
            this.gb_ROIC_op.Enabled = false;
            this.gb_ROIC_op.Location = new System.Drawing.Point(440, 782);
            this.gb_ROIC_op.Name = "gb_ROIC_op";
            this.gb_ROIC_op.Size = new System.Drawing.Size(370, 67);
            this.gb_ROIC_op.TabIndex = 46;
            this.gb_ROIC_op.TabStop = false;
            this.gb_ROIC_op.Text = "ROIC_OP";
            // 
            // lb_vos_divide
            // 
            this.lb_vos_divide.AutoSize = true;
            this.lb_vos_divide.Location = new System.Drawing.Point(320, 44);
            this.lb_vos_divide.Name = "lb_vos_divide";
            this.lb_vos_divide.Size = new System.Drawing.Size(32, 12);
            this.lb_vos_divide.TabIndex = 46;
            this.lb_vos_divide.Text = "/1023";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "1 +";
            // 
            // lb_gainAB
            // 
            this.lb_gainAB.AutoSize = true;
            this.lb_gainAB.Location = new System.Drawing.Point(189, 42);
            this.lb_gainAB.Name = "lb_gainAB";
            this.lb_gainAB.Size = new System.Drawing.Size(32, 12);
            this.lb_gainAB.TabIndex = 46;
            this.lb_gainAB.Text = "/16 x ";
            // 
            // num_pgagain_A
            // 
            this.num_pgagain_A.Location = new System.Drawing.Point(221, 40);
            this.num_pgagain_A.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_pgagain_A.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_pgagain_A.Name = "num_pgagain_A";
            this.num_pgagain_A.Size = new System.Drawing.Size(33, 22);
            this.num_pgagain_A.TabIndex = 44;
            this.num_pgagain_A.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_pgagain_A.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_changed_savepath
            // 
            this.btn_changed_savepath.Location = new System.Drawing.Point(286, 822);
            this.btn_changed_savepath.Name = "btn_changed_savepath";
            this.btn_changed_savepath.Size = new System.Drawing.Size(148, 23);
            this.btn_changed_savepath.TabIndex = 24;
            this.btn_changed_savepath.Text = "Change Save Directory";
            this.btn_changed_savepath.UseVisualStyleBackColor = true;
            this.btn_changed_savepath.Click += new System.EventHandler(this.btn_changed_savepath_Click);
            // 
            // cb_ROI
            // 
            this.cb_ROI.AutoSize = true;
            this.cb_ROI.Location = new System.Drawing.Point(1291, 713);
            this.cb_ROI.Name = "cb_ROI";
            this.cb_ROI.Size = new System.Drawing.Size(44, 16);
            this.cb_ROI.TabIndex = 35;
            this.cb_ROI.Text = "ROI";
            this.cb_ROI.UseVisualStyleBackColor = true;
            this.cb_ROI.Visible = false;
            this.cb_ROI.CheckedChanged += new System.EventHandler(this.cb_ROI_CheckedChanged);
            // 
            // btn_Encoding
            // 
            this.btn_Encoding.Location = new System.Drawing.Point(1301, 411);
            this.btn_Encoding.Name = "btn_Encoding";
            this.btn_Encoding.Size = new System.Drawing.Size(69, 23);
            this.btn_Encoding.TabIndex = 47;
            this.btn_Encoding.Text = "Encoding";
            this.btn_Encoding.UseVisualStyleBackColor = true;
            this.btn_Encoding.Visible = false;
            this.btn_Encoding.Click += new System.EventHandler(this.btn_Encoding_Click);
            // 
            // tb_Encoding
            // 
            this.tb_Encoding.Location = new System.Drawing.Point(1223, 434);
            this.tb_Encoding.Name = "tb_Encoding";
            this.tb_Encoding.Size = new System.Drawing.Size(147, 22);
            this.tb_Encoding.TabIndex = 48;
            this.tb_Encoding.Visible = false;
            // 
            // btn_Decoding
            // 
            this.btn_Decoding.Location = new System.Drawing.Point(1223, 411);
            this.btn_Decoding.Name = "btn_Decoding";
            this.btn_Decoding.Size = new System.Drawing.Size(69, 23);
            this.btn_Decoding.TabIndex = 47;
            this.btn_Decoding.Text = "Decoding";
            this.btn_Decoding.UseVisualStyleBackColor = true;
            this.btn_Decoding.Visible = false;
            this.btn_Decoding.Click += new System.EventHandler(this.btn_Decoding_Click);
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(1317, 462);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(53, 22);
            this.tb_key.TabIndex = 48;
            this.tb_key.Visible = false;
            // 
            // num_pervalue
            // 
            this.num_pervalue.Location = new System.Drawing.Point(308, 12);
            this.num_pervalue.Name = "num_pervalue";
            this.num_pervalue.Size = new System.Drawing.Size(74, 22);
            this.num_pervalue.TabIndex = 85;
            // 
            // per_label
            // 
            this.per_label.Location = new System.Drawing.Point(251, 15);
            this.per_label.Name = "per_label";
            this.per_label.Size = new System.Drawing.Size(55, 15);
            this.per_label.TabIndex = 84;
            this.per_label.Text = "Per-Value:";
            // 
            // num_value2
            // 
            this.num_value2.Location = new System.Drawing.Point(67, 61);
            this.num_value2.Name = "num_value2";
            this.num_value2.Size = new System.Drawing.Size(74, 22);
            this.num_value2.TabIndex = 83;
            // 
            // label_value2
            // 
            this.label_value2.Location = new System.Drawing.Point(10, 64);
            this.label_value2.Name = "label_value2";
            this.label_value2.Size = new System.Drawing.Size(55, 15);
            this.label_value2.TabIndex = 82;
            this.label_value2.Text = "Value2:";
            // 
            // num_value1
            // 
            this.num_value1.Location = new System.Drawing.Point(67, 35);
            this.num_value1.Name = "num_value1";
            this.num_value1.Size = new System.Drawing.Size(74, 22);
            this.num_value1.TabIndex = 81;
            // 
            // label_value1
            // 
            this.label_value1.Location = new System.Drawing.Point(10, 38);
            this.label_value1.Name = "label_value1";
            this.label_value1.Size = new System.Drawing.Size(55, 15);
            this.label_value1.TabIndex = 80;
            this.label_value1.Text = "Value1:";
            // 
            // btn_savelog
            // 
            this.btn_savelog.Location = new System.Drawing.Point(152, 35);
            this.btn_savelog.Name = "btn_savelog";
            this.btn_savelog.Size = new System.Drawing.Size(88, 22);
            this.btn_savelog.TabIndex = 79;
            this.btn_savelog.Text = "Save Log";
            this.btn_savelog.UseVisualStyleBackColor = true;
            this.btn_savelog.Visible = false;
            this.btn_savelog.Click += new System.EventHandler(this.btn_savelog_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(152, 61);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(88, 22);
            this.btn_test.TabIndex = 78;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // num_loop
            // 
            this.num_loop.Location = new System.Drawing.Point(308, 61);
            this.num_loop.Name = "num_loop";
            this.num_loop.Size = new System.Drawing.Size(74, 22);
            this.num_loop.TabIndex = 77;
            // 
            // label_Times
            // 
            this.label_Times.Location = new System.Drawing.Point(251, 64);
            this.label_Times.Name = "label_Times";
            this.label_Times.Size = new System.Drawing.Size(41, 15);
            this.label_Times.TabIndex = 76;
            this.label_Times.Text = "Loop : ";
            // 
            // num_delay
            // 
            this.num_delay.Location = new System.Drawing.Point(308, 36);
            this.num_delay.Name = "num_delay";
            this.num_delay.Size = new System.Drawing.Size(74, 22);
            this.num_delay.TabIndex = 75;
            // 
            // label_delay
            // 
            this.label_delay.Location = new System.Drawing.Point(251, 39);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(55, 15);
            this.label_delay.TabIndex = 74;
            this.label_delay.Text = "Delay: ";
            // 
            // label_testitem
            // 
            this.label_testitem.Location = new System.Drawing.Point(10, 13);
            this.label_testitem.Name = "label_testitem";
            this.label_testitem.Size = new System.Drawing.Size(55, 15);
            this.label_testitem.TabIndex = 73;
            this.label_testitem.Text = "Test Item : ";
            // 
            // cbo_testitem
            // 
            this.cbo_testitem.FormattingEnabled = true;
            this.cbo_testitem.Items.AddRange(new object[] {
            "FP_SetPWM_Frequency (1000-8000)",
            "FP_SetPWM_Duty (0-1023)",
            "FP_SetPWM_Backlight (0-1)",
            "FP_SetSensorPGAGain (0-31)",
            "FP_SetSensorCfb (0-31)",
            "FP_SetSensorADCOffset (0-1023)",
            "Device_IsConnected",
            "Device_AutoConnect_Interval",
            "Device_AutoConnect",
            "Device_Disconnect",
            "FP_StartCapture",
            "FP_StopCapture",
            "FP_SetROICStream",
            "FP_GetROICStream",
            "FP_SetDeviceSequentialTransmitWithLineCnt",
            "FP_GetDeviceDescription",
            "FP_ResetDevice",
            "FP_EnterFirmwareUpgradeMode",
            "FP_SaveCaptionData"});
            this.cbo_testitem.Location = new System.Drawing.Point(67, 11);
            this.cbo_testitem.Name = "cbo_testitem";
            this.cbo_testitem.Size = new System.Drawing.Size(173, 20);
            this.cbo_testitem.TabIndex = 72;
            // 
            // gb_Stress
            // 
            this.gb_Stress.Controls.Add(this.cbo_testitem);
            this.gb_Stress.Controls.Add(this.label_testitem);
            this.gb_Stress.Controls.Add(this.num_pervalue);
            this.gb_Stress.Controls.Add(this.label_delay);
            this.gb_Stress.Controls.Add(this.per_label);
            this.gb_Stress.Controls.Add(this.num_delay);
            this.gb_Stress.Controls.Add(this.num_value2);
            this.gb_Stress.Controls.Add(this.label_Times);
            this.gb_Stress.Controls.Add(this.label_value2);
            this.gb_Stress.Controls.Add(this.num_loop);
            this.gb_Stress.Controls.Add(this.num_value1);
            this.gb_Stress.Controls.Add(this.btn_test);
            this.gb_Stress.Controls.Add(this.label_value1);
            this.gb_Stress.Controls.Add(this.btn_savelog);
            this.gb_Stress.Enabled = false;
            this.gb_Stress.Location = new System.Drawing.Point(977, 757);
            this.gb_Stress.Name = "gb_Stress";
            this.gb_Stress.Size = new System.Drawing.Size(393, 87);
            this.gb_Stress.TabIndex = 47;
            this.gb_Stress.TabStop = false;
            this.gb_Stress.Text = "Stress";
            // 
            // Form_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 871);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.gb_Stress);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.tb_Encoding);
            this.Controls.Add(this.btn_Decoding);
            this.Controls.Add(this.btn_Encoding);
            this.Controls.Add(this.gb_ROIC_op);
            this.Controls.Add(this.nud_save_count);
            this.Controls.Add(this.lb_savecount);
            this.Controls.Add(this.cb_ROI);
            this.Controls.Add(this.cb_pixel_cursor);
            this.Controls.Add(this.btn_getpixelinfo);
            this.Controls.Add(this.gb_rotate);
            this.Controls.Add(this.lb_pinfo_y);
            this.Controls.Add(this.lb_debugloglevel);
            this.Controls.Add(this.lb_pinfo_x);
            this.Controls.Add(this.cb_DebugLog_Level);
            this.Controls.Add(this.lb_pixel_info);
            this.Controls.Add(this.lb_zoomratio);
            this.Controls.Add(this.tb_pinfo_y);
            this.Controls.Add(this.tb_pinfo_x);
            this.Controls.Add(this.tb_zoominratio);
            this.Controls.Add(this.tb_pixelinfo);
            this.Controls.Add(this.lb_save_path);
            this.Controls.Add(this.btn_changed_savepath);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_zommout);
            this.Controls.Add(this.btn_zoomin);
            this.Controls.Add(this.Sample_panel);
            this.Controls.Add(this.gb_PWM);
            this.Controls.Add(this.lb_seq_read);
            this.Controls.Add(this.btn_GetTest);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.btn_interrupt);
            this.Controls.Add(this.gb_Seq_option);
            this.Controls.Add(this.gb_displayfunc);
            this.Controls.Add(this.gb_sec_screen);
            this.Controls.Add(this.gb_DataBit);
            this.Controls.Add(this.rt_log);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.Drawpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Display";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Display_FormClosing);
            this.Shown += new System.EventHandler(this.Form_Display_Shown);
            this.Click += new System.EventHandler(this.Form_Display_Click);
            this.gb_DataBit.ResumeLayout(false);
            this.gb_DataBit.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.gb_displayfunc.ResumeLayout(false);
            this.gb_displayfunc.PerformLayout();
            this.gb_Seq_option.ResumeLayout(false);
            this.gb_Seq_option.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_linepersec)).EndInit();
            this.gb_PWM.ResumeLayout(false);
            this.gb_PWM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PWM_Freq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_PWM_Duty)).EndInit();
            this.gb_sec_screen.ResumeLayout(false);
            this.gb_sec_screen.PerformLayout();
            this.gb_rotate.ResumeLayout(false);
            this.gb_rotate.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_save_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cfb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pgagain_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_vos)).EndInit();
            this.gb_ROIC_op.ResumeLayout(false);
            this.gb_ROIC_op.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_pgagain_A)).EndInit();
            this.gb_Stress.ResumeLayout(false);
            this.gb_Stress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_interrupt;
        private System.Windows.Forms.RadioButton rb_10bit;
        private System.Windows.Forms.GroupBox gb_DataBit;
        private System.Windows.Forms.RadioButton rb_8bit;
        private System.Windows.Forms.RichTextBox rt_log;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel Drawpanel;
        public System.Windows.Forms.StatusStrip StatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel SSL_Connect_Status;
        public System.Windows.Forms.ToolStripStatusLabel SSL_Framecount;
        public System.Windows.Forms.ToolStripStatusLabel SSL_TN;
        public System.Windows.Forms.ToolStripStatusLabel SSL_Save_Status;
        private System.Windows.Forms.GroupBox gb_displayfunc;
        private System.Windows.Forms.RadioButton rb_display_opengl;
        private System.Windows.Forms.RadioButton rb_display_default;
        private System.Windows.Forms.GroupBox gb_Seq_option;
        private System.Windows.Forms.NumericUpDown nud_delay;
        private System.Windows.Forms.Label lb_Delay;
        private System.Windows.Forms.NumericUpDown nud_linepersec;
        private System.Windows.Forms.Label lb_LinePerSec;
        private System.Windows.Forms.CheckBox cb_lineorsec;
        private System.Windows.Forms.GroupBox gb_PWM;
        private System.Windows.Forms.Label lb_PWM_Duty;
        private System.Windows.Forms.Label lb_PWM_Freq;
        private System.Windows.Forms.TrackBar tbar_PWM_Freq;
        private System.Windows.Forms.TextBox tb_PWM_Freq;
        private System.Windows.Forms.TrackBar tbar_PWM_Duty;
        private System.Windows.Forms.TextBox tb_PWM_Duty;
        private System.Windows.Forms.Label lb_lmofDuty;
        private System.Windows.Forms.Label lb_lmofFreq;
        private System.Windows.Forms.Button btn_GetTest;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lb_seq_read;
        private System.Windows.Forms.Label lb_backlight;
        private System.Windows.Forms.RadioButton rb_bl_off;
        private System.Windows.Forms.RadioButton rb_bl_on;
        private System.Windows.Forms.Label lb_PWM_op;
        private System.Windows.Forms.Label lb_spliter;
        private System.Windows.Forms.Panel Sample_panel;
        private System.Windows.Forms.Button btn_zoomin;
        private System.Windows.Forms.Button btn_zommout;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lb_save_path;
        private System.Windows.Forms.TextBox tb_zoominratio;
        private System.Windows.Forms.Label lb_zoomratio;
        private System.Windows.Forms.ComboBox cb_DebugLog_Level;
        private System.Windows.Forms.Label lb_debugloglevel;
        private System.Windows.Forms.GroupBox gb_sec_screen;
        private System.Windows.Forms.RadioButton rb_sec_dynamic;
        private System.Windows.Forms.RadioButton rb_sec_static;
        private System.Windows.Forms.GroupBox gb_rotate;
        private System.Windows.Forms.RadioButton rb_rotate_0;
        private System.Windows.Forms.RadioButton rb_rotate_180;
        private System.Windows.Forms.RadioButton rb_rotate_90;
        private System.Windows.Forms.RadioButton rb_rotate_270;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripTextBox RK_tb_code;
        private System.Windows.Forms.ToolStripTextBox RK_tb_copyright;
        private System.Windows.Forms.CheckBox cb_Display_Manul_setting;
        private System.Windows.Forms.TextBox tb_pixelinfo;
        private System.Windows.Forms.TextBox tb_pinfo_x;
        private System.Windows.Forms.TextBox tb_pinfo_y;
        private System.Windows.Forms.Label lb_pixel_info;
        private System.Windows.Forms.Label lb_pinfo_x;
        private System.Windows.Forms.Label lb_pinfo_y;
        private System.Windows.Forms.Button btn_getpixelinfo;
        private System.Windows.Forms.CheckBox cb_pixel_cursor;
        private System.Windows.Forms.Label lb_savecount;
        private System.Windows.Forms.NumericUpDown nud_save_count;
        private System.Windows.Forms.Label lb_cfb;
        private System.Windows.Forms.NumericUpDown num_cfb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_pgagain_B;
        private System.Windows.Forms.Label lb_vos;
        private System.Windows.Forms.NumericUpDown num_vos;
        private System.Windows.Forms.GroupBox gb_ROIC_op;
        private System.Windows.Forms.Label lb_vos_divide;
        private System.Windows.Forms.Label lb_gainAB;
        private System.Windows.Forms.NumericUpDown num_pgagain_A;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_changed_savepath;
        private System.Windows.Forms.CheckBox cb_ROI;
        private System.Windows.Forms.Button btn_Encoding;
        private System.Windows.Forms.TextBox tb_Encoding;
        private System.Windows.Forms.Button btn_Decoding;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.TextBox num_pervalue;
        private System.Windows.Forms.Label per_label;
        private System.Windows.Forms.TextBox num_value2;
        private System.Windows.Forms.Label label_value2;
        private System.Windows.Forms.TextBox num_value1;
        private System.Windows.Forms.Label label_value1;
        private System.Windows.Forms.Button btn_savelog;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.TextBox num_loop;
        private System.Windows.Forms.Label label_Times;
        private System.Windows.Forms.TextBox num_delay;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label_testitem;
        private System.Windows.Forms.ComboBox cbo_testitem;
        private System.Windows.Forms.GroupBox gb_Stress;
    }
}