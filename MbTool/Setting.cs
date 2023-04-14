using System.IO;

namespace MbTool
{
    public class Setting
    {
        public static string ProcessName = "notepad";
        public static int SizeHeightFix { get; } = int.Parse(File.ReadAllText(@".settings\heightFix.txt").Trim());
        public static int AccuracyOfAutoQuest { get; } = int.Parse(File.ReadAllText(@".settings\Delay.txt").Trim());
        public static int DelayBuy { get; } = int.Parse(File.ReadAllText(@".settings\DelayBuy.txt").Trim());
        public static int DelayCheckShop { get; } = int.Parse(File.ReadAllText(@".settings\DelayCheckShop.txt").Trim());
        public static int DelayCheckDis { get; } = int.Parse(File.ReadAllText(@".settings\DelayCheckDis.txt").Trim());
        public static int DelayClick { get; } = int.Parse(File.ReadAllText(@".settings\DelayClick.txt").Trim());

        public static int DelayProcess = 1000;

    }
}
