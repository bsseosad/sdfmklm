using CoreScanner;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Xml;
namespace PREINSPECTION
{
    public partial class addPart : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        CCoreScannerClass cCoreScannerClass;
        public addPart()
        {
            InitializeComponent();
            try
            {
                cCoreScannerClass = new CCoreScannerClass();

                short[] scannerTypes = new short[1];
                scannerTypes[0] = 2;
                short numberOfScannerTypes = 1;
                int status;

                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                cCoreScannerClass.BarcodeEvent += OnBarcodeEvent;

                int opcode = 1001;
                string outXML;
                string inXML = "<inArgs>" +
                                "<cmdArgs>" +
                                    "<arg-int>1</arg-int>" +
                                    "<arg-int>1</arg-int>" +
                                "</cmdArgs>" +
                                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
                Console.WriteLine(outXML);
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select name from part_group";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                partGroupSelect.Items.Add(reader[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }



        private void insert_Click(object sender, EventArgs e)
        {
            string barcodetext = barcodeText.Text.Trim();
            string nametext = nameText.Text.Trim();
            string partgrouptext = "";
            if (partGroupSelect.SelectedItem == null)
            {
                MessageBox.Show("부품 그룹을 선택하세요");
                return;
            }
            else
            {
                partgrouptext = partGroupSelect.SelectedItem.ToString();
                if (nametext == "")
                {
                    MessageBox.Show("값을 입력하세요");
                    return;
                }
                else
                {
                    using (MySqlConnection connection = ConnectDB.connectDB())
                    {
                        using (MySqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select name from part where name = @partName Limit 1";
                            command.Parameters.Add("@partName", MySqlDbType.VarChar).Value = nametext;
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                try
                                {
                                    if (reader.Read())
                                    {
                                        MessageBox.Show("이미 중복된 값이 있습니다.");
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log.writeLog(ex.ToString());
                                }

                            }
                        }
                    }
                }
            }
            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO part (group_id, name, barcode) " +
                                          "SELECT id, @name, @barcode " +
                                          "FROM part_group " +
                                          "WHERE name = @part_groupName;";
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nametext;
                    command.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = barcodetext;
                    command.Parameters.Add("@part_groupName", MySqlDbType.VarChar).Value = partgrouptext;
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("부품 추가에 성공하였습니다.");
                    }
                    catch(Exception ex)
                    {
                        Log.writeLog(ex.ToString());    
                    }
                }
            }
        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            string barcode = pscanData;
            xmlDoc.LoadXml(barcode);
            XmlNode modelnumber = xmlDoc.SelectSingleNode(".//rawdata");
            string modelnumberText = modelnumber.InnerText;
            string[] hexValueArray = modelnumberText.Split(' ');

            string deximalValues = HexToAscii(hexValueArray);

            this.Invoke((MethodInvoker)delegate
            {
                barcodeText.Text = deximalValues.Trim();

            });
        }

        static string HexToAscii(string[] hexArray)
        {
            string asciiString = "";
            foreach (string hexValue in hexArray)
            {
                if (hexValue.StartsWith("0x"))
                {
                    int decimalValue = Convert.ToInt32(hexValue, 16);
                    if (decimalValue > 48 && decimalValue < 127)
                    {
                        char asciiChar = (char)decimalValue;
                        asciiString += asciiChar;
                    }
                }
            }
            return asciiString;
        }
    }
}





