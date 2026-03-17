# 更新 Ptr_Func_*.cs 文件
$ErrorActionPreference = "Stop"

$folderPath = "c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\COM_Direct3DDevice9"

# 获取所有 Ptr_Func_*.cs 文件
$files = Get-ChildItem -Path $folderPath -Filter "Ptr_Func_*.cs" | Sort-Object Name

Write-Host "找到 $($files.Count) 个文件" -ForegroundColor Cyan

$updatedCount = 0
$skippedCount = 0

foreach ($file in $files) {
    Write-Host "`n处理文件: $($file.Name)" -ForegroundColor Yellow
    
    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    
    # 检查是否已经更新
    if ($content -match 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>') {
        Write-Host "  文件已更新，跳过" -ForegroundColor Gray
        $skippedCount++
        continue
    }
    
    # 检查是否已有原函数指针注释
    if ($content -match '// 原函数指针:') {
        Write-Host "  文件已包含原函数指针注释，跳过" -ForegroundColor Gray
        $skippedCount++
        continue
    }
    
    # 查找函数指针声明
    if ($content -match 'private readonly delegate\* unmanaged\[Stdcall\]<(?<params>[^>]+)>\s*_proc\s*=') {
        $params = $matches['params']
        Write-Host "  找到函数指针: $params"
        
        # 提取完整的函数指针行
        $procMatch = [regex]::Match($content, '(private readonly delegate\* unmanaged\[Stdcall\]<[^>]+>\s*)_proc\s*=\s*\([^)]+\)\s*ptr;')
        
        if ($procMatch.Success) {
            $originalProc = $procMatch.Groups[1].Value + "_proc = " + $procMatch.Value.Substring($procMatch.Value.IndexOf('=') + 1).Trim()
            
            # 构建新内容
            $newContent = $content -replace '(private readonly delegate\* unmanaged\[Stdcall\]<[^>]+>\s*)_proc\s*=\s*\([^)]+\)\s*ptr;', "// 原函数指针: `$1_proc = (delegate* unmanaged[Stdcall]<`$1>)ptr;`n`$0"
            
            # 处理新函数指针
            $newContent = $newContent -replace 'COM_PTR_IUNKNOWN,?', 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>,'
            $newContent = $newContent -replace 'COM_PTR_IUNKNOWN>', 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>'
            
            # 替换 void* 为 nint
            $newContent = $newContent -replace 'void\*', 'nint'
            $newContent = $newContent -replace 'HANDLE\*', 'nint'
            
            # 替换基础类型指针为 UnsafeRef
            $newContent = $newContent -replace 'uint\*', 'UnsafeRef<uint>'
            $newContent = $newContent -replace 'int\*', 'UnsafeRef<int>'
            $newContent = $newContent -replace 'float\*', 'UnsafeRef<float>'
            $newContent = $newContent -replace 'BOOL\*', 'UnsafeRef<int>'
            
            # 替换 D3DRECT* 等为 nint
            $d3dTypes = @('D3DRECT\*', 'D3DMATRIX\*', 'D3DVIEWPORT9\*', 'D3DDEVICE_CREATION_PARAMETERS\*', 
                         'D3DDISPLAYMODE\*', 'D3DCAPS9\*', 'D3DADAPTER_IDENTIFIER9\*', 'D3DGAMMARAMP\*', 
                         'D3DSURFACE_DESC\*', 'D3DVERTEXELEMENT9\*', 'PALETTEENTRY\*', 'D3DCLIPSTATUS\*', 
                         'D3DRASTER_STATUS\*', 'D3DLOCKED_RECT\*', 'D3DBOX\*', 'D3DLOCKED_BOX\*', 
                         'D3DPRESENT_PARAMETERS\*', 'IDirect3DSurface9\*\*', 'IDirect3DBaseTexture9\*\*', 
                         'IDirect3DTexture9\*\*', 'IDirect3DCubeTexture9\*\*', 'IDirect3DVolumeTexture9\*\*', 
                         'IDirect3DVertexBuffer9\*\*', 'IDirect3DIndexBuffer9\*\*', 'IDirect3DDevice9\*\*', 
                         'IDirect3DVertexDeclaration9\*\*', 'IDirect3DVertexShader9\*\*', 
                         'IDirect3DPixelShader9\*\*', 'IDirect3DQuery9\*\*')
            
            foreach ($type in $d3dTypes) {
                $newContent = $newContent -replace $type, 'nint'
            }
            
            # 替换返回值 int 为 COM_HRESULT
            $newContent = $newContent -replace ', int>\s*_proc', ', COM_HRESULT> _proc'
            $newContent = $newContent -replace ', int>\s*_newProc', ', COM_HRESULT> _newProc'
            
            # 处理 Invoke 方法
            $newContent = $newContent -replace 'public int Invoke\(', 'public COM_HRESULT Invoke('
            
            # Invoke 方法中的参数替换
            $newContent = $newContent -replace 'COM_PTR_IUNKNOWN\s+pThis', 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis'
            
            # Invoke 中的 void* 替换
            $invokeMatch = [regex]::Match($newContent, 'public COM_HRESULT Invoke\([^)]+\)')
            if ($invokeMatch.Success) {
                $invokeLine = $invokeMatch.Value
                $invokeLine = $invokeLine -replace 'void\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'nint `$1'
                $invokeLine = $invokeLine -replace 'void\*\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'nint `$1'
                $invokeLine = $invokeLine -replace 'HANDLE\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'nint `$1'
                $invokeLine = $invokeLine -replace 'uint\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'UnsafeRef<uint> `$1'
                $invokeLine = $invokeLine -replace 'int\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'UnsafeRef<int> `$1'
                $invokeLine = $invokeLine -replace 'float\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'UnsafeRef<float> `$1'
                $invokeLine = $invokeLine -replace 'BOOL\*\s+([a-zA-Z_][a-zA-Z0-9_]*)', 'UnsafeRef<int> `$1'
                
                foreach ($type in $d3dTypes) {
                    $invokeLine = $invokeLine -replace $type, 'nint'
                }
                
                $newContent = $newContent.Substring(0, $invokeMatch.Index) + $invokeLine + $newContent.Substring($invokeMatch.Index + $invokeMatch.Length)
            }
            
            # 保存文件
            Set-Content -Path $file.FullName -Value $newContent -Encoding UTF8
            Write-Host "  已更新" -ForegroundColor Green
            $updatedCount++
        }
        else {
            Write-Host "  未找到匹配的函数指针声明" -ForegroundColor Red
        }
    }
    else {
        Write-Host "  未找到函数指针声明" -ForegroundColor Red
    }
}

Write-Host "`n`n更新完成！" -ForegroundColor Cyan
Write-Host "已更新: $updatedCount 个文件" -ForegroundColor Green
Write-Host "跳过: $skippedCount 个文件" -ForegroundColor Gray
