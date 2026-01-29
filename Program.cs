using System;
using System.Diagnostics;

namespace CurrentTime
{
   public class Program
   {
      public static void Main()
      {
         CaseOne();
         Console.WriteLine();
         CaseTwo();
         Console.WriteLine();
         CaseThree();

         Console.ReadKey();
      }

      private static void CaseOne()
      {
         // Способ 1: DateTime с миллисекундами
         DateTime currentTime = DateTime.Now;

         // Конвертация в Unix timestamp
         long timestamp = ToUnixTimestamp(currentTime);

         Console.WriteLine($"Текущее время: {currentTime}");
         Console.WriteLine($"Unix timestamp: {timestamp}");

         // Способ 2: DateTimeOffset с учетом часового пояса
         DateTimeOffset nowOffset = DateTimeOffset.Now;

         // Получение текущего времени
         DateTimeOffset current = DateTimeOffset.Now;

         // Конвертация в Unix timestamp
         long timestamp2 = ToUnixTimestamp(current);

         Console.WriteLine($"Текущее время: {current}");
         Console.WriteLine($"Unix timestamp: {timestamp2}");
      }

      // Базовый способ конвертации
      public static long ToUnixTimestamp(DateTime date)
      {
         DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan timeSpan = date.ToUniversalTime() - unixStart;
         return (long)(timeSpan.TotalMilliseconds);
      }

      // Использование DateTimeOffset
      public static long ToUnixTimestamp(DateTimeOffset date)
      {
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpan = date.UtcDateTime - unixStart.UtcDateTime;
         return (long)(timeSpan.TotalMilliseconds);
      }

      private static void CaseTwo()
      {

      }

      private static void CaseThree()
      {
         // Способ 1: DateTimeOffset (рекомендуется)
         DateTimeOffset now = DateTimeOffset.Now;
         long timestamp1 = now.ToUnixTimeMilliseconds();

         // Способ 2: Ручной расчет
         DateTime localNow = DateTime.Now;
         DateTime utcNow = localNow.ToUniversalTime();
         DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         long timestamp2 = (long)(utcNow - unixEpoch).TotalMilliseconds;

         Console.WriteLine("=== Способ 1: DateTimeOffset ===");
         Console.WriteLine($"Локальное время: {now:yyyy-MM-dd HH:mm:ss.fff}");
         Console.WriteLine($"Unix timestamp: {timestamp1}");
         Console.WriteLine($"Длина: {timestamp1.ToString().Length} знаков");

         Console.WriteLine("\n=== Способ 2: Ручной расчет ===");
         Console.WriteLine($"Локальное время: {localNow:yyyy-MM-dd HH:mm:ss.fff}");
         Console.WriteLine($"Unix timestamp: {timestamp2}");
         Console.WriteLine($"Длина: {timestamp2.ToString().Length} знаков");

         // Проверка совпадения
         Console.WriteLine($"\nРезультаты совпадают: {timestamp1 == timestamp2}");

         // Получение времени из timestamp обратно
         DateTimeOffset fromTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestamp1);
         Console.WriteLine($"\nВосстановлено из timestamp: {fromTimestamp:yyyy-MM-dd HH:mm:ss.fff}");
      }
   }
}