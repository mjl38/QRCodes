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
                Height = 200,
                DisableECI = true,
                CharacterSet = "UTF-8"
            };
            writer.Options = options;

            try
            {
                Bitmap result = writer.Write(text);
                result.Save(imageFilename);
                result.Dispose();
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
            BarcodeReader reader = new BarcodeReader {AutoRotate = true, TryInverted = true };

            //// this doesn't seem to be necessary for decoding:
            //ZXing.Common.DecodingOptions options = new ZXing.Common.DecodingOptions();
            //options.CharacterSet = "UTF-8";

            // TODO: check if this could facilitate different formats?
            //options.PossibleFormats
            //reader.Options = options;

            string result = "";
            
            try
            {
                Bitmap bmp = (Bitmap)imageFile;
                result = reader.Decode(bmp).ToString();
                bmp.Dispose();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}
