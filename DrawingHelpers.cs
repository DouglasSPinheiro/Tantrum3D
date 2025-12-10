using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tantrum3D
{
    using tuple3d = (float, float, float,float);

    public struct Vec2d
    {
        public float x, y;

        public Vec2d(float x, float y)
        {
            this.x = x; this.y = y; 
        }


        public static implicit operator Vec2d((float,float) p) => new(p.Item1,p.Item2);
        public static implicit operator Vec2d(Vec3d v) => new(v.x, v.y);

        public float this[int i]
        {
            get => i switch
            {
                0 => x,
                1 => y,
                _ => throw new ArgumentException("Point 2d: Indice fora de faixa")
            };
        }

        public static Vec2d operator +(Vec2d p1, Vec2d p2)
        {
            return new(
                 p1.x + p2.x,
                 p1.y + p2.y
                );
        }

        public static Vec2d operator -(Vec2d p1, Vec2d p2)
        {
            return new(
                 p1.x - p2.x,
                 p1.y - p2.y
                );
        }

        public static Vec2d operator -(Vec2d p1)
        {
            return new(
                 -p1.x,
                 -p1.y
                );
        }
    }

    public struct Mesh
    {
      public  List<Triangle> triangles;

     public static Mesh operator + (Mesh m,Vec3d offset)
        {
            Mesh result = new();
            result.triangles = new(m.triangles.Select(x => x + offset));
            return result;
        }

        public static Mesh operator *(float scale,Mesh m)
        {
            Mesh result = new();
            result.triangles = new(m.triangles.Select(x => scale * x));
            return result;
        }
    }

    internal class DrawingHelpers
    {
        public static void DrawTriangle(ICanvas canvas,Vec2d p1,Vec2d p2,Vec2d p3){
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 1;
            PathF path = new PathF(p1.x, p1.y);
            path.LineTo(p2.x, p2.y);
            path.LineTo(p3.x, p3.y);
            canvas.DrawPath(path);
        }

      
        
    }
}
