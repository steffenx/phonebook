using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PhoneBook_β1._0
{
    public class ListviewSelect
    {
        //public static List<UserData> Getuser()
        //{
        //    using (var conn = AppDatabase.GetDbConnection())
        //    {
        //        var users = new List<UserData>();
        //        StringBuilder msg = new StringBuilder();
        //        var dbPerson = conn.Table<UserData>();
        //        msg.AppendLine($"数据库中总共 {dbPerson.Count()} 个 Person 对象。");

        //        foreach (var person in dbPerson)
        //        {
        //            return users;
        //            msg.AppendLine($"Id：{person.Id}；Name：{person.Name}；Phonenumber：{person.Phonenumber}；Sex：{person.Sex}；City：{person.City}；Email：{person.Email}");
        //        }

        //    } 
        //}

        public string Userid { get; set; }
        public string Bir { get; set; }
        public string Phonenumber { get; set; }
        public string Coveimage { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
    }

    public class Usermanager
    {
        public static List<ListviewSelect> Getuser()
        {
            var users = new List<ListviewSelect>();
            using (var conn = AppDatabase.GetDbConnection())
            {
                StringBuilder msg = new StringBuilder();
                var dbPerson = conn.Table<UserData>();
                //msg.AppendLine($"数据库中总共 {dbPerson.Count()} 个 userdata对象。");
                foreach (var userdata in dbPerson)
                {
                     users.Add(new ListviewSelect { Userid = userdata.Name, Bir = userdata.Birthday, Phonenumber = userdata.Phonenumber, Coveimage =  userdata.Image, City = userdata.City, Mail = userdata.Email });
                }               
            }          
            return users;
        }
    }
}
