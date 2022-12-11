using System;

namespace lab_3{

    class EditionException : ArgumentException{
        public EditionException(string message )
        :base(message){}
    }
}