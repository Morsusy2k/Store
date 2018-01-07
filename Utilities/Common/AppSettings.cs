using System.Configuration;

namespace Store.Utilities.Common
{
    public static class AppSettings
    {
        //public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DBStoreConnection"].ConnectionString;
        public static readonly string ConnectionString = "Data Source=DESKTOP-UM5IM2P;Initial Catalog=DBStore;Integrated Security=True";
    }
}
