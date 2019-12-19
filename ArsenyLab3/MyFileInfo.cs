using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArsenyLab3
{
  
    class MyFileInfo
    {

        //Путь до файла
        public string Path { get; set; }

        //Название файла - всегда строка, ее можно получить (get) и установить (set)
        public string FileName { get; set; }

        //long - очень большое число, хранит в себе размер файла в байтах
        public long FileLength { get; set; }

        //DateTime, в которую будем запписывать инфомацию о дате создания файла
        public DateTime FileCreatedDate { get; set; }

        //Переменная, хранящая состояние файла (занят или нет)
        public string FileState = "Неизвестно";


        //конструктор класса. принимает строку с путем до файла и анализирует его (определяет название, длину и дату создания)
        public MyFileInfo(string path)
        {
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                //Инициализируем класс с ифномацией о файле
                FileInfo info = new FileInfo(path);

                FileName = info.Name;
                FileLength = info.Length;
                FileCreatedDate = info.CreationTime;
                Path = path;

            } else
            {
                throw new Exception("Не удалось найти файл с заданным путем");
            }
           
        }

        //метод для записи данных в конец файла. получает в себя строку, которую нужно записать
       public void AddInfoToFile(string text)
       {
            if(File.Exists(Path)) {
                File.AppendAllText(Path, text);
                FileInfo finf = new FileInfo(Path);
                FileLength = finf.Length;
            } else
            {
                throw new Exception("Не удалось найти файл с заданным путем");
            }
       }

        //состояние файла - такая штука, которая описывает, занят ли этот файл сейчас, "Этот файл используется в другой программе" и т.д.

        public string CheckState()
        {
            if (File.Exists(Path))
            {
                try
                {
                    using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Write))
                    {
                        fs.Dispose();
                        FileState = "Файл не занят";
                    }
                }
                catch (Exception)
                {
                    FileState = "Файл занят";
                }

                return FileState;

                
            }
            else
            {
                throw new Exception("Не удалось найти файл с заданным путем");
            }
        } 

        //возвращает ассоциативный массив (словарь) со всеми вычисленными настройками
        public Dictionary<String, String> GetAllInfo()
        {
            Dictionary<String, String> info = new Dictionary<string, string>();

            info.Add("Имя файла", FileName);
            info.Add("Путь до файла", Path);
            info.Add("Длина файла", FileLength.ToString());
            info.Add("Дата создания файла", FileCreatedDate.ToString());
            info.Add("Состояние файла", CheckState());

            return info;

        }
        
    }
}
