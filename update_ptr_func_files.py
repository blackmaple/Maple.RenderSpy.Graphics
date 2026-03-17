import os
import re
from pathlib import Path

# 类型映射规则
type_mappings = {
    'COM_PTR_IUNKNOWN, ': 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, ',
    'COM_PTR_IUNKNOWN> ': 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>> ',
    'int> _proc': 'COM_HRESULT> _proc',
    'int> _newProc': 'COM_HRESULT> _newProc',
    'void*': 'nint',
    'void**': 'nint',
    'HANDLE*': 'nint',
    'nint*': 'UnsafeRef<uint>',  # 需要具体判断类型
    'uint*': 'UnsafeRef<uint>',
    'int*': 'UnsafeRef<int>',
    'float*': 'UnsafeRef<float>',
    'D3DRECT*': 'nint',
    'D3DMATRIX*': 'nint',
    'D3DVIEWPORT9*': 'nint',
}

# 基础类型指针映射
basic_type_ptr_mapping = {
    'uint*': 'UnsafeRef<uint>',
    'int*': 'UnsafeRef<int>',
    'float*': 'UnsafeRef<float>',
    'BOOL*': 'UnsafeRef<int>',
}

# 不应该转换的指针类型
exclude_ptr_types = [
    'D3DRECT*',
    'D3DMATRIX*',
    'D3DVIEWPORT9*',
    'D3DDEVICE_CREATION_PARAMETERS*',
    'D3DDISPLAYMODE*',
    'D3DCAPS9*',
    'D3DADAPTER_IDENTIFIER9*',
    'D3DGAMMARAMP*',
    'D3DSURFACE_DESC*',
    'D3DVERTEXELEMENT9*',
    'PALETTEENTRY*',
    'D3DCLIPSTATUS*',
    'D3DRASTER_STATUS*',
    'D3DLOCKED_RECT*',
    'D3DBOX*',
    'D3DLOCKED_BOX*',
    'D3DPRESENT_PARAMETERS*',
    'D3DRECT*',
    'IDirect3DSurface9**',
    'IDirect3DBaseTexture9**',
    'IDirect3DTexture9**',
    'IDirect3DCubeTexture9**',
    'IDirect3DVolumeTexture9**',
    'IDirect3DVertexBuffer9**',
    'IDirect3DIndexBuffer9**',
    'IDirect3DDevice9**',
    'IDirect3DVertexDeclaration9**',
    'IDirect3DVertexShader9**',
    'IDirect3DPixelShader9**',
    'IDirect3DQuery9**',
]

