using System;
using System.Text;

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

      // Генерация метки времени Binance
      // Преобразование временных меток Binance в формат DateTime
      public static void CaseFour()
      {
         // 1. Получение текущего Timestamp
         //В API Binance все поля, относящиеся ко времени и меткам времени, отображаются в миллисекундах» (в стиле Unix)
         // timestamp: Представляет собой метку времени в миллисекундах, когда был инициирован запрос
         // Она может быть включена в строку запроса или тело запроса
         StringBuilder queryStringBuilder = new StringBuilder();
         long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         Console.WriteLine(timestamp);
         queryStringBuilder.Append("timestamp=").Append(timestamp);
         Console.WriteLine(queryStringBuilder);
         // Ответ сервера Binance
         // Все ответы от REST API Binance Spot предоставляются в формате JSON
         // Для обеспечения единообразия во всем API значения времени и метки времени указываются в миллисекундах

         // 2. Конвертация Timestamp из API в DateTime
         // Если вы получили данные от API (например, время закрытия свечи), их можно перевести в привычный формат:
         DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
         Console.WriteLine(dateTime);
         Console.WriteLine("Конвертация из Timestamp в DateTime: {0}", dateTime);
         Console.WriteLine("Конвертация из Timestamp в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTime);

         // Временная метка Binance - это миллисекунды прошедшей эпохи
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
         DateTime addMilliseconds = epoch.AddMilliseconds(timestamp);
         Console.WriteLine(addMilliseconds);
         Console.WriteLine("Конвертация из Timestamp в DateTime: {0}", addMilliseconds);
         Console.WriteLine("Конвертация из Timestamp в DateTime с милисекундами: {0:dd.MM.yyyy HH:mm:ss.fff}", addMilliseconds);
      }

      private static void CaseOne()
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
         // Базовый способ конвертации
         // Способ 1: DateTime с миллисекундами
         DateTime dateTimeNow = DateTime.Now;

         // Конвертация в Unix timestamp
         DateTime unixStartOne = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         TimeSpan timeSpanOne = dateTimeNow.ToUniversalTime() - unixStartOne;
         long timeStampOne = (long)(timeSpanOne.TotalMilliseconds);
         Console.WriteLine("Текущее время: {0}", dateTimeNow);
         Console.WriteLine("Локальное время: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeNow);
         Console.WriteLine("Unix timestamp: {0}", timeStampOne);

         // Использование DateTimeOffset
         // Способ 2: DateTimeOffset с учетом часового пояса
         DateTimeOffset dateTimeOffset = DateTimeOffset.Now;

         // Конвертация в Unix timestamp
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpanTwo = dateTimeOffset.UtcDateTime - unixStart.UtcDateTime;
         long timestampTwo = (long)(timeSpanTwo.TotalMilliseconds);
         Console.WriteLine("Текущее время: {0}", dateTimeOffset);
         Console.WriteLine("Локальное время: {0:dd.MM.yyyy HH:mm:ss.fff}", dateTimeOffset);
         Console.WriteLine("Unix timestamp: {0}", timestampTwo);
      }

      public static long ToUnixTimestamp(DateTimeOffset date)
      {
         DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
         TimeSpan timeSpan = date.UtcDateTime - unixStart.UtcDateTime;
         return (long)(timeSpan.TotalMilliseconds);
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