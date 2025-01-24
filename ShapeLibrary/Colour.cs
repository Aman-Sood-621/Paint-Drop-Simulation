namespace ShapeLibrary
{
    public struct Colour
    {
        public int Red { get; }
        public int Blue { get; }
        public int Green { get; }
        
        public Colour(int r, int g, int b)
        {
            if (r < 0 || r > 255)
            {
                throw new ArgumentOutOfRangeException("Incorrect Red Value");
            }

            if (g < 0 || g > 255)
            {
                throw new ArgumentOutOfRangeException("Incorrect Green Value");
            }

            if (b < 0 || b > 255)
            {
                throw new ArgumentOutOfRangeException("Incorrect Blue Value");
            }

            Red = r;
            Blue = b;
            Green = g;
        }

        public static Colour operator +(Colour c1, Colour c2)
        {
            int r = Math.Clamp(c1.Red + c2.Red, 0, 255);
            int g = Math.Clamp(c1.Green + c2.Green, 0, 255);
            int b = Math.Clamp(c1.Blue + c2.Blue, 0, 255);

            return new Colour(r, g, b);
        }

        public static Colour operator -(Colour c1, Colour c2)
        {
            int r = Math.Clamp(c1.Red - c2.Red, 0, 255);
            int g = Math.Clamp(c1.Green - c2.Green, 0, 255);
            int b = Math.Clamp(c1.Blue - c2.Blue, 0, 255);

            return new Colour(r, g, b);
        }

        public static Colour operator *(Colour c1, int x)
        {
            int r = Math.Clamp(c1.Red * x, 0, 255);
            int g = Math.Clamp(c1.Green * x, 0, 255);
            int b = Math.Clamp(c1.Blue * x, 0, 255);

            return new Colour(r, g, b);
        }

        public static bool operator ==(Colour c1, Colour c2)
        {
            return c1.Red == c2.Red && c1.Green == c2.Green && c1.Blue == c2.Blue;
        }

        public static bool operator !=(Colour c1, Colour c2)
        {
            return !(c1== c2);
        }

        public override string ToString()
        {
            return $"Colour(R: {Red}, G: {Green}, B: {Blue})";
        }
    }
}
