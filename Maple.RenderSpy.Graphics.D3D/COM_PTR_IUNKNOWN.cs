using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct COM_PTR_IUNKNOWN(nint ptr)
    {
        public UnsafePtr<COM_IUNKNOWN> PTR_IUNKNOWN = new(ptr);

        public COM_PTR_IUNKNOWN(void* ptr) : this(new nint(ptr))
        {
        }

        public readonly ref COM_IUNKNOWN IUNKNOWN => ref PTR_IUNKNOWN.Raw;

        public readonly ref COM_IUNKNOWN_VTABLE VTable => ref IUNKNOWN.VTable;

        public readonly override string ToString()
        {
            return PTR_IUNKNOWN.ToString();
        }
    }



    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct COM_PTR_IUNKNOWN<T>(nint ptr):IDisposable where T : unmanaged
    {
        public UnsafePtr<COM_IUNKNOWN<T>> PTR_IUNKNOWN = new(ptr);

        public COM_PTR_IUNKNOWN(void* ptr) : this(new nint(ptr))
        {
        }

        public static implicit operator COM_PTR_IUNKNOWN(COM_PTR_IUNKNOWN<T> value) => new(value.PTR_IUNKNOWN.Ptr);

        public readonly ref COM_IUNKNOWN<T> IUNKNOWN => ref PTR_IUNKNOWN.Raw;

        public readonly ref COM_IUNKNOWN_VTABLE<T> VTable => ref IUNKNOWN.VTable;
        public readonly COM_IUNKNOWN_VTABLE IUnknown_VTable => VTable.IUnknown_VTable;
        public readonly T Interface_VTable => VTable.Interface_VTable;

        public readonly override string ToString()
        {
            return PTR_IUNKNOWN.ToString();
        }

        public readonly void Dispose()
        {
            this.IUnknown_VTable.Release_2.Invoke(this);
        }
    }

}