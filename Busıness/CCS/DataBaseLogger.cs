using System;

namespace Busıness.CCS
{
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("veritabanına loglandı");
        }
    }
}
