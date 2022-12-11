using System;
using System.Collections;

namespace lab_3
{
    class Program
    {
        static void Main(){
            List<Article> articles = new List<Article>() {new Article(new Person(),"Инфоповод", 2.0)};
            List<Person> persons = new List<Person>() {new Person()};
            Magazine first = new Magazine("Аутро",new DateTime(2016,1,1),9,Frequency.Monthly, articles, new List<Person>());
            Magazine second = new Magazine("Наука",new DateTime(2011,1,1),10,Frequency.Weekly, new List<Article>(), new List<Person>());
            MagazineCollection collection = new MagazineCollection();
            Magazine[] magazines = new Magazine[]{second,first};
            collection.AddMagazines(magazines);
            System.Console.WriteLine(collection);
            System.Console.WriteLine("###############################################################");
            System.Console.WriteLine("##########################По названию##########################");
            foreach(var a in collection.ByTitle){
                System.Console.WriteLine(a);
            }
            System.Console.WriteLine("##########################По дате##############################");
            foreach(var a in collection.ByDateOfPub){
                System.Console.WriteLine(a);
            }
            System.Console.WriteLine("##########################По тиражу##############################");
            foreach(var a in collection.ByCirculation){
                System.Console.WriteLine(a);
            }
            System.Console.WriteLine("##################################################");
            System.Console.WriteLine($"Максимальное значение {collection.AVGRating}");
            System.Console.WriteLine("######################Period######################");
            foreach(var a in collection.ByFrequency){
                System.Console.WriteLine(a);
            }
            System.Console.WriteLine("#########По значению среднего рейтинга############");
            foreach (var a in collection.RatingGroup(1.0)){
                System.Console.WriteLine(a);
            }

            TestCollections test = new TestCollections(8);
            System.Console.WriteLine("############################Первый элемент##############################");
            test.SearchTheElem(1);
            System.Console.WriteLine("############################По центру элемент###########################");
            test.SearchTheElem(4);
            System.Console.WriteLine("############################Нет в коллекции#############################");
            test.SearchTheElem(9);

        }
    }


    interface IRateAndCopy{
        double Rating {get;}
        object DeepCopy();
    }

    enum Frequency {Weekly, Monthly, Yearly};
}
