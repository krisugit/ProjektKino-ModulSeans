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
    public partial class DodajSeans : Form
    {
        public DodajSeans()
        {
            InitializeComponent();

        }
        bool check;
        int get_number_sala;
        int get_number_film;
        int get_number_seans;

        private void DodajSeans_Load(object sender, EventArgs e)
        {
            check = SzczegółySeansu.check;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            WczytajFilmy();
            WczytajSale();
            Check();           
        }

    public void WczytajFilmy()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("select * from Film");

            comboBox1.DataSource = tab;
            comboBox1.DisplayMember = "tytuł";
            comboBox1.ValueMember = "film_id";
        }
    public void WczytajSale()
        {
            KinoClass cla = new KinoClass();
            DataTable tab = cla.table_get_data("select * from Sala");

            comboBox2.DataSource = tab;
            comboBox2.DisplayMember = "nazwa";
            comboBox2.ValueMember = "sala_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KinoClass cla = new KinoClass();
            if (check != true)
            {
                bool turn;
                turn = cla.query_command("insert into Seans(film_id,sala_id,data_czas,czas_reklamy) values ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm") + "','" + numericUpDown1.Value + "')");
                if (turn)
                {
                    MessageBox.Show("The Performance Has Been Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                bool turn;
                turn = cla.query_command("Update Seans SET film_id ='" + comboBox1.SelectedValue + "', sala_id='" + comboBox2.SelectedValue + "', data_czas= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm") + "', czas_reklamy='" + numericUpDown1.Value + "' where seans_id="+get_number_seans+";");
                if (turn)
                {
                    MessageBox.Show("The Performance Has Been Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            DialogResult = DialogResult.OK;
            ListaSeansów listaSeansów = new ListaSeansów();

        }
        public void Check()
        {
            if (check == true)
            {
                get_number_film = SzczegółySeansu.get_number_film;
                get_number_sala = SzczegółySeansu.get_number_sala;
                get_number_seans = SzczegółySeansu.get_number_seans;
                comboBox1.SelectedValue = get_number_film;
                comboBox2.SelectedValue = get_number_sala;
                KinoClass cla = new KinoClass();
                DataTable tab = cla.table_get_data("select data_czas,czas_reklamy from Seans where seans_id= " + get_number_seans + ";");
                dateTimePicker1.Value = (DateTime)tab.Rows[0][0];
                numericUpDown1.Value = (int)tab.Rows[0][1];
            }
            else
            {
                dateTimePicker1.MinDate = DateTime.Now;
            }
        }
    }
}
