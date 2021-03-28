using SQLite;
namespace Vacation_App_3.Features
{
    public class TODODataFormat
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Notes { get; set; }
      
    }
}
