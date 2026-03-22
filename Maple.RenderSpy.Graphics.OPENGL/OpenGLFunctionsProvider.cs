using System.Runtime.InteropServices;
using Windows.Win32;

namespace Maple.RenderSpy.Graphics.OPENGL
{
    public class OpenGLFunctionsProvider : IRenderSpyGraphicsFunctionsProvider
    {
        public Dictionary<string, nint> Functions => throw new NotImplementedException();

        const string LibraryName = "opengl32.dll";
        const string EntryPoint = "wglSwapBuffers";

        public static IRenderSpyGraphicsFunctionsProvider Create()
        {
          var proc =   PInvoke.wglGetProcAddress("wglSwapBuffers");
            if (proc == IntPtr.Zero) 
            {
                if (NativeLibrary.TryLoad(LibraryName, out var dll))
                {
                    NativeLibrary.TryGetExport(dll, "wglSwapBuffers", out var address);
                }
            }
             
        }





    }
}
