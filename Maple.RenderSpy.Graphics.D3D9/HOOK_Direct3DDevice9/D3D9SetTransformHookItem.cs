using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.UnmanagedExtensions;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetTransformHookItem : HookItem<D3D9SetTransformHookItem, Ptr_Func_SetTransform_44, Ptr_Func_SetTransform_44>, IHookItemFactory<D3D9SetTransformHookItem>
    {
        public const string MethodName = Ptr_Func_SetTransform_44.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetTransformHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetTransformHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetTransformHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>
                _proc = &Hook_SetTransform;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetTransform(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, D3DTRANSFORMSTATETYPE State, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX> pMatrix)
        {
            if (D3D9SetTransformHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, State, pMatrix);
                }
                return hookItem.OriginalMethod.Invoke(@this, State, pMatrix);
            }
            return 0;
        }
    }
}
