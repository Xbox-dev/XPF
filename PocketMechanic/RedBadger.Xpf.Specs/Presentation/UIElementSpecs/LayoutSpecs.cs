﻿//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.UIElementSpecs
{
    using System.Windows;

    using Machine.Specifications;

    using Moq;
    using Moq.Protected;

    using It = Machine.Specifications.It;
    using UIElement = RedBadger.Xpf.Presentation.UIElement;
    using Vector = RedBadger.Xpf.Presentation.Vector;

    [Subject(typeof(UIElement), "Layout - explicit sizes")]
    public class when_an_explicit_size_is_set_and_the_children_want_less_space : a_UIElement
    {
        private static readonly Size availableSize = new Size(300, 300);

        private static readonly Size desiredSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(125, 125);

        private static readonly Size explicitSize = new Size(100, 100);

        private Establish context = () =>
            {
                UIElement.Protected().Setup<Size>(MeasureOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
                UIElement.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
            };

        private Because of = () =>
            {
                UIElement.Object.Width = explicitSize.Width;
                UIElement.Object.Height = explicitSize.Height;
                UIElement.Object.Measure(availableSize);
                UIElement.Object.Arrange(new Rect(availableSize));
            };

        private It should_arrange_its_children_within_the_explicit_size =
            () =>
            UIElement.Protected().Verify(
                ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(explicitSize)));

        private It should_have_a_desired_size_equal_to_the_size_that_was_specified =
            () => UIElement.Object.DesiredSize.ShouldEqual(explicitSize);

        private It should_have_the_correct_visual_offset =
            () => UIElement.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Layout - explicit sizes")]
    public class when_an_explicit_width_is_set_and_the_children_want_more_space : a_UIElement
    {
        private static readonly Size availableSize = new Size(300, 300);

        private static readonly Size desiredSize = new Size(200, 200);

        private static readonly Vector expectedVisualOffset = new Vector(100, 100);

        private static readonly Size explicitSize = new Size(100, 100);

        private Establish context = () =>
            {
                UIElement.Protected().Setup<Size>(MeasureOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
                UIElement.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
            };

        private Because of = () =>
            {
                UIElement.Object.Width = explicitSize.Width;
                UIElement.Object.Height = explicitSize.Height;
                UIElement.Object.Measure(availableSize);
                UIElement.Object.Arrange(new Rect(availableSize));
            };

        private It should_arrange_its_children_within_the_explicit_size =
            () =>
            UIElement.Protected().Verify(
                ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(explicitSize)));

        private It should_have_a_desired_size_equal_to_the_size_that_was_specified =
            () => UIElement.Object.DesiredSize.ShouldEqual(explicitSize);

        private It should_have_the_correct_visual_offset =
            () => UIElement.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Layout - explicit sizes")]
    public class when_a_minimum_size_is_set_and_the_children_want_less_space : a_UIElement
    {
        private static readonly Size availableSize = new Size(300, 300);

        private static readonly Size desiredSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(125, 125);

        private static readonly Size minimumSize = new Size(100, 100);

        private Establish context = () =>
            {
                UIElement.Protected().Setup<Size>(MeasureOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
                UIElement.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
            };

        private Because of = () =>
            {
                UIElement.Object.MinWidth = minimumSize.Width;
                UIElement.Object.MinHeight = minimumSize.Height;
                UIElement.Object.Measure(availableSize);
                UIElement.Object.Arrange(new Rect(availableSize));
            };

        private It should_arrange_its_children_within_the_available_size =
            () =>
            UIElement.Protected().Verify(
                ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(availableSize)));

        private It should_have_a_desired_size_equal_to_the_minimum_size_that_was_specified =
            () => UIElement.Object.DesiredSize.ShouldEqual(minimumSize);

        private It should_have_the_correct_visual_offset =
            () => UIElement.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Layout - explicit sizes")]
    public class when_a_maximum_size_is_set_and_the_children_want_more_space : a_UIElement
    {
        private static readonly Size availableSize = new Size(300, 300);

        private static readonly Size desiredSize = new Size(200, 200);

        private static readonly Vector expectedVisualOffset = new Vector(100, 100);

        private static readonly Size maximumSize = new Size(100, 100);

        private Establish context = () =>
            {
                UIElement.Protected().Setup<Size>(MeasureOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
                UIElement.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(desiredSize);
            };

        private Because of = () =>
            {
                UIElement.Object.MaxWidth = maximumSize.Width;
                UIElement.Object.MaxHeight = maximumSize.Height;
                UIElement.Object.Measure(availableSize);
                UIElement.Object.Arrange(new Rect(availableSize));
            };

        private It should_arrange_its_children_within_the_maximum_size =
            () =>
            UIElement.Protected().Verify(
                ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(maximumSize)));

        private It should_have_a_desired_size_equal_to_the_maximum_size_that_was_specified =
            () => UIElement.Object.DesiredSize.ShouldEqual(maximumSize);

        private It should_have_the_correct_visual_offset =
            () => UIElement.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_measure_is_invalidated : a_Measured_and_Arranged_UIElement
    {
        private Establish context = () =>
            {
                var parentUiElement = new Mock<UIElement>();
                parentUiElement.Object.Measure(Size.Empty);
                parentUiElement.Object.Arrange(Rect.Empty);

                UIElement.Object.VisualParent = parentUiElement.Object;
            };

        private Because of = () => UIElement.Object.InvalidateMeasure();

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_its_parents_arrange =
            () => UIElement.Object.VisualParent.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_its_parents_measure =
            () => UIElement.Object.VisualParent.IsMeasureValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_arrange_is_invalidated : a_Measured_and_Arranged_UIElement
    {
        private Establish context = () =>
            {
                var parentUiElement = new Mock<UIElement>();
                parentUiElement.Object.Measure(Size.Empty);
                parentUiElement.Object.Arrange(Rect.Empty);

                UIElement.Object.VisualParent = parentUiElement.Object;
            };

        private Because of = () => UIElement.Object.InvalidateArrange();

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_its_parents_arrange =
            () => UIElement.Object.VisualParent.IsArrangeValid.ShouldBeFalse();

        private It should_not_invalidate_its_parents_measure =
            () => UIElement.Object.VisualParent.IsMeasureValid.ShouldBeTrue();

        private It should_not_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeTrue();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_height_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.Height = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_minimum_height_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.MinHeight = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_maximum_height_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.MaxHeight = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_width_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.Width = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_minimum_width_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.MinWidth = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_maximum_width_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.MaxWidth = 100;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_margin_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.Margin = new Thickness(10, 20, 30, 40);

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_horizontal_alignment_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.HorizontalAlignment = HorizontalAlignment.Left;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_not_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeTrue();
    }

    [Subject(typeof(UIElement), "Layout - Invalidate")]
    public class when_vertical_alignment_is_changed : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.VerticalAlignment = VerticalAlignment.Bottom;

        private It should_invalidate_arrange = () => UIElement.Object.IsArrangeValid.ShouldBeFalse();

        private It should_not_invalidate_measure = () => UIElement.Object.IsMeasureValid.ShouldBeTrue();
    }

    [Subject(typeof(UIElement), "Layout - Size Change")]
    public class when_the_available_size_changes : a_Measured_UIElement
    {
        private Because of = () => UIElement.Object.Measure(new Size(200, 200));

        private It should_measure_again =
            () => UIElement.Protected().Verify(MeasureOverride, Times.Exactly(2), ItExpr.IsAny<Size>());
    }

    [Subject(typeof(UIElement), "Layout - Size Change")]
    public class when_the_available_size_doesnt_change_enough : a_Measured_UIElement
    {
        private Because of = () => UIElement.Object.Measure(new Size(100.000001f, 100.000001f));

        private It should_not_measure_again =
            () => UIElement.Protected().Verify(MeasureOverride, Times.Once(), ItExpr.IsAny<Size>());
    }

    [Subject(typeof(UIElement), "Layout - Size Change")]
    public class when_the_final_size_changes : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.Arrange(new Rect(new Size(200, 200)));

        private It should_arrange_again =
            () => UIElement.Protected().Verify(ArrangeOverride, Times.Exactly(2), ItExpr.IsAny<Size>());
    }

    [Subject(typeof(UIElement), "Layout - Size Change")]
    public class when_the_final_size_doesnt_change_enough : a_Measured_and_Arranged_UIElement
    {
        private Because of = () => UIElement.Object.Arrange(new Rect(new Size(100.000001f, 100.000001f)));

        private It should_not_arrange_again =
            () => UIElement.Protected().Verify(ArrangeOverride, Times.Once(), ItExpr.IsAny<Size>());
    }

    [Subject(typeof(UIElement), "Layout - Absolute Offset")]
    public class when_an_absolute_offset_is_requested
    {
        private static Mock<UIElement> element1;

        private static Mock<UIElement> element2;

        private static Mock<UIElement> element3;

        private Establish context = () =>
            {
                element1 = new Mock<UIElement> { CallBase = true };
                element1.Object.VisualOffset = new Vector(10, 20);

                element2 = new Mock<UIElement> { CallBase = true };
                element2.Object.VisualOffset = new Vector(30, 40);
                element2.Object.VisualParent = element1.Object;

                element3 = new Mock<UIElement> { CallBase = true };
                element3.Object.VisualOffset = new Vector(50, 60);
                element3.Object.VisualParent = element2.Object;
            };

        private It should_return_a_correct_value_for_element_1 =
            () => element1.Object.CalculateAbsoluteOffset().ShouldEqual(new Vector(10, 20));

        private It should_return_a_correct_value_for_element_2 =
            () => element2.Object.CalculateAbsoluteOffset().ShouldEqual(new Vector(40, 60));

        private It should_return_a_correct_value_for_element_3 =
            () => element3.Object.CalculateAbsoluteOffset().ShouldEqual(new Vector(90, 120));
    }
}