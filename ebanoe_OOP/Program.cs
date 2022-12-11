using System;
using System.Diagnostics;

namespace lab_1
{
    class Program
    {
        static void Main()
        {
            Magazine magazine = new Magazine();
            System.Console.WriteLine(magazine.ToShortString());


            // Magazine magazine1 = new Magazine("Forbes", Frequency.Weekly, new DateTime(1990, 10, 10),10);
            magazine.Nameofmag = "Forbes";
            magazine.Dateofpub = new DateTime(2015, 1, 25);
            magazine.Circulation = 10;
            magazine.Period = Frequency.Monthly;
            magazine.AddArticles(new Article(new Person(), "For", 4), new Article(new Person(),"For2", 5));
            System.Console.WriteLine(magazine);
            System.Console.WriteLine("Введите размерность (либо через пробел, либо через точку): ");
            string[] raz = System.Console.ReadLine().Split(' ', '.');

            
            Article[] articls1 = new Article[Int32.Parse(raz[0])*Int32.Parse(raz[1])];
            for(int i=0; i < Int32.Parse(raz[0])*Int32.Parse(raz[1]); i++){
                articls1[i] = new Article();
            }

            var time = Stopwatch.StartNew();
            for(int i = 0 ; i < Int32.Parse(raz[0])*Int32.Parse(raz[1]); i++){
                articls1[i].Rati = 4.232;
            }
            time.Stop();
            System.Console.WriteLine($"Время для заполнения одномерного массива = {time.Elapsed}");


            Article[,] articls2 = new Article[Int32.Parse(raz[0]),Int32.Parse(raz[1])];
            for(int i = 0; i < Int32.Parse(raz[0]); i++){
                for(int j = 0; j < Int32.Parse(raz[1]); j++){
                    articls2[i,j] = new Article();
                }
            }

            time = Stopwatch.StartNew();
            for(int i = 0; i < Int32.Parse(raz[0]); i++){
                for(int j = 0; j < Int32.Parse(raz[1]); j++){
                    articls2[i,j].Title = "Default";
                }
            }
            time.Stop();
            System.Console.WriteLine($"Время для заполнения прямоугольного массива = {time.Elapsed}");


            Article[][] articls3 = new Article[Int32.Parse(raz[0])][]; 
            for(int i = 0; i < articls3.Length; i++){
                articls3[i] = new Article[Int32.Parse(raz[1])];
            }
            for(int i = 0; i < articls3.Length; i++){
                for(int j = 0 ; j < articls3[i].Length; j++){
                    articls3[i][j] = new Article();
                }
            }
            
            time = Stopwatch.StartNew();
            for(int i = 0; i < articls3.Length; i++){
                for(int j = 0 ; j < articls3[i].Length; j++){
                    articls3[i][j].Pers = new Person("Ivan", "Pupkin",(new DateTime(1995,3,12)));
                }
            }
            time.Stop();
            System.Console.WriteLine($"Время для заполнения зубчатого массива = {time.Elapsed}");


            System.Console.WriteLine(magazine.ToString());
            magazine.AddArticles(new Article(new Person(),"MIREA", 2.0) ,new Article(new Person(), "MIREA2", 3.0));
            System.Console.WriteLine(magazine.ToString());
        }

    }

    enum Frequency {Weekly, Monthly, Yearly};

}