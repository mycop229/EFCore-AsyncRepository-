using Intership.Models;
using Intership.Repository.Interfaces;
using Intership.Repository.Class;

namespace Intership.Drivers
{
    public partial class DriversForm : Form
    {
        private readonly IDriverRepository<Driver> _driverRepository;
        public DriversForm()
        {
            _driverRepository = new DriverRepository();

            InitializeComponent();
        }
        private async void DriversForm_Load(object sender, EventArgs e)
        {
            SettingDataGridView();
            await LoadFullData();
        }
        private async Task LoadFullData()
        {
            var driverList = await _driverRepository.GetAll();
            LoadDataGridView(driverList);
        }
        private void LoadDataGridView(IEnumerable<Driver> driverList)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in driverList)
            {
                var row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = item.Id;
                row.Cells[1].Value = item.Surname;
                row.Cells[2].Value = item.Name;
                row.Cells[3].Value = item.MiddleName;
                row.Cells[4].Value = item.CarId;
                row.Cells[5].Value = item.Car.Number;
                row.Cells[6].Value = item.Car.LoadCapacity;

                dataGridView1.Rows.Add(row);
            }
        }
        private void SettingDataGridView()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Surname", "Фамилия");
            dataGridView1.Columns.Add("Name", "Имя");
            dataGridView1.Columns.Add("MiddleName", "Отчество");
            dataGridView1.Columns.Add("CarId", "Id автомобиля");
            dataGridView1.Columns.Add("NumberCar", "Номер автомобиля");
            dataGridView1.Columns.Add("LoadCapacity", "Грузоподъемонсть автомобиля");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new();
            Hide();
            main.Show();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            var driverList = await _driverRepository.FindBySurnameToList(textBox1.Text);
            LoadDataGridView(driverList);
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadFullData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddDriver addDriver = new();
            addDriver.Show();
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idDriver = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            var driver = await _driverRepository.GetById(idDriver);
            UpdateDriver updateDriver = new(driver);
            updateDriver.Show();
        }
    }
}
