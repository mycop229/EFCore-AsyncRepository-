using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;


namespace Intership.Markets
{
    public partial class CreateMarket : Form
    {
        private readonly IMarketRepository<Market> _marketRepository;
        private readonly ValidationService _validationService;
        public CreateMarket()
        {
            InitializeComponent();
            _marketRepository = new MarketRepository();
            _validationService = new ValidationService();
        }
        private void CreateMarket_Load(object sender, EventArgs e)
        {

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (await InsertMarketAsync())
            {
                MessageBox.Show("Магазин добавлен");
                Hide();
            }
            else
            {
                MessageBox.Show("Валидация не пройдена");
            }
        }
        private async Task<bool> InsertMarketAsync()
        {
            var market = new Market()
            {
                Name = textBox1.Text,
                Address = textBox2.Text
            };
            if (_validationService.IsValid(market))
            {
                await _marketRepository.Create(market);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
