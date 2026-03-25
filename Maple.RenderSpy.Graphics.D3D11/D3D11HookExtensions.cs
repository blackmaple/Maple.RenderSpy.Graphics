using Microsoft.Extensions.DependencyInjection;

namespace Maple.RenderSpy.Graphics.D3D11
{
    public static class D3D11HookExtensions
    {
        public static IServiceCollection AddD3D11FunctionsProvider(this IServiceCollection @this)
        {
            return @this.AddGraphicsFunctionsProvider<D3D11FunctionsProvider>(EnumGraphicsType.D3D11);
        }

    }
}
