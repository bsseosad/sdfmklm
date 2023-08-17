using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
namespace PREINSPECTION
{
    public partial class itemSelect : Form
    {
        UpdatePart updatepart = null;//부품 수정하는 폼
        addPart addpart = null;//부품을 추가하는 폼
        PartSearch partsearch = null;
        ItemAdd itemadd = null;
        Mapping mapping = null;
        public itemSelect()
        {
            InitializeComponent();
        }

        private void itemSelect_Load(object sender, EventArgs e)
        {

            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM item_group";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemGroupBox.Items.Add(reader[0].ToString());
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
        private void itemGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemBox.Items.Clear();
            string selectedItem = itemGroupBox.SelectedItem.ToString();

            using (MySqlConnection connection = ConnectDB.connectDB())
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT item.name FROM item_group INNER JOIN " +
                        "item ON item_group.id = item.group_id " +
                        "WHERE item_group.name = @SelectedItem";
                    command.Parameters.Add("@SelectedItem", MySqlDbType.VarChar, 45).Value = selectedItem;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemBox.Items.Add(reader[0].ToString());
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
        private void partAdd_Click(object sender, EventArgs e)
        {

            if (addpart == null || addpart.IsDisposed)
            {
                try
                {
                    addpart = new addPart();
                    addpart.Show();
                }
                catch (Exception ex)
                {
                    Log.writeLog(ex.ToString());
                }
            }
            else
            {
                addpart.Activate();
            }
        }

        private void updatePart_Click(object sender, EventArgs e)
        {
            if (updatepart == null || updatepart.IsDisposed)
            {
                try
                {
                    updatepart = new UpdatePart();
                    updatepart.Show();
                }
                catch (Exception ex)
                {
                    Log.writeLog(ex.ToString());
                }
            }
            else
            {
                updatepart.Activate();
            }
        }

        private void partButton_Click(object sender, EventArgs e)
        {
            if (itemBox.SelectedItem == null)
            {
                MessageBox.Show("제품을 선택하세요");
            }
            else
            {
                string item = itemBox.SelectedItem.ToString().Trim();
                if (partsearch == null || partsearch.IsDisposed)
                {
                    try
                    {
                        partsearch = new PartSearch(item);
                        partsearch.Show();
                    }
                    catch (Exception ex)
                    {
                        Log.writeLog(ex.ToString());
                    }
                }
                else
                {
                    partsearch.Activate();
                }
            }
        }

        private void itemAdd_Click(object sender, EventArgs e)
        {
            if (itemadd == null || itemadd.IsDisposed)
            {
                try
                {
                    itemadd = new ItemAdd();
                    itemadd.Show();
                }
                catch (Exception ex)
                {
                    Log.writeLog(ex.ToString());
                }
            }
            else
            {
                itemadd.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mapping == null || mapping.IsDisposed)
            {
                try
                {
                    if (itemBox.SelectedItem != null)
                    {
                        string item = itemBox.SelectedItem.ToString();
                        mapping = new Mapping(item);
                        mapping.Show();
                    }
                    else
                    {
                        MessageBox.Show("제품을 선택하세요");
                    }
                }
                catch (Exception ex)
                {
                    Log.writeLog(ex.ToString());
                }
            }
            else
            {
                mapping.Activate();
            }
        }
    }
}
