using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tantrum3D
{
    public static class MeshConstructors
    {

        public static Mesh CreateCube(float l = 1) {
            Mesh m = new();

            m.triangles = new() {
                    ((0.0f, 0.0f, 0.0f), (0.0f, 1f, 0.0f), (1f, 1f, 0.0f)),
                    ((0.0f, 0.0f, 0.0f), (1f, 1f, 0.0f), (1f, 0.0f, 0.0f)),

                    ((1f, 0.0f, 0.0f), (1f, 1f, 0.0f), (1f, 1f, 1f)),
                    ((1f, 0.0f, 0.0f), (1f, 1f, 1f), (1f, 0.0f, 1f)),

                    ((1f, 0.0f, 1f), (1f, 1f, 1f), (0.0f, 1f, 1f)),
                    ((1f, 0.0f, 1f), (0.0f, 1f, 1f), (0.0f, 0.0f, 1f)),

                    ((0.0f, 0.0f, 1f), (0.0f, 1f, 1f), (0.0f, 1f, 0.0f)),
                    ((0.0f, 0.0f, 1f), (0.0f, 1f, 0.0f), (0.0f, 0.0f, 0.0f)),

                    ((0.0f, 1f, 0.0f), (0.0f, 1f, 1f), (1f, 1f, 1f)),
                    ((0.0f, 1f, 0.0f), (1f, 1f, 1f), (1f, 1f, 0.0f)),

                    ((1f, 0.0f, 1f), (0.0f, 0.0f, 1f), (0.0f, 0.0f, 0.0f)),
                    ((1f, 0.0f, 1f), (0.0f, 0.0f, 0.0f), (1f, 0.0f, 0.0f))
                };
            return l * m;
        }
    }
}
