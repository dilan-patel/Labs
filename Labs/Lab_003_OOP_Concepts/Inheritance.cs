using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_003_OOP_Concepts
{
    class Inheritance
    {
        // Inheritance allows a class to be define in terms of another class.

        // Parent
            // Child
                // GrandChild
    }

    class Parent
    {
        // This is a base (parent) class

        string parentTrait = "This string belongs in base (parent) class.";
        // This class can make use of parentTrait.

        public Parent()
        {

        }
    }

    class Child : Parent
    {
        // This is a derived (child) class that inherits from parent using ':'.

        string childTrait = "This string belongs in child (derived) class.";
        // This class can make use of parentTrait and childTrait.

        public Child()
        {

        }
    }

    class GrandChild : Child
    {
        // You can inherit from a derivative but not from multiple base classes.

        string grandChildTrait = "This string belongs to further child (derived from previous child) class.";
        // This class can make use of parentTrait, childTrait and grandChildTrait.

        public GrandChild()
        {

        }
    }
}
