using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GeneralProtocol.ComportHandle;
using System.IO;

namespace FPD
{
    public partial class Form_ROIC : Form
    {
        List<Command> CommandList;
        int pre_PN = 0;
        int current_PN = 0;
        bool cb_lock = false;

        public Form_ROIC()
        {
            InitializeComponent();
            CommandList = new List<Command>();
            //rt_script.AppendText("W	2100  05\nW	2101  00\nW	2102  03\nW	2103  E8\nW	2104  00\nW	2105  0F\nW	2106  00\nW	2107  00\nW	2108  00\nW	2109  0F\nW	210A  07\nW	210B  94\nW	210C  00\nW	210D  00\nW	210E  00\nW	210F  00\nW	2110  00\nW	2111  00\nW	2112  00\nW	2113  00\nW	2114  00\nW	2115  00\nW	2116  00\nW	2117  00\nW	2118  00\nW	2119  00\nW	211A  00\nW	211B  00\nW	211C  00\nW	211D  69\nW	211E  01\nW	211F  28\nW	2120  02\nW	2121  46\nW	2122  01\nW	2123  30\nW	2124  04\nW	2125  32\nW	2126  01\nW	2127  30\nW	2128  06\nW	2129  20\nW	212A  01\nW	212B  30");
            dgv_seq_data.RowHeadersWidth = 100;
            Fill_the_Rule();
        }

        class Command
        {
            public string RW;
            public ushort data_addr;
            public byte[] data;
            public ushort len;

            public Command() { }

