using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace CFGpc
{
    public partial class Form6 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form6()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.MPP". При необходимости она может быть перемещена или удалена.
            this.mPPTableAdapter.Fill(this.bAZA.MPP);
            mPPBindingSource.DataSource = this.bAZA.MPP;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtFullName.Focus();
                this.bAZA.MPP.AddMPPRow(this.bAZA.MPP.NewMPPRow());
                mPPBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mPPBindingSource.ResetBindings(false);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    mPPBindingSource.RemoveCurrent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtFullName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            mPPBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                mPPBindingSource.EndEdit();
                mPPTableAdapter.Update(this.bAZA.MPP);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mPPBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.mPPTableAdapter.Fill(this.bAZA.MPP);
                    mPPBindingSource.DataSource = this.bAZA.MPP;
                }
                else
                {
                    var query = from o in this.bAZA.MPP
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Сокет == txtSearch.Text || o.Форм_фактор == txtSearch.Text || o.Чипсет == txtSearch.Text || o.Память == txtSearch.Text || o.Цена.Contains(txtSearch.Text)
                                select o;
                    mPPBindingSource.DataSource = query.ToList();
                }
            }
        }
    }
}
