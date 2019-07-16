using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhoneBook_β1._0
{
    
    internal class SQLiteOperation
    {
        public string DbPath;

        #region 删除数据
        internal int DeleteData(UserData AccourtUID)
        {
            int result = 0;
            DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Phonebook.db");
            using (var conn = AppDatabase.GetDbConnection())
            {
                if (AccourtUID != null)
                { result = conn.Delete(AccourtUID); }
                else
                    return result;               
            }
            return result;
        }

        #endregion

        #region 修改数据
        internal int UpadateData(UserData updataAccourt)
        {
            int result = 0;
            DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Phonebook.db");
            using (var conn = AppDatabase.GetDbConnection())
            {
                result = conn.Update(updataAccourt);
            }
            return result;
        }

        internal void UpadateData(string deleteSqliteSequence)
        {

            DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Phonebook.db");
        }

        #endregion

        #region 读数据
        internal ObservableCollection<UserData> ReadData(ObservableCollection<UserData> accourt)
        {
            accourt.Clear();
            DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Phonebook.db");
            using (var conn = AppDatabase.GetDbConnection())
            {
                var dbAccourt = conn.Table<UserData>();
                foreach (var item in dbAccourt)
                {
                    accourt.Add(item);
                }
            }
            return accourt;
        }
        #endregion

        #region 查找数据
        internal List<UserData> CheckData(string conditions)
        {
            var temSTR = "%" + conditions + "%";

            using (var conn = AppDatabase.GetDbConnection())
            {
                return conn.Query<UserData>("select * from UserData where Name like ? or Phonenumber like ? or Birthday like ? or City like ? or Email like ?;", temSTR, temSTR, temSTR, temSTR, temSTR);
            }
        }
        #endregion
    }
}
