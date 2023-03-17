using Newtonsoft.Json;
using Parsing;

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
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html)|*.html|Textual Files (*.txt)| *.txt|CSV Files (*.csv)|*.csv";
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
                else if (extension == ".html")
                {
                    textBox1.Text = ParseHTMLFile.Parse(ofd.FileName);
                }
                else if(extension == ".txt")
                {
                    textBox1.Text = ParseTXTFile.Parse(ofd.FileName); 
                }
                else if (extension == ".csv")
                {
                    textBox1.Text = ParseCSVFile.Parse(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Invalid file type. Please select a JSON, XML or HTML file.");
                }
            }
        }
    }
}