using Maple.Hook.Abstractions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.OPENGL
{
    public class OPENGLwglSwapBuffersHookItem : HookItem<OPENGLwglSwapBuffersHookItem, Ptr_Func_wglSwapBuffers, Ptr_Func_wglSwapBuffers>, IGraphicsHookItem<OPENGLwglSwapBuffersHookItem>
    {
        public const string MethodName = Ptr_Func_wglSwapBuffers.Name;

        public Func<HandleDeviceContext, OPENGLwglSwapBuffersHookItem, bool>? SyncCallback { get; set; }

        public static OPENGLwglSwapBuffersHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<OPENGLwglSwapBuffersHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<OPENGLwglSwapBuffersHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<HandleDeviceContext, bool>
                _proc = &Hook_wglSwapBuffers;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool Hook_wglSwapBuffers(HandleDeviceContext hdc)
        {
            if (OPENGLwglSwapBuffersHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(hdc, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(hdc);
            }
            return false;
        }
    }


}
