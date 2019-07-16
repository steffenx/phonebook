using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_β1._0
{
    class GetCitynum
    {
        public async static Task<Root> GetOperator(string num)
        {
            var http = new HttpClient();     //http协议
            var url = string.Format("https://www.iteblog.com/api/mobile.php?mobile={0}", num);
            var response = await http.GetAsync(url);   //异步   等待返回的
            var result = await response.Content.ReadAsStringAsync();//将 HTTP 内容序列化到字符串
            var serializer = new DataContractJsonSerializer(typeof(Root));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);
            return data;
        }
    }

   


}
