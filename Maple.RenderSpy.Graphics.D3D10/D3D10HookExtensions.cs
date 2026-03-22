using Maple.RenderSpy.Graphics.D3D.TempWindow;
using Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maple.RenderSpy.Graphics.D3D10
{
    public static class D3D10HookExtensions
    {
        public static IServiceCollection AddD3D10Hook(this IServiceCollection @this)
        {

            @this.TryAddSingleton<D3DTempWindowFactory>();
            @this.TryAddKeyedSingleton(EnumGraphicsType.D3D10, (p, key) => D3D10FunctionsProvider.Create(p.GetRequiredService<D3DTempWindowFactory>()));
            @this.TryAddSingletonHookItem<D3D10PresentHookItem>();
            //    .TryAddSingletonHookItem<D3D9ResetHookItem>()
            //    .TryAddSingletonHookItem<D3D9PresentHookItem>();
            return @this;
        }

    }
}
