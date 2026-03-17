using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateRenderTargetHookItem : HookItem<Ptr_Func_CreateRenderTarget_28, Ptr_Func_CreateRenderTarget_28>, IHookItemFactory<D3D9CreateRenderTargetHookItem>
    {
        public const string MethodName = Ptr_Func_CreateRenderTarget_28.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, nint*, HANDLE*, D3D9CreateRenderTargetHookItem, int>? SyncCallback { get; set; }

        public static D3D9CreateRenderTargetHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateRenderTargetHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateRenderTargetHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DFORMAT, D3DMULTISAMPLE_TYPE, uint, int, nint*, HANDLE*, int>
                _proc = &Hook_CreateRenderTarget;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_CreateRenderTarget(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Width, uint Height, D3DFORMAT Format, D3DMULTISAMPLE_TYPE MultiSample, uint MultisampleQuality, int Lockable, nint* ppSurface, HANDLE* pSharedHandle)
        {
            if (D3D9CreateRenderTargetHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, ppSurface, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Width, Height, Format, MultiSample, MultisampleQuality, Lockable, ppSurface, pSharedHandle);
            }
            return 0;
        }
    }
}
