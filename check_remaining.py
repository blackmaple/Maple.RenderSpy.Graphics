import os
import re
import glob

# HOOK文件目录
hook_dir = r"Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

# 获取所有 D3D9*.cs 文件
files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

print("检查需要更新的文件...")
print("=" * 60)

remaining_files = []

for file_path in files:
    file_name = os.path.basename(file_path)
    class_name = os.path.splitext(file_name)[0]
    
    # 读取文件
    try:
        with open(file_path, 'r', encoding='utf-8') as f:
            content = f.read()
    except Exception as e:
        continue

    # 检查是否需要更新（基类格式不正确）
    pattern = rf'HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>'
    correct_pattern = rf'HookItem<{class_name}, Ptr_Func_\d+, Ptr_Func_\d+>'
    
    if re.search(pattern, content):
        remaining_files.append(file_name)
        print(f"需要更新: {file_name}")
    elif not re.search(correct_pattern, content):
        print(f"格式异常: {file_name}")
    else:
        print(f"✓ 已正确: {file_name}")

print("=" * 60)
print(f"总共需要更新 {len(remaining_files)} 个文件")
