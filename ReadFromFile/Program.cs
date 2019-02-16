using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromFile
{
    class Program
    {
        //Correct
        public static int get_key()
        {
            Console.Write("Enter your key: ");
            int key = Convert.ToInt32(Console.ReadLine());
            return key;
        }

        //Correct
        public static void codding(char[] list)
        {
            int number = 0;
            int letter_number;
            int key = get_key();
            string abc = "abcdefghijklmnopqrstuvwxyz";
            char ch;
            int abc_length = abc.Length;

            while (number != get_value())
            {
                if (list[number] == ' ')
                {
                    number++;
                    continue;
                }
                else
                {
                    letter_number = found(abc, list[number]);
                    letter_number += key - 1;

                    while (letter_number >= abc_length)
                    {
                        letter_number -= abc_length;
                    }

                    ch = abc[letter_number];
                    list[number] = ch;
                    number++;
                }
            }
        }

        //Correct
        public static void print_list(char[] list)
        {
            int number = get_value();
            for (int i = 0; i < number; i++)
            {
                Console.Write(list[i]);
            }
        }

        //Correct
        public static int get_value ()
        {
            string link = @"C:\Users\rocho\Desktop\ReadFromFile\read.txt";
            string line;

            using (StreamReader sr = new StreamReader(link))
            {
                line = sr.ReadToEnd();
            }

            int count = line.Length;
            return count;
        }

        //Correct
        public static void make_list(char[] list)
        {
            string link = @"C:\Users\rocho\Desktop\ReadFromFile\read.txt";
            int text_lengh = get_value();

            using (StreamReader sr = new StreamReader(link, System.Text.Encoding.Default))
            {
                sr.Read(list, 0, text_lengh);
            }
        }

        //Correct
        public static int found(string abc, char letter)
        {
            int low, hight, mid;
            char ch;

            low = 0;
            hight = abc.Length - 1;

            letter = char.ToLower(letter);

            while (low <= hight)
            {
                mid = (low + hight) / 2;
                ch = abc[mid];

                if (ch == letter)
                {
                    return mid + 1;
                }
                if (ch > letter)
                {
                    hight = mid - 1;
                }
                if (ch < letter)
                {
                    low = mid + 1;
                }

            }
            return 0;
        }

        //Correct
        public static void write_to_txt (char[] list)
        {
            string writePath = @"C:\Users\rocho\Desktop\ReadFromFile\write.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(list);
            }
        }

        static void Main(string[] args)
        {
            int number = get_value();

            char[] list = new char[number];

            make_list(list);
            codding(list);
            print_list(list);
            write_to_txt(list);
            Console.ReadKey();
        }
    }
}
