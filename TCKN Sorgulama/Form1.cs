using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCKNReference;
using Exception = System.Exception;

namespace TCKN_Sorgulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool? durum;
        private async void button1_Click(object sender, EventArgs e)
        {

            long tckn = long.Parse(txtTCKN.Text);
            int dogumyili = int.Parse(txtDogumYili.Text);
            var client = new TCKNReference.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            bool? durum;

            try
            {
               var response= await client.TCKimlikNoDogrulaAsync(tckn, txtAD.Text, txtSoyad.Text, dogumyili);
               durum = response.Body.TCKimlikNoDogrulaResult;

            }
            catch
            {
                durum = null;
            }

            MessageBox.Show(durum.ToString());
        }
    }
}