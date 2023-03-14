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
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ofd.FileName);
                if (extension == ".json")
                {
                    textBox1.Text = ParseJSONFile.ParseDevice(ofd.FileName);
                }
                else if (extension == ".xml")
                {
                    textBox1.Text = ParseXMLFile.ParseDevice(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Invalid file type. Please select a JSON or XML file.");
                }
            }
        }
    }
}