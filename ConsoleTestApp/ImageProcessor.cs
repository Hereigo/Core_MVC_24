using System.Drawing;

namespace ConsoleTestApp
{
    public class ImageProcessor
    {
        public static void Test()
        {
            string sourceImagePath = "source.png";
            string targetImagePath = "target.png";
            string outputImagePath = "output.png";

            // Load the source (smaller) and target (larger) images

            using (var targetBigImage = new Bitmap(targetImagePath))
            using (var sourceSmallImage = new Bitmap(sourceImagePath))
            {
                // Create a Graphics object from the target image

                using (Graphics g = Graphics.FromImage(targetBigImage))
                {
                    // Optional: Set the drawing mode (for transparent backgrounds, etc.)

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                    // Specify the position where you want to insert the source image into the target image
                    int x = 50;
                    int y = 50;

                    // Draw the source image onto the target image
                    g.DrawImage(sourceSmallImage, new Rectangle(x, y, sourceSmallImage.Width, sourceSmallImage.Height));
                }

                // Save the result to a new file
                targetBigImage.Save(outputImagePath);
            }

            Console.WriteLine($"Image has been inserted and saved to {outputImagePath}");
        }
    }
}