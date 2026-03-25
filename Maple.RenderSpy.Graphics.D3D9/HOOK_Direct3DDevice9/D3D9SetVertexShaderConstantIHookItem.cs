using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetVertexShaderConstantIHookItem : HookItem<D3D9SetVertexShaderConstantIHookItem,Ptr_Func_SetVertexShaderConstantI_96, Ptr_Func_SetVertexShaderConstantI_96>, IGraphicsHookItem<D3D9SetVertexShaderConstantIHookItem>
    {
        public const string MethodName = Ptr_Func_SetVertexShaderConstantI_96.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetVertexShaderConstantIHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetVertexShaderConstantIHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetVertexShaderConstantIHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, uint, COM_HRESULT>
                _proc = &Hook_SetVertexShaderConstantI;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetVertexShaderConstantI(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint StartRegister, Maple.UnmanagedExtensions.UnsafeRef<int> pConstantData, uint Vector4iCount)
        {
            if (D3D9SetVertexShaderConstantIHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, StartRegister, pConstantData, Vector4iCount);
                }
                return hookItem.OriginalMethod.Invoke(@this, StartRegister, pConstantData, Vector4iCount);
            }
            return 0;
        }
    }
}
