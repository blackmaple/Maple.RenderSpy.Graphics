using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Maple.RenderSpy.Graphics.D3D9
{



    [GeneratedComInterface]
    [Guid("00000000-0000-0000-C000-000000000046")]
    internal partial interface IUnknown
    {
        uint QueryInterface(in Guid riid, out IntPtr ppvObject);
        uint AddRef();
        uint Release();


      
    }


    [GeneratedComInterface]
    [Guid("81bdcbca-64d4-426d-ae8d-ad0147f4275c")]
    internal partial interface IDirect3D9 : IUnknown
    {

        uint RegisterSoftwareDevice(nint pInitializeFunction);
        uint GetAdapterCount();
        uint GetAdapterIdentifier(uint Adapter, uint Flags, out D3DADAPTER_IDENTIFIER9 pIdentifier);
        uint GetAdapterModeCount(uint Adapter, D3DFORMAT Format);
        uint EnumAdapterModes(uint Adapter, D3DFORMAT Format, uint Mode, out D3DDISPLAYMODE pMode);
        uint GetAdapterDisplayMode(uint Adapter, out D3DDISPLAYMODE pMode);
        uint CheckDeviceType(uint Adapter, D3DDEVTYPE DevType, D3DFORMAT AdapterFormat, D3DFORMAT BackBufferFormat, uint bWindowed);
        uint CheckDeviceFormat(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, uint Usage, D3DRESOURCETYPE RType, D3DFORMAT CheckFormat);
        uint CheckDeviceMultiSampleType(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SurfaceFormat, uint Windowed, D3DMULTISAMPLE_TYPE MultiSampleType, out uint pQualityLevels);
        uint CheckDepthStencilMatch(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, D3DFORMAT RenderTargetFormat, D3DFORMAT DepthStencilFormat);
        uint CheckDeviceFormatConversion(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SourceFormat, D3DFORMAT TargetFormat);
        uint GetDeviceCaps(uint Adapter, D3DDEVTYPE DevType, out D3DCAPS9 pCaps);
        nint GetAdapterMonitor(uint Adapter);
        uint CreateDevice(uint Adapter, D3DDEVTYPE DeviceType, nint hFocusWindow, uint BehaviorFlags, ref D3DPRESENT_PARAMETERS pPresentationParameters, out IDirect3DDevice9 ppReturnedDeviceInterface);
    }



    [GeneratedComInterface]
    [Guid("d0223b96-bf7a-43fd-92bd-a43b0d82b9eb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal partial interface IDirect3DDevice9 : IUnknown
    {
        // IUnknown 方法
          void QueryInterface(ref Guid riid, out nint ppvObject);
        new uint AddRef();
        new uint Release();

        // 基本方法
        uint TestCooperativeLevel();
        uint GetAvailableTextureMem();
        uint EvictManagedResources();
        uint GetDirect3D(out IDirect3D9 ppD3D9);
        uint GetDeviceCaps(out D3DCAPS9 pCaps);
        uint GetDisplayMode(uint iSwapChain, out D3DDISPLAYMODE pMode);
        uint GetCreationParameters(out D3DDEVICE_CREATION_PARAMETERS pParameters);
        uint SetCursorProperties(uint XHotSpot, uint YHotSpot, IDirect3DSurface9 pCursorBitmap);
        void SetCursorPosition(int X, int Y, uint Flags);
        uint ShowCursor(uint bShow);
        uint CreateAdditionalSwapChain(ref D3DPRESENT_PARAMETERS pPresentationParameters, out IDirect3DSwapChain9 pSwapChain);
        uint GetSwapChain(uint iSwapChain, out IDirect3DSwapChain9 pSwapChain);
        uint GetNumberOfSwapChannels(out uint pCount);
        uint Reset(ref D3DPRESENT_PARAMETERS pPresentationParameters);
        uint Present(ref RECT pSourceRect, ref RECT pDestRect, nint hDestWindowOverride, ref RGNDATA pDirtyRegion);
        uint GetBackBuffer(uint iSwapChain, uint iBackBuffer, D3DBACKBUFFER_TYPE Type, out IDirect3DSurface9 ppBackBuffer);
        uint GetRasterStatus(uint iSwapChain, out D3DRASTER_STATUS pRasterStatus);
        uint SetDialogBoxMode(uint bEnableDialogs);
        void SetGammaRamp(uint iSwapChain, uint Flags, ref D3DGAMMARAMP pRamp);
        void GetGammaRamp(uint iSwapChain, out D3DGAMMARAMP pRamp);

        // 创建方法
        uint CreateTexture(uint Width, uint Height, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, out IDirect3DTexture9 ppTexture, nint pSharedHandle);
        uint CreateVolumeTexture(uint Width, uint Height, uint Depth, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, out IDirect3DVolumeTexture9 ppVolumeTexture, nint pSharedHandle);
        uint CreateCubeTexture(uint EdgeLength, uint Levels, uint Usage, D3DFORMAT Format, D3DPOOL Pool, out IDirect3DCubeTexture9 ppCubeTexture, nint pSharedHandle);
        uint CreateVertexBuffer(uint Length, uint Usage, uint FVF, D3DPOOL Pool, out IDirect3DVertexBuffer9 ppVertexBuffer, nint pSharedHandle);
        uint CreateIndexBuffer(uint Length, uint Usage, D3DFORMAT Format, D3DPOOL Pool, out IDirect3DIndexBuffer9 ppIndexBuffer, nint pSharedHandle);
        uint CreateRenderTarget(uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, uint Lockable, out IDirect3DSurface9 ppSurface, nint pSharedHandle);
        uint CreateDepthStencilSurface(uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, uint Discard, out IDirect3DSurface9 ppSurface, nint pSharedHandle);
        uint UpdateSurface(IDirect3DSurface9 pSourceSurface, ref RECT pSourceRect, IDirect3DSurface9 pDestinationSurface, ref POINT pDestPoint);
        uint UpdateTexture(IDirect3DBaseTexture9 pSourceTexture, IDirect3DBaseTexture9 pDestinationTexture);

        // 渲染状态方法
        uint GetRenderTarget(uint RenderTargetIndex, out IDirect3DSurface9 ppRenderTarget);
        uint SetRenderTarget(uint RenderTargetIndex, IDirect3DSurface9 pRenderTarget);
        uint GetDepthStencilSurface(out IDirect3DSurface9 ppZStencilSurface);
        uint SetDepthStencilSurface(IDirect3DSurface9 pNewZStencil);
        uint BeginScene();
        uint EndScene();  // 您要求的 EndScene 方法
        uint Clear(uint Count, [In] uint[] pRects, uint Flags, uint Color, float Z, uint Stencil);
        uint SetTransform(D3DTRANSFORMSTATETYPE State, ref D3DMATRIX pMatrix);
        uint GetTransform(D3DTRANSFORMSTATETYPE State, out D3DMATRIX pMatrix);
        uint MultiplyTransform(D3DTRANSFORMSTATETYPE State, ref D3DMATRIX pMatrix);
        uint SetViewport(ref D3DVIEWPORT9 pViewport);
        uint GetViewport(out D3DVIEWPORT9 pViewport);
        uint SetMaterial(ref D3DMATERIAL9 pMaterial);
        uint GetMaterial(out D3DMATERIAL9 pMaterial);
        uint SetLight(uint Index, ref D3DLIGHT9 pLight);
        uint GetLight(uint Index, out D3DLIGHT9 pLight);
        uint LightEnable(uint Index, uint Enable);
        uint GetLightEnable(uint Index, out uint pEnable);
        uint SetClipPlane(uint Index, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] pPlane);
        uint GetClipPlane(uint Index, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] pPlane);
        uint SetRenderState(D3DRENDERSTATETYPE State, uint Value);
        uint GetRenderState(D3DRENDERSTATETYPE State, out uint pValue);
        uint CreateStateBlock(D3DSTATEBLOCKTYPE Type, out IDirect3DStateBlock9 ppSB);
        uint BeginStateBlock();
        uint EndStateBlock(out IDirect3DStateBlock9 ppSB);

        // 纹理状态方法
        uint SetTexture(uint Sampler, IDirect3DBaseTexture9 pTexture);
        uint GetTexture(uint Sampler, out IDirect3DBaseTexture9 ppTexture);
        uint SetTextureStageState(uint Stage, D3DTEXTURESTAGESTATETYPE Type, uint Value);
        uint GetTextureStageState(uint Stage, D3DTEXTURESTAGESTATETYPE Type, out uint pValue);
        uint SetSamplerState(uint Sampler, D3DSAMPLERSTATETYPE Type, uint Value);
        uint GetSamplerState(uint Sampler, D3DSAMPLERSTATETYPE Type, out uint pValue);

        // 顶点缓冲区方法
        uint ValidateDevice(out uint pNumPasses);
        uint SetPaletteEntries(uint PaletteNumber, [In] uint[] pEntries);
        uint GetPaletteEntries(uint PaletteNumber, out uint pEntries);
        uint SetCurrentTexturePalette(uint PaletteNumber);
        uint GetCurrentTexturePalette(out uint PaletteNumber);
        uint SetScissorRect(ref RECT pRect);
        uint GetScissorRect(out RECT pRect);
        uint SetSoftwareVertexProcessing(uint bSoftware);
        uint GetSoftwareVertexProcessing();
        uint SetNPatchMode(float nSegments);
        float GetNPatchMode();
        uint DrawPrimitive(D3DPRIMITIVETYPE PrimitiveType, uint StartVertex, uint PrimitiveCount);
        uint DrawIndexedPrimitive(D3DPRIMITIVETYPE PrimitiveType, int BaseVertexIndex, uint MinVertexIndex, uint NumVertices, uint StartIndex, uint PrimitiveCount);
        uint DrawPrimitiveUP(D3DPRIMITIVETYPE PrimitiveType, uint PrimitiveCount, nint pVertexStreamZeroData, uint VertexStreamZeroStride);
        uint DrawIndexedPrimitiveUP(D3DPRIMITIVETYPE PrimitiveType, uint MinVertexIndex, uint NumVertices, uint PrimitiveCount, nint pIndexData, D3DFORMAT IndexDataFormat, nint pVertexStreamZeroData, uint VertexStreamZeroStride);
        uint ProcessVertices(uint SrcStartIndex, uint DestIndex, uint VertexCount, IDirect3DVertexBuffer9 pDestBuffer, IDirect3DVertexDeclaration9 pVertexDecl, uint Flags);
        uint CreateVertexDeclaration([In] uint[] pVertexElements, out IDirect3DVertexDeclaration9 ppDecl);
        uint SetVertexDeclaration(IDirect3DVertexDeclaration9 pDecl);
        uint GetVertexDeclaration(out IDirect3DVertexDeclaration9 ppDecl);
        uint SetFVF(uint FVF);
        uint GetFVF(out uint pFVF);
        uint CreateVertexShader([In] uint[] pFunction, out IDirect3DVertexShader9 ppShader);
        uint SetVertexShader(IDirect3DVertexShader9 pShader);
        uint GetVertexShader(out IDirect3DVertexShader9 ppShader);
        uint SetVertexShaderConstantF(uint StartRegister, [In] float[] pConstantData, uint Vector4fCount);
        uint GetVertexShaderConstantF(uint StartRegister, [Out] float[] pConstantData, uint Vector4fCount);
        uint SetVertexShaderConstantI(uint StartRegister, [In] int[] pConstantData, uint Vector4iCount);
        uint GetVertexShaderConstantI(uint StartRegister, [Out] int[] pConstantData, uint Vector4iCount);
        uint SetVertexShaderConstantB(uint StartRegister, [In] uint[] pConstantData, uint BoolCount);
        uint GetVertexShaderConstantB(uint StartRegister, [Out] uint[] pConstantData, uint BoolCount);
        uint SetStreamSource(uint StreamNumber, IDirect3DVertexBuffer9 pStreamData, uint OffsetInBytes, uint Stride);
        uint GetStreamSource(uint StreamNumber, out IDirect3DVertexBuffer9 ppStreamData, out uint pOffsetInBytes, out uint pStride);
        uint SetStreamSourceFreq(uint StreamNumber, uint Setting);
        uint GetStreamSourceFreq(uint StreamNumber, out uint pSetting);
        uint SetIndices(IDirect3DIndexBuffer9 pIndexData);
        uint GetIndices(out IDirect3DIndexBuffer9 ppIndexData);

        // 像素着色器方法
        uint CreatePixelShader([In] uint[] pFunction, out IDirect3DPixelShader9 ppShader);
        uint SetPixelShader(IDirect3DPixelShader9 pShader);
        uint GetPixelShader(out IDirect3DPixelShader9 ppShader);
        uint SetPixelShaderConstantF(uint StartRegister, [In] float[] pConstantData, uint Vector4fCount);
        uint GetPixelShaderConstantF(uint StartRegister, [Out] float[] pConstantData, uint Vector4fCount);
        uint SetPixelShaderConstantI(uint StartRegister, [In] int[] pConstantData, uint Vector4iCount);
        uint GetPixelShaderConstantI(uint StartRegister, [Out] int[] pConstantData, uint Vector4iCount);
        uint SetPixelShaderConstantB(uint StartRegister, [In] uint[] pConstantData, uint BoolCount);
        uint GetPixelShaderConstantB(uint StartRegister, [Out] uint[] pConstantData, uint BoolCount);

        // 查询方法
        uint CreateQuery(D3DQUERYTYPE Type, out IDirect3DQuery9 ppQuery);
        uint SetClipStatus(ref D3DCLIPSTATUS9 pClipStatus);
        uint GetClipStatus(out D3DCLIPSTATUS9 pClipStatus);
        uint GetTextureStageState(uint Stage, D3DTEXTURESTAGESTATETYPE Type, out uint pValue);
    }

}
