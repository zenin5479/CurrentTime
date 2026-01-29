using System;
using System.Diagnostics;

namespace CurrentTime
{
   public class TimeUtils
   {
      // Метод 1: Простой Unix timestamp
      public static long GetUnixTimestampMillis()
      {
         return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
      }

      // Метод 2: Локальное время в Unix timestamp
      public static long GetLocalUnixTimestampMillis()
      {
         DateTime localNow = DateTime.Now;
         DateTime localNowtm = DateTime.Now.ToUniversalTime();
         DateTime utcNow = localNow.ToUniversalTime();
         Console.WriteLine(localNow);
         Console.WriteLine(localNowtm);
         Console.WriteLine(utcNow);
         DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         return (long)(localNow - unixEpoch).TotalMilliseconds;
      }

      // Метод 3: Высокая точность с использованием DateTimeOffset
      public static (long timestamp, string readable) GetPreciseLocalTime()
      {
         DateTimeOffset localTime = DateTimeOffset.Now;

         // Unix timestamp
         long timestamp = localTime.ToUnixTimeMilliseconds();

         // Читаемый формат
         string readable = localTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

         return (timestamp, readable);
      }
   }

   // Использование
   class Program
   {
      static void Main()
      {
         // Получение 13-значного Unix timestamp
         long timestamp1 = TimeUtils.GetUnixTimestampMillis();
         Console.WriteLine($"Unix timestamp (UTC): {timestamp1}");

         // Локальное время в timestamp
         long timestamp2 = TimeUtils.GetLocalUnixTimestampMillis();

         Console.WriteLine($"Local time in timestamp: {timestamp2}");

         // Полная информация
         (long timestamp3, string readable) = TimeUtils.GetPreciseLocalTime();
         Console.WriteLine($"Timestamp: {timestamp3}");
         Console.WriteLine($"Readable: {readable}");

         // Проверка, что число действительно 13-значное
         Console.WriteLine($"Is 13-digit: {timestamp3.ToString().Length == 13}");
      }
   }
}