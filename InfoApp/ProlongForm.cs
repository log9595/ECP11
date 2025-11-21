using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using ExcelDataReader;
using System.Collections;
using NLog;

namespace InfoApp
{
    public partial class ProlongForm : Form
    {
        public class Posts
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        
        public class Orgs
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class Centers
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class EditData
        {
            public int id { get; set; }
            public string FIO { get; set; }
            public int postID { get; set; }
            public int orgID { get; set; }
            public string room { get; set; }
            public string numbContainer { get; set; }
            public DateTime dateFrom { get; set; }
            public DateTime dateTo { get; set; }
            public int centerID { get; set; }
            public string comment { get; set; }

        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        List<Posts> postList = new List<Posts>();
        List<Orgs> orgList = new List<Orgs>();
        List<Centers> centerList = new List<Centers>();
        List<EditData> editList = new List<EditData>();
        int _id = 0;

        public ProlongForm(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void LoadPost()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from PostTable", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    postList.Clear();

                    while (reader.Read())
                    {
                        postList.Add(new Posts { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbPost.DataSource = null;
                cbPost.DataSource = postList;
                cbPost.DisplayMember = "name";
                cbPost.ValueMember = "id";
                cbPost.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadOrgstruct()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from OrgTable", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    orgList.Clear();

                    while (reader.Read())
                    {
                        orgList.Add(new Orgs { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbOrgStruct.DataSource = null;
                cbOrgStruct.DataSource = orgList;
                cbOrgStruct.DisplayMember = "name";
                cbOrgStruct.ValueMember = "id";
                cbOrgStruct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadCenter()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from CenterECP", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    centerList.Clear();

                    while (reader.Read())
                    {
                        centerList.Add(new Centers { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbCenter.DataSource = null;
                cbCenter.DataSource = centerList;
                cbCenter.DisplayMember = "name";
                cbCenter.ValueMember = "id";
                cbCenter.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                /*-Load PostName-*/
                    LoadPost();
                /*---------------*/

                /*-Load OrgStructure-*/
                    LoadOrgstruct();
                /*-------------------*/

                /*--Load Center--*/
                    LoadCenter();
                /*---------------*/
                LoadFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
        
        private void BtnAddPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPost.Text != "" && cbPost.SelectedIndex == -1)
                {
                    AddDataClass.InsertData($"insert into PostTable (postName) value ('{cbPost.Text}')");
                    LoadPost();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAddOrg_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOrgStruct.Text != "" || cbOrgStruct.SelectedIndex == -1)
                {
                    AddDataClass.InsertData($"insert into OrgTable (OrgStructure) value ('{cbOrgStruct.Text}')");
                    LoadOrgstruct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadFunction()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                    string query = "select id, FIO, postID, orgID, room, numbContainer, dateFrom, dateTo, centerID, comment from ECPTable" +
                                  $" where id = {_id}";

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        editList.Add(new EditData { id = reader.GetInt32(0), FIO = reader.GetString(1), postID = reader.GetInt32(2), orgID = reader.GetInt32(3), room = reader.GetString(4), numbContainer = reader.GetString(5), dateFrom = reader.GetDateTime(6), dateTo = reader.GetDateTime(7), centerID = reader.GetInt32(8), comment = reader.GetString(9) });
                    }
                }

                txtFIO.Text = editList[0].FIO;
                cbPost.SelectedValue = editList[0].postID;
                cbOrgStruct.SelectedValue = editList[0].orgID;
                txtRoom.Text = editList[0].room;
                txtBox.Text = editList[0].numbContainer;
                dateFrom.Value = Convert.ToDateTime(editList[0].dateFrom);
                dateTo.Value = Convert.ToDateTime(editList[0].dateTo);
                cbCenter.SelectedValue = editList[0].centerID;
                txtComment.Text = editList[0].comment;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    string query = $"update ECPTable set deleted = 1 where id = {_id}";
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                AddDataClass.InsertData($"insert into ECPTable (FIO, postID, orgID, room, numbContainer, dateFrom, dateTo, centerID, comment) value ('{txtFIO.Text}', {postList[cbPost.SelectedIndex].id}, {orgList[cbOrgStruct.SelectedIndex].id}, '{txtRoom.Text}', '{txtBox.Text}', '{dateFrom.Value:yyyy-MM-dd}', '{dateTo.Value:yyyy-MM-dd}', {centerList[cbCenter.SelectedIndex].id}, '{txtComment.Text}')");
                MessageBox.Show("Цифровая подпись успешно продлена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAddCenter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cbCenter.Text != "" && cbCenter.SelectedIndex == -1) || cbCenter.SelectedIndex == -2)
                {
                    string cbText = cbCenter.Text;
                    AddDataClass.InsertData($"insert into CenterECP (CenterName) value ('{cbCenter.Text}')");
                    LoadCenter();
                    cbCenter.SelectedItem = cbText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
    }
}
