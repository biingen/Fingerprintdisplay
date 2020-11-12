
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using HID_Handler;
using System.Security;
using System.Security.Cryptography;


namespace FPD
{
    public partial class Form_Main : Form
    {
        public static Form_Communication form_communication;
        public static Form_Display form_display;
        public static Form_ROIC form_roic;

        public static bool Engineering_mode = false;
        private static SDP_Handler sdp_Handler;

        private static BL_Handler bl_Handler;

        public static Tuple<string, string> tuple;

        internal static SDP_Handler Sdp_Handler { get => sdp_Handler; set => sdp_Handler = value; }
        internal static BL_Handler Bl_Handler { get => bl_Handler; set => bl_Handler = value; }


        public Form_Main()
        {
            InitializeComponent();
            Viewer.PathofExe = Directory.GetCurrentDirectory() + "\\";
            this.Text += " - " + Application.ProductVersion;
            if (form_display == null)
            {
                form_display = new Form_Display();
                form_display.MdiParent = this;
                form_display.MaximizeBox = false;
                form_display.MinimizeBox = false;
                form_display.ControlBox = false;
                form_display.Text = "";
                form_display.Dock = DockStyle.Fill;
                form_display.WindowState = FormWindowState.Normal;
                form_display.Show();
            }
            else
            {
                form_display.WindowState = FormWindowState.Normal;
                form_display.Activate();
            }

            tuple = GenerateRSAKeys();

            if (System.Environment.UserDomainName == "AUO")
            {
                Console.WriteLine("AUO Domain");
                rOICToolStripMenuItem.Visible = true;
            }
            else
            {
                if (File.Exists("Timestamp.fp"))
                {
                    DateTime dateTime = DateTime.Today;
                    try
                    {
                        string text = System.IO.File.ReadAllText("Timestamp.fp");
                        string key = "<RSAKeyValue><Modulus>wisT1dlSbiacCyF09p+SPksPJ5faGclSNkGTId/vZf0lo6fjg4XeSITSwP85KiyHD7l3m/AD2yVFmI4S8AZ/muBRneiAKW8G9CCPyE7T82jGbShFKPAb+4RKZQGTfx53FFQqQFfIAOKFR5r/vUUMqHblyX3wk/nVHUUgKR0IGEk=</Modulus><Exponent>AQAB</Exponent><P>9sOrGTpFC6+6cBbGrJLMs1rHvGaVG+Bwk/dilr0L2NScuAaXl6AA+hHCSMB+2Gz3XlzkF+jc5ioOO+4XZ8oEUw==</P><Q>yW93+/1kumo9yqeXeREAVKgEYVwIDJmSLTThmXe0JSg7hleuVQ1yMqRe9gVrUBFiu+dQvh4VMrNgUJNaiLJdcw==</Q><DP>Q9PYzeBkZifxWSoJhhn7xjjnufOAfN8eUq2nHcPs47bdNQAq3vSOEC6ddp3iv96DyB5EXAYX4fQhYXu6Vz8CHQ==</DP><DQ>O7hmlDkN8g6pfzmsuOIHfRHLKqpEYKfvJKP29q78o7+H1k6Miv7PiqAc30fABx8AbMEpuRPmKP/xYDIvtzNabQ==</DQ><InverseQ>rztylLLMvfJNHqGvFM9tMCUFAKLgGa6R4fSiA7coHLo1WV4jjnzQwNOPUieNMYRtvH6t7P8hxGgUcdMNSaDMVg==</InverseQ><D>PoExhHDOGUlyiB7AETgzEryE52D5w71MKs0XORtmbHV+bV15Xvh0IvInChve4hWtcMFqoJc2FpC8A60QqZXd84Qka7OiLf5KM5i6vir+JgyWTTwd5DNij7r38uaTUoF49+ioXjemN6IkShv8PVp+8PjexwT6r7LE6MjjxuGfJCU=</D></RSAKeyValue>";
                        // public    "<RSAKeyValue><Modulus>wisT1dlSbiacCyF09p+SPksPJ5faGclSNkGTId/vZf0lo6fjg4XeSITSwP85KiyHD7l3m/AD2yVFmI4S8AZ/muBRneiAKW8G9CCPyE7T82jGbShFKPAb+4RKZQGTfx53FFQqQFfIAOKFR5r/vUUMqHblyX3wk/nVHUUgKR0IGEk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
                        string Date = Decrypt(key, text);
                        dateTime = DateTime.Parse(Date);
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Certificate Error");
                    }
                    finally
                    {
                         if (DateTime.Today < dateTime)
                            rOICToolStripMenuItem.Visible = true;
                        else
                        {
                            MessageBox.Show("Certificate Expired");
                        }
                    }
                }
                else
                {
                    rOICToolStripMenuItem.Visible = false;
                }
            }
        }

        public Tuple<string, string> GenerateRSAKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);

