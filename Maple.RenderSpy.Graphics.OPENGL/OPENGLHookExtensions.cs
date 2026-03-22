using Microsoft.Extensions.DependencyInjection;


namespace Maple.RenderSpy.Graphics.OPENGL
{
    public static class OPENGLHookExtensions
    {
        extension(IServiceCollection @this)
        {

            public IServiceCollection AddOPENGLFunctionsProvider()
            {
                return @this.AddGraphicsFunctionsProvider<OPENGLFunctionsProvider>(EnumGraphicsType.OPENGL);

            }
        }

    }


}