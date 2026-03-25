using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9LightEnableHookItem : HookItem<D3D9LightEnableHookItem, Ptr_Func_LightEnable_53, Ptr_Func_LightEnable_53>, IGraphicsHookItem<D3D9LightEnableHookItem>
    {
        public const string MethodName = Ptr_Func_LightEnable_53.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, int, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9LightEnableHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9LightEnableHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9LightEnableHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, int, COM_HRESULT>
                _proc = &Hook_LightEnable;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_LightEnable(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Index, int Enable)
        {
            if (D3D9LightEnableHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Index, Enable);
                }
                return hookItem.OriginalMethod.Invoke(@this, Index, Enable);
            }
            return 0;
        }
    }
}
