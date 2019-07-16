using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBook_β1._0
{
    class Login
    {
        [PrimaryKey]// 主键。
        [MaxLength(20)]// 对应到数据库 varchar 的大小。
        public string  LoginUser
        {
            get;
            set;
        }

        [MaxLength(20)]// 对应到数据库 varchar 的大小。
        public string Mima
        {
            get;
            set;
        }
    }
}
