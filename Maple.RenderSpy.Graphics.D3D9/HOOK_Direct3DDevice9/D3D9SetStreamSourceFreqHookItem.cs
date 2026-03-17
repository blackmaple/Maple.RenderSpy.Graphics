using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetStreamSourceFreqHookItem : HookItem<Ptr_Func_SetStreamSourceFreq_102, Ptr_Func_SetStreamSourceFreq_102>, IHookItemFactory<D3D9SetStreamSourceFreqHookItem>
    {
        public const string MethodName = Ptr_Func_SetStreamSourceFreq_102.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3D9SetStreamSourceFreqHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetStreamSourceFreqHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetStreamSourceFreqHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetStreamSourceFreqHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, COM_HRESULT>
                _proc = &Hook_SetStreamSourceFreq;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetStreamSourceFreq(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint StreamNumber, uint Divider)
        {
            if (D3D9SetStreamSourceFreqHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StreamNumber, Divider, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, StreamNumber, Divider);
            }
            return 0;
        }
    }
}
