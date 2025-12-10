
using System.Diagnostics;
using Timer = System.Timers.Timer;
using static Tantrum3D.DrawingHelpers;
using static Tantrum3D.MeshConstructors;
namespace Tantrum3D


{
    public partial class MainPage : ContentPage, IDrawable
    {
        int count = 0;
        Timer t;
        Stopwatch s;
        public event EventHandler<double> update;


        float size = 5f;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            t = new(500);
            t.AutoReset = true;
            t.Elapsed += (sender, e) =>
            {
                update?.Invoke(this, s.ElapsedMilliseconds);
                App.Current.Dispatcher.Dispatch(() =>
                {
                     offset *= 5;
                    canva.Invalidate();
                 }
                    );
            };
            config();
            update += (s, elapsedTime) =>
            {
                size = size <100 ? size + 10 : 0;
                m = CreateCube(100);
            };

            offset = (0, 0.1f,0 );
            t.Start();
            s = new();
            s.Start();
          //  m = cube;
           
         
        }

        public Mesh m;
        public Vec3d offset;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            Vec3d center = (dirtyRect.Center.X, dirtyRect.Center.Y, 0);
            foreach (var triangle in m.triangles)
            {
                var projected = (triangle+offset)* projection +center;
                DrawTriangle(canvas, projected[0], projected[1], projected[2]);
            }
            ;
            
        }

        public void config()
        {
            float fNear = 0.1f;
            float fFar = 1000f;
            float fFov = 90f;
            float h = (float)canva.Height;
            float w = (float)canva.Width;
            float fAspectRatio =  h/w;
            float fFovRad = 1.0f / float.Tan(fFov * 0.5f / 180f * float.Pi);

            projection = (
                (fAspectRatio * fFovRad,     0f,                         0f,                     0f),
                (0f,                      (fFovRad),                     0f,                     0f),
                (0f,                         0f,               fFar / (fFar - fNear),            1.0f),
                (0f,                         0f,              (-fFar * fNear) / (fFar - fNear),  0f)

            );

        }

        Matrix4x4 projection;

       
    }

 
}