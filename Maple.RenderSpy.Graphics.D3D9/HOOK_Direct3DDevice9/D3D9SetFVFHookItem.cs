using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetFVFHookItem : HookItem<D3D9SetFVFHookItem, Ptr_Func_SetFVF_89, Ptr_Func_SetFVF_89>, IHookItemFactory<D3D9SetFVFHookItem>
    {
        public const string MethodName = Ptr_Func_SetFVF_89.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetFVFHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetFVFHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetFVFHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, COM_HRESULT>
                _proc = &Hook_SetFVF;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetFVF(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint FVF)
        {
            if (D3D9SetFVFHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, FVF);
                }
                return hookItem.OriginalMethod.Invoke(@this, FVF);
            }
            return 0;
        }
    }
}
