# 批量修改 Ptr_Func_*.cs 文件
$directory = "c:/Users/NBNN_IT_CODE/source/repos/blackmaple/Maple.RenderSpy.Graphics/Maple.RenderSpy.Graphics.D3D9/COM_Direct3DDevice9"

Get-ChildItem -Path $directory -Filter "Ptr_Func_*.cs" | ForEach-Object {
    $file = $_.FullName
    $content = Get-Content $file -Raw -Encoding UTF8

    # 检查是否已经修改过（包含 COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>）
    if ($content -match "COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>") {
        Write-Host "已修改: $file"
        continue
    }

    # 替换 COM_PTR_IUNKNOWN 为 COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>
    $content = $content -replace 'COM_PTR_IUNKNOWN,', 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>,'
    $content = $content -replace 'COM_PTR_IUNKNOWN>', 'COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>'

    # 替换 int 返回值为 COM_HRESULT（在 delegate 定义中）
    $content = $content -regex 'delegate\*\s+unmanaged\[Stdcall\]<(.*?)>\s+_proc', {
        param($match)
        $signature = $match.Groups[1].Value
        # 将最后的 int 改为 COM_HRESULT
        $signature = $signature -replace ',\s*int$', ', COM_HRESULT'
        "delegate* unmanaged[Stdcall]<$signature> _proc"
    }

    # 替换 Invoke 方法的返回值 int 为 COM_HRESULT
    $content = $content -replace 'public int Invoke\(', 'public COM_HRESULT Invoke('

    # 替换自定义结构体指针为 nint
    $content = $content -replace '(D3DRECT|D3DMATRIX|RECT|D3DVIEWPORT9|D3DINDEXBUFFER_DESC|D3DVERTEXBUFFER_DESC|D3DSURFACE_DESC|D3DVOLUME_DESC|D3DCONTENTSTATISTICS|D3DDEVINFO_D3D9BUSTATS|D3DDEVINFO_D3D9PIPELINETIMINGS|D3DDEVINFO_D3D9INTERFACETIMINGS|D3DDEVINFO_D3D9STAGETIMINGS|D3DDEVINFO_D3D9BANDWIDTHTIMINGS|D3DDEVINFO_D3D9CACHEUTILIZATION|D3DVERTEXELEMENT9)\*', 'nint'

    # 替换 void* 为 nint
    $content = $content -replace 'void\*', 'nint'

    # 替换 void** 为 nint
    $content = $content -replace 'void\*\*', 'nint'

    # 替换基础类型指针为 nint
    $content = $content -replace '(uint|float|int|byte)\*', 'nint'

    # 替换 HANDLE* 为 nint
    $content = $content -replace 'HANDLE\*', 'nint'

    # 替换 Invoke 方法中的指针参数
    $content = $content -replace '(D3DRECT|D3DMATRIX|RECT|D3DVIEWPORT9|D3DINDEXBUFFER_DESC|D3DVERTEXBUFFER_DESC|D3DSURFACE_DESC|D3DVOLUME_DESC|D3DVIEWPORT9)\s+(\w+)\)', 'nint $2)'

    # 添加原函数指针注释（如果还没有）
    if (-not $content -match '// 原函数指针:') {
        $content = $content -replace 'private readonly delegate\*', '// 原函数指针: private readonly delegate*'
    }

    Set-Content $file -Value $content -Encoding UTF8 -NoNewline
    Write-Host "已处理: $file"
}
