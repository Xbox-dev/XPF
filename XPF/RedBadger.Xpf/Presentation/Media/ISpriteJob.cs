﻿namespace RedBadger.Xpf.Presentation.Media
{
    using RedBadger.Xpf.Graphics;

    public interface ISpriteJob
    {
        void Draw(ISpriteBatch spriteBatch, Vector offset);
    }
}