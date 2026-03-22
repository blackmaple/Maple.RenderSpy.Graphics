using Maple.Hook.Abstractions;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.OPENGL
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct Ptr_Func_wglSwapBuffers(nint ptr) : IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<nint, bool> _proc =
           (delegate* unmanaged[Stdcall]<nint, bool>)ptr;

        public const string Name = "wglSwapBuffers";

        public bool Invoke(nint hdc) => _proc(hdc);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }


}
