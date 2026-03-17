# 批量更新脚本 - 更新所有剩余文件
$hookDir = "Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"
$files = Get-ChildItem -Path $hookDir -Filter "D3D9*.cs"

$count = 0
foreach ($file in $files) {
    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $className = $file.BaseName

    # 检查是否需要更新
    if ($content -match "internal class $className : HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>") {
        $oldBase = $matches[0]
        $func1 = $matches[1]
        $func2 = $matches[2]
        $newBase = "internal class $className : HookItem<$className, $func1, $func2>"
        
        $content = $content -replace [regex]::Escape($oldBase), $newBase
        Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline
        
        Write-Host "已更新: $($file.Name)"
        $count++
    }
}

Write-Host "`n总计更新 $count 个文件"
