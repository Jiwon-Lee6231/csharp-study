using System;
using System.Threading.Tasks;

namespace Csharp6
{
    class Program
    {

        static Task Test()
        {
            Console.WriteLine("Start Test");
            Task t = Task.Delay(3000);
            return t;
        }

        static async Task<int> TestAsync()
        {
            Console.WriteLine("Start TestAsync");
            // Task t = Task.Delay(3000);  // 복잡한 작업 (ex. DB, File)
            // await t;

            await Task.Delay(3000);
            Console.WriteLine("End TestAsync");
            return 1;
        }

        static async Task Main(string[] args)
        {
            // Task t = Test();
            // t.Wait();
            Task<int> t = TestAsync();
            int ret = await t;
            
            Console.WriteLine("while start");
            Console.WriteLine(ret);

            while (true)
            {

            }
        }
    }
}
