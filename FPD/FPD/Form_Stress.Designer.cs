namespace FPD
{
    partial class Form_Stress
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
            this.btn_test = new System.Windows.Forms.Button();
            this.textBox_Times = new System.Windows.Forms.TextBox();
            this.label_Times = new System.Windows.Forms.Label();
            this.textBox_delay = new System.Windows.Forms.TextBox();
            this.label_delay = new System.Windows.Forms.Label();
            this.label_testitem = new System.Windows.Forms.Label();
            this.comboBox_Testitem = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.label_value1 = new System.Windows.Forms.Label();
            this.textBox_value1 = new System.Windows.Forms.TextBox();
            this.textBox_value2 = new System.Windows.Forms.TextBox();
            this.label_value2 = new System.Windows.Forms.Label();
            this.textBox_per = new System.Windows.Forms.TextBox();
            this.per_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(176, 174);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(92, 22);
            this.btn_test.TabIndex = 63;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            // 
            // textBox_Times
            // 
            this.textBox_Times.Location = new System.Drawing.Point(71, 174);
            this.textBox_Times.Name = "textBox_Times";
            this.textBox_Times.Size = new System.Drawing.Size(74, 22);
            this.textBox_Times.TabIndex = 62;
            // 
            // label_Times
            // 
            this.label_Times.Location = new System.Drawing.Point(14, 177);
            this.label_Times.Name = "label_Times";
            this.label_Times.Size = new System.Drawing.Size(41, 15);
            this.label_Times.TabIndex = 61;
            this.label_Times.Text = "Times : ";
            // 
            // textBox_delay
            // 
            this.textBox_delay.Location = new System.Drawing.Point(71, 143);
            this.textBox_delay.Name = "textBox_delay";
            this.textBox_delay.Size = new System.Drawing.Size(74, 22);
            this.textBox_delay.TabIndex = 60;
            // 
            // label_delay
            // 
            this.label_delay.Location = new System.Drawing.Point(14, 146);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(55, 15);
            this.label_delay.TabIndex = 59;
            this.label_delay.Text = "Delay: ";
            // 
            // label_testitem
            // 
            this.label_testitem.Location = new System.Drawing.Point(14, 26);
            this.label_testitem.Name = "label_testitem";
            this.label_testitem.Size = new System.Drawing.Size(55, 15);
            this.label_testitem.TabIndex = 58;
            this.label_testitem.Text = "Test Item : ";
            // 
            // comboBox_Testitem
            // 
            this.comboBox_Testitem.FormattingEnabled = true;
            this.comboBox_Testitem.Items.AddRange(new object[] {
            "Device_IsConnected",
            "Device_AutoConnect_Interval",
            "Device_AutoConnect",
            "Device_Disconnect",
            "FP_SetPWM",
            "FP_GetPWM",
            "FP_SetSensorPGAGain",
            "FP_GetSensorPGAGain",
            "FP_SetSensorCfb",
            "FP_GetSensorCfb",
            "FP_SetSensorADCOffset",
            "FP_GetSensorADCOffset",
            "FP_StartCapture",
            "FP_StopCapture",
            "FP_SetROICStream",
            "FP_GetROICStream",
            "FP_SetDeviceSequentialTransmitWithLineCnt",
            "FP_GetDeviceDescription",
            "FP_ResetDevice",
            "FP_EnterFirmwareUpgradeMode",
            "FP_SaveCaptionData"});
            this.comboBox_Testitem.Location = new System.Drawing.Point(71, 24);
            this.comboBox_Testitem.Name = "comboBox_Testitem";
            this.comboBox_Testitem.Size = new System.Drawing.Size(197, 20);
            this.comboBox_Testitem.TabIndex = 57;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(176, 143);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(92, 22);
            this.btn_add.TabIndex = 65;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label_value1
            // 
            this.label_value1.Location = new System.Drawing.Point(14, 56);
            this.label_value1.Name = "label_value1";
            this.label_value1.Size = new System.Drawing.Size(55, 15);
            this.label_value1.TabIndex = 66;
            this.label_value1.Text = "Value1:";
            // 
            // textBox_value1
            // 
            this.textBox_value1.Location = new System.Drawing.Point(71, 53);
            this.textBox_value1.Name = "textBox_value1";
            this.textBox_value1.Size = new System.Drawing.Size(74, 22);
            this.textBox_value1.TabIndex = 67;
            // 
            // textBox_value2
            // 
            this.textBox_value2.Location = new System.Drawing.Point(71, 85);
            this.textBox_value2.Name = "textBox_value2";
            this.textBox_value2.Size = new System.Drawing.Size(74, 22);
            this.textBox_value2.TabIndex = 69;
            // 
            // label_value2
            // 
            this.label_value2.Location = new System.Drawing.Point(14, 88);
            this.label_value2.Name = "label_value2";
            this.label_value2.Size = new System.Drawing.Size(55, 15);
            this.label_value2.TabIndex = 68;
            this.label_value2.Text = "Value2:";
            // 
            // textBox_per
            // 
            this.textBox_per.Location = new System.Drawing.Point(71, 114);
            this.textBox_per.Name = "textBox_per";
            this.textBox_per.Size = new System.Drawing.Size(74, 22);
            this.textBox_per.TabIndex = 71;
            // 
            // per_label
            // 
            this.per_label.Location = new System.Drawing.Point(14, 117);
            this.per_label.Name = "per_label";
            this.per_label.Size = new System.Drawing.Size(55, 15);
            this.per_label.TabIndex = 70;
            this.per_label.Text = "Per-Value:";
            // 
            // Form_Stress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 838);
            this.Controls.Add(this.textBox_per);
            this.Controls.Add(this.per_label);
            this.Controls.Add(this.textBox_value2);
            this.Controls.Add(this.label_value2);
            this.Controls.Add(this.textBox_value1);
            this.Controls.Add(this.label_value1);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.textBox_Times);
            this.Controls.Add(this.label_Times);
            this.Controls.Add(this.textBox_delay);
            this.Controls.Add(this.label_delay);
            this.Controls.Add(this.label_testitem);
            this.Controls.Add(this.comboBox_Testitem);
            this.Name = "Form_Stress";
            this.Text = "Form_Stress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.TextBox textBox_Times;
        private System.Windows.Forms.Label label_Times;
        private System.Windows.Forms.TextBox textBox_delay;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label_testitem;
        private System.Windows.Forms.ComboBox comboBox_Testitem;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label_value1;
        private System.Windows.Forms.TextBox textBox_value1;
        private System.Windows.Forms.TextBox textBox_value2;
        private System.Windows.Forms.Label label_value2;
        private System.Windows.Forms.TextBox textBox_per;
        private System.Windows.Forms.Label per_label;
    }
}