# PowerShell script to generate D3D9 Hook files
# This script generates HookItem classes for all D3D9 device functions

$baseDir = "c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9"
$hookDir = "$baseDir\Hook_Direct3DDevice9"
$ptrFuncDir = "$baseDir\COM_Direct3DDevice9"

# Function names and their types (simplified - you may need to adjust based on actual signatures)
$functions = @(
    @{Name="GetAvailableTextureMem"; Index="4"; ReturnType="uint"},
    @{Name="EvictManagedResources"; Index="5"; ReturnType="int"},
    @{Name="GetDirect3D"; Index="6"; ReturnType="int"},
    @{Name="GetDeviceCaps"; Index="7"; ReturnType="int"},
    @{Name="GetDisplayMode"; Index="8"; ReturnType="int"},
    @{Name="GetCreationParameters"; Index="9"; ReturnType="int"},
    @{Name="SetCursorProperties"; Index="10"; ReturnType="int"},
    @{Name="SetCursorPosition"; Index="11"; ReturnType="int"},
    @{Name="ShowCursor"; Index="12"; ReturnType="int"},
    @{Name="CreateAdditionalSwapChain"; Index="13"; ReturnType="int"},
    @{Name="GetSwapChain"; Index="14"; ReturnType="int"},
    @{Name="GetNumberOfSwapChains"; Index="15"; ReturnType="int"},
    @{Name="Present"; Index="17"; ReturnType="int"},
    @{Name="GetBackBuffer"; Index="18"; ReturnType="int"},
    @{Name="GetRasterStatus"; Index="19"; ReturnType="int"},
    @{Name="SetDialogBoxMode"; Index="20"; ReturnType="int"},
    @{Name="SetGammaRamp"; Index="21"; ReturnType="int"},
    @{Name="GetGammaRamp"; Index="22"; ReturnType="void"},
    @{Name="CreateTexture"; Index="23"; ReturnType="int"},
    @{Name="CreateVolumeTexture"; Index="24"; ReturnType="int"},
    @{Name="CreateCubeTexture"; Index="25"; ReturnType="int"},
    @{Name="CreateVertexBuffer"; Index="26"; ReturnType="int"},
    @{Name="CreateIndexBuffer"; Index="27"; ReturnType="int"},
    @{Name="CreateRenderTarget"; Index="28"; ReturnType="int"},
    @{Name="CreateDepthStencilSurface"; Index="29"; ReturnType="int"},
    @{Name="UpdateSurface"; Index="30"; ReturnType="int"},
    @{Name="UpdateTexture"; Index="31"; ReturnType="int"},
    @{Name="GetRenderTargetData"; Index="32"; ReturnType="int"},
    @{Name="GetFrontBufferData"; Index="33"; ReturnType="int"},
    @{Name="StretchRect"; Index="34"; ReturnType="int"},
    @{Name="ColorFill"; Index="35"; ReturnType="int"},
    @{Name="CreateOffscreenPlainSurface"; Index="36"; ReturnType="int"},
    @{Name="SetRenderTarget"; Index="37"; ReturnType="int"},
    @{Name="GetRenderTarget"; Index="38"; ReturnType="int"},
    @{Name="SetDepthStencilSurface"; Index="39"; ReturnType="int"},
    @{Name="GetDepthStencilSurface"; Index="40"; ReturnType="int"},
    @{Name="BeginScene"; Index="41"; ReturnType="int"},
    @{Name="Clear"; Index="43"; ReturnType="int"},
    @{Name="SetTransform"; Index="44"; ReturnType="int"},
    @{Name="GetTransform"; Index="45"; ReturnType="int"},
    @{Name="MultiplyTransform"; Index="46"; ReturnType="int"},
    @{Name="SetViewport"; Index="47"; ReturnType="int"},
    @{Name="GetViewport"; Index="48"; ReturnType="int"},
    @{Name="SetMaterial"; Index="49"; ReturnType="int"},
    @{Name="GetMaterial"; Index="50"; ReturnType="int"},
    @{Name="SetLight"; Index="51"; ReturnType="int"},
    @{Name="GetLight"; Index="52"; ReturnType="int"},
    @{Name="LightEnable"; Index="53"; ReturnType="int"},
    @{Name="GetLightEnable"; Index="54"; ReturnType="int"},
    @{Name="SetClipPlane"; Index="55"; ReturnType="int"},
    @{Name="GetClipPlane"; Index="56"; ReturnType="int"},
    @{Name="SetRenderState"; Index="57"; ReturnType="int"},
    @{Name="GetRenderState"; Index="58"; ReturnType="int"},
    @{Name="CreateStateBlock"; Index="59"; ReturnType="int"},
    @{Name="BeginStateBlock"; Index="60"; ReturnType="int"},
    @{Name="EndStateBlock"; Index="61"; ReturnType="int"},
    @{Name="SetClipStatus"; Index="62"; ReturnType="int"},
    @{Name="GetClipStatus"; Index="63"; ReturnType="int"},
    @{Name="GetTexture"; Index="64"; ReturnType="int"},
    @{Name="SetTexture"; Index="65"; ReturnType="int"},
    @{Name="GetTextureStageState"; Index="66"; ReturnType="int"},
    @{Name="SetTextureStageState"; Index="67"; ReturnType="int"},
    @{Name="GetSamplerState"; Index="68"; ReturnType="int"},
    @{Name="SetSamplerState"; Index="69"; ReturnType="int"},
    @{Name="ValidateDevice"; Index="70"; ReturnType="int"},
    @{Name="SetPaletteEntries"; Index="71"; ReturnType="int"},
    @{Name="GetPaletteEntries"; Index="72"; ReturnType="int"},
    @{Name="SetCurrentTexturePalette"; Index="73"; ReturnType="int"},
    @{Name="GetCurrentTexturePalette"; Index="74"; ReturnType="int"},
    @{Name="SetScissorRect"; Index="75"; ReturnType="int"},
    @{Name="GetScissorRect"; Index="76"; ReturnType="int"},
    @{Name="SetSoftwareVertexProcessing"; Index="77"; ReturnType="int"},
    @{Name="GetSoftwareVertexProcessing"; Index="78"; ReturnType="int"},
    @{Name="SetNPatchMode"; Index="79"; ReturnType="float"},
    @{Name="GetNPatchMode"; Index="80"; ReturnType="float"},
    @{Name="DrawPrimitive"; Index="81"; ReturnType="int"},
    @{Name="DrawIndexedPrimitive"; Index="82"; ReturnType="int"},
    @{Name="DrawPrimitiveUP"; Index="83"; ReturnType="int"},
    @{Name="DrawIndexedPrimitiveUP"; Index="84"; ReturnType="int"},
    @{Name="ProcessVertices"; Index="85"; ReturnType="int"},
    @{Name="CreateVertexDeclaration"; Index="86"; ReturnType="int"},
    @{Name="SetVertexDeclaration"; Index="87"; ReturnType="int"},
    @{Name="GetVertexDeclaration"; Index="88"; ReturnType="int"},
    @{Name="SetFVF"; Index="89"; ReturnType="int"},
    @{Name="GetFVF"; Index="90"; ReturnType="int"},
    @{Name="CreateVertexShader"; Index="91"; ReturnType="int"},
    @{Name="SetVertexShader"; Index="92"; ReturnType="int"},
    @{Name="GetVertexShader"; Index="93"; ReturnType="int"},
    @{Name="SetVertexShaderConstantF"; Index="94"; ReturnType="int"},
    @{Name="GetVertexShaderConstantF"; Index="95"; ReturnType="int"},
    @{Name="SetVertexShaderConstantI"; Index="96"; ReturnType="int"},
    @{Name="GetVertexShaderConstantI"; Index="97"; ReturnType="int"},
    @{Name="SetVertexShaderConstantB"; Index="98"; ReturnType="int"},
    @{Name="GetVertexShaderConstantB"; Index="99"; ReturnType="int"},
    @{Name="SetStreamSource"; Index="100"; ReturnType="int"},
    @{Name="GetStreamSource"; Index="101"; ReturnType="int"},
    @{Name="SetStreamSourceFreq"; Index="102"; ReturnType="int"},
    @{Name="GetStreamSourceFreq"; Index="103"; ReturnType="int"},
    @{Name="SetIndices"; Index="104"; ReturnType="int"},
    @{Name="GetIndices"; Index="105"; ReturnType="int"},
    @{Name="CreatePixelShader"; Index="106"; ReturnType="int"},
    @{Name="SetPixelShader"; Index="107"; ReturnType="int"},
    @{Name="GetPixelShader"; Index="108"; ReturnType="int"},
    @{Name="SetPixelShaderConstantF"; Index="109"; ReturnType="int"},
    @{Name="GetPixelShaderConstantF"; Index="110"; ReturnType="int"},
    @{Name="SetPixelShaderConstantI"; Index="111"; ReturnType="int"},
    @{Name="GetPixelShaderConstantI"; Index="112"; ReturnType="int"},
    @{Name="SetPixelShaderConstantB"; Index="113"; ReturnType="int"},
    @{Name="GetPixelShaderConstantB"; Index="114"; ReturnType="int"},
    @{Name="DrawRectPatch"; Index="115"; ReturnType="int"},
    @{Name="DrawTriPatch"; Index="116"; ReturnType="int"},
    @{Name="DeletePatch"; Index="117"; ReturnType="int"},
    @{Name="CreateQuery"; Index="118"; ReturnType="int"}
)

# Generate hook files
foreach ($func in $functions) {
    $className = "D3D9$($func.Name)HookItem"
    $ptrFuncName = "Ptr_Func_$($func.Name)_$($func.Index)"
    $fileName = "$className.cs"
    $filePath = Join-Path $hookDir $fileName

    $content = @"
using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.Hook_Direct3DDevice9
{
    internal class $className : HookItem<$ptrFuncName, $ptrFuncName>, IHookItemFactory<$className>
    {
        public const string MethodName = $ptrFuncName.Name;

        public static $className Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<$className>(`$"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<$className>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, $($func.ReturnType)>
                _proc = &Hook_$($func.Name);
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static $($func.ReturnType) Hook_$($func.Name)(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this)
        {
            if (IHookFactory.TryGet<$className>(out var hookItem))
            {
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return default($($func.ReturnType));
        }
    }
}
"@

    Set-Content -Path $filePath -Value $content -Encoding UTF8
    Write-Host "Created: $fileName"
}

Write-Host "Hook generation complete!"
