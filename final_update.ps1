# 最终批量更新脚本
$hookDir = "Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
$updated = @('D3D9BeginSceneHookItem.cs', 'D3D9SetTextureHookItem.cs', 'D3D9ClearHookItem.cs', 
             'D3D9DrawPrimitiveHookItem.cs', 'D3D9PresentHookItem.cs', 'D3D9EndSceneHookItem.cs',
             'D3D9GetPixelShaderHookItem.cs', 'D3D9SetPixelShaderHookItem.cs', 'D3D9CreateTextureHookItem.cs', 
             'D3D9CreateVertexShaderHookItem.cs')

$files = Get-ChildItem -Path $hookDir -Filter "D3D9*.cs"
$count = 0

foreach ($file in $files) {
    if ($file.Name -in $updated) {
        Write-Host "跳过: $($file.Name)"
        continue
    }

    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $className = $file.BaseName

    # 检查是否需要更新
    if ($content -match "HookItem<Ptr_Func_\d+, Ptr_Func_\d+>") {
        # 替换基类
        $oldBase = [regex]::Match($content, "HookItem<Ptr_Func_\d+, Ptr_Func_\d+>").Value
        $newBase = "HookItem<$className, $([regex]::Match($oldBase, 'Ptr_Func_\d+').Value), $([regex]::Match($oldBase, 'Ptr_Func_\d+').Value)>"
        $content = $content.Replace($oldBase, $newBase)

        Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline
        Write-Host "已更新: $($file.Name)"
        $count++
    } else {
        Write-Host "无需更新: $($file.Name)"
    }
}

Write-Host "`n总计更新 $count 个文件"
