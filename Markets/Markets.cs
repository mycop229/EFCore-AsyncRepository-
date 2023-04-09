using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Markets
{
    public partial class Markets : Form
    {
        private readonly IMarketRepository<Market> _marketRepository;
        public Markets()
        {
            _marketRepository = new MarketRepository();
            InitializeComponent();
        }
        private async void Markets_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            dataGridView1.DataSource = await _marketRepository.GetAll();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            await FindByName();
            textBox1.Clear();
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            await FindByAddress();
            textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new MainForm();
            Hide();
            menu.Show();
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var create = new CreateMarket();
            create.Show();
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idMarket = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            var result = await _marketRepository.GetById(idMarket);
            MarketUpdate market = new(result);
            market.Show();
        }
        private async Task FindByName()
        {
            dataGridView1.DataSource = await _marketRepository.GetByNameFirstOrDefault(textBox1.Text);
        }
        private async Task FindByAddress()
        {
            dataGridView1.DataSource = await _marketRepository.GetByAddress(textBox2.Text);
        }
    }
}
