using System;

namespace lab_2{

    class EditionException : ArgumentException{
        public EditionException(string message )
        :base(message){}
    }
}