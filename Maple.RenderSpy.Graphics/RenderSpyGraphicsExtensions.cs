using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.TempWindow;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maple.RenderSpy.Graphics
{
    public static class RenderSpyGraphicsExtensions
    {
        extension(IServiceCollection @this)
        {
            public IServiceCollection AddGraphicsHookFactory()
            {
                @this.TryAddSingleton<D3DTempWindowFactory>();
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
