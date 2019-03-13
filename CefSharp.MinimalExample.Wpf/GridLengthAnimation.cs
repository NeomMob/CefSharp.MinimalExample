
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace CefSharp.MinimalExample.Wpf
{
    /// <summary>
    /// Description of GridLengthAnimation.
    /// </summary>
    public class GridLengthAnimation : AnimationTimeline
    {
        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }

        protected override System.Windows.Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(GridLength), typeof(GridLengthAnimation));

        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimation.FromProperty);
            }
            set
            {
                SetValue(GridLengthAnimation.FromProperty, value);
            }
        }

        private double FromAsDouble
        {
            get
            {
                return ((GridLength)From).Value;
            }
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(GridLength), typeof(GridLengthAnimation));

        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimation.ToProperty);
            }
            set
            {
                SetValue(GridLengthAnimation.ToProperty, value);
            }
        }

        private double ToAsDouble
        {
            get
            {
                return ((GridLength)To).Value;
            }
        }

        public GridUnitType GridUnitType
        {
            get { return (GridUnitType)GetValue(GridUnitTypeProperty); }
            set { SetValue(GridUnitTypeProperty, value); }
        }

        public static readonly DependencyProperty GridUnitTypeProperty =
            DependencyProperty.Register("GridUnitType", typeof(GridUnitType), typeof(GridLengthAnimation), new UIPropertyMetadata(GridUnitType.Pixel));

        public override object GetCurrentValue(object defaultOriginValue,
                                               object defaultDestinationValue,
                                               AnimationClock animationClock)
        {
            if (FromAsDouble > ToAsDouble)
                return new GridLength((1 - animationClock.CurrentProgress.Value) *
                                      (FromAsDouble - ToAsDouble) + ToAsDouble, this.GridUnitType);

            return new GridLength(animationClock.CurrentProgress.Value *
                                  (ToAsDouble - FromAsDouble) + FromAsDouble, this.GridUnitType);
        }
    }
}