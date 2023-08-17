using CoreScanner;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
using System.IO;

namespace PREINSPECTION
{
    public partial class PartSearch : Form
    {
        string[] partListName =new  string[] {"IGBT", "DIODE", "콘덴서", "리액터", "CT" };
        string[] partListBarcode = new string[] {"","","","","" };
        string item;
        XmlDocument xmlDoc = new XmlDocument();
        CCoreScannerClass cCoreScannerClass;
        public PartSearch(string item)
        {
            this.item = item;
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
        }


        private void PartSearch_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = item;
            richTextBox1.Enabled = false;
            for (int i = 0; i < 5; i++)
            {
                this.partRichTextBoxList[i] = new RichTextBox();
                this.parttextBoxList[i] = new TextBox();
                this.CheckBox[i] = new CheckBox();  
            }

            for (int i = 0; i < 5; i++)
            {

                partRichTextBoxList[i].Location = new System.Drawing.Point(300, 100 + 40 * i);
                partRichTextBoxList[i].Name = "part" + i.ToString();
                partRichTextBoxList[i].Size = new System.Drawing.Size(200, 30);
                partRichTextBoxList[i].TabIndex = i + 1;
                partRichTextBoxList[i].Text = "";
                this.Controls.Add(partRichTextBoxList[i]);

                parttextBoxList[i].Location = new System.Drawing.Point(200, 100 + 40 * i);
                parttextBoxList[i].Size = new System.Drawing.Size(70, 30);
                parttextBoxList[i].Name = "partText" + i.ToString();
                parttextBoxList[i].TabIndex = i + 1;
                parttextBoxList[i].Text = partListName[i];
                this.Controls.Add(parttextBoxList[i]);
                parttextBoxList[i].Enabled = false;

                CheckBox[i].Location = new System.Drawing.Point(520, 100 + 40 * i);
                CheckBox[i].Size = new System.Drawing.Size(104, 19);
                CheckBox[i].Name = "checkbox" + i.ToString();
                this.Controls.Add(CheckBox[i]);
            }

            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT part.name,part_group.name,part.barcode " +
                                          "FROM mapping INNER JOIN part ON mapping.part_id=part.id " +
                                          "INNER JOIN part_group ON part_group.id=part.group_id " +
                                          "INNER JOIN item ON mapping.item_id = item.id " +
                                          "WHERE item.name = @itemName";
                    command.Parameters.Add("@itemName", MySqlDbType.VarChar, 45).Value = item;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                switch (reader[1].ToString())
                                {
                                    case "IGBT":
                                        partRichTextBoxList[0].Text = reader[0].ToString();
                                        partListBarcode[0] = reader[2].ToString();
                                        StyleNumbers(partRichTextBoxList[0]);
                                        break;

                                    case "DIODE":
                                        partRichTextBoxList[1].Text = reader[0].ToString();
                                        partListBarcode[1] = reader[2].ToString();
                                        StyleNumbers(partRichTextBoxList[1]);
                                        break;

                                    case "콘덴서":
                                        partRichTextBoxList[2].Text = reader[0].ToString();
                                        partListBarcode[2] = reader[2].ToString();
                                        StyleNumbers(partRichTextBoxList[2]);
                                        break;

                                    case "리액터":
                                        partRichTextBoxList[3].Text = reader[0].ToString();
                                        partListBarcode[3] = reader[2].ToString();
                                        StyleNumbers(partRichTextBoxList[3]);
                                        break;

                                    case "CT":
                                        partRichTextBoxList[4].Text = reader[0].ToString();
                                        partListBarcode[4] = reader[2].ToString();
                                        StyleNumbers(partRichTextBoxList[4]);
                                        break;

                                    default:
                                        MessageBox.Show("잘못되었습니다.");
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        partRichTextBoxList[i].Enabled = false;
                        if (partRichTextBoxList[i].Text=="")
                        {
                            CheckBox[i].Checked = true;
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
                for(int i = 0;i < partListBarcode.Length;i++)
                {
                    if (partListBarcode[i].Trim() ==  deximalValues.Trim())
                    {
                        CheckBox[i].Checked = true;
                        return;
                    }
                }
                MessageBox.Show("일치하는 바코드가 없습니다.");
                
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

        private void StyleNumbers(RichTextBox richTextBox)
        {
            string input = richTextBox.Text;
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(input, pattern);

            Color numberColor = Color.Red;
            Font numberFont = new Font(richTextBox.Font.FontFamily, 12, FontStyle.Bold);

            foreach (Match match in matches)
            {
                int start = match.Index;
                int length = match.Length;

                richTextBox.SelectionStart = start;
                richTextBox.SelectionLength = length;

                richTextBox.SelectionColor = numberColor;
                richTextBox.SelectionFont = numberFont;
            }
        }
       
        private bool isAllChecked(CheckBox[] checkBoxes)
        {
            for(int i = 0; i < checkBoxes.Length; i++)
            {
                if(checkBoxes[i].Checked == false)
                {
                    return false;
                }
            }
            return true;
            
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (isAllChecked(CheckBox))
            {

            }
        }
    }
}
