using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9MultiplyTransformHookItem : HookItem<Ptr_Func_MultiplyTransform_46, Ptr_Func_MultiplyTransform_46>, IHookItemFactory<D3D9MultiplyTransformHookItem>
    {
        public const string MethodName = Ptr_Func_MultiplyTransform_46.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DTRANSFORMSTATETYPE, D3DMATRIX*, D3D9MultiplyTransformHookItem, int>? SyncCallback { get; set; }

        public static D3D9MultiplyTransformHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9MultiplyTransformHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9MultiplyTransformHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DTRANSFORMSTATETYPE, D3DMATRIX*, int>
                _proc = &Hook_MultiplyTransform;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_MultiplyTransform(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DTRANSFORMSTATETYPE State, D3DMATRIX* pMatrix)
        {
            if (D3D9MultiplyTransformHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, State, pMatrix, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, State, pMatrix);
            }
            return 0;
        }
    }
}
