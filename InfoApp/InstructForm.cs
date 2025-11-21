using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using NLog;

namespace InfoApp
{
    public partial class InstructForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        DataTable dataTable;
        int flag = 0;
        public InstructForm()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCenterName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtFileAddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void InstructForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select id, CenterName, fileAddress from CenterECP", sqlConnection);
                    dataTable = new DataTable();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    txtCenterName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtFileAddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }

                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                txtCenterName.Enabled = false;
                txtFileAddress.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            flag = 0;
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            txtCenterName.Enabled = true;
            txtFileAddress.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                txtCenterName.Enabled = false;
                txtFileAddress.Enabled = false;

                txtCenterName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtFileAddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtCenterName.Clear();
            txtFileAddress.Clear();
            txtCenterName.Enabled = true;
            txtFileAddress.Enabled = true;

            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (flag)
                {
                    case 0:
                        AddDataClass.InsertData($"update CenterECP set CenterName = '{txtCenterName.Text}', fileAddress = '{txtFileAddress.Text}' where id = {dataGridView1.CurrentRow.Cells[0].Value}");
                        MessageBox.Show("Изменения успешно сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        AddDataClass.InsertData($"insert into CenterECP (CenterName, fileAddress) value ('{txtCenterName.Text}', '{txtFileAddress.Text}')");
                        MessageBox.Show("Информация успешно добавлена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                txtCenterName.Enabled = false;
                txtFileAddress.Enabled = false;

                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void TxtFileAddress_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                OpenFileDialog selectFile = new OpenFileDialog();
                selectFile.Filter = "Doc Files|*.doc;*.docx|Text Files|*.txt|Excel Files|*.xls;*.xlsx;*.xlsm|All Files|*.*";
                if (selectFile.ShowDialog() == DialogResult.Cancel) return;

                string filename = selectFile.FileName;
                FileInfo fi = new FileInfo(selectFile.FileName);
                string dirSource = fi.DirectoryName;
                string fname = "Инструкция " + txtCenterName.Text + fi.Extension;
                File.Copy(Path.Combine(dirSource, fi.Name), Path.Combine(Application.StartupPath + @"\Instructions", fname), true);

                AddDataClass.InsertData($"update CenterECP set fileAddress = '{fname}' where id = {dataGridView1.CurrentRow.Cells[0].Value}");

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select id, CenterName, fileAddress from CenterECP", sqlConnection);
                    dataTable.Clear();
                    dataTable.Load(sqlCommand.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Refresh();
                }

                txtCenterName.Enabled = false;
                txtFileAddress.Enabled = false;

                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "") Process.Start(Application.StartupPath + @"\Instructions\" + dataGridView1.CurrentRow.Cells[2].Value.ToString());
                else MessageBox.Show("Для данного УЦ еще не сохранена инструкция", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
    }
}