            return Tuple.Create<string, string>(publicKey, privateKey);
        }
        static public string Encrypt(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var encryptString = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), true));

            return encryptString;
        }
        static public string Decrypt(string privateKey, string encryptedContent)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var decryptString = Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(encryptedContent), true));

            return decryptString;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x219;
            const int DBT_DEVICEARRIVAL = 0x8000;
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;


            // Listen for operating system messages.
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL:
                            Debug.WriteLine("Main : Device Arrival");
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            Debug.WriteLine("Main : Device Remove"); 

                            break;
                    }
                    break;
            }
            form_display.Mainform_pass(ref m);
            base.WndProc(ref m);
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Viewer.fingerPrint != null)
            {
                Viewer.fingerPrint.Dispose();
                try
                {
                    Viewer.tArrange.Abort();
                    Viewer.tShowImage.Abort();
                    Viewer.tArrange.Interrupt();
                    Viewer.tShowImage.Interrupt();
                }
                catch (Exception)
                {
                }
            }
        }
               
        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_communication == null)
            {
                form_communication = new Form_Communication();
                form_communication.MdiParent = this;
                form_communication.MaximizeBox = false;
                form_communication.MinimizeBox = false;
                form_communication.ControlBox = false;
                form_communication.Text = "";
                form_communication.Dock = DockStyle.Fill;
                form_communication.WindowState = FormWindowState.Normal;
                form_communication.Show();
            }
            else
            {
                form_communication.WindowState = FormWindowState.Normal;
                form_communication.Activate();
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_display == null)
            {
                form_display = new Form_Display();
                form_display.MdiParent = this;
                form_display.MaximizeBox = false;
                form_display.MinimizeBox = false;
                form_display.ControlBox = false;
                form_display.Text = "";
                form_display.Dock = DockStyle.Fill;
                form_display.WindowState = FormWindowState.Normal;
                form_display.Show();

            }
            else
            {
                form_display.WindowState = FormWindowState.Normal;
                form_display.Activate();
            }
        }

        public void Set_Engineering(bool enable)
        {
            this.communicationToolStripMenuItem.Visible = enable;
        }

        private void rOICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_roic == null)
            {
                form_roic = new Form_ROIC();
                form_roic.MdiParent = this;
                form_roic.MaximizeBox = false;
                form_roic.MinimizeBox = false;
                form_roic.ControlBox = false;
                form_roic.Text = "";
                form_roic.Dock = DockStyle.Fill;
                form_roic.WindowState = FormWindowState.Normal;
                form_roic.Show();
            }
            else
            {
                form_roic.WindowState = FormWindowState.Normal;
                form_roic.Activate();
            }
        }

        public Form_Main(string args)
        {
            InitializeComponent();
            string[] parameters = args.Split('?');
            Viewer.SetPalette();
            if (parameters[0] != null)
            {
                switch (parameters[0])
                {
                    case "IsConnected":
                        break;
                    case "AutoConnect_Interval":
                        Viewer.fingerPrint.AutoConnect_Interval= Convert.ToUInt16(parameters[1]);
                        break;
                    case "AutoConnect":                        
                        break;
                    case "Disconnect":
                        Viewer.fingerPrint.Disconnect();
                        break;
                    case "FP_SetPWM":
                        Viewer.fingerPrint.FP_SetPWMPara((UInt16)Convert.ToUInt16(parameters[1]), (UInt16)Convert.ToUInt16(parameters[2]));
                        System.Threading.Thread.Sleep(100);
                        Viewer.fingerPrint.FP_GetPWMPara(out ushort uFreq, out ushort uDuty);
                        break;
                    case "FP_GetPWM":
                        Viewer.fingerPrint.FP_GetPWMPara(out uFreq, out uDuty);
                        break;
                    case "FP_SetSensorPGAGain":
                        ushort pgagain = (ushort)Convert.ToInt16(parameters[1]);
                        Viewer.fingerPrint.FP_SetSensorPGAGain((byte)pgagain);
                        Thread.Sleep(100);
                        byte o_pgagain;
                        Viewer.fingerPrint.FP_GetSensorPGAGain(out o_pgagain);
                        break;
                    case "FP_GetSensorPGAGain":
                        Viewer.fingerPrint.FP_GetSensorPGAGain(out o_pgagain);
                        break;
                    case "FP_SetSensorCfb":
                        ushort cfb = (ushort)(Convert.ToDouble(parameters[1]) / 0.125);
                        Viewer.fingerPrint.FP_SetSensorCfb((byte)cfb);
                        Thread.Sleep(100);
                        byte o_cfb;
                        Viewer.fingerPrint.FP_GetSensorCfb(out o_cfb);
                        break;
                    case "FP_GetSensorCfb":
                        Viewer.fingerPrint.FP_GetSensorCfb(out o_cfb);
                        break;
                    case "FP_SetSensorADCOffset":
                        ushort vos = (ushort)Convert.ToDouble(parameters[1]);
                        Viewer.fingerPrint.FP_SetSensorADCOffset(vos);
                        Thread.Sleep(100);
                        ushort o_vos;
                        Viewer.fingerPrint.FP_GetSensorADCOffset(out o_vos);
                        break;
                    case "FP_GetSensorADCOffset":
                        Viewer.fingerPrint.FP_GetSensorADCOffset(out o_vos);
                        break;
                    case "FP_StartCapture":
                        break;
                    case "FP_StopCapture":
                        break;
                    case "FP_SetROICStream":
                        break;
                    case "FP_GetROICStream":
                        break;
                    case "FP_SetDeviceSequentialTransmitWithLineCnt":
                        break;
                    case "FP_GetDeviceDescription":
                        break;
                    case "FP_ResetDevice":
                        Viewer.fingerPrint.FP_ResetDevice();
                        break;
                    case "FP_EnterFirmwareUpgradeMode":
                        break;
                    case "FP_SaveCaptionData":
                        break;


                }
            }
        }
    }
}
