//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Media.DrawingContextSpecs
{
    using System.Windows;
    using System.Windows.Media;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation.Media.Imaging;

    using DrawingContext = RedBadger.Xpf.Presentation.Media.DrawingContext;
    using It = Machine.Specifications.It;
    using SolidColorBrush = RedBadger.Xpf.Presentation.Media.SolidColorBrush;
    using Vector = RedBadger.Xpf.Presentation.Vector;

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text : a_DrawingContext
    {
        private const string ExpectedString = "String Value";

        private static readonly Color expectedColor = Colors.Black;

        private static readonly Vector expectedDrawPosition = Vector.Zero;

        private Because of = () =>
            {
                DrawingContext.DrawText(
                    SpriteFont.Object, ExpectedString, expectedDrawPosition, new SolidColorBrush(expectedColor));
                Renderer.Draw();
            };

        private It should_render_text =
            () =>
            SpriteBatch.Verify(
                batch => batch.DrawString(SpriteFont.Object, ExpectedString, expectedDrawPosition, expectedColor));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.AliceBlue);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private Because of = () =>
            {
                DrawingContext.DrawRectangle(expectedRect, expectedBrush);
                Renderer.Draw();
            };

        private It should_render_a_rectangle =
            () => SpriteBatch.Verify(batch => batch.Draw(Moq.It.IsAny<ITexture2D>(), expectedRect, expectedBrush.Color));
    }

    [Subject(typeof(DrawingContext), "Image")]
    public class when_drawing_an_image : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedColor = new SolidColorBrush(Colors.White);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private static Mock<ITexture2D> expectedTexture;

        private Because of = () =>
            {
                expectedTexture = new Mock<ITexture2D>();
                DrawingContext.DrawImage(new Mock<XnaImage>(expectedTexture.Object).Object, expectedRect);
                Renderer.Draw();
            };

        private It should_render_an_image =
            () => SpriteBatch.Verify(batch => batch.Draw(expectedTexture.Object, expectedRect, expectedColor.Color));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_resolving_offsets_for_a_rectangle : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Rect rect = new Rect(10, 20, 30, 40);

        private Establish conetxt = () => UiElement.SetupGet(element => element.AbsoluteOffset).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawRectangle(rect, new SolidColorBrush(Colors.AliceBlue));
                Renderer.PreDraw();
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture2D>(), 
                    new Rect(absoluteOffset.X + rect.X, absoluteOffset.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "Text")]
    public class when_resolving_offsets_for_text : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Vector textOffset = new Vector(10, 20);

        private Establish context = () => UiElement.SetupGet(element => element.AbsoluteOffset).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawText(
                    SpriteFont.Object, string.Empty, textOffset, new SolidColorBrush(Colors.AliceBlue));
                Renderer.PreDraw();
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.DrawString(
                    Moq.It.IsAny<ISpriteFont>(), 
                    Moq.It.IsAny<string>(), 
                    absoluteOffset + textOffset, 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "Image")]
    public class when_resolving_offsets_for_an_image : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Rect rect = new Rect(10, 20, 30, 40);

        private Establish context = () => UiElement.SetupGet(element => element.AbsoluteOffset).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawImage(new Mock<XnaImage>(new Mock<ITexture2D>().Object).Object, rect);
                Renderer.PreDraw();
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture2D>(), 
                    new Rect(absoluteOffset.X + rect.X, absoluteOffset.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }
}