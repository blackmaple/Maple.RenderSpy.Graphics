using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetFVFHookItem : HookItem<D3D9GetFVFHookItem, Ptr_Func_GetFVF_90, Ptr_Func_GetFVF_90>, IHookItemFactory<D3D9GetFVFHookItem>
    {
        public const string MethodName = Ptr_Func_GetFVF_90.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint>? SyncCallback { get; set; }

        public static D3D9GetFVFHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetFVFHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetFVFHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint>
                _proc = &Hook_GetFVF;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static uint Hook_GetFVF(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this)
        {
            if (D3D9GetFVFHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this);
                }
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return 0;
        }
    }
}
