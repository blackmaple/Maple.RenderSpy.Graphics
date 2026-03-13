using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_IUNKNOWN
    {
        public readonly UnsafePtr<COM_IUNKNOWN_VTABLE> VTablePointer;

        public readonly ref COM_IUNKNOWN_VTABLE VTable => ref VTablePointer.Raw;
    }


    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_IUNKNOWN<T> where T : unmanaged
    {
        public readonly UnsafePtr<COM_IUNKNOWN_VTABLE<T>> Ptr_VTable;

        public readonly ref COM_IUNKNOWN_VTABLE<T> VTable => ref Ptr_VTable.Raw;
        public readonly COM_IUNKNOWN_VTABLE IUnknown_VTable => VTable.IUnknown_VTable;
        public readonly T Interface_VTable => VTable.Interface_VTable;

        public static implicit operator COM_IUNKNOWN(COM_IUNKNOWN<T> value)
        {
            return Unsafe.As<COM_IUNKNOWN<T>, COM_IUNKNOWN>(ref value);
        }
    }
}