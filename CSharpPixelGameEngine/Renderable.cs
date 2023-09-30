namespace CSharpPixelGameEngine;

public class Renderable
{
    public Sprite Sprite { get; private set; }
    public Decal Decal { get; private set; }
    private readonly IRenderer renderer;

    public Renderable(IRenderer renderer)
    {
        this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
    }

    public void Create(uint width, uint height, bool filter = false, bool clamp = true)
    {
        Sprite = new Sprite(width, height);
        Decal = new Decal(Sprite, renderer, filter, clamp);
    }

    public bool Load(string filePath, ResourcePack? pack = null, bool filter = false, bool clamp = true)
    {
        Sprite = new Sprite();
        if (Sprite.LoadFromFile(filePath, pack) == RCode.OK)
        {
            Decal = new Decal(Sprite, renderer, filter, clamp);
            return true;
        }
        else
        {
            Sprite = null;
            return false;
        }
    }
}

