$files = Get-ChildItem -Path "Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9" -Filter "D3D9*.cs"

foreach ($file in $files) {
    if ($file.Name -eq "D3D9BeginSceneHookItem.cs" -or $file.Name -eq "D3D9SetTextureHookItem.cs" -or 
        $file.Name -eq "D3D9ClearHookItem.cs" -or $file.Name -eq "D3D9DrawPrimitiveHookItem.cs") {
        Write-Host "跳过已更新: $($file.Name)"
        continue
    }

    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8
    $className = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)

    # 只更新基类
    $content = $content -replace "HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>", "HookItem<$className, `$1, `$2>"

    Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline
    Write-Host "已更新基类: $($file.Name)"
}

Write-Host "基类更新完成!"
