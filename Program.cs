using System;

namespace CurrentTime
{
   internal class Program
   {
      static void Main()
      {
         CaseOne();
         Console.WriteLine();
         CaseTwo();
         Console.WriteLine();
         CaseThree();
         Console.WriteLine();
         CaseFour();
         Console.WriteLine();
         CaseFive();

         Console.ReadKey();
      }

      static void CaseFive()
      {
         Console.WriteLine("Текущее UTC время: {0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.UtcNow);
         Console.WriteLine("==========================================");

         // Способ 1
         long timestampone = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         Console.WriteLine("Способ 1 (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()):");
         Console.WriteLine("Результат: {0}", timestampone);
         Console.WriteLine("Длина: {0} цифр", timestampone.ToString().Length);
         Console.WriteLine("Формат: {0:#,##0}\n", timestampone);

         // Способ 2
         DateTimeOffset timeoffset = DateTimeOffset.UtcNow;
         long timestamptwo = (timeoffset.Ticks - DateTimeOffset.UnixEpoch.Ticks) / TimeSpan.TicksPerMillisecond;
         Console.WriteLine("Способ 2 (Ручной расчет через Ticks):");
         Console.WriteLine("Результат: {0}", timestamptwo);
         Console.WriteLine("Длина: {0} цифр", timestamptwo.ToString().Length);
         Console.WriteLine("Формат: {0:#,##0}\n", timestamptwo);

         // Способ 3
         DateTimeOffset specificdate = DateTimeOffset.UtcNow;
         long timestampthree = new DateTimeOffset(specificdate.UtcDateTime).ToUnixTimeMilliseconds();
         Console.WriteLine("Способ 3 (new DateTimeOffset().ToUnixTimeMilliseconds()):");
         Console.WriteLine("Результат: {0}", timestampthree);
         Console.WriteLine("Длина: {0} цифр", timestampthree.ToString().Length);
         Console.WriteLine("Формат: {0:#,##0}\n", timestampthree);

         // Проверка эквивалентности
         Console.WriteLine("Проверка эквивалентности:");
         Console.WriteLine("Способ 1 == Способ 2: {0}", timestampone == timestamptwo);
         Console.WriteLine("Способ 2 == Способ 3: {0}", timestamptwo == timestampthree);

         // Конвертация обратно для проверки
         Console.WriteLine("\nКонвертация обратно в DateTime:");
         DateTimeOffset datefromtimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampone);
         Console.WriteLine("Из timestamp: {0:yyyy-MM-dd HH:mm:ss.fff}", datefromtimestamp);
      }

      // Точное время в Unix‑timestamp в миллисекундах (13‑значное число)
      static void CaseFour()
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