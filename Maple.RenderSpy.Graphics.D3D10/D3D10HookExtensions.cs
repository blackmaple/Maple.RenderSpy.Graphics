using Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain;
using Maple.RenderSpy.Graphics.TempWindow;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maple.RenderSpy.Graphics.D3D10
{
    public static class D3D10HookExtensions
    {
        public static IServiceCollection AddD3D10FunctionsProvider(this IServiceCollection @this)
        {
            @this.AddGraphicsFunctionsProvider<D3D10FunctionsProvider>(EnumGraphicsType.D3D10);
            return @this;
        }

    }
}
