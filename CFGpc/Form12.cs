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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.HDD". При необходимости она может быть перемещена или удалена.
            this.hDDTableAdapter.Fill(this.bAZA.HDD);
            hDDBindingSource.DataSource = this.bAZA.HDD;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    hDDBindingSource.RemoveCurrent();
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
                this.bAZA.HDD.AddHDDRow(this.bAZA.HDD.NewHDDRow());
                hDDBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hDDBindingSource.ResetBindings(false);
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
            hDDBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                hDDBindingSource.EndEdit();
                hDDTableAdapter.Update(this.bAZA.HDD);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hDDBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.hDDTableAdapter.Fill(this.bAZA.HDD);
                    hDDBindingSource.DataSource = this.bAZA.HDD;
                }
                else
                {
                    var query = from o in this.bAZA.HDD
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Тип_накопителя == txtSearch.Text || o.Объём == txtSearch.Text || o.Форм_фактор == txtSearch.Text || o.Интерфейс == txtSearch.Text || o.Скорость_вращения_шпинделя == txtSearch.Text || o.Цена.Contains(txtSearch.Text)
                                select o;
                    hDDBindingSource.DataSource = query.ToList();
                }
            }
        }
    }
}
