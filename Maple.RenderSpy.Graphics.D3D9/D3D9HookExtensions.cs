using Maple.RenderSpy.Graphics.D3D.TempWindow;
using Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Maple.RenderSpy.Graphics.D3D9
{
    public static class D3D9HookExtensions
    {
        extension(IServiceCollection @this)
        {

            public IServiceCollection AddD3D9Hook()
            {
                @this.TryAddSingleton<D3DTempWindowFactory>();
                @this.TryAddKeyedSingleton(EnumGraphicsType.D3D9, (p, key) => D3D9FunctionsProvider.Create(p.GetRequiredService<D3DTempWindowFactory>()));
                @this.TryAddSingletonHookItem<D3D9EndSceneHookItem>()
                    .TryAddSingletonHookItem<D3D9ResetHookItem>()
                    .TryAddSingletonHookItem<D3D9PresentHookItem>();
                 return @this;
            }
        }
     
    }


}