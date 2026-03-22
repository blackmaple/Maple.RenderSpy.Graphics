using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D.TempWindow;
using Maple.RenderSpy.Graphics.D3D11.HOOK_DXGISwapChain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Maple.RenderSpy.Graphics.D3D11
{
    public static class D3D11HookExtensions
    {
        public static IServiceCollection AddD3D11Hook(this IServiceCollection @this)
        {

            @this.TryAddSingleton<D3DTempWindowFactory>();
            @this.TryAddKeyedSingleton(EnumGraphicsType.D3D11, (p, key) => D3D11FunctionsProvider.Create(p.GetRequiredService<D3DTempWindowFactory>()));
            @this.TryAddSingletonHookItem<D3D11PresentHookItem>();
            return @this;
        }

    }
}
