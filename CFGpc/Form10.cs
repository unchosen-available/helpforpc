using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFGpc
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.KO". При необходимости она может быть перемещена или удалена.
            this.kOTableAdapter.Fill(this.bAZA.KO);
            kOBindingSource.DataSource = this.bAZA.KO;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    kOBindingSource.RemoveCurrent();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtFullName.Focus();
                this.bAZA.KO.AddKORow(this.bAZA.KO.NewKORow());
                kOBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kOBindingSource.ResetBindings(false);
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
            kOBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                kOBindingSource.EndEdit();
                kOTableAdapter.Update(this.bAZA.KO);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kOBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.kOTableAdapter.Fill(this.bAZA.KO);
                    kOBindingSource.DataSource = this.bAZA.KO;
                }
                else
                {
                    var query = from o in this.bAZA.KO
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Тип == txtSearch.Text || o.Форм_фактор == txtSearch.Text || o.Тип_корпуса == txtSearch.Text || o.Цена.Contains(txtSearch.Text)
                                select o;
                    kOBindingSource.DataSource = query.ToList();
                }
            }
        }
    }
}
