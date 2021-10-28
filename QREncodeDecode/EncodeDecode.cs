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
            System.Drawing.Imaging.ImageFormat imgFormat;
            string imgExtension = imageFilename.ToLower().Substring(imageFilename.LastIndexOf('.') + 1);
            
            switch (imgExtension) {
                case "gif":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case "bmp":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case "jpg":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case "jpeg":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case "png":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                case "tiff":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Tiff;
                    break;
                case "wmf":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Wmf;
                    break;
                case "emf":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Emf;
                    break;
                case "ico":
                    imgFormat = System.Drawing.Imaging.ImageFormat.Icon;
                    break;
                default:
                    return "Image format not supported! (based on the extension of the filename).";
            }

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
                result.Save(imageFilename, imgFormat);
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
