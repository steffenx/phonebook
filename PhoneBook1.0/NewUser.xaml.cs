using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class NewUser : Page
    {
        public NewUser()
        {
            this.InitializeComponent();
            EllStoryboard.Begin();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddmima.Text!=""&&txtAdduser.Text!="")
            {
                string user = txtAdduser.Text;
                string mima = txtAddmima.Text;
                using (var conn = AppDatabase.GetDbConnection())
                {
                    // 需要添加的 Person 对象。
                    var addLoginuser = new Login() { LoginUser = user, Mima = mima };
                    var count = conn.Insert(addLoginuser);
                    string msg = $"新用户创建成功!\n用户名：{addLoginuser.LoginUser}\n 密码：{addLoginuser.Mima}";
                    await new MessageDialog(msg).ShowAsync();
                }
            }
            if(txtAdduser.Text=="")
            {
                txtAdduser.PlaceholderText= "不能为空";
            }
            if (txtAddmima.Text == "")
            {
                txtAddmima.PlaceholderText = "不能为空";
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
