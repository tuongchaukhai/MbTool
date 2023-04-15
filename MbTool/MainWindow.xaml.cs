using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MbTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhoneData pdata = new PhoneData();

        DispatcherTimer timerProcess = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(Setting.DelayProcess) };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PhoneModel();
            timerProcess.Tick += TimerProcess_Tick;
            timerProcess.Start();
        }

        private bool isTaskExecuting = false;

        void TimerProcess_Tick(object sender, EventArgs e)
        {
            if (isTaskExecuting)
            {
                return; // Nếu tác vụ đang được thực thi, không làm gì hết
            }

            isTaskExecuting = true;

            try
            {
                //thêm vào datagird
                pdata.AddPhone(); //thực hiện chạy hàm AddPhone bên phonedata kiểm tra //trong AddPhone này nếu duyệt được sẽ thêm vào phoneList cho nên bước tiếp theo duyệt phoneList

                pdata.RemovePhone(); //hàm này sẽ xóa những item trong phoneList nào không còn tồn tại (đã tắt) trong process[].

                myDataGrid.ItemsSource = PhoneData.phoneList;
            }
            finally //kết thúc "try"
            {
                isTaskExecuting = false; 
            }
        }

        private void myDataGrid_SizeChanged(object sender, SizeChangedEventArgs e) //mỗi khi cái datagrid thay đổi size (thêm 1 dòng sẽ thay đổi height) thì: 
        {
            double gridWidth = myDataGrid.ActualWidth; //lấy width của myDataGrid
            double gridHeight = myDataGrid.ActualHeight; //lấy height
            double windowWidth = gridWidth + 40; 
            double windowHeight = gridHeight + 60;

            this.Width = windowWidth; //this tức là cái width của form này
            this.Height = windowHeight;

            this.Title = "MbTool | COUNT : " + PhoneData.phoneList.Count;
        }

        private void btnAction_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var phone = ((Label)sender).Tag as PhoneModel;
            if (phone != null)
            {
                Label item = sender as Label;
                if (item.Content.ToString() == "START")
                {
                    item.Background = Brushes.Blue;
                    item.Content = "STOP";
                    phone.Action = true;
                    phone.timerSet.TimerCheckShop_Start(phone);
                }
                else if (item.Content.ToString() == "STOP")
                {
                    item.Background = Brushes.White;
                    item.Content = "START";
                    phone.Action = false;
                    phone.timerSet.TimerCheckShop_Stop();
                }
                //phone.Type =  item.Type.Content
            }

        }

        private void btnSound_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var phone = ((Label)sender).Tag as PhoneModel; //Tag: này nó sẽ lấy ra cái phone mà mình tác động đến nút.

            if (phone != null)
            {
                Label item = sender as Label;
                if (item.Content.ToString() == "OFF") 
                {
                    item.Background = Brushes.Brown;
                    item.Content = "ON";
                    phone.Sound = true; //ở mấy cái hàm quét mỗi khi quét thấy thì check if(phone.Sound == true) { //blabla }
                }
                else if (item.Content.ToString() == "ON")
                {
                    item.Background = Brushes.White;
                    item.Content = "OFF";
                    phone.Sound = false;
                }
            }
        }

        private void myDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        //Thiết lâp sắp xếp, bởi vì mỗi lần nhấn Sort thì nó sẽ sắp xếp theo kiểu asc hoặc desc, ở đây tạo ra mục đích chỉ cho nó sort theo asc
        {
            DataGridColumn column = myDataGrid.Columns[0]; //columns 0 là cột đầu
            if (myDataGrid != null)
            {
                // Sắp xếp theo cột và kiểu tăng dần
                myDataGrid.Items.SortDescriptions.Clear();
                myDataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Descending));
                column.SortDirection = ListSortDirection.Descending;

                // Cập nhật lại view
                myDataGrid.Items.Refresh();
            }
        }


    }

}
