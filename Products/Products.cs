using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Products
{
    public partial class Products : Form
    {
        private readonly IProductRepository<Product> _productRepository;
        public Products()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
        }
        private async void Products_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            dataGridView1.DataSource = await _productRepository.GetAll(); 
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var create = new CreateProduct();
            create.Show();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            await FindByNameAsync();
            textBox1.Clear();
        }
        private async Task FindByNameAsync()
        {
            dataGridView1.DataSource = await _productRepository.GetByNameList(textBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new MainForm();
            Hide();
            menu.Show();
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idProduct = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            var product = await _productRepository.GetById(idProduct);

            var updateProduct = new UpdateProduct(product);
            updateProduct.Show();
        }
    }
}
