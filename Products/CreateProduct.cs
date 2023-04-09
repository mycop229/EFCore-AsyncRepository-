using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Products
{
    public partial class CreateProduct : Form
    {
        private readonly IProductRepository<Product> _productRepository;
        private readonly ValidationService _validationService;
        public CreateProduct()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
            _validationService = new ValidationService();
        }
        private void CreateProduct_Load(object sender, EventArgs e)
        {

        }
        private async Task<bool> InsertProductAsync()
        {
            try
            {
                var product = new Product()
                {
                    Name = textBox1.Text,
                    Description = richTextBox1.Text,
                    Price = Convert.ToDecimal(textBox2.Text),
                    Weight = Convert.ToDouble(textBox3.Text),
                    Value = Convert.ToInt32(textBox4.Text)
                };
                if (_validationService.IsValid(product))
                {
                    await _productRepository.Create(product);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Совет: вместо '.' используйте ','");
                return false;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (await InsertProductAsync())
            {
                MessageBox.Show("Продукт успешно добавлен");
                Hide();
            }
            else
            {
                MessageBox.Show("Валидация нарушена");
            }
        }
    }
}
