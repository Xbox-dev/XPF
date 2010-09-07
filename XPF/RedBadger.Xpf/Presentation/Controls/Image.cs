namespace RedBadger.Xpf.Presentation.Controls
{
    using RedBadger.Xpf.Internal;
    using RedBadger.Xpf.Internal.Controls;
    using RedBadger.Xpf.Presentation.Media;

    public class Image : UIElement
    {
        public static readonly Property<ImageSource, Image> SourceProperty =
            Property<ImageSource, Image>.Register("Source", null, PropertyChangedCallbacks.InvalidateMeasure);

        public static readonly Property<StretchDirection, Image> StretchDirectionProperty =
            Property<StretchDirection, Image>.Register(
                "StretchDirection", StretchDirection.Both, PropertyChangedCallbacks.InvalidateMeasure);

        public static readonly Property<Stretch, Image> StretchProperty = Property<Stretch, Image>.Register(
            "Stretch", Stretch.Uniform, PropertyChangedCallbacks.InvalidateMeasure);

        public ImageSource Source
        {
            get
            {
                return this.GetValue(SourceProperty);
            }

            set
            {
                this.SetValue(SourceProperty, value);
            }
        }

        public Stretch Stretch
        {
            get
            {
                return this.GetValue(StretchProperty);
            }

            set
            {
                this.SetValue(StretchProperty, value);
            }
        }

        public StretchDirection StretchDirection
        {
            get
            {
                return this.GetValue(StretchDirectionProperty);
            }

            set
            {
                this.SetValue(StretchDirectionProperty, value);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return this.GetScaledImageSize(finalSize);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return this.GetScaledImageSize(availableSize);
        }

        protected override void OnRender(IDrawingContext drawingContext)
        {
            drawingContext.DrawImage(this.Source, new Rect(new Point(), this.RenderSize));
        }

        private Size GetScaledImageSize(Size givenSize)
        {
            ImageSource source = this.Source;
            if (source == null)
            {
                return Size.Empty;
            }

            Size contentSize = source.Size;
            Vector scale = Viewbox.ComputeScaleFactor(givenSize, contentSize, this.Stretch, this.StretchDirection);
            return new Size(contentSize.Width * scale.X, contentSize.Height * scale.Y);
        }
    }
}