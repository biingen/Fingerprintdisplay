using System;
using HidLibrary;

namespace FPD
{
    public abstract class Report
    {
      
    }


    public class SDP_Report : Report
    {
        private readonly byte[] _data;
        private readonly HidDeviceData.ReadStatus _status;

        public SDP_Report(HidReport hidReport)
        {
            _status = hidReport.ReadStatus;
            ReportId = hidReport.ReportId;
            Exists = hidReport.Exists;

            if(ReportId == 3)
            {
                if (hidReport.Data.Length > 3)
                {
                    if (hidReport.Data[0] == 0x12 && hidReport.Data[1] == 0x34 && hidReport.Data[2] == 0x34 && hidReport.Data[3] == 0x12) PortStatus = false;
                    if (hidReport.Data[0] == 0x56 && hidReport.Data[1] == 0x78 && hidReport.Data[2] == 0x78 && hidReport.Data[3] == 0x56) PortStatus = true;
                }
            }
            else if (ReportId == 4)
            {
                if (hidReport.Data[0] == 0x88 && hidReport.Data[1] == 0x88 && hidReport.Data[2] == 0x88 && hidReport.Data[3] == 0x88) FileWriteComplete = true;
                else if (hidReport.Data[0] == 0x12 && hidReport.Data[1] == 0x8A && hidReport.Data[2] == 0x8A && hidReport.Data[3] == 0x12) WriteSuccess = true;
                else if (hidReport.Data[0] == 0x89 && hidReport.Data[1] == 0x23 && hidReport.Data[2] == 0x23 && hidReport.Data[3] == 0x89) WriteSuccess = false;
                else
                {
                    Array.Resize(ref _data, hidReport.Data.Length);
                    Array.Copy(hidReport.Data, 0, _data, 0, hidReport.Data.Length);
                }
            }            
        }

        public HidDeviceData.ReadStatus ReadStatus { get { return _status; } }
        public byte[] Data { get { return _data; } }
        public bool Exists { get; private set; }
        public byte ReportId { get; private set; }
        public bool PortStatus { get; private set; }
        public bool WriteSuccess { get; private set; }
        public bool FileWriteComplete { get; private set; }
    }

    public class BL_Report : Report
    {
        private readonly byte[] _data;
        private readonly HidDeviceData.ReadStatus _status;

        public BL_Report(HidReport hidReport)
        {
            _status = hidReport.ReadStatus;
            ReportId = hidReport.ReportId;
            Exists = hidReport.Exists;
            Valid_Packet_Len = hidReport.Data[1] + hidReport.Data[2] * 256;

            if(ReportId == 3)
            {
                Response_Tag = hidReport.Data[3];
                FollowwithData = hidReport.Data[4] == 1;
                BL_Status = hidReport.Data[7] + hidReport.Data[8] * 16 + hidReport.Data[9] * 256 + hidReport.Data[10] * 4096;
                if (Response_Tag == 160)
                {
                    Command_Respond_For = hidReport.Data[11] + hidReport.Data[12] * 16 + hidReport.Data[13] * 256 + hidReport.Data[14] * 4096;
                }
                else if (Response_Tag == 175)
                {
                    Valid_Data_count = hidReport.Data[11] + hidReport.Data[12] * 16 + hidReport.Data[13] * 256 + hidReport.Data[14] * 4096;
                    Array.Resize(ref _data, Valid_Data_count);
                    Array.Copy(hidReport.Data, 15, _data, 0, _data.Length); //BL Packet Has 2 Bytes of Report ID
                }
                else
                {
                    Array.Resize(ref _data, 0);
                }

            }
            else
            {
                Array.Resize(ref _data, Valid_Packet_Len);
                Array.Copy(hidReport.Data, 3, _data, 0, _data.Length); //BL Packet Has 2 Bytes of Report ID
            }

        }

        public HidDeviceData.ReadStatus ReadStatus { get { return _status; } }
        public byte[] Data { get { return _data; } }
        public bool Exists { get; private set; }
        public byte ReportId { get; private set; }
        public bool PortStatus { get; private set; }
        public bool WriteSuccess { get; private set; }
        public bool FileWriteComplete { get; private set; }
        public int Response_Tag { get; private set; }
        public int Valid_Packet_Len { get; private set; }
        public int Valid_Data_count { get; private set; }
        public int BL_Status { get; private set; }
        public bool FollowwithData { get; private set; }
        public int Command_Respond_For { get; private set; }

    }
}
