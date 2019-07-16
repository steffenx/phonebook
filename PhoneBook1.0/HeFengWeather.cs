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
    class HeFengWeather
    {
        public async static Task<Root> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();     //http协议
            var url = string.Format("https://free-api.heweather.com/s6/weather?location={0},{1}&key=df6a71af9eb34a95b2fa5d1660b9c818", lat, lon);

            var response = await http.GetAsync(url);   //异步   等待返回的
            var result = await response.Content.ReadAsStringAsync();//将 HTTP 内容序列化到字符串
            var serializer = new DataContractJsonSerializer(typeof(Root));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);
            return data;
        }

        public async static Task<Root> GetWeathercity(string num)
        {
            var http = new HttpClient();     //http协议
            var url = string.Format("https://free-api.heweather.com/s6/weather?location={0}&key=df6a71af9eb34a95b2fa5d1660b9c818", num);

            var response = await http.GetAsync(url);   //异步   等待返回的
            var result = await response.Content.ReadAsStringAsync();//将 HTTP 内容序列化到字符串
            var serializer = new DataContractJsonSerializer(typeof(Root));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);
            return data;
        }
    }
}
