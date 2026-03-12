using Maple.UnmanagedExtensions;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{

    [DebuggerDisplay("{Ptr}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Ptr_Func_QueryInterface(nint ptr)
    {
        public readonly delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, UnsafeIn<Guid>, UnsafeOut<UnsafePtr<COM_INTERFACE>>, COM_HRESULT> Ptr
            = (delegate* unmanaged[Stdcall]<UnsafePtr<COM_IUNKNOWN>, UnsafeIn<Guid>, UnsafeOut<UnsafePtr<COM_INTERFACE>>, COM_HRESULT>)ptr;

        public readonly COM_HRESULT Invoke(UnsafePtr<COM_IUNKNOWN> @this, in Guid riid, out UnsafePtr<COM_INTERFACE> ppvObject)
        {
            return Ptr(@this, UnsafeIn<Guid>.FromIn(in riid), UnsafeOut<UnsafePtr<COM_INTERFACE>>.FromOut(out ppvObject));
        }
    }

}