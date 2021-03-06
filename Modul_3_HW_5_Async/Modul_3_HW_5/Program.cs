/*using System;
using System.IO;
using System.Threading.Tasks;

namespace Modul_3_HW_5
{
    public class Program
    {
        private static string ReadFile()
        {
            StreamReader sr = new StreamReader("text.txt");
            return sr.ReadLine();
        }

        private static async Task<string> ReadFileAsync()
        {
            return await Task.FromResult(ReadFile());
        }

        private static async Task<string> ReturnStringAsync()
        {
            return await Task.FromResult("world");
        }

        private static string ConcatStringAsync()
        {
            var readFile = ReadFileAsync();
            var returnString = ReturnStringAsync();
            string s = string.Concat(readFile, returnString);
            return s;
        }

        private static void Main(string[] args)
        {
            Task.WhenAll().GetAwaiter().GetResult();
            var result = ConcatStringAsync();
            Console.WriteLine(result);
        }
    }
} */

using System;
using System.IO;
using System.Threading.Tasks;

namespace Modul_3_HW_5
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var readFile = ReadFileAsync();
            var returnString = ReturnStringAsync();
            var result = string.Concat(readFile, returnString);
            Console.WriteLine(result);

            static async Task<string> ReadFileAsync()
            {
                using (FileStream fstream = File.OpenRead("text.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    await fstream.ReadAsync(array, 0, array.Length);

                    string textFromFile = System.Text.Encoding.UTF8.GetString(array);
                    return textFromFile;
                }
            }

            static async Task<string> ReturnStringAsync()
            {
                return await Task.FromResult("world");
            }
        }
    }
}