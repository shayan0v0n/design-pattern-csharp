namespace factory_pattern_1
{
    internal class Program
    {
        public interface IProduct
        {
            string Operation();
        }

        abstract class Creator
        {
            public abstract IProduct FactoryMethod();
            public string SomeOperation()
            {
                var product = FactoryMethod();
                var result = "Creator: The same creator's code has just worked with "
                    + product.Operation();

                return result;
            }
        }

        class ConcreteProduct1 : IProduct
        {
            public string Operation() => "{Result of ConcreteProduct1}";
            
        }

        class ConcreteProduct2 : IProduct
        {
            public string Operation() => "{Result of ConcreteProduct2}";
            
        }

        class ConcreteCreator1 : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct1();
            }
        }

        class ConcreteCreator2 : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct2();
            }
        }

        class Client
        {
            public void Main()
            {
                Console.WriteLine("App: Launched with the ConcreteCreator1.");
                ClientCode(new ConcreteCreator1());

                Console.WriteLine("");

                Console.WriteLine("App: Launched with the ConcreteCreator2.");
                ClientCode(new ConcreteCreator2());
            }
            public void ClientCode(Creator creator)
            {
                Console.WriteLine("Client: I'm not aware of the creator's class," +
                    "but it still works.\n" + creator.SomeOperation());
            }
        }

        static void Main(string[] args)
        {
            new Client().Main();
            Console.ReadKey();
        }
    }
}