            public Command(string command_str)
            {
                char[] spliter = new char[] { ' ', '\t', ',' };
                string[] sub_str = command_str.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
                if (sub_str.Length > 2)
                {
                    RW = sub_str[0];
                    data_addr = (ushort)int.Parse(sub_str[1], System.Globalization.NumberStyles.HexNumber);
                    if (RW == "W")
                    {
                        len = (ushort)(sub_str.Length - 2);
                        data = new byte[len];
                        for(int i = 0; i < data.Length; i++)
                        {
                            data[i] = byte.Parse(sub_str[i + 2], System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                    else
                    {
                        len = Convert.ToUInt16(sub_str[2]);
                    }
                }
                else if (sub_str.Length == 2)
                {
                    RW = sub_str[0];
                    data_addr = (ushort)int.Parse(sub_str[1], System.Globalization.NumberStyles.HexNumber);
                    if (RW == "R")
                    {
                        len = 1;
                    }
                }
            }
        }

        private void Fill_the_Rule()
        {
            rt_rule.AppendText("Tool Version : " + Application.ProductVersion + Environment.NewLine);
            rt_rule.AppendText("-------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
            rt_rule.AppendText("Script Design Rule : " + Environment.NewLine);
            rt_rule.AppendText("Notice: Following parameter in Hex all unneeded \"0x\"" + Environment.NewLine);
            rt_rule.AppendText("Notice: To separate three parameter, can use\'\\t\' or blank or tab" + Environment.NewLine);
            rt_rule.AppendText("  1. Byte Write :" + Environment.NewLine);
            rt_rule.AppendText("\t (Command Flag)\t(Memory Address in Hex)\t(Data in Hex)" + Environment.NewLine);
            rt_rule.AppendText("    EX :" + Environment.NewLine);
            rt_rule.AppendText("\t     W\t2100\tF0" + Environment.NewLine);
            rt_rule.AppendText("  2. Byte Read : " + Environment.NewLine);
            rt_rule.AppendText("\t (Command Flag)\t(Memory Address in Hex)" + Environment.NewLine);
            rt_rule.AppendText("    EX :" + Environment.NewLine);
            rt_rule.AppendText("\t      R\t2100" + Environment.NewLine);
        }

        public void LogUpdatewColor(string log, bool line, Color color)
        {
            if (color != null)
                rt_log.SelectionColor = color;
            else
                rt_log.SelectionColor = Color.Black;

            if (line)
            {
                rt_log.Text += log + "\n";
                try
                {
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
                catch (Exception) { }
            }
            else
            {
                rt_log.Text += log + " ";
                try
                {
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
                catch (Exception) { }
            }

            rt_log.Select(rt_log.Text.Length - 1, 0);
            rt_log.ScrollToCaret();
        }

        private byte[] extract_byte(string in_str)
        {
            int len = in_str.Length;
            byte[] Byte_Data = new byte[len / 2 + len % 2];
            for (int i = 0; i < Byte_Data.Length; i++)
            {
                if (len % 2 == 1)
                {
                    if (i == 0)
                    {
                        Byte_Data[i] = byte.Parse(in_str.Substring(0, 1), System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        Byte_Data[i] = byte.Parse(in_str.Substring(i * 2 - 1, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
                else
                {
                    Byte_Data[i] = byte.Parse(in_str.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }
            }

            return Byte_Data;
        }

        public UInt16 Hex2Dec(string Hex)
        {
            int Dec = 0;
            Dec = int.Parse(Hex, System.Globalization.NumberStyles.HexNumber);
            return Convert.ToUInt16(Dec);
        }

        private string Dec2Hex(int dec)
        {
            string Hex = "";
            Hex = dec.ToString("X2");
            return Hex;
        }

        private string Dec2Bin(int dec)
        {
            string Bin = "";
            Bin = Convert.ToString(dec, 2);
            return Bin;
        }

        private int Bin2Dec(string Bin)
        {
            int Dec = 0;
            Dec = Convert.ToInt32(Bin, 2);
            return Dec;
        }

        private bool Byte_write(UInt16 Data_addr, byte Data)
        {
            Viewer.UpadateLogColorInvoke UpdateLog = LogUpdatewColor;

            byte Dev_addr = byte.Parse("49", System.Globalization.NumberStyles.HexNumber);
            byte Dev_Ack;
            byte[] Data_pac = new byte[1] {Data};
            ErrorCode ret = Viewer.fingerPrint.FP_I2CWrite(Dev_addr, Data_addr, 1, Data_pac, out Dev_Ack);

            if (ret != ErrorCode.FP_STATUS_OK) UpdateLog("[E] FP_I2CWrite - ErrorCode = " + ret.ToString(), true, Color.Red);
            else if(Dev_Ack == 0 || Dev_Ack == 81) UpdateLog("[S] FP_I2CWrite - DeviceACK = " + Dev_Ack.ToString(), true, Color.Red);
            else UpdateLog("I2C Write : " + Dec2Hex(Data_addr) + ", Value : " + Data + " Success!", true, Color.Red);

            return ret == ErrorCode.FP_STATUS_OK && Dev_Ack == 1;
        }

        private byte Byte_read(UInt16 Data_addr)
        {
            Viewer.UpadateLogColorInvoke UpdateLog = LogUpdatewColor;

            byte Dev_addr = byte.Parse("49", System.Globalization.NumberStyles.HexNumber);
            byte Dev_Ack;
            byte[] Data_pac;
            ErrorCode ret = Viewer.fingerPrint.FP_I2CRead(Dev_addr, Data_addr, 1, out Dev_Ack, out Data_pac);
            if (ret != ErrorCode.FP_STATUS_OK) UpdateLog("[E] FP_I2CRead - ErrorCode = " + ret.ToString(), true, Color.Red);
            else if (Dev_Ack == 0) UpdateLog("[E] FP_I2CRead - DeviceACK = " + Dev_Ack.ToString(), true, Color.Red);
            else UpdateLog("I2C Read : " + Dec2Hex(Data_addr) + " Success!", true, Color.Green);

            return Data_pac[0];
        }

        private bool Seq_write(UInt16 Data_addr, ushort len, byte[] Data)
        {
            Viewer.UpadateLogColorInvoke UpdateLog = LogUpdatewColor;

            byte Dev_addr = byte.Parse("49", System.Globalization.NumberStyles.HexNumber);
            byte Dev_Ack;
            ErrorCode ret = Viewer.fingerPrint.FP_I2CWrite(Dev_addr, Data_addr, len, Data, out Dev_Ack);

            if (ret != ErrorCode.FP_STATUS_OK) UpdateLog("[E] FP_I2CWrite - ErrorCode = " + ret.ToString(), true, Color.Red);
            else if (Dev_Ack == 0 || Dev_Ack == 81) UpdateLog("[S] FP_I2CWrite - DeviceACK = " + Dev_Ack.ToString(), true, Color.Red);
            else
            {
                UpdateLog("I2C SWrite : " + Dec2Hex(Data_addr) + ", Len : " + len + " Success!", true, Color.Red);
                if (cb_detail_log.Checked)
                {
                    UpdateLog("[Detail] Value :", false, Color.Black);
                    for (int i = 0; i < Data.Length; i++)
                    {
                        UpdateLog(Data[i].ToString("X2"), false, Color.Black);
                    }
                    UpdateLog("", true, Color.Black);
                }
            }

            return ret == ErrorCode.FP_STATUS_OK && Dev_Ack == 1;
        }

        private byte[] Seq_read(UInt16 Data_addr, ushort len)
        {
            Viewer.UpadateLogColorInvoke UpdateLog = LogUpdatewColor;

            byte Dev_addr = byte.Parse("49", System.Globalization.NumberStyles.HexNumber);
            byte Dev_Ack;
            byte[] Data_pac;
            ErrorCode ret = Viewer.fingerPrint.FP_I2CRead(Dev_addr, Data_addr, len, out Dev_Ack, out Data_pac);
            if (ret != ErrorCode.FP_STATUS_OK) UpdateLog("[E] FP_I2CRead - ErrorCode = " + ret.ToString(), true, Color.Red);
            else if (Dev_Ack == 0) UpdateLog("[E] FP_I2CRead - DeviceACK = " + Dev_Ack.ToString(), true, Color.Red);
            else
            {
                UpdateLog("I2C SRead : " + Dec2Hex(Data_addr) + " Success!", true, Color.Green);
                if (cb_detail_log.Checked)
                {
                    UpdateLog("[Detail] Value :", false, Color.Black);
                    for (int i = 0; i < Data_pac.Length; i++)
                    {
                        UpdateLog(Data_pac[i].ToString(), false, Color.Black);
                    }
                    UpdateLog("", true, Color.Black);
                }
            }

            return Data_pac;
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            string addr = tb_address.Text;
            string value = tb_wvalue.Text;
            UInt16 uint_addr = 0;
            byte[] byte_data = null;

            if (rb_hex.Checked)
            {
                uint_addr = Hex2Dec(addr);
                byte_data = extract_byte(value);
            }
            else if (rb_bin.Checked)
            {
                uint_addr = Convert.ToUInt16(Bin2Dec(addr));
                byte_data = extract_byte(Dec2Hex(Bin2Dec(value)));
            }
            else
            {
                uint_addr = Convert.ToUInt16(addr);
                byte_data = extract_byte(Dec2Hex(Convert.ToInt32(value)));
            }

            
            bool ack;
            if (byte_data.Length == 1)
            {
                ack = Byte_write(uint_addr, byte_data[0]);
            }
            else
            {
                rt_log.AppendText("Value over Byte, Write Failed...");
                try
                {
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
                catch (Exception) { }
            }
            
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            string addr = tb_address.Text;
            UInt16 uint_addr = Hex2Dec(addr);
            byte Readout_Data;

            if (rb_hex.Checked)
            {
                uint_addr = Hex2Dec(addr);
            }
            else if (rb_bin.Checked)
            {
                uint_addr = Convert.ToUInt16(Bin2Dec(addr));
            }
            else
            {
                uint_addr = Convert.ToUInt16(addr);
            }

            Readout_Data = Byte_read(uint_addr);

            if (rb_hex.Checked)
            {
                tb_rvalue.Text = Dec2Hex( Convert.ToInt32(Readout_Data));
            }
            else if (rb_bin.Checked)
            {
                tb_rvalue.Text = Dec2Bin(Convert.ToInt32(Readout_Data));
            }
            else
            {
                tb_rvalue.Text = Convert.ToInt32(Readout_Data).ToString();
            }
        }

        private void btn_seq_read_Click(object sender, EventArgs e)
        {
            string addr = tb_seq_addr.Text;
            string len = tb_seq_len.Text;
            UInt16 uint_addr = Hex2Dec(addr);
            UInt16 ulen = (ushort)int.Parse(len);
            byte[] Readout_Data;

            if (rb_hex.Checked)
            {
                uint_addr = Hex2Dec(addr);
            }
            else if (rb_bin.Checked)
            {
                uint_addr = Convert.ToUInt16(Bin2Dec(addr));
            }
            else
            {
                uint_addr = Convert.ToUInt16(addr);
            }
            if(ulen != 0)
            {
                Readout_Data = Seq_read(uint_addr, ulen);
                Dgv_data_update(uint_addr, Readout_Data);
            }
            else
            {
                rt_log.AppendText("Resd len should not be 0");
                try
                {
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
                catch (Exception) { }
            }
        }

        private void btn_seq_write_Click(object sender, EventArgs e)
        {
            string addr = tb_seq_addr.Text;
            string len = tb_seq_len.Text;
            UInt16 uint_addr = Hex2Dec(addr);
            UInt16 ulen = (ushort)int.Parse(len);
            byte[] Write_Data;
            Write_Data = new byte[ulen];
            
            if (rb_hex.Checked)
            {
                uint_addr = Hex2Dec(addr);
            }
            else if (rb_bin.Checked)
            {
                uint_addr = Convert.ToUInt16(Bin2Dec(addr));
            }
            else
            {
                uint_addr = Convert.ToUInt16(addr);
            }
            if (ulen != 0)
            {
                Arrange_Dgv_data(uint_addr, ulen, out Write_Data);
                Seq_write(uint_addr, ulen, Write_Data);
            }
            else
            {
                rt_log.AppendText("Write len should not be 0");
                try
                {
                    File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                }
                catch (Exception) { }
            }
        }

        public static String byte2string(byte pf)
        {
            return pf.ToString("X2");
        }
        public static byte str2byte(string pf)
        {
            return byte.Parse(pf, System.Globalization.NumberStyles.HexNumber);
        }
        private void Arrange_Dgv_data(int start_addr, int len, out byte[] Data)
        {
            int redundent = (len) % 16;
            int total_rowcount = len / 16 + ((redundent != 0) ? 1 : 0);
            int data_pointer = 0;
            Data = new byte[len];
            String[] Data_instr = new string[len];

            for (int row_count = 0; row_count < total_rowcount; row_count++)
            {
                if (row_count == total_rowcount - 1 && redundent != 0)
                {
                    for (int c_count = 0; c_count < redundent; c_count++)
                    {
                        Data_instr[data_pointer] = dgv_seq_data.Rows[row_count].Cells[c_count].Value.ToString();
                        data_pointer++;
                    }
                }
                else
                {
                    for(int c_count = 0; c_count < dgv_seq_data.Rows[row_count].Cells.Count; c_count++)
                    {
                        Data_instr[data_pointer] = dgv_seq_data.Rows[row_count].Cells[c_count].Value.ToString();
                        data_pointer++;
                    }
                }
                dgv_seq_data.Rows[row_count].HeaderCell.Value = (start_addr + row_count * 16).ToString("X");
            }
            Data = Array.ConvertAll(Data_instr, new Converter<String, byte>(str2byte));
        }

        private void Dgv_data_update(int start_addr, byte[] Data)
        {
            Dgv_clear(dgv_seq_data);
            String[] Data_instr = Array.ConvertAll(Data, new Converter<byte, String>(byte2string));
            int redundent = (Data_instr.Length) % 16;
            int total_rowcount = (Data_instr.Length) / 16 + ((redundent != 0) ? 1 : 0);
            int data_pointer = 0;
            for (int row_count = 0; row_count < total_rowcount; row_count++)
            {
                string[] row_temp = new string[dgv_seq_data.Columns.Count];
                if (row_count == total_rowcount - 1 && redundent != 0)
                {
                    Array.Copy(Data_instr, data_pointer, row_temp, 0, redundent);
                    data_pointer += redundent;
                }
                else
                {
                    Array.Copy(Data_instr, data_pointer, row_temp, 0, dgv_seq_data.Columns.Count);
                    data_pointer += dgv_seq_data.Columns.Count;
                }

                dgv_seq_data.Rows.Add(row_temp);
                dgv_seq_data.Rows[row_count].HeaderCell.Value = (start_addr + row_count*16).ToString("X");
            }            
        }

        private void Dgv_clear(DataGridView dgv)
        {
            int remove_count = dgv.Rows.Count-1;
            for (int i = 0; i < remove_count; i++)
            {
                dgv.Rows.RemoveAt(0);
            }
        }
      
        private void dgv_seq_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = dgv_seq_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(value.Length > 2)
                dgv_seq_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value.Substring(0, 2);
            else if (value.Length < 2)
                dgv_seq_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Dec2Hex(Hex2Dec(value));
        }

        private void btn_script_start_Click(object sender, EventArgs e)
        {
            int delay = int.Parse(tb_command_delay.Text);
            string[] script = rt_script.Lines;
            for(int i = 0; i < script.Length; i++)
            {
                CommandList.Add(new Command(script[i]));
            }
            for(int i = 0; i < CommandList.Count; i++)
            {
                switch (CommandList[i].RW)
                {
                    case "W":
                        Seq_write(CommandList[i].data_addr, CommandList[i].len, CommandList[i].data);
                        break;
                    case "R":
                        Seq_read(CommandList[i].data_addr, CommandList[i].len);
                        break;
                    default:
                        break;
                }
                System.Threading.Thread.Sleep(delay);
            }
            CommandList.Clear();
        }

        private void btn_script_load_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    rt_script.Clear();
                    rt_script.AppendText(fileContent);
                }
            }
        }

        private void btn_script_save_Click(object sender, EventArgs e)
        {
            string[] script = rt_script.Lines;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(saveFileDialog1.FileName);
                System.IO.File.WriteAllLines(path, script);
                MessageBox.Show("Save Done At :" + path);
            }
            else
            {
                MessageBox.Show("Save Stop");
            }
        }

        private void btn_script_clear_Click(object sender, EventArgs e)
        {
            rt_script.Clear();
        }

        private void PN_Change(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked == false)
            {
                string PN = ((RadioButton)sender).Text;
                pre_PN = (PN == "Hex") ? 16 : (PN == "Dec") ? 10 : 2;
            }
            else
            {
                string PN = ((RadioButton)sender).Text;
                current_PN = (PN == "Hex") ? 16 : (PN == "Dec") ? 10 : 2;

                switch (pre_PN)
                {
                    case 16:
                        if(current_PN == 10)
                        {
                            tb_address.Text = Hex2Dec(tb_address.Text).ToString();
                            tb_seq_addr.Text = Hex2Dec(tb_seq_addr.Text).ToString();
                            tb_rvalue.Text = Hex2Dec(tb_rvalue.Text).ToString();
                            tb_wvalue.Text = Hex2Dec(tb_wvalue.Text).ToString();
                        }
                        else
                        {
                            tb_address.Text = Dec2Bin(Hex2Dec(tb_address.Text));
                            tb_seq_addr.Text = Dec2Bin(Hex2Dec(tb_seq_addr.Text));
                            tb_rvalue.Text = Dec2Bin(Hex2Dec(tb_rvalue.Text));
                            tb_wvalue.Text = Dec2Bin(Hex2Dec(tb_wvalue.Text));
                        }
                        break;
                    case 10:
                        if (current_PN == 16)
                        {
                            tb_address.Text = Dec2Hex(int.Parse(tb_address.Text));
                            tb_seq_addr.Text = Dec2Hex(int.Parse(tb_seq_addr.Text));
                            tb_rvalue.Text = Dec2Hex(int.Parse(tb_rvalue.Text));
                            tb_wvalue.Text = Dec2Hex(int.Parse(tb_wvalue.Text));
                        }
                        else
                        {
                            tb_address.Text = Dec2Bin(int.Parse(tb_address.Text));
                            tb_seq_addr.Text = Dec2Bin(int.Parse(tb_seq_addr.Text));
                            tb_rvalue.Text = Dec2Bin(int.Parse(tb_rvalue.Text));
                            tb_wvalue.Text = Dec2Bin(int.Parse(tb_wvalue.Text));
                        }
                        break;
                    case 2:
                        if (current_PN == 16)
                        {
                            tb_address.Text = Dec2Hex(Bin2Dec(tb_address.Text));
                            tb_seq_addr.Text = Dec2Hex(Bin2Dec(tb_seq_addr.Text));
                            tb_rvalue.Text = Dec2Hex(Bin2Dec(tb_rvalue.Text));
                            tb_wvalue.Text = Dec2Hex(Bin2Dec(tb_wvalue.Text));
                        }
                        else
                        {
                            tb_address.Text = Bin2Dec(tb_address.Text).ToString();
                            tb_seq_addr.Text = Bin2Dec(tb_seq_addr.Text).ToString();
                            tb_rvalue.Text = Bin2Dec(tb_rvalue.Text).ToString();
                            tb_wvalue.Text = Bin2Dec(tb_wvalue.Text).ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void dgv_seq_data_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string selected_value = dgv_seq_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string selected_addr = Dec2Hex(Hex2Dec(dgv_seq_data.Rows[e.RowIndex].HeaderCell.Value.ToString()) + e.ColumnIndex);
                Byte_op_change(selected_addr, Dec2Bin(Hex2Dec(selected_value)).PadLeft(8, '0'));
            }
            catch(Exception ex){
                gb_Byte_detail.Enabled = false;
            }
        }

        private void Byte_op_change(string addr, string bin_value)
        {
            gb_Byte_detail.Enabled = true;

            cb_byte_0.Text = addr + "[0]";
            cb_byte_1.Text = addr + "[1]";
            cb_byte_2.Text = addr + "[2]";
            cb_byte_3.Text = addr + "[3]";
            cb_byte_4.Text = addr + "[4]";
            cb_byte_5.Text = addr + "[5]";
            cb_byte_6.Text = addr + "[6]";
            cb_byte_7.Text = addr + "[7]";

            cb_lock = true;
            cb_byte_0.Checked = (bin_value[7] == 49); //'49' = 1
            cb_byte_1.Checked = (bin_value[6] == 49);
            cb_byte_2.Checked = (bin_value[5] == 49);
            cb_byte_3.Checked = (bin_value[4] == 49);
            cb_byte_4.Checked = (bin_value[3] == 49);
            cb_byte_5.Checked = (bin_value[2] == 49);
            cb_byte_6.Checked = (bin_value[1] == 49);
            cb_byte_7.Checked = (bin_value[0] == 49);
            cb_lock = false;
        }

        private void Byte_op_checkchange(object sender, EventArgs e)
        {
            if (!cb_lock)
            {
                string bin_value = "";
                bin_value += (cb_byte_7.Checked)? "1" : "0";
                bin_value += (cb_byte_6.Checked)? "1" : "0";
                bin_value += (cb_byte_5.Checked)? "1" : "0";
                bin_value += (cb_byte_4.Checked)? "1" : "0";
                bin_value += (cb_byte_3.Checked)? "1" : "0";
                bin_value += (cb_byte_2.Checked)? "1" : "0";
                bin_value += (cb_byte_1.Checked)? "1" : "0";
                bin_value += (cb_byte_0.Checked)? "1" : "0";
                dgv_seq_data.SelectedCells[0].Value = Dec2Hex(Bin2Dec(bin_value));
                try
                {
                    string addr = dgv_seq_data.Rows[dgv_seq_data.SelectedCells[0].RowIndex].HeaderCell.Value.ToString();
                    string offset = dgv_seq_data.SelectedCells[0].ColumnIndex.ToString();
                    ushort u_offset = (ushort)int.Parse(offset);
                    Byte_write((ushort)(Hex2Dec(addr) + u_offset), byte.Parse(dgv_seq_data.SelectedCells[0].Value.ToString(), System.Globalization.NumberStyles.HexNumber));
                }
                catch (Exception ex)
                {
                    rt_log.AppendText("Addr. Value Transformate Error, Write Abort" + Environment.NewLine);
                    try
                    {
                        File.WriteAllLines(Viewer.PathofLogfileName, rt_log.Lines, Encoding.Default);
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}
