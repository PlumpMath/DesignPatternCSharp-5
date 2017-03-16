using System;


namespace DoFactory.DesignPattern
{
    public class FactoryExample : IPatternExample
    {
        public string PatternName { get; }

        public FactoryExample()
        {
            PatternName = "Factory";
        }

        public void Show()
        {
            // An array of creators
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                ProductOFactory product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }
        }
    }

    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class ProductOFactory
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductA : ProductOFactory
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductB : ProductOFactory
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Creator
    {
        public abstract ProductOFactory FactoryMethod();
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorA : Creator
    {

        public override ProductOFactory FactoryMethod()
        {

            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorB : Creator
    {

        public override ProductOFactory FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
