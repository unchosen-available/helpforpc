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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.OPP". При необходимости она может быть перемещена или удалена.
            this.oPPTableAdapter.Fill(this.bAZA.OPP);
            oPPBindingSource.DataSource = this.bAZA.OPP;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtFullName.Focus();
                this.bAZA.OPP.AddOPPRow(this.bAZA.OPP.NewOPPRow());
                oPPBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oPPBindingSource.ResetBindings(false);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (MessageBox.Show("Вы точно хотите удаить эту запись?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    oPPBindingSource.RemoveCurrent();
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
            oPPBindingSource.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                oPPBindingSource.EndEdit();
                oPPTableAdapter.Update(this.bAZA.OPP);
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oPPBindingSource.ResetBindings(false);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    this.oPPTableAdapter.Fill(this.bAZA.OPP);
                    oPPBindingSource.DataSource = this.bAZA.OPP;
                   
                }
                else
                {
                    var query = from o in this.bAZA.OPP
                                where o.Производитель.Contains(txtSearch.Text) || o.Название == txtSearch.Text || o.Канальность == txtSearch.Text || o.Тайминги == txtSearch.Text || o.Частота == txtSearch.Text || o.Напряжение == txtSearch.Text || o.Цена.Contains(txtSearch.Text)
                                select o;
                    oPPBindingSource.DataSource = query.ToList();
                   
                }
            }
        }
    }
}
