namespace Tantrum3D
{
    using tuple3d = (float, float, float,float);

    public record struct Vec3d
    {
        public Vec3d(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;w = 1;
        }
        public Vec3d(float x, float y, float z,float w):this(x,y,z)
        {
            this.w = w;
        }

        public static Vec3d Zero() => new Vec3d(0,0,0,1);

        public override string ToString()
        {
            return $"{x} {y} {z} {w}";
        }
        public float x, y, z, w;

        public static implicit operator Vec3d(tuple3d t) => new Vec3d(t.Item1, t.Item2, t.Item3, t.Item4);
        public static implicit operator Vec3d((float,float,float)t) => new Vec3d(t.Item1, t.Item2,t.Item3);
        public static Vec3d Unitario { get => new Vec3d(1, 1, 1); }

        public static Vec3d operator *(Vec3d v, Matrix4x4 m)
        {
            Vec3d o = new();
            o.x = v.x * m[0,0] + v.y * m[1,0] + v.z * m[2,0] + m[3,0];
            o.y = v.x * m[0,1] + v.y * m[1,1] + v.z * m[2,1] + m[3,1];
            o.z = v.x * m[0,2] + v.y * m[1,2] + v.z * m[2,2] + m[3,2];
            float w = v.x * m[0,3] + v.y * m[1,3] + v.z * m[2,3] + m[3,3];

            if (w != 0.0f)
            {
                o.x /= w; o.y /= w; o.z /= w;
            }
            var a = m.ToString();
            return o;
        }
            
        public float this[int i]
        {
            get => i switch
            {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => throw new ArgumentException("Point 3d: Indice fora de faixa")
            };
            set 
            {
                switch (i)
                {
                    case 0: x = value;break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value;break;
                        default: throw new ArgumentException("Point 3d: Indice fora de faixa");
                }
            }

        }

        public static  Vec3d operator +(Vec3d p1,Vec3d p2)
        {
            return new(
                 p1.x + p2.x,
                 p1.y + p2.y,
                 p1.z + p2.z
                );
        }
        public static Vec3d operator *(Vec3d p1, Vec3d p2)
        {
            return new(
                 p1.x * p2.x,
                 p1.y * p2.y,
                 p1.z * p2.z
                );
        }

        public static Vec3d operator *(float f, Vec3d p)
        {
            return new(
                 f * p.x,
                 f * p.y,
                 f * p.z
                );
        }
        public static Vec3d operator *(Vec3d p, float f) => f * p;

        public static Vec3d operator /(Vec3d p1, Vec3d p2)
        {
            return new(
                 p1.x / p2.x,
                 p1.y / p2.y,
                 p1.z / p2.z
                );
        }


        public static Vec3d operator -(Vec3d p1, Vec3d p2)
        {
            return new(
                 p1.x - p2.x,
                 p1.y - p2.y,
                 p1.z - p2.z
                );
        }

        public static Vec3d operator -(Vec3d p1)
        {
            return new(
                 -p1.x ,
                 -p1.y ,
                 -p1.z 
                );
        }
    }
}