def process_file(file_path):
    """处理单个文件"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # 检查文件是否已经更新过
    if 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>' in content:
        print(f"文件已更新，跳过: {file_path.name}")
        return False
    
    # 检查是否有原函数指针注释
    if '// 原函数指针:' in content:
        print(f"文件已包含原函数指针注释，跳过: {file_path.name}")
        return False
    
    lines = content.split('\n')
    result_lines = []
    modified = False
    
    i = 0
    while i < len(lines):
        line = lines[i]
        
        # 查找函数指针声明行
        if 'private readonly delegate* unmanaged[Stdcall]<' in line and '_proc' in line:
            # 保存原函数指针（带注释）
            original_line = line.strip()
            
            # 复制到下一行，添加注释
            comment_line = '        // 原函数指针: ' + original_line
            result_lines.append(comment_line)
            
            # 处理新函数指针
            new_line = line
            
            # 替换 COM_PTR_IUNKNOWN 为泛型版本
            new_line = re.sub(r'COM_PTR_IUNKNOWN,?', r'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>,', new_line)
            new_line = re.sub(r'COM_PTR_IUNKNOWN>', r'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>', new_line)
            
            # 替换 void* 为 nint（排除系统内置类型）
            for ptr_type in exclude_ptr_types:
                # 先排除这些类型
                pass
            
            # 替换 void* 为 nint
            new_line = re.sub(r'void\*', r'nint', new_line)
            new_line = re.sub(r'void\*\*', r'nint', new_line)
            new_line = re.sub(r'HANDLE\*', r'nint', new_line)
            
            # 替换基础类型指针
            for old_type, new_type in basic_type_ptr_mapping.items():
                new_line = new_line.replace(old_type, new_type)
            
            # 替换返回值 int 为 COM_HRESULT
            new_line = re.sub(r', int>\s*_proc', r', COM_HRESULT> _proc', new_line)
            new_line = re.sub(r', int>\s*_newProc', r', COM_HRESULT> _newProc', new_line)
            
            result_lines.append(new_line)
            modified = True
        else:
            result_lines.append(line)
        
        i += 1
    
    # 如果没有找到函数指针，跳过
    if not modified:
        print(f"未找到需要更新的内容: {file_path.name}")
        return False
    
    # 处理 Invoke 方法
    i = 0
    invoke_lines = []
    while i < len(result_lines):
        line = result_lines[i]
        
        # 查找 Invoke 方法声明
        if 'public int Invoke(' in line:
            # 转换返回类型
            line = line.replace('public int Invoke(', 'public COM_HRESULT Invoke(')
            
            # 处理参数
            # COM_PTR_IUNKNOWN -> COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>
            line = re.sub(r'COM_PTR_IUNKNOWN\s+pThis', r'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis', line)
            
            # 替换 void* 参数为 nint
            line = re.sub(r'void\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', r'nint \1', line)
            line = re.sub(r'void\*\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', r'nint \1', line)
            line = re.sub(r'HANDLE\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', r'nint \1', line)
            
            # 替换基础类型指针
            for old_type, new_type in basic_type_ptr_mapping.items():
                line = re.sub(rf'{old_type}\s+([a-zA-Z_][a-zA-Z0-9_]*)', rf'{new_type} \1', line)
            
            invoke_lines.append(line)
            modified = True
        else:
            invoke_lines.append(line)
        
        i += 1
    
    # 处理 D3DRECT* 等特殊类型
    i = 0
    final_lines = []
    while i < len(invoke_lines):
        line = invoke_lines[i]
        
        # D3DRECT* -> nint
        for ptr_type in exclude_ptr_types:
            # 只在Invoke方法的参数中替换
            if 'public COM_HRESULT Invoke(' in invoke_lines[max(0, i-5):i+1]:
                if ptr_type.startswith('IDirect3D') or ptr_type in ['D3DRECT*', 'D3DMATRIX*', 'D3DVIEWPORT9*', 'D3DLOCKED_RECT*', 'D3DLOCKED_BOX*', 'D3DBOX*', 'D3DCLIPSTATUS*', 'D3DRASTER_STATUS*', 'D3DGAMMARAMP*', 'D3DDEVICE_CREATION_PARAMETERS*', 'D3DDISPLAYMODE*', 'D3DCAPS9*', 'D3DADAPTER_IDENTIFIER9*', 'PALETTEENTRY*', 'D3DSURFACE_DESC*', 'D3DVERTEXELEMENT9*', 'D3DPRESENT_PARAMETERS*']:
                    line = line.replace(ptr_type, 'nint')
        
        final_lines.append(line)
        i += 1
    
    # 写回文件
    if modified:
        new_content = '\n'.join(final_lines)
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(new_content)
        print(f"已更新: {file_path.name}")
        return True
    else:
        return False

def main():
    """主函数"""
    folder_path = r'c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9'
    
    # 遍历所有 Ptr_Func_*.cs 文件
    files = list(Path(folder_path).glob('Ptr_Func_*.cs'))
    print(f"找到 {len(files)} 个文件")
    
    updated_count = 0
    skipped_count = 0
    
    for file in sorted(files):
        try:
            if process_file(file):
                updated_count += 1
            else:
                skipped_count += 1
        except Exception as e:
            print(f"处理文件出错 {file.name}: {e}")
    
    print(f"\n更新完成！")
    print(f"已更新: {updated_count} 个文件")
    print(f"跳过: {skipped_count} 个文件")

if __name__ == '__main__':
    main()
