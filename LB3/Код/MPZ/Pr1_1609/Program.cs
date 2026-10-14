using System.Security.Claims;
using System.Threading.Channels;

namespace Pr1_1609
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB();
            
            DepartmentServyses departmentServyses = new DepartmentServyses(db);

           departmentServyses.GetAllInformationAboutStudients();

           
        }
    }
}
