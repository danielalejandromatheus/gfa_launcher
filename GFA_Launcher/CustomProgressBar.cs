using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    internal class CustomProgressBar : Control
    {
        private int _progress;
        private Image _spritesheetCompleted;
        private Image _spritesheetUncompleted;

        [Category("Appearance")]
        [Description("The progress value of the bar.")]
        public double Progress
        {
            get => _progress;
            set
            {
                //clamp double value to 0-100
                _progress = (int)Math.Max(0, Math.Min(100, value));
                Invalidate(); // Redraw the control
            }
        }

        [Category("Appearance")]
        [Description("The spritesheet for the completed (progress) area.")]
        public Image SpritesheetCompleted
        {
            get => _spritesheetCompleted;
            set
            {
                _spritesheetCompleted = value;
                Invalidate(); // Redraw the control
            }
        }

        [Category("Appearance")]
        [Description("The spritesheet for the uncompleted area.")]
        public Image SpritesheetUncompleted
        {
            get => _spritesheetUncompleted;
            set
            {
                _spritesheetUncompleted = value;
                Invalidate(); // Redraw the control
            }
        }

        public CustomProgressBar()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_spritesheetCompleted == null || _spritesheetUncompleted == null)
            {
                // Draw a placeholder rectangle if spritesheets are not set
                e.Graphics.FillRectangle(Brushes.Gray, 0, 0, Width, Height);
                return;
            }

            float completedWidth = (Width * _progress) / 100f; // Width of the completed area
            float uncompletedWidth = Width - completedWidth; // Remaining width

            // Draw the completed area (left side)
            if (completedWidth > 0)
            {
                // Source rectangle from the spritesheet
                Rectangle sourceCompletedRect = new Rectangle(0, 0, (int)(_spritesheetCompleted.Width * (completedWidth / Width)), _spritesheetCompleted.Height);

                // Destination rectangle on the control
                Rectangle destCompletedRect = new Rectangle(0, 0, (int)completedWidth, Height);

                // Draw the cropped completed area
                e.Graphics.DrawImage(_spritesheetCompleted, destCompletedRect, sourceCompletedRect, GraphicsUnit.Pixel);
            }

            // Draw the uncompleted area (right side)
            if (uncompletedWidth > 0)
            {
                // Source rectangle from the spritesheet
                Rectangle sourceUncompletedRect = new Rectangle((int)(_spritesheetUncompleted.Width * (completedWidth / Width)), 0, (int)(_spritesheetUncompleted.Width * (uncompletedWidth / Width)), _spritesheetUncompleted.Height);

                // Destination rectangle on the control
                Rectangle destUncompletedRect = new Rectangle((int)completedWidth, 0, (int)uncompletedWidth, Height);

                // Draw the cropped uncompleted area
                e.Graphics.DrawImage(_spritesheetUncompleted, destUncompletedRect, sourceUncompletedRect, GraphicsUnit.Pixel);
            }

            // Optional: Draw a border around the control
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }
    }
}
