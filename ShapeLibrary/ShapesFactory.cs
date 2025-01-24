namespace ShapeLibrary
{
    public static class ShapesFactory
    {
        public static ICircle CreateCircle(float radius, Vector center, Colour colour)
        {
            return new Circle(radius, center, colour);
        }

        public static IRectangle CreateRectangle(float x, float y, float width, float height, Colour colour)
        {
            return new Rectangle(x, y, width, height, colour);
        }
    }
}
