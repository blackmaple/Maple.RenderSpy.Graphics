using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetNPatchModeHookItem : HookItem<D3D9GetNPatchModeHookItem, Ptr_Func_GetNPatchMode_80, Ptr_Func_GetNPatchMode_80>, IGraphicsHookItem<D3D9GetNPatchModeHookItem>
    {
        public const string MethodName = Ptr_Func_GetNPatchMode_80.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, float>? SyncCallback { get; set; }

        public static D3D9GetNPatchModeHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetNPatchModeHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetNPatchModeHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, float>
                _proc = &Hook_GetNPatchMode;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static float Hook_GetNPatchMode(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this)
        {
            if (D3D9GetNPatchModeHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this);
                }
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return 0.0f;
        }
    }
}
