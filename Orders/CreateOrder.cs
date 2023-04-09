using Intership.Models;
using Intership.Models.AdditionalModels;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.Orders
{
    public partial class CreateOrder : Form
    {
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IProductRepository<Product> _productRepository;
        private readonly IMarketRepository<Market> _marketRepository;
        private readonly IDriverRepository<Driver> _driverRepository;

        private List<ProductVM> _productList;

        private int _productId = default;
        private int _amountProduct = default;
        private decimal _totalPriceProduct = default;
        private double _totalWeightProduct = default;

        private int _marketId = default;
        private int _driverId = default;
        private string? _nameTxtFile;

        private decimal _totalPriceOrder = default;
        private double _totalWeightOrder = default;


        public CreateOrder()
        {
            _orderRepository = new OrderRepository();
            _productRepository = new ProductRepository();
            _marketRepository = new MarketRepository();
            _driverRepository = new DriverRepository();

            _productList = new List<ProductVM>();

            InitializeComponent();
        }

        private async void CreateOrder_Load(object sender, EventArgs e)
        {
            await LoadProducts();
            await LoadMarkets();
            await LoadDrivers();
        }
        #region Products
        private async Task LoadProducts()
        {
            var marketList = await _productRepository.GetAll();
            foreach(var item in marketList)
            {
                comboBox1.Items.Add(item.Name);
            }
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadProduct();
        }

        private async Task LoadProduct()
        {
            var product = await _productRepository.GetByNameFirstOrDefault(comboBox1.Text);
            label3.Text = product.Value.ToString();
            label4.Text = product.Weight.ToString();
            label6.Text = product.Price.ToString();
            label10.Text = product.Name;
            _productId = product.Id;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _amountProduct = Convert.ToInt32(textBox1.Text);
                decimal price = Convert.ToDecimal(label6.Text);
                _totalPriceProduct = _amountProduct * price;
                label13.Text = _totalPriceProduct.ToString();

                double weight = Convert.ToDouble(label4.Text);
                _totalWeightProduct = weight * _amountProduct;
                label14.Text = _totalWeightProduct.ToString();
            }
            catch { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_amountProduct > 0 & comboBox1.Text != "" & Convert.ToInt32(label3.Text) >= _amountProduct)
                {
                    ProductVM productVM = new()
                    {
                        Id = _productId,
                        Name = label10.Text,
                        TotalSum = _totalPriceProduct,
                        TotalValue = _amountProduct,
                        TotalWeight = _totalWeightProduct
                    };

                    _totalWeightOrder += _totalWeightProduct;
                    label27.Text = _totalWeightOrder.ToString();

                    _totalPriceOrder += _totalPriceProduct;
                    label26.Text = _totalPriceOrder.ToString();

                    _productList.Add(productVM);

                    listBox1.Items.Add($"Продукт: {productVM.Name} | Сумма: {productVM.TotalSum} | Количество: {productVM.TotalValue} | Вес: {productVM.TotalWeight} кг.");
                }
                else
                {
                    MessageBox.Show("Выберите количество продуктов / Выберите продукт / Продукта не складе не достаточно");
                }
            }
            catch
            {
                MessageBox.Show("Выберите продукт");
            }
        }

        #endregion
        #region Markets

        private async Task LoadMarkets()
        {
            var marketList = await _marketRepository.GetAll();
            foreach(var item in marketList)
            {
                comboBox2.Items.Add(item.Name);
            }
        }
        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = await _marketRepository.GetByNameFirstOrDefault(comboBox2.Text);
            label17.Text = result.Address;
            _marketId = result.Id;
        }

        #endregion
        #region Drivers

        private async Task LoadDrivers()
        {
            var drivetList = await _driverRepository.GetAll();
            foreach(var item in drivetList)
            {
                comboBox3.Items.Add(item.Surname);
            }
        }
        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = await _driverRepository.FindBySurnameFirstOrDefault(comboBox3.Text);
            label18.Text = result.Car.Name;
            label21.Text = result.Car.Number;
            label23.Text = result.Car.LoadCapacity.ToString();
            _driverId = result.Id;
        }


        #endregion
        #region CreateOrder
        private async void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" & comboBox2.Text != "" & comboBox3.Text != "" & listBox1.Items.Count > 1)
            {
                await CreateTxt();
                await UpdateProductValue();
                await OrderCreate();
            }
            else
                MessageBox.Show("Заполните все данные");
        }
        private async Task CreateTxt()
        {
            _nameTxtFile = $"{comboBox2.Text}_{dateTimePicker1.Text}_{_totalPriceOrder}pyб.";
            string path = (Application.StartupPath + $"\\Txt\\{_nameTxtFile}.txt");

            FileStream fileStream = File.Create(path);
            fileStream.Dispose();

            TextWriter writer = new StreamWriter(path);
            writer.WriteLine("Продукты:");
            foreach (var item in listBox1.Items)
            {
                writer.WriteLine(item.ToString());
            }
            writer.WriteLine("-----------------------------------------------------------");
            writer.WriteLine($"Магазин: {comboBox2.Text}");
            writer.WriteLine($"Общая сумма заказа: {_totalPriceOrder}");
            writer.WriteLine($"Общий вес заказа: {_totalWeightOrder}");


            writer.Close();
        }
        private async Task UpdateProductValue()
        {
            foreach(var item in _productList)
            {
                var result = await _productRepository.GetById(item.Id);
                result.Value = result.Value - item.TotalValue;
                await _productRepository.Update(result);
            }
        }
        private async Task OrderCreate()
        {
            Order order = new Order()
            {
                ProductListName = _nameTxtFile,
                Date = dateTimePicker1.Value,
                MarketId = _marketId,
                DriverId = _driverId,
                TotalPrice = _totalPriceOrder
            };
            await _orderRepository.Create(order);
            MessageBox.Show("Запись успешно добавлена");
            Hide();
        }

        #endregion
    }
}
