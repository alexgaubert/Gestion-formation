using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_formation
{
    public partial class FormPersonne : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public FormPersonne()
        {
            InitializeComponent();
            chargedgv();
        }

        public void chargedgv()
        {
            bindingSource1.DataSource = controleur.Vmodele.Dv_personne;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns[0].Visible = false;

            int vwidth = dataGridView1.RowHeadersWidth;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Visible)
                {
                    vwidth = vwidth + dataGridView1.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
                }
            }
            dataGridView1.Width = vwidth;
            if (dataGridView1.ScrollBars.Equals(ScrollBars.Both) | dataGridView1.ScrollBars.Equals(ScrollBars.Vertical))
            {
                dataGridView1.Width += 20;
            }
            dataGridView1.Refresh();

            comboBox1.Items.Clear();
            List<KeyValuePair<int, string>> FList = new List<KeyValuePair<int, string>>();
            FList.Add(new KeyValuePair<int, string>(0, "Tout les groupes"));
            comboBox1.Items.Add("Tout les groupes");
            for (int i = 0; i < controleur.Vmodele.Dv_formation.ToTable().Rows.Count; i++)
            {
                FList.Add(new KeyValuePair<int,
                string>((int)controleur.Vmodele.Dv_formation.ToTable().Rows[i][0],
                controleur.Vmodele.Dv_formation.ToTable().Rows[i][1].ToString()));
            }
            comboBox1.DataSource = FList;
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void changefiltre()
        {
            string num = comboBox1.SelectedValue.ToString();
            int n = Convert.ToInt32(num);
            if (n == 0)
                controleur.Vmodele.Dv_personne.RowFilter = "";
            else
            {
                string Filter = "IdFormation = '" + n + "'";
                controleur.Vmodele.Dv_personne.RowFilter = Filter;
            }
            dataGridView1.Refresh();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changefiltre();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controleur.crud_personne('c', dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            bindingSource1.MoveLast();
            bindingSource1.MoveFirst();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                controleur.crud_personne('u', dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                bindingSource1.MoveLast();
                bindingSource1.MoveFirst();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Sélectionner une ligne à modifier");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                controleur.crud_personne('d', dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                bindingSource1.MoveLast();
                bindingSource1.MoveFirst();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Sélectionner une ligne à modifier");
            }
        }
    }
}
