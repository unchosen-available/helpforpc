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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.KULL". При необходимости она может быть перемещена или удалена.
            this.kULLTableAdapter.Fill(this.bAZA.KULL);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.KULL". При необходимости она может быть перемещена или удалена.
            this.kULLTableAdapter.Fill(this.bAZA.KULL);
            kULLBindingSource.DataSource = this.bAZA.KULL;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    kULLBindingSource.RemoveCurrent();
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
                this.bAZA.KULL.AddKULLRow(this.bAZA.KULL.NewKULLRow());
                kULLBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kULLBindingSource.ResetBindings(false);
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
            kULLBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                kULLBindingSource.EndEdit();
                kULLTableAdapter.Update(this.bAZA.KULL);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kULLBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.kULLTableAdapter.Fill(this.bAZA.KULL);
                    kULLBindingSource.DataSource = this.bAZA.KULL;
                }
                else
                {
                    var query = from o in this.bAZA.KULL
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Производитель == txtSearch.Text || o.Шум == txtSearch.Text || o.Тип_охлаждения == txtSearch.Text || o.Вентилятор == txtSearch.Text || o.Скорость_вращения.Contains(txtSearch.Text)
                                select o;
                    kULLBindingSource.DataSource = query.ToList();
                } 
            }
        }
    }
}
