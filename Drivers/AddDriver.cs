using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Drivers
{
    public partial class AddDriver : Form
    {
        private int _idCar;
        private readonly ICarRepository<Car> _carRepository;
        private readonly IDriverRepository<Driver> _driverRepository;
        private readonly ValidationService _validationService;
        public AddDriver()
        {
            _carRepository = new CarRepository();
            _driverRepository = new DriverRepository();
            _validationService = new ValidationService();
            InitializeComponent();
        }

        private async void AddDriver_Load(object sender, EventArgs e)
        {
            await LoadCars();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
                await CreateDriver();
            else
                MessageBox.Show("Заполните поля ввода");
        }

        private async Task CreateDriver()
        {
            var driver = new Driver()
            {
                Surname = textBox3.Text,
                Name = textBox2.Text,
                MiddleName = textBox1.Text,
                CarId = _idCar
            };
            if (_validationService.IsValid(driver))
            {
                await _driverRepository.Create(driver);
                MessageBox.Show("Запись успешно добавлена");
                Hide();
            }
            else
                MessageBox.Show("Валидация нарушена");
        }
        private async Task LoadCars()
        {
            var carList = await _carRepository.GetAll();
            foreach (var item in carList)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var car = await _carRepository.FindByName(comboBox1.Text);
            textBox4.Text = car.Name;
            textBox5.Text = car.Number;
            textBox6.Text = car.LoadCapacity.ToString();
            _idCar = car.Id;
        }
    }
}
