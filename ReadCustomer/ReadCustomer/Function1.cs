using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ReadCustomer
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("customercreated", "CustomerReadService", AccessRights.Manage, Connection = "sbcon")]string mySbMsg, TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            Users user = JsonConvert.DeserializeObject<Users>(mySbMsg);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=tcp:devcustomerserver01.database.windows.net,1433;Initial Catalog=devcustomerserver;Persist Security Info=False;User ID=rahul;Password=Password@123;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into users values ("+user.CustomerId + ",'"+user.Firstname+ "','"+user.Lastname+"',0,'"+user.City+"',10)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;

            int results = cmd.ExecuteNonQuery();
        }
    }
    public  class Users
    {
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
    }
}
