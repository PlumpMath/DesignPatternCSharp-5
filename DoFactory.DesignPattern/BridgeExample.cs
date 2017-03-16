using System;

namespace DoFactory.DesignPattern
{
    public class BridgeExample : IPatternExample
    {
        public string PatternName { get; private set; }

        public BridgeExample()
        {
            PatternName = "Bridge";
        }

        public void Show()
        {
            Abstraction ab = new RefinedAbstraction();

            // Set implementation and call
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    class Abstraction
    {
        public Implementor implementor;

        // Property
        public Implementor Implementor
        {
            set { implementor = value; }
        }

        public virtual void Operation()
        {
            implementor.Operation();
        }
    }


    /// <summary>
    /// The 'Implementor' abstract class
    /// </summary>
    abstract class Implementor
    {
        public abstract void Operation();
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    class RefinedAbstraction : Abstraction
    {

        public override void Operation()
        {
            implementor.Operation();

        }
    }

    /// <summary>
    /// The 'ConcreteImplementorA' class
    /// </summary>
    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }

    }

    /// <summary>
    /// The 'ConcreteImplementorB' class
    /// </summary>
    class ConcreteImplementorB : Implementor
    {

        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
}
