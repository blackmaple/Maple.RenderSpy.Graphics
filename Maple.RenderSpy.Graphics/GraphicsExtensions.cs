using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maple.RenderSpy.Graphics
{
    public static class GraphicsExtensions
    {
        extension(IServiceCollection @this)
        {
            public IServiceCollection AddGraphicsHookFactory()
            {
                @this.TryAddSingleton<IGraphicsHookFactory, DefaultGraphicsHookFactory>();
                return @this;
            }

            public IServiceCollection AddGraphicsFunctionsProvider<T>(EnumGraphicsType graphicsType)
                where T : GraphicsFunctionsProvider, IGraphicsFunctions<T>
            {
                @this.AddKeyedSingleton<GraphicsFunctionsProvider>(graphicsType, (p, key) => T.Create(p));
                return @this;
            }

        }

    }
}
