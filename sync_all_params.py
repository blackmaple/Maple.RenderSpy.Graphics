import os
import re
import glob

# 文件目录
hook_dir = r"Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
func_dir = r"Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9"

# 常见类型映射
type_mapping = {
    'void*': 'nint',
    'void**': 'nint',
    'uint*': 'nint',
    'D3DRECT*': 'nint',
    'int': 'COM_HRESULT'  # 当作为返回类型时
}

# 获取所有 HOOK 文件
hook_files = glob.glob(os.path.join(hook_dir, "D3D9*.cs"))

updated_files = []

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
        
        # 提取 Ptr_Func 的函数签名
        func_pattern = r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>'
        func_match = re.search(func_pattern, func_content)
        
        if not func_match:
            continue
            
        func_params = func_match.group(1).strip()
        
        # 提取参数和返回类型
        func_parts = [p.strip() for p in func_params.split(',')]
        func_return = func_parts[-1]  # 最后一个是返回类型
        func_param_list = func_parts[:-1]  # 前面的是参数
        
        # 检查 HOOK 文件中的 Func 签名
        hook_func_pattern = r'Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>'
        hook_func_match = re.search(hook_func_pattern, hook_content)
        
        if not hook_func_match:
            continue
            
        hook_func_params = hook_func_match.group(1).strip()
        hook_parts = [p.strip() for p in hook_func_params.split(',')]
        
        # 最后一个是返回类型，倒数第二个是HookItem类，前面的是函数参数
        hook_return = hook_parts[-1]
        hook_param_list = hook_parts[:-2]  # 移除HookItem类和返回类型
        
        # 检查是否需要更新
        needs_update = False
        new_hook_param_list = []
        
        for i, param in enumerate(hook_param_list):
            if i < len(func_param_list):
                if param != func_param_list[i]:
                    needs_update = True
                    new_hook_param_list.append(func_param_list[i])
                else:
                    new_hook_param_list.append(param)
            else:
                new_hook_param_list.append(param)
        
        if needs_update or hook_return != func_return:
            # 更新 Func 声明
            new_hook_params = ', '.join(new_hook_param_list)
            new_hook_signature = f'Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {new_hook_params}, {class_name}, {func_return}>'
            
            old_hook_signature = hook_func_match.group(0)
            hook_content = hook_content.replace(old_hook_signature, new_hook_signature)
            
            # 更新 Hook 方法签名
            hook_method_pattern = r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)>\s+_proc'
            hook_method_match = re.search(hook_method_pattern, hook_content)
            
            if hook_method_match:
                old_method_params = hook_method_match.group(1).strip()
                new_method_params = ', '.join(func_param_list)
                new_method_signature = f'delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {new_method_params}, {func_return}>'
                
                old_method_signature = f'delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {old_method_params}>'
                hook_content = hook_content.replace(old_method_signature, new_method_signature)
                
                # 更新 Hook 方法参数
                hook_method_name_pattern = r'private static \w+ Hook_\w+\(' + class_name.replace('D3D9', '').replace('HookItem', '')
                # 这个比较复杂，暂时跳过
            
            # 保存文件
            try:
                with open(hook_file, 'w', encoding='utf-8') as f:
                    f.write(hook_content)
                print(f"已更新: {hook_filename}")
                updated_files.append(hook_filename)
            except Exception as e:
                print(f"保存失败: {hook_filename} - {e}")

print(f"\n总计更新 {len(updated_files)} 个文件")
