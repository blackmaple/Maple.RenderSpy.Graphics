using Maple.Hook.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maple.RenderSpy.Graphics
{
    public static class RenderSpyGraphicsExtensions
    {
        extension(IServiceProvider @this)
        {
            public T CreateHookItem<T>()
                where T : HookItem, IHookItemFactory<T>

            {
                var hookFactory = @this.GetRequiredService<IHookFactory>();
                var functionsProvider = @this.GetRequiredKeyedService<IRenderSpyGraphicsFunctionsProvider>(EnumGraphicsType.D3D9);
                return T.Create(hookFactory, functionsProvider);
            }
        }

        extension(IServiceCollection @this)
        {
            public IServiceCollection TryAddSingletonHookItem<T>()
                 where T : HookItem, IHookItemFactory<T>
            {
                @this.TryAddSingleton(CreateHookItem<T>);
                return @this;
            }

        }

    }
}
