using System;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

namespace QREncodeDecodeLibrary
{
    public class QREncodeDecode
    {
        public static string EncodeTextToQRImage(string text, string imageFilename)
        {
            BarcodeWriter writer = new BarcodeWriter();

            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                Width = 200,
                Height = 200
            };
            writer.Options = options;

            try
            {
                Bitmap result = writer.Write(text);
                result.Save(imageFilename);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "SUCCESS"; 
        }

        public static string DecodeQRImageToText(string imageFilename)
        {
            Image imageFile = Image.FromFile(imageFilename) as Bitmap;
            BarcodeReader reader = new BarcodeReader();

            string result = "";
            
            try
            {
                result = reader.Decode((Bitmap)imageFile).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}
