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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.GPU". При необходимости она может быть перемещена или удалена.
            this.gPUTableAdapter.Fill(this.bAZA.GPU);
            gPUBindingSource.DataSource = this.bAZA.GPU;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.gPUTableAdapter.Fill(this.bAZA.GPU);
                    gPUBindingSource.DataSource = this.bAZA.GPU;
                }
                else
                {
                    var query = from o in this.bAZA.GPU
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Графический_процессор == txtSearch.Text || o.Видеопамять == txtSearch.Text || o.Ширина_шины == txtSearch.Text || o.Интерфейсы == txtSearch.Text || o.Цена.Contains(txtSearch.Text)
                                select o;
                    gPUBindingSource.DataSource = query.ToList();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gPUBindingSource.EndEdit();
                gPUTableAdapter.Update(this.bAZA.GPU);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gPUBindingSource.ResetBindings(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            gPUBindingSource.ResetBindings(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtFullName.Focus();
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

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    gPUBindingSource.RemoveCurrent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtFullName.Focus();
                this.bAZA.GPU.AddGPURow(this.bAZA.GPU.NewGPURow());
                gPUBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gPUBindingSource.ResetBindings(false);
            }
        }
    }
}
