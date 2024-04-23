namespace factory_pattern_2
{
    internal class Program
    {
        interface ITransport
        {
            string Operation();
        }

        abstract class Logistics
        {
            abstract public ITransport planDelivery();
            public string createTransport() {
                ITransport transport = planDelivery();
                string text = $"transport created: {transport.Operation()}";
                return text;
            }
        }

        class Truck: ITransport {
            public string Operation() => "this is truck";
        }

        class Ship: ITransport
        {
            public string Operation() => "this is ship";
        }

        class RoadLogistics: Logistics
        {
            public override ITransport planDelivery()
            {
                return new Truck();
            }
        }

        class SeaLogistics: Logistics
        {
            public override ITransport planDelivery()
            {
                return new Ship();
            }
        }

        class Client()
        {
            public void Main()
            {
                Console.WriteLine("try to deliver road logisitc...");
                ClientCode(new RoadLogistics());

                Console.WriteLine("");

                Console.WriteLine("try to deliver sea logisitc...");
                ClientCode(new SeaLogistics());
            }

            public void ClientCode(Logistics logistics)
            {
                Console.WriteLine($"{logistics.createTransport()}");
            }
        }


        static void Main(string[] args)
        {
            new Client().Main();
            Console.ReadKey();
        }
    }
}
