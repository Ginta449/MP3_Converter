using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter folder path or type stop to exit:");
            string folderPath = Console.ReadLine();

            for(int i=0; i<100000; i++)
            {
                if(!folderPath.Contains("stop".ToUpper()))
                {
                    Console.WriteLine("Enter video link:");
                    string videoLink = Console.ReadLine();

                    new MediaManager(folderPath, videoLink);
                }
            }
            
        }
    }
}
