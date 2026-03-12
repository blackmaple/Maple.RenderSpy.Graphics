using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [DebuggerDisplay("{Ptr}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct UnsafePtr<T>(nint ptr) where T : unmanaged
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public nint Ptr = ptr;

        public UnsafePtr(void* ptr) : this(new nint(ptr))
        {
        }


        public static implicit operator nint(UnsafePtr<T> v) => v.Ptr;
        public static implicit operator UnsafePtr<T>(nint v) => new(v);
        public static implicit operator UnsafePtr<T>(void* v) => new(v);
        public static implicit operator bool(UnsafePtr<T> v) => v.Ptr != nint.Zero;

        public readonly ref T RefRaw => ref Unsafe.AsRef<T>(Ptr.ToPointer());
    }

    [DebuggerDisplay("{Ptr}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct UnsafePtr(nint ptr)
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public nint Ptr = ptr;

        public UnsafePtr(void* ptr) : this(new nint(ptr))
        {
        }


        public static implicit operator nint(UnsafePtr v) => v.Ptr;
        public static implicit operator UnsafePtr(nint v) => new(v);
        public static implicit operator UnsafePtr(void* v) => new(v);
        public static implicit operator bool(UnsafePtr v) => v.Ptr != nint.Zero;

        public readonly ref T GetRefRaw<T>() where T : unmanaged => ref Unsafe.AsRef<T>(Ptr.ToPointer());
    }

}