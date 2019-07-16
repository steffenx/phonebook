using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_β1._0
{

    #region 和风天气
    ///<summary></summary>
    ///基础数据类
    ///</summary>
    [DataContract]
    public class Basic
    {
        /// <summary>
        /// CN101010100
        /// </summary>
        /// 
        [DataMember]
        public string cid { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        /// 
        [DataMember]
        public string location { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        /// 
        [DataMember]
        public string parent_city { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        /// 
        [DataMember]
        public string admin_area { get; set; }
        ///// <summary>
        ///// 39.90498734
        ///// </summary>
        ///// 
        //[DataMember]
        //public string lat { get; set; }
        ///// <summary>
        ///// 116.40528870
        ///// </summary>
        ///// 
        //[DataMember]
        //public string lon { get; set; }
        /// <summary>
        /// +8.0
        /// </summary>
        /// 
        [DataMember]
        public string tz { get; set; }
    }

    ///<summary></summary>
    ///API更新时间类
    ///</summary>
    [DataContract]
    public class Update
    {

    }

    ///<summary></summary>
    ///逐小时预报类
    ///</summary>
    [DataContract]
    public class Now
    {
        /// <summary>
        /// 0
        /// </summary>
        /// 
        [DataMember]
        public string cloud { get; set; }
        /// <summary>
        /// 100
        /// </summary>
        /// 
        [DataMember]
        public string cond_code { get; set; }
        /// <summary>
        /// 晴
        /// </summary>
        /// 
        [DataMember]
        public string cond_txt { get; set; }
        /// <summary>
        /// 9
        /// </summary>
        /// 
        [DataMember]
        public string fl { get; set; }
        /// <summary>
        /// 32
        /// </summary>
        /// 
        [DataMember]
        public string hum { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        /// 
        [DataMember]
        public string pcpn { get; set; }
        /// <summary>
        /// 1015
        /// </summary>
        /// 
        [DataMember]
        public string pres { get; set; }
        /// <summary>
        /// 9
        /// </summary>
        /// 
        [DataMember]
        public string tmp { get; set; }
        /// <summary>
        /// 8
        /// </summary>
        /// 
        [DataMember]
        public string vis { get; set; }
        /// <summary>
        /// 197
        /// </summary>
        /// 
        [DataMember]
        public string wind_deg { get; set; }
        /// <summary>
        /// 西南风
        /// </summary>
        /// 
        [DataMember]
        public string wind_dir { get; set; }
        /// <summary>
        /// 微风
        /// </summary>
        /// 
        [DataMember]
        public string wind_sc { get; set; }
        /// <summary>
        /// 10
        /// </summary>
        /// 
        [DataMember]
        public string wind_spd { get; set; }
    }

    ///<summary></summary>
    ///3-15天气类
    ///</summary>
    [DataContract]
    public class Daily_forecast
    {
        /// <summary>
        /// 2017-11-09
        /// </summary>
        /// 
        [DataMember]
        public string date { get; set; }
        /// <summary>
        /// 103
        /// </summary>
        /// 
        [DataMember]
        public string cond_code_d { get; set; }
        /// <summary>
        /// 104
        /// </summary>
        /// 
        [DataMember]
        public string cond_code_n { get; set; }
        /// <summary>
        /// 晴间多云
        /// </summary>
        /// 
        [DataMember]
        public string cond_txt_d { get; set; }
        /// <summary>
        /// 阴
        /// </summary>
        /// 
        [DataMember]
        public string cond_txt_n { get; set; }
        /// <summary>
        /// 39
        /// </summary>
        /// 
        [DataMember]
        public string hum { get; set; }
        /// <summary>
        /// 22:06
        /// </summary>
        /// 
        [DataMember]
        public string mr { get; set; }
        /// <summary>
        /// 11:53
        /// </summary>
        /// 
        [DataMember]
        public string ms { get; set; }
        /// <summary>
        /// 0.0
        /// </summary>
        /// 
        [DataMember]
        public string pcpn { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        /// 
        [DataMember]
        public string pop { get; set; }
        /// <summary>
        /// 1019
        /// </summary>
        /// 
        [DataMember]
        public string pres { get; set; }
        /// <summary>
        /// 06:52
        /// </summary>
        /// 
        [DataMember]
        public string sr { get; set; }
        /// <summary>
        /// 17:05
        /// </summary>
        /// 
        [DataMember]
        public string ss { get; set; }
        /// <summary>
        /// 13
        /// </summary>
        /// 
        [DataMember]
        public string tmp_max { get; set; }
        /// <summary>
        /// 5
        /// </summary>
        /// 
        [DataMember]
        public string tmp_min { get; set; }
        /// <summary>
        /// 2
        /// </summary>
        /// 
        [DataMember]
        public string uv_index { get; set; }
        /// <summary>
        /// 16
        /// </summary>
        /// 
        [DataMember]
        public string vis { get; set; }
        /// <summary>
        /// 西北风
        /// </summary>
        /// 
        [DataMember]
        public string wind_dir { get; set; }
        /// <summary>
        /// 微风
        /// </summary>
        /// 
        [DataMember]
        public string wind_sc { get; set; }
        /// <summary>
        /// 6
        /// </summary>
        /// 
        [DataMember]
        public string wind_spd { get; set; }
    }

    ///<summary></summary>
    ///生活指数类
    ///</summary>
    [DataContract]
    public class Lifestyle
    {
        /// <summary>
        /// 较舒适
        /// </summary>
        /// 
        [DataMember]
        public string brf { get; set; }
        /// <summary>
        /// 白天虽然天气晴好，但早晚会感觉偏凉，午后舒适、宜人。
        /// </summary>
        /// 
        [DataMember]
        public string txt { get; set; }
        /// <summary>
        /// comf
        /// </summary>
        /// 
        [DataMember]
        public string type { get; set; }
    }

    ///<summary></summary>
    ///基础数据调用类
    ///</summary>
    [DataContract]
    public class HeWeather6
    {
        /// <summary>
        /// Basic
        /// </summary>
        /// 
        [DataMember]
        public Basic basic { get; set; }
        /// <summary>
        /// Update
        /// </summary>
        /// 
        [DataMember]
        public Update update { get; set; }
        /// <summary>
        /// ok
        /// </summary>
        /// 
        [DataMember]
        public string status { get; set; }
        /// <summary>
        /// Now
        /// </summary>
        /// 
        [DataMember]
        public Now now { get; set; }
        /// <summary>
        /// Daily_forecast
        /// </summary>
        /// 
        [DataMember]
        public List<Daily_forecast> daily_forecast { get; set; }
        /// <summary>
        /// Lifestyle
        /// </summary>
        /// 
        [DataMember]
        public List<Lifestyle> lifestyle { get; set; }
    }


    #endregion

    [DataContract]
    public class Root
    {
        #region 归属地
        /// <summary>
        /// 220871
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 1772651
        /// </summary>
        /// 
        [DataMember]
        public string prefix { get; set; }
        /// <summary>
        /// 四川
        /// </summary>
        /// 
        [DataMember]
        public string province { get; set; }
        /// <summary>
        /// 德阳
        /// </summary>
        /// 
        [DataMember]
        public string city { get; set; }
        /// <summary>
        /// 中国电信
        /// </summary>
        /// 
        [DataMember]
        public string @operator { get; set; }
        /// <summary>
        /// 0838
        /// </summary>
        /// 
        [DataMember]
        public string areaCode { get; set; }
        /// <summary>
        /// 618000
        /// </summary>
        /// 
        [DataMember]
        public string zip { get; set; }
        /// <summary>
        /// Ret
        /// </summary>
        /// 
        [DataMember]
        public int ret { get; set; }
        /// <summary>
        /// 17726517495
        /// </summary>
        /// 
        [DataMember]
        public string searchStr { get; set; }
        /// <summary>
        /// 223.86.26.10
        /// </summary>
        /// 
        [DataMember]
        public string ip { get; set; }
        #endregion

        #region 丫丫天气
        /// <summary>
        /// Code
        /// </summary>
        /// 
        [DataMember]
        public int code { get; set; }
        /// <summary>
        /// Sucess
        /// </summary>
        /// 
        [DataMember]
        public string msg { get; set; }
        /// <summary>
        /// Counts
        /// </summary>
        /// 
        [DataMember]
        public int counts { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        /// 
        [DataMember]
        public Data data { get; set; }
        #endregion

        #region 和风天气
        /// <summary>
        /// HeWeather6
        /// </summary>
        /// 
        [DataMember]
        public List<HeWeather6> HeWeather6 { get; set; }
        #endregion
    }
}
