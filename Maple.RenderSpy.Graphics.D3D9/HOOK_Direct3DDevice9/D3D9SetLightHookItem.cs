using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetLightHookItem : HookItem<Ptr_Func_SetLight_51, Ptr_Func_SetLight_51>, IHookItemFactory<D3D9SetLightHookItem>
    {
        public const string MethodName = Ptr_Func_SetLight_51.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, D3DLIGHT9*, D3D9SetLightHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetLightHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetLightHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetLightHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, D3DLIGHT9*, int>
                _proc = &Hook_SetLight;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetLight(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Index, D3DLIGHT9* pLight)
        {
            if (D3D9SetLightHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, pLight, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, pLight);
            }
            return 0;
        }
    }
}
