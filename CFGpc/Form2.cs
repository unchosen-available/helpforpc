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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DataGridView2.Columns[2].Width = 250;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.KO". При необходимости она может быть перемещена или удалена.
            this.kOTableAdapter.Fill(this.bAZA.KO);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.BP". При необходимости она может быть перемещена или удалена.
            this.bPTableAdapter.Fill(this.bAZA.BP);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.HDD". При необходимости она может быть перемещена или удалена.
            this.hDDTableAdapter.Fill(this.bAZA.HDD);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.OPP". При необходимости она может быть перемещена или удалена.
            this.oPPTableAdapter.Fill(this.bAZA.OPP);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.GPU". При необходимости она может быть перемещена или удалена.
            this.gPUTableAdapter.Fill(this.bAZA.GPU);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.KULL". При необходимости она может быть перемещена или удалена.
            this.kULLTableAdapter.Fill(this.bAZA.KULL);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.CPU". При необходимости она может быть перемещена или удалена.
            this.cPUTableAdapter.Fill(this.bAZA.CPU);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.Конфигурация_компьютера". При необходимости она может быть перемещена или удалена.
            this.конфигурация_компьютераTableAdapter.Fill(this.bAZA.Конфигурация_компьютера);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bAZA.MPP". При необходимости она может быть перемещена или удалена.
            this.mPPTableAdapter.Fill(this.bAZA.MPP);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void NavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.MPPRow)((DataRowView)mPPBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = DataGridView2.CurrentRow.Index;
            DataGridView2.Rows.Remove(DataGridView2.Rows[a]);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.CPURow)((DataRowView)cPUBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = true;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = true;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.KULLRow)((DataRowView)kULLBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.GPURow)((DataRowView)gPUBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = true;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.OPPRow)((DataRowView)oPPBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = true;
            dataGridView8.Visible = false;
            dataGridView9.Visible = false;
        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.HDDRow)((DataRowView)hDDBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = true;
            dataGridView9.Visible = false;
        }

        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.BPRow)((DataRowView)bPBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            dataGridView9.Visible = true;
        }

        private void dataGridView9_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var drw = ((BAZA.KORow)((DataRowView)kOBindingSource.Current).Row);
            конфигурация_компьютераTableAdapter.Insert(drw.Название, drw.Цена);
            конфигурация_компьютераTableAdapter.Update(bAZA.Конфигурация_компьютера);
            конфигурация_компьютераTableAdapter.Fill(bAZA.Конфигурация_компьютера);

            double d = 0;
            foreach (DataGridViewRow row in DataGridView2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "")
                    d += Convert.ToDouble(row.Cells[2].Value.ToString());
                else
                    d += 0;
            }

            label5.Text = d.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(DataGridView2.Size.Width, DataGridView2.Size.Height);
            DataGridView2.DrawToBitmap(bmp, DataGridView2.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

    }
}
