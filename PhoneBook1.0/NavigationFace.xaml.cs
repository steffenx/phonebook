using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PhoneBook_β1._0
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NavigationFace : Page
    {
        SQLiteOperation sqliteoperation = new SQLiteOperation();
        public NavigationFace()
        {
            this.InitializeComponent();
            back.Visibility = Visibility.Collapsed;
        }

        private void hanbao_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = !splitview.IsPaneOpen;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (fram.CanGoBack)
            {
                first.IsSelected = true;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (first.IsSelected)
            {
                fram.Navigate(typeof(MainFace));
                name.Text = "主页";
            }
            else if (add.IsSelected)
            {
                back.Visibility = Visibility.Visible;
                fram.Navigate(typeof(AddFace));
                name.Text = "添加";
            }
            else if (delete.IsSelected)
            {
                back.Visibility = Visibility.Visible;
                fram.Navigate(typeof(DeleteData));
                name.Text = "删除";
            }
            else if (revise.IsSelected)
            {
                back.Visibility = Visibility.Visible;
                fram.Navigate(typeof(ReviseData));
                name.Text = "修改（双击列表项修改联系人）";
            }
            else if (revis.IsSelected)
            {
                back.Visibility = Visibility.Visible;
                fram.Navigate(typeof(QCellCore));
                name.Text = "归属地查询";
            }
            else if (weather.IsSelected)
            {
                back.Visibility = Visibility.Visible;
                fram.Navigate(typeof(WeatherHeFeng));
                name.Text = "天气";
            }
        }

        private async void selectbox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            StringBuilder msg = new StringBuilder();
            ObservableCollection<UserData> accourtCheck = new ObservableCollection<UserData>();
            var result = sqliteoperation.CheckData(selectbox.Text.Trim());
            foreach (var item in result)
            {

                msg.AppendLine($"  姓名：{item.Name}\n 电话：{item.Phonenumber}\n 生日：{item.Birthday}\n 城市：{item.City}\n 邮件：{item.Email}\n");

            }
            await new MessageDialog(msg.ToString()).ShowAsync();
        }
    }
}
