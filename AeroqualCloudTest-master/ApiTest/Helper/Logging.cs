using System.Linq;

namespace ApiTest.Helper
{
    public class Logging
    {
        public static string CreateLoggingPrefix(char delimiter = ':', params string[] terms)
        {
            return terms.Aggregate((t1, t2) => $"{t1}{delimiter}{t2}");
        }
    }
}