using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PhoneBook_β1._0
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainFace : Page
    {
        //ObservableCollection<UserData> accourt = new ObservableCollection<UserData>();
        public List<ListviewSelect> Users;
        ListviewSelect use = new ListviewSelect();

        //public object ServicePointManager { get; private set; }

        public MainFace()
        {
            this.InitializeComponent();
            
            Users = Usermanager.Getuser();

            //ImageBrush imgBrush = new ImageBrush();
            //var a = use.Coveimage;
            //imgBrush.ImageSource = new BitmapImage(new Uri(a));
            webview.Navigate(new Uri("ms-appx-web:///Javascript/MouseMove.html", UriKind.Absolute));

        }

        private async void listview1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var use = (ListviewSelect)e.ClickedItem;
            nameid.Text = use.Userid;
            number.Text = use.Phonenumber;
            birthday.Text = use.Bir;
            mail1.Text = use.Mail;
            city1.Text = use.City;

            ImageBrush imgBrush = new ImageBrush();
            var a = use.Coveimage;
            imgBrush.ImageSource = new BitmapImage(new Uri(a));
            ellips.Fill = imgBrush;
            try
            {
                Root MyCitynum = await GetCitynum.GetOperator(use.Phonenumber);
                cityphone.Text = MyCitynum.province + "  " + MyCitynum.city + "  " + MyCitynum.@operator;
            }
            catch { cityphone.Text = "归属地获取失败！"; }
            //Uri uri = new Uri("ms-appx:///Assets/pikaqiu.png");
            //BitmapImage bitmap = new BitmapImage(uri);
        }
    }
}
