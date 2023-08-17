using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREINSPECTION
{
    public partial class ItemAdd : Form
    {
        string itemSelectComboText;
        public ItemAdd()
        {
            InitializeComponent();
            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select name from item_group";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemSelectCombo.Items.Add(reader[0].ToString());
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

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (itemSelectCombo.SelectedItem == null || itemTextBox.Text=="")
            {
                MessageBox.Show("제품 그룹을 선택하세요");
                return;
            }
            else
            {
                itemSelectComboText = itemSelectCombo.SelectedItem.ToString();
                    using (MySqlConnection connection = ConnectDB.connectDB())
                    {
                        using (MySqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select name from part where name = @item_group Limit 1";
                            command.Parameters.Add("@item_group", MySqlDbType.VarChar).Value = itemSelectComboText;
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                try
                                {
                                    if (reader.Read())
                                    {
                                        MessageBox.Show("중복된 제품이 있습니다");
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
            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO item (name, group_id) " +
                                          "SELECT @name,id " +
                                          "FROM item_group " +
                                          "WHERE name = @item_groupName;";
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = itemTextBox.Text;
                    command.Parameters.Add("@item_groupName", MySqlDbType.VarChar).Value = itemSelectComboText;
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("입력에 성공하였습니다.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("제품 추가에 실패했습니다.");
                        Log.writeLog(ex.ToString());
                    }
                }
            }
           
        }

        private void ItemAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
