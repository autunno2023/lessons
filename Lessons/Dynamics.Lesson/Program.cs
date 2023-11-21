using static Dynamics.Lesson.State;

namespace Dynamics.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            State italy = new State();
            RegionReq request = new RegionReq() { Name = "Lombardia" };
            var response = italy.CreateRegion(request);
        }
    }


}
