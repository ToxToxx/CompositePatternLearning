using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Component forbiddenKingdom = new Location("Forbidden kingdom");

            // make new location
            Component castle = new Location("Castle");

            // new memorable places
            Component treasureWithTraps = new Places("Treasure with Traps");
            Component palaceOfTheFallenKing = new Places("Fallen king Palace");

            // add memorable places in Location
            castle.Add(treasureWithTraps);
            castle.Add(palaceOfTheFallenKing);

            // add castle into forbidden Kingdom
            forbiddenKingdom.Add(castle);

            // print all of this
            forbiddenKingdom.Print();
            Console.WriteLine("\n" + new string('-',25));

            // delete treasury place
            castle.Remove(treasureWithTraps);

            // add new location
            Component surroundingOfCastle = new Location("Surrounding of Castle");

            // add new places
            Component houseOfBlacksmith = new Places("House of Blacksmith");
            Component knightsCamp = new Places("Knight's camp");
            surroundingOfCastle.Add(houseOfBlacksmith);
            surroundingOfCastle.Add(knightsCamp);
            castle.Add(surroundingOfCastle);

            forbiddenKingdom.Print();

            Console.Read();
        }
    }

    //Component
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.Write(name + ", ");
        }
    }
    //Composite
    class Location : Component
    {
        private List<Component> _components = new List<Component>();

        public Location(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Location: " + name);
            Console.Write("Memorable Places: ");
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Print();
            }
        }
    }

    //Leaf
    class Places : Component
    {
        public Places(string name)
                : base(name)
        { }
    }
}
