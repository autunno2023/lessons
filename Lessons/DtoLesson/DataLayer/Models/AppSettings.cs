namespace DataLayer.Models
{
    interface IAppSettings
    {

    }
    public class AppSettings : IAppSettings
    {
        public DataLayerSettings dataLayerSettings { get; set; }
        public class DataLayerSettings
        {
            public string DefaultConnection { get; set; }

        }

    }


}
