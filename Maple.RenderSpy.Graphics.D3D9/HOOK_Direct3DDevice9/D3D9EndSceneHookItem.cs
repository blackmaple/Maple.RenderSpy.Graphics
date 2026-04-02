using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{


    public class D3D9EndSceneHookItem : HookItem<D3D9EndSceneHookItem, Ptr_Func_EndScene_42, Ptr_Func_EndScene_42>, IGraphicsHookItem<D3D9EndSceneHookItem>
    {
        public const string MethodName = Ptr_Func_EndScene_42.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, D3D9EndSceneHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9EndSceneHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9EndSceneHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9EndSceneHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, COM_HRESULT>
                _proc = &Hook_EndScene;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_EndScene(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this)
        {

            if (D3D9EndSceneHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return COM_HRESULT.S_FALSE;
        }


    }
}
