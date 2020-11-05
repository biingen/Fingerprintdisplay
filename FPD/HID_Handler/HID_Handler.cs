using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using System.Threading;
using System.Diagnostics;

namespace HID_Handler
{
    public abstract class HID_Handler : IDisposable
    {
        public abstract void BeginReadReport();

        public abstract void ReadReport(HidReport report);

        public abstract void OnReport(HidReport report);
        
        public abstract void WriteData(byte[] data);

        public abstract void Dispose();
    }

    public class SDP_Handler : HID_Handler
    {

        public event InsertedEventHandler Inserted;
        public event RemovedEventHandler Removed;
        public event DataRecievedEventHandler DataRecieved;

        public delegate void InsertedEventHandler();
        public delegate void RemovedEventHandler();
        public delegate void DataRecievedEventHandler(byte[] data);

        private readonly HidDevice _hid_handler;
        private int _isReading;

        public SDP_Handler(string devicePath) : this(HidDevices.GetDevice(devicePath)) { }

        public SDP_Handler(HidDevice hidDevice)
        {
            _hid_handler = hidDevice;

            _hid_handler.Inserted += DeviceInserted;
            _hid_handler.Removed += DeviceRemoved;

            if (!_hid_handler.IsOpen) _hid_handler.OpenDevice();
            _hid_handler.MonitorDeviceEvents = true;

            BeginReadReport();
        }

        public string DevicePath { get { return _hid_handler.DevicePath; } }
        public bool IsListening { get; private set; }
        public bool IsConnected { get { return _hid_handler.IsConnected; } }

        public static IEnumerable<SDP_Handler> Enumerate(int Vid, int[] productIds)
        {
            return HidDevices.Enumerate(Vid, productIds).Select(x => new SDP_Handler(x));
        }

        public void StartListen() { IsListening = true; }
        public void StopListen() { IsListening = false; }

        public override void BeginReadReport()
        {
            if (Interlocked.CompareExchange(ref _isReading, 1, 0) == 1) return;
            _hid_handler.ReadReport(ReadReport, 0);
        }

        public override void ReadReport(HidReport report)
        {
            var ReadReport = new SDP_Report(report);
            var data = new byte[] { };

            if (ReadReport.ReadStatus == HidDeviceData.ReadStatus.Success)
            {

                Debug.WriteLine("Report ID : " + ReadReport.ReportId);
                if (!ReadReport.Exists || ReadReport.ReportId == 3)
                    Debug.WriteLine("Port Status : " + ((ReadReport.PortStatus) ? "Open" : "Close"));
                else if (ReadReport.ReportId == 4)
                {
                    if (ReadReport.Data != null)
                    {
                        Array.Resize(ref data, data.GetUpperBound(0) + ReadReport.Data.Length + 1);
                        Array.Copy(ReadReport.Data, 0, data, 0, ReadReport.Data.Length);
                    }
                    else
                    {
                        if (ReadReport.FileWriteComplete == true)
                            Debug.WriteLine("Write File Compelte");
                        else
                        {
                            if (ReadReport.WriteSuccess)
                                Debug.WriteLine("Write Success");
                            else
                                Debug.WriteLine("Invalid Write");
                        }
                    }
                }
                else
                {
                    return;
                }
                Debug.WriteLine("Packetage Received");
                if (IsListening && data.Length > 0 && DataRecieved != null) DataRecieved(data);
            }
            if (ReadReport.ReadStatus != HidDeviceData.ReadStatus.NotConnected) _hid_handler.ReadReport(this.ReadReport);
            else _isReading = 0;
        }

        public override void OnReport(HidReport report)
        {
            if (IsListening == false) { return; }

            System.Diagnostics.Debug.Write("Received raw data: ");
            for (int i = 0; i < report.Data.Length; i++)
            {
                System.Diagnostics.Debug.Write(String.Format("{0:000} ", report.Data[i]));
            }
            System.Diagnostics.Debug.WriteLine("");

            _hid_handler.ReadReport(OnReport);
        }

        private void DeviceInserted()
        {
            BeginReadReport();
            if (Inserted != null) Inserted();
        }

        private void DeviceRemoved()
        {
            if (Removed != null) Removed();
        }

        public override void Dispose()
        {
            _hid_handler.CloseDevice();
            GC.SuppressFinalize(this);
        }

        ~SDP_Handler()
        {
            Dispose();
        }

