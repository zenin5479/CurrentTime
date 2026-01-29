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
         DateTime timenow = DateTime.Now;

         // Конвертация в Unix timestamp
         long timestamp = ToUnixTimestamp(timenow);
         Console.WriteLine("Текущее время: {0}", timenow);
         Console.WriteLine("Unix timestamp: {0}", timestamp);

         Console.WriteLine("Локальное время: {0:yyyy-MM-dd HH:mm:ss.fff}", timenow);
         Console.WriteLine("Unix timestamp: {0}", timestamp);
         Console.WriteLine("Длина: {0} знаков", timestamp.ToString().Length);


         // Способ 2: DateTimeOffset с учетом часового пояса
         DateTimeOffset timeOffset = DateTimeOffset.Now;

         // Конвертация в Unix timestamp
         long timestamp2 = ToUnixTimestamp(timeOffset);

         Console.WriteLine("Текущее время: {0}", timeOffset);
         Console.WriteLine("Unix timestamp: {0}", timestamp2);
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
         Console.WriteLine("Локальное время: {0:yyyy-MM-dd HH:mm:ss.fff}", now);
         Console.WriteLine("Unix timestamp: {0}", timestamp1);
         Console.WriteLine("Длина: {0} знаков", timestamp1.ToString().Length);

         Console.WriteLine("\n=== Способ 2: Ручной расчет ===");
         Console.WriteLine("Локальное время: {0:yyyy-MM-dd HH:mm:ss.fff}", localNow);
         Console.WriteLine("Unix timestamp: {0}", timestamp2);
         Console.WriteLine("Длина: {0} знаков", timestamp2.ToString().Length);

         // Проверка совпадения
         Console.WriteLine("\nРезультаты совпадают: {0}", timestamp1 == timestamp2);

         // Получение времени из timestamp обратно
         DateTimeOffset fromTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestamp1);
         Console.WriteLine("\nВосстановлено из timestamp: {0:yyyy-MM-dd HH:mm:ss.fff}", fromTimestamp);
      }
   }
}