
using System;


namespace DoFactory.DesignPattern
{
    public class SingleExample : IPatternExample
    {
        public string PatternName { get; private set; }

        public SingleExample()
        {
            PatternName = "Single";
        }

        public void Show()
        {
            // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    class Singleton
    {
        private static Singleton _instance;

        // Constructor is 'protected'
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {

            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }

    }
}
