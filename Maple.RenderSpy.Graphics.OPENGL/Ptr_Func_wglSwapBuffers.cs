using Maple.Hook.Abstractions;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;

namespace Maple.RenderSpy.Graphics.OPENGL
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct Ptr_Func_wglSwapBuffers(nint ptr) : IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<HandleDeviceContext, bool> _proc =
           (delegate* unmanaged[Stdcall]<HandleDeviceContext, bool>)ptr;

        public const string Name = "wglSwapBuffers";

        internal bool Invoke(HandleDeviceContext hdc) => _proc(hdc);

        public bool Invoke(nint hdc) => _proc(new HandleDeviceContext(hdc));

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
