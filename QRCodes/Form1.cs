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
            string result = QREncodeDecode.EncodeTextToQRImage("hello my name is migueliiiito", "c:/temp2/hello.png");
            result = QREncodeDecode.DecodeQRImageToText("c:/temp2/hello.png");
            result = "";
        }
    }
}
