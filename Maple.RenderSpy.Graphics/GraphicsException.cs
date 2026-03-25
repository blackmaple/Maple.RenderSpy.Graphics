using System.Diagnostics.CodeAnalysis;

namespace Maple.RenderSpy.Graphics
{
    public class GraphicsException(string? msg) : Exception(msg)
    {
        [DoesNotReturn]
        public static void Throw(string? msg = default) => throw new GraphicsException(msg);

        [DoesNotReturn]
        public static T Throw<T>(string? msg = default) => throw new GraphicsException(msg);
    }



}
