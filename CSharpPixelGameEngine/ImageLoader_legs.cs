using System.Drawing;

namespace CSharpPixelGameEngine;

public class ImageLoader1 : IImageLoader
{
    public RCode LoadImageResource(Sprite sprite, string imageFile, ResourcePack pack)
    {
        try
        {
            // Load the image into a Bitmap object
            using (Bitmap bitmap = new Bitmap(imageFile))
            {
                sprite.Width = bitmap.Width;
                sprite.Height = bitmap.Height;

                // Resize the PixelData list to fit the new image
                sprite.PixelData = new List<Pixel>(sprite.Width * sprite.Height);

                // Populate the PixelData list
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);
                        sprite.PixelData.Add(new Pixel(color.R, color.G, color.B, color.A));
                    }
                }
            }
            return RCode.OK;
        }
        catch (Exception)
        {
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
                        Color color = Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
                        bitmap.SetPixel(x, y, color);
                    }
                }

                // Save the bitmap to a file
                bitmap.Save(imageFile);
            }
            return RCode.OK;
        }
        catch (Exception)
        {
            return RCode.FAIL;
        }
    }
}
