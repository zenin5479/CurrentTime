using System;

namespace CurrentTime
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Определение точного времени в миллисекундах (13-значное число)");
         // Способ 1
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 1. DateTimeOffset.Now.ToUnixTimeMilliseconds()");
         Console.WriteLine("Текущее время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
         long timestampone = DateTimeOffset.Now.ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampone);

         // Способ 2
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 2. Ручной расчет через Ticks");
         Console.WriteLine("Текущее время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
         DateTimeOffset datetimeoffset = DateTimeOffset.Now;
         long timestamptwo = (datetimeoffset.Ticks - DateTimeOffset.UnixEpoch.Ticks) / TimeSpan.TicksPerMillisecond;
         Console.WriteLine("Unix timestamp (ms): {0}", timestamptwo);

         // Способ 3
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 3. new DateTimeOffset().ToUnixTimeMilliseconds()");
         Console.WriteLine("Текущее время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
         DateTimeOffset specificdate = DateTimeOffset.Now;
         long timestampthree = new DateTimeOffset(specificdate.DateTime).ToUnixTimeMilliseconds();
         Console.WriteLine("Unix timestamp (ms): {0}", timestampthree);

         // Способ 4
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 4. DateTime.Now и вычитание эпохи");
         Console.WriteLine("Текущее время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
         DateTime thistime = DateTime.Now;
         TimeSpan span = thistime - epoch;
         long timestampfour = (long)span.TotalMilliseconds;
         Console.WriteLine("Unix timestamp (ms): {0}", timestampfour);

         // Способ 5
         Console.WriteLine("========================================================");
         Console.WriteLine("Способ 5. DateTimeOffset с явным преобразованием");
         Console.WriteLine("Текущее время в миллисекундах: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
         DateTimeOffset rightnow = DateTimeOffset.Now;
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

         Console.ReadKey();
      }
   }
}