using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_names
{
    struct Person
    {
        public string Name, Surname;
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
    
    public class SortService
    {
        string _fileName;
        IEnumerable<string> lines;
        public SortService(string fileName)
        {
            _fileName = fileName;
        }
        public bool IsInputFileExists()
        {
            return File.Exists(_fileName);
        }
        public bool IsInputFileNotEmpty()
        {
            lines = File.ReadLines(_fileName);
            return lines.Any();
        }
        public bool IsInputFileProperlyFormatted()
        {
            if (IsInputFileNotEmpty())
            {
                return lines.All(item => item.Contains(','));
            }
            return false;
        }
        public string Execute()
        {
            string rVal = "created names-sorted.txt";
            IEnumerable<Person> personel = lines.Select(item => new Person { Surname = item.Split(',')[0], Name = item.Split(',')[1] }).OrderBy(item => item.Surname).ThenBy(item => item.Name).ToList();
            _fileName = String.Format("{0}{1}-sorted{2}", AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(_fileName), Path.GetExtension(_fileName));
            File.WriteAllLines(_fileName, personel.Select(item => String.Join(",", item.Surname, item.Name)));
            Console.Write("created names-sorted.txt");
            return rVal;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                string FileName = args[0];
                SortService srv = new SortService(FileName);
                if (srv.IsInputFileExists())
                {
                    if (srv.IsInputFileNotEmpty())
                    {
                         if (srv.IsInputFileProperlyFormatted())
                        {
                             srv.Execute();
                        }
                        else
                        {
                            Console.Write("File is not formatted as expected");
                        }
                    }
                    else
                    {
                        Console.Write("File is empty");
                    }
                }
                else
                {
                    Console.Write("File not found");
                }
            }
            else
            {
                Console.Write("No file provided");
            }
        }
    }
}
