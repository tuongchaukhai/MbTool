using System;
using System.Windows.Threading;

namespace MbTool
{
    public class TimerSet
    {
        private DispatcherTimer timerCheckShop, timerClick, timerCheck, timerBuy, timerRelog, timerTS;
        public bool isTimerCheckShopRunning, isTimerClickRunning, isTimerCheckRunning, isTimerBuyRunning, isTimerRelogRunning, isTimerTSRunning;

        public void TimerCheckShop_Start(PhoneModel phone)
        {
            timerCheckShop = new DispatcherTimer();
            timerCheckShop.Tick += (sender, e) => TimerCheckShop_Tick(sender, e, phone);
            timerCheckShop.Interval = new TimeSpan(0, 0, 0, 0, Setting.DelayCheckShop);
            timerCheckShop.Start();
            isTimerCheckShopRunning = true;
        }
        public void TimerCheckShop_Stop()
        {
            if (isTimerCheckShopRunning)
            {
                timerCheckShop.Stop();
                timerCheckShop = null; //xóa timer đó đi = cách set null
                isTimerCheckShopRunning = false;
            }
        }
        private void TimerCheckShop_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            phone.imgSearch.Shop(phone);
        }
        
        public void TimerClick_Start(PhoneModel phone)
        {
            timerClick = new DispatcherTimer();
            timerClick.Tick += (sender, e) => TimerClick_Tick(sender, e, phone);
            timerClick.Interval = new TimeSpan(0, 0, 0, 0, Setting.DelayClick);
            timerClick.Start();
            isTimerClickRunning = true;
        }
        public void TimerClick_Stop()
        {
            if (isTimerClickRunning)
            {
                timerClick.Stop();
                timerClick = null;
                isTimerClickRunning = false;
            }
        }
        private void TimerClick_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            phone.action.Clickk(phone.AdbId);
        }

        public void TimerCheck_Start(PhoneModel phone)
        {
            timerCheck = new DispatcherTimer();
            timerCheck.Tick += (sender, e) => TimerCheck_Tick(sender, e, phone);
            timerCheck.Interval = new TimeSpan(0, 0, 0, 0, Setting.DelayCheckDis);
            timerCheck.Start();
            isTimerCheckRunning = true;
        }
        public void TimerCheck_Stop()
        {
            if (isTimerCheckRunning)
            {
                timerCheck.Stop();
                timerCheck = null;
                isTimerCheckRunning = false;
            }

        }
        private void TimerCheck_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            //CheckDced();
        }

        public void TimerBuy_Start(PhoneModel phone)
        {
            timerBuy = new DispatcherTimer();
            timerBuy.Tick += (sender, e) => TimerBuy_Tick(sender, e, phone);
            timerBuy.Interval = new TimeSpan(0, 0, 0, 0, Setting.DelayBuy);
            timerBuy.Start();
            isTimerBuyRunning = true;
        }
        public void TimerBuy_Stop()
        {
            if (isTimerBuyRunning)
            {
                timerBuy.Stop();
                timerBuy = null;
                isTimerBuyRunning = false;
            }
        }
        private void TimerBuy_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            phone.imgSearch.Buy(phone);
        }

        public void TimerRelog_Start(PhoneModel phone)
        {
            timerRelog = new DispatcherTimer();
            timerRelog.Tick += (sender, e) => TimerRelog_Tick(sender, e, phone);
            timerRelog.Interval = new TimeSpan(0, 0, 0, 0, 2500);
            timerRelog.Start();
            isTimerRelogRunning = true;
        }
        public void TimerRelog_Stop()
        {
            if (isTimerRelogRunning)
            {
                timerRelog.Stop();
                timerRelog = null;
                isTimerRelogRunning = false;
            }
        }
        private void TimerRelog_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            //  Relog();
        }

        public void TimerTS_Start(PhoneModel phone)
        {
            timerTS = new DispatcherTimer();
            timerTS.Tick += (sender, e) => TimerTS_Tick(sender, e, phone);
            timerTS.Interval = new TimeSpan(0, 0, 0, 0, 2000);
            timerTS.Start();
            isTimerTSRunning = true;
        }
        public void TimerTS_Stop()
        {
            if (isTimerTSRunning)
            {
                timerTS.Stop();
                timerTS = null;
                isTimerTSRunning = false;
            }
        }
        private void TimerTS_Tick(object sender, EventArgs e, PhoneModel phone)
        {
            //  Relog();
        }

        public void TimerStopAll()
        {
            TimerCheckShop_Stop();
            TimerClick_Stop();
            TimerCheck_Stop();
            TimerBuy_Stop();
            TimerRelog_Stop();
            TimerTS_Stop();
        }
    }
}
