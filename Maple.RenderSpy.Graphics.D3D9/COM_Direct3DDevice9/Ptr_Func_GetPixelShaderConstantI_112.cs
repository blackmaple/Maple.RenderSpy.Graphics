using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取像素着色器整数常量
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetPixelShaderConstantI_112(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>)ptr;

        public const string Name = "GetPixelShaderConstantI";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<int> pConstantData, uint Vector4iCount) => _proc(pThis, StartRegister, pConstantData, Vector4iCount);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
