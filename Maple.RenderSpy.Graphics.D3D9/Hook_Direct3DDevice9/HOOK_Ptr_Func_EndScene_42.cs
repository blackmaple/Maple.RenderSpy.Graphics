using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static Maple.RenderSpy.Graphics.D3D9.Hook_Direct3DDevice9.HookItem_EndScene_42;

namespace Maple.RenderSpy.Graphics.D3D9.Hook_Direct3DDevice9
{
    internal class HookItem_EndScene_42(IHookFactory hookFactory) 
    {
        HookItem_EndScene_42_Imp HookItem { get; } = hookFactory.Create< HookItem_EndScene_42_Imp >()
        internal class HookItem_EndScene_42_Imp() : Hook.Abstractions.HookItem<Ptr_Func_EndScene_42, Ptr_Func_EndScene_42>
        {
            public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, COM_HRESULT>? SyncCallback;

        }

        

        [StructLayout(LayoutKind.Sequential)]
        internal readonly unsafe struct Hook_Ptr_Func_EndScene_42()  : IHookMethod
        {
            private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, COM_HRESULT>
                _proc = &HOOK_EndScene_42;


            public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis) => _proc(pThis);

            public nint PtrMethod => new(_proc);
            public override string ToString()
            {
                return PtrMethod.ToString("X8");
            }
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT HOOK_EndScene_42(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this)
        {
            if (IHookFactory.TryGet<HookItem_EndScene_42>("", out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this);
                }
            }
            return COM_HRESULT.S_OK;
        }
    }
}
