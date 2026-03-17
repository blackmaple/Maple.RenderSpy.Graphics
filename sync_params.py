import os
import re
import glob

# 文件目录
hook_dir = r"Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
func_dir = r"Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9"

# 获取所有 HOOK 文件
hook_files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

print("检查参数同步情况...")
print("=" * 80)

for hook_file in hook_files:
    hook_filename = os.path.basename(hook_file)
    class_name = os.path.splitext(hook_filename)[0]
    
    # 找到对应的 Ptr_Func 文件
    if class_name.startswith("D3D9"):
        func_name = "Ptr_Func_" + class_name[3:]  # 移除 D3D9 前缀
        func_file = os.path.join(func_dir, func_name + ".cs")
        
        if not os.path.exists(func_file):
            continue
        
        # 读取 HOOK 文件
        try:
            with open(hook_file, 'r', encoding='utf-8') as f:
                hook_content = f.read()
        except:
            continue
        
        # 读取 Ptr_Func 文件
        try:
            with open(func_file, 'r', encoding='utf-8') as f:
                func_content = f.read()
        except:
            continue
        
        # 提取 Ptr_Func 的签名参数
        func_pattern = r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>'
        func_match = re.search(func_pattern, func_content)
        
        if not func_match:
            continue
            
        func_params = func_match.group(1).strip()
        
        # 提取返回类型
        return_pattern = r'>\s*COM_HRESULT|>\s*int'
        return_match = re.search(return_pattern, func_match.group(0))
        
        if return_match:
            return_type = 'COM_HRESULT' if 'COM_HRESULT' in return_match.group(0) else 'int'
        else:
            continue
        
        # 检查 HOOK 文件中的 Func 签名和 Hook 方法签名
        hook_func_pattern = r'Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>'
        hook_func_match = re.search(hook_func_pattern, hook_content)
        
        hook_method_pattern = r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>\s+_proc'
        hook_method_match = re.search(hook_method_pattern, hook_content)
        
        if not hook_func_match and not hook_method_match:
            continue
            
        print(f"\n{class_name}:")
        print(f"  Ptr_Func 参数: {func_params}")
        print(f"  Ptr_Func 返回: {return_type}")
        
        if hook_func_match:
            hook_func_params = hook_func_match.group(1).strip()
            print(f"  HOOK Func 参数: {hook_func_params}")
            
        if hook_method_match:
            hook_method_params = hook_method_match.group(1).strip()
            print(f"  HOOK Method 参数: {hook_method_params}")

print("\n" + "=" * 80)
