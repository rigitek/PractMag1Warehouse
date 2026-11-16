using Microsoft.EntityFrameworkCore;
using PractMag1Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.Xml;
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
    /// Логика взаимодействия для ZoneWindow.xaml
    /// </summary>
    public partial class ZoneWindow : Window
    {
        PractMag1WarehouseContext db = new PractMag1WarehouseContext();

        ObservableCollection<Zone> ZonesList;

        List<Warehouse> warehouses;
        public ZoneWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Warehouses.Load();
            db.Zones.Load();

            warehouses = db.Warehouses.ToList();

            WarehouseComboBox.ItemsSource = warehouses;

            ZonesList = db.Zones.Local.ToObservableCollection();
            zonesGrid.ItemsSource = ZonesList;
        }

        private void Add_Zone(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse= WarehouseComboBox.SelectedItem as Warehouse;
            if (Type.Text == "")
            {
                MessageBox.Show("Заполните тип!");
                return;
            }
            if (Capacity.Text == "")
            {
                MessageBox.Show("Заполните вместимость!");
                return;
            }
            if (CurrentLoad.Text == "")
            {
                MessageBox.Show("Заполните загруженность!");
                return;
            }
            if (WarehouseComboBox.Text == "")
            {
                MessageBox.Show("Выберите склад!");
                return;
            }

            Zone zone= new Zone
            {
                Type = Type.Text,
                Capacity = int.Parse(Capacity.Text),
                CurrentLoad = int.Parse(CurrentLoad.Text),
                IsDynamic = isDynamic.IsChecked.Value,
                Warehouse = warehouse
            };

            db.Zones.Add(zone);
            db.SaveChanges();
            db.Zones.Load();

            Type.Text = "";
            Capacity.Text = "";
            CurrentLoad.Text = "";
            isDynamic.IsChecked= false;
            WarehouseComboBox.Text = "выбрать";
        }

        private void Edit_Zone(object sender, RoutedEventArgs e)
        {
            Zone? zone= zonesGrid.SelectedItem as Zone;

            if (zone is null) return;

            zone = db.Zones.Find(zone.Id);

            //если такой суещствует то меняем данные
            if (zone != null)
            {
                zone.Type = Type.Text;
                zone.Capacity = int.Parse(Capacity.Text);
                zone.CurrentLoad= int.Parse(CurrentLoad.Text);
                zone.IsDynamic= isDynamic.IsChecked.Value;
                zone.Warehouse= WarehouseComboBox.SelectedItem as Warehouse;

                db.SaveChanges();
                db.Zones.Load();
                zonesGrid.Items.Refresh();

                Type.Text = "";
                Capacity.Text = "";
                CurrentLoad.Text = "";
                isDynamic.IsChecked = false;
                WarehouseComboBox.Text = "выбрать";
            }
        }

        private void Delete_Zone(object sender, RoutedEventArgs e)
        {
            Zone? zone= zonesGrid.SelectedItem as Zone;
            if (zone is null) return;

            db.Zones.Remove(zone);
            db.SaveChanges();
        }

        private void zoneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Zone? zone= zonesGrid.SelectedItem as Zone;
            if (zone is null) return;

            Type.Text = zone.Type;
            Capacity.Text= zone.Capacity.ToString();
            CurrentLoad.Text = zone.CurrentLoad.ToString();
            isDynamic.IsChecked= zone.IsDynamic;
            WarehouseComboBox.SelectedItem = zone.Warehouse;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //выход в меню
            MainWindow mainMenu = new MainWindow();
            this.Close();
            mainMenu.Show();
        }
    }
}