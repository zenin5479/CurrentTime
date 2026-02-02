using System;

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
         Console.WriteLine();
         CaseFour();

         Console.ReadKey();
      }

      public static void CaseOne()
      {
         Console.WriteLine("=== DateTime, DateTimeOffset ===");
         // 1. Получение текущего Timestamp
         long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         Console.WriteLine("=== Получение текущего Timestamp через DateTimeOffset ===");
         Console.WriteLine("Timestamp: {0}", timestamp);

         // 2. Конвертация Timestamp в DateTime
         Console.WriteLine("=== Конвертация Timestamp в DateTime ===");
         Console.WriteLine("=== Способ 1: DateTime ===");
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         DateTime addMilliseconds = epoch.AddMilliseconds(timestamp);
         Console.WriteLine("Конвертация из Timestamp в DateTime: {0}", addMilliseconds);
         Console.WriteLine("Конвертация из Timestamp в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", addMilliseconds);

         Console.WriteLine("=== Способ 2: DateTimeOffset ===");
         DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
         Console.WriteLine("Конвертация из Timestamp в DateTime: {0}", dateTime);
         Console.WriteLine("Конвертация из Timestamp в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTime);
      }

      private static void CaseFour()
      {
         // Пример Unix timestamp (13-значное число)
         long timestamp = 1769934086938;

         // 1. Базовый метод
         // Создаем начальную дату Unix эпохи
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         // Конвертируем timestamp в локальное время
         DateTime localTime = epoch.AddMilliseconds(timestamp).ToLocalTime();
         Console.WriteLine("Базовое преобразование: {0}", localTime);
         Console.WriteLine("Базовое преобразование с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", localTime);

         // 2. С учетом часового пояса
         // Свойство TimeZoneInfo.Id - "Russian Standard Time"
         DateTime utcDateTime = epoch.AddMilliseconds(timestamp);

         // Получаем нужный часовой пояс
         TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

         // Конвертируем в локальное время
         DateTime localZone = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
         Console.WriteLine("С учетом часового пояса: {0}", localZone);
         Console.WriteLine("С учетом часового пояса с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", localZone);
      }

      private static void CaseTwo()
      {
         Console.WriteLine("=== DateTime, DateTimeOffset и TimeSpan ===");
         Console.WriteLine("=== Получение текущего Timestamp через DateTime и TimeSpan ===");
         DateTime dateTimeNow = DateTime.Now;
         DateTime unixStartOne = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan timeSpanOne = dateTimeNow.ToUniversalTime() - unixStartOne;
         long timeStampOne = (long)(timeSpanOne.TotalMilliseconds);
         Console.WriteLine("Текущее время в DateTime: {0}", dateTimeNow);
         Console.WriteLine("Текущее время в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeNow);
         Console.WriteLine("Timestamp: {0}", timeStampOne);

         Console.WriteLine("=== Получение текущего Timestamp через DateTimeOffset и TimeSpan с учетом часового пояса ===");
         DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpanTwo = dateTimeOffset.UtcDateTime - unixStart.UtcDateTime;
         long timestampTwo = (long)(timeSpanTwo.TotalMilliseconds);
         Console.WriteLine("Текущее время в DateTime: {0}", dateTimeOffset);
         Console.WriteLine("Текущее время в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeOffset);
         Console.WriteLine("Timestamp: {0}", timestampTwo);
      }

      private static void CaseThree()
      {
         Console.WriteLine("Определение точного локального времени в миллисекундах");
         // Способ 1: DateTimeOffset (рекомендуется)
         DateTimeOffset datenow = DateTimeOffset.Now;
         long timestampoffset = datenow.ToUnixTimeMilliseconds();
         Console.WriteLine("=== Способ 1: DateTimeOffset ===");
         Console.WriteLine("Локальное время: {0:dd.MM.yyyy HH:mm:ss.fff}", datenow);
         Console.WriteLine("Unix timestamp: {0}", timestampoffset);

         // Способ 2: Ручной расчет
         DateTime datelocalnow = DateTime.Now;
         DateTime universalnow = datelocalnow.ToUniversalTime();
         DateTime unixepoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         long timestampepoch = (long)(universalnow - unixepoch).TotalMilliseconds;
         Console.WriteLine("=== Способ 2: Ручной расчет ===");
         Console.WriteLine("Локальное время: {0:dd.MM.yyyy HH:mm:ss.fff}", datelocalnow);
         Console.WriteLine("Unix timestamp: {0}", timestampepoch);

         // Проверка совпадения
         Console.WriteLine("Результаты совпадают: {0}", timestampoffset == timestampepoch);

         // Получение времени из timestamp обратно
         DateTimeOffset fromTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampoffset);
         Console.WriteLine("Восстановлено из timestamp: {0:dd.MM.yyyy HH:mm:ss.fff}", fromTimestamp);
      }
   }
}