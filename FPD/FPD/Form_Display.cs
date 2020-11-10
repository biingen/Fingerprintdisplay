using FingerPrint_API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static FPD.Form_Main;
using System.Drawing.Imaging;
using CsGL.OpenGL;
using System.IO;
using static GeneralProtocol.ComportHandle;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace FPD
{
    public partial class Form_Display : Form
    {
        GL_Drawer gL_Drawer;
        GL_SampleDrawer Sample_draw;
        bool UI_Change_Flag = false;
        public Form_Display()
        {
            InitializeComponent();

            Viewer.SetPalette();
            this.rb_display_opengl.Checked = Viewer.DisplayByGL;
            lb_save_path.Text = "Save Path : " + Viewer.PathofExe;
            tb_zoominratio.Text = (1 / Viewer.ZoomIn_Ratio).ToString();
            rb_sec_static.Checked = Viewer.Sec_screen_static;
            rb_sec_dynamic.Checked = !Viewer.Sec_screen_static;
            Engineering_Item(Form_Main.Engineering_mode);

        }

        private void Sample_draw_MouseWheel(object sender, MouseEventArgs e)
        {
            tb_zoominratio.Text = (1 / Viewer.ZoomIn_Ratio).ToString();
            Sample_draw.Refresh();
            if(gL_Drawer != null)
            {
                if (!Viewer.StreamStart)
                    gL_Drawer.Refresh();
            }
        }

        private void Sample_draw_MouseMove(object sender, EventArgs e)
        {
            Sample_draw.Refresh();
            if (gL_Drawer != null)
            {
                if (!Viewer.StreamStart)
                    gL_Drawer.Refresh();
            }
        }

        private void Sample_draw_MouseUp(object sender, MouseEventArgs e)
        {
            Sample_draw.Refresh();
            if (gL_Drawer != null)
            {
                if(!Viewer.StreamStart)
                        gL_Drawer.Refresh();
            }
        }
        private void gl_draw_MouseUp(object sender, MouseEventArgs e)
        {
            Sample_draw.Refresh();
            if (gL_Drawer != null)
            {
                if (!Viewer.StreamStart)
                    gL_Drawer.Refresh();
            }
        }

        public void Mainform_pass(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x219;
            const int DBT_DEVICEARRIVAL = 0x8000;
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            bool Connect_device_remove = false;

            // Listen for operating system messages.
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL:
                            rt_log.AppendText("Device Arrival" + Environment.NewLine);
                            if(Viewer.fingerPrint == null)
                                callButtonEvent(btn_connect, "OnClick");
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            rt_log.AppendText("Device Remove " + Environment.NewLine);
                            if (Viewer.fingerPrint != null)
                            {
                                GeneralProtocol.BasicCommand.DeviceDescription devDes = new GeneralProtocol.BasicCommand.DeviceDescription();
                                ErrorCode ret = Viewer.fingerPrint.FP_GetDeviceDescription(out devDes);
                                if(ret != ErrorCode.FP_STATUS_OK)
                                {
                                    Viewer.fingerPrint.Dispose();
                                    Viewer.fingerPrint = null;
                                    GC.Collect();
                                    rt_log.AppendText("FP Device Remove " + Environment.NewLine);
                                    Connect_device_remove = true;
                                }
                                else
                                {
                                    Connect_device_remove = false;
                                }
                            }
                            if (Connect_device_remove)
                            {
                                if (Viewer._Initial)
                                {
                                    btn_connect.Enabled = true;
                                    btn_Reset.Enabled = false;
                                    gb_ROIC_op.Enabled = false;
                                    gb_PWM.Enabled = false;
                                    Viewer._Initial = false;
                                    if (!btn_Start.Enabled && btn_interrupt.Enabled)
                                    {
                                        if (!Viewer.DisplayByGL)
                                            Viewer.tShowImage.Abort();
                                        Viewer.frameCount = 0;
                                        Viewer.reportTimeCount = 0;
                                        btn_Start.Enabled = true;
                                        gb_displayfunc.Enabled = true;
                                        btn_Start.BackColor = SystemColors.Control;
                                        btn_interrupt.BackColor = Color.PaleVioletRed;

                                        switch (Viewer.nDataFrameNum)
                                        {
                                            case 0:
                                                Viewer.bmp_backup = (Bitmap)Viewer.bmp0.Clone();
                                                break;
                                            case 1:
                                                Viewer.bmp_backup = (Bitmap)Viewer.bmp1.Clone();
                                                break;
                                            case 2:
                                                Viewer.bmp_backup = (Bitmap)Viewer.bmp2.Clone();
                                                break;
                                        }
                                        Viewer.nDataFrameNum = 9;       //in to Backup
                                        Viewer.StreamStart = false;
                                        rt_log.Text += "Stop Stream...\n";
                                        rt_log.Select(rt_log.Text.Length - 1, 0);
                                        rt_log.ScrollToCaret();
                                        if (Viewer.DisplayByGL)
                                        {
                                            gL_Drawer.Refresh();
                                            Sample_draw.Refresh();
                                        }
                                        else
                                            Viewer.Draw_graphic.DrawImage(Viewer.bmp_backup, new Rectangle(0, 0, 800, 750));
                                    }
                                    btn_Start.Enabled = false;
                                    btn_interrupt.Enabled = false;
                                }
                            }
                            break;
                    }
                    rt_log.ScrollToCaret();
                    break;
            }
        }

        public void InitialDvice()
        {
            //Viewer.UpdateStatusCallback UpdateStatusText = ShowStatusText;
            //Viewer._Initial = true;

            //System.IntPtr pRegHandle;
            //pRegHandle = new IntPtr(1);

            //if (!Viewer.fingerPrint.Communication.IsConnected)
            //{
            //    this.rt_log.Text += "Connecting...\n";

            //    foreach (string CP in Viewer.fingerPrint.Communication.USB_VCP.GetVCPbyVidPid())
            //        if (Viewer.fingerPrint.Communication.ManulConnect(CP))
            //        {
            //            Invoke(UpdateStatusText, new Object[] { SSL_Connect_Status, CP + " Connectted", Color.Green });
            //            Viewer.fingerPrint.FrameReceived += Communication_PackageReceived;
            //            Viewer.fingerPrint.Communication.LogReceived += Communication_LogReceived;
            //            break;
            //        }
            //    if (!Viewer.fingerPrint.Communication.IsConnected)
            //    {
            //        Viewer._Initial = false;
            //        Invoke(UpdateStatusText, new Object[] { SSL_Connect_Status, " Connect Failed", Color.Red });
            //    }
            //}


        }
        public void DeviceInitial()
        {
            Viewer.InitialDviceCallback InvokeInitialDvice = InitialDvice;
            if (!Viewer._FormInitial)
            {
                Thread.Sleep(100);
            }
            Viewer._FormInitial = true;
            if (!Viewer._FLUDevice)
            {

                if (true)
                {
                    Viewer._FLUDevice = true;
                }
            }
            if (!Viewer._Initial)
            {
                Invoke(InvokeInitialDvice);
            }
        }

        public static void ShowStatusText(ToolStripStatusLabel txt, String str, Color color)
        {
            txt.Text = str;
            if (color != null)
                txt.ForeColor = color;
            else
                txt.ForeColor = Color.Black;
        }

        public void LogUpdate(string log, bool line)
        {
            if (line)
                rt_log.Text += log + "\n";
            else
                rt_log.Text += log + "\t";
            rt_log.Select(rt_log.Text.Length - 1, 0);
            rt_log.ScrollToCaret();
        }

        public void LogUpdatewColor(string log, bool line, Color color)
        {
            rt_log.SelectionColor = color;
            if (line)
                rt_log.Text += log + "\n";
            else
                rt_log.Text += log + "\t";
            rt_log.Select(rt_log.Text.Length - 1, 0);
            rt_log.ScrollToCaret();
        }

        public void DisplayModeChange(object sender, EventArgs e)
        {
            Viewer.nDataFrameNum = 9;
            if ((string)((RadioButton)sender).Text == "OpenGL" && ((RadioButton)sender).Checked == true)
            {
                Viewer.DisplayByGL = true;
                if (gL_Drawer == null)
                {
                    gL_Drawer = new GL_Drawer();
                    gL_Drawer.Dock = DockStyle.Fill;
                    gL_Drawer.MouseUp += gl_draw_MouseUp;
                }
                if (Sample_draw == null)
                {
                    Sample_draw = new GL_SampleDrawer();
                    Sample_draw.Dock = DockStyle.Fill;
                    Sample_draw.MouseUp += Sample_draw_MouseUp;
                    Sample_draw.MouseMove += Sample_draw_MouseMove;
                    Sample_draw.MouseWheel += Sample_draw_MouseWheel;
                }
                try
                {
                    Drawpanel.Controls.Add(gL_Drawer);
                    Sample_panel.Controls.Add(Sample_draw);
                }
                catch (Exception) { }

                if (Viewer.Draw_graphic != null)
                {
                    Viewer.Draw_graphic.Dispose();
                    Viewer.Draw_graphic = null;
                }
                Additional_Function(true);
            }
            else if ((string)((RadioButton)sender).Text == "Default" && ((RadioButton)sender).Checked == true)
            {
                Viewer.DisplayByGL = false;
                if (gL_Drawer != null)
                {
                    Drawpanel.Controls.Remove(gL_Drawer);
                    gL_Drawer.Dispose();
                    gL_Drawer = null;
                }
                if (Sample_draw != null)
                {
                    Sample_draw.Dispose();
                    Sample_draw = null;
                }
                if (Viewer.Draw_graphic == null)
                    Viewer.Draw_graphic = this.Drawpanel.CreateGraphics();

                Additional_Function(false);
            }
        }

        private void Additional_Function(bool enable)
        {
            Sample_panel.Enabled = enable;
            Sample_panel.Visible = enable;
            btn_zoomin.Enabled = enable;
            btn_zoomin.Visible = enable;
            btn_zommout.Enabled = enable;
            btn_zommout.Visible = enable;
            lb_zoomratio.Enabled = enable;
            lb_zoomratio.Visible = enable;
            tb_zoominratio.Visible = enable;
            tb_zoominratio.Enabled = enable;
            gb_rotate.Visible = enable;
            lb_pixel_info.Visible = enable;
            lb_pinfo_x.Visible = enable;
            tb_pinfo_x.Visible = enable;
            lb_pinfo_y.Visible = enable;
            tb_pinfo_y.Visible = enable;
            cb_pixel_cursor.Visible = enable;
            btn_getpixelinfo.Visible = enable;
            tb_pixelinfo.Visible = enable;
        }

        public void ShowImage()
        {
            Font font = new Font("Times New Roman", 15, FontStyle.Regular);
            System.Drawing.SolidBrush penBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            PointF drawpoint = new PointF(0, 0);
            Viewer.UpdateStatusCallback UpdateStatusText = ShowStatusText;
            System.Diagnostics.Stopwatch drawwatch = new System.Diagnostics.Stopwatch();
            Viewer.frameTime = 100;
            Rectangle Panel_rec = new Rectangle(0, 0, 800, 750);
            int preframe = -1;
            while (Viewer.tShowImage.IsAlive)
            {
                do
                {
                    Thread.Sleep(10);
                } while (preframe == Viewer.frameCount);
                preframe = Viewer.frameCount;
                if (Viewer.frameCount % 100 > 0 && Viewer.tictoc.Elapsed.TotalMilliseconds > 0)
                {
                    Viewer.frameTime = Convert.ToInt32(Viewer.tictoc.Elapsed.TotalMilliseconds) / (Convert.ToInt32(Viewer.frameCount % 100));
                }
                Panel_rec.Width = Drawpanel.Width;
                Panel_rec.Height = Drawpanel.Height;
#if DEBUG
                drawwatch.Reset();
                drawwatch.Start();
#endif
                switch (Viewer.nDataFrameNum)
                {
                    case 0:
                        Viewer.Draw_graphic.DrawImage(Viewer.bmp0, Panel_rec);
                        Viewer._Buffer0 = false;
                        break;
                    case 1:
                        Viewer.Draw_graphic.DrawImage(Viewer.bmp1, Panel_rec);
                        Viewer._Buffer1 = false;
                        break;
                    case 2:
                        Viewer.Draw_graphic.DrawImage(Viewer.bmp2, Panel_rec);
                        Viewer._Buffer2 = false;
                        break;
                    default:
                        break;
                }
                if(Form_Main.Engineering_mode)
                    Viewer.Draw_graphic.DrawString("FPS : " + ((float)1000 / Viewer.frameTime).ToString("f4"), font, penBrush, drawpoint);
                Viewer.Draw_graphic.Flush();
#if DEBUG
                drawwatch.Stop();
                Viewer.drawTime = (int)drawwatch.Elapsed.TotalMilliseconds;
                Invoke(UpdateStatusText, new Object[] { this.SSL_TN, "Wait Time : " + Viewer.drawTime, null });
#endif
            }
        }


        public void ChangeImage()
        {
            gL_Drawer.Refresh();
            if(!Viewer.Sec_screen_static || Viewer.frameCount == 0)
                Sample_draw.Refresh();
        }

        private void Communication_LogReceived(LogMessage.Type type, string Log)
        {
            Viewer.UpadateLogColorInvoke UpdateLogwColor = LogUpdatewColor;
            // 根據 type 改變 Log 文字的顏色
            Color tans_color = SystemColors.ControlText;
            switch (type)
            {
                case LogMessage.Type.Normal:
                    break;
                case LogMessage.Type.Infomation:
                    tans_color = Color.Blue;
                    break;
                case LogMessage.Type.Successful:
                    tans_color = Color.Green;
                    break;
                case LogMessage.Type.Warning:
                    tans_color = Color.Yellow;
                    break;
                case LogMessage.Type.Error:
                    tans_color = Color.Red;
                    break;
                default:
                    break;
            }

            // 印出至 RichTextBox
            if (Log != "")
                Invoke(UpdateLogwColor, new Object[] { Log, true, tans_color });
            
        }

        private void Communication_PackageReceived(FingerPrint.Frame frame)
        {
            Viewer.UpdateImageCallback UpdateImage = ChangeImage;
            Viewer.UpdateStatusCallback UpdateStatusText = ShowStatusText;
            Viewer.UpdateStatusCallback UpdateTNText = ShowStatusText;
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            #region Debug_input
#if DEBUGX
            if (Viewer.frameCount > 0 && Viewer.frameCount % 20 == 0)
            {
                Viewer._Buffer3 = true;
                int col = frame.nDataFrameNum * 16;
                Bitmap clo = frame.bitmap.Clone(new Rectangle(col, 0, 4, frame.bitmap.Height), PixelFormat.Format24bppRgb);
                BitmapData bmpData = clo.LockBits(new Rectangle(0, 0, 4, clo.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb); //frame.bitmap.Height
                byte[] data = new byte[bmpData.Width * bmpData.Height * 3];
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, data.Length); //複製記憶體區塊
                clo.UnlockBits(bmpData);
                if (data[0] != 0)
                {
                    Viewer.tArrange = new Thread(CheckBmp);
                    Viewer.tArrange.Start(data); //new Rectangle(0, 0, 1600, 1), frame.bitmap.PixelFormat
                }
            }
#endif
            #endregion Debug_input

            if (!Viewer.StreamStart)
            {
                Viewer.StreamStart = true;
                Invoke(UpdateLog, new Object[] { "Frist Stream In, Start Stram...", true });
            }

            Viewer.nDataFrameNum = (uint)frame.nDataFrameNum;
            Viewer.FPS = frame.nFPS;
            Viewer.bmp_TN_Temp = frame.bitmap;
            switch (frame.nDataFrameNum)
            {

                case 0:
                    Viewer._Buffer0 = false;
                    Viewer.bmp0 = frame.bitmap;
                    Viewer._Buffer0 = true;
                    break;
                case 1:
                    Viewer._Buffer1 = false;
                    Viewer.bmp1 = frame.bitmap;
                    Viewer._Buffer1 = true;
                    break;
                case 2:
                    Viewer._Buffer2 = false;
                    Viewer.bmp2 = frame.bitmap;
                    Viewer._Buffer2 = true;
                    break;
                default:
                    break;
            }
            if (Viewer.DisplayByGL)
            {
                Invoke(UpdateImage);
            }
            Invoke(UpdateStatusText, new Object[] { this.SSL_Framecount, "Frame count : " + Viewer.frameCount, null });
            Invoke(UpdateStatusText, new Object[] { this.SSL_TN, "TN : " + Viewer.TN, null });
            Viewer.frameCount++;

            if (Viewer.save_count > 0)
            {
                Viewer.tSaveImage = new Thread(new ParameterizedThreadStart(Save_Image));
                Viewer.tSaveImage.Start(frame.bitmap);
                Viewer.save_count--;
            }
            GC.Collect();
        }

       

        public void CheckBmp(object Checkmap)
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Invoke(UpdateLog, new Object[] { "Start Check :" + Viewer.frameCount, true });

            for (int c = 0; c < ((byte[])Checkmap).Length; c++)
            {
                if (((byte[])Checkmap)[c] != 255)
                {
                    Invoke(UpdateLog, new Object[] { "Failed position count : " + c + "Value : " + ((byte[])Checkmap)[c], true });
                }
            }

            //Invoke(UpdateLog, new Object[] { "End Check :" + Viewer.Backup_frame, true });
            Viewer._Buffer3 = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_Start.Enabled = false;
            gb_displayfunc.Enabled = false;
            ErrorCode ret;
            if (cb_Display_Manul_setting.Checked)
            {
                ret = Viewer.fingerPrint.FP_SetROICStream(true);
                if (cb_lineorsec.Checked)
                    ret = Viewer.fingerPrint.FP_SetDeviceSequentialTransmitWithLineCnt(true, Parameter.PatternColorDepth._8bit, Convert.ToByte(nud_linepersec.Value), Convert.ToUInt16(nud_delay.Value), false);
                else
                    ret = Viewer.fingerPrint.FP_SetDeviceSequentialTransmit(true, Parameter.PatternColorDepth._8bit, Convert.ToUInt16(nud_delay.Value));
            }
            else
                ret = Viewer.fingerPrint.FP_StartCapture();

            if (ret == ErrorCode.FP_STATUS_OK)
            {
                Viewer.frameCount = 0;

                btn_interrupt.BackColor = SystemColors.Control;
                btn_Start.BackColor = Color.LawnGreen;
                btn_save.Enabled = true;

                if (!Viewer.DisplayByGL)
                {
                    Viewer.tShowImage = new Thread(ShowImage);
                    Viewer.tShowImage.Start();
                }
            }
            else
            {
                LogUpdate("[E] StartCapture - ErrorCode = " + ret.ToString(), true);
#if DEBUG
                Viewer.fingerPrint.FP_SetDeviceSequentialTransmitWithLineCnt(true, Parameter.PatternColorDepth._8bit, (byte)nud_linepersec.Value, (ushort)nud_delay.Value, false);
#else
                btn_Start.Enabled = true;
#endif

            }
        }

        private void Btn_interrupt_Click(object sender, EventArgs e)
        {
            ErrorCode ret = Viewer.fingerPrint.FP_StopCapture();
            if(ret == ErrorCode.FP_STATUS_OK)
            {
                if (!Viewer.DisplayByGL)
                    Viewer.tShowImage.Abort();
                Viewer.frameCount = 0;
                Viewer.reportTimeCount = 0;
                Viewer.tictoc.Stop();
                Viewer.tictoc.Reset();
                btn_Start.Enabled = true;
                gb_displayfunc.Enabled = true;
                btn_Start.BackColor = SystemColors.Control;
                btn_interrupt.BackColor = Color.PaleVioletRed;

                switch (Viewer.nDataFrameNum)
                {
                    case 0:
                        Viewer.bmp_backup = (Bitmap)Viewer.bmp0.Clone();                    
                        break;
                    case 1:
                        Viewer.bmp_backup = (Bitmap)Viewer.bmp1.Clone();
                        break;
                    case 2:
                        Viewer.bmp_backup = (Bitmap)Viewer.bmp2.Clone();
                        break;
                }
                Viewer.nDataFrameNum = 9;       //in to Backup
                Viewer.StreamStart = false;
                rt_log.Text += "Stop Stream...\n";
                btn_save.Enabled = false;
                if (Viewer.DisplayByGL)
                {
                    gL_Drawer.Refresh();
                    Sample_draw.Refresh();
                }
                else
                    Viewer.Draw_graphic.DrawImage(Viewer.bmp_backup, new Rectangle(0, 0, 800, 750));
            }
            else
            {
                LogUpdate("[E] StopCapture - ErrorCode = " + ret.ToString(), true);
                Viewer.fingerPrint.FP_SetDeviceSequentialTransmit(false);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Viewer.UpdateStatusCallback UpdateStatusText = ShowStatusText;
            Viewer.fingerPrint = new FingerPrint();
            Viewer.fingerPrint.AutoConnect_Interval = 5000;
            btn_connect.Enabled = false;
            if (Viewer.fingerPrint.IsConnected)
            {
                Viewer._Initial = true;
                Invoke(UpdateStatusText, new Object[] { SSL_Connect_Status, " Connectted", Color.Green });
                Viewer.fingerPrint.FrameReceived += Communication_PackageReceived;
                Viewer.fingerPrint.LogReceived += Communication_LogReceived;
                GeneralProtocol.BasicCommand.DeviceDescription devDes = new GeneralProtocol.BasicCommand.DeviceDescription();
                ErrorCode ret = Viewer.fingerPrint.FP_GetDeviceDescription(out devDes);
                if (ret != ErrorCode.FP_STATUS_OK)
                    this.rt_log.AppendText("[E] FP_GetDeviceDescription - ErrorCode = " + ret.ToString() + Environment.NewLine);
                else
                {
                    this.rt_log.AppendText(devDes.ToString() + Environment.NewLine);
                    btn_Reset.Enabled = true;
                    btn_Start.Enabled = true;
                    btn_interrupt.Enabled = true;
                    btn_interrupt.BackColor = Color.PaleVioletRed;
                    gb_ROIC_op.Enabled = true;
                    gb_PWM.Enabled = true;

                    ushort duty, freq;
                    ret = Viewer.fingerPrint.FP_GetPWMPara(out freq, out duty);
                    if (ret != ErrorCode.FP_STATUS_OK)
                        this.rt_log.AppendText("[E] GET PWM - ErrorCode = " + ret.ToString() + Environment.NewLine);
                    else
                    {
                        Viewer.PWMDuty_memory = duty;
                        tb_PWM_Duty.Text = Convert.ToString(duty);
                        tb_PWM_Freq.Text = Convert.ToString(freq);
                        cb_DebugLog_Level.SelectedIndex = (int)Viewer.debuglevel;
                    }

                    byte o_cfb;
                    Viewer.fingerPrint.FP_GetSensorCfb(out o_cfb);
                    num_cfb.Value = o_cfb * num_cfb.Increment;
                    byte o_pgagain;
                    Viewer.fingerPrint.FP_GetSensorPGAGain(out o_pgagain);
                    num_pgagain_A.Value = o_pgagain / 16 + 1;
                    num_pgagain_B.Value = o_pgagain % 16 + 1;
                    ushort o_vos;
                    Viewer.fingerPrint.FP_GetSensorADCOffset(out o_vos);
                    num_vos.Value = o_vos;
                    num_cfb.ValueChanged += num_cfb_ValueChanged;
                    num_pgagain_A.ValueChanged += num_pgagain_ValueChanged;
                    num_pgagain_B.ValueChanged += num_pgagain_ValueChanged;
                    num_vos.ValueChanged += num_vos_ValueChanged;
                    num_cfb.MouseWheel += new MouseEventHandler(Num_MouseWheel_DoNothing);
                    num_pgagain_A.MouseWheel += new MouseEventHandler(Num_MouseWheel_DoNothing);
                    num_pgagain_B.MouseWheel += new MouseEventHandler(Num_MouseWheel_DoNothing);
                    num_vos.MouseWheel += new MouseEventHandler(Num_MouseWheel_DoNothing);
                }
                rt_log.Select(rt_log.Text.Length - 1, 0);
                rt_log.ScrollToCaret();
            }
            else
            {
                Viewer._Initial = false;
                rt_log.Text += "Connect Failed  : \n";
                rt_log.Select(rt_log.Text.Length - 1, 0);
                rt_log.ScrollToCaret();
                Viewer.fingerPrint.Dispose();
                Viewer.fingerPrint = null;
                btn_connect.Enabled = true;
            }
        }

        private void Num_MouseWheel_DoNothing(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs h = e as HandledMouseEventArgs;
            if (h != null)
            {
                h.Handled = true;
            }

        }
               
        private void nud_linepersec_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nud_delay_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cb_lineorsec_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_lineorsec.Checked)
            {
                nud_linepersec.Visible = true;
                nud_linepersec.Enabled = true;
            }
            else
            {
                nud_linepersec.Visible = false;
                nud_linepersec.Enabled = false;
            }
        }
                
        private void tbar_PWM_Scroll(object sender, EventArgs e)
        {
            tb_PWM_Duty.Text = Convert.ToString(tbar_PWM_Duty.Value);
            tb_PWM_Freq.Text = Convert.ToString(tbar_PWM_Freq.Value);
        }

        private void tb_PWM_TextChanged(object sender, EventArgs e)
        {
            if (!UI_Change_Flag)
            {
                UI_Change_Flag = true;
                int Duty = 0;
                int Freq = 0;
                try
                {
                    Duty = Convert.ToUInt16(tb_PWM_Duty.Text);
                }
                catch (Exception ex)
                {
                    tb_PWM_Duty.BackColor = Color.PaleVioletRed;
                    lb_lmofDuty.ForeColor = Color.Red;
                }
                try
                {
                    Freq = Convert.ToUInt16(tb_PWM_Freq.Text);
                }
                catch (Exception ex)
                {
                    tb_PWM_Freq.BackColor = Color.PaleVioletRed;
                    lb_lmofFreq.ForeColor = Color.Red;
                }
                if (Duty < 0 || Duty > 1023)
                {
                    tb_PWM_Duty.BackColor = Color.PaleVioletRed;
                    lb_lmofDuty.ForeColor = Color.Red;
                }
                else if (Freq < 1000 || Freq > 8000)
                {
                    tb_PWM_Freq.BackColor = Color.PaleVioletRed;
                    lb_lmofFreq.ForeColor = Color.Red;
                }
                else
                {
                    ErrorCode ret =  Viewer.fingerPrint.FP_SetPWMPara((UInt16)Freq, (UInt16)Duty);
                    tbar_PWM_Duty.Value = Duty;
                    tb_PWM_Duty.BackColor = Color.PaleVioletRed;
                    System.Threading.Thread.Sleep(100);
                    if (ret != ErrorCode.FP_STATUS_OK)
                    {
                        this.rt_log.AppendText("[E] Set PWM - ErrorCode = " + ret.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        Viewer.fingerPrint.FP_GetPWMPara(out ushort uFreq, out ushort uDuty);
                        tb_PWM_Duty.Text = Convert.ToString(uDuty);
                        tbar_PWM_Duty.Value = Convert.ToUInt16(tb_PWM_Duty.Text);
                        lb_lmofDuty.ForeColor = SystemColors.ControlText;
                        tb_PWM_Freq.Text = Convert.ToString(uFreq);
                        tbar_PWM_Freq.Value = Convert.ToUInt16(tb_PWM_Freq.Text);
                        lb_lmofFreq.ForeColor = SystemColors.ControlText;

                        if (uDuty > 0)
                        {
                            Viewer.PWMDuty_memory = uDuty;
                            tb_PWM_Duty.BackColor = Color.LimeGreen;
                            rb_bl_on.Checked = true;
                        }
                        else if (uDuty == 0)
                        {
                            tb_PWM_Duty.BackColor = Color.LightGray;
                            rb_bl_off.Checked = true;
                        }
                        if(8000> uFreq && uFreq > 1000)
                        {
                            tb_PWM_Freq.BackColor = Color.LimeGreen;
                        }
                    }
                }
                UI_Change_Flag = false;
            }
        }

        private void btn_GetTest_Click(object sender, EventArgs e)
        {
            ErrorCode ret = Viewer.fingerPrint.FP_GetTestPattern(ref Viewer.bmp_backup);
            if (ret == ErrorCode.FP_STATUS_OK)
            {
                Viewer.nDataFrameNum = 9;
                if (Viewer.DisplayByGL)
                {
                    gL_Drawer.Refresh();
                    if (!Viewer.Sec_screen_static)
                        Sample_draw.Refresh();
                }
                else
                    Viewer.Draw_graphic.DrawImage(Viewer.bmp_backup, new Rectangle(0, 0, 800, 750));

            }
            else
                rt_log.AppendText("Get TestPattern Failed - ErrorCode = " + ret.ToString() + Environment.NewLine);

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Viewer.fingerPrint.FP_ResetDevice();
        }

        private void rb_bl_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender).Text == "On")
                {
                    if (!UI_Change_Flag)
                        tb_PWM_Duty.Text = Viewer.PWMDuty_memory.ToString();
                }
                else
                {
                    tb_PWM_Duty.Text = "0";
                }
            }
        }

        private void Drawpanel_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
        }

        private void btn_zoomin_Click(object sender, EventArgs e)
        {
            Viewer.ZoomIn_Ratio = (Viewer.ZoomIn_Ratio / 2 < 0.125) ? 0.125 : Viewer.ZoomIn_Ratio / 2;
            tb_zoominratio.Text = (1 / Viewer.ZoomIn_Ratio).ToString();
            Sample_draw.Update_DisplayRange(0, 0);
            Sample_draw.Refresh();
            if (gL_Drawer != null)
                gL_Drawer.Refresh();
        }

        private void btn_zommout_Click(object sender, EventArgs e)
        {
            Viewer.ZoomIn_Ratio = (Viewer.ZoomIn_Ratio * 2 > 1) ? 1 : Viewer.ZoomIn_Ratio * 2;
            tb_zoominratio.Text = (1 / Viewer.ZoomIn_Ratio).ToString();
            Sample_draw.Update_DisplayRange(0, 0);
            Sample_draw.Refresh();
            gL_Drawer.Refresh();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Viewer.save_count = (int)nud_save_count.Value;
        }

        private void btn_changed_savepath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Viewer.PathofExe = fbd.SelectedPath + "\\";                    
                }
            }
            lb_save_path.Text = "Save Path : " + Viewer.PathofExe;
        }

        private void cb_DebugLog_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_DebugLog_Level.SelectedItem.ToString())
            {
                case "Normal":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.NORMAL);
                    break;
                case "Infomation":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.INFORMATION);
                    break;
                case "Successful":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.SUCCESSFUL);
                    break;
                case "Warning":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.WARNING);
                    break;
                case "Error":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.ERROR);
                    break;
                case "No Log":
                    Viewer.fingerPrint.FP_SetDebugLevel(Parameter.DebugLevel.NOLOG);
                    break;
                default:
                    break;
            }
            Viewer.debuglevel = (Parameter.DebugLevel)cb_DebugLog_Level.SelectedIndex;
        }

        private void second_screen_source(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Viewer.Sec_screen_static = (((RadioButton)sender).Text == "Static Sample Picture");                
            }
            Sample_draw.Refresh();
        }

        public void Pixel_Info(TextBox txt, String str, Color fore, Color back)
        {
            if (fore == null)
                fore = SystemColors.WindowText;
            if (back == null)
                back = SystemColors.Control;
            if (txt == null)
                tb_pixelinfo.Text = str;
            else
                txt.Text = str;
        }

        private void btn_getpixelinfo_Click(object sender, EventArgs e)
        {
            Viewer.UpdateTextCallback UpdateText = Pixel_Info;
            int X = 0, Y = 0;
            X = Convert.ToInt32(tb_pinfo_x.Text);
            Y = Convert.ToInt32(tb_pinfo_y.Text);
            int Rotate_X = 0, Rotate_Y = 0;
            Rotate_X = (Viewer.rotate_degree == 180) ? Viewer.bmp0.Width - 1 - X : (Viewer.rotate_degree == 270) ? Y : (Viewer.rotate_degree == 90) ? Viewer.bmp0.Width - 1 - Y : X;
            Rotate_Y = (Viewer.rotate_degree == 180) ? Viewer.bmp0.Height - 1 - Y : (Viewer.rotate_degree == 270) ? Viewer.bmp0.Height - 1 - X : (Viewer.rotate_degree == 90) ? X : Y;
            Viewer.Mouse.X = Rotate_X;
            Viewer.Mouse.Y = Rotate_Y;


            Viewer.Save_current_tobackup();
            Color pixel = Viewer.bmp_backup.GetPixel(Rotate_X, Rotate_Y);
            Invoke(UpdateText, new Object[] { null, $"X : {X}, Y : {Y}, {pixel.ToString()} ", null, null });
            Sample_draw.Update_DisplayRange(Rotate_X / 4, Rotate_Y / 4);
            Sample_draw.Refresh();
            if (Viewer.DisplayByGL)
            {
                gL_Drawer.Refresh();
            }
        }

        private void cb_pixel_cursor_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.Cursor = ((CheckBox)sender).Checked;
            if (Viewer.DisplayByGL)
            {
                gL_Drawer.Refresh();
            }
        }
        private void cb_ROI_CheckedChanged(object sender, EventArgs e)
        {
            Viewer.ROI = ((CheckBox)sender).Checked;
            if (Viewer.DisplayByGL)
            {
                gL_Drawer.Refresh();
            }
        }

        private void Rotate_chenge(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked == true)
            {
                switch (((RadioButton)sender).Text)
                {
                    case "0°":
                        Viewer.rotate_degree = 0;
                        Drawpanel.Width = 800;
                        Drawpanel.Height = 750;
                        Sample_panel.Width = 400;
                        Sample_panel.Height = 375;
                        break;
                    case "90°":
                        Viewer.rotate_degree = 90;
                        Drawpanel.Width = 750;
                        Drawpanel.Height = 800;
                        Sample_panel.Width = 375;
                        Sample_panel.Height = 400;
                        break;
                    case "180°":
                        Viewer.rotate_degree = 180;
                        Drawpanel.Width = 800;
                        Drawpanel.Height = 750;
                        Sample_panel.Width = 400;
                        Sample_panel.Height = 375;
                        break;
                    case "270°":
                        Viewer.rotate_degree = 270;
                        Drawpanel.Width = 750;
                        Drawpanel.Height = 800;
                        Sample_panel.Width = 375;
                        Sample_panel.Height = 400;
                        break;
                    default:
                        Viewer.rotate_degree = 0;
                        break;
                }
                if (Viewer.DisplayByGL && !Viewer.StreamStart)
                    gL_Drawer.Refresh();
                Sample_draw.Refresh();

                callButtonEvent(btn_getpixelinfo, "OnClick");
            }
        }

        private void callButtonEvent(Button btn, string EventName)
        {
            //建立一個型別      
            Type t = typeof(Button);
            //引數物件      
            object[] p = new object[1];
            //產生方法      
            System.Reflection.MethodInfo m = t.GetMethod(EventName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //引數賦值。傳入函式      
            //獲得引數資料  
            System.Reflection.ParameterInfo[] para = m.GetParameters();
            //根據引數的名字，拿引數的空值。  
            p[0] = Type.GetType(para[0].ParameterType.BaseType.FullName).GetProperty("Empty");
            //呼叫      
            m.Invoke(btn, p);
            return;
        }

        private void Engineering_Item(bool Enable)
        {
            btn_GetTest.Visible = Enable;
            lb_debugloglevel.Visible = Enable;
            cb_DebugLog_Level.Visible = Enable;
            gb_DataBit.Visible = Enable;
            gb_Seq_option.Visible = Enable;
            tb_Encoding.Visible = Enable;
            tb_key.Visible = Enable;
            btn_Encoding.Visible = Enable;
            btn_Decoding.Visible = Enable;
            cb_ROI.Visible = Enable;
            //Viewer.FPS_Enable = Enable;
            if (this.MdiParent != null)
                ((Form_Main)this.MdiParent).Set_Engineering(Enable);
        }

        private void Form_Display_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Right)
            {   
                this.contextMenuStrip1.Show(MousePosition);
            }
        }

        private void RK_tb_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if(RK_tb_code.Text == "1510192" || RK_tb_code.Text == "ACSBA0")
                {
                    Form_Main.Engineering_mode = true;
                    this.Engineering_Item(Form_Main.Engineering_mode);
                    RK_tb_code.Text = "";
                    MessageBox.Show("Welcome Engineering Mode");
                }
                this.contextMenuStrip1.Close();
            }
        }

        private void Form_Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btn_Start.Enabled && btn_interrupt.Enabled)
            {
                callButtonEvent(btn_interrupt, "OnClick");
            }
        }

        private void Form_Display_Shown(object sender, EventArgs e)
        {
            callButtonEvent(btn_connect, "OnClick");
            //callButtonEvent(btn_Start, "OnClick");
            //callButtonEvent(btn_save, "OnClick");
        }

        private void Save_Image(object image)
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            string save_path = "Saved_Image_" + DateTime.Now.ToString("ddMMyy_HHmmss_fff") + ".bmp";            
            Viewer.sSavePath = new FileStream(Viewer.PathofExe + save_path, FileMode.Create);
            lock(image)
            {
                ((Bitmap)image).Save(Viewer.sSavePath, ImageFormat.Bmp);
            }
            Viewer.sSavePath.Close();
            SSL_Save_Status.Text = "File Save at " + Viewer.PathofExe + save_path;
            Invoke(UpdateLog, new Object[] { "File Save at " + Viewer.PathofExe + save_path, true });
            GC.Collect();
        }

        private void num_cfb_ValueChanged(object sender, EventArgs e)
        {
            ushort cfb = (ushort)(Convert.ToDouble( num_cfb.Value ) / 0.125);
            Viewer.fingerPrint.FP_SetSensorCfb((byte)cfb);
            Thread.Sleep(100);
            byte o_cfb;
            Viewer.fingerPrint.FP_GetSensorCfb(out o_cfb);
            if(o_cfb != cfb)
            {
                rt_log.AppendText("Set Cfb Fail..." + Environment.NewLine);
                num_cfb.Value = o_cfb * num_cfb.Increment;
            }
        }
        

        private void num_pgagain_ValueChanged(object sender, EventArgs e)
        {
            ushort pgagain = (ushort)((Convert.ToInt16(num_pgagain_A.Value) - 1) * 16 + Convert.ToInt16(num_pgagain_B.Value) - 1);
            Viewer.fingerPrint.FP_SetSensorPGAGain((byte)pgagain);
            Thread.Sleep(100);
            byte o_pgagain;
            Viewer.fingerPrint.FP_GetSensorPGAGain(out o_pgagain);
            if (o_pgagain != pgagain)
            {
                rt_log.AppendText("Set Gain Fail..." + Environment.NewLine);
                num_pgagain_A.Value = o_pgagain / 16 + 1;
                num_pgagain_B.Value = o_pgagain % 16 + 1;
            }
        }

        private void num_vos_ValueChanged(object sender, EventArgs e)
        {
            ushort vos = (ushort)(Convert.ToDouble(num_vos.Value));
            Viewer.fingerPrint.FP_SetSensorADCOffset(vos);
            Thread.Sleep(100);
            ushort o_vos;
            Viewer.fingerPrint.FP_GetSensorADCOffset(out o_vos);
            if (o_vos != vos)
            {
                rt_log.AppendText("Set Vos Fail..." + Environment.NewLine);
                num_vos.Value = o_vos;
            }
        }

        private void btn_Encoding_Click(object sender, EventArgs e)
        {
            tb_Encoding.Text = Form_Main.Encrypt(Form_Main.tuple.Item1, tb_Encoding.Text);//將加密後的位元組陣列轉換為加密字串
            tb_key.Text = Form_Main.tuple.Item2;
        }

        private void btn_Decoding_Click(object sender, EventArgs e)
        {
            tb_Encoding.Text = Form_Main.Decrypt(Form_Main.tuple.Item2, tb_Encoding.Text);//將加密後的位元組陣列轉換為加密字串
        }
    }
}
