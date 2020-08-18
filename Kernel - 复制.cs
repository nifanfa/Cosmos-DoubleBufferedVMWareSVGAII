using Cosmos.System;
using System.Drawing;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        uint screenWidth = 640;
        uint screenHeight = 480;
        VMWareSVGAII vMWareSVGAII;

        int[] cursor = new int[]
            {
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,0,1,0,0,0,0,0,0,0,0,0,
                1,0,0,1,0,0,0,0,0,0,0,0,
                1,0,0,0,1,0,0,0,0,0,0,0,
                1,0,0,0,0,1,0,0,0,0,0,0,
                1,0,0,0,0,0,1,0,0,0,0,0,
                1,0,0,0,0,0,0,1,0,0,0,0,
                1,0,0,0,0,0,0,0,1,0,0,0,
                1,0,0,0,0,0,0,0,0,1,0,0,
                1,0,0,0,0,0,0,0,0,0,1,0,
                1,0,0,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,1,1,1,1,1,
                1,0,0,0,1,0,0,1,0,0,0,0,
                1,0,0,1,0,1,0,0,1,0,0,0,
                1,0,1,0,0,1,0,0,1,0,0,0,
                1,1,0,0,0,0,1,0,0,1,0,0,
                0,0,0,0,0,0,1,0,0,1,0,0,
                0,0,0,0,0,0,0,1,1,0,0,0
            };

        protected override void BeforeRun()
        {
            vMWareSVGAII = new VMWareSVGAII();
            vMWareSVGAII.SetMode((uint)screenWidth, (uint)screenHeight);
            MouseManager.ScreenWidth = (uint)screenWidth;
            MouseManager.ScreenHeight = (uint)screenHeight;
            vMWareSVGAII.Clear((uint)Color.Black.ToArgb());
        }

        protected override void Run()
        {
            vMWareSVGAII._Clear((uint)Color.Black.ToArgb());
            DrawCursor(vMWareSVGAII, MouseManager.X, MouseManager.Y);
            vMWareSVGAII._Update();
            vMWareSVGAII.Update(0, 0, (uint)screenWidth, (uint)screenHeight);
        }

        public void DrawCursor(VMWareSVGAII vMWareSVGAII, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vMWareSVGAII._SetPixel(w + x, h + y, (uint)Color.White.ToArgb());
                    }
                }
            }
        }
    }
}
