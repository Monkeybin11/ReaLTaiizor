﻿#region Imports

using System.Drawing;
using System.Windows.Forms;
using ReaLTaiizor.Enum.Poison;

#endregion

namespace ReaLTaiizor.Animate.Poison
{
    #region ExpandAnimationAnimate

    public sealed class ExpandAnimation : Animate
    {
        public void Start(Control control, Size targetSize, TransitionType transitionType, int duration)
        {
            base.Start(control, transitionType, duration,
                delegate
                {
                    int width = DoExpandAnimation(control.Width, targetSize.Width);
                    int height = DoExpandAnimation(control.Height, targetSize.Height);

                    control.Size = new Size(width, height);
                },
                delegate
                {
                    return (control.Size.Equals(targetSize));
                });
        }

        private int DoExpandAnimation(int startSize, int targetSize)
        {
            float t = (float)counter - startTime;
            float b = (float)startSize;
            float c = (float)targetSize - startSize;
            float d = (float)targetTime - startTime;

            return MakeTransition(t, b, d, c);
        }
    }

    #endregion
}