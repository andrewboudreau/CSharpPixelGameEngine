namespace olc
{
#if defined(OLC_GFX_HEADLESS)
	class Renderer_Headless : public olc::Renderer
	{
	public:
		virtual void       PrepareDevice() {};
		virtual olc::rcode CreateDevice(std::vector<void*> params, bool bFullScreen, bool bVSYNC) { return olc::rcode::OK;		}
		virtual olc::rcode DestroyDevice() { return olc::rcode::OK; }
		virtual void       DisplayFrame() {}
		virtual void       PrepareDrawing() {}
		virtual void	   SetDecalMode(const olc::DecalMode& mode) {}
		virtual void       DrawLayerQuad(const olc::vf2d& offset, const olc::vf2d& scale, const olc::Pixel tint) {}
		virtual void       DrawDecal(const olc::DecalInstance& decal) {}
		virtual uint32_t   CreateTexture(const uint32_t width, const uint32_t height, const bool filtered = false, const bool clamp = true) {return 1;};
		virtual void       UpdateTexture(uint32_t id, olc::Sprite* spr) {}
		virtual void       ReadTexture(uint32_t id, olc::Sprite* spr) {}
		virtual uint32_t   DeleteTexture(const uint32_t id) {return 1;}
		virtual void       ApplyTexture(uint32_t id) {}
		virtual void       UpdateViewport(const olc::vi2d& pos, const olc::vi2d& size) {}
		virtual void       ClearBuffer(olc::Pixel p, bool bDepth) {}
	};
#endif
#if defined(OLC_PLATFORM_HEADLESS)
	class Platform_Headless : public olc::Platform
	{
	public:
		virtual olc::rcode ApplicationStartUp() { return olc::rcode::OK; }
		virtual olc::rcode ApplicationCleanUp() { return olc::rcode::OK; }
		virtual olc::rcode ThreadStartUp() { return olc::rcode::OK; }
		virtual olc::rcode ThreadCleanUp() { return olc::rcode::OK; }
		virtual olc::rcode CreateGraphics(bool bFullScreen, bool bEnableVSYNC, const olc::vi2d& vViewPos, const olc::vi2d& vViewSize) { return olc::rcode::OK; }
		virtual olc::rcode CreateWindowPane(const olc::vi2d& vWindowPos, olc::vi2d& vWindowSize, bool bFullScreen) { return olc::rcode::OK; }
		virtual olc::rcode SetWindowTitle(const std::string& s) { return olc::rcode::OK; }
		virtual olc::rcode StartSystemEventLoop() { return olc::rcode::OK; }
		virtual olc::rcode HandleSystemEvent() { return olc::rcode::OK; }
	};
#endif
}
