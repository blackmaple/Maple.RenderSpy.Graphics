import os
import re

# 目录路径
hook_dir = r'c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9'

print(f"检查目录: {hook_dir}")
print(f"目录存在: {os.path.exists(hook_dir)}")

# 遍历所有 .cs 文件
count = 0
old_format_count = 0
for filename in os.listdir(hook_dir):
    if filename.endswith('.cs'):
        count += 1
        filepath = os.path.join(hook_dir, filename)

        # 读取文件内容
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()

        # 检查是否使用了旧格式 (只有2个泛型参数)
        # 匹配 HookItem<Ptr_Func_XXX, Ptr_Func_XXX>
        pattern = r'HookItem<(Ptr_Func_\w+),\s*(Ptr_Func_\w+)>'
        match = re.search(pattern, content)

        if match:
            old_format_count += 1
            print(f"发现旧格式: {filename}")
            print(f"  匹配: {match.group(0)}")

print(f"\n总文件数: {count}")
print(f"使用旧格式的文件数: {old_format_count}")
