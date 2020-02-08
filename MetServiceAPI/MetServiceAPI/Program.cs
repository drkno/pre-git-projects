using System;
using MetServiceAPI.MetService.Maps.SataliteImagery;
using MetServiceAPI.MetService.Maps.SurfacePressure;

namespace MetServiceAPI
{
    class Program
    {
        static void Main()
        {
            var satImages = SurfacePressure.GetSurfacePressureImages(SurfacePressureCharts.TasmanSeaCombined);
            for (var index = 0; index < satImages.Length; index++)
            {
                Console.WriteLine(satImages[index].Description);
                satImages[index].GetImage().Save(index + ".jpg");
            }
        }
    }
}
