using Maple.UnmanagedExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace Maple.RenderSpy.Graphics
{
    public class RenderSpyGraphicsException(string? msg) : Exception(msg)
    {
        [DoesNotReturn]
        public static void Throw(string? msg = default) => throw new RenderSpyGraphicsException(msg);

        [DoesNotReturn]
        public static T Throw<T>(string? msg = default) => throw new RenderSpyGraphicsException(msg);
    }



}
