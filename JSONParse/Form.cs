using JSONParseClass;
using Newtonsoft.Json;

namespace JSONParse
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ParseJSONFile.ParseDevice(ofd.FileName);
            }
        }
    }
}