using Maple.RenderSpy.Graphics;
using Maple.RenderSpy.Graphics.Windows.Native;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace Maple.RenderSpy.Graphics.Windows
{
    public static class WindowsGraphicsExtensions
    {
        extension(IServiceCollection @this)
        {
            public IServiceCollection AddWindowsGraphicsHookFactory(bool jmpChain = false)
            {
                @this.TryAddSingleton<Win32WindowFactory>();
                @this.AddGraphicsHookFactory(jmpChain);
                return @this;
            }



        }

    }
}