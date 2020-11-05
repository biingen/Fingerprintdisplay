using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HID_api;
using HidLibrary;
using System.Threading;
using System.Windows.Forms;

namespace FPD
{
    class HID_Handler
    {
        #region parameter Define
        public static HIDInterface hid = new HIDInterface();


        public struct connectStatusStruct
        {
            public bool preStatus;
            public bool curStatus;
        }

        public static connectStatusStruct connectStatus = new connectStatusStruct();

        //推送連接狀態信息
        public delegate void isConnectedDelegate(bool isConnected);
        public static isConnectedDelegate isConnectedFunc;


        //推送接收數據信息
        public delegate void PushReceiveDataDele(byte[] datas);
        public static PushReceiveDataDele pushReceiveData;

        #endregion

        //第一步需要初始化，傳入vid、pid，並開啓自動連接
        public static void Initial()
        {

            hid.StatusConnected = StatusConnected;
            hid.DataReceived = DataReceived;

            HIDInterface.HidDevice hidDevice = new HIDInterface.HidDevice();
            hidDevice.vID = 0x1FC9;
            hidDevice.pID = 0x0130;
            hidDevice.serial = "";
            hid.AutoConnect(hidDevice);

        }

        //不使用則關閉
        public static void Close()
        {
            hid.StopAutoConnect();
        }

        //發送數據
        public static bool SendBytes(byte[] data)
        {
            return hid.Send(data);

        }

        //接受到數據
        public static void DataReceived(object sender, byte[] e)
        {
            if (pushReceiveData != null)
                pushReceiveData(e);
        }

        //狀態改變接收
        public static void StatusConnected(object sender, bool isConnect)
        {
            connectStatus.curStatus = isConnect;
            if (connectStatus.curStatus == connectStatus.preStatus)  //connect
                return;
            connectStatus.preStatus = connectStatus.curStatus;

            if (connectStatus.curStatus)
            {
                isConnectedFunc(true);
            }
            else //disconnect
            {
                isConnectedFunc(false);
            }
        }

        public void WriteBytes(byte[] data)
        {
            //HidReport report = new HidReport(data.Length, new HidDeviceData(data, HidDeviceData.ReadStatus.Success));
            //_hid_handler.WriteFeatureData(data);
            //byte[] outdata;
            //_hid_handler.ReadFeatureData(out outdata);
            //System.Diagnostics.Debug.WriteLine("Received raw data: ");
            //for (int i = 0; i < outdata.Length; i++)
            //{
            //    System.Diagnostics.Debug.Write(String.Format("{0:000} ", outdata[i]));
            //}
        }

    }
}
