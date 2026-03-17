# 简单批量更新脚本
$hookDir = "Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
$updated = @('D3D9BeginSceneHookItem.cs', 'D3D9SetTextureHookItem.cs', 'D3D9ClearHookItem.cs', 
             'D3D9DrawPrimitiveHookItem.cs', 'D3D9PresentHookItem.cs', 'D3D9EndSceneHookItem.cs',
             'D3D9GetPixelShaderHookItem.cs', 'D3D9SetPixelShaderHookItem.cs', 'D3D9CreateTextureHookItem.cs', 
             'D3D9CreateVertexShaderHookItem.cs', 'D3D9ResetHookItem.cs', 'D3D9SetRenderStateHookItem.cs')

$files = Get-ChildItem -Path $hookDir -Filter "D3D9*.cs"

foreach ($file in $files) {
    if ($file.Name -in $updated) {
        Write-Host "跳过: $($file.Name)"
        continue
    }

    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8

    # 查找并替换基类声明
    if ($content -match 'HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>') {
        $className = $file.BaseName
        $oldPattern = $matches[0]
        $newPattern = "HookItem<$className, $($matches[1]), $($matches[2])>"
        
        $content = $content -replace [regex]::Escape($oldPattern), $newPattern

        Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline
        Write-Host "已更新: $($file.Name) - $oldPattern -> $newPattern"
    } else {
        Write-Host "无需更新: $($file.Name)"
    }
}

Write-Host "完成!"
