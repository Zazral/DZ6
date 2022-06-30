using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZ6
{
    class Program
    {
        static void Writer(string date, string[] arr)
        {
            StreamWriter StreamWriter = new StreamWriter("workers.txt", true);
            StreamWriter.Write($"{date}#");
            for(int i = 0; i < arr.Length; i++)
            {
                if(i == arr.Length-1)
                {
                    StreamWriter.Write($"#город {arr[i]}\n");
                }
                else if(i<3)
                {
                    StreamWriter.Write($" {arr[i]}");
                }
                else StreamWriter.Write($"#{arr[i]}");
            }
            StreamWriter.Close();
        }
        static void Writer(int id)
        {
            StreamWriter StreamWriter = new StreamWriter("workers.txt", true);
            StreamWriter.Write($"{id}#");
            StreamWriter.Close();
        }
        static void Main(string[] args)
        {
            string[] str = new string[6];
            string[] Arr = new string[6];
            while (true)
            {
                Console.WriteLine("1-вывести данные\n2-записать данные\nenter-выход");
                string doing = Console.ReadLine();
                if (doing == "2")
                {
                    Console.WriteLine("Введите фио, возраст, рост, дату и место рождения сотрудника");
                    Arr = Console.ReadLine().Split(' ');
                    if(Arr.Length < 7)
                    {
                        Console.WriteLine("Данные введены ошибочно. Повторите ввод.");
                        continue;
                    }
                    string now = DateTime.Now.ToString();
                    try
                    {
                        using (StreamReader sr = new StreamReader("workers.txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                str = sr.ReadLine().Split('#');
                            }
                        }
                        Writer(Convert.ToInt32(str[0]) + 1);
                    }
                    catch
                    {
                        Writer(1);
                    }
                    Writer(now, Arr);
                    
                }
                else if (doing == "1")
                {
                    try
                    {

                        using (StreamReader sr = new StreamReader("workers.txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                str = sr.ReadLine().Split('#');
                                for (int i = 0; i <= str.Length - 1; i++)
                                {
                                    Console.Write($"{str[i]} ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Файл отсутствует. Введите данные для создания файла");
                        continue;
                    }
                }
                else break;
            }
        }
    }
}
