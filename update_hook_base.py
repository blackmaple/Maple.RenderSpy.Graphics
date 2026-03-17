import os
import re

# 目录路径
hook_dir = r'c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9'

# 遍历所有 .cs 文件
files_to_update = []
for filename in os.listdir(hook_dir):
    if filename.endswith('.cs'):
        filepath = os.path.join(hook_dir, filename)

        # 读取文件内容
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()

        # 检查是否使用了旧格式 (只有2个泛型参数)
        # 匹配 HookItem<Ptr_Func_XXX, Ptr_Func_XXX>
        pattern = r'HookItem<(Ptr_Func_\w+),\s*(Ptr_Func_\w+)>'
        match = re.search(pattern, content)

        if match:
            # 提取类名（去掉 D3D9 前缀和 HookItem 后缀）
            class_name = filename.replace('.cs', '')  # 例如: D3D9GetClipPlaneHookItem

            # 提取 Ptr_Func 名称
            ptr_func_name = match.group(1)  # 例如: Ptr_Func_GetClipPlane_56

            # 构建新的基类定义
            old_base = match.group(0)
            new_base = f'HookItem<{class_name}, {match.group(1)}, {match.group(2)}>'

            # 替换
            new_content = content.replace(old_base, new_base)

            # 写回文件
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(new_content)

            files_to_update.append((filename, old_base, new_base))
            print(f'Updated: {filename}')
            print(f'  Old: {old_base}')
            print(f'  New: {new_base}')
            print()

print(f'\n总计更新了 {len(files_to_update)} 个文件')
