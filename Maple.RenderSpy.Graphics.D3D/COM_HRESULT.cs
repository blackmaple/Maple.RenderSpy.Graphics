using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
namespace Maple.RenderSpy.Graphics.D3D
{

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct COM_HRESULT(uint v)
    {
        public const uint S_OK = 0U;
       

        [MarshalAs(UnmanagedType.U4)]
        public readonly uint Value = v;

        public static implicit operator uint(COM_HRESULT v) => v.Value;
        public static implicit operator COM_HRESULT(uint v) => new(v);
        public static implicit operator bool(COM_HRESULT v) => v.Value == S_OK;

        public override string ToString()
        {
            return Value.ToString("X8");
        }
    }
}