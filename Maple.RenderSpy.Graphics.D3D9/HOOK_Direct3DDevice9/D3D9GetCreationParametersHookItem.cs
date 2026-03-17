using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetCreationParametersHookItem : HookItem<D3D9GetCreationParametersHookItem, Ptr_Func_GetCreationParameters_9, Ptr_Func_GetCreationParameters_9>, IHookItemFactory<D3D9GetCreationParametersHookItem>
    {
        public const string MethodName = Ptr_Func_GetCreationParameters_9.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetCreationParametersHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetCreationParametersHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetCreationParametersHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_GetCreationParameters;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetCreationParameters(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pParameters)
        {
            if (D3D9GetCreationParametersHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pParameters);
                }
                return hookItem.OriginalMethod.Invoke(@this, pParameters);
            }
            return 0;
        }
    }
}
