using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Cars
{
    public partial class CreateCar : Form
    {
        private readonly ICarRepository<Car> _carRepository;
        private readonly ValidationService _validationService;
        public CreateCar()
        {
            _carRepository = new CarRepository();
            _validationService = new ValidationService();

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                await InsertCar();
                Hide();
            }
        }

        private async Task InsertCar()
        {
            Car car = new()
            {
                Name = textBox3.Text,
                Number = textBox2.Text,
                LoadCapacity = Convert.ToInt32(textBox1.Text)
            };
            if (_validationService.IsValid(car))
            {
                await _carRepository.Create(car);
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                MessageBox.Show("Валидация не пройдена, проверьте введеные значения");
            }
        }

        private void CreateCar_Load(object sender, EventArgs e)
        {

        }
    }
}
