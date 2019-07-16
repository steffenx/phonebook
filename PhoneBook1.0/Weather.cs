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
    class Weather
    {
        public async static Task<Root> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();     //http协议
            var url = string.Format("http://api.yytianqi.com/observe?city={0},{1}&key=fcpave5onoqhic9k", lat, lon);

            var response = await http.GetAsync(url);   //异步   等待返回的
            var result = await response.Content.ReadAsStringAsync();//将 HTTP 内容序列化到字符串
            var serializer = new DataContractJsonSerializer(typeof(Root));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]
    public class Data
    {
        /// <summary>
        /// CH010100
        /// </summary>
        /// 
        [DataMember]
        public string cityId { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        /// 
        [DataMember]
        public string cityName { get; set; }

        /// <summary>
        /// 雾
        /// </summary>
        /// 
        [DataMember]
        public string tq { get; set; }
        /// <summary>
        /// 18
        /// </summary>
        /// 
        [DataMember]
        public string numtq { get; set; }
        /// <summary>
        /// 17.0
        /// </summary>
        /// 
        [DataMember]
        public string qw { get; set; }
        /// <summary>
        /// Numfl
        /// </summary>
        /// 
        [DataMember]
        public int numfl { get; set; }
        /// <summary>
        /// 3-4级
        /// </summary>
        /// 
        [DataMember]
        public string fl { get; set; }
        /// <summary>
        /// 西风
        /// </summary>
        /// 
        [DataMember]
        public string fx { get; set; }
        /// <summary>
        /// 6
        /// </summary>
        /// 
        [DataMember]
        public string numfx { get; set; }
        /// <summary>
        /// 24.0
        /// </summary>
        /// 
        [DataMember]
        public string sd { get; set; }

        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }
    }
}
