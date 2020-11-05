#define DEBUG
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

namespace FPD
{
    class SREC_file
    {
        string File_Path;
        private Bootable_Image bootable_Image;
        public SREC_file(string Path)
        {
            File_Path = Path;
            Image_Packing();
        }

        private void Image_Packing()
        {
            FileStream fileStream = new FileStream(File_Path, FileMode.Open, FileAccess.Read);
            byte[] Filedata = new byte[fileStream.Length / 2];
            int data_count = 0;
            byte[] app_entry = new byte[4];
            byte[] in_temp = new byte[4];
            byte[] Filedata_reranged;

            while (fileStream.Read(in_temp, 0, 4) > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    in_temp[i] = Convert.ToByte((in_temp[i] > 57) ? in_temp[i] - 55 : in_temp[i] - 48); ;
                }
                byte type = BitConverter.GetBytes(in_temp[0] * 16 + in_temp[1])[0];
                //Debug.Write("\nType : " + type + "\t");
                byte len = BitConverter.GetBytes(in_temp[2] * 16 + in_temp[3])[0];
                //Debug.Write("Len : " + len + "\t");

                if (type == 192)
                {
                    byte[] raw_line_data = new byte[(len + 1) * 2];
                    fileStream.Read(raw_line_data, 0, (len + 1) * 2);
                    byte[] line_data = new byte[len];
                    for (int i = 0; i < raw_line_data.Length - 2; i++)
                    {
                        raw_line_data[i] = Convert.ToByte((raw_line_data[i] > 57) ? raw_line_data[i] - 55 : raw_line_data[i] - 48); ;
                        if (i % 2 == 1)
                        {
                            line_data[i / 2] = BitConverter.GetBytes(raw_line_data[i - 1] * 16 + raw_line_data[i])[0];
                            //Debug.Write(Convert.ToChar(line_data[i / 2]));
                        }
                    }
                }
                else if (type == 195)
                {
                    byte[] raw_line_data = new byte[(len + 1) * 2];
                    fileStream.Read(raw_line_data, 0, (len + 1) * 2);
                    byte[] line_data = new byte[len];
                    for (int i = 0; i < raw_line_data.Length - 2; i++)
                    {
                        raw_line_data[i] = Convert.ToByte((raw_line_data[i] > 57) ? raw_line_data[i] - 55 : raw_line_data[i] - 48); ;
                        if (i % 2 == 1)
                        {
                            line_data[i / 2] = BitConverter.GetBytes(raw_line_data[i - 1] * 16 + raw_line_data[i])[0];
                        }
                    }
                    Array.Copy(line_data, 4, Filedata, data_count, len - 5);
                    //Debug.Write("Data : ");
                    for (int c = 0; c < len - 5; c++)
                    {
                        //Debug.Write(Filedata[data_count + c] + "\t");

                    }
                    data_count += len - 5;
                }
                else if (type == 199)
                {
                    byte[] raw_line_data = new byte[(len + 1) * 2];
                    fileStream.Read(raw_line_data, 0, (len + 1) * 2);
                    byte[] line_data = new byte[len];
                    for (int i = 0; i < raw_line_data.Length - 2; i++)
                    {
                        raw_line_data[i] = Convert.ToByte((raw_line_data[i] > 57) ? raw_line_data[i] - 55 : raw_line_data[i] - 48); ;
                        if (i % 2 == 1)
                        {
                            line_data[i / 2] = BitConverter.GetBytes(raw_line_data[i - 1] * 16 + raw_line_data[i])[0];
                        }
                    }
                    app_entry[0] = line_data[len - 2];
                    app_entry[1] = line_data[len - 3];
                    app_entry[2] = line_data[len - 4];
                    app_entry[3] = line_data[len - 5];
                    Debug.Write("APP_Entry : " + app_entry[0] + " " + app_entry[1] + " " + app_entry[2] + " " + app_entry[3]);
                    break;
                }
            }
            Filedata_reranged = new byte[data_count];
            Array.Copy(Filedata, 0, Filedata_reranged, 0, data_count);
            ivt_boot_image = new Bootable_Image(Filedata_reranged, app_entry);
#if DEBUG
            if (File.Exists("Bootable_image.txt"))
                File.Delete("Bootable_image.txt");
            FileStream outstream = new FileStream("Bootable_image.txt", FileMode.CreateNew, FileAccess.Write);
            int file_pointer = 0;
            while (file_pointer < ivt_boot_image.Data.Length)
            {
                int data_len = ((ivt_boot_image.Data.Length - file_pointer) > 16) ? 16 : (ivt_boot_image.Data.Length - file_pointer);
                byte[] stream = new byte[data_len];
                Array.Copy(ivt_boot_image.Data, file_pointer, stream, 0, stream.Length);
                outstream.Write(stream, 0, stream.Length);
                file_pointer += data_len;
            }
            outstream.Close();
#endif
        }

        public Bootable_Image ivt_boot_image { private set { bootable_Image = value; } get { return bootable_Image; } }
    }
}
