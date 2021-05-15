using MESConsoleClient.MESServiceReference;
using MESModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MESServiceClient client = new MESServiceClient("BasicHttpBinding_IMESService");
            Console.WriteLine(client.GetData(7));
            //var departments = client.GetDepartments();
            /*foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
            }*/
            //Console.WriteLine(client.InitDb());
            client.Close();
            Console.ReadKey();
        }
    }
}
