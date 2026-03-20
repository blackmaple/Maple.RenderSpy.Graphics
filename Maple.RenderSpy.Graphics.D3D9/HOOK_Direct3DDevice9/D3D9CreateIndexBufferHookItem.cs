using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateIndexBufferHookItem : HookItem<D3D9CreateIndexBufferHookItem, Ptr_Func_CreateIndexBuffer_27, Ptr_Func_CreateIndexBuffer_27>, IHookItemFactory<D3D9CreateIndexBufferHookItem>
    {
        public const string MethodName = Ptr_Func_CreateIndexBuffer_27.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, D3D9CreateIndexBufferHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateIndexBufferHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateIndexBufferHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateIndexBufferHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, D3DFORMAT, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>
                _proc = &Hook_CreateIndexBuffer;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateIndexBuffer(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Length, uint Usage, D3DFORMAT Format, D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppIndexBuffer, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle)
        {
            if (D3D9CreateIndexBufferHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Length, Usage, Format, Pool, ppIndexBuffer, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Length, Usage, Format, Pool, ppIndexBuffer, pSharedHandle);
            }
            return 0;
        }
    }
}
