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

    using RedBadger.Xpf.Presentation.Controls;

    public abstract class a_Image
    {
        #region Constants and Fields

        protected static Image image;

        private Establish context = () => image = new Image();

        #endregion
    }

    [Subject(typeof(Image))]
    public class Spec : a_Image
    {
    }
}