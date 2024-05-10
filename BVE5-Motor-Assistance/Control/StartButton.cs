using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BVE5_Motor_Assistance.Control
{
    public class StartButton : Button
    {
        //ImageSource Source;



        public ImageSource imageSource
        {
            get { return (ImageSource)GetValue(imageSourceProperty); }
            set { SetValue(imageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for imageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty imageSourceProperty =
            DependencyProperty.Register("imageSource", typeof(ImageSource), typeof(StartButton));



        public Visibility VisibilityYellow
        {
            get { return (Visibility)GetValue(VisibilityYellowProperty); }
            set { SetValue(VisibilityYellowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibilityYellow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityYellowProperty =
            DependencyProperty.Register("VisibilityYellow", typeof(Visibility), typeof(StartButton));
     
            




    }
}
