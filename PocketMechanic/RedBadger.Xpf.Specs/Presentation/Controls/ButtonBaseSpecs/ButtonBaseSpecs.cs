//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.ButtonBaseSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;

    public abstract class a_ButtonBase
    {
        protected static Mock<ButtonBase> ButtonBase;

        private Establish context = () => ButtonBase = new Mock<ButtonBase> { CallBase = true };
    }

    [Subject(typeof(ButtonBase))]
    public class when_the_left_mouse_button_is_pressed : a_ButtonBase
    {
        private Because of = () => ButtonBase.Object.RaiseMouseLeftButtonDown();

        private It should_set_that_the_button_is_pressed = () => ButtonBase.Object.IsPressed.ShouldBeTrue();
    }

    [Subject(typeof(ButtonBase))]
    public class when_the_left_mouse_button_is_pressed_and_the_control_is_disabled : a_ButtonBase
    {
        private Establish context = () => ButtonBase.Object.IsEnabled = false;

        private Because of = () => ButtonBase.Object.RaiseMouseLeftButtonDown();

        private It should_not_set_that_the_button_is_pressed = () => ButtonBase.Object.IsPressed.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase))]
    public class when_the_left_mouse_button_is_released_and_the_control_is_pressed : a_ButtonBase
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                ButtonBase.Object.IsPressed = true;
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () => ButtonBase.Object.RaiseMouseLeftButtonUp();

        private It should_raise_the_click_event = () => wasClicked.ShouldBeTrue();

        private It should_set_that_the_button_is_released = () => ButtonBase.Object.IsPressed.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase))]
    public class when_the_left_mouse_button_is_released_and_the_control_is_pressed_but_disabled :
        a_ButtonBase
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                ButtonBase.Object.IsEnabled = false;
                ButtonBase.Object.IsPressed = true;
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () => ButtonBase.Object.RaiseMouseLeftButtonUp();

        private It should_not_raise_the_click_event = () => wasClicked.ShouldBeFalse();

        private It should_not_set_that_the_button_is_released = () => ButtonBase.Object.IsPressed.ShouldBeTrue();
    }
}