using System;

namespace lab_1{
    class Magazine{
        private string nameofmag;
        private Frequency period;
        private DateTime dateofpub;
        private int circulation;
        private Article[] articles;

        public Magazine(){
            this.nameofmag = "defoult";
            this.period = Frequency.Yearly;
            this.circulation = 0;
            this.dateofpub = new DateTime(0001,1,1);
            this.articles = new Article[0];
        }

        public Magazine(string nameofmag, Frequency period, DateTime dateofpub, int circulation){
            this.nameofmag = nameofmag;
            this.period = period;
            this.circulation = circulation;
            this.dateofpub = dateofpub;
        }

        public string Nameofmag{get {return this.nameofmag;} set{this.nameofmag = value;}}
        public Frequency Period{get{return this.period;} set{this.period = value;}}
        public DateTime Dateofpub{get{return this.dateofpub;} set{this.dateofpub = value;}}
        public int Circulation{get{return this.circulation;} set{this.circulation = value;}}
        public Article[] Articles{get{return this.articles.ToArray();} set {this.articles = value;}}

        public double Rating{
            get{
                double sum = 0;
                if (articles.Length == 0)
                {
                    return 0;
                }
                else{
                    foreach(Article el in articles){
                        sum += el.Rati;
                    }
                    return sum/articles.Length ;
                } 
            }
        }
        public bool this[Frequency index]{
            get{
                return this.Period == index;
            }
        }
        public void AddArticles(params Article[] articles){
            this.articles = (articles);
        }

        public override string ToString()
        {
            return $"{this.nameofmag},{this.period},{this.dateofpub},{this.circulation},{String.Join(",",this.articles.ToList())} ";
        }
        public virtual string ToShortString(){
            return $"{this.nameofmag},{this.period},{this.dateofpub},{this.circulation}, ({this.Rating})";
        }

    }


}