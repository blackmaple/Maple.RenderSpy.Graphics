using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetStreamSourceHookItem : HookItem<D3D9GetStreamSourceHookItem, Ptr_Func_GetStreamSource_101, Ptr_Func_GetStreamSource_101>, IGraphicsHookItem<D3D9GetStreamSourceHookItem>
    {
        public const string MethodName = Ptr_Func_GetStreamSource_101.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetStreamSourceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetStreamSourceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetStreamSourceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>
                _proc = &Hook_GetStreamSource;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetStreamSource(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StreamNumber, Maple.UnmanagedExtensions.UnsafeOut<nint> ppStreamData, Maple.UnmanagedExtensions.UnsafeRef<int> pOffsetInBytes, Maple.UnmanagedExtensions.UnsafeRef<int> pStride)
        {
            if (D3D9GetStreamSourceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StreamNumber, ppStreamData, pOffsetInBytes, pStride);
                }
                return hookItem.OriginalMethod.Invoke(@this, StreamNumber, ppStreamData, pOffsetInBytes, pStride);
            }
            return 0;
        }
    }
}
