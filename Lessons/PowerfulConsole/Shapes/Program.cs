using PowerfulConsole.Abstract;
using PowerfulConsole.Factories;

namespace PowerfulConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AbstractFactory 1
            AbstractFactory shapeFactory = ClientFactoryProducer.getFactory(false);
            IShape shape1 = shapeFactory.getShape(SHAPE.RECTANGLE);
            shape1.draw();
            IShape shape2 = shapeFactory.getShape(SHAPE.SQUARE);
            shape2.draw();



            // AbstractFactory 2
            AbstractFactory shapeFactory1 = ClientFactoryProducer.getFactory(true);
            IShape shape3 = shapeFactory1.getShape(SHAPE.RECTANGLE);
            shape3.draw();
            IShape shape4 = shapeFactory1.getShape(SHAPE.SQUARE);
            shape4.draw();
        }
    }
    public enum SHAPE
    {
        RECTANGLE,
        SQUARE
    }
}

