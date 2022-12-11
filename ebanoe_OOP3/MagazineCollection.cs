using System;

namespace lab_3{

    class MagazineCollection{
        public List<Magazine> list_of_magazines = new List<Magazine>();
        public List<Magazine> ByTitle{get {return this.SortByTitle();}}

        public List<Magazine> ByDateOfPub{get {return this.SortByDateOfPub();}}

        public List<Magazine> ByCirculation{get {return this.SortByCirculation();}}

        public double AVGRating{get {
            double maximum = 0;
            List<double> avg = new List<double>();
            foreach(Magazine a in list_of_magazines){
                avg.Add(a.Rating);
            }
            if (avg.Count > 0) maximum = avg.Max();
            return maximum;}}

        public IEnumerable<Magazine> ByFrequency{get {
            var selected = from p in this.list_of_magazines where p[Frequency.Monthly] == true select p;
            return selected ;
        }}

        public List<Magazine> RatingGroup(double value){
            var result = from p in list_of_magazines group p by p.Rating into g select new {Rating = g.Key, Magazine = g.ToList()};
            List<Magazine> temp = new List<Magazine>();
            foreach (var a in result){
                if (a.Rating >= value){
                    temp.AddRange(a.Magazine);
                }
            }
            return temp;
        }


        private List<Magazine> SortByTitle(){
            this.list_of_magazines.Sort();
            return list_of_magazines;
        }


        private List<Magazine> SortByDateOfPub(){
            Edition comparer = new Edition();
            this.list_of_magazines.Sort(comparer);
            return list_of_magazines;
        }


        private List<Magazine> SortByCirculation(){
            Edition.Compare comparer = new Edition.Compare();
            this.list_of_magazines.Sort(comparer);
            return list_of_magazines;
        }

        public void AddDefaults(){
            this.list_of_magazines.Add(new Magazine());
            this.list_of_magazines.Add(new Magazine());
            this.list_of_magazines.Add(new Magazine());
        }


        public void AddMagazines(params Magazine[] magazines){
            this.list_of_magazines.AddRange(magazines);
        }


        public override string ToString(){
            string string_magazines = "";
            for(int i = 0; i < this.list_of_magazines.Count; i++){
                string_magazines += this.list_of_magazines[i].ToString() + "\n --------------------------------\n";
            }
            return $"Список журналов:\n{string_magazines}";
        }

        public virtual string ToShortString(){
            string string_magazines = "Список журналов:\n";
            for(int i = 0; i < this.list_of_magazines.Count; i++){
                string_magazines += this.list_of_magazines[i].ToShortString();
                string_magazines += $", Кол-во редакторов журнала: {this.list_of_magazines[i].Editors.Count}, ";
                string_magazines += $"Кол-во статей в журнале: {this.list_of_magazines[i].Articles.Count}";
                string_magazines+= "\n----------------------------\n";
            }
            return string_magazines;
        }


    }

}