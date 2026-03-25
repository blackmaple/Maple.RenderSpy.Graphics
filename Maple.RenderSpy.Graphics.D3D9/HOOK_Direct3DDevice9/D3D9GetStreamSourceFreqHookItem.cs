using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetStreamSourceFreqHookItem : HookItem<D3D9GetStreamSourceFreqHookItem, Ptr_Func_GetStreamSourceFreq_103, Ptr_Func_GetStreamSourceFreq_103>, IGraphicsHookItem<D3D9GetStreamSourceFreqHookItem>
    {
        public const string MethodName = Ptr_Func_GetStreamSourceFreq_103.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetStreamSourceFreqHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetStreamSourceFreqHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetStreamSourceFreqHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetStreamSourceFreq;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetStreamSourceFreq(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StreamNumber, UnsafeRef<int> pDivider)
        {
            if (D3D9GetStreamSourceFreqHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StreamNumber, pDivider);
                }
                return hookItem.OriginalMethod.Invoke(@this, StreamNumber, pDivider);
            }
            return 0;
        }
    }
}
