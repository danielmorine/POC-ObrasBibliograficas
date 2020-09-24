using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas
{
    class Program
    {
        static void Main(string[] args)
        {
            var nome = "Joao Neto da silva junior";
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

            var arr = nome.ToUpper().Split(" ");           
            var exists = Filter(arr.LastOrDefault());
            var count = 1;
            var total = arr.ToArray().Length;

            var sb = new StringBuilder();
            var firstName = new StringBuilder();
            var justOnName = count == total;

                foreach (var value in arr)
                {
                    var needsToBeLowerCase = ProbableLowerCase(value);
                    if (exists && Filter(value) && arr[total -1] == value)
                    {
                        sb.Append($"{value}");
                    }
                    else if (count == 1)
                    {
                        firstName.Append(count == total ? value : $"{Format(value)} ");
                    } else if (exists && Filter(arr[count]))
                    {
                        sb.Append($"{value} ");
                    }
                    else if (!needsToBeLowerCase && count != total)
                    {
                        firstName.Append($"{Format(value)} ");

                    } else if (needsToBeLowerCase)
                    {
                        firstName.Append($"{value.ToLower()} ");
                    }
                    else
                    {
                        sb.Append($"{value}");
                    }
                    count++;
                }

            if (justOnName)
            {
                Console.WriteLine(firstName.ToString());
            } else
            {
                sb.Append($", {firstName}");

                Console.WriteLine(sb.ToString());
            }    
            
            Console.ReadKey();
        }

        private static string Format(string word)
        {
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;          
                return cultInfo.ToTitleCase(word.ToLower());
        }

        private static bool ProbableLowerCase(string text)
        {
            var list = new List<string>
            {
                "DA", "DE", "DO", "DAS", "DOS"
            };

            if (list.Any(x => x.Equals(text)))
            {
                return true;
            }
            return false;
        }

        private static bool Filter(string text) {
            var list = new List<string>
            {
                { "FILHO" },
                { "FILHA" },
                { "NETO" },
                { "NETA" },
                { "SOBRINHO" },
                { "SOBRINHA" },
                { "JUNIOR" }
            };

            return list.Any(x => x.Equals(text.ToUpper()));
        }
    }
}
