using CoreScanner;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Xml;

namespace PREINSPECTION
{
    public partial class UpdatePart : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        CCoreScannerClass cCoreScannerClass;
        public UpdatePart()
        {
            InitializeComponent();
            barcodeText.Enabled = false;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (partText.Enabled == false)
            {
                barcodeText.Enabled = false;
                partText.Enabled = true;
            }
            else
            {
                string parttext = partText.Text;
                string partgrouptext;
                if (partGroupSelect.SelectedItem == null || parttext == "")
                {
                    MessageBox.Show("부품 그룹을 선택하거나 값을 입력하세요");
                    return;
                }
                else
                {
                    partgrouptext = partGroupSelect.SelectedItem.ToString();
                    using (MySqlConnection connection = ConnectDB.connectDB())
                    {
                        using (MySqlCommand command = connection.CreateCommand())
                        {

                            command.CommandText = "Select barcode " +
                                                  "from part " +
                                                  "where group_id = (select id from part_group where name = @partgrouptext) " +
                                                  "and name = @parttext";
                            command.Parameters.Add("@partgrouptext", MySqlDbType.VarChar).Value = partgrouptext;
                            command.Parameters.Add("@parttext", MySqlDbType.VarChar).Value = parttext;
                            try
                            {
                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    string barcode = result.ToString();
                                    barcodeText.Text = barcode;
                                    partText.Enabled = false;
                                    barcodeText.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("이름이 일치하는 부품이 없습니다..");
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            string barcodetext = barcodeText.Text.Trim();
            string parttext = partText.Text.Trim();
            if (partText.Enabled == true)
            {
                MessageBox.Show("부품을 다시 조회하세요");
            }
            else
            {
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {

                        command.CommandText = "update part " +
                                              "set barcode = @barcodetext " +
                                              "where name = @parttext";
                        command.Parameters.Add("@barcodetext", MySqlDbType.VarChar).Value = barcodetext;
                        command.Parameters.Add("@parttext", MySqlDbType.VarChar).Value = parttext;
                        try
                        {
                            int affected = command.ExecuteNonQuery();
                            if (affected != 0)
                            {
                                MessageBox.Show("저장됐습니다.");
                            }
                            else
                            {
                                MessageBox.Show("저장에 실패했습니다.");
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
                barcodeText.Text = deximalValues.Trim(); ;

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

