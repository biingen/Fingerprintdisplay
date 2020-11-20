
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using static FPD.Form_Main;
using HID_Handler;

namespace FPD
{    
    public partial class Form_Communication : Form
    {
        static bool wait_response_lock;
        private static bool File_Support = false;        
        static List<Command> CommandList = new List<Command>();

        public Form_Communication()
        {
            InitializeComponent();
            dgv_datamap.Rows.Add(new string[dgv_datamap.Columns.Count]);
            dgv_datamap.Rows.RemoveAt(0);
        }

        public void LogUpdate(string log, bool line)
        {
            if (line)
            {
                rt_log.Text += log + "\n";
                File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
            }
            else
            {
                rt_log.Text += log + "\t";
                File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
            }
            rt_log.Select(rt_log.Text.Length - 1, 0);
            rt_log.ScrollToCaret();
        }
        
        private void UpdateLogFromHandler(string log, bool newline) {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Invoke(UpdateLog, new Object[] { log, newline });
        }

        private void DeviceInserted()
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Invoke(UpdateLog, new Object[] { "連接成功", true});
        }

        private void DeviceRemoved()
        {
            
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Invoke(UpdateLog, new Object[] { "連接中斷", true });
        }

        public void PushReceiveData(byte[] datas)
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Viewer.UpadateDataMapInvoke UpdateDataMap = Data_Process;
            if(datas.Length > 0)
            {
                Invoke(UpdateLog, "Data Received", true);
                Invoke(UpdateDataMap, BitConverter.ToString(datas, 0).Replace("-", " "));
            }
        }

        public void Data_Process(string raw_data)
        {
            if (raw_data != null)
            {
                int addr = Int32.Parse(tb_addr.Text, System.Globalization.NumberStyles.HexNumber);
                char[] spliter = { ' ' };
                string[] data_split = raw_data.Split(spliter);
#if DEBUG
                for(int i = 0; i < data_split.Length; i++)
                {
                    Debug.Write(data_split[i] + "\t");
                }
                Debug.WriteLine("");
#endif
                int redundent = data_split.Length % dgv_datamap.Columns.Count;
                int totaldata_rowcount = data_split.Length / dgv_datamap.Columns.Count + ((redundent != 0) ? 1 : 0);
                for (int row_count = 0; row_count < totaldata_rowcount; row_count++)
                {
                    string[] row_temp = new string[dgv_datamap.Columns.Count];
                    if(row_count == totaldata_rowcount - 1)
                    {
                        Array.Copy(data_split, row_count * dgv_datamap.Columns.Count, row_temp, 0, redundent);
                    }
                    else
                        Array.Copy(data_split, row_count * dgv_datamap.Columns.Count, row_temp, 0, dgv_datamap.Columns.Count);

                    dgv_datamap.Rows.Add(row_temp);
                    dgv_datamap.Rows[row_count].HeaderCell.Value = row_count.ToString();
                }
            }
            else
            {
                int removecount = dgv_datamap.Rows.Count;
                dgv_datamap.Rows.Add(new string[dgv_datamap.Columns.Count]);
                for (int row = 0; row < removecount; row++)
                    dgv_datamap.Rows.RemoveAt(0);
            }
        }

        public void Assign_ProgressBar(int value)
        {
            if (value == 0)
                pBar_1.Value = value;
            else
            {
                if (pBar_1.Value + value > pBar_1.Maximum)
                    pBar_1.Value = pBar_1.Maximum;
                else
                    pBar_1.Value += value;
            }
        }

        private void btn_SDP_Connect_Click(object sender, EventArgs e)
        {
            Sdp_Handler = SDP_Handler.Enumerate(0x1FC9, new[] { 0x0130 }).FirstOrDefault();
            if (Sdp_Handler != null)
            {
                Sdp_Handler.DataRecieved += PushReceiveData;
                Sdp_Handler.Inserted += DeviceInserted;
                Sdp_Handler.Removed += DeviceRemoved;
                Sdp_Handler.StartListen();
            }
        }

        private void btn_SDP_disconnect_Click(object sender, EventArgs e)
        {
        }

        private void btn_sent_SDP_Click(object sender, EventArgs e)
        {
            btn_sent_SDP.Enabled = false;
            Viewer.UpadateDataMapInvoke UpdateDataMap = Data_Process;
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Viewer.UpdateProgressBarCallback UpdateProgressBar = Assign_ProgressBar;
            Invoke(UpdateProgressBar, 0);
            int addr_int = Int32.Parse(tb_addr.Text, System.Globalization.NumberStyles.HexNumber);

            int datacount = Convert.ToInt32(tb_datacount.Text);
            byte[] data = new byte[datacount];
            int row = 0, col = 0, pcount = 0;

            if (cb_command_type.Text == "WRITE_REGISTER" || cb_command_type.Text == "WRITE_FILE")
            {
                while (pcount < datacount && dgv_datamap.Rows[row].Cells[col].Value != null)
                {

                    data[pcount] = byte.Parse(dgv_datamap.Rows[row].Cells[col].Value.ToString(), System.Globalization.NumberStyles.HexNumber);
                    pcount++;
                    col = (col + 1 > dgv_datamap.ColumnCount - 1) ? 0 : col++;
                    if (col == 0)
                        row = (row + 1 > dgv_datamap.RowCount) ? row : row++;
                }
            }

            Invoke(UpdateDataMap, new string[] { null });
            int command_type = 0;
            switch (cb_command_type.Text)
            {
                case "READ_REGISTER":
                    command_type = 1;
                    Sdp_Handler.WriteCommand(command_type, addr_int, datacount);
                    break;
                case "WRITE_REGISTER":
                    command_type = 2;
                    Sdp_Handler.WriteCommand(command_type, addr_int, datacount, data);
                    break;
                case "WRITE_FILE":
                    command_type = 4;
                    int count = 0;
                    long preposition = 0;
                    byte[] Filedata = new byte[1024];
                    FileStream fileStream = new FileStream(tb_filepath.Text, FileMode.Open, FileAccess.Read);
                    Invoke(UpdateLog, "File Length : " + fileStream.Length, true); 
                    Invoke(UpdateProgressBar, 20);
                    Invoke(UpdateLog, "Start", true);
                    Sdp_Handler.WriteCommand(command_type, addr_int, Convert.ToInt32(fileStream.Length));
                    while (fileStream.Read(Filedata, 0, Filedata.Length) > 0)
                    {                        
                        if (fileStream.Position == fileStream.Length)
                        {
                            byte[] partdata = new byte[fileStream.Position - preposition];
                            Array.Copy(Filedata, partdata, partdata.Length);
                            Sdp_Handler.WriteData(partdata);
                            count += partdata.Length;
                        }
                        else
                        {
                            Sdp_Handler.WriteData(Filedata);
                            count += Filedata.Length;
                        }
                        Debug.WriteLine("Write Count : " + count);
                        preposition = fileStream.Position;
                    }
                    break;
                case "ERROR_STATUS":
                    command_type = 5;
                    Sdp_Handler.WriteCommand(command_type, 0, 0);
                    break;
                case "DCD_WRITE":
                    command_type = 10;
                    break;
                case "JUMP_ADDRESS":
                    command_type = 11;
                    Sdp_Handler.WriteCommand(command_type, addr_int, 0);
                    break;
                default:
                    MessageBox.Show("Please Select Command Type");
                    break;
            }

            Invoke(UpdateLog, "Command Process Done", true);
            btn_sent_SDP.Enabled = true;
            Invoke(UpdateProgressBar, 100);
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Write File Bin";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "bin files (*.*)|*.bin";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb_filepath.Text = dialog.FileName;
            }
        }

        private void btn_allinone_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Write File Bin";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "Bin files (*.bin)|*.bin | S19 files(*.s19) | *.s19";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb_allinone_path.Text = dialog.FileName;
            }
        }

        private void btn_CRC_Click(object sender, EventArgs e)
        {
            byte[] CRC32 = new byte[4];
            string command = tb_command.Text;
            char[] spliter = new char[] { ' ' };
            string[] subcommand = command.Split(spliter);
            byte[] subcommand_byte = new byte[subcommand.Length];
            for (int i = 0; i < subcommand_byte.Length; i++)
                subcommand_byte[i] = byte.Parse(subcommand[i], System.Globalization.NumberStyles.HexNumber);

            CRC.Crc CRC32_X = new CRC.Crc(CRC.CrcStdParams.StandartParameters[CRC.CrcAlgorithms.Crc32Mpeg2]);
            CRC32 = CRC32_X.ComputeHash(subcommand_byte);
            tb_crc_result.Text = BitConverter.ToString(CRC32, 0, 4).Replace("-", " ");
        }

        private void btn_BL_connet_Click(object sender, EventArgs e)
        {
            Bl_Handler = BL_Handler.Enumerate(0x15A2, new[] { 0x0073 }).FirstOrDefault();
            if (Bl_Handler != null)
            {
                Bl_Handler.LogUpdate += UpdateLogFromHandler;
                Bl_Handler.DataRecieved += PushReceiveData;
                Bl_Handler.Inserted += DeviceInserted;
                Bl_Handler.Removed += DeviceRemoved;
                Bl_Handler.StartListen();
            }
        }

        private void btn_BL_disconnect_Click(object sender, EventArgs e)
        {

        }

        private void btn_send_BL_Click(object sender, EventArgs e)
        {
            Viewer.UpadateDataMapInvoke UpdateDataMap = Data_Process;
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            Viewer.UpdateProgressBarCallback UpdateProgressBar = Assign_ProgressBar;
            Invoke(UpdateProgressBar, 0);
            int para_1 = Int32.Parse(tb_BL_para1.Text, System.Globalization.NumberStyles.HexNumber);

            int para_2 = Convert.ToInt32(tb_BL_para2.Text);
            byte[] data = new byte[para_2];
            int row = 0, col = 0, pcount = 0;

            if (cb_BL_command_type.Text == "FillMemory")
            {
                while (pcount < para_2 && dgv_datamap.Rows[row].Cells[col].Value != null)
                {

                    data[pcount] = byte.Parse(dgv_datamap.Rows[row].Cells[col].Value.ToString(), System.Globalization.NumberStyles.HexNumber);
                    pcount++;
                    col = (col + 1 > dgv_datamap.ColumnCount - 1) ? 0 : ++col;
                    if (col == 0)
                        row = (row + 1 > dgv_datamap.RowCount) ? row : ++row;
                }
            }

            Invoke(UpdateDataMap, new string[] { null });
            int command_type = 0;
            switch (cb_BL_command_type.Text)
            {
                case "FlashEraseRegion":
                    command_type = 2;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                case "ReadMemory":
                    command_type = 3;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                case "WriteMemory":
                    Invoke(UpdateProgressBar, 20);
                    command_type = 4;
                    int file_pointer = 0;
                    string file_path = tb_BL_filepath.Text;
                    char[] spliter = new char[] { '.' };
                    string[] subcommand = file_path.Split(spliter);
                    string file_posfix = subcommand[subcommand.Length - 1];
                    if (file_posfix == "s19")
                    {
                        SREC_file srec = new SREC_file(file_path);
                        byte[] HID_packet = new byte[1016];

                        int datapacket_count_perstep = (srec.ivt_boot_image.Data.Length / HID_packet.Length) / 80;

                        Bl_Handler.WriteCommand(command_type, para_1, Convert.ToInt32(srec.ivt_boot_image.Data.Length), true);

                        int count = 0;
                        while (file_pointer < srec.ivt_boot_image.Data.Length)
                        {
                            int data_len = ((srec.ivt_boot_image.Data.Length - file_pointer) > HID_packet.Length) ? HID_packet.Length : (srec.ivt_boot_image.Data.Length - file_pointer);
                            Array.Copy(srec.ivt_boot_image.Data, file_pointer, HID_packet, 0, data_len);
                            Debug.WriteLine("pointer : " + file_pointer + ", data len : " + data_len);
                            Bl_Handler.WriteData(HID_packet);
                            file_pointer += data_len;
                            count++;
                            if(count == datapacket_count_perstep)
                            {
                                count = 0;
                                Invoke(UpdateProgressBar, 1);
                            }
                        }
                    }
                    else if (file_posfix == "bin")
                    {
                        int count = 0;
                        long preposition = 0;
                        byte[] Filedata = new byte[1016];
                        FileStream fileStream = new FileStream(tb_BL_filepath.Text, FileMode.Open, FileAccess.Read);
                        Debug.WriteLine(fileStream.Length);
                        Bl_Handler.WriteCommand(command_type, para_1, Convert.ToInt32(fileStream.Length), true);
                        while (fileStream.Read(Filedata, 0, Filedata.Length) > 0)
                        {
                            Debug.WriteLine(fileStream.Position);
                            if (fileStream.Position == fileStream.Length)
                            {
                                byte[] partdata = new byte[fileStream.Position - preposition];
                                Array.Copy(Filedata, partdata, partdata.Length);
                                Bl_Handler.WriteData(partdata);
                                count += partdata.Length;
                            }
                            else
                            {
                                Bl_Handler.WriteData(Filedata);
                                count += Filedata.Length;
                            }
                            Debug.WriteLine("Write Count : " + count);
                            preposition = fileStream.Position;
                        }
                    }                     
                    break;
                case "FillMemory":
                    command_type = 5;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, data, false);
                    break;
                case "GetProperty":
                    command_type = 7;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                case "Reset":
                    command_type = 11;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                case "FlashReadOnce":
                    command_type = 15;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                case "ConfigureQuadSPI":
                    command_type = 17;
                    Bl_Handler.WriteCommand(command_type, para_1, para_2, false);
                    break;
                default:
                    break;
            }

            Invoke(UpdateLog, "Command Process Done", true);
            Invoke(UpdateProgressBar, 100);
        }

        private void btn_BL_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Write File Bin";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "Bin files (*.bin)|*.bin | S19 files(*.s19) | *.s19";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb_BL_filepath.Text = dialog.FileName;
            }
        }

        private void cb_BL_command_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_BL_command_type.Text)
            {
                case "FlashEraseRegion":
                    lb_BL_para1.Text = "Start Address :";
                    lb_BL_para2.Text = "Byte Count :";
                    break;
                case "ReadMemory":
                    lb_BL_para1.Text = "Start Address :";
                    lb_BL_para2.Text = "Byte Count :";
                    break;
                case "WriteMemory":
                    lb_BL_para1.Text = "Start Address :";
                    lb_BL_para2.Text = "Byte Count :";
                    break;
                case "FillMemory":
                    lb_BL_para1.Text = "Start Address :";
                    lb_BL_para2.Text = "Byte Count :";
                    //data
                    break;
                case "GetProperty":
                    lb_BL_para1.Text = "Property Tag :";
                    lb_BL_para2.Text = "Memory ID :";
                    break;
                case "FlashReadOnce":
                    lb_BL_para1.Text = "Index :";
                    lb_BL_para2.Text = "Byte Count :";
                    break;
                case "ConfigureQuadSPI":
                    lb_BL_para1.Text = "Memory ID :";
                    lb_BL_para2.Text = "Block Address :";
                    break;
                default:
                    break;
            }
        }

        public void InitialDvice(bool Update)
        {
            rt_log.Text += "Connecting Finger Print Device...\n";
            File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);

            //foreach (string CP in Viewer.fingerPrint.FilterVCP_GetVCPbyVidPid())
            //    if (Viewer.fingerPrint.ManualConnect(CP))
            //    {
            //        rt_log.Text += "Connecting Finger Print Device Success...\n";
            //        File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
            //        Viewer._Initial = true;
            //        break;
            //    }
            if (!Viewer.fingerPrint.IsConnected)
            {
                rt_log.Text += "Connecting Finger Print Device Failed...\n";
                File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                Viewer._Initial = false;
            }
            else
            {
                if (Update)
                {
                    rt_log.Text += "Loading...\n";
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                    Viewer.fingerPrint.FP_EnterFirmwareUpgradeMode();
                }
                else
                {
                    rt_log.Text += "Updated Success!!!\n";
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
            }
        }

        public void ReceiveDataFlag(byte[] datas)
        {
            wait_response_lock = false;
        }

        public void Check_Recipe()
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;

            Invoke(UpdateLog, new Object[] { "Start Upgrading FW... ", true });
            CommandList.RemoveRange(0, CommandList.Count);
            using (StreamReader update_flow = new StreamReader("Auto_Recipe.txt"))
            {
                string templine;
                byte[] rawbyte;
                while ((templine = update_flow.ReadLine()) != null)
                {
                    Command readin_command = new Command();
                    char[] spliter = { '\t' };
                    string[] data_split = templine.Split(spliter);
                    for (int i = 0; i < data_split.Length; i++)
                    {
                        rawbyte = System.Text.Encoding.Default.GetBytes(data_split[i]);
                        byte[] change_record = new byte[rawbyte.Length / 2];
                        for (int c = 0; c < rawbyte.Length; c++)
                        {
                            rawbyte[c] = Convert.ToByte((rawbyte[c] > 57) ? rawbyte[c] - 55 : rawbyte[c] - 48); ;
                        }
                        for (int c = 0; c < change_record.Length; c++)
                        {
                            change_record[c] = BitConverter.GetBytes(rawbyte[2 * c] * 16 + rawbyte[2 * c + 1])[0];
                        }

                        switch (i)
                        {
                            case 0:
                                readin_command.command_type = change_record;
                                break;
                            case 1:
                                for (int j = 0; j < change_record.Length; j++)
                                    readin_command.Para_1[j] = change_record[j];
                                break;
                            case 2:
                                for (int j = 0; j < change_record.Length; j++)
                                    readin_command.Para_2[j] = change_record[j];
                                break;
                        }
                    }
                    CommandList.Add(readin_command);
                }
                update_flow.Close();
            }
        }

        public void Setup_BootLoader()
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            int count = 0;
            byte[] Filedata = new byte[1024];
            ivt_BootLoader BL = new ivt_BootLoader();
            Sdp_Handler.WriteCommand(4, 539001344, Convert.ToInt32(BL.BootLoader.Length));
            while (count < BL.BootLoader.Length)
            {

                if (count + Filedata.Length > BL.BootLoader.Length)
                {
                    byte[] partdata = new byte[BL.BootLoader.Length - count];
                    Array.Copy(BL.BootLoader, count, partdata, 0, partdata.Length);
                    Sdp_Handler.WriteData(partdata);
                    count += partdata.Length;
                }
                else
                {
                    Array.Copy(BL.BootLoader, count, Filedata, 0, Filedata.Length);
                    Sdp_Handler.WriteData(Filedata);
                    count += Filedata.Length;
                }
            }

            Sdp_Handler.WriteCommand(11, 539001344, 0);
            System.Threading.Thread.Sleep(1000);
            Invoke(UpdateLog, new Object[] { "Recovery Success, Reinitializing FW Upgrade Menager...", true });
        }

        public byte[] Load_Image(string args)
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            //Image//
            string file_path = args;
            byte[] Image_data = new byte[0];
            char[] File_spliter = new char[] { '.' };
            string[] subcommand = file_path.Split(File_spliter);
            string file_posfix = subcommand[subcommand.Length - 1];
            if (file_posfix == "s19")
            {
                SREC_file srec = new SREC_file(file_path);
                Image_data = srec.ivt_boot_image.Data;
                File_Support = true;
            }
            else if (file_posfix == "bin")
            {
                FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                Image_data = new byte[fileStream.Length];
                fileStream.Read(Image_data, 0, Image_data.Length);
                File_Support = true;
            }
            else
            {
                Invoke(UpdateLog, new Object[] { "File Format Doesn't Supported Now...", true });
                File_Support = false;
            }
            return Image_data;
        }

        public void Do_Command(byte[] Image_data)
        {
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;
            byte[] image_Len = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
            image_Len = BitConverter.GetBytes(Image_data.Length);
            Array.Reverse(image_Len);
            byte[] Erase_Len = new byte[4];
            Array.Copy(image_Len, Erase_Len, image_Len.Length);
            Erase_Len[3] = 0x00;
            Erase_Len[2] = BitConverter.GetBytes((((Erase_Len[2] / 16) + 2) * 16))[0];

            /////Load in Progress Done/////
            Invoke(UpdateLog, new Object[] { "Load in Image Progress Done", true });
            Invoke(UpdateLog, new Object[] { "Processing..., Please Waiting...", false });
            foreach (Command active_command in CommandList)
            {
                //Invoke(UpdateLog, new Object[] { "...", false });
                
                switch (BitConverter.ToString(active_command.command_type, 0))
                {
                    case "02":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, Erase_Len, false);
                        wait_response_lock = true;
                        break;
                    case "03":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    case "04":
                        int file_pointer = 0;
                        byte[] HID_packet = new byte[1016];
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, image_Len, true);
                        wait_response_lock = true;
                        while (file_pointer < Image_data.Length)
                        {
                            int data_len = ((Image_data.Length - file_pointer) > HID_packet.Length) ? HID_packet.Length : (Image_data.Length - file_pointer);
                            Array.Copy(Image_data, file_pointer, HID_packet, 0, data_len);
                            Bl_Handler.WriteData(HID_packet);
                            file_pointer += data_len;
                        }
                        wait_response_lock = true;
                        break;
                    case "05":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2.Length, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    case "07":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    case "0B":

                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    case "0F":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    case "11":
                        Bl_Handler.WriteCommand(active_command.command_type, active_command.Para_1, active_command.Para_2, false);
                        wait_response_lock = true;
                        break;
                    default:
                        break;
                }
            }
            Invoke(UpdateLog, new Object[] { " ", true });
        }

        private void btn_onekeyupdate_Click(object sender, EventArgs e)
        {
            btn_onekeyupdate.Enabled = false;
            bool BL_connect = false;
            Viewer.UpdateProgressBarCallback UpdateProgressBar = Assign_ProgressBar;
            Viewer.UpadateLogInvoke UpdateLog = LogUpdate;

            if (Viewer.fingerPrint == null)
            {
                Viewer.fingerPrint = new FingerPrint_API.FingerPrint();
                Viewer.fingerPrint.AutoConnect_Interval = 5000;
            }
            if (!Viewer.fingerPrint.IsConnected)
            {
                InitialDvice(true);
            }            
            bool force_try = false;
            if (!Viewer._Initial)
            {
                DialogResult dr = MessageBox.Show("Can't Find Appropriate Device, Try Recovery?", "Connect Failed", MessageBoxButtons.YesNo);
                
                force_try = (dr == DialogResult.Yes) ? true : false;
            }

            if (Viewer._Initial || force_try)
            {
                int BLtry_count = 0;
                Invoke(UpdateLog, new Object[] { "Initializing FW Update Menager...", true });
                Invoke(UpdateLog, new Object[] { "Please Waiting...", false });
                while (Bl_Handler == null && BLtry_count < 5)
                {
                    Invoke(UpdateLog, new Object[] { "...", false });
                    System.Threading.Thread.Sleep(1000);
                    Bl_Handler = BL_Handler.Enumerate(0x15A2, new[] { 0x0073 }).FirstOrDefault();
                    BLtry_count++;
                }
                Invoke(UpdateLog, new Object[] { " ", true });
                if (Bl_Handler != null)
                {

                    Bl_Handler.LogUpdate += UpdateLogFromHandler;
                    Bl_Handler.DataRecieved += ReceiveDataFlag;
                    Bl_Handler.StartListen();
                    BL_connect = true;
                    Invoke(UpdateLog, new Object[] { "Initializing FW Update Menager Success...", true });
                }
                else
                {
                    Invoke(UpdateLog, new Object[] { "Initializing Failed, Recovery Function Start...", true });

                    Sdp_Handler = SDP_Handler.Enumerate(0x1FC9, new[] { 0x0130 }).FirstOrDefault();
                    if (Sdp_Handler != null)
                    {
                        Sdp_Handler.DataRecieved += ReceiveDataFlag;
                        Sdp_Handler.StartListen();

                        Setup_BootLoader();
                    }
                    else
                        Invoke(UpdateLog, new Object[] { "Recovery Failed, Terminated...", true });
                }

                System.Threading.Thread.Sleep(3000);
                // Reconnect
                if (!BL_connect)
                {
                    Bl_Handler = BL_Handler.Enumerate(0x15A2, new[] { 0x0073 }).FirstOrDefault();
                    if (Bl_Handler != null)
                    {
                        Bl_Handler.LogUpdate += UpdateLogFromHandler;
                        Bl_Handler.DataRecieved += ReceiveDataFlag;
                        Bl_Handler.StartListen();
                        BL_connect = true;
                        Invoke(UpdateLog, new Object[] { "Initializing FW Update Menager Success...", true });                        
                    }
                    else
                    {
                        Invoke(UpdateLog, new Object[] { "Initializing FW Upgrade Menager Fail... Terminated", true });                        
                    }
                }

                if (BL_connect)
                {
                    string ImageFilePath = tb_allinone_path.Text;
                    //Check Recipe//
                    if (!File.Exists("Auto_Recipe.txt"))
                        Invoke(UpdateLog, new Object[] { "Recipe Loss, Please Contact For Support", true });
                    else
                    {
                        Check_Recipe();
                        byte[] Image_data = Load_Image(ImageFilePath);
                        if (File_Support)
                        {
                            Do_Command(Image_data);
                        }
                        Invoke(UpdateLog, new Object[] { "Process Done", true });
                    }
                }
                if (File_Support)
                {
                    Viewer._Initial = false;
                    int try_count = 0;
                    Viewer.fingerPrint.Dispose();
                    Viewer.fingerPrint = new FingerPrint_API.FingerPrint();
                    rt_log.Text += "Verificating...\n";
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                    while (!Viewer._Initial && try_count < 3)
                    {
                        try_count++;
                        System.Threading.Thread.Sleep(3000);
                        InitialDvice(false);
                    }
                    if (!Viewer._Initial)
                        Invoke(UpdateLog, new Object[] { "Updated Failed Please Check Your Image File And Restart Upgrade Program", true });
                    
                }
            }
            btn_onekeyupdate.Enabled = true;
        }

        
    }

    public class Command
    {
        public byte[] command_type = new byte[1] { 0x00 };
        public byte[] Para_1 = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
        public byte[] Para_2 = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
    }
}
