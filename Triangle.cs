
namespace Tantrum3D
{
    public struct Triangle
    {
       public Triangle() : this(Vec3d.Unitario, Vec3d.Unitario, Vec3d.Unitario) { }

       
       public Triangle(Vec3d p1,Vec3d p2,Vec3d p3)
        {
            vertices = new Vec3d[3];
            vertices[0] = p1;
            vertices[1] = p2;
            vertices[2] = p3;
        }

       public static implicit operator Triangle((Vec3d,Vec3d,Vec3d)t)=>new Triangle(t.Item1,t.Item2,t.Item3);

        public static  Triangle operator  +(Triangle t,Vec3d v)
        {
            Triangle result = new();
            for (int i = 0; i< 3; i++)
                result.vertices[i] = t.vertices[i]+v;
            return result;
        }

        public static Triangle operator *(float f, Triangle t) {
            new Triangle();
            for (int i=0; i < 3; i++)
                t.vertices[i] *= f;
            return t;
        }

        public Vec3d this[int i] { get => vertices[i];set => vertices[i] = value; }

       public static Triangle operator *(Triangle t,Matrix4x4 transform)
        {
            Triangle result = new();
            for (int i = 0; i < 3; i++)
                result.vertices[i] = t.vertices[i] * transform;
            return result;
        }

       public Vec3d[] vertices;
    }
}
