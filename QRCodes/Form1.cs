using System.Windows.Forms;
using System.Drawing;
using QREncodeDecodeLibrary;

namespace QRCodes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string text = textBoxText.Text;
            string fileName = textBoxFile.Text;

            // Static, so this is not necessary: EncodeDecode encodeDecode = new EncodeDecode();
            string result = QREncodeDecode.EncodeTextToQRImage(text, fileName);
            string decoded = QREncodeDecode.DecodeQRImageToText(fileName);
            ; // just to be able to set a stop
        }
    }
}
