using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_IUNKNOWN
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct PTR_COM_IUNKNOWN
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public nint _ptr = ptr;

    }


    public unsafe struct COM_IUNKNOWN_VTABLE
    {
        public delegate* unmanaged[Stdcall]<COM_IUNKNOWN*, Guid*, void**, uint> QueryInterface;
        public delegate* unmanaged[Stdcall]<COM_IUNKNOWN*, uint> AddRef;
        public delegate* unmanaged[Stdcall]<COM_IUNKNOWN*, uint> Release;
    }



    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct UnSafePtr<T>(nint ptr) where T : unmanaged
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public nint _ptr = ptr;

        public static implicit operator nint(UnSafePtr<T> v) => v._ptr;
        public static implicit operator UnSafePtr<T>(nint v) => new(v);
    }
}