using System.Text;

namespace RabbitMQ.Producer.Helper
{
    public static class StringExtensions{
     public static byte[] GetBytes(this string value){
          return System.Text.Encoding.ASCII.GetBytes(value);
      }

      public static string GetString(this byte[] value){
         return Encoding.UTF8.GetString(value);
      }
   }



}
