namespace olc
{
	void PixelGameEngine::olc_ConfigureSystem()
	{

//#if !defined(OLC_PGE_HEADLESS)

		olc::Sprite::loader = nullptr;

#if defined(OLC_IMAGE_GDI)
		olc::Sprite::loader = std::make_unique<olc::ImageLoader_GDIPlus>();
#endif

#if defined(OLC_IMAGE_LIBPNG)
		olc::Sprite::loader = std::make_unique<olc::ImageLoader_LibPNG>();
#endif

#if defined(OLC_IMAGE_STB)
		olc::Sprite::loader = std::make_unique<olc::ImageLoader_STB>();
#endif

#if defined(OLC_IMAGE_CUSTOM_EX)
		olc::Sprite::loader = std::make_unique<OLC_IMAGE_CUSTOM_EX>();
#endif


#if defined(OLC_PLATFORM_HEADLESS)
		platform = std::make_unique<olc::Platform_Headless>();
#endif

#if defined(OLC_PLATFORM_WINAPI)
		platform = std::make_unique<olc::Platform_Windows>();
#endif

#if defined(OLC_PLATFORM_X11)
		platform = std::make_unique<olc::Platform_Linux>();
#endif

#if defined(OLC_PLATFORM_GLUT)
		platform = std::make_unique<olc::Platform_GLUT>();
#endif

#if defined(OLC_PLATFORM_EMSCRIPTEN)
		platform = std::make_unique<olc::Platform_Emscripten>();
#endif

#if defined(OLC_PLATFORM_CUSTOM_EX)
		platform = std::make_unique<OLC_PLATFORM_CUSTOM_EX>();
#endif

#if defined(OLC_GFX_HEADLESS)
		renderer = std::make_unique<olc::Renderer_Headless>();
#endif

#if defined(OLC_GFX_OPENGL10)
		renderer = std::make_unique<olc::Renderer_OGL10>();
#endif

#if defined(OLC_GFX_OPENGL33)
		renderer = std::make_unique<olc::Renderer_OGL33>();
#endif

#if defined(OLC_GFX_OPENGLES2)
		renderer = std::make_unique<olc::Renderer_OGLES2>();
#endif

#if defined(OLC_GFX_DIRECTX10)
		renderer = std::make_unique<olc::Renderer_DX10>();
#endif

#if defined(OLC_GFX_DIRECTX11)
		renderer = std::make_unique<olc::Renderer_DX11>();
#endif

#if defined(OLC_GFX_CUSTOM_EX)
		renderer = std::make_unique<OLC_RENDERER_CUSTOM_EX>();
#endif

		// Associate components with PGE instance
		platform->ptrPGE = this;
		renderer->ptrPGE = this;
//#else
//		olc::Sprite::loader = nullptr;
//		platform = nullptr;
//		renderer = nullptr;
//#endif
	}
}

