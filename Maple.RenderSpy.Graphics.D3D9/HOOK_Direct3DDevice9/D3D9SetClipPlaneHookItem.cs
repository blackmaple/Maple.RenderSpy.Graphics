using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetClipPlaneHookItem : HookItem<D3D9SetClipPlaneHookItem, Ptr_Func_SetClipPlane_55, Ptr_Func_SetClipPlane_55>, IGraphicsHookItem<D3D9SetClipPlaneHookItem>
    {
        public const string MethodName = Ptr_Func_SetClipPlane_55.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetClipPlaneHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetClipPlaneHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetClipPlaneHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, COM_HRESULT>
                _proc = &Hook_SetClipPlane;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetClipPlane(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Index, Maple.UnmanagedExtensions.UnsafeRef<float> pPlane)
        {
            if (D3D9SetClipPlaneHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, pPlane);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, pPlane);
            }
            return 0;
        }
    }
}
