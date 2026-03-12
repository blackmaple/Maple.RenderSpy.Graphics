using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [DebuggerDisplay("{Ptr}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Ptr_Func_Release(nint ptr)
    {
        public readonly delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, COM_HRESULT> Ptr
            = (delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, COM_HRESULT>)ptr;

        public readonly COM_HRESULT Invoke(UnsafePtr<COM_IUNKNOWN> @this)
        {
            return Ptr(@this);
        }
    }

}