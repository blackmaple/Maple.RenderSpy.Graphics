using System;
using System.Collections.Generic;
using System.Text;

namespace Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device
{
    public readonly struct ID3D11DeviceImp
    {
    }
    /*
        public delegate* unmanaged[MemberFunction]<void*, global::System.Guid*, void**, int> QueryInterface_0;
    public delegate* unmanaged[MemberFunction]<void*, uint> AddRef_1;
    public delegate* unmanaged[MemberFunction]<void*, uint> Release_2;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSSetConstantBuffers_3;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSSetShaderResources_4;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> PSSetShader_5;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSSetSamplers_6;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> VSSetShader_7;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, int, void> DrawIndexed_8;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, void> Draw_9;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSSetConstantBuffers_10;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> IASetInputLayout_11;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, uint*, uint*, void> IASetVertexBuffers_12;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, uint, void> IASetIndexBuffer_13;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, int, uint, void> DrawIndexedInstanced_14;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, uint, uint, void> DrawInstanced_15;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSSetConstantBuffers_16;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> GSSetShader_17;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY, void> IASetPrimitiveTopology_18;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSSetShaderResources_19;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSSetSamplers_20;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, int, void> SetPredication_21;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSSetShaderResources_22;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSSetSamplers_23;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, void*, void> OMSetRenderTargets_24;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, float*, uint, void> OMSetBlendState_25;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, void> OMSetDepthStencilState_26;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, uint*, void> SOSetTargets_27;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void> DrawAuto_28;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> RSSetState_29;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Graphics.Direct3D10.D3D10_VIEWPORT*, void> RSSetViewports_30;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::Windows.Win32.Foundation.RECT*, void> RSSetScissorRects_31;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void*, void> CopyResource_33;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, global::Windows.Win32.Graphics.Direct3D10.D3D10_BOX*, void*, uint, uint, void> UpdateSubresource_34;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, float*, void> ClearRenderTargetView_35;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, float, byte, void> ClearDepthStencilView_36;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> GenerateMips_37;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, void*, uint, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, void> ResolveSubresource_38;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSGetConstantBuffers_39;
     */
}
