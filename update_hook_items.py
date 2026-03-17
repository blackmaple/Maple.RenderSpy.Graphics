import os
import re

# 目录路径
hook_dir = r'c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9'

# 遍历所有 .cs 文件
files_updated = 0
for filename in os.listdir(hook_dir):
    if filename.endswith('.cs'):
        filepath = os.path.join(hook_dir, filename)

        # 读取文件内容
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()

        # 检查是否使用了旧格式 (只有2个泛型参数)
        # 匹配 HookItem<Ptr_Func_XXX, Ptr_Func_XXX>
        pattern = r': HookItem<(Ptr_Func_\w+),\s*(Ptr_Func_\w+)>'
        match = re.search(pattern, content)

        if match:
            # 提取类名
            class_name = filename.replace('.cs', '')

            # 构建新的基类定义
            old_base = f": HookItem<{match.group(1)}, {match.group(2)}>"
            new_base = f": HookItem<{class_name}, {match.group(1)}, {match.group(2)}>"

            # 替换
            new_content = content.replace(old_base, new_base)

            # 写回文件
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(new_content)

            files_updated += 1
            print(f'Updated: {filename}')
            print(f'  {old_base}')
            print(f'  {new_base}')

print(f'\n总计更新了 {files_updated} 个文件')
