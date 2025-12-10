namespace Tantrum3D
{
    public static class MatrixTransformationExtensions
    {
        public delegate Matrix4x4 LazyMatrix4x4();
        public delegate float LazyF();


        public static T ItemAt<T>(this (T, T, T, T) tupla, int pos) => pos switch
        {
            0 => tupla.Item1,
            1 => tupla.Item2,
            2 => tupla.Item3,
            3 => tupla.Item4,
            _=> throw new NotImplementedException()
        };

    } 

}
