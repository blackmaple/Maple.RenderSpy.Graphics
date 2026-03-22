namespace Maple.RenderSpy.Graphics
{
    public interface IGraphicsFunctions<T> where T : GraphicsFunctionsProvider
    {
        static abstract T Create(IServiceProvider provider);

    }
}
