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
    public partial class AddClientForm : Form
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        List<Posts> postList = new List<Posts>();
        List<Orgs> orgList = new List<Orgs>();
        List<Centers> centerList = new List<Centers>();

        public AddClientForm()
        {
            InitializeComponent();
        }

        private void ClearFunc()
        {
            txtFIO.Clear();
            cbPost.SelectedIndex = -1;
            cbOrgStruct.SelectedIndex = -1;
            txtRoom.Clear();
            txtBox.Clear();
            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
            cbCenter.SelectedIndex = -1;
            txtComment.Clear();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddDataClass.InsertData($"insert into ECPTable (FIO, postID, orgID, room, numbContainer, dateFrom, dateTo, centerID, comment) value ('{txtFIO.Text}', {postList[cbPost.SelectedIndex].id}, {orgList[cbOrgStruct.SelectedIndex].id}, '{txtRoom.Text}', '{txtBox.Text}', '{dateFrom.Value:yyyy-MM-dd}', '{dateTo.Value:yyyy-MM-dd}', {centerList[cbCenter.SelectedIndex].id}, '{txtComment.Text}')");
                MessageBox.Show("Пользователь успешно добавлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Хотите добавить следующего пользователя?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ClearFunc();
                else this.Close();
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
                    string post = cbPost.Text;
                    AddDataClass.InsertData($"insert into PostTable (postName) value ('{post}')");
                    LoadPost();
                    cbPost.Text = post;
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
                if (cbOrgStruct.Text != "" && cbOrgStruct.SelectedIndex == -1)
                {
                    string depart = cbOrgStruct.Text;
                    AddDataClass.InsertData($"insert into OrgTable (OrgStructure) value ('{depart}')");
                    LoadOrgstruct();
                    cbOrgStruct.Text = depart;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Excel Files | *.xls; *.xlsx; *.xlsm";

                if (openFile.ShowDialog() == DialogResult.Cancel) return;

                FileStream fileStream = new FileStream(openFile.FileName, FileMode.Open);
                IExcelDataReader excelData = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                DataSet dataSet = excelData.AsDataSet();
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    foreach (DataTable dataTable in dataSet.Tables)
                    {
                        if (dataTable.TableName != "Списки")
                        {
                            for (int i = 1; i < dataTable.Rows.Count; i++)
                            {
                                DataRow dataRow = dataTable.Rows[i];

                                string query = $"insert into ECPTable (FIO, postID, orgID, room, numbContainer, dateFrom, dateTo, centerID, comment) value ('{dataRow[0].ToString()}', {CheckData(dataRow[1].ToString(), 1)}, {CheckData(dataRow[2].ToString(), 2)}, '{dataRow[3].ToString()}', '{dataRow[4].ToString()}', '{dataRow[5].ToString()}', '{dataRow[6].ToString()}', {CheckData(dataRow[7].ToString(), 3)}, '{dataRow[8].ToString()}')";
                                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                                MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private int CheckData(string dataStr, int poz)
        {
            try
            {
                bool dataBool = false;
                int returnData = 0;
                switch (poz)
                {
                    case 1:
                        /*-----------------------------------------------------------------------------------*/
                        for (int i = 0; i < postList.Count; i++)
                        {
                            if (postList[i].name == dataStr)
                            {
                                dataBool = true;
                            }
                        }

                        if (dataBool != true)
                        {
                            AddDataClass.InsertData($"insert into PostTable (postName) value ('{dataStr}')");
                            LoadPost();
                        }

                        for (int i = 0; i < postList.Count; i++)
                        {
                            if (postList[i].name == dataStr)
                            {
                                returnData = postList[i].id;
                            }
                        }
                        break;
                    case 2:
                        /*-----------------------------------------------------------------------------------*/
                        for (int i = 0; i < orgList.Count; i++)
                        {
                            if (orgList[i].name == dataStr)
                            {
                                dataBool = true;
                            }
                        }

                        if (dataBool != true)
                        {
                            AddDataClass.InsertData($"insert into OrgTable (OrgStructure) value ('{dataStr}')");
                            LoadOrgstruct();
                        }

                        for (int i = 0; i < orgList.Count; i++)
                        {
                            if (orgList[i].name == dataStr)
                            {
                                returnData = orgList[i].id;
                            }
                        }
                        break;
                    case 3:
                        /*-----------------------------------------------------------------------------------*/
                        for (int i = 0; i < centerList.Count; i++)
                        {
                            if (centerList[i].name == dataStr)
                            {
                                dataBool = true;
                            }
                        }

                        if (dataBool != true)
                        {
                            AddDataClass.InsertData($"insert into CenterECP (CenterName) value ('{dataStr}')");
                            LoadCenter();
                        }

                        for (int i = 0; i < centerList.Count; i++)
                        {
                            if (centerList[i].name == dataStr)
                            {
                                returnData = centerList[i].id;
                            }
                        }
                        break;
                }

                return returnData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
                return 0;
            }
        }

        private void BtnAddCenter_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCenter.Text != "" && cbCenter.SelectedIndex == -1)
                {
                    string center = cbCenter.Text;
                    AddDataClass.InsertData($"insert into CenterECP (CenterName) value ('{center}')");
                    LoadCenter();
                    cbCenter.Text = center;
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
