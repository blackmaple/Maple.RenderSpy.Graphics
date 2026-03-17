import os
import re
import glob
from collections import defaultdict

# 目录
hook_dir = r"Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
ptr_func_dir = r"Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9"

# 获取所有 Hook 文件
hook_files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

def extract_params_from_signature(sig):
    """从函数签名中提取参数类型（返回值和最后一个参数除外）"""
    # 移除返回值部分（最后一个类型）
    # 假设签名格式: Type1, Type2, Type3, ..., ReturnType
    if '->' in sig:
        parts = sig.split('->')
        params_part = parts[0].strip()
        return_type = parts[1].strip()
    else:
        params_part = sig
        return_type = None
    
    # 移除第一个参数（this指针）
    # 分割参数
    params = [p.strip() for p in params_part.split(',')]
    # 跳过第一个参数和返回值
    if len(params) > 1:
        return params[1:]  # 返回除第一个参数外的所有参数
    return []

def extract_ptr_func_params(file_path):
    """从 ptr_func 文件中提取参数类型"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # 查找 delegate* 声明
    match = re.search(r'delegate\*\s+unmanaged\[Stdcall\]\s*<([^>]+)>', content, re.DOTALL)
    if match:
        sig = match.group(1)
        return extract_params_from_signature(sig)
    return None

def extract_hook_params(file_path):
    """从 Hook 文件中提取参数类型"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # 查找 SyncCallback 声明
    match = re.search(r'Func<([^>]+)>.*SyncCallback', content, re.DOTALL)
    if match:
        sig = match.group(1)
        return extract_params_from_signature(sig)
    return None

def extract_hook_unmanaged_params(file_path):
    """从 Hook 文件的 unmanaged 函数指针中提取参数类型"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # 查找 delegate* 声明
    match = re.search(r'delegate\*\s+unmanaged\[Stdcall\]\s*<([^>]+)>', content, re.DOTALL)
    if match:
        sig = match.group(1)
        return extract_params_from_signature(sig)
    return None

def extract_ptr_func_name(file_path):
    """从 Hook 文件中提取 ptr_func 名称"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # 查找 Ptr_Func_xxx
    match = re.search(r'Ptr_Func_\w+_\d+', content)
    if match:
        return match.group(0)
    return None

print("检查 HOOK_Direct3DDevice9 文件夹中的参数类型匹配情况")
print("=" * 80)

mismatches = []

for hook_file in hook_files:
    file_name = os.path.basename(hook_file)
    class_name = os.path.splitext(file_name)[0]
    
    # 提取 ptr_func 名称
    ptr_func_name = extract_ptr_func_name(hook_file)
    if not ptr_func_name:
        print(f"⚠ 跳过: {file_name} (无法找到 ptr_func 名称)")
        continue
    
    # 查找对应的 ptr_func 文件
    ptr_func_file = os.path.join(ptr_func_dir, f"{ptr_func_name}.cs")
    if not os.path.exists(ptr_func_file):
        print(f"⚠ 跳过: {file_name} (ptr_func 文件不存在: {ptr_func_name}.cs)")
        continue
    
    # 提取参数
    ptr_func_params = extract_ptr_func_params(ptr_func_file)
    hook_params = extract_hook_params(hook_file)
    hook_unmanaged_params = extract_hook_unmanaged_params(hook_file)
    
    if ptr_func_params is None or hook_params is None or hook_unmanaged_params is None:
        print(f"⚠ 跳过: {file_name} (无法提取参数)")
        continue
    
    # 比较
    ptr_func_sig = ', '.join(ptr_func_params)
    hook_sig = ', '.join(hook_params)
    hook_unmanaged_sig = ', '.join(hook_unmanaged_params)
    
    if ptr_func_sig != hook_sig or ptr_func_sig != hook_unmanaged_sig:
        mismatches.append({
            'file': file_name,
            'ptr_func': ptr_func_sig,
            'hook': hook_sig,
            'hook_unmanaged': hook_unmanaged_sig
        })
        print(f"✗ 不匹配: {file_name}")
        print(f"  ptr_func:      {ptr_func_sig}")
        print(f"  Hook callback: {hook_sig}")
        print(f"  Hook unmanaged:{hook_unmanaged_sig}")
    else:
        print(f"✓ 正确: {file_name}")

print("=" * 80)
print(f"总共发现 {len(mismatches)} 个不匹配的文件")

if mismatches:
    print("\n不匹配的文件列表:")
    for m in mismatches:
        print(f"  - {m['file']}")
