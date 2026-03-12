using System.Runtime.InteropServices;
namespace Maple.RenderSpy.Graphics.D3D
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_IUNKNOWN
    {
        public readonly UnsafePtr<COM_IUNKNOWN_VTABLE> VTable;
    }


    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_IUNKNOWN<T> where T : unmanaged
    {
        public readonly UnsafePtr<COM_IUNKNOWN_VTABLE<T>> VTable;
    }
}