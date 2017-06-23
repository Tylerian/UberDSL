using UIKit;

namespace UberDSL
{
    public class LayoutProxy
    {
        internal UIView View
        {
            get;
        }

        internal Context Context
        {
            get;
        }

        public Dimension Width
        {
            get
            {
                return new Dimension(Context, View, NSLayoutAttribute.Width);
            }
        }

        public Dimension Height
        {
            get
            {
                return new Dimension(Context, View, NSLayoutAttribute.Height);
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Context, new[] {
                    Width,
                    Height
                });
            }
        }

        public Edge Top
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Top);
            }
        }

        public Edge Left
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Left);
            }
        }

        public Edge Right
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Right);
            }
        }

        public Edge Bottom
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Bottom);
            }
        }

        public Edges Edges
        {
            get
            {
                return new Edges(Context, new[] {
                    Bottom,
                    Leading,
                    Bottom,
                    Trailing
                });
            }
        }

        public Edge Leading
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Leading);
            }
        }

        public Edge Trailing
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Trailing);
            }
        }

        public Edge CenterX
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.CenterX);
            }
        }

        public Edge CenterY
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.CenterY);
            }
        }

        public Point Center
        {
            get
            {
                return new Point(Context, new[] {
                    CenterX,
                    CenterY
                });
            }
        }

        public Edge Baseline
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.Baseline);
            }
        }

        public Edge LastBaseline
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.LastBaseline);
            }
        }

        public Edge FirstBaseline
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.FirstBaseline);
            }
        }

        public Edges EdgesWithMargins
        {
            get
            {
                return new Edges(Context, new[] {
                    TopMargin,
                    LeadingMargin,
                    BottomMargin,
                    TrailingMargin
                });
            }
        }

        public Edge TopMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.TopMargin);
            }
        }

        public Edge LeftMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.LeftMargin);
            }
        }

        public Edge BottomMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.BottomMargin);
            }
        }

        public Edge RightMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.RightMargin);
            }
        }

        public Edge LeadingMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.LeadingMargin);
            }
        }

        public Edge TrailingMargin
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.TrailingMargin);
            }
        }

        public Edge CenterXWithinMargins
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.CenterXWithinMargins);
            }
        }

        public Edge CenterYWithinMargins
        {
            get
            {
                return new Edge(Context, View, NSLayoutAttribute.CenterYWithinMargins);
            }
        }

        public Point CenterWithinMargins
        {
            get
            {
                return new Point(Context, new[] {
                    CenterXWithinMargins,
                    CenterYWithinMargins
                });
            }
        }

        public LayoutProxy Superview
        {
            get
            {
                if (View?.Superview != null)
                {
                    return new LayoutProxy(Context, View.Superview);
                }

                return null;
            }
        }

        public LayoutProxy(Context context, UIView view)
        {
            View = view;
            Context = context;
        }
    }
}
