using PowerfulConsole.Abstract;
using PowerfulConsole.Products;

namespace PowerfulConsole.Factories
{
    public class RoundedShapeFactory : AbstractFactory
    {
        public override IShape getShape(SHAPE shapeType)
        {

            if (shapeType == SHAPE.RECTANGLE)
            {
                return new RoundedRectangle();

            }
            else if (shapeType == SHAPE.SQUARE)
            {
                return new RoundedSquare();
            }

            return null;
        }

    }
}

