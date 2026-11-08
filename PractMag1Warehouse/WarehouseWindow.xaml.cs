using Microsoft.EntityFrameworkCore;
using PractMag1Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PractMag1Warehouse
{
    /// <summary>
    /// Логика взаимодействия для WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        PractMag1WarehouseContext db=new PractMag1WarehouseContext();

        ObservableCollection<Warehouse> warehouses;
        public WarehouseWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Warehouses.Load();
            //загрузка таблиц

            //связь с интерфейсом
            warehouses = db.Warehouses.Local.ToObservableCollection();
            wareHousesGrid.ItemsSource = warehouses;
        }

        private void Add_Warehouse(object sender, RoutedEventArgs e)
        {
            //вылетает окно, если поле пропущно
            if (name.Text == "")
            {
                MessageBox.Show("Заполните поле название здания!");
                return;
            }
            if (address.Text == "")
            {
                MessageBox.Show("Заполните поле адрес здания!");
                return;
            }

            //если все заполнено, то создается новое здание
            Warehouse warehouse= new Warehouse
            {
                Name = name.Text,
                Address = address.Text,
            };

            //добавление записи в бд
            db.Warehouses.Add(warehouse);
            db.SaveChanges();
            //сохранение в бд
            db.Warehouses.Load();
            //перезагрузка таблицы

            name.Text = "";
            address.Text = "";
            //обнуляем поля
        }

        private void Edit_Warehouse(object sender, RoutedEventArgs e)
        {
            Warehouse? warehouse = wareHousesGrid.SelectedItem as Warehouse;
            // если ни одного объекта не выделено, выходим
            if (warehouse is null) return;

            //находим такую запись
            warehouse = db.Warehouses.Find(warehouse.Id);

            //если такой суещствует то меняем данные
            if (warehouse!= null)
            {
                warehouse.Name= name.Text;
                warehouse.Address = address.Text;

                db.SaveChanges();
                db.Warehouses.Load();
                wareHousesGrid.Items.Refresh();

                name.Text = "";
                address.Text = "";
            }
        }

        private void Delete_Warehouse(object sender, RoutedEventArgs e)
        {
            Warehouse? warehouse= wareHousesGrid.SelectedItem as Warehouse;
            // если ни одного объекта не выделено, выходим
            if (warehouse is null) return;
            //удаляем объект
            db.Warehouses.Remove(warehouse);
            //сохранение данных в бд
            db.SaveChanges();
            db.Warehouses.Load();

            name.Text = "";
address.Text = "";
            //обнуляем поля
        }
    }
}
