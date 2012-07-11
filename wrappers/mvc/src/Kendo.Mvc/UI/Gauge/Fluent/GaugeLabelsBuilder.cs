namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the gauge labels.
    /// </summary>
    public abstract class GaugeLabelsBuilder<TBuilder> : IHideObjectMembers
        where TBuilder : GaugeLabelsBuilder<TBuilder>
    {
        private readonly GaugeScaleLabelsBase labels;

        /// <summary>
        /// Initializes a new instance of the <see cref="GaugeLabelsBuilder{TBuilder}" /> class.
        /// </summary>
        /// <param name="scaleLabels">The labels configuration.</param>
        public GaugeLabelsBuilder(GaugeScaleLabelsBase scaleLabels)
        {
            labels = scaleLabels;
        }

        /// <summary>
        /// Sets the labels font
        /// </summary>
        /// <param name="font">The labels font (CSS format).</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Font("14px Arial,Helvetica,sans-serif")
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Font(string font)
        {
            labels.Font = font;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels visibility
        /// </summary>
        /// <param name="visible">The labels visibility.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Visible(false)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Visible(bool visible)
        {
            labels.Visible = visible;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels background color
        /// </summary>
        /// <param name="background">The labels background color.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Background("Red")
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Background(string background)
        {
            labels.Background = background;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels text color
        /// </summary>
        /// <param name="color">The labels text color.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Color("Red")
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Color(string color)
        {
            labels.Color = color;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels margin
        /// </summary>
        /// <param name="top">The labels top margin.</param>
        /// <param name="right">The labels right margin.</param>
        /// <param name="bottom">The labels bottom margin.</param>
        /// <param name="left">The labels left margin.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Margin(0, 5, 5, 0)
        ///                )
        ///            )
        /// %&gt;els
        /// </code>
        /// </example>        
        public TBuilder Margin(int top, int right, int bottom, int left)
        {
            labels.Margin.Top = top;
            labels.Margin.Right = right;
            labels.Margin.Bottom = bottom;
            labels.Margin.Left = left;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels margin
        /// </summary>
        /// <param name="margin">The labels margin.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Margin(20)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Margin(int margin)
        {
            labels.Margin = new ChartSpacing(margin);
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels padding
        /// </summary>
        /// <param name="top">The labels top padding.</param>
        /// <param name="right">The labels right padding.</param>
        /// <param name="bottom">The labels bottom padding.</param>
        /// <param name="left">The labels left padding.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Padding(0, 5, 5, 0)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Padding(int top, int right, int bottom, int left)
        {
            labels.Padding.Top = top;
            labels.Padding.Right = right;
            labels.Padding.Bottom = bottom;
            labels.Padding.Left = left;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels padding
        /// </summary>
        /// <param name="padding">The labels padding.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Padding(20)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Padding(int padding)
        {
            labels.Padding = new ChartSpacing(padding);
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels border
        /// </summary>
        /// <param name="width">The labels border width.</param>
        /// <param name="color">The labels border color (CSS syntax).</param>
        /// <param name="dashType">The labels border dash type.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Border(1, "Red", ChartDashType.Dot)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Border(int width, string color, ChartDashType dashType)
        {
            labels.Border = new ChartElementBorder(width, color, dashType);
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels format.
        /// </summary>
        /// <param name="format">The labels format.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Format("{0:C}")
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Format(string format)
        {
            labels.Format = format;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels template.
        /// </summary>
        /// <param name="template">The labels template.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Template("#= value #")
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>        
        public TBuilder Template(string template)
        {
            labels.Template = template;
            return this as TBuilder;
        }

        /// <summary>
        /// Sets the labels opacity.
        /// </summary>
        /// <param name="opacity">
        /// The series opacity in the range from 0 (transparent) to 1 (opaque).
        /// The default value is 1.
        /// </param>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        ///            .Scale(scale => scale
        ///                .Labels(labels => labels
        ///                    .Opacity(0.5)
        ///                )
        ///            )
        /// %&gt;
        /// </code>
        /// </example>
        public TBuilder Opacity(double opacity)
        {
            labels.Opacity = opacity;

            return this as TBuilder;
        }
    }
}