using System;
using System.Collections.Generic;
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
    public sealed partial class WeatherHeFeng : Page
    {
        public WeatherHeFeng()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mypro.IsIndeterminate = true;
            mypro.Visibility = Visibility.Visible;
            try
            {
                Getcity getcity = new Getcity();
                var position = await GPSselect.GetPosition();//地理位置
                Root MyWeahter = await HeFengWeather.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);//经纬度
                
                //背景
                string a= MyWeahter.HeWeather6[0].now.cond_txt;
                if (a == "晴")
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/晴.jpg", UriKind.Absolute));
                    gd_backimage.Background = imageBrush;
                }

                else if (a == "多云" || a == "少云" || a == "晴间多云")
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/多云.jpg", UriKind.Absolute));
                    gd_backimage.Background = imageBrush;
                }

                else if (a == "阵雨" || a == "小雨" || a == "中雨" || a == "大雨" || a == "毛毛雨/细雨")
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/下雨.jpg", UriKind.Absolute));
                    gd_backimage.Background = imageBrush;
                }

                else if (a == "小雪" || a == "中雪" || a == "中雨" || a == "大雪" || a == "雨夹雪" || a == "雨雪天气")
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/下雨.jpg", UriKind.Absolute));
                    gd_backimage.Background = imageBrush;
                }
                else
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/其他.jpg", UriKind.Absolute));
                    gd_backimage.Background = imageBrush;
                }
            

                //当日气象
                string icon = string.Format("ms-appx:///Assets/HF_Weather/{0}.png", MyWeahter.HeWeather6[0].now.cond_code);//获取图片
                ico.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                cityname.Text = MyWeahter.HeWeather6[0].basic.admin_area + MyWeahter.HeWeather6[0].basic.location;
                wea1.Text = MyWeahter.HeWeather6[0].now.tmp + "℃";
                Wea1.Text = MyWeahter.HeWeather6[0].now.cond_txt;
                zhiliang.Text = MyWeahter.HeWeather6[0].lifestyle[7].brf;
                fengxiang.Text = "🌀"+ MyWeahter.HeWeather6[0].now.wind_dir;
                fengsu.Text = MyWeahter.HeWeather6[0].now.wind_sc;
                shudu.Text = "💧" + MyWeahter.HeWeather6[0].now.hum;

                //每日天气（今天）
                day1.Text = MyWeahter.HeWeather6[0].daily_forecast[0].date;
                string icon1 = string.Format("ms-appx:///Assets/HF_Weather/{0}.png", MyWeahter.HeWeather6[0].daily_forecast[0].cond_code_d);//获取图片
                ico1.Source = new BitmapImage(new Uri(icon1, UriKind.Absolute));
                wea2.Text = "🌡"+MyWeahter.HeWeather6[0].daily_forecast[0].tmp_min + "-" + MyWeahter.HeWeather6[0].daily_forecast[0].tmp_max + "℃";
                Wea2.Text = MyWeahter.HeWeather6[0].daily_forecast[0].cond_txt_d;

                //明天
                day2.Text = MyWeahter.HeWeather6[0].daily_forecast[1].date;
                string icon2 = string.Format("ms-appx:///Assets/HF_Weather/{0}.png", MyWeahter.HeWeather6[0].daily_forecast[1].cond_code_d);//获取图片
                ico2.Source = new BitmapImage(new Uri(icon2, UriKind.Absolute));
                wea3.Text = "🌡" + MyWeahter.HeWeather6[0].daily_forecast[1].tmp_min + "-" + MyWeahter.HeWeather6[0].daily_forecast[1].tmp_max + "℃";
                Wea3.Text = MyWeahter.HeWeather6[0].daily_forecast[1].cond_txt_d;

                //后天
                day3.Text = MyWeahter.HeWeather6[0].daily_forecast[2].date;
                string icon3 = string.Format("ms-appx:///Assets/HF_Weather/{0}.png", MyWeahter.HeWeather6[0].daily_forecast[2].cond_code_d);//获取图片
                ico3.Source = new BitmapImage(new Uri(icon3, UriKind.Absolute));
                wea4.Text = "🌡" + MyWeahter.HeWeather6[0].daily_forecast[2].tmp_min + "-" + MyWeahter.HeWeather6[0].daily_forecast[2].tmp_max + "℃";
                Wea4.Text = MyWeahter.HeWeather6[0].daily_forecast[2].cond_txt_d;

                //今日详情
                morning.Text = "🌝预计今天白天" + MyWeahter.HeWeather6[0].daily_forecast[0].cond_txt_d;
                night.Text = "🌜预计今天夜间" + MyWeahter.HeWeather6[0].daily_forecast[0].cond_txt_n;
                fengshu.Text = "🌀" + MyWeahter.HeWeather6[0].daily_forecast[0].wind_spd;

                rain.Text = MyWeahter.HeWeather6[0].daily_forecast[0].pop;
                rainl.Text = MyWeahter.HeWeather6[0].now.pcpn;
                ziwaixian.Text ="🏖"+ MyWeahter.HeWeather6[0].daily_forecast[0].uv_index;
                yaqiang.Text = MyWeahter.HeWeather6[0].daily_forecast[0].pres;

                richu.Text = "🌞" + MyWeahter.HeWeather6[0].daily_forecast[0].sr;
                riluo.Text = "🌞" + MyWeahter.HeWeather6[0].daily_forecast[0].ss;

                //生活指数
                shzs.Text = MyWeahter.HeWeather6[0].lifestyle[0].brf;
                shzsxx.Text = MyWeahter.HeWeather6[0].lifestyle[0].txt;

                xczs.Text = MyWeahter.HeWeather6[0].lifestyle[6].brf;
                xcxx.Text = MyWeahter.HeWeather6[0].lifestyle[6].txt;

                cyzs.Text = MyWeahter.HeWeather6[0].lifestyle[1].brf;
                cyxx.Text = MyWeahter.HeWeather6[0].lifestyle[1].txt;

                gmzs.Text = MyWeahter.HeWeather6[0].lifestyle[2].brf;
                gmxx.Text = MyWeahter.HeWeather6[0].lifestyle[2].txt;

                ydzs.Text = MyWeahter.HeWeather6[0].lifestyle[3].brf;
                ydxx.Text = MyWeahter.HeWeather6[0].lifestyle[3].txt;

                zyxzs.Text = MyWeahter.HeWeather6[0].lifestyle[5].brf;
                zyxxx.Text = MyWeahter.HeWeather6[0].lifestyle[5].txt;

                kqzs.Text = MyWeahter.HeWeather6[0].lifestyle[7].brf;
                kqxx.Text = MyWeahter.HeWeather6[0].lifestyle[7].txt;

              
            }
            catch { cityname.Text = "获取天气失败！"; }
            mypro.IsIndeterminate = false;
            mypro.Visibility = Visibility.Collapsed;
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
