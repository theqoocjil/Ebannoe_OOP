using System;

namespace lab_1{
    class Article{
        public Person Pers {get; set;}
        public string Title{get; set;}
        public double Rati{get;set;}

        public Article(Person pers, string title, double rati){
            this.Pers = pers;
            this.Title = title;
            this.Rati = rati;
        }

        public Article(){
            this.Pers = new Person() ;
            this.Title = "defoult Title";
            this.Rati = 0.0d;
        }

        public override string ToString()
        {
            return $"Автор {this.Pers}, Название статьи: {this.Title}, Рейтинг статьи: {this.Rati}";
        }



    }


}