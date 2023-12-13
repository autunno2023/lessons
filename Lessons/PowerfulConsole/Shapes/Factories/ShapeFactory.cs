using PowerfulConsole.Abstract;
using PowerfulConsole.Products;

namespace PowerfulConsole.Factories
{
    public class ShapeFactory : AbstractFactory
    {
        public override IShape getShape(SHAPE shapeType)
        {
            if (shapeType == SHAPE.RECTANGLE)
            {
                return new Rectangle();

            }
            else if (shapeType == SHAPE.SQUARE)
            {
                return new Square();
            }

            return null;
        }
    }
}

