
namespace Core.Helpers
{
    public static class Log
    {
        public static void Error(string errorMessage)
        {
            string logFilePath = "logError.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] Hata: {errorMessage}");
                    writer.WriteLine("-------------------------------------------");
                }

                Console.WriteLine("Hata loglandı. Log dosyası: " + logFilePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Hata loglanırken bir hata oluştu.");
            }
        }
        public static void Info(string infoMessage)
        {
            string logFilePath = "logInfo.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] Bilgi: {infoMessage}");
                    writer.WriteLine("-------------------------------------------");
                }

                Console.WriteLine("Bilgi loglandı. Log dosyası: " + logFilePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Hata loglanırken bir hata oluştu.");
            }
        }
    }
}
