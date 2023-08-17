using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PREINSPECTION
{
    public partial class Mapping : Form
    {
        string selectedItem = null;
        public Mapping(string selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
            MessageBox.Show(selectedItem);
        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT part.name as partName,  part_group.name As partGroupName " +
                                          "FROM part INNER JOIN part_group ON part.group_id = part_group.id";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                switch (reader[1].ToString())
                                {
                                    case "IGBT":
                                        IGBTCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "DIODE":
                                        DIODECombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "콘덴서":
                                        CAPCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "리액터":
                                        REACCombo.Items.Add(reader[0].ToString());
                                        break;

                                    case "CT":
                                        CTCombo.Items.Add(reader[0].ToString());
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
                }
            }
        }

        private void IGBTinsert_Click(object sender, EventArgs e)
        {
            string SelectedIGBT = "";

            if (IGBTCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedIGBT = IGBTCombo.SelectedItem.ToString();
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO mapping(part_id,item_id,partgroup_id)" +
                                              "VALUES((SELECT id FROM part WHERE name = @PartNameIGBT)," +
                                                     "(SELECT id FROM item WHERE name = @ItemName)," +
                                                     "(SELECT id FROM part_group WHERE name ='IGBT')) as IGBT " +
                                                      "ON DUPLICATE KEY UPDATE part_id = CASE " +
                                                                                         "WHEN IGBT.partgroup_id =(SELECT id FROM part_group WHERE name = 'IGBT') THEN (SELECT id FROM part WHERE name = @PartNameIGBT )" +
                                                                                         "END";
                        command.Parameters.Add("@PartNameIGBT", MySqlDbType.VarChar).Value = SelectedIGBT;
                        command.Parameters.Add("@ItemName", MySqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void DIODEinsert_Click(object sender, EventArgs e)
        {
            string SelectedDIODE = "";

            if (DIODECombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedDIODE = DIODECombo.SelectedItem.ToString();
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO mapping(part_id,item_id,partgroup_id)" +
                                              "VALUES((SELECT id FROM part WHERE name = @PartNameDIODE)," +
                                                     "(SELECT id FROM item WHERE name = @ItemName)," +
                                                     "(SELECT id FROM part_group WHERE name ='DIODE')) as DIODE " +
                                                      "ON DUPLICATE KEY UPDATE part_id = CASE " +
                                                                                         "WHEN DIODE.partgroup_id =(SELECT id FROM part_group WHERE name = 'DIODE') THEN (SELECT id FROM part WHERE name = @PartNameDIODE )" +
                                                                                         "END";
                        command.Parameters.Add("@PartNameDIODE", MySqlDbType.VarChar).Value = SelectedDIODE;
                        command.Parameters.Add("@ItemName", MySqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void CAPinsert_Click(object sender, EventArgs e)
        {
            string SelectedCAP = "";

            if (CAPCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedCAP = CAPCombo.SelectedItem.ToString();
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO mapping(part_id,item_id,partgroup_id)" +
                                              "VALUES((SELECT id FROM part WHERE name = @PartNameCAP)," +
                                                     "(SELECT id FROM item WHERE name = @ItemName)," +
                                                     "(SELECT id FROM part_group WHERE name ='콘덴서')) as CAP " +
                                                      "ON DUPLICATE KEY UPDATE part_id = CASE " +
                                                                                         "WHEN CAP.partgroup_id =(SELECT id FROM part_group WHERE name = '콘덴서') THEN (SELECT id FROM part WHERE name = @PartNameCAP )" +
                                                                                         "END";
                        command.Parameters.Add("@PartNameCAP", MySqlDbType.VarChar).Value = SelectedCAP;
                        command.Parameters.Add("@ItemName", MySqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void REACinsert_Click(object sender, EventArgs e)
        {
            string SelectedREAC = "";

            if (REACCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedREAC = REACCombo.SelectedItem.ToString();
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO mapping(part_id,item_id,partgroup_id)" +
                                              "VALUES((SELECT id FROM part WHERE name = @PartNameREAC)," +
                                                     "(SELECT id FROM item WHERE name = @ItemName)," +
                                                     "(SELECT id FROM part_group WHERE name ='리액터')) as REAC " +
                                                      "ON DUPLICATE KEY UPDATE part_id = CASE " +
                                                                                         "WHEN REAC.partgroup_id =(SELECT id FROM part_group WHERE name = '리액터') THEN (SELECT id FROM part WHERE name = @PartNameREAC )" +
                                                                                         "END";
                        command.Parameters.Add("@PartNameREAC", MySqlDbType.VarChar).Value = SelectedREAC;
                        command.Parameters.Add("@ItemName", MySqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }

        private void CTinsert_Click(object sender, EventArgs e)
        {
            string SelectedCT = "";

            if (CTCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
                return;
            }
            else
            {
                SelectedCT = CTCombo.SelectedItem.ToString().Trim();
                using (MySqlConnection connection = ConnectDB.connectDB())
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO mapping(part_id,item_id,partgroup_id)" +
                                              "VALUES((SELECT id FROM part WHERE name = @PartNameCT)," +
                                                     "(SELECT id FROM item WHERE name = @ItemName)," +
                                                     "(SELECT id FROM part_group WHERE name ='CT')) as CT " +
                                                      "ON DUPLICATE KEY UPDATE part_id = CASE " +
                                                                                         "WHEN CT.partgroup_id =(SELECT id FROM part_group WHERE name = 'CT') THEN (SELECT id FROM part WHERE name = @PartNameCT )" +
                                                                                         "END";
                        command.Parameters.Add("@PartNameCT", MySqlDbType.VarChar).Value = SelectedCT;
                        command.Parameters.Add("@ItemName", MySqlDbType.VarChar).Value = selectedItem;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("부품 업데이트에 성공하였습니다!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("부품 업데이트에 실패하였습니다!");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
