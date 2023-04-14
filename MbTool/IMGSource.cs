using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;

namespace MbTool
{
    public class IMGSource
    {
        private const string ScansPath = @".scans\";
        
        public static Image<Bgr, byte> Found { get; } = GetImage("Found.bmp");
        public static Image<Bgr, byte> FoundCheck { get; } = GetImage("FoundCheck.bmp");
        public static Image<Bgr, byte> Buy { get; } = GetImage("Buy.bmp");
        public static Image<Bgr, byte> BuyConfirm { get; } = GetImage("BuyConfirm.bmp");
        public static Image<Bgr, byte> Confirm { get; } = GetImage("Confirm.bmp");
        public static Image<Bgr, byte> Dced { get; } = GetImage("Relog\\Dced.bmp");
        public static Image<Bgr, byte> Dced2 { get; } = GetImage("Relog\\Dced2.bmp");
        public static Image<Bgr, byte> MapleIcon { get; } = GetImage("Relog\\Mapleicon.bmp");
        public static Image<Bgr, byte> MapleIcon2 { get; } = GetImage("Relog\\Mapleicon2.bmp");
        public static Image<Bgr, byte> XIcon { get; } = GetImage("Relog\\Xicon.bmp");
        public static Image<Bgr, byte> XIcon1 { get; } = GetImage("Relog\\Xicon1.bmp");
        public static Image<Bgr, byte> XIcon2 { get; } = GetImage("Relog\\Xicon2.bmp");
        public static Image<Bgr, byte> XIcon3 { get; } = GetImage("Relog\\Xicon3.bmp");
        public static Image<Bgr, byte> XIcon4 { get; } = GetImage("Relog\\Xicon4.bmp");
        public static Image<Bgr, byte> Package { get; } = GetImage("Relog\\Package.bmp");
        public static Image<Bgr, byte> InGame { get; } = GetImage("Relog\\InGame.bmp");
        public static Image<Bgr, byte> Ready { get; } = GetImage("Relog\\Ready.bmp");
        public static Image<Bgr, byte> HotNew { get; } = GetImage("Relog\\Hot&New.bmp");
        public static Image<Bgr, byte> Update { get; } = GetImage("Relog\\Update.bmp");
        public static Image<Bgr, byte> PetEnd { get; } = GetImage("Relog\\Update.bmp");
        public static Image<Bgr, byte> CharacterScreen { get; } = GetImage("Relog\\Update.bmp");
        public static Image<Bgr, byte> NotArmor { get; } = GetImage("TS\\NotArmor.bmp");
        public static Image<Bgr, byte> Off { get; } = GetImage("TS\\Off.bmp");
        public static Image<Bgr, byte> Display { get; } = GetImage("TS\\Display.bmp");
        public static Image<Bgr, byte> TSS { get; } = GetImage("TS\\TS.bmp");
        public static Image<Bgr, byte> Setting { get; } = GetImage("TS\\Setting.bmp");


        private static Dictionary<string, Image<Bgr, byte>> imageDict = new Dictionary<string, Image<Bgr, byte>>();

        private static Image<Bgr, byte> GetImage(string imageName)
        {
            if (!imageDict.ContainsKey(imageName))
            {
                var image = new Image<Bgr, byte>(ScansPath + imageName);
                imageDict[imageName] = image;
            }
            return imageDict[imageName];
        }


    }
}
