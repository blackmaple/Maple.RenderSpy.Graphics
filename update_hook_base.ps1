$hookDir = "c:\Users\Black\source\repos\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

$filesToUpdate = @()
$files = Get-ChildItem -Path $hookDir -Filter "*.cs"

foreach ($file in $files) {
    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8

    # 检查是否使用了旧格式 (只有2个泛型参数)
    if ($content -match 'HookItem<(Ptr_Func_\w+),\s*(Ptr_Func_\w+)>') {
        $oldBase = $matches[0]
        $className = $file.BaseName
        $ptrFunc1 = $matches[1]
        $ptrFunc2 = $matches[2]

        $newBase = "HookItem<$className, $ptrFunc1, $ptrFunc2>"

        # 替换
        $newContent = $content -replace [regex]::Escape($oldBase), $newBase

        # 写回文件
        Set-Content -Path $file.FullName -Value $newContent -Encoding UTF8

        $filesToUpdate += @{
            File = $file.Name
            Old = $oldBase
            New = $newBase
        }

        Write-Host "Updated: $($file.Name)"
        Write-Host "  Old: $oldBase"
        Write-Host "  New: $newBase"
        Write-Host ""
    }
}

Write-Host "总计更新了 $($filesToUpdate.Count) 个文件"
