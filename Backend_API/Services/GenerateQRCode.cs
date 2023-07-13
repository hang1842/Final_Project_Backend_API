using QRCoder;
using System.Drawing;
using System.Text;

namespace Backend_API.Services
{
    public class GenerateQRCode
    {
        public void generateQRCode(string level, string message)
        {
            QRCodeGenerator.ECCLevel eCCLevel = (QRCodeGenerator.ECCLevel)
                (level =="L" ? 0:level == "M"? 1:level=="Q" ? 2:3);
            int size = 10;

            byte[] MessageText = new UnicodeEncoding().GetBytes(message);

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using(QRCodeData qRCodeData = qrGenerator.CreateQrCode(MessageText, eCCLevel))
                {
                    using(AsciiQRCode qRCoder = new AsciiQRCode(qRCodeData))
                    {
                        //PictureBoxQRCode.BackGroundImage = qRCoder.GetGraphic(20, Color.Black, Color.White, false, size.ToString());
                        //this.PictureBoxQRCode.Size = new System.Drawing.Size(PictureBoxQRCode.width, PictureBoxQRCode.height);
                        //this.PictureBoxQRCode.SizeMode = PictureBoxSizeMode.CenterImage;
                        //this.PictureBoxQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }
    }
}
