using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FingerPrint_API;
using System.Drawing.Imaging;
using System.Diagnostics;
using CsGL.OpenGL;
using CsGL.Pointers;
using CsGL.Util;
using System.Runtime.InteropServices;
using System.IO;

namespace FPD
{
    class Viewer
    {
        public static int handle = 0;
        public static int frameCount = -1;
        public static int save_count = 0;
        public static uint nDataFrameNum = 9;
        public static uint goodFrame = 0;
        public static uint badFrame = 0;
        public static bool _Running = false;
        public static bool _Buffer0 = false;
        public static bool _Buffer1 = false;
        public static bool _Buffer2 = false;
        public static bool _Buffer3 = false;
        public static bool _Save = false;
        public static bool _Reset = false;
        public static bool _Initial = false;
        public static bool _isConnect = false;
        public static bool DisplayByGL = true;
        public static bool StreamStart = false;
        public static bool Sec_screen_static = true;
        public static bool Cursor = false;
        public static bool ROI = false;
        public static bool FPS_Enable = true;
        public static Point Mouse;
        public static int BLU = 0x55AA;
        public static int FLU = 0x55AA;
        public static int gate = 0x55AA;
        public static int cfb = 0x55AA;
        public static int gain = 1;
        public static int scale = 1;
        public static int frameTime = 0;
        public static int drawTime = 0;
        public static int reportTimeCount = 0;
        public static int Backup_frame = 0;
        public static double TN = 0.0;
        public static Parameter.DebugLevel debuglevel = Parameter.DebugLevel.NORMAL;
        public static System.IO.Stream sSavePath;
        public static string PathofExe;
        public static FingerPrint fingerPrint;
        public static Graphics Draw_graphic;
        public static Stopwatch tictoc = new Stopwatch();
        public static double FPS = 0;
        public static double ZoomIn_Ratio = 1;
        public static int rotate_degree = 0;

        public static double Display_Width = 1600;
        public static double Display_Height = 1500;

        public static double Display_Range_L = -1.0;
        public static double Display_Range_R = 1.0;
        public static double Display_Range_T = 1.0;
        public static double Display_Range_D = -1.0;

        public static double ROI_DrawRange_L = 0;
        public static double ROI_DrawRange_R = 0;
        public static double ROI_DrawRange_T = 0;
        public static double ROI_DrawRange_D = 0;
        public static double ROI_X_1 = 0;
        public static double ROI_Y_1 = 0;
        public static double ROI_X_2 = 0;
        public static double ROI_Y_2 = 0;
        public static double Temp_ROI_x = 0;
        public static double Temp_ROI_y = 0;

        public static double APP_Start_times;
        public static double PIC_Success_times;
        public static int PWMDuty_memory;
        public static int PWMFrequency_memory;
        public static bool _Device = false;
        public static bool _FLUDevice = false;
        public static bool _FormInitial = false;

        //public static byte[] pBitData0 = new byte[1600 * 1500 * 3];
        //public static byte[] pBitData1 = new byte[1600 * 1500 * 3];
        //public static byte[] pBitData2 = new byte[1600 * 1500 * 3];
        //public static byte[] pBitData3 = new byte[1600 * 1500 * 3];
        public static byte[] pBitData0 = new byte[1600 * 1500];
        public static byte[] pBitData1 = new byte[1600 * 1500];
        public static byte[] pBitData2 = new byte[1600 * 1500];
        public static byte[] pBitData3 = new byte[1600 * 1500];
        public static byte[] pBitDataGray = new byte[1600 * 1500];

        public static byte[] pBitDataTN0 = new byte[1600 * 1500];
        public static byte[] pBitDataTN1 = new byte[1600 * 1500];
        public static byte[] pBitDataTN2 = new byte[1600 * 1500];
        public static byte[] pBitDataTN3 = new byte[1600 * 1500];
        public static byte[] pBitDataTN4 = new byte[1600 * 1500];
        public static byte[] pBitDataTN5 = new byte[1600 * 1500];
        public static byte[] pBitDataTN6 = new byte[1600 * 1500];
        public static byte[] pBitDataTN7 = new byte[1600 * 1500];
        public static byte[] pBitDataTN8 = new byte[1600 * 1500];
        public static byte[] pBitDataTN9 = new byte[1600 * 1500];
        public static byte[] pBitDataTN_temp = new byte[1600 * 1500];
        public static byte[] input = new byte[1600 * 1500];

        public static byte[] pBitFPN_L = new byte[1600 * 1500];
        public static byte[] pBitFPN_H = new byte[1600 * 1500];

