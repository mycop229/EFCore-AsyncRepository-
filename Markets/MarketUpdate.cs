using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Markets
{
    public partial class MarketUpdate : Form
    {
        private readonly int _idMarket;

        private readonly IMarketRepository<Market> _marketRepository;
        private readonly ValidationService _validationService;
        public MarketUpdate(Market market)
        {
            InitializeComponent();
            textBox1.Text = market.Name;
            textBox2.Text = market.Address;
            _idMarket = market.Id;

            _marketRepository = new MarketRepository();
            _validationService = new ValidationService();
        }
        private void MarketUpdate_Load(object sender, EventArgs e)
        {

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await _marketRepository.Delete(_idMarket);
            MessageBox.Show("Магазин удален");
            Hide();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await UpdateMarket();
        }
        private async Task UpdateMarket()
        {
            var market = await _marketRepository.GetById(_idMarket);
            market.Name = textBox1.Text;
            market.Address = textBox2.Text;
            if (_validationService.IsValid(market))
            {
                await _marketRepository.Update(market);
                MessageBox.Show("Запись успешно обновлена");
                Hide();
            }
            else
            {
                MessageBox.Show("Нарушена валидация");
            }
        }
    }
}
