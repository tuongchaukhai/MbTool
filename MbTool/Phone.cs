using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MbTool
{
    public class PhoneModel
    {
        public Process Process { get; set; }
        public string AdbId { get; set; }
        public bool Action { get; set; }
        public bool Sound { get; set; }

        public TimerSet timerSet = new TimerSet(); //mỗi Phone đều có riêng các timer
        public IMGSearch imgSearch = new IMGSearch(); //..
        public Action action = new Action(); // ..
    }

    public class PhoneData
    {
        public static ObservableCollection<PhoneModel> phoneList = new ObservableCollection<PhoneModel>(); //Mấy các kiểu collection này là dùng để chứa tập hợp các <...> 

        public void AddPhone()
        {
            Process[] processes = Process.GetProcessesByName(Setting.ProcessName); //lấy processName từ class Setting
            //Duyệt tìm xem có process nào chưa tồn tại trong phoneList không, có thì cho vào notInPhoneList
            var notInPhoneList = processes.Where(p => !phoneList.Any(phone => phone.Process.MainWindowHandle == p.MainWindowHandle));
            var phonesToAdd = notInPhoneList.Select(phoneProcess => new PhoneModel
            {
                Process = phoneProcess,
                AdbId = PhoneADBIDGet(phoneProcess.MainWindowTitle)
            }).ToList();

            foreach (var phone in phonesToAdd)
            {
                phoneList.Add(phone);
            }
        }

        public void RemovePhone()
        {
            Process[] processes = Process.GetProcessesByName(Setting.ProcessName);

            //tìm những phone nào trong phoneList không còn tồn tại trong process (tức là đã tắt) thì sẽ cho hết vào phoneModelsNotRunning
            var phoneModelsNotRunning = phoneList.Where(phone => !processes.Any(process => process.MainWindowHandle == phone.Process.MainWindowHandle)).ToList();

            phoneModelsNotRunning.ForEach(phone => phone.timerSet.TimerStopAll()); //mỗi cái trong phoneModelsNotRunning sẽ thực hiện TimerStop
            foreach (var phone in phoneModelsNotRunning)
            {
                phoneList.Remove(phone);
            }
        }

        private static string PhoneADBIDGet(string phoneProcess)
        {
            string fileContent = File.ReadAllText(@".settings\PhoneConfig.ini");
            string[] lines = fileContent.Split('\n'); //mỗi "\n" (ký hiệu xuống dòng) sẽ tương ứng với một line được lưu trong mảng lines
            foreach (string line in lines)
            {
                if (line.Contains(phoneProcess))
                {
                    string[] parts = line.Split('|'); // phân tách thông tin mỗi dòng dựa theo "|" đã lưu trong .ini
                    if (parts.Length == 2)
                    {
                        string proc = parts[0].Trim(); // xóa khoảng trắng ở đầu và cuối chuỗi
                        string id = parts[1].Trim(); // xóa khoảng trắng ở đầu và cuối chuỗi
                        return id; //trả về id
                    }
                }
            }
            return null; //không thấy thì trả về null
        }
    }
}
