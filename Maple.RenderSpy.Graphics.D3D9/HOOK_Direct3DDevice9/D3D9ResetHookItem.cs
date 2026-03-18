using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    public class D3D9ResetHookItem : HookItem<D3D9ResetHookItem, Ptr_Func_Reset_16, Ptr_Func_Reset_16>, IHookItemFactory<D3D9ResetHookItem>
    {
        public const string MethodName = Ptr_Func_Reset_16.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9ResetHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9ResetHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9ResetHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, UnsafeRef<D3DPRESENT_PARAMETERS>, COM_HRESULT>
                _proc = &Hook_Reset;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_Reset(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, UnsafeRef<D3DPRESENT_PARAMETERS> pPresentationParameters)
        {

            if (D3D9ResetHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pPresentationParameters);
                }
                return hookItem.OriginalMethod.Invoke(@this, pPresentationParameters);
            }
            return COM_HRESULT.S_FALSE;
        }


    }
}
