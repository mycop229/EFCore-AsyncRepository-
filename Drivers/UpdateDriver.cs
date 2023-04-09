using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Drivers
{
    public partial class UpdateDriver : Form
    {
        private int _idCar;
        private int _idDriver;
        private readonly ICarRepository<Car> _carRepository;
        private readonly IDriverRepository<Driver> _driverRepository;
        private readonly ValidationService _validationService;
        public UpdateDriver(Driver driver)
        {
            _carRepository = new CarRepository();
            _driverRepository = new DriverRepository();
            _validationService = new ValidationService();
            InitializeComponent();

            textBox3.Text = driver.Surname;
            textBox2.Text = driver.Name;
            textBox1.Text = driver.MiddleName;
            comboBox1.Text = driver.Car.Name;
            _idDriver = driver.Id;
            _idCar = driver.CarId;

        }
        private async void UpdateDriver_Load(object sender, EventArgs e)
        {
            await LoadCars();
        }
        private async Task LoadCars()
        {
            var carList = await _carRepository.GetAll();
            foreach (var item in carList)
            {
                comboBox1.Items.Add(item.Name);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await _driverRepository.Delete(_idDriver);
            MessageBox.Show("Запись успешно удалена");
            Hide();
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var car = await _carRepository.FindByName(comboBox1.Text);
            textBox4.Text = car.Name;
            textBox5.Text = car.Number;
            textBox6.Text = car.LoadCapacity.ToString();
            _idCar = car.Id;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await DriverUpdate();
        }
        private async Task DriverUpdate()
        {
            var driver = await _driverRepository.GetById(_idDriver);
            driver.Surname = textBox3.Text;
            driver.Name = textBox2.Text;
            driver.MiddleName = textBox1.Text;
            driver.CarId = _idCar;

            if (_validationService.IsValid(driver))
            {
                await _driverRepository.Update(driver);
                MessageBox.Show("Запись успешно обновлена");
            }
            else
                MessageBox.Show("Валидация нарушена");
        }
    }
}
