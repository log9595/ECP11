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
using NLog;

namespace InfoApp
{
    public partial class Form1 : Form
    {
        public class Orgs
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();

        DataTable dataTable;
        List<Orgs> orgList = new List<Orgs>();
        DateTime firstDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, 1);
        DateTime lastDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month));
        DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        public Form1()
        {
            InitializeComponent();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
        private void LoadFunc(string strLoad)
        {
            try
            {
                string query = "select et.id," +
                                     " FIO,"+
                                     " postName," +
                                     " OrgStructure," +
                                     " room," +
                                     " numbContainer," +
                                     " dateFrom," +
                                     " dateTo," +
                                     " CenterName," +
                                     " comment" +
                               " from ECPTable et" +
                               " left join PostTable pt on et.postID = pt.id" +
                               " left join OrgTable ot on et.orgID = ot.id" +
                               " left join CenterECP ce on et.centerID = ce.id" +
                              $" where deleted = 0" +
                              $" {strLoad}";

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);

                    dataTable = new DataTable();

                    dataTable.Load(sqlCommand.ExecuteReader());
                    
                    dataGridView1.DataSource = dataTable;
                    
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOrgstruct();
                LoadFunc("");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void AddForm_Click(object sender, EventArgs e)
        {
            try
            {
                using (AddClientForm addClientForm = new AddClientForm())
                {
                    addClientForm.ShowDialog();
                }

                LoadOrgstruct();

                if (cbOrgStruct.SelectedIndex == -1) LoadFunc("");
                else
                {
                    LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOrgStruct.SelectedIndex == -1) LoadFunc("");
                else
                {
                    LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //dataTable.DefaultView.Sort = "dateTo DESC";
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (EditClientForm editClientForm = new EditClientForm(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())))
                {
                    editClientForm.ShowDialog();

                    if (cbOrgStruct.SelectedIndex == -1) LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnProlong_Click(object sender, EventArgs e)
        {
            try
            {
                using (ProlongForm prolongForm = new ProlongForm(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())))
                {
                    prolongForm.ShowDialog();

                    if (cbOrgStruct.SelectedIndex == -1) LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (InstructForm instForm = new InstructForm())
                {
                    instForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTable.DefaultView.RowFilter = string.Format($"Convert([FIO], System.String) like '{txtSearch.Text}%'");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данную запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddDataClass.InsertData($"update ECPTable set deleted = 1 where id = {dataGridView1.CurrentRow.Cells[0].Value}");

                    if (cbOrgStruct.SelectedIndex == -1) LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionSettingsForm csForm = new ConnectionSettingsForm())
                {
                    csForm.ShowDialog();
                }
                LoadOrgstruct();
                LoadFunc("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
    }
}
