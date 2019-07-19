using System;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ERPNextClient("https://your.erpnext.com", "username", "password");

            var active_username = client.GetActiveUserName();
        }
    }
}
