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
    public partial class SzczegółySeansu : Form
    {
        public SzczegółySeansu()
        {
            InitializeComponent();
        }
        public static int get_number_seans;
        public static int get_number_sala;
        public static int get_number_film;
        public static bool check;

        private void SzczegółySeansu_Load(object sender, EventArgs e)
        {
            check = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            get_number_seans = ListaSeansów.id_seans;
            get_number_film = ListaSeansów.id_film;
            get_number_sala = ListaSeansów.id_sala;
            wczytajFilm();
            wczytajSale();
            wczytajSeans();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public void wczytajFilm()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("select * from Film where film_id =" + get_number_film + ";");
            textBox10.Text = tab.Rows[0][0].ToString();
            textBox2.Text = tab.Rows[0][1].ToString();
            textBox3.Text = tab.Rows[0][2].ToString();
            textBox4.Text = tab.Rows[0][3].ToString();
            textBox5.Text = tab.Rows[0][4].ToString();
        }
        public void wczytajSeans()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("select * from Seans where seans_id =" + get_number_seans + ";");
            dateTimePicker1.Value  = (DateTime)tab.Rows[0][3];
            textBox9.Text = tab.Rows[0][4].ToString();
        }
        public void wczytajSale()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("select * from sala where sala_id =" + get_number_sala + ";");
            textBox7.Text = tab.Rows[0][0].ToString();
            textBox8.Text = tab.Rows[0][1].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("DELETE from Seans where seans_id =" + get_number_seans + ";");
            MessageBox.Show("The Performance Has Been Successfully DELETED", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            ListaSeansów listaSeansów = new ListaSeansów();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            check = true;
            DodajSeans dodajSeans = new DodajSeans();
            if (dodajSeans.ShowDialog() != DialogResult.OK)
                return;
            DialogResult = DialogResult.OK;
        }
    }

}
