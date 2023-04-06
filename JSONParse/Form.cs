using DocumentFormat.OpenXml.CustomProperties;
using Newtonsoft.Json;
using OfficeOpenXml;
using ParseFormsApp.Properties;
using Parsing;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using ParseFormsApp;

namespace JSONParse
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string fileName;
        public string extension;
        public bool isXML = false;
        public bool isJSONForExcel = false;
        public string templatePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "Template.xlsx");
        public Form()
        {
            InitializeComponent();
            button3.Visible = false;
            button4.Visible = false;
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
                string jsonString = File.ReadAllText(fileName);
                if (jsonString.Contains("ports"))
                {
                    textBox1.Text = ParseJSONFile.ParseDevice(fileName);
                    isJSONForExcel = true;
                }
                else if (jsonString.Contains("people"))
                {
                    textBox1.Text = ParseJSONFile.ParsePeopleRegexImpl(fileName);
                    isJSONForExcel = false;
                }
            }
            else if (extension == ".xml")
            {
                textBox1.Text = ParseXMLFile.ParseDevice(fileName);
                isXML = true;
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
            if (isJSONForExcel || isXML)
            {
                button3.Visible = true;
                button4.Visible = true;
                button4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No data to export.");
                return;
            }
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Excel template not found.");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var template = new ExcelPackage(new FileInfo(templatePath)))
            {
                var deviceSheet = template.Workbook.Worksheets["Device info"];
                if (deviceSheet == null)
                {
                    MessageBox.Show("Device info sheet not found in the Excel template.");
                    return;
                }
                var portSheet = template.Workbook.Worksheets["Port info"];
                if (portSheet == null)
                {
                    MessageBox.Show("Port info sheet not found in the Excel template.");
                    return;
                }
                var device = new Device();
                if (isXML)
                {
                    device = ParseXMLFile.Parse(fileName);
                    isXML= false;
                }
                if (isJSONForExcel)
                {
                    device = ParseJSONFile.Parse(fileName);
                    isJSONForExcel = false;
                }
                deviceSheet.Cells["A2"].Value = device.DeviceName;
                deviceSheet.Cells["B2"].Value = device.Manufacturer;
                deviceSheet.Cells["C2"].Value = device.PartNumber;
                deviceSheet.Cells["D2"].Value = device.SerialNumber;
                deviceSheet.Cells["E2"].Value = device.ProductName;
                deviceSheet.Cells["F2"].Value = device.VendorPartNumber;
                deviceSheet.Cells["G2"].Value = device.VendorSerialNumber;
                deviceSheet.Cells["H2"].Value = device.LicenseId;
                deviceSheet.Cells["I2"].Value = device.ChassisWwn;
                deviceSheet.Cells["J2"].Value = device.CollectorDate;
                int row = 2;
                foreach(var port in device.Ports)
                {
                    portSheet.Cells["A" + row].Value = port.Wwnn;
                    portSheet.Cells["B" + row].Value = port.Wwpn;
                    portSheet.Cells["C" + row].Value = port.DomainId;
                    portSheet.Cells["D" + row].Value = port.FcId;
                    portSheet.Cells["E" + row].Value = port.PortName;
                    portSheet.Cells["F" + row].Value = port.PortNumber;
                    portSheet.Cells["G" + row].Value = port.FirmwareVersion;
                    portSheet.Cells["H" + row].Value = port.SerialNumber;
                    portSheet.Cells["I" + row].Value = device.DeviceName;
                    portSheet.Cells["J" + row].Value = device.SerialNumber;
                    row++;
                }
                template.Save();
                MessageBox.Show("Successfully saved to Excel template!");
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", templatePath);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parsing App allows you to parse five different types of files:\n\n" +
                "- XML\n" +
                "- HTML\n" +
                "- JSON\n" +
                "- CSV\n" +
                "- TXT\n\n" +
                "To parse a file, follow these steps:\n\n" +
                "1. Click on the 'Load file' button\n" +
                "2. Choose your file\n" +
                "3. Click on the 'Parse file' button\n\n" +
                "To export the file to Excel, click on the 'Export to Excel' button.\n\n" +
                "To open the Excel file where information was stored, click on the 'Open Excel' button.",
                "User guide for Parsing App",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            button3.Visible = false;
            button4.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void getInputOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetInputOnlineForm getInputOnlineForm = new GetInputOnlineForm();
            getInputOnlineForm.Show();
        }
    }
}