        public void WriteCommand(int Command_type, int addr_in, int datacount, byte[] data)
        {
            byte[] CommandBuffer = new byte[17];
            byte[] count = new byte[4];
            byte[] addr = new byte[4];
            for (int i = 3; i > -1; i--)
            {
                count[i] = Convert.ToByte(datacount % 256);
                datacount = datacount / 256;
            }
            for (int i = 3; i > -1; i--)
            {
                addr[i] = Convert.ToByte(addr_in % 256);
                addr_in = addr_in / 256;
            }
            CommandBuffer[0] = 0x01;
            CommandBuffer[1] = Convert.ToByte(Command_type);
            CommandBuffer[2] = Convert.ToByte(Command_type);
            CommandBuffer[3] = addr[0];
            CommandBuffer[4] = addr[1];
            CommandBuffer[5] = addr[2];
            CommandBuffer[6] = addr[3];
            CommandBuffer[7] = 0x20;
            CommandBuffer[8] = count[0];
            CommandBuffer[9] = count[1];
            CommandBuffer[10] = count[2];
            CommandBuffer[11] = count[3];
            CommandBuffer[12] = data[0];
            CommandBuffer[13] = data[1];
            CommandBuffer[14] = data[2];
            CommandBuffer[15] = data[3];
            CommandBuffer[16] = 0x00;
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public void WriteCommand(int Command_type, int addr_in, int datacount)
        {
            byte[] CommandBuffer = new byte[17];
            byte[] count = new byte[4];
            byte[] addr = new byte[4];
            for (int i = 3; i > -1; i--)
            {
                count[i] = Convert.ToByte(datacount % 256);
                datacount = datacount / 256;
            }
            for (int i = 3; i > -1; i--)
            {
                addr[i] = Convert.ToByte(addr_in % 256);
                addr_in = addr_in / 256;
            }
            CommandBuffer[0] = 0x01;
            CommandBuffer[1] = Convert.ToByte(Command_type);
            CommandBuffer[2] = Convert.ToByte(Command_type);
            CommandBuffer[3] = addr[0];
            CommandBuffer[4] = addr[1];
            CommandBuffer[5] = addr[2];
            CommandBuffer[6] = addr[3];
            CommandBuffer[7] = 0x20;
            CommandBuffer[8] = count[0];
            CommandBuffer[9] = count[1];
            CommandBuffer[10] = count[2];
            CommandBuffer[11] = count[3];
            CommandBuffer[12] = 0x00;
            CommandBuffer[13] = 0x00;
            CommandBuffer[14] = 0x00;
            CommandBuffer[15] = 0x00;
            CommandBuffer[16] = 0x00;
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public override void WriteData(byte[] data)
        {
            byte[] ReportBuffer = new byte[data.Length + 1];
            ReportBuffer[0] = 0x02;
            Array.Copy(data, 0, ReportBuffer, 1, data.Length);
            HidReport report = new HidReport(ReportBuffer.Length, new HidDeviceData(ReportBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

    }

    public class BL_Handler : HID_Handler
    {

        public event InsertedEventHandler Inserted;
        public event RemovedEventHandler Removed;
        public event DataRecievedEventHandler DataRecieved;
        public event LogUpdateEventHandler LogUpdate;

        public delegate void InsertedEventHandler();
        public delegate void RemovedEventHandler();
        public delegate void DataRecievedEventHandler(byte[] data);
        public delegate void LogUpdateEventHandler(string log, bool newline);

        private readonly HidDevice _hid_handler;
        private int _isReading;

        public BL_Handler(string devicePath) : this(HidDevices.GetDevice(devicePath)) { }

        public BL_Handler(HidDevice hidDevice)
        {
            _hid_handler = hidDevice;

            _hid_handler.Inserted += DeviceInserted;
            _hid_handler.Removed += DeviceRemoved;
            if (!_hid_handler.IsOpen) _hid_handler.OpenDevice();
            _hid_handler.MonitorDeviceEvents = true;

            BeginReadReport();
        }

        public string DevicePath { get { return _hid_handler.DevicePath; } }
        public bool IsListening { get; private set; }
        public bool IsConnected { get { return _hid_handler.IsConnected; } }

        public static IEnumerable<BL_Handler> Enumerate(int Vid, int[] productIds)
        {
            return HidDevices.Enumerate(Vid, productIds).Select(x => new BL_Handler(x));
        }

        public void StartListen() { IsListening = true; }
        public void StopListen() { IsListening = false; }

        public override void BeginReadReport()
        {
            if (Interlocked.CompareExchange(ref _isReading, 1, 0) == 1) return;
            _hid_handler.ReadReport(ReadReport, 0);
        }

        public override void ReadReport(HidReport report)
        {
            var ReadReport = new BL_Report(report);
            var data = new byte[] { };

            if (ReadReport.ReadStatus == HidDeviceData.ReadStatus.Success)
            {

                LogUpdate("Report ID : " + ReadReport.ReportId, true);
                if (ReadReport.Data != null)
                {
                    Array.Resize(ref data, data.GetUpperBound(0) + ReadReport.Data.Length + 1);
                    Array.Copy(ReadReport.Data, 0, data, 0, ReadReport.Data.Length);
                }                
                else if (ReadReport.FollowwithData)
                {
                    LogUpdate("Following with Data, BootLoader Status : " + ReadReport.BL_Status , true);
                }
                else if (ReadReport.Response_Tag == 160)
                {
                    LogUpdate("Command Operated Status : " + ReadReport.BL_Status + " Command : " + ReadReport.Command_Respond_For, true);
                }
                Debug.WriteLine("BLPacketage Received");
                if (IsListening && DataRecieved != null) DataRecieved(data); //&& data.Length > 0
            }
            if (ReadReport.ReadStatus != HidDeviceData.ReadStatus.NotConnected) _hid_handler.ReadReport(this.ReadReport);
            else _isReading = 0;
        }

        public override void OnReport(HidReport report)
        {
            if (IsListening == false) { return; }

            System.Diagnostics.Debug.Write("Received raw data: ");
            for (int i = 0; i < report.Data.Length; i++)
            {
                System.Diagnostics.Debug.Write(String.Format("{0:000} ", report.Data[i]));
            }
            System.Diagnostics.Debug.WriteLine("");

            _hid_handler.ReadReport(OnReport);
        }

        private void DeviceInserted()
        {
            BeginReadReport();
            if (Inserted != null) Inserted();
        }

        private void DeviceRemoved()
        {
            if (Removed != null) Removed();
        }

        public override void Dispose()
        {
            _hid_handler.CloseDevice();
            GC.SuppressFinalize(this);
        }

        ~BL_Handler()
        {
            Dispose();
        }

        public void WriteCommand(int Command_type, int para_1_in, int para_2_in, byte[] data, bool follow_data)
        {
            byte[] CommandBuffer = new byte[1021]; //6+12+1(Report ID)+4 byte data
            byte[] para_1 = new byte[4];
            byte[] para_2 = new byte[4];
            byte[] data_replicated = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                para_2[i] = Convert.ToByte(para_2_in % 256);
                para_2_in = para_2_in / 256;
            }
            for (int i = 0; i < 4; i++)
            {
                para_1[i] = Convert.ToByte(para_1_in % 256);
                para_1_in = para_1_in / 256;
            }
            for (int i = 0; i < 4; i++)
            {
                if(data == null)
                {
                    data_replicated[i] = 0x00;
                }
                else if (data.Length < 4)
                {
                    if(data.Length != 2 || data.Length != 4)
                    {
                        throw new ArgumentException(String.Format("Write data count isn't 2 or 4"), "data");
                    }
                    else
                    {
                        data_replicated[3-i] = data[i % data.Length];
                    }
                }
                else
                    data_replicated[3-i] = data[i];
            }
            CommandBuffer[0] = 0x01;    //Report ID
            CommandBuffer[1] = 0x00;
            CommandBuffer[2] = 0x10;    //Packet Length Low
            CommandBuffer[3] = 0x00;    //Packet Length High
            CommandBuffer[4] = Convert.ToByte(Command_type);
            CommandBuffer[5] = (follow_data) ? Convert.ToByte(0x01) : Convert.ToByte(0x00);    //Flags
            CommandBuffer[6] = 0x00;    //Reserved
            CommandBuffer[7] = 0x03;   //Para_count
            CommandBuffer[8] = para_1[0];
            CommandBuffer[9] = para_1[1];
            CommandBuffer[10] = para_1[2];
            CommandBuffer[11] = para_1[3];
            CommandBuffer[12] = para_2[0];
            CommandBuffer[13] = para_2[1];
            CommandBuffer[14] = para_2[2];
            CommandBuffer[15] = para_2[3];
            CommandBuffer[16] = data_replicated[0];
            CommandBuffer[17] = data_replicated[1];
            CommandBuffer[18] = data_replicated[2];
            CommandBuffer[19] = data_replicated[3];
            for (int c = 20; c < CommandBuffer.Length; c++)
            {
                CommandBuffer[c] = 0x00;
            }
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public void WriteCommand(int Command_type, int para_1_in, int para_2_in, bool follow_data)
        {
            byte[] CommandBuffer = new byte[1021]; //2+12+1(Report ID)
            byte[] para_1 = new byte[4];
            byte[] para_2 = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                para_2[i] = Convert.ToByte(para_2_in % 256);
                para_2_in = para_2_in / 256;
            }
            for (int i = 0; i < 4; i++)
            {
                para_1[i] = Convert.ToByte(para_1_in % 256);
                para_1_in = para_1_in / 256;
            }
            //Crc CRC16_X = new Crc(CrcStdParams.StandartParameters[CRC.CrcAlgorithms.Crc16Xmodem]);
            //CRC16 = CRC16_X.ComputeHash(pure_command);

            CommandBuffer[0] = 0x01;    //Report ID
            CommandBuffer[1] = 0x00;
            CommandBuffer[2] = 0x0C;    //Packet Length Low
            CommandBuffer[3] = 0x00;    //Packet Length High
            CommandBuffer[4] = Convert.ToByte(Command_type);
            CommandBuffer[5] = (follow_data) ? Convert.ToByte(0x01) : Convert.ToByte(0x00);    //Flags
            CommandBuffer[6] = 0x00;    //Reserved
            CommandBuffer[7] = 0x02;   //Para_count
            CommandBuffer[8] = para_1[0];
            CommandBuffer[9] = para_1[1];
            CommandBuffer[10] = para_1[2];
            CommandBuffer[11] = para_1[3];
            CommandBuffer[12] = para_2[0];
            CommandBuffer[13] = para_2[1];
            CommandBuffer[14] = para_2[2];
            CommandBuffer[15] = para_2[3];
            for(int c = 16; c < CommandBuffer.Length; c++)
            {
                CommandBuffer[c] = 0x00;
            }
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public void WriteCommand(byte[] Command_type, byte[] para_1_in, byte[] para_2_in, bool follow_data)
        {
            byte[] CommandBuffer = new byte[1021]; //2+12+1(Report ID)
            
            CommandBuffer[0] = 0x01;    //Report ID
            CommandBuffer[1] = 0x00;
            CommandBuffer[2] = 0x0C;    //Packet Length Low
            CommandBuffer[3] = 0x00;    //Packet Length High
            CommandBuffer[4] = Command_type[0];
            CommandBuffer[5] = (follow_data) ? Convert.ToByte(0x01) : Convert.ToByte(0x00);    //Flags
            CommandBuffer[6] = 0x00;    //Reserved
            CommandBuffer[7] = 0x02;   //Para_count
            CommandBuffer[8] = para_1_in[3];
            CommandBuffer[9] = para_1_in[2];
            CommandBuffer[10] = para_1_in[1];
            CommandBuffer[11] = para_1_in[0];
            CommandBuffer[12] = para_2_in[3];
            CommandBuffer[13] = para_2_in[2];
            CommandBuffer[14] = para_2_in[1];
            CommandBuffer[15] = para_2_in[0];
            for (int c = 16; c < CommandBuffer.Length; c++)
            {
                CommandBuffer[c] = 0x00;
            }
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public void WriteCommand(byte[] Command_type, byte[] para_1_in, int data_len, byte[] data, bool follow_data)
        {
            byte[] CommandBuffer = new byte[1021]; //6+12+1(Report ID)+4 byte data
            byte[] datalen = new byte[4];
            byte[] data_replicated = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                datalen[i] = Convert.ToByte(data_len % 256);
                data_len = data_len / 256;
            }
            CommandBuffer[0] = 0x01;    //Report ID
            CommandBuffer[1] = 0x00;
            CommandBuffer[2] = 0x10;    //Packet Length Low
            CommandBuffer[3] = 0x00;    //Packet Length High
            CommandBuffer[4] = Command_type[0];
            CommandBuffer[5] = (follow_data) ? Convert.ToByte(0x01) : Convert.ToByte(0x00);    //Flags
            CommandBuffer[6] = 0x00;    //Reserved
            CommandBuffer[7] = 0x03;   //Para_count
            CommandBuffer[8] = para_1_in[3];
            CommandBuffer[9] = para_1_in[2];
            CommandBuffer[10] = para_1_in[1];
            CommandBuffer[11] = para_1_in[0];
            CommandBuffer[12] = datalen[0];
            CommandBuffer[13] = datalen[1];
            CommandBuffer[14] = datalen[2];
            CommandBuffer[15] = datalen[3];
            CommandBuffer[16] = data[3];
            CommandBuffer[17] = data[2];
            CommandBuffer[18] = data[1];
            CommandBuffer[19] = data[0];
            for (int c = 20; c < CommandBuffer.Length; c++)
            {
                CommandBuffer[c] = 0x00;
            }
            HidReport report = new HidReport(CommandBuffer.Length, new HidDeviceData(CommandBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

        public override void WriteData(byte[] data)
        {
            int data_len = data.Length;
            byte[] data_L = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                data_L[i] = Convert.ToByte(data_len % 256);
                data_len = data_len / 256;
            }
            byte[] ReportBuffer = new byte[1021];
            ReportBuffer[0] = 0x02;
            ReportBuffer[1] = 0x00;
            ReportBuffer[2] = data_L[0];
            ReportBuffer[3] = data_L[1];
            Array.Copy(data, 0, ReportBuffer, 4, data.Length);
            for(int i = data.Length + 4; i < 1021; i++)
            {
                ReportBuffer[i] = 0x00;
            }
            HidReport report = new HidReport(ReportBuffer.Length, new HidDeviceData(ReportBuffer, HidDeviceData.ReadStatus.Success));
            _hid_handler.WriteReport(report);
        }

    }
}
