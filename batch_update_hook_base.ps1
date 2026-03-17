# 批量更新 HOOK_Direct3DDevice9 文件夹中的基类和 TryGet 调用
$hookDir = "c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics\Maple.RenderSpy.Graphics.D3D9\HOOK_Direct3DDevice9"

# 获取所有 D3D9*.cs 文件
$files = Get-ChildItem -Path $hookDir -Filter "D3D9*.cs" -File

foreach ($file in $files) {
    if ($file.Name -eq "D3D9BeginSceneHookItem.cs") {
        Write-Host "跳过已更新的文件: $($file.Name)" -ForegroundColor Green
        continue
    }

    $content = Get-Content -Path $file.FullName -Raw -Encoding UTF8

    # 提取类名
    $className = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)

    # 替换基类声明：HookItem<Ptr_Func_XXX, Ptr_Func_XXX> -> HookItem<D3D9XXXHookItem, Ptr_Func_XXX, Ptr_Func_XXX>
    $content = $content -replace "HookItem<(Ptr_Func_\d+), (Ptr_Func_\d+)>", "HookItem<$className, `$1, `$2>"

    # 替换 TryGet 调用：IHookFactory.TryGet<D3D9XXXHookItem> -> D3D9XXXHookItem.TryGet
    $content = $content -replace "IHookFactory\.TryGet<$className\(\)?>", "$className.TryGet"

    # 保存文件
    Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -NoNewline

    Write-Host "已更新: $($file.Name)" -ForegroundColor Cyan
}

Write-Host "`n批量更新完成!" -ForegroundColor Green
