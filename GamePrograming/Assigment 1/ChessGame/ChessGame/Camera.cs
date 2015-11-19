using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    class Camera
    {
        private GraphicsDevice device;
        private int chessBackgroundSizeX;
        private int chessBackgroundSizeY;
        private int tileSizeX;
        private int tileSizeY;
        private ChessModel chessModel;

        public Camera(GraphicsDevice device, ChessModel chessModel)
        {
            this.device = device;
            this.chessModel = chessModel;
            UpdateResolutionValues();
        }

        public Rectangle GetBackgroundVectorPos()
        {
            return new Rectangle(0, 0, chessBackgroundSizeX, chessBackgroundSizeY);
        }

        internal Rectangle GetVisualCords(int x, int y)
        {
            Rectangle originPos = GetBackgroundVectorPos();
            originPos.X += tileSizeX;
            originPos.Y += tileSizeY;

            Rectangle TitePosition;

            if (this.chessModel.IsTableTurned)
            {
                TitePosition = new Rectangle(tileSizeX * x + originPos.X, tileSizeY * y + originPos.Y, tileSizeX, tileSizeY);
            }
            else
            {
                TitePosition = new Rectangle((7 - x) * tileSizeX + originPos.X, (7 - y) * tileSizeY + originPos.Y, tileSizeX, tileSizeY);
            }

            return TitePosition;
        }

        public void UpdateGameResolution(GraphicsDevice device)
        {
            this.device = device;
            UpdateResolutionValues();
        }

        public void UpdateResolutionValues()
        {
            tileSizeX = device.Viewport.Width / 10;
            tileSizeY = device.Viewport.Height / 10;
            chessBackgroundSizeX = device.Viewport.Width;
            chessBackgroundSizeY = device.Viewport.Height;
        }
    }
}
