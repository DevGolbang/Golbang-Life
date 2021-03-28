using System;
using System.IO;
using SQLite;
namespace Vacation_App_3.Features
{
    class Consts
    {
        public const string OpenWeatherAPIEndpoint = "http://apis.data.go.kr/1360000/VilageFcstInfoService/getVilageFcst?serviceKey={0}&pageNo=1&numOfRows=10&dataType=JSON&base_date={1}&base_time=0500&nx=90&ny=90";
        public const string OpenWeatherAPIKey = "8PFZxVIuEGqCfz%2FcldVYoJES4QUTImrloZmugVKp6fe7dCB5pyCB3YLKr0FMp5LxhU%2FIw4GxLHQ%2BY7GV2185Vg%3D%3D";
        public const string DBFileName = "AppSQLite.db3";
        public const SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        
        public static string DBPath
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(path, DBFileName);
            }
        }
        public static string YearAndDate
        {
            get
            {
                DateTime _now = DateTime.Now;
                return _now.Year + Consts.SetString(_now.Month) + Consts.SetString(_now.Day);
                //string.Format(OpenWeatherAPIEndpoint, OpenWeatherAPIKey, YearAndDate);
            }
        }
        public static string SetString(int target)
        {
            if (target < 10)
            {

                return "0" + target.ToString();
            }
            else
            {
                return target.ToString();
            }

        }
    }
}
