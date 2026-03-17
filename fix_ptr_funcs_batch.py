import os
import re

# 定义映射关系：从 txt 文件中的函数名到正确的函数指针签名
# 根据 IDirect3DDevice9.txt 的内容解析

def read_txt_signatures():
    """读取 IDirect3DDevice9.txt 文件，解析函数指针签名"""
    txt_path = r"c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9\IDirect3DDevice9.txt"
    with open(txt_path, 'r', encoding='utf-8') as f:
        content = f.read()

    signatures = {}
    # 匹配模式: FuncName_Num; <params>;
    pattern = r'public delegate\* unmanaged\[Stdcall\]<(.*?)>\s+(\w+)_(\d+);'
    matches = re.findall(pattern, content)

    for match in matches:
        params, func_name, num = match
        signatures[f"{func_name}_{num}"] = params

    return signatures

def process_cs_file(file_path, signatures):
    """处理单个 .cs 文件"""
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # 提取文件名（不带扩展名）
    filename = os.path.basename(file_path).replace('.cs', '')

    if filename not in signatures:
        print(f"警告: {filename} 在 txt 中没有找到对应的签名")
        return False

    # 解析正确的签名
    correct_params = signatures[filename]

    # 替换模式 1: 替换注释的旧签名和当前的签名
    old_pattern = r'// 原函数指针:.*?_proc = \(.*?\)ptr;\s*private readonly delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, (.*?)> _proc = \(delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, (.*?)>\)ptr;'

    # 查找 Invoke 方法的参数部分
    invoke_pattern = r'public COM_HRESULT Invoke\(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis, (.*?)\)'
    invoke_match = re.search(invoke_pattern, content)

    # 构建新的函数指针声明
    new_proc_line = f'        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {correct_params}> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {correct_params}>)ptr;'

    # 替换旧的 _proc 声明
    content = re.sub(
        r'(?:// 原函数指针:.*?\n)?\s*private readonly delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, .*?> _proc = \(delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, .*?>\)ptr;',
        new_proc_line,
        content
    )

    # 写回文件
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(content)

    return True

def main():
    signatures = read_txt_signatures()
    print(f"找到 {len(signatures)} 个函数签名")

    # 遍历所有 Ptr_Func_*.cs 文件
    dir_path = r"c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9"

    for filename in os.listdir(dir_path):
        if filename.startswith('Ptr_Func_') and filename.endswith('.cs'):
            file_path = os.path.join(dir_path, filename)
            if process_cs_file(file_path, signatures):
                print(f"已处理: {filename}")
            else:
                print(f"跳过: {filename}")

if __name__ == '__main__':
    main()
