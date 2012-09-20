#region License
/* The MIT License
 *
 * Copyright (c) 2011 Red Badger Consulting
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
#endregion

//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Graphics.DrawingContextSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Adapters.Xna.Graphics;
    using RedBadger.Xpf.Graphics;

    public abstract class a_DrawingContext
    {
        protected static IDrawingContext DrawingContext;

        protected static IRenderer Renderer;

        protected static Mock<ISpriteBatch> SpriteBatch;

        protected static Mock<ISpriteFont> SpriteFont;

        protected static Mock<IElement> UiElement;

        private Establish context = () =>
            {
                SpriteBatch = new Mock<ISpriteBatch>();

                var newRect = new Rect();
                SpriteBatch.Setup(batch => batch.TryIntersectViewport(ref newRect)).Returns(true);

                var emptyRect = Rect.Empty;
                SpriteBatch.Setup(batch => batch.TryIntersectViewport(ref emptyRect)).Returns(true);

                Renderer = new Renderer(SpriteBatch.Object, new Mock<IPrimitivesService>().Object);
                UiElement = new Mock<IElement> { CallBase = true };
                DrawingContext = Renderer.GetDrawingContext(UiElement.Object);

                SpriteFont = new Mock<ISpriteFont>();
            };
    }
}
