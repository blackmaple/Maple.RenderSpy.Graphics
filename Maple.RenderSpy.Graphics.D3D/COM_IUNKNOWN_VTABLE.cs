using Maple.UnmanagedExtensions;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly  unsafe struct COM_IUNKNOWN_VTABLE
    {
        public readonly Ptr_Func_QueryInterface QueryInterface;
        public readonly Ptr_Func_AddRef AddRef;
        public readonly Ptr_Func_Release Release;
    }


    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct COM_IUNKNOWN_VTABLE<T> where T:unmanaged
    {
        public readonly COM_IUNKNOWN_VTABLE IUNKNOWN_VTABLE;
        public readonly T INTERFACE_VTABLE;
    }
}