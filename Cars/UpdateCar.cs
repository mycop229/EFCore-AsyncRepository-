using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Cars
{
    public partial class UpdateCar : Form
    {
        private readonly int _carId;
        private readonly ICarRepository<Car> _carRepository;
        private readonly ValidationService _validationService;
        public UpdateCar(Car car)
        {
            InitializeComponent();
            textBox3.Text = car.Name;
            textBox2.Text = car.Number;
            textBox1.Text = car.LoadCapacity.ToString();
            _carId = car.Id;

            _carRepository = new CarRepository();
            _validationService = new ValidationService();
        }

        private void UpdateCar_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _carRepository.Delete(_carId);
            MessageBox.Show("Запись успешно удалена");
            Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await CarUpdate();
        }

        private async Task CarUpdate()
        {
            var car = await _carRepository.GetById(_carId);
            car.Name = textBox3.Text;
            car.Number = textBox2.Text;
            car.LoadCapacity = Convert.ToInt32(textBox1.Text);

            if (_validationService.IsValid(car))
            {
                await _carRepository.Update(car);
                MessageBox.Show("Запись успешно обновлена");
                Hide();
            }
            else
                MessageBox.Show("Валидация не пройдена");
        }
    }
}
