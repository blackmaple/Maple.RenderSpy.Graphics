#!/usr/bin/env python3
"""
Generate D3D9 Hook files based on function signatures.
This script reads Ptr_Func files and generates corresponding HookItem files.
"""

import os
import re
from pathlib import Path

# Base directories
BASE_DIR = r"c:\Users\NBNN_IT_CODE\source\repos\blackmaple\Maple.RenderSpy.Graphics"
HOOK_DIR = os.path.join(BASE_DIR, "Maple.RenderSpy.Graphics.D3D9", "Hook_Direct3DDevice9")
PTR_FUNC_DIR = os.path.join(BASE_DIR, "Maple.RenderSpy.Graphics.D3D9", "COM_Direct3DDevice9")

# Function template for simple functions (only @this parameter)
SIMPLE_TEMPLATE = """using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.Hook_Direct3DDevice9
{{
    internal class {class_name} : HookItem<{ptr_func_name}, {ptr_func_name}>, IHookItemFactory<{class_name}>
    {{
        public const string MethodName = {ptr_func_name}.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {class_name}, {return_type}>? SyncCallback {{ get; set; }}

        public static {class_name} Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {{
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {{
                return RenderSpyGraphicsException.Throw<{class_name}>($"NOT FOUND {{MethodName}}");
            }}
            var hookItemImp = hookFactory.Create<{class_name}>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }}

        private static unsafe nint GetHookMethodPointer()
        {{
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, {return_type}>
                _proc = &Hook_{method_name};
            return new(_proc);
        }}

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static {return_type} Hook_{method_name}(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this)
        {{
            if (IHookFactory.TryGet<{class_name}>(out var hookItem))
            {{
                if (hookItem.SyncCallback is not null)
                {{
                    return hookItem.SyncCallback.Invoke(@this, hookItem);
                }}
                return hookItem.OriginalMethod.Invoke(@this);
            }}
            return default({return_type});
        }}
    }}
}}
"""

# Functions to skip (already created or special cases)
SKIP_FUNCTIONS = {
    "TestCooperativeLevel",  # Already created
    "Reset",                 # Already created
    "EndScene",              # Already created
    "BeginScene",            # Already created
    "Clear",                 # Already created
}

def extract_function_info(file_path):
    """Extract function name, index, and return type from Ptr_Func file."""
    try:
        with open(file_path, 'r', encoding='utf-8') as f:
            content = f.read()

        # Extract function name
        name_match = re.search(r'public const string Name = "(.*?)"', content)
        if not name_match:
            return None
        name = name_match.group(1)

        # Extract function index from file name
        index_match = re.search(r'Ptr_Func_(.+)_(\d+)', os.path.basename(file_path))
        if not index_match:
            return None
        func_name = index_match.group(1)
        index = index_match.group(2)

        # Extract return type from delegate signature
        # Look for pattern: delegate* unmanaged[Stdcall]<..., RETURN_TYPE> _proc
        delegate_match = re.search(r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>(?:, [^>]+)*, (int|uint|void|float|COM_HRESULT)>', content)
        if not delegate_match:
            # Try alternative pattern for COM_PTR_IUNKNOWN without generic
            delegate_match = re.search(r'delegate\* unmanaged\[Stdcall\]<COM_PTR_IUNKNOWN(?:, [^>]+)*, (int|uint|void|float|COM_HRESULT)>', content)

        if not delegate_match:
            return None
        return_type = delegate_match.group(1)

        return {
            'name': name,
            'func_name': func_name,
            'index': index,
            'return_type': return_type,
            'ptr_func_name': f'Ptr_Func_{func_name}_{index}',
            'class_name': f'D3D9{name}HookItem'
        }
    except Exception as e:
        print(f"Error reading {file_path}: {e}")
        return None

def generate_hook_file(func_info):
    """Generate Hook file content for a function."""
    class_name = func_info['class_name']
    ptr_func_name = func_info['ptr_func_name']
    method_name = func_info['name']
    return_type = func_info['return_type']

    # Use simple template for now (functions with only @this parameter)
    return SIMPLE_TEMPLATE.format(
        class_name=class_name,
        ptr_func_name=ptr_func_name,
        method_name=method_name,
        return_type=return_type
    )

def main():
    """Main function to generate all Hook files."""
    # Ensure hook directory exists
    os.makedirs(HOOK_DIR, exist_ok=True)

    # Find all Ptr_Func files
    ptr_func_files = []
    for file in os.listdir(PTR_FUNC_DIR):
        if file.startswith('Ptr_Func_') and file.endswith('.cs'):
            ptr_func_files.append(os.path.join(PTR_FUNC_DIR, file))

    # Sort files by index
    ptr_func_files.sort(key=lambda x: int(re.search(r'_(\d+)\.cs$', x).group(1)) if re.search(r'_(\d+)\.cs$', x) else 0)

    generated_count = 0
    for ptr_func_file in ptr_func_files:
        func_info = extract_function_info(ptr_func_file)
        if not func_info:
            print(f"Skipping {ptr_func_file}: could not extract function info")
            continue

        if func_info['name'] in SKIP_FUNCTIONS:
            print(f"Skipping {func_info['name']}: already created or special case")
            continue

        # Generate hook file
        hook_content = generate_hook_file(func_info)
        hook_file_path = os.path.join(HOOK_DIR, f"{func_info['class_name']}.cs")

        # Write file
        try:
            with open(hook_file_path, 'w', encoding='utf-8') as f:
                f.write(hook_content)
            print(f"Created: {func_info['class_name']}.cs")
            generated_count += 1
        except Exception as e:
            print(f"Error writing {hook_file_path}: {e}")

    print(f"\nGenerated {generated_count} Hook files")

if __name__ == "__main__":
    main()
