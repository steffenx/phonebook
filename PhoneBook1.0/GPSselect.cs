using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace PhoneBook_β1._0
{
    class GPSselect
    {
        public async static Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();//等待返回地理位置
            if (accessStatus != GeolocationAccessStatus.Allowed)   //检测地理位置
                throw new Exception(); //抛出异常
            var geolocator = new Geolocator
            { DesiredAccuracyInMeters = 1 };
            var position = await geolocator.GetGeopositionAsync();
            return position;
        }
    }
}
