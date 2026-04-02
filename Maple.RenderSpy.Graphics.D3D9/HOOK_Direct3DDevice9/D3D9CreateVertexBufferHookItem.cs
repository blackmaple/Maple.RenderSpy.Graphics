using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Foundation;
using Maple.RenderSpy.Graphics.Windows.COM;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVertexBufferHookItem : HookItem<D3D9CreateVertexBufferHookItem, Ptr_Func_CreateVertexBuffer_26, Ptr_Func_CreateVertexBuffer_26>, IGraphicsHookItem<D3D9CreateVertexBufferHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVertexBuffer_26.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, D3D9CreateVertexBufferHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateVertexBufferHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9CreateVertexBufferHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateVertexBufferHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, D3DPOOL, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE>, COM_HRESULT>
                _proc = &Hook_CreateVertexBuffer;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateVertexBuffer(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Length, uint Usage, uint FVF, D3DPOOL Pool, Maple.UnmanagedExtensions.UnsafeOut<nint> ppVertexBuffer, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Foundation.HANDLE> pSharedHandle)
        {
            if (D3D9CreateVertexBufferHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Length, Usage, FVF, Pool, ppVertexBuffer, pSharedHandle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Length, Usage, FVF, Pool, ppVertexBuffer, pSharedHandle);
            }
            return 0;
        }
    }
}
