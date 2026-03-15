using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::LightEnable 函数指针 (VTable 索引 53)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_LightEnable_53(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, int, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, int, int>)ptr;

        public const string Name = "LightEnable";

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Index, int Enable) => _proc(pThis, Index, Enable);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
