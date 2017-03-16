
using System;
using System.Collections.Generic;

namespace DoFactory.DesignPattern
{

    public class VisitorExample : IPatternExample
    {
        public string PatternName { get; private set; }

        public VisitorExample()
        {
            PatternName = "Visitor";
        }

        public void Show()
        {
            // Setup structure
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            // Create visitor objects
            IntEvaluator v1 = new IntEvaluator();
            StringEvaluator v2 = new StringEvaluator();

            // Structure accepting visitors
            o.Accept(v1);
            o.Accept(v2);

        }
    }

    /// <summary>
    /// The 'Visitor' abstract class
    /// </summary>
    public abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }


    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    public class IntEvaluator : Visitor
    {
        public override void VisitConcreteElementA(

         ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0} visited by {1}",

            concreteElementA.GetType().Name, GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, GetType().Name);
        }
    }


    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    public class StringEvaluator : Visitor
    {
        public override void VisitConcreteElementA(

        ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0} visited by {1}",
            concreteElementA.GetType().Name, GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, GetType().Name);
        }

    }


    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);

    }

    /// <summary>
    /// A 'ConcreteElement' class
    /// </summary>
    public class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {

            visitor.VisitConcreteElementA(this);

        }

        public void OperationA()
        {

        }

    }


    /// <summary>
    /// A 'ConcreteElement' class
    /// </summary>
    public class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {
        }
    }



    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    public class ObjectStructure
    {
        private List<Element> _elements = new List<Element>();

        public void Attach(Element element)
        {
            _elements.Add(element);
        }

        public void Detach(Element element)
        {
            _elements.Remove(element);

        }

        public void Accept(Visitor visitor)
        {

            foreach (Element element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
