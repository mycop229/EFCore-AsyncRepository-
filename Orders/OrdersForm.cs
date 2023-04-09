using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Orders
{
    public partial class OrdersForm : Form
    {
        private readonly IOrderRepository<Order> _orderRepository;
        public OrdersForm()
        {
            _orderRepository = new OrderRepository();

            InitializeComponent();
        }

        private async void OrdersForm_Load(object sender, EventArgs e)
        {
            SettingDataGridView();
            await LoadFullData();
        }
        private async Task LoadFullData()
        {
            var orderList = await _orderRepository.GetAll();
            LoadDataGridView(orderList);
        }
        private void LoadDataGridView(IEnumerable<Order> orderList)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in orderList)
            {
                var row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = item.Id;
                row.Cells[1].Value = item.ProductListName;
                row.Cells[2].Value = item.Date;
                row.Cells[3].Value = item.TotalPrice;
                row.Cells[4].Value = item.Market.Name;
                row.Cells[5].Value = item.Market.Address;
                dataGridView1.Rows.Add(row);
            }
        }
        private void SettingDataGridView()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("ProductListName", "Название списка товаров");
            dataGridView1.Columns.Add("Date", "Дата поставки");
            dataGridView1.Columns.Add("TotalPrice", "Сумма поставки");
            dataGridView1.Columns.Add("MarketName", "Название магазина");
            dataGridView1.Columns.Add("MarketAddress", "Адрес магазина");
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadFullData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new();
            Hide();
            main.Show();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            var orderList = await _orderRepository.GetByName(textBox1.Text);
            LoadDataGridView(orderList);
            textBox1.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CreateOrder createOrder = new();
            createOrder.Show();
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idOrder = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            var order = await _orderRepository.GetById(idOrder);
            var info = new InfoAboutOrder(order);
            info.Show();
        }
    }
}
