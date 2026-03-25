using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9BeginSceneHookItem : HookItem<D3D9BeginSceneHookItem, Ptr_Func_BeginScene_41, Ptr_Func_BeginScene_41>, IGraphicsHookItem<D3D9BeginSceneHookItem>
    {
        public const string MethodName = Ptr_Func_BeginScene_41.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9BeginSceneHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9BeginSceneHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9BeginSceneHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, COM_HRESULT>
                _proc = &Hook_BeginScene;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_BeginScene(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this)
        {
            if (D3D9BeginSceneHookItem.TryGet(out var hookItem))
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
