using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_β1._0
{

    public class UserData
    {

        public UserData() { }
        public UserData(int ID, string name, string phonenumber, string bir, string city, string email, string image)
        {
            this.Id = ID;
            this.Name = name;
            this.Phonenumber = phonenumber;
            this.Birthday = bir;
            this.City = city;
            this.Email = email;
            this.Image = image;
        }

        [PrimaryKey]// 主键。
        [AutoIncrement]// 自动增长。
        public int Id
        {
            get;
            set;
        }

        [MaxLength(6)]// 对应到数据库 varchar 的大小。
        public string Name
        {
            get;
            set;
        }

        [MaxLength(11)]// 对应到数据库 varchar 的大小。
        public string Phonenumber
        {
            get;
            set;
        }

        [MaxLength(10)]// 对应到数据库 varchar 的大小。
        public string Birthday
        {
            get;
            set;
        }

        [MaxLength(10)]// 对应到数据库 varchar 的大小。
        public string City
        {
            get;
            set;
        }

        [MaxLength(20)]// 对应到数据库 varchar 的大小。
        public string Email
        {
            get;
            set;
        }

        [MaxLength(20)]// 对应到数据库 varchar 的大小。
        public string Image
        {
            get;
            set;
        }
    }
}
