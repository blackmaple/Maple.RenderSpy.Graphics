import os
import re

# 目录路径
hook_dir = r'c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9'

# 遍历所有 .cs 文件
for filename in os.listdir(hook_dir):
    if filename.endswith('.cs'):
        filepath = os.path.join(hook_dir, filename)
        
        # 读取文件内容
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()
        
        original_content = content
        
        # 修正 SyncCallback 声明 - 移除最后的 HookItem 参数
        # 匹配模式: public Func<..., D3D9XXXHookItem, COM_HRESULT>
        pattern1 = r'public Func<(.*?),\s*(D3D9\w+HookItem),\s*(COM_HRESULT|int|uint|float)>'
        content = re.sub(pattern1, r'public Func<\1, \3>', content)
        
        # 修正 SyncCallback 声明 - 移除最后的 HookItem 参数 (其他返回类型)
        pattern2 = r'public Func<(.*?),\s*(D3D9\w+HookItem)>'
        content = re.sub(pattern2, r'public Func<\1>', content)
        
        # 修正 SyncCallback.Invoke 调用 - 移除最后的 hookItem 参数
        pattern3 = r'SyncCallback\.Invoke\((.*?)\),\s*hookItem\)'
        content = re.sub(pattern3, r'SyncCallback.Invoke(\1)', content)
        
        # 如果有修改，写回文件
        if content != original_content:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(content)
            print(f'Updated: {filename}')

print('Done!')
