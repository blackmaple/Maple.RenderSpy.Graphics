$hookDir = "c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

$files = Get-ChildItem -Path $hookDir -Filter "*.cs"

$updatedCount = 0

foreach ($file in $files) {
    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $originalContent = $content

    # 修正 SyncCallback 声明 - 移除最后的 HookItem 参数
    # 模式1: public Func<..., D3D9XXXHookItem, COM_HRESULT>
    $content = $content -replace '(public Func<.*?),\s*(D3D9\w+HookItem),\s*(COM_HRESULT|int|uint|float)\?(\? SyncCallback)', '$1, $3$2'

    # 模式2: public Func<..., D3D9XXXHookItem>? SyncCallback
    $content = $content -replace '(public Func<.*?),\s*(D3D9\w+HookItem)\?(\? SyncCallback)', '$1$2'

    # 修正 SyncCallback.Invoke 调用 - 移除最后的 hookItem 参数
    $content = $content -replace 'SyncCallback\.Invoke\((.*?)\),\s*hookItem\)', 'SyncCallback.Invoke($1)'

    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -Encoding UTF8
        $updatedCount++
        Write-Host "Updated: $($file.Name)"
    }
}

Write-Host "总计更新了 $updatedCount 个文件"
