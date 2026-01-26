using System;

namespace CurrentTime
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Определение точного времени в миллисекундах (13-значное число)");
         CaseOne();
         Console.WriteLine();
         CaseTwo();
         Console.WriteLine();

         Console.ReadKey();
      }

      // Точное время в Unix‑timestamp в миллисекундах (13‑значное число)
      static void CaseOne()
      {
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

         // Способ 4.
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 4. DateTime.UtcNow и вычитание эпохи");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         DateTime thistime = DateTime.UtcNow;
         TimeSpan span = thistime - epoch;
         long timestampfour = (long)span.TotalMilliseconds;
         Console.WriteLine("Unix timestamp (ms): {0}", timestampfour);

         // Способ 5.
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 5. Через DateTimeOffset с явным преобразованием");
         Console.WriteLine("Текущее UTC время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         DateTimeOffset rightnow = DateTimeOffset.UtcNow;
         long timestampfive = rightnow.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampfive);

         // Проверка эквивалентности
         Console.WriteLine("Проверка эквивалентности:");
         Console.WriteLine("Способ 1 == Способ 2: {0}", timestampone == timestamptwo);
         Console.WriteLine("Способ 2 == Способ 3: {0}", timestamptwo == timestampthree);
         Console.WriteLine("Способ 3 == Способ 4: {0}", timestampthree == timestampfour);
         Console.WriteLine("Способ 4 == Способ 5: {0}", timestampfour == timestampfive);

         // Конвертация обратно для проверки
         Console.WriteLine("\nКонвертация обратно в DateTime:");
         DateTimeOffset datefromtimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampone);
         Console.WriteLine("Из timestamp: {0:yyyy-MM-dd HH:mm:ss.fff}", datefromtimestamp);
      }

      // Точное время в Unix‑timestamp в миллисекундах (13‑значное число)
      static void CaseTwo()
      {
         Console.WriteLine("Точное время в Unix timestamp в миллисекундах (13-значное число)");

         // 1. Через DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
         Console.WriteLine("1. Через DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()");
         long timestampoffset = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampoffset);

         // 2. Через DateTime.UtcNow и вычитание эпохи
         Console.WriteLine("2. Через DateTime.UtcNow и вычитание эпохи");
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         DateTime thistime = DateTime.UtcNow;
         TimeSpan span = thistime - epoch;
         long timestamputcnow = (long)span.TotalMilliseconds;
         Console.WriteLine("Unix timestamp (ms): {0}", timestamputcnow);

         // 3. Через DateTimeOffset с явным преобразованием
         Console.WriteLine("3. Через DateTimeOffset с явным преобразованием");
         DateTimeOffset rightnow = DateTimeOffset.UtcNow;
         long timestampoffsetconvert = rightnow.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampoffsetconvert);
      }
   }
}