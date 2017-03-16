using System;

namespace DoFactory.DesignPattern
{
    public class CommandExample : IPatternExample
    {

        public string PatternName { get; private set; }

        public CommandExample()
        {
            PatternName = "Command";
        }

        public void Show()
        {
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    public abstract class Command
    {

        protected Receiver Receiver;

        // Constructor
        public Command(Receiver receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();

    }


    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    public class ConcreteCommand : Command
    {

        // Constructor
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            Receiver.Action();
        }
    }


    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    public class Receiver
    {

        public void Action()
        {

            Console.WriteLine("Called Receiver.Action()");
        }
    }


    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    public class Invoker
    {

        private Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
