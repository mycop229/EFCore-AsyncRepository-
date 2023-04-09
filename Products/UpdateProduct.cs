using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Products
{
    public partial class UpdateProduct : Form
    {
        private readonly IProductRepository<Product> _productRepository;
        private readonly int _idProduct;
        public UpdateProduct(Product product)
        {
            InitializeComponent();
            textBox1.Text = product.Name;
            richTextBox1.Text = product.Description;
            textBox2.Text = product.Price.ToString();
            textBox3.Text = product.Weight.ToString();
            textBox4.Text = product.Value.ToString();
            _idProduct = product.Id;
            _productRepository = new ProductRepository();
        }
        private void UpdateProduct_Load(object sender, EventArgs e)
        {

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await (DeleteProductAsync());
            MessageBox.Show("Продукт удален");
            Hide();
        }
        private async Task DeleteProductAsync()
        {
            await _productRepository.Delete(_idProduct);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await UpdateProductAsync();
            MessageBox.Show("Продукт обновлен");
            Hide();
        }
        private async Task UpdateProductAsync()
        {
            var product = await _productRepository.GetById(_idProduct);
            product.Name = textBox1.Text;
            product.Description = richTextBox1.Text;
            product.Price = Convert.ToDecimal(textBox2.Text);
            product.Weight = Convert.ToDouble(textBox3.Text);
            product.Value = Convert.ToInt32(textBox4.Text);

            await _productRepository.Update(product);
        }
    }
}
