using Newtonsoft.Json;
using Parsing;

namespace JSONParse
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string fileName;
        public string extension;
        public Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html)|*.html|Textual Files (*.txt)| *.txt|CSV Files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                extension = Path.GetExtension(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Path.GetFileName(fileName);
            if (extension == ".json")
            {
                textBox1.Text = ParseJSONFile.ParseDevice(fileName);
            }
            else if (extension == ".xml")
            {
                textBox1.Text = ParseXMLFile.ParseDevice(fileName);
            }
            else if (extension == ".html")
            {
                textBox1.Text = ParseHTMLFile.Parse(fileName);
            }
            else if (extension == ".txt")
            {
                textBox1.Text = ParseTXTFile.Parse(fileName);
            }
            else if (extension == ".csv")
            {
                textBox1.Text = ParseCSVFile.Parse(fileName);
            }
            else
            {
                MessageBox.Show("Invalid file type. Please select a JSON, XML or HTML file.");
            }
        }
    }
}