using System;
using System.Windows.Forms;
using Wsqm;

namespace wsqEncodeDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Decode_Click(object sender, EventArgs e)
        {
            var dec = new Wsq();
            dec.Decode(
                @"C:\Users\cwagner\OneDrive - Sterling Talent Solutions\Documents\Development\Craig's Fingerprints\Rolled_LeftIndex.wsq",
                @"C:\Users\cwagner\OneDrive - Sterling Talent Solutions\Documents\Development\Craig's Fingerprints\Rolled_LeftIndex2.png");
        }

        private void Encode_Click(object sender, EventArgs e)
        {
            var dec = new Wsq();
            var comentario = new[] { "comment1", "comment2" };

            dec.Encode(
                @"C:\Users\cwagner\OneDrive - Sterling Talent Solutions\Documents\Development\Craig's Fingerprints\Rolled_LeftIndex.png",
                @"C:\Users\cwagner\OneDrive - Sterling Talent Solutions\Documents\Development\Craig's Fingerprints\Rolled_LeftIndex.wsq",
                comentario, 0.75f);
        }
    }
}