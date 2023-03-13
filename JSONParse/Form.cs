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
                string jsonString = File.ReadAllText(ofd.FileName);
                Device device = JsonConvert.DeserializeObject<Device>(jsonString);
                textBox1.Text = $"Device Name: {device.DeviceName}\r\n" +
                       $"Manufacturer: {device.Manufacturer}\r\n" +
                       $"Part Number: {device.PartNumber}\r\n" +
                       $"Serial Number: {device.SerialNumber}\r\n"+
                       $"Product Name: {device.ProductName}\r\n"+
                       $"Vendor Part Number: {device.VendorPartNumber}\r\n"+
                       $"Vendor Serial Number: {device.VendorSerialNumber}\r\n"+
                       $"License ID: {device.LicenseId}\r\n"+
                       $"Chassis Wwn: {device.ChassisWwn}\r\n"+
                       $"Collector Date: {device.CollectorDate}\r\n\r\n"+
                       "Ports:\r\n";
                int n = 0;
                foreach (Port port in device.Ports)
                {
                    textBox1.Text += ++n +".\r\n" + $"Wwpn: {port.Wwpn}\r\n" +
                        $"Wwnn: {port.Wwnn}\r\n" +
                        $"Domain ID: {port.DomainId}\r\n" +
                        $"Fc ID: {port.FcId}\r\n" +
                        $"Port Name: {port.PortName}\r\n" +
                        $"Port Number: {port.PortNumber}\r\n" +
                        $"Firmware Version: {port.FirmwareVersion}\r\n" +
                        $"Serial Number: {port.SerialNumber}\r\n\r\n";
                }

            }
        }
    }
}