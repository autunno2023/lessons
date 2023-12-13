using PowerfulConsole.Abstract;

namespace PowerfulConsole.Factories
{
    public class ClientFactoryProducer
    {
        public static AbstractFactory getFactory(bool rounded)
        {
            if (rounded)
            {
                return new RoundedShapeFactory();
            }
            else
            {
                return new ShapeFactory();
            }
        }
    }
}



