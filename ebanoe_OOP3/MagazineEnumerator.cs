using System;
using System.Collections;


namespace lab_3{

    class MagazineEnumerator: IEnumerator{

        Magazine magazine;
        int position = -1;

        System.Collections.Generic.List<Person> temp;
        System.Collections.Generic.List<Article> temp1;

        public MagazineEnumerator(Magazine magazine){
            this.magazine = magazine;
            this.temp = magazine.Editors;
            this.temp1 = magazine.Articles;
        }

        public object Current{
            get{
                return magazine.Articles[position];
            }
        }
        public bool MoveNext(){ 
            while (++position < magazine.Articles.Count && IsEditor(temp,temp1[position]));
            return position < magazine.Articles.Count;
        }
        public void Reset(){
            position = -1;
        }

        private bool IsEditor(List<Person> editors, Article article){
            return(editors.Contains(article.Pers));
            
        }

    }
}