using System.Configuration;

namespace DataAccessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccessContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DataAccessContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
