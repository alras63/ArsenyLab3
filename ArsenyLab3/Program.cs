using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArsenyLab3
{
    class Program
    {
        //Эта штука нужна, чтобы мы могли отркыть диалог из консольного приложения. Подробнее в документации
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 3. Вариант 12");

            Console.WriteLine("Выберите файл");

            //Открываем диалог
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //создаем экземпляр моего класса
                try
                {
                    MyFileInfo myFileInfo = new MyFileInfo(ofd.FileName);
                    var info = myFileInfo.GetAllInfo();

                    //получем пары ключ-значения из словаря с информацией
                    foreach (KeyValuePair<string, string> kvp in info)
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }

                    Console.WriteLine("Чтобы добавить информацию в конец файла, введите их в следующей строке: ");

                    string infoToAdd = Console.ReadLine();

                    myFileInfo.AddInfoToFile(infoToAdd);


                    Console.WriteLine();

                    Console.WriteLine("Мы добавили информацию в файл. ПОсмотрим на информацию о нем (увеличится размер файла)");
                    info = myFileInfo.GetAllInfo();

                    //получем пары ключ-значения из словаря с информацией
                    foreach (KeyValuePair<string, string> kvp in info)
                    {
                        Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            }
            else
            {
                Console.WriteLine("Произошла ошибка");
            }
            Console.Read();

        }
    }
}
