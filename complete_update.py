import os
import re
import glob

# HOOK文件目录
hook_dir = r"Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

# 已更新的文件列表
updated_files = {'D3D9BeginSceneHookItem.cs', 'D3D9SetTextureHookItem.cs', 'D3D9ClearHookItem.cs', 
                 'D3D9DrawPrimitiveHookItem.cs', 'D3D9PresentHookItem.cs', 'D3D9EndSceneHookItem.cs',
                 'D3D9GetPixelShaderHookItem.cs', 'D3D9SetPixelShaderHookItem.cs', 'D3D9CreateTextureHookItem.cs', 
                 'D3D9CreateVertexShaderHookItem.cs', 'D3D9ResetHookItem.cs', 'D3D9SetRenderStateHookItem.cs',
                 'D3D9GetRenderTargetHookItem.cs'}

# 获取所有 D3D9*.cs 文件
files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

count = 0
for file_path in files:
    file_name = os.path.basename(file_path)
    if file_name in updated_files:
        print(f"跳过已更新的文件: {file_name}")
        continue

    # 读取文件
    try:
        with open(file_path, 'r', encoding='utf-8') as f:
            content = f.read()
    except Exception as e:
        print(f"读取文件失败 {file_name}: {e}")
        continue

    # 提取类名
    class_name = os.path.splitext(file_name)[0]

    # 查找并替换基类声明
    pattern = r'HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>'
    match = re.search(pattern, content)
    
    if match:
        old_base = match.group(0)
        func1 = match.group(1)
        func2 = match.group(2)
        new_base = f'HookItem<{class_name}, {func1}, {func2}>'
        
        # 替换
        content = content.replace(old_base, new_base)
        
        # 保存文件
        try:
            with open(file_path, 'w', encoding='utf-8') as f:
                f.write(content)
            
            print(f"已更新: {file_name}")
            print(f"  {old_base} -> {new_base}")
            count += 1
        except Exception as e:
            print(f"保存文件失败 {file_name}: {e}")
    else:
        print(f"跳过（无需更新）: {file_name}")

print(f"\n总计更新 {count} 个文件!")
