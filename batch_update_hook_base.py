import os
import re
import glob

# HOOK文件目录
hook_dir = r"c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

# 已更新的文件列表
updated_files = ['D3D9BeginSceneHookItem.cs', 'D3D9SetTextureHookItem.cs', 'D3D9ClearHookItem.cs', 
                 'D3D9DrawPrimitiveHookItem.cs', 'D3D9PresentHookItem.cs', 'D3D9EndSceneHookItem.cs']

# 获取所有 D3D9*.cs 文件
files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

count = 0
for file_path in files:
    file_name = os.path.basename(file_path)
    if file_name in updated_files:
        print(f"跳过已更新的文件: {file_name}")
        continue

    # 读取文件
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # 提取类名
    class_name = os.path.splitext(file_name)[0]

    # 替换基类声明：HookItem<Ptr_Func_XXX, Ptr_Func_XXX> -> HookItem<D3D9XXXHookItem, Ptr_Func_XXX, Ptr_Func_XXX>
    old_pattern = f"HookItem<(Ptr_Func_\\d+), (Ptr_Func_\\d+)>"
    new_pattern = f"HookItem<{class_name}, \\1, \\2>"
    
    if re.search(old_pattern, content):
        content = re.sub(old_pattern, new_pattern, content)
        
        # 保存文件
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(content)
        
        print(f"已更新: {file_name}")
        count += 1
    else:
        print(f"跳过（无需更新）: {file_name}")

print(f"\n共更新 {count} 个文件!")

