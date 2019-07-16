using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PhoneBook_β1._0
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DeleteData : Page
    {
        ObservableCollection<UserData> accourt = new ObservableCollection<UserData>();
        SQLiteOperation sqliteoperation = new SQLiteOperation();
        public List<ListviewSelect> Users;
        ListviewSelect use = new ListviewSelect();
        public DeleteData()
        {
            this.InitializeComponent();
            //ImageBrush imgBrush = new ImageBrush();
            //var a =  use.Coveimage;
            //imgBrush.ImageSource = new BitmapImage(new Uri(a));
            this.Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            accourt.Clear();
            accourt = sqliteoperation.ReadData(accourt);
            Dgridview.ItemsSource = accourt;
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            var temp = Dgridview.SelectedItem as UserData;
            sqliteoperation.DeleteData(temp);
            var sql = "UPDATE from sqlite_sequence where name='UserData';";
            sqliteoperation.UpadateData(sql);
            accourt.Remove(temp);
        }

        private void Dgridview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var used = (UserData)e.ClickedItem;
            bir.Text = used.Birthday;
            city1.Text = used.City;
            mail.Text = used.Email;
        }
    }
}
