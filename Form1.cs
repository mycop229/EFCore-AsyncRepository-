using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership
{
    public partial class Form1 : Form
    {
        private readonly IRoleRepository<Role> _roleRepository;
        private readonly ValidationService _validationService;
        public Form1()
        {
            InitializeComponent();
            _roleRepository = new RoleRepository();
            _validationService = new ValidationService();
        }

        #region Загрузка формы
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            dataGridView1.DataSource = await _roleRepository.GetAll();
        }
        #endregion

        #region Фильтрация 
        private async void button1_Click(object sender, EventArgs e)
        {
            await FoundById();
        }
        private async Task FoundById()
        {
            var result = await _roleRepository.GetById(Convert.ToInt32(textBox1.Text));
            if (result != null)
                label3.Text = result.Name;
            else
                MessageBox.Show("Записи с таким id не существует");
        }
        #endregion

        #region Добавление 
        private async void button2_Click(object sender, EventArgs e)
        {
            if (await CreateRole())
            {
                MessageBox.Show("Запись успешно добавлена");
                await LoadData();
            }
            else
            {
                MessageBox.Show("Валидация не пройдена");
            }
        }
        private async Task<bool> CreateRole()
        {
            var role = new Role()
            {
                Name = textBox2.Text
            };
            if (_validationService.IsValid(role))
            {
                await _roleRepository.Create(role);
                return true;
            }

            return false;
        }
        #endregion

        #region Удаление
        private async void button3_Click(object sender, EventArgs e)
        {
            if (await DeleteRole())
            {
                MessageBox.Show("Запись успешно удалена");
                await LoadData();
            }
            else
            {
                MessageBox.Show("Записи с таким ID не найдено");
            }
        }
        private async Task<bool> DeleteRole()
        {
            return await _roleRepository.Delete(Convert.ToInt32(textBox3.Text));
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}