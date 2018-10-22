//All Images Courtesy of WikiMedia
namespace Didstopia.PDFSharp.Tests.Images
{
    public class TestImages
    {
        public TestImages()
        {
            this.W3CBmp = getImage("w3c_home.bmp");
            this.W3CGif = getImage("w3c_home.gif");
            this.W3CJpg = getImage("w3c_home.jpg");
            this.W3CPng = getImage("w3c_home.png");
            this.W3C2Bmp = getImage("w3c_home_2.bmp");
            this.W3C2Gif = getImage("w3c_home_2.gif");
            this.W3C2Jpg = getImage("w3c_home_2.jpg");
            this.W3C2Png = getImage("w3c_home_2.png");
            this.W3C256Bmp = getImage("w3c_home_256.bmp");
            this.W3C256Gif = getImage("w3c_home_256.gif");
            this.W3C256Jpg = getImage("w3c_home_256.jpg");
            this.W3C256Png = getImage("w3c_home_256.png");
            this.W3CAnimationGif = getImage("w3c_home_animation.gif");
            this.W3CAnimationMng = getImage("w3c_home_animation.mng");
            this.W3CGrayBmp = getImage("w3c_home_gray.bmp");
            this.W3CGrayGif = getImage("w3c_home_gray.gif");
            this.W3CGrayJpg = getImage("w3c_home_gray.jpg");
            this.W3CGrayPng = getImage("w3c_home_gray.png");
        }

        public byte[] W3CBmp { get; }
        public byte[] W3CGif { get; }
        public byte[] W3CJpg { get; }
        public byte[] W3CPng { get; }
        public byte[] W3C2Bmp { get; }
        public byte[] W3C2Gif { get; }
        public byte[] W3C2Jpg { get; }
        public byte[] W3C2Png { get; }
        public byte[] W3C256Bmp { get; }
        public byte[] W3C256Gif { get; }
        public byte[] W3C256Jpg { get; }
        public byte[] W3C256Png { get; }
        public byte[] W3CAnimationGif { get; }
        public byte[] W3CAnimationMng { get; }
        public byte[] W3CGrayBmp { get; }
        public byte[] W3CGrayGif { get; }
        public byte[] W3CGrayJpg { get; }
        public byte[] W3CGrayPng { get; }

        private byte[] getImage(string imageName)
        {
            imageName = $"Didstopia.PDFSharp.Tests.Images.{imageName}";
            var assembly = typeof(TestImages).Assembly;
            using (var resFilestream = assembly.GetManifestResourceStream(imageName))
            {
                if (resFilestream == null) return null;
                byte[] bytes = new byte[resFilestream.Length];
                resFilestream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }
    }
}

