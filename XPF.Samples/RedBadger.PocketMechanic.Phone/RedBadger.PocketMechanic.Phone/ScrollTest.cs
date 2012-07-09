namespace RedBadger.PocketMechanic.Phone
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using RedBadger.Xpf;
    using RedBadger.Xpf.Adapters.Xna.Graphics;
    using RedBadger.Xpf.Adapters.Xna.Input;
    using RedBadger.Xpf.Controls;
    using RedBadger.Xpf.Data;
    using RedBadger.Xpf.Media;

    using Color = RedBadger.Xpf.Media.Color;

    public class ScrollTest : DrawableGameComponent
    {
        private readonly Random random = new Random();

        private RootElement rootElement;

        private SpriteBatchAdapter spriteBatchAdapter;

        private SpriteFont spriteFont;

        public ScrollTest(Game game)
            : base(game)
        {
        }

        public RootElement RootElement
        {
            get
            {
                return this.rootElement;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this.RootElement.Draw();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.RootElement.Update();
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            this.spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont");
            this.spriteBatchAdapter = new SpriteBatchAdapter(new SpriteBatch(this.GraphicsDevice));
            var spriteFontAdapter = new SpriteFontAdapter(this.spriteFont);

            var items = new ObservableCollection<string>();
            var itemsControl = new ItemsControl
                {
                    ItemTemplate = _ =>
                        {
                            var textBlock = new TextBlock(spriteFontAdapter)
                                {
                                    Margin = new Thickness(0, 0, 0, 50), 
                                    Background = new SolidColorBrush(GetRandomColor(this.random))
                                };
                            textBlock.Bind(TextBlock.TextProperty, BindingFactory.CreateOneWay<string>());
                            return textBlock;
                        }, 
                    ItemsSource = items
                };

            var renderer = new Renderer(this.spriteBatchAdapter, new PrimitivesService(this.GraphicsDevice));

            this.rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer, new InputManager())
                {
                    Content = new ScrollViewer { Content = itemsControl }
                };

            Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)).ObserveOnDispatcher().Subscribe(
                l => items.Add(DateTime.Now.ToString()));

            /*var renderer = new Renderer(this.spriteBatchAdapter, new PrimitivesService(this.GraphicsDevice));

            this.rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer, new InputManager());

            var textBlock = new TextBlock(spriteFontAdapter)
                {
                    Text =
                        "Red Badger is a product and service consultancy, specialising in bespoke software projects, developer tools and platforms on the Microsoft technology stack.", 
                    Background = new SolidColorBrush(Colors.Red), 
                    HorizontalAlignment = HorizontalAlignment.Left, 
                    VerticalAlignment = VerticalAlignment.Top, 
                    Wrapping = TextWrapping.Wrap, 
                    Margin = new Thickness(10), 
                    Padding = new Thickness(10)
                };

            this.rootElement.Content = textBlock;

            var grid = new Grid { RowDefinitions = { new RowDefinition(), new RowDefinition() } };

            var button = new Button
                {
                    Content =
                        new TextBlock(spriteFontAdapter)
                            {
                               Text = "Click", Background = new SolidColorBrush(Colors.Blue) 
                            }
                };
            grid.Children.Add(button);
            Grid.SetRow(button, 1);

            this.textBlock = new TextBlock(spriteFontAdapter) { Text = "Item 1", Margin = new Thickness(15) };
            this.stackPanel = new StackPanel
                {
                    Children =
                        {
                            this.textBlock, 
                            new TextBlock(spriteFontAdapter) { Text = "Item 2", Margin = new Thickness(15) }, 
                            new TextBlock(spriteFontAdapter) { Text = "Item 3", Margin = new Thickness(15) }
                        }
                };
            grid.Children.Add(this.stackPanel);
            this.rootElement.Content = grid;

            button.Click += (sender, args) => this.stackPanel.Children.RemoveAt(0);*/
        }

        private static Color GetRandomColor(Random random)
        {
            int next = random.Next(3);
            switch (next)
            {
                case 0:
                    return new Color(255, 0, 0, 128);
                case 1:
                    return Colors.Blue;
                case 2:
                    return Colors.Yellow;
            }

            return Colors.Purple;
        }
    }
}