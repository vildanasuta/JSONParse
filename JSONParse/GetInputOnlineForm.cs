using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseFormsApp
{
    public partial class GetInputOnlineForm : Form
    {
        string path;
        public GetInputOnlineForm()
        {
            InitializeComponent();
        }

        private void GetInputOnlineForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "https://filesamples.com/samples/code/json/sample4.json";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            WebClient client = new WebClient();
            string jsonData = client.DownloadString(url);
            string fileName = Path.GetFileName(url);
            string filePath = Path.Combine(path, fileName);
            File.WriteAllText(filePath, jsonData);
            MessageBox.Show("Successfully saved file to the selected location.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
