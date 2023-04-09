using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Cars
{
    public partial class CarsForm : Form
    {
        private readonly ICarRepository<Car> _carRepository;
        public CarsForm()
        {
            _carRepository = new CarRepository();

            InitializeComponent();
        }

        private async void CarsForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            dataGridView1.DataSource = await _carRepository.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new();
            Hide();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateCar create = new();
            create.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _carRepository.FindByNumber(textBox1.Text);
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            var car = await _carRepository.GetById(idCar);
            UpdateCar updateCar = new(car);
            updateCar.Show();
        }
    }
}
