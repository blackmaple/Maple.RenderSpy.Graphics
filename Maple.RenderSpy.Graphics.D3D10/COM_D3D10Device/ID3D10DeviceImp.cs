using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Win32.Graphics.Direct3D10;

namespace Maple.RenderSpy.Graphics.D3D10.COM_D3D10Device
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ID3D10DeviceImp
    {
        public readonly static Guid GUID = new("9B7E4C0F-342C-4106-A19F-4F2704F689F0");

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
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, uint, int, uint, void> DrawIndexedInstanced_14;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, uint, uint, void> DrawInstanced_15;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSSetConstantBuffers_16;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> GSSetShader_17;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY, void> IASetPrimitiveTopology_18;
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
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, uint, uint, uint, void*, uint, global::Windows.Win32.Graphics.Direct3D10.D3D10_BOX*, void> CopySubresourceRegion_32;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void*, void> CopyResource_33;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, global::Windows.Win32.Graphics.Direct3D10.D3D10_BOX*, void*, uint, uint, void> UpdateSubresource_34;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, float*, void> ClearRenderTargetView_35;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, float, byte, void> ClearDepthStencilView_36;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, void> GenerateMips_37;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, uint, void*, uint, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, void> ResolveSubresource_38;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSGetConstantBuffers_39;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSGetShaderResources_40;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> PSGetShader_41;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSGetSamplers_42;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> VSGetShader_43;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> PSGetConstantBuffers_44;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> IAGetInputLayout_45;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, uint*, uint*, void> IAGetVertexBuffers_46;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Buffer_unmanaged**, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT*, uint*, void> IAGetIndexBuffer_47;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSGetConstantBuffers_48;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> GSGetShader_49;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D.D3D_PRIMITIVE_TOPOLOGY*, void> IAGetPrimitiveTopology_50;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSGetShaderResources_51;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> VSGetSamplers_52;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Predicate_unmanaged**, global::Windows.Win32.Foundation.BOOL*, void> GetPredication_53;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSGetShaderResources_54;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, global::System.IntPtr*, void> GSGetSamplers_55;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, global::Windows.Win32.Graphics.Direct3D10.ID3D10DepthStencilView_unmanaged**, void> OMGetRenderTargets_56;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.ID3D10BlendState_unmanaged**, float*, uint*, void> OMGetBlendState_57;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.ID3D10DepthStencilState_unmanaged**, uint*, void> OMGetDepthStencilState_58;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, global::System.IntPtr*, uint*, void> SOGetTargets_59;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void**, void> RSGetState_60;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, global::Windows.Win32.Graphics.Direct3D10.D3D10_VIEWPORT*, void> RSGetViewports_61;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, global::Windows.Win32.Foundation.RECT*, void> RSGetScissorRects_62;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, int> GetDeviceRemovedReason_63;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, int> SetExceptionMode_64;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint> GetExceptionMode_65;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, uint*, void*, int> GetPrivateData_66;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, uint, void*, int> SetPrivateData_67;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::System.Guid*, void*, int> SetPrivateDataInterface_68;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void> ClearState_69;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void> Flush_70;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_BUFFER_DESC*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SUBRESOURCE_DATA*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Buffer_unmanaged**, int> CreateBuffer_71;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_TEXTURE1D_DESC*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SUBRESOURCE_DATA*, void**, int> CreateTexture1D_72;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_TEXTURE2D_DESC*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SUBRESOURCE_DATA*, void**, int> CreateTexture2D_73;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_TEXTURE3D_DESC*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SUBRESOURCE_DATA*, void**, int> CreateTexture3D_74;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SHADER_RESOURCE_VIEW_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10ShaderResourceView_unmanaged**, int> CreateShaderResourceView_75;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Direct3D10.D3D10_RENDER_TARGET_VIEW_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10RenderTargetView_unmanaged**, int> CreateRenderTargetView_76;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::Windows.Win32.Graphics.Direct3D10.D3D10_DEPTH_STENCIL_VIEW_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10DepthStencilView_unmanaged**, int> CreateDepthStencilView_77;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_INPUT_ELEMENT_DESC*, uint, void*, nuint, global::Windows.Win32.Graphics.Direct3D10.ID3D10InputLayout_unmanaged**, int> CreateInputLayout_78;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, nuint, global::Windows.Win32.Graphics.Direct3D10.ID3D10VertexShader_unmanaged**, int> CreateVertexShader_79;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, nuint, global::Windows.Win32.Graphics.Direct3D10.ID3D10GeometryShader_unmanaged**, int> CreateGeometryShader_80;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, nuint, global::Windows.Win32.Graphics.Direct3D10.D3D10_SO_DECLARATION_ENTRY*, uint, uint, global::Windows.Win32.Graphics.Direct3D10.ID3D10GeometryShader_unmanaged**, int> CreateGeometryShaderWithStreamOutput_81;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, nuint, global::Windows.Win32.Graphics.Direct3D10.ID3D10PixelShader_unmanaged**, int> CreatePixelShader_82;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_BLEND_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10BlendState_unmanaged**, int> CreateBlendState_83;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_DEPTH_STENCIL_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10DepthStencilState_unmanaged**, int> CreateDepthStencilState_84;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_RASTERIZER_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10RasterizerState_unmanaged**, int> CreateRasterizerState_85;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_SAMPLER_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10SamplerState_unmanaged**, int> CreateSamplerState_86;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_QUERY_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Query_unmanaged**, int> CreateQuery_87;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_QUERY_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Predicate_unmanaged**, int> CreatePredicate_88;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_COUNTER_DESC*, global::Windows.Win32.Graphics.Direct3D10.ID3D10Counter_unmanaged**, int> CreateCounter_89;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, uint*, int> CheckFormatSupport_90;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Dxgi.Common.DXGI_FORMAT, uint, uint*, int> CheckMultisampleQualityLevels_91;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_COUNTER_INFO*, void> CheckCounterInfo_92;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, global::Windows.Win32.Graphics.Direct3D10.D3D10_COUNTER_DESC*, global::Windows.Win32.Graphics.Direct3D10.D3D10_COUNTER_TYPE*, uint*, byte*, uint*, byte*, uint*, byte*, uint*, int> CheckCounter_93;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint> GetCreationFlags_94;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, void*, global::System.Guid*, void**, int> OpenSharedResource_95;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint, uint, void> SetTextFilterSize_96;
    public delegate* unmanaged[MemberFunction]<global::System.Runtime.InteropServices.ComWrappers.ComInterfaceDispatch*, uint*, uint*, void> GetTextFilterSize_97;

    
    */
}
