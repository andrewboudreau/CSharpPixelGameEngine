using System.Numerics;

namespace CSharpPixelGameEngine;

// DecalMode enum in C#
public enum DecalMode
{
    Normal,
    Additive,
    Multiplicative,
    Stencil,
    Illuminate,
    Wireframe,
    Model3D
}

public enum DecalStructure
{
    Line,
    Fan,
    Strip,
    List
};

public class LayerDesc
{
    public Vector2D Offset { get; set; } = new Vector2D(0, 0);
    public Vector2D Scale { get; set; } = new Vector2D(1, 1);
    public bool Show { get; set; } = false;
    public bool Update { get; set; } = false;
    public Renderable DrawTarget { get; set; }
    public int ResourceId { get; set; } = 0;
    public List<DecalInstance> DecalInstances { get; set; } = new List<DecalInstance>();
    public Pixel Tint { get; set; } = PixelGameEngine.White; 
    // Assuming a static White pixel exists in Pixel class
    
    public Action FuncHook { get; set; }

    public LayerDesc()
    {
        // Default constructor
    }

    // Additional methods as needed...
}


public class DecalInstance
{
    public Decal Decal { get; set; }
    public List<Vector2D> Positions { get; set; } = new List<Vector2D>();
    public List<Vector2D> UVs { get; set; } = new List<Vector2D>();
    public List<float> W { get; set; } = new List<float>();
    public List<Pixel> Tints { get; set; } = new List<Pixel>();
    public DecalMode Mode { get; set; } = DecalMode.Normal;
    public DecalStructure Structure { get; set; } = DecalStructure.Fan;
    public uint Points { get; set; } = 0;

    public DecalInstance()
    {
        // Default constructor
    }

}


public class Decal : IDisposable
{
    public int Id { get; private set; } = -1;

    public Sprite Sprite { get; }

    public Vector2 UVScale { get; private set; } = new Vector2(1.0f, 1.0f);

    private readonly IRenderer renderer;

    public Decal(Sprite sprite, IRenderer renderer, bool filter = false, bool clamp = true)
    {
        ArgumentNullException.ThrowIfNull(renderer);
        this.renderer = renderer;

        if (sprite == null)
        {
            return;
        }

        Sprite = sprite;
        Id = renderer.CreateTexture(Sprite.Width, Sprite.Height, filter, clamp);
        Update();
    }

    public Decal(int existingTextureResource, Sprite sprite, IRenderer renderer)
    {
        ArgumentNullException.ThrowIfNull(renderer);
        this.renderer = renderer;

        if (sprite == null)
        {
            return;
        }

        Sprite = sprite;
        Id = existingTextureResource;
    }

    public void Update()
    {
        if (Sprite == null)
        {
            return;
        }

        UVScale = new Vector2(1.0f / (float)Sprite.Width, 1.0f / (float)Sprite.Height);
        renderer.ApplyTexture(Id);
        renderer.UpdateTexture(Id, Sprite);
    }

    public void UpdateSprite()
    {
        if (Sprite == null)
        {
            return;
        }

        renderer.ApplyTexture(Id);
        renderer.ReadTexture(Id, Sprite);
    }

    public void Dispose()
    {
        if (Id != -1)
        {
            renderer.DeleteTexture(Id);
            Id = -1;
        }
    }
}
