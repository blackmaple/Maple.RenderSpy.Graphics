using Maple.RenderSpy.Graphics;
using Maple.RenderSpy.Graphics.D3D10;
using Maple.RenderSpy.Graphics.D3D11;
using Maple.RenderSpy.Graphics.D3D9;
using Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9;
using Maple.RenderSpy.Graphics.OPENGL;
using Microsoft.Extensions.DependencyInjection;
using Maple.Hook.Imp.Dobby;
using Maple.RenderSpy.Graphics.D3D11.HOOK_DXGISwapChain;
using Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain;
var service = new ServiceCollection();
Maple.Hook.Imp.Dobby.Dynamic.DobbyHookDynamicExtensions.AddDobbyHookDynamicFactory(service, "dobby.dll");
service.AddD3D10FunctionsProvider();
service.AddD3D11FunctionsProvider();
service.AddD3D9FunctionsProvider();
service.AddOPENGLFunctionsProvider();
service.AddGraphicsHookFactory();
var build = service.BuildServiceProvider();
var graphicsHookFactory = build.GetRequiredService<IGraphicsHookFactory>();
using var hookItem1 = graphicsHookFactory.Create<D3D11PresentHookItem>(EnumGraphicsType.D3D11);
using var hookItem2 = graphicsHookFactory.Create<D3D10PresentHookItem>(EnumGraphicsType.D3D10);
using var hookItem3 = graphicsHookFactory.Create<OPENGLwglSwapBuffersHookItem>(EnumGraphicsType.OPENGL);

using var hookItem = graphicsHookFactory.Create<D3D9EndSceneHookItem>(EnumGraphicsType.D3D9);

hookItem.Enable();
hookItem.Disable();
Console.WriteLine("?");