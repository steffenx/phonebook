using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace PhoneBook_β1._0
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {            
            this.InitializeComponent();
            int a = DateTime.Now.Hour;
            if (a > 18 || a <= 5)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/添加.jpg", UriKind.Absolute));
                gd_backimage.Background = imageBrush;
            }
            if (a < 12 && a > 5)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/denglu2.jpg", UriKind.Absolute));
                gd_backimage.Background = imageBrush;
            }
            if (a >= 12 && a <= 18)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/denglu3.jpg", UriKind.Absolute));
                gd_backimage.Background = imageBrush;
            }
        }

        private async void denglu_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = AppDatabase.GetDbConnection())
            {
                StringBuilder msg = new StringBuilder();
                var dbLogin = conn.Table<Login>();
                int a=1;
                foreach (var login in dbLogin)
                {
                    if (suser.Text == login.LoginUser && smima.Password == login.Mima)
                    {
                        a = 0;
                        break;
                    }
                    if (suser.Text != login.LoginUser|| smima.Password != login.Mima)
                    {                        
                        a = 1;                       
                    }
                    //if (smima.Password != login.Mima)
                    //{                      
                    //    a = 2;                      
                    //}
                }
                if (a == 0)
                {
                    Frame.Navigate(typeof(NavigationFace));
                }
                if (a == 1)
                {                    
                    msg.AppendLine($"账户或密码错误\n请重新输入");
                    await new MessageDialog(msg.ToString()).ShowAsync();
                }

                //if (a == 2)
                //{
                //    await new MessageDialog(msg.ToString()).ShowAsync();
                //    msg.AppendLine($"密码错误");
                //    await new MessageDialog(msg.ToString()).ShowAsync();
                //}
            }
        }

        private void zhice_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUser));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mypro.IsActive = true;
            mypro.Visibility = Visibility.Visible;
            try
            {
                var position = await GPSselect.GetPosition();//地理位置
                Root MyWeahter = await Weather.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);//经纬度
                string icon = string.Format("ms-appx:///Assets/tick_weather/{0}.png", MyWeahter.data.numtq);//获取图片
                MyImg.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                myname.Text = MyWeahter.data.cityName;
                myqw.Text = MyWeahter.data.qw + "℃";  //输出
                mytq.Text = MyWeahter.data.tq;
            }
            catch { myname.Text = "天气获取失败！"; }
            mypro.IsActive = false;
            mypro.Visibility = Visibility.Collapsed;
        }
    }
}
