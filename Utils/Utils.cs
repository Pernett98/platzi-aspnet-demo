using System;
namespace PlatziMVC.Utils
{
    public class Utils
    {
        
        public static string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }

    }
}