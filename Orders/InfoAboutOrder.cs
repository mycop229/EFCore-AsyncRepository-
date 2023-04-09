using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Orders
{
    public partial class InfoAboutOrder : Form
    {
        private readonly ICarRepository<Car> _carRepository;

        private int _carId;
        private string _txtFileName;
        public InfoAboutOrder(Order order)
        {
            _carRepository = new CarRepository();

            InitializeComponent();
            label1.Text = order.Market.Name;
            label17.Text = order.Market.Address;
            label2.Text = order.Driver.Surname;
            label26.Text = order.TotalPrice.ToString();
            _carId = order.Driver.CarId;
            _txtFileName = order.ProductListName;
        }
        private async void InfoAboutOrder_Load(object sender, EventArgs e)
        {
            await LoadCar();
            LoadTxt();
        }
        private async Task LoadCar()
        {
            var car = await _carRepository.GetById(_carId);

            label18.Text = car.Name;
            label21.Text = car.Number;
            label23.Text = car.LoadCapacity.ToString();
        }
        private void LoadTxt()
        {
            string path = Application.StartupPath + $"\\Txt\\{_txtFileName}.txt";
            using(StreamReader reader = new(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
        }
    }
}
