$files = Get-ChildItem -Path "Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9" -Filter "D3D9*.cs"

foreach ($file in $files) {
    if ($file.Name -eq "D3D9BeginSceneHookItem.cs" -or $file.Name -eq "D3D9SetTextureHookItem.cs") {
        Write-Host "跳过: $($file.Name)"
        continue
    }

    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $className = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)

    # 替换基类
    $content = $content -replace "HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>", "HookItem<$className, `$1, `$2>"
    
    # 替换 TryGet
    $content = $content -replace '\.TryGet\(out var hookItem\)', "$className.TryGet(out var hookItem)"

    Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline
    Write-Host "已更新: $($file.Name)"
}

Write-Host "完成!"
