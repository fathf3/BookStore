using BookStore.Services;
using System.IO;

namespace BookStore.Common
{
    public class Log : ILoggerService
    {

        public void checkAndCreate()
        {

            string filePath = @"C:\Users\fatih\Documents\Code\CSharp\Patika\BookStore\BookStore\Log";
            if (!Directory.Exists(filePath))//Logların bulunduğu dosya yoksa oluşturur
            {
                Directory.CreateDirectory(filePath);//Dosya yoksa oluşturur
                //Aşağıdaki kod ise string ifadeleri birleştirerek bir dosya yolu oluşturur
                string logFilePath = Path.Combine(filePath, "log-dosyasi" + ".txt");
                if (!File.Exists(logFilePath))
                    File.Create(logFilePath);
            }
            else
            {
                string logFilePath = Path.Combine(filePath, "log-dosyasi" + ".txt");
                if (!File.Exists(logFilePath))
                    File.Create(logFilePath);
            }
        }

        //Log mesajını kullanıcının log dosyasına yazdıran metot

        public void writeLog(string logMessage)
        {
            
            checkAndCreate();
            

            //Önce log dosyalarının bulunduğu ana dosyaya gideceğiz
            string folderPath = @"C:\Users\fatih\Documents\Code\CSharp\Patika\BookStore\BookStore\Log";
            //Sonra belirtilen dosya yolunu kapsayan log.txt dosya yollarını bir diziye aktaracağız
            string[] logFiles = Directory.GetFiles(folderPath, "log-dosyasi" + ".txt");
            string logFilePath = logFiles[0];//Belirtilen koşulu sağlayan ilk log dosyasını alıyoruz

            //StreamWriter ile dosyaya yazdırma işlemi gerçekleştiriyoruz  
            using (StreamWriter logWriter = File.AppendText(logFilePath))
            {
                //AppenText() metodu var olan metin  dosyasına yeni bir metin dosyası eklemek için kullanılıır
                logWriter.WriteLine(logMessage);
            }
        }
    }
}
