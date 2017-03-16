using System;

namespace DoFactory.DesignPattern
{
    public class DecoratorExample : IPatternExample
    {
        public string PatternName { get; private set; }

        public DecoratorExample()
        {
            PatternName = "Decorator";
        }

        public void Show()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class DecoratorComponent
    {
        public abstract void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class ConcreteComponent : DecoratorComponent
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    abstract class Decorator : DecoratorComponent
    {
        protected DecoratorComponent component;

        public void SetComponent(DecoratorComponent component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }


    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
        }
    }
}
