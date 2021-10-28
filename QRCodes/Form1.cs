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
            //EncodeDecode encodeDecode = new EncodeDecode();
            string text = textBoxText.Text;
            string fileName = textBoxFile.Text;
            
            string result = QREncodeDecode.EncodeTextToQRImage(text, fileName);
            string decoded = QREncodeDecode.DecodeQRImageToText("c:/temp2/hello.png");
            ; // just to be able to set a stop
        }
    }
}
