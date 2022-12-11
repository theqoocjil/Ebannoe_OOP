using System;
using System.Diagnostics;

namespace lab_3{
    class TestCollections{
        private List<Edition> list_editions = new List<Edition>();
        private List<string> list_strings = new List<string>();
        private Dictionary<Edition, Magazine> dic_ed_mag = new Dictionary<Edition, Magazine>();
        private Dictionary<string,Magazine> dic_str_mag = new Dictionary<string, Magazine>();

        public static Magazine GenerateMagazine(int x){
            return new Magazine(x.ToString(), new DateTime(), 0, Frequency.Yearly,new List<Article>(),new List<Person>());
        }

        public TestCollections(int countofelements){
            for(int i = 0; i < countofelements; i++){
                Magazine mag = GenerateMagazine(i);
                list_editions.Add(mag.Edition);
                list_strings.Add(mag.ToString());
                dic_ed_mag.Add(mag.Edition, mag);
                dic_str_mag.Add(mag.ToString(),mag);
            }
        }


        public void SearchTheElem(int size)
        {
            Magazine mag = new Magazine(size.ToString(), new DateTime(), 0, Frequency.Weekly, new List<Article>(), new List<Person>());
            var time = Stopwatch.StartNew();
            if (list_editions.Contains(mag.Edition))
            {
                time.Stop();
                Console.WriteLine("В списке edition содержится {0} элемент, время: {1}", size, time.Elapsed);
            }
 
            time = Stopwatch.StartNew();
            if (list_strings.Contains(mag.ToString()))
            {
                time.Stop();
                Console.WriteLine("В списке string содержится {0} элемента, время: {1}", size, time.Elapsed);
            }
 
            time = Stopwatch.StartNew();
            if (dic_ed_mag.ContainsKey(mag.Edition))
            {
                time.Stop();
                Console.WriteLine("В dic_ed_mag содержится {0} элемента, время: {1}", size, time.Elapsed);
            }
 
            time = Stopwatch.StartNew();
            if (dic_ed_mag.ContainsValue(mag))
            {
                time.Stop();
                Console.WriteLine("В dic_ed_mag содержится {0} элемента, время: {1}", size, time.Elapsed);
            }
 
            time = Stopwatch.StartNew();
            if (dic_str_mag.ContainsKey(mag.ToString()))
            {
                time.Stop();
                Console.WriteLine("В dic_str_mag содержится {0} элемента, время: {1}", size, time.Elapsed);
            }
 
            time = Stopwatch.StartNew();
            if (dic_str_mag.ContainsValue(mag))
            {
                time.Stop();
                Console.WriteLine("В dic_str_mag содержится {0} элемента, время: {1}", size, time.Elapsed);
            }
        }   

    }

}