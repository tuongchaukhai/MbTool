using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MbTool
{
    public class IMGSearch
    {
        public Bitmap bitmapp;

        public void Shop(PhoneModel phone)
        {
            phone.action.Click(phone, 300, 300);
            ////if (IMSes.NormalSearch(phone.Process.MainWindowHandle, bitmapp, 649, 349, 654, 357, Found, 0.99) == false)
            //if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 600, 300, 700, 400, IMGSource.Found, 0.99) == false)
            ////if (IMSes.NormalSearch(phone.Process.MainWindowHandle, bitmapp, 500, 250, 800, 500, Found, 0.99) == false)
            //{
            //    phone.timerSet.TimerBuy_Start(phone);
            //    phone.timerSet.TimerClick_Stop();
            //    phone.timerSet.TimerCheckShop_Stop();
            //}
        }

        int tempcount;
        public async void Buy(PhoneModel phone)
        {
            tempcount++;
            phone.action.Click(phone, 530, 300);
            await Task.Delay(33);
            phone.action.Click(phone, 730, 515);
            await Task.Delay(33);
            phone.action.Click(phone, 595, 450);

            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 440, 410, 525, 440, IMGSource.Confirm, 0.97) == true)
            {
                phone.action.Click(phone, 484, 428);
                await Task.Delay(33);
            }
            //if (IMSes.NormalSearch(phone.Process.MainWindowHandle, bitmapp, 70, 155, 140, 200, FoundCheck, 0.97) == true)
            //{
            //   ADBClick(530, 300);
            //    await Task.Delay(33); ;
            //}
            //if (IMSes.NormalSearch(phone.Process.MainWindowHandle, bitmapp, 700, 500, 750, 540, Buyy, 0.97) == true)
            //{
            //   ADBClick(730, 515);
            //    await Task.Delay(33);
            //   ADBClick(595, 450);
            //}
            //if (IMSes.NormalSearch(phone.Process.MainWindowHandle, bitmapp, 430, 265, 535, 300, BuyConfirm, 0.97) == true)
            //{
            //   ADBClick(595, 450);
            //    tempbuy++;
            //}
        }

        public async void CheckDced(PhoneModel phone)
        {
            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 60, 280, 240, 450, IMGSource.MapleIcon, 0.97) == true)
            {
                tempcount = 0;
                phone.timerSet.TimerBuy_Stop();
                phone.action.Click(phone, 500, 15);
                await Task.Delay(1000);
                phone.action.Click(phone, 500, 323);
                await Task.Delay(1000);
                phone.timerSet.TimerRelog_Start(phone);
                await Task.Delay(200);
                return;
            }
            if ((NormalSearch(phone.Process.MainWindowHandle, bitmapp, 600, 300, 700, 400, IMGSource.Found, 0.97) == true) && phone.timerSet.isTimerBuyRunning)
            {
                return;
            }
            if ((NormalSearch(phone.Process.MainWindowHandle, bitmapp, 200, 150, 800, 450, IMGSource.Dced, 0.97) == true)
            || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 200, 150, 800, 450, IMGSource.Dced2, 0.97) == true)
            || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 60, 280, 240, 450, IMGSource.MapleIcon, 0.97) == true)
            || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 60, 280, 240, 450, IMGSource.MapleIcon2, 0.97) == true))
            {
                tempcount = 0;
                phone.  timerSet.TimerBuy_Stop();
                phone.action.Click(phone, 500, 15);
                await Task.Delay(1000);
                phone.action.Click(phone, 500, 323);
                await Task.Delay(1000);
                phone.timerSet.TimerRelog_Start(phone);
                return;
            }
            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 370, 240, 950, 480, IMGSource.Found, 0.99) == true || tempcount > 250)
            {
                tempcount = 0;
                phone.timerSet.TimerBuy_Stop();
                phone.timerSet.TimerClick_Start(phone);
                await Task.Delay(Setting.DelayClick);
                phone.timerSet.TimerCheckShop_Start(phone);
            }

            if ((NormalSearch(phone.Process.MainWindowHandle, bitmapp, 700, 40, 900, 150, IMGSource.XIcon1, 0.75) == true)
                || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 700, 40, 900, 150, IMGSource.XIcon2, 0.75) == true)
                || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 700, 40, 900, 150, IMGSource.XIcon3, 0.75) == true)
                || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 700, 40, 900, 150, IMGSource.XIcon4, 0.75) == true))
            {
                phone.action.Click(phone, 830, 85);
                await Task.Delay(1000);
                phone.action.Click(phone, 830, 85);
                await Task.Delay(1000);
                phone.action.Click(phone, 830, 85);
                await Task.Delay(1000);
            }
            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 1, 30, 300, 150, IMGSource.Package, 0.95) == true)
            {
                phone.action.Click(phone, 830, 85);
                await Task.Delay(1000);
                phone.action.Click(phone, 933, 60);
                await Task.Delay(1000);
            }
            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 320, 80, 385, 135, IMGSource.PetEnd, 0.95) == true)
            {
                phone.action.Click(phone, 685, 105);
                await Task.Delay(1000);
            }
            //if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 600, 200, 800, 400, InGame, 0.95) == true)
            if (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 900, 85, 950, 155, IMGSource.InGame, 0.95) == true)
            {
                tempcount = 0;
                phone.timerSet.TimerBuy_Stop();
                phone.timerSet.TimerClick_Stop();
                phone.timerSet.TimerCheckShop_Stop();
                phone.timerSet.TimerTS_Start(phone);
                return;
            }
            if ((NormalSearch(phone.Process.MainWindowHandle, bitmapp, 600, 300, 800, 500, IMGSource.TSS, 0.95) == true) || (NormalSearch(phone.Process.MainWindowHandle, bitmapp, 775, 425, 950, 560, IMGSource.Setting, 0.95) == true))
            {
                tempcount = 0;
                phone.timerSet.TimerBuy_Stop();
                phone.timerSet.TimerClick_Stop();
                phone.timerSet.TimerCheckShop_Stop();
                phone.timerSet.TimerTS_Start(phone);
                return;
            }

        }

        const uint PW_RENDERFULLCONTENT = 0x00000002;
        const uint PW_CLIENTONLY = 0x00000001;

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);

        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);

        static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        public static Bitmap Crop(IntPtr handle)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
            GetWindowRect(handle, ref rect);
            Bitmap bitmap = new Bitmap(rect.Width - rect.X, rect.Height - rect.Y);
            return bitmap;
        }


        #region Normal Search

        //public static bool NormalSearch(IntPtr handle, Bitmap bitmapp, int x, int y, int xx, int yy, Image<Bgr, byte> image, double accuracy = 0.96)
        //{

        //    using (Graphics g = Graphics.FromImage(bitmapp))
        //    {
        //        IntPtr hdc = g.GetHdc();
        //        PrintWindow(handle, hdc, 0x00000002);
        //        g.ReleaseHdc(hdc);
        //    }
        //    bitmapp = CropImage(bitmapp, new Rectangle(new Point(x, y), new Size(xx - x, yy - y)));
        //    Image<Bgr, byte> source = new Image<Bgr, byte>(bitmapp);
        //    //bitmapp.Save("test.png");
        //    bitmapp.Dispose();

        //    using (Image<Gray, float> result = source.MatchTemplate(image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
        //    {
        //        double[] minValues, maxValues;
        //        Point[] minLocations, maxLocations;
        //        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

        //        if (maxValues[0] > accuracy)
        //        {
        //            result.Dispose();
        //            return true;
        //        }
        //        else
        //        {
        //            result.Dispose();
        //            return false;
        //        }
        //    }
        //}


        public bool NormalSearch(IntPtr handle, Bitmap bitmap, int x, int y, int xx, int yy, Image<Bgr, byte> image, double accuracy)
        {
            Rectangle rect = new Rectangle(x, y, xx - x, yy - y);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = g.GetHdc();
                try
                {
                    PrintWindow(handle, hdc, 0x00000002);
                }
                finally
                {
                    g.ReleaseHdc(hdc);
                }
            }

            using (Bitmap croppedBitmap = new Bitmap(rect.Width, rect.Height))
            {
                using (Graphics g = Graphics.FromImage(croppedBitmap))
                {
                    g.DrawImage(bitmap, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
                }

                using (Image<Bgr, byte> source = new Image<Bgr, byte>(croppedBitmap))
                {
                    using (Image<Gray, float> result = source.MatchTemplate(image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                    {
                        double[] minValues, maxValues;
                        Point[] minLocations, maxLocations;
                        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                        if (maxValues[0] > accuracy)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }


        public static Point SearchReturn(IntPtr handle, int x, int y, int xx, int yy, string imgTargetPath, double accuracy = 0.96)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
            GetWindowRect(handle, ref rect);

            Bitmap bitmap = new Bitmap(rect.Width - rect.X, rect.Height - rect.Y);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = g.GetHdc();
                PrintWindow(handle, hdc, 0);
                g.ReleaseHdc(hdc);
            }

            yy = yy + Setting.SizeHeightFix;
            y = y + Setting.SizeHeightFix;

            bitmap = CropImage(bitmap, new Rectangle(new Point(x, y), new Size(xx - x, yy - y)));

            Image<Bgr, byte> source = new Image<Bgr, byte>(bitmap);
            Image<Bgr, byte> template = new Image<Bgr, byte>(imgTargetPath);

            //bitmap.Save("test.png");
            bitmap.Dispose();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > accuracy)
                {
                    Point temp = new Point(maxLocations[0].X + (template.Size.Width / 2) + x, maxLocations[0].Y + (template.Size.Height / 2) + y); //lấy ra toạ độ giữa ảnh
                    template.Dispose();
                    return temp;

                }
                else
                {
                    template.Dispose();
                    return new Point(-1, -1);
                }
            }
        }

        #endregion

        #region Mini Search

        static int[][] pos;
        static int regionCount; //số lượng vùng quét

        public static void SetPos()
        {
            string[] regions = System.IO.File.ReadAllLines(@".settings\pos.txt"); //đọc file lấy ra từng dòng (vùng) cho vào mảng regions
            regionCount = regions.Length; //lấy ra số lượng vùng
            pos = new int[regionCount][]; //khai báo số lượng mảng (vùng) cần tạo cho pos

            for (int i = 0; i < regionCount; i++) //chạy từng vùng
            {
                char[] separator = new char[] { '|' };
                string[] xyxxyy = regions[i].Split(separator); //tách lấy ra x,y,xx,yy giữa mỗi "|"

                pos[i] = new int[4];
                for (int j = 0; j < 4; j++) //chạy cho mỗi điểm x y xx yy (=> là 4)
                {
                    pos[i][j] = Convert.ToInt32(xyxxyy[j]); //nạp vào x,y,xx,yy cho mỗi vùng quét
                }
            }
            //pos[0][0] = 0; pos[0][1] = 0; pos[0][2] = 100; pos[0][3] = 100;  //x,y,xx,yy
            //pos[1][0] = 100; pos[1][1] = 0; pos[1][2] = 100; pos[1][3] = 100;
            //pos[2][0] = 200; pos[2][1] = 0; pos[2][2] = 100; pos[2][3] = 100;
            //pos[3][0] = 300; pos[3][1] = 0; pos[3][2] = 100; pos[3][3] = 100;
        }

        public static int SearchME(IntPtr handle, string imgTargetPath, double accuracy = 0.90)
        {
            int region = -1;
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
            GetWindowRect(handle, ref rect);

            Bitmap bitmap = new Bitmap(rect.Width - rect.X, rect.Height - rect.Y);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = g.GetHdc();
                PrintWindow(handle, hdc, 0); //in màn hình inactiveWindow vào bitmap
                g.ReleaseHdc(hdc);
            }
            for (int i = 0; i < regionCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Bitmap bitmapClone = CropImage(bitmap, new Rectangle(new Point(pos[i][0], pos[i][1]), new Size(pos[i][2], pos[i][3]))); //cắt ra vùng quét nhỏ từ bitmap fullscreen

                    Image<Bgr, byte> source = new Image<Bgr, byte>(bitmapClone);
                    Image<Bgr, byte> template = new Image<Bgr, byte>(imgTargetPath);

                    bitmapClone.Save("test" + i + ".png");

                    using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                    {
                        double[] minValues, maxValues;
                        Point[] minLocations, maxLocations;
                        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                        if (maxValues[0] > accuracy)
                        {
                            bitmapClone.Dispose();
                            bitmap.Dispose();
                            return region = i; //xuất ra vùng tìm thấy 
                        }
                        bitmapClone.Dispose();
                    }
                }
            }
            bitmap.Dispose();
            return region; //nếu không tìm thấy return -1;
        }

        #endregion
    }
}
