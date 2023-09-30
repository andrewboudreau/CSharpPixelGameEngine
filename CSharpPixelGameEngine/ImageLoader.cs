using System.Drawing;
using System.IO;

namespace CSharpPixelGameEngine;

public interface IImageLoader
{
    RCode LoadImageResource(Sprite sprite, string imageFile, ResourcePack pack);
    RCode SaveImageResource(Sprite sprite, string imageFile);
}

public class ImageLoader : IImageLoader
{
    public RCode LoadImageResource(Sprite sprite, string imageFile, ResourcePack pack)
    {
        try
        {
            using (Bitmap bitmap = new Bitmap(imageFile))
            {
                sprite.Width = bitmap.Width;
                sprite.Height = bitmap.Height;
                sprite.PixelData = new List<Pixel>(sprite.Width * sprite.Height);

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);
                        sprite.PixelData.Add(ConvertToPixel(color));
                    }
                }
            }
            return RCode.OK;
        }
        catch (Exception ex)
        {
            // Log exception details
            Console.WriteLine(ex.Message);
            return RCode.FAIL;
        }
    }

    public RCode SaveImageResource(Sprite sprite, string imageFile)
    {
        try
        {
            using (Bitmap bitmap = new Bitmap(sprite.Width, sprite.Height))
            {
                for (int y = 0; y < sprite.Height; y++)
                {
                    for (int x = 0; x < sprite.Width; x++)
                    {
                        Pixel pixel = sprite.PixelData[y * sprite.Width + x];
                        bitmap.SetPixel(x, y, ConvertToColor(pixel));
                    }
                }
                bitmap.Save(imageFile);
            }
            return RCode.OK;
        }
        catch (Exception ex)
        {
            // Log exception details
            Console.WriteLine(ex.Message);
            return RCode.FAIL;
        }
    }

    private Pixel ConvertToPixel(Color color)
    {
        return new Pixel(color.R, color.G, color.B, color.A);
    }

    private Color ConvertToColor(Pixel pixel)
    {
        return Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
    }
}
