#define USE_EXPERIMENTAL_FS
#if defined(_WIN32)
	#if _MSC_VER >= 1920 && _MSVC_LANG >= 201703L
		#undef USE_EXPERIMENTAL_FS
	#endif
#endif
#if defined(__linux__) || defined(__MINGW32__) || defined(__EMSCRIPTEN__) || defined(__FreeBSD__) || defined(__APPLE__)
	#if __cplusplus >= 201703L
		#undef USE_EXPERIMENTAL_FS
	#endif
#endif

#if !defined(OLC_KEYBOARD_UK)
	#define OLC_KEYBOARD_UK
#endif


#if defined(USE_EXPERIMENTAL_FS) || defined(FORCE_EXPERIMENTAL_FS)
	// C++14
	#define _SILENCE_EXPERIMENTAL_FILESYSTEM_DEPRECATION_WARNING
	#include <experimental/filesystem>
	namespace _gfs = std::experimental::filesystem::v1;
#else
	// C++17
	#include <filesystem>
	namespace _gfs = std::filesystem;
#endif

#if defined(UNICODE) || defined(_UNICODE)
	#define olcT(s) L##s
#else
	#define olcT(s) s
#endif

#define UNUSED(x) (void)(x)

// O------------------------------------------------------------------------------O
// | PLATFORM SELECTION CODE, Thanks slavka!                                      |
// O------------------------------------------------------------------------------O

#if defined(OLC_PGE_HEADLESS)
	#define OLC_PLATFORM_HEADLESS
	#define OLC_GFX_HEADLESS
	#if !defined(OLC_IMAGE_STB) && !defined(OLC_IMAGE_GDI) && !defined(OLC_IMAGE_LIBPNG)
		#define OLC_IMAGE_HEADLESS
	#endif
#endif

// Platform
#if !defined(OLC_PLATFORM_WINAPI) && !defined(OLC_PLATFORM_X11) && !defined(OLC_PLATFORM_GLUT) && !defined(OLC_PLATFORM_EMSCRIPTEN) && !defined(OLC_PLATFORM_HEADLESS)
	#if !defined(OLC_PLATFORM_CUSTOM_EX)
		#if defined(_WIN32)
			#define OLC_PLATFORM_WINAPI
		#endif
		#if defined(__linux__) || defined(__FreeBSD__)
			#define OLC_PLATFORM_X11
		#endif
		#if defined(__APPLE__)
			#define GL_SILENCE_DEPRECATION
			#define OLC_PLATFORM_GLUT
		#endif
		#if defined(__EMSCRIPTEN__)
			#define OLC_PLATFORM_EMSCRIPTEN
		#endif
	#endif
#endif

// Start Situation
#if defined(OLC_PLATFORM_GLUT) || defined(OLC_PLATFORM_EMSCRIPTEN)
	#define PGE_USE_CUSTOM_START
#endif



// Renderer
#if !defined(OLC_GFX_OPENGL10) && !defined(OLC_GFX_OPENGL33) && !defined(OLC_GFX_DIRECTX10) && !defined(OLC_GFX_HEADLESS)
	#if !defined(OLC_GFX_CUSTOM_EX)
		#if defined(OLC_PLATFORM_EMSCRIPTEN)
			#define OLC_GFX_OPENGL33
		#else
			#define OLC_GFX_OPENGL10
		#endif
	#endif
#endif

// Image loader
#if !defined(OLC_IMAGE_STB) && !defined(OLC_IMAGE_GDI) && !defined(OLC_IMAGE_LIBPNG) && !defined(OLC_IMAGE_HEADLESS)
	#if !defined(OLC_IMAGE_CUSTOM_EX)
		#if defined(_WIN32)
			#define	OLC_IMAGE_GDI
		#endif
		#if defined(__linux__) || defined(__APPLE__) || defined(__FreeBSD__) || defined(__EMSCRIPTEN__)
			#define	OLC_IMAGE_LIBPNG
		#endif
	#endif
#endif


// O------------------------------------------------------------------------------O
// | PLATFORM-SPECIFIC DEPENDENCIES                                               |
// O------------------------------------------------------------------------------O
#if !defined(OLC_PGE_HEADLESS)
#if defined(OLC_PLATFORM_WINAPI)	
	#define _WINSOCKAPI_ // Thanks Cornchipss
		#if !defined(VC_EXTRALEAN)
		#define VC_EXTRALEAN
	#endif
	#if !defined(NOMINMAX)
		#define NOMINMAX
	#endif

	// In Code::Blocks
	#if !defined(_WIN32_WINNT)
		#ifdef HAVE_MSMF
			#define _WIN32_WINNT 0x0600 // Windows Vista
		#else
			#define _WIN32_WINNT 0x0500 // Windows 2000
		#endif
	#endif

	#include <windows.h>
	#undef _WINSOCKAPI_
#endif

#if defined(OLC_PLATFORM_X11)
	namespace X11
	{
		#include <X11/X.h>
		#include <X11/Xlib.h>
	}
#endif

#if defined(OLC_PLATFORM_GLUT)
	#if defined(__linux__)
		#include <GL/glut.h>
		#include <GL/freeglut_ext.h>
	#endif
	#if defined(__APPLE__)
		#include <GLUT/glut.h>
	#include <objc/message.h>
	#include <objc/NSObjCRuntime.h>
	#endif
#endif
#endif

#if defined(OLC_PGE_HEADLESS)
#if defined max
#undef max
#endif
#if defined min
#undef min
#endif
#endif
