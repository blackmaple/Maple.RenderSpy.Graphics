using Maple.Hook.Abstractions;

namespace Maple.RenderSpy.Graphics
{
    public interface IHookItemFactory<T> where T : HookItem
    {
        static abstract T Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider); // 要求实现类提供静态 Create 方法，返回 T

    }
}
