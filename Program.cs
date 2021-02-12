using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Interfaces
            //
            //Can't call method bark on it, unless casting is implemented
            IAnimal animal = new Dog();

            //Instruct user
            Console.WriteLine("Interfaces:");

            //Initiate Move method
            animal.Move();

            //Division
            Console.WriteLine(string.Empty);

            //Inheritance
            //
            //Base class Object
            Base b = new Base();

            //Instruct user
            Console.WriteLine("Inheritance:");

            //Initiate Base.Execute method
            b.Execute();

            //Derived class Object
            Derived d = new Derived();

            //Initiate Derived.Execute method
            d.Execute();

            //Division
            Console.WriteLine(string.Empty);

            //Abstract and Sealed classes
            Console.WriteLine("Abstract and Sealed classes");
            //Abstract Derived class object
            AbstractDerived ad = new AbstractDerived();
            //Initiate Asbtract Base class MethodWithImplementation method
            ad.MethodWithImplementation();
            //Initiate overridden AbstractMethod
            ad.AbstractMethod();

            //Division
            Console.WriteLine(string.Empty);

            //IComparable interface
            Console.WriteLine("IComparable interface");

            //List of hard-coded orders
            List<Order> orders = new List<Order>
            {
                new Order { Created = new DateTime(2012, 12, 1 )},
                new Order { Created = new DateTime(2012, 1, 6 )},
                new Order { Created = new DateTime(2012, 7, 8 )},
                new Order { Created = new DateTime(2012, 2, 20 )},
            };

            //calls the CompareTo method to sort items. After sorting, list contains the orderedOrders.
            orders.Sort();

            //Display sorted orders
            foreach(var o in orders){
                Console.WriteLine(o.Created);
            }

            //Division
            Console.WriteLine(string.Empty);

            //IComparable interface
            Console.WriteLine("IEnumerable interface");

            //Initiate EnumerableInterface void method
            EnumerableInterface();
        }

        //Interface: Cntains the public signature of methods, properties, events, and indexers
        //Interfaces can be implemented by structs and classes.
        //Can't instantiate interface directly, can only instantiate oncrete type that implements interface(line 9)
        interface IAnimal
        {
            void Move();
        }

        class Dog : IAnimal
        {
            //Dog.Move method
            public void Move() {
                Console.WriteLine("Dog moved!");
            }

            //Dog.Bark method
            public void Bark() {
                Console.WriteLine("Dog barked!");
            }
        }

        //Inheritance
        class Base
        {
            //Base.Execute method
            public void Execute() { 
                Console.WriteLine("Base.Execute"); 
            }
        }

        class Derived : Base
        {
            //Derived.Execute method
            public new void Execute() { 
                Console.WriteLine("Derived.Execute"); 
                }
        }

        //Abstract and Sealed classes
        //If you don’t want to allow a base class to be instantiated, you can declare it as an abstract class. 
        //Abstract Class: Can have implementation code for its members, but it’s not required. Because class is abstract, can’t use new operator on it to create new instance
        //The opposite of an abstract class is a sealed class, cannot be derived from. can’t be marked as abstract. All members should have an implementation. 
        //Structs are implicitly sealed in C#. 
        abstract class AbstractBase
        {
            public virtual void MethodWithImplementation() {
                Console.WriteLine("Hello there...");
                }

            public abstract void AbstractMethod();
        }

        //Abstract Derived class
        class AbstractDerived : AbstractBase
        {
            //Overridden Abstract method
            public override void AbstractMethod() {
                Console.WriteLine("General Kenobi!");
             }
        }

        //IComparable interface
        //Interface is used to sort elements. CompareTo method returns int value that shows how two elements are related
        //Less than zero: The current instance precedes the object specified by the CompareTo method in the sort order.
        //Equal to zero: This current instance occurs in the same position in the sort order as the object specified by the CompareTo method.
        //More than zero: This current instance follows the object specified by the CompareTo method in the sort order.
        class Order : IComparable
        {
            public DateTime Created { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) 
                return 1;

                Order o = obj as Order;

                if (o == null)
                {
                    throw new ArgumentException("Object is not an Order");
                }

                //CompareTo method
                return this.Created.CompareTo(o.Created);
            }
        }

        //IEnumerable interface
        //IEnumerable: helps you to implement iterator pattern, which enables you to access all elements in collection without caring about how it’s implemented
        //IEnumerable exposes GetEnumerator method that returns an enumerator. Enumerator has a MoveNext method that returns next item in collection.
        public static void EnumerableInterface(){
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }
        }

    }
}
