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
         Console.WriteLine();
         CaseFive();

         Console.ReadKey();
      }

      // Генерация метки времени
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

      public static void CaseFive()
      {

      }

      private static void CaseOne()
      {
         //string timeStamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + "000";

         // Пример Unix timestamp (13-значное число)
         long timestamp = 1769775722433;

         // Базовый метод
         DateTime localTime = FromUnixTimestamp(timestamp);
         Console.WriteLine("Базовое преобразование: {0}", localTime);
         Console.WriteLine("Базовое преобразование с милисекундами: {0:yyyy-MM-dd HH:mm:ss.fff}", localTime);

         // С учетом часового пояса
         // Свойство TimeZoneInfo.Id - "Russian Standard Time"
         DateTime moscowTime = FromUnixTimestampWithTimeZone(timestamp, "Russian Standard Time");
         Console.WriteLine("С учетом часового пояса: {0}", moscowTime);
         Console.WriteLine("С учетом часового пояса с милисекундами: {0:yyyy-MM-dd HH:mm:ss.fff}", moscowTime);
      }

      public static DateTime FromUnixTimestamp(long timestamp)
      {
         // Создаем начальную дату Unix эпохи
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

         // Конвертируем timestamp в локальное время
         return epoch.AddMilliseconds(timestamp).ToLocalTime();
      }

      public static DateTime FromUnixTimestampWithTimeZone(long timestamp, string timeZoneId)
      {
         DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         DateTime utcDateTime = epoch.AddMilliseconds(timestamp);

         // Получаем нужный часовой пояс
         TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

         // Конвертируем в локальное время
         return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
      }

      private static void CaseTwo()
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