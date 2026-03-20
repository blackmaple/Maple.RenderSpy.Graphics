using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D.TempWindow;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9
{
    internal partial class D3D9FunctionsProvider()
        : IRenderSpyGraphicsFunctionsProvider
    {
        public Dictionary<string, nint> Functions { get; } = [];

        public static IRenderSpyGraphicsFunctionsProvider Create(D3DTempWindowFactory tempWindowFactory)
        {
            using var ptr_com = Direct3DCreate9(PInvoke.D3D_SDK_VERSION);
            using var frm = tempWindowFactory.Create();
            HWND hWnd = new(frm.Handle);
            var createStatus = ptr_com.Interface_VTable.CreateDevice_16.Invoke(ptr_com,
                        PInvoke.D3DADAPTER_DEFAULT,
                    D3DDEVTYPE.D3DDEVTYPE_NULLREF,
                    hWnd,
                    PInvoke.D3DCREATE_SOFTWARE_VERTEXPROCESSING | PInvoke.D3DCREATE_DISABLE_DRIVER_MANAGEMENT,
                    new D3DPRESENT_PARAMETERS()
                    {
                        BackBufferWidth = 0,
                        BackBufferHeight = 0,
                        BackBufferFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                        BackBufferCount = 0,
                        MultiSampleType = D3DMULTISAMPLE_TYPE.D3DMULTISAMPLE_NONE,
                        SwapEffect = D3DSWAPEFFECT.D3DSWAPEFFECT_DISCARD,
                        hDeviceWindow = hWnd,
                        Windowed = true,
                        EnableAutoDepthStencil = false,
                        AutoDepthStencilFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                        FullScreen_RefreshRateInHz = 0,

                    },
                    out var ppReturnedDeviceInterface
                    );
            if (createStatus == false)
            {
                return RenderSpyGraphicsException.Throw<IRenderSpyGraphicsFunctionsProvider>($"ERROR {nameof(Ptr_Func_CreateDevice_16)}");
            }
            using (ppReturnedDeviceInterface)
            {
                IRenderSpyGraphicsFunctionsProvider functionsProvider = new D3D9FunctionsProvider();

                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_TestCooperativeLevel_3.Name, ppReturnedDeviceInterface.Interface_VTable.TestCooperativeLevel_3.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetAvailableTextureMem_4.Name, ppReturnedDeviceInterface.Interface_VTable.GetAvailableTextureMem_4.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_EvictManagedResources_5.Name, ppReturnedDeviceInterface.Interface_VTable.EvictManagedResources_5.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetDirect3D_6.Name, ppReturnedDeviceInterface.Interface_VTable.GetDirect3D_6.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetDeviceCaps_7.Name, ppReturnedDeviceInterface.Interface_VTable.GetDeviceCaps_7.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetDisplayMode_8.Name, ppReturnedDeviceInterface.Interface_VTable.GetDisplayMode_8.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetCreationParameters_9.Name, ppReturnedDeviceInterface.Interface_VTable.GetCreationParameters_9.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetCursorProperties_10.Name, ppReturnedDeviceInterface.Interface_VTable.SetCursorProperties_10.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetCursorPosition_11.Name, ppReturnedDeviceInterface.Interface_VTable.SetCursorPosition_11.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_ShowCursor_12.Name, ppReturnedDeviceInterface.Interface_VTable.ShowCursor_12.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateAdditionalSwapChain_13.Name, ppReturnedDeviceInterface.Interface_VTable.CreateAdditionalSwapChain_13.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetSwapChain_14.Name, ppReturnedDeviceInterface.Interface_VTable.GetSwapChain_14.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetNumberOfSwapChains_15.Name, ppReturnedDeviceInterface.Interface_VTable.GetNumberOfSwapChains_15.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_Reset_16.Name, ppReturnedDeviceInterface.Interface_VTable.Reset_16.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_Present_17.Name, ppReturnedDeviceInterface.Interface_VTable.Present_17.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetBackBuffer_18.Name, ppReturnedDeviceInterface.Interface_VTable.GetBackBuffer_18.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetRasterStatus_19.Name, ppReturnedDeviceInterface.Interface_VTable.GetRasterStatus_19.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetDialogBoxMode_20.Name, ppReturnedDeviceInterface.Interface_VTable.SetDialogBoxMode_20.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetGammaRamp_21.Name, ppReturnedDeviceInterface.Interface_VTable.SetGammaRamp_21.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetGammaRamp_22.Name, ppReturnedDeviceInterface.Interface_VTable.GetGammaRamp_22.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateTexture_23.Name, ppReturnedDeviceInterface.Interface_VTable.CreateTexture_23.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateVolumeTexture_24.Name, ppReturnedDeviceInterface.Interface_VTable.CreateVolumeTexture_24.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateCubeTexture_25.Name, ppReturnedDeviceInterface.Interface_VTable.CreateCubeTexture_25.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateVertexBuffer_26.Name, ppReturnedDeviceInterface.Interface_VTable.CreateVertexBuffer_26.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateIndexBuffer_27.Name, ppReturnedDeviceInterface.Interface_VTable.CreateIndexBuffer_27.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateRenderTarget_28.Name, ppReturnedDeviceInterface.Interface_VTable.CreateRenderTarget_28.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateDepthStencilSurface_29.Name, ppReturnedDeviceInterface.Interface_VTable.CreateDepthStencilSurface_29.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_UpdateSurface_30.Name, ppReturnedDeviceInterface.Interface_VTable.UpdateSurface_30.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_UpdateTexture_31.Name, ppReturnedDeviceInterface.Interface_VTable.UpdateTexture_31.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetRenderTargetData_32.Name, ppReturnedDeviceInterface.Interface_VTable.GetRenderTargetData_32.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetFrontBufferData_33.Name, ppReturnedDeviceInterface.Interface_VTable.GetFrontBufferData_33.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_StretchRect_34.Name, ppReturnedDeviceInterface.Interface_VTable.StretchRect_34.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_ColorFill_35.Name, ppReturnedDeviceInterface.Interface_VTable.ColorFill_35.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateOffscreenPlainSurface_36.Name, ppReturnedDeviceInterface.Interface_VTable.CreateOffscreenPlainSurface_36.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetRenderTarget_37.Name, ppReturnedDeviceInterface.Interface_VTable.SetRenderTarget_37.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetRenderTarget_38.Name, ppReturnedDeviceInterface.Interface_VTable.GetRenderTarget_38.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetDepthStencilSurface_39.Name, ppReturnedDeviceInterface.Interface_VTable.SetDepthStencilSurface_39.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetDepthStencilSurface_40.Name, ppReturnedDeviceInterface.Interface_VTable.GetDepthStencilSurface_40.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_BeginScene_41.Name, ppReturnedDeviceInterface.Interface_VTable.BeginScene_41.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_EndScene_42.Name, ppReturnedDeviceInterface.Interface_VTable.EndScene_42.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_Clear_43.Name, ppReturnedDeviceInterface.Interface_VTable.Clear_43.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetTransform_44.Name, ppReturnedDeviceInterface.Interface_VTable.SetTransform_44.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetTransform_45.Name, ppReturnedDeviceInterface.Interface_VTable.GetTransform_45.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_MultiplyTransform_46.Name, ppReturnedDeviceInterface.Interface_VTable.MultiplyTransform_46.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetViewport_47.Name, ppReturnedDeviceInterface.Interface_VTable.SetViewport_47.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetViewport_48.Name, ppReturnedDeviceInterface.Interface_VTable.GetViewport_48.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetMaterial_49.Name, ppReturnedDeviceInterface.Interface_VTable.SetMaterial_49.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetMaterial_50.Name, ppReturnedDeviceInterface.Interface_VTable.GetMaterial_50.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetLight_51.Name, ppReturnedDeviceInterface.Interface_VTable.SetLight_51.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetLight_52.Name, ppReturnedDeviceInterface.Interface_VTable.GetLight_52.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_LightEnable_53.Name, ppReturnedDeviceInterface.Interface_VTable.LightEnable_53.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetLightEnable_54.Name, ppReturnedDeviceInterface.Interface_VTable.GetLightEnable_54.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetClipPlane_55.Name, ppReturnedDeviceInterface.Interface_VTable.SetClipPlane_55.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetClipPlane_56.Name, ppReturnedDeviceInterface.Interface_VTable.GetClipPlane_56.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetRenderState_57.Name, ppReturnedDeviceInterface.Interface_VTable.SetRenderState_57.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetRenderState_58.Name, ppReturnedDeviceInterface.Interface_VTable.GetRenderState_58.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateStateBlock_59.Name, ppReturnedDeviceInterface.Interface_VTable.CreateStateBlock_59.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_BeginStateBlock_60.Name, ppReturnedDeviceInterface.Interface_VTable.BeginStateBlock_60.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_EndStateBlock_61.Name, ppReturnedDeviceInterface.Interface_VTable.EndStateBlock_61.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetClipStatus_62.Name, ppReturnedDeviceInterface.Interface_VTable.SetClipStatus_62.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetClipStatus_63.Name, ppReturnedDeviceInterface.Interface_VTable.GetClipStatus_63.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetTexture_64.Name, ppReturnedDeviceInterface.Interface_VTable.GetTexture_64.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetTexture_65.Name, ppReturnedDeviceInterface.Interface_VTable.SetTexture_65.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetTextureStageState_66.Name, ppReturnedDeviceInterface.Interface_VTable.GetTextureStageState_66.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetTextureStageState_67.Name, ppReturnedDeviceInterface.Interface_VTable.SetTextureStageState_67.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetSamplerState_68.Name, ppReturnedDeviceInterface.Interface_VTable.GetSamplerState_68.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetSamplerState_69.Name, ppReturnedDeviceInterface.Interface_VTable.SetSamplerState_69.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_ValidateDevice_70.Name, ppReturnedDeviceInterface.Interface_VTable.ValidateDevice_70.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetPaletteEntries_71.Name, ppReturnedDeviceInterface.Interface_VTable.SetPaletteEntries_71.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetPaletteEntries_72.Name, ppReturnedDeviceInterface.Interface_VTable.GetPaletteEntries_72.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetCurrentTexturePalette_73.Name, ppReturnedDeviceInterface.Interface_VTable.SetCurrentTexturePalette_73.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetCurrentTexturePalette_74.Name, ppReturnedDeviceInterface.Interface_VTable.GetCurrentTexturePalette_74.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetScissorRect_75.Name, ppReturnedDeviceInterface.Interface_VTable.SetScissorRect_75.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetScissorRect_76.Name, ppReturnedDeviceInterface.Interface_VTable.GetScissorRect_76.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetSoftwareVertexProcessing_77.Name, ppReturnedDeviceInterface.Interface_VTable.SetSoftwareVertexProcessing_77.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetSoftwareVertexProcessing_78.Name, ppReturnedDeviceInterface.Interface_VTable.GetSoftwareVertexProcessing_78.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetNPatchMode_79.Name, ppReturnedDeviceInterface.Interface_VTable.SetNPatchMode_79.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetNPatchMode_80.Name, ppReturnedDeviceInterface.Interface_VTable.GetNPatchMode_80.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawPrimitive_81.Name, ppReturnedDeviceInterface.Interface_VTable.DrawPrimitive_81.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawIndexedPrimitive_82.Name, ppReturnedDeviceInterface.Interface_VTable.DrawIndexedPrimitive_82.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawPrimitiveUP_83.Name, ppReturnedDeviceInterface.Interface_VTable.DrawPrimitiveUP_83.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawIndexedPrimitiveUP_84.Name, ppReturnedDeviceInterface.Interface_VTable.DrawIndexedPrimitiveUP_84.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_ProcessVertices_85.Name, ppReturnedDeviceInterface.Interface_VTable.ProcessVertices_85.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateVertexDeclaration_86.Name, ppReturnedDeviceInterface.Interface_VTable.CreateVertexDeclaration_86.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetVertexDeclaration_87.Name, ppReturnedDeviceInterface.Interface_VTable.SetVertexDeclaration_87.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetVertexDeclaration_88.Name, ppReturnedDeviceInterface.Interface_VTable.GetVertexDeclaration_88.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetFVF_89.Name, ppReturnedDeviceInterface.Interface_VTable.SetFVF_89.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetFVF_90.Name, ppReturnedDeviceInterface.Interface_VTable.GetFVF_90.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateVertexShader_91.Name, ppReturnedDeviceInterface.Interface_VTable.CreateVertexShader_91.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetVertexShader_92.Name, ppReturnedDeviceInterface.Interface_VTable.SetVertexShader_92.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetVertexShader_93.Name, ppReturnedDeviceInterface.Interface_VTable.GetVertexShader_93.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetVertexShaderConstantF_94.Name, ppReturnedDeviceInterface.Interface_VTable.SetVertexShaderConstantF_94.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetVertexShaderConstantF_95.Name, ppReturnedDeviceInterface.Interface_VTable.GetVertexShaderConstantF_95.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetVertexShaderConstantI_96.Name, ppReturnedDeviceInterface.Interface_VTable.SetVertexShaderConstantI_96.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetVertexShaderConstantI_97.Name, ppReturnedDeviceInterface.Interface_VTable.GetVertexShaderConstantI_97.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetVertexShaderConstantB_98.Name, ppReturnedDeviceInterface.Interface_VTable.SetVertexShaderConstantB_98.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetVertexShaderConstantB_99.Name, ppReturnedDeviceInterface.Interface_VTable.GetVertexShaderConstantB_99.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetStreamSource_100.Name, ppReturnedDeviceInterface.Interface_VTable.SetStreamSource_100.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetStreamSource_101.Name, ppReturnedDeviceInterface.Interface_VTable.GetStreamSource_101.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetStreamSourceFreq_102.Name, ppReturnedDeviceInterface.Interface_VTable.SetStreamSourceFreq_102.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetStreamSourceFreq_103.Name, ppReturnedDeviceInterface.Interface_VTable.GetStreamSourceFreq_103.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetIndices_104.Name, ppReturnedDeviceInterface.Interface_VTable.SetIndices_104.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetIndices_105.Name, ppReturnedDeviceInterface.Interface_VTable.GetIndices_105.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreatePixelShader_106.Name, ppReturnedDeviceInterface.Interface_VTable.CreatePixelShader_106.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetPixelShader_107.Name, ppReturnedDeviceInterface.Interface_VTable.SetPixelShader_107.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetPixelShader_108.Name, ppReturnedDeviceInterface.Interface_VTable.GetPixelShader_108.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetPixelShaderConstantF_109.Name, ppReturnedDeviceInterface.Interface_VTable.SetPixelShaderConstantF_109.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetPixelShaderConstantF_110.Name, ppReturnedDeviceInterface.Interface_VTable.GetPixelShaderConstantF_110.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetPixelShaderConstantI_111.Name, ppReturnedDeviceInterface.Interface_VTable.SetPixelShaderConstantI_111.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetPixelShaderConstantI_112.Name, ppReturnedDeviceInterface.Interface_VTable.GetPixelShaderConstantI_112.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_SetPixelShaderConstantB_113.Name, ppReturnedDeviceInterface.Interface_VTable.SetPixelShaderConstantB_113.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_GetPixelShaderConstantB_114.Name, ppReturnedDeviceInterface.Interface_VTable.GetPixelShaderConstantB_114.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawRectPatch_115.Name, ppReturnedDeviceInterface.Interface_VTable.DrawRectPatch_115.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DrawTriPatch_116.Name, ppReturnedDeviceInterface.Interface_VTable.DrawTriPatch_116.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_DeletePatch_117.Name, ppReturnedDeviceInterface.Interface_VTable.DeletePatch_117.PtrMethod);
                functionsProvider.TryAddGraphicsFunctions(Ptr_Func_CreateQuery_118.Name, ppReturnedDeviceInterface.Interface_VTable.CreateQuery_118.PtrMethod);

                return functionsProvider;
            }
        }







        const string LibraryName = "d3d9.dll";
        const string EntryPoint = "Direct3DCreate9";


        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [LibraryImport(LibraryName, EntryPoint = EntryPoint)]
        internal static partial COM_PTR_IUNKNOWN<Direct3D9Imp> Direct3DCreate9(uint SDKVersion);

    }
}
