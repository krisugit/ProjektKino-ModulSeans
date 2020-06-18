using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ListaSeansów : Form
    {
        public static int id_seans,id_sala,id_film;
        public ListaSeansów()
        {
            InitializeComponent();
        }

        private void ListaSeansów_Load(object sender, EventArgs e)
        {
            wczytajSeanse();
            dataGridView1_Resize(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajSeans dodajSeans = new DodajSeans();
            if (dodajSeans.ShowDialog() != DialogResult.OK)
                return;
            wczytajSeanse();
            
        }
        public void wczytajSeanse()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("Select * From Seans");

            dataGridView1.DataSource = tab;
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            int cw = (dataGridView1.ClientSize.Width / dataGridView1.Columns.Count) - 3;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = cw;
            }
        }

        public void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_seans= Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            id_film = Convert.ToInt16(dataGridView1.CurrentRow.Cells[1].Value);
            id_sala= Convert.ToInt16(dataGridView1.CurrentRow.Cells[2].Value);
            SzczegółySeansu szczegółySeansu = new SzczegółySeansu();
            if (szczegółySeansu.ShowDialog() != DialogResult.OK)
                return;
            wczytajSeanse();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellDoubleClick(sender, e);
        }
    }
}

