using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Graphics
{
    public class Screen : IScreen
    {
        public int Height { get; private set; }

        public int Width { get; private set; }

        private RenderTarget2D _renderTarget { get; }


        public Screen(RenderTarget2D render)
        {
            _renderTarget = render;
            Height = render.Height;
            Width = render.Width;
        }

        public Rectangle CalculateDestinationRectangle()
        {
            int width = _renderTarget.GraphicsDevice.Viewport.Width;
            int height = _renderTarget.GraphicsDevice.Viewport.Height;
            float aspectRatio = (float)(Width) / (float)(Height);
            int x = 0;
            int y = 0;

            if (height < width)
            {
                width = (int)(height * aspectRatio);
                x = (_renderTarget.GraphicsDevice.Viewport.Width - width) / 2;
            }
            else
            {
                height = (int)(width / aspectRatio);
                y = (_renderTarget.GraphicsDevice.Viewport.Height - height) / 2;
            }

            return new Rectangle(x, y, width, height);
        }

        public void Dispose()
        {
            _renderTarget?.Dispose();
        }

        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            spritesRenderer.Begin(textureFiltering);
            spritesRenderer.Draw(_renderTarget, CalculateDestinationRectangle(), Color.White);
            spritesRenderer.End();
        }

        public void Set()
        {
            _renderTarget.GraphicsDevice.SetRenderTarget(_renderTarget);
        }

        public void UnSet()
        {
            _renderTarget.GraphicsDevice.SetRenderTarget(null);
        }
    }
}
