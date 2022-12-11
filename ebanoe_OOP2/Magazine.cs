using System;
using System.Collections;

namespace lab_2{

    class Magazine: Edition, IRateAndCopy{
        private Frequency period;
        private ArrayList editors = new ArrayList();
        private ArrayList articles = new ArrayList();


        public Magazine()
            :base()
        {
            this.period = Frequency.Yearly;
        }


        public Magazine(string title, DateTime dateofpub, int circulation, Frequency period, ArrayList articles, ArrayList editors)
            :base(title,dateofpub,circulation)
        {
            this.period = period;
            this.articles = articles;
            this.editors = editors;
        }


        public IEnumerable<double> ByRating (double Rating)
        {
            foreach (Article a in articles)
            {
                if (a.Rating > Rating)
                yield return a.Rating;
            }   
        }


        public IEnumerable<string> ByNameSubstring(string SubString)
        {
            foreach (Article p in this.articles)
            {
                if (p.Title.IndexOf(SubString) > -1)
                    yield return p.Title;
            }
        }


        public IEnumerable<Article> ByArticle(){
            foreach (Article a in this.articles){
                if ((this.editors.Contains(a.Pers))){
                    yield return a;
                }
            }
        }

        public IEnumerable<Person> ByPerson(){
            List<Person> temp = new List<Person> ();
            foreach(Article a in this.articles){
                temp.Add(a.Pers);
            }
            foreach(Person a in this.editors){
                if (!temp.Contains(a))
                yield return a;
            }
        }
        

        public double Rating{
            get{
                double sum = 0;
                if (articles.Count == 0)
                {
                    return 0;
                }
                else{
                    foreach(Article el in articles){
                        sum += el.Rating;
                    }
                    return sum/articles.Count ;
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
            Article[] temp_articles;
            Person[] temp_editors;
            List<Article> temp_articles2 = new List<Article>();
            List<Person> temp_editors2 = new List<Person>();
            temp_articles = (Article[])this.articles.ToArray(typeof(Article));
            temp_editors = (Person[])this.editors.ToArray(typeof(Person));
            foreach(Article a in temp_articles){
                temp_articles2.Add((Article)a.DeepCopy());
            }
            foreach(Person a in temp_editors){
                temp_editors2.Add((Person)a.DeepCopy());
            }
            ArrayList temp1 = new ArrayList(temp_articles2);
            ArrayList temp2 = new ArrayList(temp_editors2);

            Magazine copy_magazine = new Magazine(base.title, base.dateofpub, base.circulation, this.period, temp1, temp2);
            return copy_magazine;
        }
        


        public ArrayList Articles{get{return this.articles;}set{this.articles = value;}}
        public ArrayList Editors{get{return this.editors;}set{this.articles = value;}}


        public void AddArticles(params Article[] articles){
            this.articles.AddRange(articles);
        }


        public void AddEditors(params Person[] editors){
            this.editors.AddRange(editors);
        }


        public override string ToString()
        {
            string string_article = "";
            for(int i = 0; i < this.articles.Count; i++){
                string_article += this.articles[i].ToString();
            }
            string string_editors = "";
            for(int i = 0; i < this.editors.Count; i++){
                string_editors += this.editors[i].ToString();
            }
            return $"Название: {base.title}, Дата публикации: {base.dateofpub}, Тираж: {base.circulation}, Период публикации {this.period}, Список статей: {string_article}, Список редакторов: {string_editors}";
        }


        public virtual string ToShortString(){
            return $"Название: {base.title}, Дата публикации: {base.dateofpub}, Тираж: {base.circulation}, Период публикации {this.period}, {this.Rating}";
        }


        public IEnumerator GetEnumerator() => new MagazineEnumerator(this);

    }
}