using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::MultiplyTransform 函数指针 (VTable 索引 46)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_MultiplyTransform_46(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DTRANSFORMSTATETYPE, D3DMATRIX*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, D3DTRANSFORMSTATETYPE, D3DMATRIX*, int>)ptr;

        public const string Name = "MultiplyTransform";

        public int Invoke(COM_PTR_IUNKNOWN pThis, D3DTRANSFORMSTATETYPE State, D3DMATRIX* pMatrix) => _proc(pThis, State, pMatrix);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
