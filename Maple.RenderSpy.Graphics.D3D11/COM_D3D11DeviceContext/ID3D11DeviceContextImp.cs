using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct ID3D11DeviceContextImp
    {
        public readonly static Guid GUID = new("C0BFA96C-E089-44FB-8EAF-26F8796190DA");
    }
}
