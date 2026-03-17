# 批量修改 HOOK_Direct3DDevice9 文件夹中的所有 HOOK 文件
$directory = "c:/Users/NBNN_IT_CODE/source/repos/blackmaple/Maple.RenderSpy.Graphics/Maple.RenderSpy.Graphics.D3D9/HOOK_Direct3DDevice9"

Get-ChildItem -Path $directory -Filter "D3D9*.cs" | ForEach-Object {
    $file = $_.FullName
    $content = Get-Content $file -Raw -Encoding UTF8

    # 检查是否已经修改过（包含 COM_HRESULT）
    if ($content -match 'COM_HRESULT\? SyncCallback') {
        Write-Host "已修改: $file"
        continue
    }

    # 替换 SyncCallback 的返回值 int 为 COM_HRESULT
    $content = $content -replace 'Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(.*?)> SyncCallback', {
        param($match)
        $params = $match.Groups[1].Value
        # 将最后的 int 改为 COM_HRESULT
        $params = $params -replace ',\s*int> SyncCallback', ', COM_HRESULT> SyncCallback'
        "Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>$params"
    }

    # 替换函数指针签名中的 int 为 COM_HRESULT
    $content = $content -regex 'delegate\*\s+unmanaged\[Stdcall\]<(.*?)>\s+_proc', {
        param($match)
        $signature = $match.Groups[1].Value
        # 将最后的 int 改为 COM_HRESULT
        $signature = $signature -replace ',\s*int>$', ', COM_HRESULT>'
        "delegate* unmanaged[Stdcall]<$signature> _proc"
    }

    # 替换 Hook 方法返回值 int 为 COM_HRESULT
    $content = $content -replace 'private static int Hook_', 'private static COM_HRESULT Hook_'

    # 替换自定义结构体指针为 nint
    $content = $content -replace '(D3DRECT|D3DMATRIX|RECT|D3DVIEWPORT9|D3DINDEXBUFFER_DESC|D3DVERTEXBUFFER_DESC|D3DSURFACE_DESC|D3DVOLUME_DESC|D3DVIEWPORT9)\*', 'nint'

    # 替换 void* 为 nint
    $content = $content -replace 'void\*', 'nint'

    # 替换 void** 为 nint
    $content = $content -replace 'void\*\*', 'nint'

    # 替换 HANDLE* 为 nint
    $content = $content -replace 'HANDLE\*', 'nint'

    # 替换 RGNDATA* 为 nint
    $content = $content -replace 'RGNDATA\*', 'nint'

    # 替换基础类型指针为 nint
    $content = $content -replace '(uint|float|int|byte)\*', 'nint'

    # 替换 Invoke 方法中的参数类型
    $content = $content -replace '\.Invoke\(@this, (D3DRECT|D3DMATRIX|RECT|D3DVIEWPORT9|D3DINDEXBUFFER_DESC|D3DVERTEXBUFFER_DESC|D3DSURFACE_DESC|D3DVOLUME_DESC|D3DVIEWPORT9)\*', '.Invoke(@this, nint'
    $content = $content -replace '\.Invoke\(@this, void\*', '.Invoke(@this, nint'
    $content = $content -replace '\.Invoke\(@this, HANDLE\*', '.Invoke(@this, nint'
    $content = $content -replace '\.Invoke\(@this, RGNDATA\*', '.Invoke(@this, nint'
    $content = $content -replace '\.Invoke\(@this, (uint|float|int|byte)\*', '.Invoke(@this, nint'

    Set-Content $file -Value $content -Encoding UTF8 -NoNewline
    Write-Host "已处理: $file"
}

Write-Host "批量修改完成!"
