using System;
using System.Collections;

namespace lab_3{

    class Magazine: Edition, IRateAndCopy{
        private Frequency period;

        private List<Person> list_of_persons = new List<Person>();
        private List<Article> list_of_articles = new List<Article>();



        public Magazine()
            :base()
        {
            this.period = Frequency.Yearly;
        }


        public Magazine(string title, DateTime dateofpub, int circulation, Frequency period, List<Article> articles, List<Person> editors)
            :base(title,dateofpub,circulation)
        {
            this.period = period;
            this.list_of_articles = articles;
            this.list_of_persons = editors;
        }


        public IEnumerable<double> ByRating (double Rating)
        {
            foreach (Article a in list_of_articles)
            {
                if (a.Rating > Rating)
                yield return a.Rating;
            }   
        }


        public IEnumerable<string> ByNameSubstring(string SubString)
        {
            foreach (Article p in this.list_of_articles)
            {
                if (p.Title.IndexOf(SubString) > -1)
                    yield return p.Title;
            }
        }


        public IEnumerable<Article> ByArticle(){
            foreach (Article a in this.list_of_articles){
                if ((this.list_of_persons.Contains(a.Pers))){
                    yield return a;
                }
            }
        }

        public IEnumerable<Person> ByPerson(){
            List<Person> temp = new List<Person> ();
            foreach(Article a in this.list_of_articles){
                temp.Add(a.Pers);
            }
            foreach(Person a in this.list_of_persons){
                if (!temp.Contains(a))
                yield return a;
            }
        }

        


        public double Rating{
            get{
                double sum = 0;
                if (list_of_articles.Count == 0)
                {
                    return 0;
                }
                else{
                    foreach(Article el in list_of_articles){
                        sum += el.Rating;
                    }
                    return sum/list_of_articles.Count ;
                } 
            }
        }

        public Edition Edition{
            get {
                return new Edition(base.Title, base.Dateofpub, base.Circulation);
                }
            set {
                Edition temp = (Edition)value; 
                base.Title = temp.Title;
                base.Dateofpub = temp.Dateofpub;
                base.Circulation = temp.Circulation;
                }
        }


        public override Magazine DeepCopy(){
            List<Article> temp_articles2 = this.list_of_articles;
            List<Person> temp_editors2 = this.list_of_persons;
            foreach(Article a in temp_articles2){
                temp_articles2.Add((Article)a.DeepCopy());
            }
            foreach(Person a in temp_editors2){
                temp_editors2.Add((Person)a.DeepCopy());
            }

            Magazine copy_magazine = new Magazine(base.title, base.dateofpub, base.circulation, this.period, temp_articles2, temp_editors2);
            return copy_magazine;
        }
        


        public List<Article> Articles{get{return this.list_of_articles;}set{this.list_of_articles = value;}}
        public List<Person> Editors{get{return this.list_of_persons;}set{this.list_of_persons = value;}}
        public Frequency Period{get{return this.period;} set{this.period = value;}}

        public void AddArticles(params Article[] articles){
            this.list_of_articles.AddRange(articles);
        }

        public bool this[Frequency index]{
            get{
                return this.period == index;
            }
        }
        public void AddEditors(params Person[] editors){
            this.list_of_persons.AddRange(editors);
        }


        public override string ToString()
        {
            string string_article = "";
            for(int i = 0; i < this.list_of_articles.Count; i++){
                string_article += this.list_of_articles[i].ToString();
            }
            string string_editors = "";
            for(int i = 0; i < this.list_of_persons.Count; i++){
                string_editors += this.list_of_persons[i].ToString();
            }
            return $"Название: {base.title}, Дата публикации: {base.dateofpub}, Тираж: {base.circulation}, Период публикации {this.period}, Список статей: {string_article}, Список редакторов: {string_editors}";
        }


        public virtual string ToShortString(){
            return $"Название: {base.title}, Дата публикации: {base.dateofpub}, Тираж: {base.circulation}, Период публикации {this.period}, Рейтинг: {this.Rating}";
        }


        public IEnumerator GetEnumerator() => new MagazineEnumerator(this);

    }
}