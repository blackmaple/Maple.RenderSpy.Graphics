using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetTextureStageStateHookItem : HookItem<D3D9GetTextureStageStateHookItem, Ptr_Func_GetTextureStageState_66, Ptr_Func_GetTextureStageState_66>, IGraphicsHookItem<D3D9GetTextureStageStateHookItem>
    {
        public const string MethodName = Ptr_Func_GetTextureStageState_66.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, D3DTEXTURESTAGESTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetTextureStageStateHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetTextureStageStateHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetTextureStageStateHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, D3DTEXTURESTAGESTATETYPE, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetTextureStageState;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetTextureStageState(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Stage, D3DTEXTURESTAGESTATETYPE Type, Maple.UnmanagedExtensions.UnsafeRef<int> pValue)
        {
            if (D3D9GetTextureStageStateHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Stage, Type, pValue);
                }
                return hookItem.OriginalMethod.Invoke(@this, Stage, Type, pValue);
            }
            return 0;
        }
    }
}
