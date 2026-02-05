using System;

namespace CurrentTime
{
   public class Program
   {
      public static void Main()
      {
         //CaseOne();
         //Console.WriteLine();
         CaseTwo();
         //Console.WriteLine();
         //CaseThree();
         //Console.WriteLine();
         //CaseFour();

         Console.ReadKey();
      }

      public static void CaseOne()
      {
         Console.WriteLine("Определение точного времени UTC в миллисекундах (13-значное число)");

         // 1. Получение Timestamp
         Console.WriteLine("========================================================");
         Console.WriteLine("Получение Timestamp через DateTimeOffset (рекомендуется)");
         DateTimeOffset dateTimeOne = DateTimeOffset.UtcNow;
         long timestampOne = dateTimeOne.ToUnixTimeMilliseconds();
         Console.WriteLine("Текущее UTC время: {0}", dateTimeOne);
         Console.WriteLine("Текущее UTC время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeOne);
         Console.WriteLine("Timestamp: {0}", timestampOne);

         Console.WriteLine("===========================================================================");
         Console.WriteLine("Получение Timestamp через DateTimeOffset и TimeSpan с учетом часового пояса");
         DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpanTwo = dateTimeOffset.UtcDateTime - unixStart.UtcDateTime;
         long timestampThree = (long)(timeSpanTwo.TotalMilliseconds);
         Console.WriteLine("Текущее UTC время: {0}", dateTimeOffset);
         Console.WriteLine("Текущее UTC время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeOffset);
         Console.WriteLine("Timestamp: {0}", timestampThree);

         Console.WriteLine("=============================================");
         Console.WriteLine("Получение Timestamp через DateTime и TimeSpan");
         DateTime dateTimeNow = DateTime.UtcNow;
         DateTime unixStartOne = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan timeSpanOne = dateTimeNow.ToUniversalTime() - unixStartOne;
         long timeStampTwo = (long)(timeSpanOne.TotalMilliseconds);
         Console.WriteLine("Текущее UTC время: {0}", dateTimeNow);
         Console.WriteLine("Текущее UTC время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeNow);
         Console.WriteLine("Timestamp: {0}", timeStampTwo);

         // 2. Конвертация Timestamp в DateTime
         Console.WriteLine("========================================================");
         Console.WriteLine("Конвертация из Timestamp в DateTime через DateTimeOffset");
         DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestampOne).UtcDateTime;
         Console.WriteLine("Текущее UTC время: {0}", dateTime);
         Console.WriteLine("Текущее UTC время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTime);

         Console.WriteLine("===================================");
         Console.WriteLine("Конвертация из Timestamp в DateTime");
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         DateTime addMilliseconds = epoch.AddMilliseconds(timestampOne);
         Console.WriteLine("Текущее UTC время: {0}", addMilliseconds);
         Console.WriteLine("Текущее UTC время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", addMilliseconds);
      }

      public static void CaseTwo()
      {
         Console.WriteLine("Определение точного локального времени в миллисекундах (13-значное число)");
         Console.WriteLine("=============================================");
         Console.WriteLine("Получение Timestamp через DateTime и TimeSpan");
         DateTime dateTimeNow = DateTime.Now;
         DateTime unixStartOne = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
         TimeSpan timeSpanOne = dateTimeNow.ToUniversalTime() - unixStartOne;
         long timeStampOne = (long)(timeSpanOne.TotalMilliseconds);
         Console.WriteLine("Текущее локальное время: {0}", dateTimeNow);
         Console.WriteLine("Текущее локальное время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeNow);
         Console.WriteLine("Timestamp: {0}", timeStampOne);

         Console.WriteLine("===========================================================================");
         Console.WriteLine("Получение Timestamp через DateTimeOffset и TimeSpan с учетом часового пояса");
         DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpanTwo = dateTimeOffset.UtcDateTime - unixStart.UtcDateTime;
         long timestampTwo = (long)(timeSpanTwo.TotalMilliseconds);
         Console.WriteLine("Текущее локальное время: {0}", dateTimeOffset);
         Console.WriteLine("Текущее локальное время в милисекундах: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeOffset);
         Console.WriteLine("Timestamp: {0}", timestampTwo);

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

         // 1. Базовый метод
         // Создаем начальную дату Unix эпохи
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         // Конвертируем timestamp в локальное время
         Console.WriteLine("========================================================");
         Console.WriteLine("Конвертация из Timestamp в DateTime через DateTimeOffset");
         DateTime localTime = epoch.AddMilliseconds(timeStampOne).ToLocalTime();
         Console.WriteLine("Базовое преобразование: {0}", localTime);
         Console.WriteLine("Базовое преобразование с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", localTime);

         // 2. С учетом часового пояса
         // Свойство TimeZoneInfo.Id - "Russian Standard Time"
         DateTime utcDateTime = epoch.AddMilliseconds(timestampTwo);

         // Получаем нужный часовой пояс
         TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

         // Конвертируем в локальное время
         Console.WriteLine("===================================");
         Console.WriteLine("Конвертация из Timestamp в DateTime");
         DateTime localZone = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
         Console.WriteLine("С учетом часового пояса: {0}", localZone);
         Console.WriteLine("С учетом часового пояса с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", localZone);

         Console.WriteLine("========================================================");
         Console.WriteLine("Конвертация из Timestamp в DateTime через DateTimeOffset");



         // Получение времени из timestamp обратно
         DateTimeOffset fromTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampoffset);
         Console.WriteLine("Восстановлено из timestamp: {0:dd.MM.yyyy HH:mm:ss.fff}", fromTimestamp);
      }

      public static void CaseThree()
      {
         Console.WriteLine("Определение точного времени UTC в миллисекундах (13-значное число)");
         // Способ 1
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 1. DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         long timestampone = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampone);

         // Способ 2
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 2. Ручной расчет через Ticks");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTimeOffset datetimeoffset = DateTimeOffset.UtcNow;
         long timestamptwo = (datetimeoffset.Ticks - DateTimeOffset.UnixEpoch.Ticks) / TimeSpan.TicksPerMillisecond;
         Console.WriteLine("Unix timestamp (ms): {0}", timestamptwo);

         // Способ 3
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 3. new DateTimeOffset().ToUnixTimeMilliseconds()");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTimeOffset specificdate = DateTimeOffset.UtcNow;
         long timestampthree = new DateTimeOffset(specificdate.UtcDateTime).ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampthree);

         // Способ 4
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 4. DateTime.UtcNow и вычитание эпохи");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         DateTime thistime = DateTime.UtcNow;
         TimeSpan span = thistime - epoch;
         long timestampfour = (long)span.TotalMilliseconds;
         Console.WriteLine("Unix timestamp (ms): {0}", timestampfour);

         // Способ 5
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 5. DateTimeOffset с явным преобразованием");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTimeOffset rightnow = DateTimeOffset.UtcNow;
         long timestampfive = rightnow.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampfive);

         // Проверка эквивалентности
         Console.WriteLine("========================================================");
         Console.WriteLine("Проверка эквивалентности:");
         Console.WriteLine("Способ 1 == Способ 2: {0}", timestampone == timestamptwo);
         Console.WriteLine("Способ 2 == Способ 3: {0}", timestamptwo == timestampthree);
         Console.WriteLine("Способ 3 == Способ 4: {0}", timestampthree == timestampfour);
         Console.WriteLine("Способ 4 == Способ 5: {0}", timestampfour == timestampfive);

         // Конвертация обратно для проверки
         Console.WriteLine("========================================================");
         Console.WriteLine("Конвертация обратно в DateTime:");
         DateTimeOffset datefromtimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampone);
         Console.WriteLine("Из timestamp: {0:yyyy-MM-dd HH:mm:ss.fff}", datefromtimestamp);
      }
   }
}