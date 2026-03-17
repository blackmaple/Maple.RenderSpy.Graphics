using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawPrimitiveUPHookItem : HookItem<D3D9DrawPrimitiveUPHookItem, Ptr_Func_DrawPrimitiveUP_83, Ptr_Func_DrawPrimitiveUP_83>, IHookItemFactory<D3D9DrawPrimitiveUPHookItem>
    {
        public const string MethodName = Ptr_Func_DrawPrimitiveUP_83.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, nint, uint, D3D9DrawPrimitiveUPHookItem, int>? SyncCallback { get; set; }

        public static D3D9DrawPrimitiveUPHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DrawPrimitiveUPHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DrawPrimitiveUPHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, nint, uint, int>
                _proc = &Hook_DrawPrimitiveUP;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_DrawPrimitiveUP(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DPRIMITIVETYPE PrimitiveType, uint PrimitiveCount, nint pVertexStreamZeroData, uint VertexStreamZeroStride)
        {
            if (D3D9DrawPrimitiveUPHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, PrimitiveType, PrimitiveCount, pVertexStreamZeroData, VertexStreamZeroStride, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, PrimitiveType, PrimitiveCount, pVertexStreamZeroData, VertexStreamZeroStride);
            }
            return 0;
        }
    }
}
