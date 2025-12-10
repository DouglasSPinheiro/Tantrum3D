namespace Tantrum3D
{
    using System.Runtime.CompilerServices;
    using static MatrixTransformationExtensions;
    using tuple3d = (float, float, float,float);


    public record struct Matrix4x4
    {
        private float[] m = new float[16];

        public Matrix4x4()
        {
            m = new float[16];
            for (int i = 0; i < 16; i++)
                m[i] = 0f;
        }

        public static  Matrix4x4 Zero = new Matrix4x4();

        public static implicit operator Matrix4x4((tuple3d l1, tuple3d l2, tuple3d l3, tuple3d l4) t) =>
            new Matrix4x4(t.l1, t.l2, t.l3, t.l4);

        public static implicit operator Matrix4x4( float[] p)
        {
            if (p.Length != 16)
                return Matrix4x4.Zero;

            var m = new float[16];
            for (int i = 0; i < 16; i++)
                m[i] = 0f;
            return new() { m = m };
        }

        public Matrix4x4(tuple3d l1, tuple3d l2, tuple3d l3, tuple3d l4)
        {
            m = new float[16];

            var a = (float[] m, int c, Vec3d l) =>
            {
                for (int i = 0; i < 4; i++)
                    m[4 * c + i] = l[i];
            };

            a(m, 0, l1);
            a(m, 1, l2);
            a(m, 2, l3);
            a(m, 3, l4);
        }

        public float this[int x, int y]
        {
            get
            {
                
                return m[x*4+y];
            }
            set
            {
                m[x*4+y] = value;
            }
        }

        public override string ToString()
        {
            string retorno = "";
            for(int i = 0; i < 4; i++) { 
                for(int j = 0;j < 4;j++)
                    retorno += $"{m[i * 4 + j]} ";
                retorno += " | ";
            }
            return retorno;
        }
    }

}