        //public static Bitmap bmp0 = new Bitmap(1600, 1500, 1600 * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData0, 0));
        //public static Bitmap bmp1 = new Bitmap(1600, 1500, 1600 * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData1, 0));
        //public static Bitmap bmp2 = new Bitmap(1600, 1500, 1600 * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData2, 0));
        public static Bitmap bmp0 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData0, 0));
        public static Bitmap bmp1 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData1, 0));
        public static Bitmap bmp2 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData2, 0));
        public static Bitmap bmp_backup = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitData3, 0));
        public static Bitmap bmpGray = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataGray, 0));

        public static Bitmap bmp_TN_0 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN0, 0));
        public static Bitmap bmp_TN_1 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN1, 0));
        public static Bitmap bmp_TN_2 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN2, 0));
        public static Bitmap bmp_TN_3 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN3, 0));
        public static Bitmap bmp_TN_4 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN4, 0));
        public static Bitmap bmp_TN_5 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN5, 0));
        public static Bitmap bmp_TN_6 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN6, 0));
        public static Bitmap bmp_TN_7 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN7, 0));
        public static Bitmap bmp_TN_8 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN8, 0));
        public static Bitmap bmp_TN_9 = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN9, 0));
        public static Bitmap bmp_TN_Temp = new Bitmap(1600, 1500, 1600, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(pBitDataTN_temp, 0));

        public static double[] avg = new double[1600 * 1500];
        public static double[] Variance = new double[1600 * 1500];
        public static double[] STD = new double[1600 * 1500];

        public static System.Threading.Thread tArrange;
        public static System.Threading.Thread tShowImage;
        public static System.Threading.Thread tInitial;
        public static System.Threading.Thread tSaveImage;
        public static System.Threading.Thread tCompatible;
        public static System.Threading.Thread tStressTest;

        public static System.Drawing.Imaging.ColorPalette tempPalette;


        public delegate void UpadateImageInvoke(int image);
        public delegate void UpadateLogInvoke(string log, bool line);
        public delegate void UpadateDataMapInvoke(string data);
        public delegate void UpadateLogColorInvoke(string log, bool line, Color color);
        public delegate void SaveImageInvoke(Bitmap image);

        public delegate void InitialDviceCallback();
        public delegate void InitialINFCallback();

        public delegate void UpdateTextCallback(TextBox txt, String str, Color fore, Color back);																// Setup the callback routine for updating the UI
        public delegate void UpdateStatusCallback(ToolStripStatusLabel txt, String str, Color color);
        public delegate void UpdateRichTextCallback(RichTextBox rRxt, String str);
        public delegate void UpdateStatusBarCallback(ToolStripProgressBar statusBar, int value);
        public delegate void UpdateProgressBarCallback(int value);
        public delegate void UpdateImageCallback();


        public static void UpdateShowBmp(ref byte[] src, ref byte[] dest)
        {
            for (int i = 0; i < 1500 * 1600; i++)
            {
                dest[i * 3] = src[i];
                dest[i * 3 + 1] = src[i];
                dest[i * 3 + 2] = src[i];
            }
        }

        public static void UpdateShowBmp(ref ushort[] src, ref byte[] dest)
        {
            for (int i = 0; i < 1500 * 1600; i++)
            {
                dest[i * 3] = (byte)(src[i] >> 2);
                dest[i * 3 + 1] = dest[i * 3];
                dest[i * 3 + 2] = dest[i * 3];
            }
        }

        public static void SetPalette()
        {
            tempPalette = bmpGray.Palette;
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmpGray.Palette = tempPalette;
        }

        public static void Save_current_tobackup()
        {
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
                default:
                    break;
            }
        }

    }
      

    public class GL_Drawer : OpenGLControl
    {
        Size m_size;
        byte[] m_pixBuffer;
        int freash_count = -1;
        uint[] texID = new uint[10];
        int height = Viewer.bmp0.Height;
        int width = Viewer.bmp0.Width;
        public GL_Drawer()
        {
        }

        public override void glDraw()
        {
            freash_count++;
            BitmapData bmpData;
            ImageConverter converter = new ImageConverter();
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT); // Clear Screen And Depth Buffer
            OpenGL.glLoadIdentity();
            GL.glBindTexture(GL.GL_TEXTURE_2D, texID[0]);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
            GL.glEnable(GL.GL_TEXTURE_2D);

            GL.glColor3f(1.0f, 1.0f, 1.0f);
            switch (Viewer.nDataFrameNum)
            {
                case 0:
                    Viewer.bmp0.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpData = Viewer.bmp0.LockBits(new Rectangle(0, 0, Viewer.bmp0.Width, Viewer.bmp0.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                    GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp0.Width, Viewer.bmp0.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                    //Viewer.input = new byte[bmpData.Stride * bmpData.Height];
                    //Marshal.Copy(bmpData.Scan0, Viewer.input, 0, bmpData.Stride * bmpData.Height);
                    Viewer.bmp0.UnlockBits(bmpData);
                    break;
                case 1:
                    Viewer.bmp1.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpData = Viewer.bmp1.LockBits(new Rectangle(0, 0, Viewer.bmp1.Width, Viewer.bmp1.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                    GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp1.Width, Viewer.bmp1.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                    //Viewer.input = new byte[bmpData.Stride * bmpData.Height];
                    //Marshal.Copy(bmpData.Scan0, Viewer.input, 0, bmpData.Stride * bmpData.Height);
                    Viewer.bmp1.UnlockBits(bmpData);
                    break;
                case 2:
                    Viewer.bmp2.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpData = Viewer.bmp2.LockBits(new Rectangle(0, 0, Viewer.bmp2.Width, Viewer.bmp2.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                    GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp2.Width, Viewer.bmp2.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                    //Viewer.input = new byte[bmpData.Stride * bmpData.Height];
                    //Marshal.Copy(bmpData.Scan0, Viewer.input, 0, bmpData.Stride * bmpData.Height);
                    Viewer.bmp2.UnlockBits(bmpData);
                    break;
                case 9:
                    bmpData = Viewer.bmp_backup.LockBits(new Rectangle(0, 0, Viewer.bmp_backup.Width, Viewer.bmp_backup.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                    GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp_backup.Width, Viewer.bmp_backup.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                    //Viewer.input = new byte[bmpData.Stride * bmpData.Height];
                    //Marshal.Copy(bmpData.Scan0, Viewer.input, 0, bmpData.Stride * bmpData.Height);
                    Viewer.bmp_backup.UnlockBits(bmpData);
                    break;
                default:
                    break;

            }
            Viewer.Save_current_tobackup();
            //TN();
            Drawsquare(Viewer.rotate_degree);
            GL.glDisable(GL.GL_TEXTURE_2D);
            if (Viewer.Cursor)
            {
                double x_ratio = ((double)Viewer.Mouse.X / Viewer.bmp0.Width) * 2 - 1;
                double y_ratio = (1 - ((double)Viewer.Mouse.Y / Viewer.bmp0.Height)) * 2 - 1;
                double x_cursor = (x_ratio - Viewer.Display_Range_L) / (2 * Viewer.ZoomIn_Ratio);
                double y_cursor = (y_ratio - Viewer.Display_Range_D) / (2 * Viewer.ZoomIn_Ratio); 
                GL.glColor3f(1.0f, 0.0f, 0.0f);
                GL.glBegin(GL.GL_LINES);
                GL.glVertex2d(x_cursor * 2 - 1, -1);
                GL.glVertex2d(x_cursor * 2 - 1, 1);
                GL.glEnd();
                GL.glBegin(GL.GL_LINES);
                GL.glVertex2d(-1, y_cursor * 2 - 1);
                GL.glVertex2d(1, y_cursor * 2 - 1);
                GL.glEnd();
            }
            if (Viewer.ROI)
                DrawROIRange();

            if (Viewer.FPS_Enable)
            {
                this.glPrint(0, this.Size.Height - 20, "FPS :" + Viewer.FPS.ToString("f4"));
            }
            GC.Collect();
            GL.glFlush();
            GL.glFinish();
        }

        public void TN()
        {
            switch (Viewer.frameCount % 10)
            {
                case 0:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_0.Clone(), Viewer.input);
                    Viewer.bmp_TN_0 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 1:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_1.Clone(), Viewer.input);
                    Viewer.bmp_TN_1 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 2:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_2.Clone(), Viewer.input);
                    Viewer.bmp_TN_2 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 3:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_3.Clone(), Viewer.input);
                    Viewer.bmp_TN_3 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 4:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_4.Clone(), Viewer.input);
                    Viewer.bmp_TN_4 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 5:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_5.Clone(), Viewer.input);
                    Viewer.bmp_TN_5 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 6:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_6.Clone(), Viewer.input);
                    Viewer.bmp_TN_6 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 7:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_7.Clone(), Viewer.input);
                    Viewer.bmp_TN_7 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 8:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_8.Clone(), Viewer.input);
                    Viewer.bmp_TN_8 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                case 9:
                    Viewer.TN = Cal_TN(Viewer.bmp_TN_9.Clone(), Viewer.input);
                    Viewer.bmp_TN_9 = (Bitmap)Viewer.bmp_TN_Temp.Clone();
                    break;
                default:
                    break;
            }
        }

        public double Cal_TN(object in_bmp, byte[] input)
        {
            double TN = 0.0;
            ImageConverter converter = new ImageConverter();
            BitmapData bmpData_TN = ((Bitmap)in_bmp).LockBits(new Rectangle(0, 0, ((Bitmap)in_bmp).Width, ((Bitmap)in_bmp).Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            byte[] origin = new byte[bmpData_TN.Stride * bmpData_TN.Height];
            Marshal.Copy(bmpData_TN.Scan0, origin, 0, bmpData_TN.Stride * bmpData_TN.Height);
            ((Bitmap)in_bmp).UnlockBits(bmpData_TN);

            for (int count = 0; count < input.Length; count++)
            {
                double i_o = Convert.ToInt16(input[count]) - Convert.ToInt16(origin[count]);
                double ipo = Convert.ToInt16(input[count]) + Convert.ToInt16(origin[count]);
                double temp = Viewer.Variance[count];
                Viewer.Variance[count] = Viewer.Variance[count] + ((i_o * ipo) / 10) - 2 * Viewer.avg[count] * (i_o / 10) - Math.Pow((i_o / 10), 2);
                
                Viewer.STD[count] = Double.IsNaN(Math.Pow(Viewer.Variance[count], 0.5))? 0 : Math.Pow(Viewer.Variance[count], 0.5);
                Viewer.avg[count] = Viewer.avg[count] + (i_o / 10);
            }
            for (int count = 0; count < Viewer.STD.Length; count++)
            {
                TN += Viewer.STD[count] / Viewer.STD.Length;
            };
            return TN;
        }

        protected void Drawsquare(int degree)
        {
            // Draw a square.
            GL.glBegin(GL.GL_POLYGON);
            switch(degree){
                case 0:
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(-1, 1);
                    break;
                case 90:
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(1, 1);
                    break;
                case 180:
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(1, -1);
                    break;
                case 270:
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(-1, -1);
                    break;
                default:
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_D + 1) / 2); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d((Viewer.Display_Range_R + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d((Viewer.Display_Range_L + 1) / 2, (Viewer.Display_Range_T + 1) / 2); GL.glVertex2f(-1, 1);
                    break;
            }
            GL.glEnd();
            GL.glFinish();
        }

        protected void DrawROIRange()
        {
            OpenGL.glLoadIdentity();
            GL.glColor3f(0.0f, 1.0f, 0.0f);

            double x1_ratio = (Viewer.ROI_DrawRange_L / Viewer.bmp0.Width) * 2 - 1;
            double y1_ratio = (1 - (Viewer.ROI_DrawRange_T / Viewer.bmp0.Height)) * 2 - 1;
            double x1_cursor = ((x1_ratio - Viewer.Display_Range_L) / (2 * Viewer.ZoomIn_Ratio)) * 2 - 1;
            double y1_cursor = ((y1_ratio - Viewer.Display_Range_D) / (2 * Viewer.ZoomIn_Ratio)) * 2 - 1;
            double x2_ratio = (Viewer.ROI_DrawRange_R / Viewer.bmp0.Width) * 2 - 1;
            double y2_ratio = (1 - (Viewer.ROI_DrawRange_D / Viewer.bmp0.Height)) * 2 - 1;
            double x2_cursor = ((x2_ratio - Viewer.Display_Range_L) / (2 * Viewer.ZoomIn_Ratio)) * 2 - 1;
            double y2_cursor = ((y2_ratio - Viewer.Display_Range_D) / (2 * Viewer.ZoomIn_Ratio)) * 2 - 1;

            // Draw a square.
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(x1_cursor, y1_cursor); GL.glVertex2d(x2_cursor, y1_cursor);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(x2_cursor, y1_cursor); GL.glVertex2d(x2_cursor, y2_cursor);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(x2_cursor, y2_cursor); GL.glVertex2d(x1_cursor, y2_cursor);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(x1_cursor, y2_cursor); GL.glVertex2d(x1_cursor, y1_cursor);
            GL.glEnd();
        }

        protected override void InitGLContext()
        {
            base.InitGLContext();
            GL.glGenTextures(1, texID); //where 1 is the count, and texID a new texture slot in the gpu
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.glOrtho(-1, 1, -1, 1, 1, -1);
        }

        private void BuildFont(string text, out byte[] pixBuffer, Font font)
        {
            if (font == null)
                font = new Font("Times New Roman", 11F);
            Color m_color = Color.White;

            Graphics g_ctrl = this.CreateGraphics();
            m_size = g_ctrl.MeasureString(text, font).ToSize() + new Size(1, 0);
            g_ctrl.Dispose();

            pixBuffer = new byte[m_size.Width * m_size.Height * 4];
            Bitmap bitmap = new Bitmap(m_size.Width, m_size.Height);
            Graphics g_bmp = Graphics.FromImage(bitmap);
            Brush brush = new SolidBrush(m_color);

            g_bmp.Clear(System.Drawing.Color.FromArgb(0, 0, 0, 0));
            g_bmp.DrawString(text, font, brush, new Rectangle(0, 0, m_size.Width, m_size.Height));
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            Array.Copy(stream.ToArray(), 54, pixBuffer, 0, pixBuffer.Length);

            stream.Dispose();
            brush.Dispose();
            g_bmp.Dispose();
            bitmap.Dispose();
        }

        private void glPrint(int x, int y, string text)
        {
            Font font = new Font("Times New Roman", 11F);

            this.BuildFont(text, out m_pixBuffer, font);

            GL.glBindTexture(GL.GL_TEXTURE_2D, 0);

            GL.glPushMatrix();
            GL.glLoadIdentity();

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.gluOrtho2D(0.0, (double)this.Width, 0.0, (double)this.Height);

            GL.glRasterPos2i(x, y);

            GL.glEnable(GL.GL_BLEND);
            GL.glDrawPixels(m_size.Width, m_size.Height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, m_pixBuffer);
            GL.glDisable(GL.GL_BLEND);

            GL.glPopMatrix();

            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glPopMatrix();
        }

        protected override void OnMouseDown(MouseEventArgs s)
        {
            if (((MouseEventArgs)s).Button == MouseButtons.Left)
            {
                int X = 0, Y = 0;
                X = ((MouseEventArgs)s).X;
                Y = ((MouseEventArgs)s).Y;
                int Rotate_X = 0, Rotate_Y = 0;
                Rotate_X = (Viewer.rotate_degree == 180) ? this.Width - X : (Viewer.rotate_degree == 90) ? Y : (Viewer.rotate_degree == 270) ? this.Height - Y : X;
                Rotate_Y = (Viewer.rotate_degree == 180) ? this.Height - Y : (Viewer.rotate_degree == 90) ? this.Width - X : (Viewer.rotate_degree == 270) ? X : Y;
                int zoomx = 0, zoomy = 0;
                zoomx = Convert.ToInt32(Rotate_X * 2 * Viewer.ZoomIn_Ratio);
                zoomy = Convert.ToInt32(Rotate_Y * 2 * Viewer.ZoomIn_Ratio);
                int shiftx = 0, shifty = 0;
                shiftx = Convert.ToInt32(zoomx + (Viewer.Display_Range_L + 1) / 2 * Viewer.bmp0.Width);
                shifty = Convert.ToInt32(zoomy + (1 - (Viewer.Display_Range_T + 1) / 2) * Viewer.bmp0.Height);

                Viewer.ROI_X_1 = shiftx;
                Viewer.ROI_Y_1 = shifty;
                Viewer.Temp_ROI_x = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).X * 2 * Viewer.ZoomIn_Ratio) + (Viewer.Display_Range_L + 1) / 2 * Viewer.bmp0.Width);      //zoom + shift
                Viewer.Temp_ROI_y = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).Y * 2 * Viewer.ZoomIn_Ratio) + (1 - (Viewer.Display_Range_T + 1) / 2) * Viewer.bmp0.Height);
            }
            base.OnMouseDown(s);
        }
        protected override void OnMouseMove(MouseEventArgs s)
        {
            if (((MouseEventArgs)s).Button == MouseButtons.Left)
            {
                int X = 0, Y = 0;
                X = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).X * 2 * Viewer.ZoomIn_Ratio) + (Viewer.Display_Range_L + 1) / 2 * Viewer.bmp0.Width);      //zoom + shift
                Y = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).Y * 2 * Viewer.ZoomIn_Ratio) + (1 - (Viewer.Display_Range_T + 1) / 2) * Viewer.bmp0.Height);
                if (X < Viewer.Temp_ROI_x)
                {
                    Viewer.ROI_DrawRange_L = X;
                    Viewer.ROI_DrawRange_R = Viewer.Temp_ROI_x;
                }
                else
                {
                    Viewer.ROI_DrawRange_L = Viewer.Temp_ROI_x;
                    Viewer.ROI_DrawRange_R = X;
                }

                if (Y < Viewer.Temp_ROI_y)
                {
                    Viewer.ROI_DrawRange_T = Y;
                    Viewer.ROI_DrawRange_D = Viewer.Temp_ROI_y;
                }
                else
                {
                    Viewer.ROI_DrawRange_T = Viewer.Temp_ROI_y;
                    Viewer.ROI_DrawRange_D = Y;
                }
                base.OnMouseMove(s);
            }
        }
        protected override void OnMouseUp(MouseEventArgs s)
        {
            Viewer.UpdateTextCallback UpdateText = FPD.Form_Main.form_display.Pixel_Info;
            if (((MouseEventArgs)s).Button == MouseButtons.Left)
            {
                Viewer.Save_current_tobackup();
                try
                {
                    int X = 0, Y = 0;
                    X = ((MouseEventArgs)s).X;
                    Y = ((MouseEventArgs)s).Y;
                    int Rotate_X = 0, Rotate_Y = 0;
                    Rotate_X = (Viewer.rotate_degree == 180) ? this.Width - X : (Viewer.rotate_degree == 90) ? Y : (Viewer.rotate_degree == 270) ? this.Height - Y : X;
                    Rotate_Y = (Viewer.rotate_degree == 180) ? this.Height - Y : (Viewer.rotate_degree == 90) ? this.Width - X : (Viewer.rotate_degree == 270) ? X : Y;
                    int zoomx = 0, zoomy = 0;
                    zoomx = Convert.ToInt32(Rotate_X * 2 * Viewer.ZoomIn_Ratio);
                    zoomy = Convert.ToInt32(Rotate_Y * 2 * Viewer.ZoomIn_Ratio);
                    int shiftx = 0, shifty = 0;
                    shiftx = Convert.ToInt32(zoomx + (Viewer.Display_Range_L + 1) / 2 * Viewer.bmp0.Width);
                    shifty = Convert.ToInt32(zoomy + (1 - (Viewer.Display_Range_T + 1) / 2) * Viewer.bmp0.Height);
                    Color pixel = Viewer.bmp_backup.GetPixel(shiftx, shifty);
                    Invoke(UpdateText, new Object[] { null, $"X : {shiftx}, Y : {shifty}, Gray Value : {pixel.GetBrightness() * 255} ", null, null });

                    Viewer.Mouse.X = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).X * 2 * Viewer.ZoomIn_Ratio) + (Viewer.Display_Range_L + 1) / 2 * Viewer.bmp0.Width);      //zoom + shift
                    Viewer.Mouse.Y = Convert.ToInt32(Convert.ToInt32(((MouseEventArgs)s).Y * 2 * Viewer.ZoomIn_Ratio) + (1 - (Viewer.Display_Range_T + 1) / 2) * Viewer.bmp0.Height);
                    Viewer.ROI_X_2 = shiftx;
                    Viewer.ROI_Y_2 = shifty;

                    if(Viewer.Mouse.X < Viewer.Temp_ROI_x)
                    {
                        Viewer.ROI_DrawRange_L = Viewer.Mouse.X;
                        Viewer.ROI_DrawRange_R = Viewer.Temp_ROI_x;
                    }
                    else
                    {
                        Viewer.ROI_DrawRange_L = Viewer.Temp_ROI_x;
                        Viewer.ROI_DrawRange_R = Viewer.Mouse.X;
                    }

                    if (Viewer.Mouse.Y < Viewer.Temp_ROI_y)
                    {
                        Viewer.ROI_DrawRange_T = Viewer.Mouse.Y;
                        Viewer.ROI_DrawRange_D = Viewer.Temp_ROI_y;
                    }
                    else
                    {
                        Viewer.ROI_DrawRange_T = Viewer.Temp_ROI_y;
                        Viewer.ROI_DrawRange_D = Viewer.Mouse.Y;
                    }

                    base.OnMouseUp(s);
                }
                catch (Exception e)
                {

                }

            }
        }

    }

    public class GL_SampleDrawer : OpenGLControl
    {
        Bitmap b;
        Size m_size;
        byte[] m_pixBuffer;
        uint[] texID = new uint[1];
        public override void glDraw()
        {
            BitmapData bmpData;
            GL.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT); // Clear Screen And Depth Buffer
            OpenGL.glLoadIdentity();

            GL.glEnable(GL.GL_TEXTURE_2D);
            GL.glBindTexture(GL.GL_TEXTURE_2D, texID[0]);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
            GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                       

            GL.glColor3f(1.0f, 1.0f, 1.0f);
            if (!Viewer.Sec_screen_static)
            {
                switch (Viewer.nDataFrameNum)
                {
                    case 0:
                        bmpData = Viewer.bmp0.LockBits(new Rectangle(0, 0, Viewer.bmp0.Width, Viewer.bmp0.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                        GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp0.Width, Viewer.bmp0.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        Viewer.bmp0.UnlockBits(bmpData);
                        break;
                    case 1:
                        bmpData = Viewer.bmp1.LockBits(new Rectangle(0, 0, Viewer.bmp1.Width, Viewer.bmp1.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                        GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp1.Width, Viewer.bmp1.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        Viewer.bmp1.UnlockBits(bmpData);
                        break;
                    case 2:
                        
                        bmpData = Viewer.bmp2.LockBits(new Rectangle(0, 0, Viewer.bmp2.Width, Viewer.bmp2.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                        GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp2.Width, Viewer.bmp2.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        Viewer.bmp2.UnlockBits(bmpData);
                        break;
                    case 9:
                        //Viewer.bmp_backup.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        bmpData = Viewer.bmp_backup.LockBits(new Rectangle(0, 0, Viewer.bmp_backup.Width, Viewer.bmp_backup.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                        GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_LUMINANCE, Viewer.bmp_backup.Width, Viewer.bmp_backup.Height, 0, GL.GL_LUMINANCE, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        Viewer.bmp_backup.UnlockBits(bmpData);
                        break;
                    default:
                        //b = global::FPD.Properties.Resources.AUO;
                        //b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        //bmpData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                        //GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, b.Width, b.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                        //b.UnlockBits(bmpData);
                        break;
                }
            }
            else
            {
                b = global::FPD.Properties.Resources.FP;
                b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                bmpData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, b.Width, b.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                b.UnlockBits(bmpData);
            }

            Drawsquare(Viewer.rotate_degree);
            GL.glDisable(GL.GL_TEXTURE_2D);

            // Draw Lines  
            GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(Viewer.Display_Range_L, Viewer.Display_Range_D);
            GL.glVertex2d(Viewer.Display_Range_R, Viewer.Display_Range_D);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(Viewer.Display_Range_R, Viewer.Display_Range_D);
            GL.glVertex2d(Viewer.Display_Range_R, Viewer.Display_Range_T);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(Viewer.Display_Range_R, Viewer.Display_Range_T);
            GL.glVertex2d(Viewer.Display_Range_L, Viewer.Display_Range_T);
            GL.glEnd();
            GL.glBegin(GL.GL_LINES);
            GL.glVertex2d(Viewer.Display_Range_L, Viewer.Display_Range_T);
            GL.glVertex2d(Viewer.Display_Range_L, Viewer.Display_Range_D);
            GL.glEnd();

            if (!Viewer.StreamStart)
            {
                this.glPrint(0, 0, "Stream Stop");
            }

            GC.Collect();
            GL.glFlush();
            GL.glFinish();
        }
        protected void Drawsquare(int degree)
        {

            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            OpenGL.glLoadIdentity();
            GL.glColor3f(1.0f, 1.0f, 1.0f);
            // Draw a square.
            GL.glBegin(GL.GL_POLYGON);
            switch (degree)
            {
                case 0:
                    GL.glTexCoord2d(0, 0); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d(1, 0); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d(1, 1); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d(0, 1); GL.glVertex2f(-1, 1);
                    break;
                case 90:
                    GL.glTexCoord2d(0, 0); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d(1, 0); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d(1, 1); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d(0, 1); GL.glVertex2f(1, 1);
                    break;
                case 180:
                    GL.glTexCoord2d(0, 0); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d(1, 0); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d(1, 1); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d(0, 1); GL.glVertex2f(1, -1);
                    break;
                case 270:
                    GL.glTexCoord2d(0, 0); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d(1, 0); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d(1, 1); GL.glVertex2f(-1, 1);
                    GL.glTexCoord2d(0, 1); GL.glVertex2f(-1, -1);
                    break;
                default:
                    GL.glTexCoord2d(0, 0); GL.glVertex2f(-1, -1);
                    GL.glTexCoord2d(1, 0); GL.glVertex2f(1, -1);
                    GL.glTexCoord2d(1, 1); GL.glVertex2f(1, 1);
                    GL.glTexCoord2d(0, 1); GL.glVertex2f(-1, 1);
                    break;
            }
            GL.glEnd();
            GL.glFinish();
        }

        protected override void InitGLContext()
        {
            base.InitGLContext();

            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.glOrtho(-1, 1, -1, 1, 1, -1);
            GL.glGenTextures(1, texID); //where 1 is the count, and texID a new texture slot in the gpu
        }               

        protected override void OnMouseMove(MouseEventArgs s)
        {
            if (((MouseEventArgs)s).Button == MouseButtons.Left)
            {
                Update_DisplayRange(((MouseEventArgs)s).X, ((MouseEventArgs)s).Y);
                base.OnMouseMove(s);
            }
        }

        protected override void OnMouseUp(MouseEventArgs s)
        {
            Viewer.UpdateTextCallback UpdateText = FPD.Form_Main.form_display.Pixel_Info;
            if (((MouseEventArgs)s).Button == MouseButtons.Left)
            {
                //Viewer.Save_current_tobackup();
                try
                {

                    int X = 0, Y = 0;
                    X = ((MouseEventArgs)s).X;
                    Y = ((MouseEventArgs)s).Y;
                    int Rotate_X = 0, Rotate_Y = 0;
                    Rotate_X = (Viewer.rotate_degree == 180) ? this.Width - X : (Viewer.rotate_degree == 90)? Y : (Viewer.rotate_degree == 270)? this.Height - Y : X;
                    Rotate_Y = (Viewer.rotate_degree == 180) ? this.Height - Y : (Viewer.rotate_degree == 90) ? this.Width - X : (Viewer.rotate_degree == 270) ?  X : Y;
                    Color pixel = Viewer.bmp_backup.GetPixel(Rotate_X * 4, Rotate_Y * 4);
                    Invoke(UpdateText, new Object[] { null, $"X : {Rotate_X * 4}, Y : {Rotate_Y * 4}, Gray Value : {pixel.GetBrightness()} ", null, null });

                    Viewer.Mouse.X = ((MouseEventArgs)s).X * 4;
                    Viewer.Mouse.Y = ((MouseEventArgs)s).Y * 4;
                    Update_DisplayRange(((MouseEventArgs)s).X, ((MouseEventArgs)s).Y);
                    base.OnMouseUp(s);
                }
                catch (Exception e)
                {

                }
                
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                Viewer.ZoomIn_Ratio = (Viewer.ZoomIn_Ratio / 2 < 0.125) ? 0.125 : Viewer.ZoomIn_Ratio / 2;
                Update_DisplayRange(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            }
            else
            {
                Viewer.ZoomIn_Ratio = (Viewer.ZoomIn_Ratio * 2 > 1) ? 1 : Viewer.ZoomIn_Ratio * 2;
                Update_DisplayRange(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            }
            base.OnMouseWheel(e);
        }

        public void Update_DisplayRange(double x, double y)
        {
            double C_x = (x / this.Size.Width) * 2 - 1;
            double C_y = ((this.Size.Height - y) / this.Size.Height) * 2 - 1;
            Viewer.Display_Range_L = (C_x - Viewer.ZoomIn_Ratio < -1) ? -1 : (C_x + Viewer.ZoomIn_Ratio > 1) ? (1 - 2 * Viewer.ZoomIn_Ratio) : (C_x - Viewer.ZoomIn_Ratio);
            Viewer.Display_Range_R = Viewer.Display_Range_L + 2* Viewer.ZoomIn_Ratio;
            Viewer.Display_Range_T = (C_y + Viewer.ZoomIn_Ratio > 1) ? 1 : (C_y - Viewer.ZoomIn_Ratio < -1) ? (-1 + 2 * Viewer.ZoomIn_Ratio) : (C_y + Viewer.ZoomIn_Ratio);
            Viewer.Display_Range_D = Viewer.Display_Range_T - 2* Viewer.ZoomIn_Ratio;
        }

        private void Reset_DisplayRange()

        {
            Viewer.Display_Range_L = -1.0;
            Viewer.Display_Range_R = 1.0;
            Viewer.Display_Range_T = 1.0;
            Viewer.Display_Range_D = -1.0;
        }

        private void BuildFont(string text, out byte[] pixBuffer, Font font)
        {
            if (font == null)
                font = new Font("Times New Roman", 22F);
            Color m_color = Color.White;

            Graphics g_ctrl = this.CreateGraphics();
            m_size = g_ctrl.MeasureString(text, font).ToSize() + new Size(1, 0);
            g_ctrl.Dispose();

            pixBuffer = new byte[m_size.Width * m_size.Height * 4];
            Bitmap bitmap = new Bitmap(m_size.Width, m_size.Height);
            Graphics g_bmp = Graphics.FromImage(bitmap);
            Brush brush = new SolidBrush(m_color);

            g_bmp.Clear(System.Drawing.Color.FromArgb(255, 50, 0, 75));
            g_bmp.DrawString(text, font, brush, new Rectangle(0, 0, m_size.Width, m_size.Height));
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            Array.Copy(stream.ToArray(), 54, pixBuffer, 0, pixBuffer.Length);

            stream.Dispose();
            brush.Dispose();
            g_bmp.Dispose();
            bitmap.Dispose();
        }

        private void glPrint(int x, int y, string text)
        {
            Font font = new Font("Times New Roman", 22F);

            this.BuildFont(text, out m_pixBuffer, font);

            GL.glBindTexture(GL.GL_TEXTURE_2D, 0);

            GL.glPushMatrix();
            GL.glLoadIdentity();

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.gluOrtho2D(0.0, (double)this.Width, 0.0, (double)this.Height);

            GL.glRasterPos2i(x, y);

            GL.glEnable(GL.GL_BLEND);
            GL.glDrawPixels(m_size.Width, m_size.Height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, m_pixBuffer);
            GL.glDisable(GL.GL_BLEND);

            GL.glPopMatrix();

            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glPopMatrix();
        }

    }
}
