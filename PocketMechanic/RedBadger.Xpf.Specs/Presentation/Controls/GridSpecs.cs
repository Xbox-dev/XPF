//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;

    public abstract class a_Grid
    {
        protected static Grid grid;

        private Establish context = () => grid = new Grid();
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_an_element_is_added : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;
            };

        private Because of = () =>
            {
                grid.Children.Add(child.Object);
                grid.Measure(availableSize);
            };

        private It should_have_a_desired_size_equal_to_that_of_its_child =
            () => grid.DesiredSize.ShouldEqual(child.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_two_elements_are_added : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
            };

        private Because of = () =>
            {
                grid.Children.Add(largeChild.Object);
                grid.Children.Add(smallChild.Object);
                grid.Measure(availableSize);
            };

        private It should_have_a_desired_size_that_equal_to_that_of_the_largest_element =
            () => grid.DesiredSize.ShouldEqual(largeChild.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_there_are_two_columns : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;
                Grid.SetColumn(largeChild.Object, 0);

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
                Grid.SetColumn(smallChild.Object, 1);
            };

        private Because of = () =>
        {
            grid.Children.Add(largeChild.Object);
            grid.Children.Add(smallChild.Object);
            grid.Measure(availableSize);
        };
        
        private It should_have_a_desired_height_equal_to_that_of_the_highest_child =
            () => grid.DesiredSize.Height.ShouldEqual(largeChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_sum_of_its_children =
            () =>
            grid.DesiredSize.Width.ShouldEqual(
                largeChild.Object.DesiredSize.Width + smallChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_there_are_two_rows : a_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
        {
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            largeChild = new Mock<UIElement> { CallBase = true };
            largeChild.Object.Width = 50;
            largeChild.Object.Height = 60;
            Grid.SetRow(largeChild.Object, 0);

            smallChild = new Mock<UIElement> { CallBase = true };
            smallChild.Object.Width = 20;
            smallChild.Object.Height = 30;
            Grid.SetRow(smallChild.Object, 1);
        };

        private Because of = () =>
        {
            grid.Children.Add(largeChild.Object);
            grid.Children.Add(smallChild.Object);
            grid.Measure(availableSize);
        };

        private It should_have_a_desired_height_equal_to_the_sum_of_its_children =
            () => grid.DesiredSize.Height.ShouldEqual(largeChild.Object.DesiredSize.Height + smallChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_that_of_the_widest_child =
            () =>
            grid.DesiredSize.Width.ShouldEqual(largeChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure")]
    public class when_a_column_index_is_specified_greater_than_the_number_of_columns_available : a_Grid
    {
        private It should_put_it_in_the_last_column;
    }
}