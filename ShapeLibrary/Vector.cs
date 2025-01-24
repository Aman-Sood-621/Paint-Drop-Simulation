namespace ShapeLibrary
{
    public struct Vector
    {
        public float X {  get; } 
        public float Y { get; }

        public Vector (float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector (Vector v)
        {
            X = v.X;
            Y = v.Y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vector operator *(Vector v1, int x)
        {
            return new Vector(v1.X * x, v1.Y * x);
        }

        public static Vector operator *(Vector v1, float x)
        {
            return new Vector(v1.X * x, v1.Y * x);
        }

        public static Vector operator /(Vector v1, int x)
        {
            if (x == 0)
            {
                throw new DivideByZeroException("Cannot Divide By Zero");
            }
            return new Vector (v1.X/x, v1.Y/x);
        }

        public static Vector operator /(Vector v1, float x)
        {
            if (x == (float)0)
            {
                throw new DivideByZeroException("Cannot Divide By Zero");
            }
            return new Vector(v1.X / x, v1.Y / x);
        }

        // Only for Marbling to remove redundant calculation
        public static float MagnitudeWithoutSQRT(Vector v)
        {
            return v.X * v.X + v.Y * v.Y;
        }

        public static float Magnitude(Vector v)
        {
            return ((float)Math.Sqrt(v.X * v.X + v.Y * v.Y));
        }

        public static Vector Normalize(Vector v)
        {
            float magnitude = Magnitude(v);

            if (magnitude == 0)
            {
                return new Vector(0, 0);
            }

            return new Vector(v.X / magnitude, v.Y / magnitude);
        }

        public override string ToString()
        {
            return $"Vector: X: {X}, Y: {Y})";
        }
    }
}
