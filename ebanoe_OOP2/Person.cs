using System;

namespace lab_2
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person()
        {
            this.name = "Defoult";
            this.surname = "Defoult";
            this.birthday = new DateTime(0001,1,1);

        }

        public Person(string name, string surname, DateTime birthday){
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        // Just for understanding how it's working
        // public string Name{
        //     get{return this.name;}
        //     set{this.name = value;}
        // }


        public string Name {
            get{
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        public string Surname {
            get{
                return this.surname;
            }
            set {
                this.surname = value;
            }
        }

        public DateTime Birthday{
            get{return this.birthday;}
            set{this.birthday = value;}
        }


        public int Year{
            get{return this.birthday.Year;}
            // set{this.birthday = this.birthday.AddYears(-(this.birthday.Year - 1)).AddYears(value - 1);}
            // // second variant how to do set option 
            set{this.birthday = new DateTime(value, this.birthday.Month, this.birthday.Day) ;}
        }

        public override string ToString()
        {
            return($"Имя: {this.name} Фамилия: {this.surname} Дата рождения: {this.birthday}");
        }

        public virtual string ToShortString(){
            return $"Имя: {this.name} Фамилия: {this.surname}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null){
                return false;
            }
            if (obj is not Person){
                return false;
            }
            return (Name == ((Person)obj).Name && Surname == ((Person)obj).Surname && Birthday == ((Person)obj).Birthday);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode() ^ Birthday.GetHashCode();
        }

        public static bool operator == (Person pers1, Person pers2){
            return pers1.Equals(pers2);
        }

        public static bool operator != (Person pers1, Person pers2){
            return !pers1.Equals(pers2);
        }


        public virtual Person DeepCopy(){
            Person copy_person = new Person(this.name, this.surname, this.birthday);
            return copy_person;
        }
    }
}
