using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
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
    public sealed partial class AddFace : Page
    {
        public AddFace()
        {
            this.InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtAddName.Text;
            string number = txtAddnum.Text;
            string bir = txtAddbir.Text;
            string mail = txtAddmail.Text;
            string city = txtAddcity.Text;
            string image = AddImage.Text;
            if (image != "")
            {
                using (var conn = AppDatabase.GetDbConnection())
                {
                    // 需要添加的 Person 对象。
                    var adduserdata = new UserData() { Name = name, Phonenumber = number, Birthday = bir, City = city, Email = mail, Image = image };

                    // 受影响行数。
                    var count = conn.Insert(adduserdata);
                    string msg = $"新增的 Person 对象的 Id 为 {adduserdata.Id}，Name 为 {adduserdata.Name},Phonenumber为 {adduserdata.Phonenumber},Birthday为 {adduserdata.Birthday},City为 {adduserdata.City},Email为 {adduserdata.Email}";
                    await new MessageDialog(msg).ShowAsync();
                }
            }
            if(image=="")
            {
                using (var conn = AppDatabase.GetDbConnection())
                {
                    // 需要添加的 Person 对象。
                    var adduserdata = new UserData() { Name = name, Phonenumber = number, Birthday = bir, City = city, Email = mail, Image = @"C:\\\"+image };

                    // 受影响行数。
                    var count = conn.Insert(adduserdata);
                    string msg = $"新增的 Person 对象的 Id 为 {adduserdata.Id}，Name 为 {adduserdata.Name},Phonenumber为 {adduserdata.Phonenumber},Brithday为 {adduserdata.Birthday},City为 {adduserdata.City},Email为 {adduserdata.Email}";
                    await new MessageDialog(msg).ShowAsync();
                }
            }
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
            e.DragUIOverride.Caption = "把图片拖拽进本区域添加";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }
    }
}
