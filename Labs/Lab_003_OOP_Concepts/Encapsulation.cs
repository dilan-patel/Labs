using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_003_OOP_Concepts
{
    class Encapsulation
    {
        // The process of enclosing one or more items of a class which can be used to prevent access to implementation details.
        // Implemented by using access modifiers.

        private string privateString = "I am a secret!";
        public string publicString = "Anyone can see me!";
        protected string protectedString = "Child classes can see me!";
        internal string internalString = "Can only be seen in namespace";
        protected internal string protIntString = "Can only be seen by child classes in namespace";

        public string PrivateString { get => privateString; set => privateString = value; }
    }
}
