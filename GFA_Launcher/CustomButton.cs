using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace GFA_Launcher
{
    public class CustomButton : Button
    {
        private Image? _spriteSheet;
        private int _stateHeight;
        private int _stateWidth;
        private int _currentState;

        // Constructor with no parameters, required by the designer
        public CustomButton()
        {
            // Initialize default values
            _currentState = 0;
            _spriteSheet = null;
            //this.Size = new Size(100, 50);
            //this.Text = ""; 
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            // Default event handlers
            this.MouseEnter += (s, e) => { _currentState = 1; Invalidate(); };
            this.MouseLeave += (s, e) => { _currentState = 0; Invalidate(); };
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) _currentState = 2; Invalidate(); };
            this.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) _currentState = 0; Invalidate(); };
            this.EnabledChanged += (s, e) => { _currentState = this.Enabled ? 0 : 3; Invalidate(); };
        }

        // Constructor that accepts a sprite sheet, for runtime initialization
        public CustomButton(Image spriteSheet)
            : this()
        {
            _spriteSheet = spriteSheet;
            _stateHeight = spriteSheet.Height;
            _stateWidth = spriteSheet.Width / 4;
        }

        // Designer property for setting the sprite sheet image
        [Category("Appearance")]
        [Description("Sets the sprite sheet for the button states.")]
        public Image? SpriteSheet
        {
            get { return _spriteSheet; }
            set
            {
                _spriteSheet = value;
                if (_spriteSheet != null)
                {
                    _stateHeight = _spriteSheet.Height;
                    _stateWidth = _spriteSheet.Width / 4;
                }
                Invalidate();
            }
        }

        // Paint event to draw the custom button
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, this.Width - 4, this.Height - 4);
            this.Region = new Region(p);
            base.OnPaint(pevent);

            if (_spriteSheet == null)
                return;

            Graphics g = pevent.Graphics;
            g.Clear(this.BackColor);

            // Determine the source rectangle for the current state
            Rectangle srcRect = new Rectangle(_currentState * _stateWidth,  0, _stateWidth, _stateHeight);

            // Draw the sprite sheet section for the current state
            g.DrawImage(_spriteSheet, new Rectangle(0, 0, this.Width, this.Height), srcRect, GraphicsUnit.Pixel);
        }

        // Override resize to adjust drawing area
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Redraw button when resized
        }
    }
}
