using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class ReviseData : Page
    {
        UserData updateItem;
        ObservableCollection<UserData> accourt = new ObservableCollection<UserData>();
        SQLiteOperation sqliteoperation = new SQLiteOperation();
        int updateItemIndex;

        public ReviseData()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            accourt.Clear();
            accourt = sqliteoperation.ReadData(accourt);
            listview1.ItemsSource = accourt;
        }

        private void dataListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            updateItem = listview1.SelectedItem as UserData; //选中项的类型是你定义的model类型；
            var updateItemIndex = accourt.IndexOf(updateItem);//获取索引

            txtAddName.Text = updateItem.Name; //把ID显示到ID文本上 下面就同此处一样了
            txtAddnum.Text = updateItem.Phonenumber;
            txtAddbir.Text = updateItem.Birthday;
            txtAddcity.Text = updateItem.City;
            txtAddmail.Text = updateItem.Email;
            AddImage.Text = updateItem.Image;
            updatebutton.IsEnabled = true;

            ImageBrush imgBrush = new ImageBrush();
            var ImageUri = updateItem.Image;
            imgBrush.ImageSource = new BitmapImage(new Uri(ImageUri));
            ellipseWithImageBrush.Fill = imgBrush;
        }

        private async void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    var storagefile = items[0] as StorageFile;
                    var contenttype = storagefile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    string MyPaths = folder.Path + @"\" + storagefile.Name;

                    char[] PathArray = new char[MyPaths.Length + 1];
                    string[] NewPathArray = new string[MyPaths.Length + 3];

                    int i = 0, z = 0;
                    foreach (char a in MyPaths)
                    {
                        PathArray[i] = a;
                        i++;
                    }

                    for (int x = 3; x <= MyPaths.Length - 1; x++)
                    {
                        NewPathArray[z] = PathArray[x].ToString();
                        z++;
                    }

                    string NewPaths = "";
                    for (int j = 0; j <= NewPathArray.Length - 6; j++)
                    {
                        NewPaths += NewPathArray[j];
                    }

                    if (contenttype == "image/png" || contenttype == "image/jpeg")
                    {

                        StorageFile newfile = await storagefile.CopyAsync(folder, storagefile.Name, NameCollisionOption.GenerateUniqueName);
                        ImageBrush imgBrush = new ImageBrush();

                        var ImageUri = @"C:\\\" + NewPaths;
                        imgBrush.ImageSource = new BitmapImage(new Uri(ImageUri));
                        ellipseWithImageBrush.Fill = imgBrush;

                    }
                    AddImage.Text = @"C:\\\" + NewPaths;
                }
       
            }
        }

        private void StackPanel_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "把图片拖拽进本区域修改";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            var upDataAccourt = new UserData()
            {
                Id = updateItem.Id,
                Name = txtAddName.Text,
                Phonenumber = txtAddnum.Text,
                Birthday = txtAddbir.Text,
                City=txtAddcity.Text,
                Email=txtAddmail.Text,
                Image=AddImage.Text
            };
            sqliteoperation.UpadateData(upDataAccourt); //到这里更新就完成了
            accourt.Remove(updateItem);
            accourt.Insert(updateItemIndex, new UserData(updateItem.Id, txtAddName.Text, txtAddnum.Text, txtAddbir.Text, txtAddcity.Text, txtAddmail.Text, AddImage.Text));

            txtAddName.Text = string.Empty;
            txtAddnum.Text = string.Empty;
            txtAddbir.Text = string.Empty;
            txtAddcity.Text = string.Empty;
            txtAddmail.Text = string.Empty;
        }
    }
}
