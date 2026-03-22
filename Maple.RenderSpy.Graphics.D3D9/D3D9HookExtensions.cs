using Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9;
using Maple.RenderSpy.Graphics.TempWindow;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Maple.RenderSpy.Graphics.D3D9
{
    public static class D3D9HookExtensions
    {
        extension(IServiceCollection @this)
        {

            public IServiceCollection AddD3D9FunctionsProvider()
            {
                return @this.AddGraphicsFunctionsProvider<D3D9FunctionsProvider>(EnumGraphicsType.D3D9);
            }
        }
     
    }


}