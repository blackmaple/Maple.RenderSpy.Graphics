using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetStreamSourceHookItem : HookItem<D3D9SetStreamSourceHookItem, Ptr_Func_SetStreamSource_100, Ptr_Func_SetStreamSource_100>, IGraphicsHookItem<D3D9SetStreamSourceHookItem>
    {
        public const string MethodName = Ptr_Func_SetStreamSource_100.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, nint, uint, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetStreamSourceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetStreamSourceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetStreamSourceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, nint, uint, uint, COM_HRESULT>
                _proc = &Hook_SetStreamSource;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetStreamSource(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StreamNumber, nint pStreamData, uint OffsetInBytes, uint Stride)
        {
            if (D3D9SetStreamSourceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StreamNumber, pStreamData, OffsetInBytes, Stride);
                }
                return hookItem.OriginalMethod.Invoke(@this, StreamNumber, pStreamData, OffsetInBytes, Stride);
            }
            return 0;
        }
    }
}
