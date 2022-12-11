using System;

namespace lab_3{
    class Article : IRateAndCopy{
        public Person Pers {get; set;}
        public string Title{get; set;}
        public double Rating{get; }

        public Article(Person pers, string title, double rati){
            this.Pers = pers;
            this.Title = title;
            this.Rating = rati;
        }

        public Article(){
            this.Pers = new Person() ;
            this.Title = "defoult Title";
            this.Rating = 0.0d;
        }


        public virtual object DeepCopy(){
            Article copy_article = new Article(this.Pers, this.Title, this.Rating);
            return copy_article;
        }

        public override string ToString()
        {
            return $"Автор {this.Pers}, Название статьи: {this.Title}, Рейтинг статьи: {this.Rating}";
        }

    }
}