using FutureLending.Properties;
using System.Drawing.Drawing2D;

namespace FutureLending.ControlesPersonalizados;

public class DateTimePickerPersonalizado : DateTimePicker
{
    private const int calendarIconWidth = 34;
    private const int arrowIconWidth = 17;
    private Color borderColor = Color.PaleVioletRed;
    private int borderSize;
    private Image calendarIcon = Resources.calendarWhite;

    //-> Other Values
    private bool droppedDown;

    private RectangleF iconButtonArea;

    //Fields
    //-> Appearance
    private Color skinColor = Color.MediumSlateBlue;
    private Color textColor = Color.White;

    //Constructor
    public DateTimePickerPersonalizado()
    {
        SetStyle(ControlStyles.UserPaint, true);
        MinimumSize = new Size(0, 35);
        Font = new Font(Font.Name, 9.5F);
    }

    //Properties
    public Color SkinColor
    {
        get => skinColor;
        set
        {
            skinColor = value;
            if (skinColor.GetBrightness() >= 0.8F)
                calendarIcon = Resources.calendarDark;
            else calendarIcon = Resources.calendarWhite;
            Invalidate();
        }
    }

    public Color TextColor
    {
        get => textColor;
        set
        {
            textColor = value;
            Invalidate();
        }
    }

    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    public int BorderSize
    {
        get => borderSize;
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    //Overridden methods
    protected override void OnDropDown(EventArgs eventargs)
    {
        base.OnDropDown(eventargs);
        droppedDown = true;
    }

    protected override void OnCloseUp(EventArgs eventargs)
    {
        base.OnCloseUp(eventargs);
        droppedDown = false;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        e.Handled = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (var graphics = CreateGraphics())
        using (var penBorder = new Pen(borderColor, borderSize))
        using (var skinBrush = new SolidBrush(skinColor))
        using (var openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
        using (var textBrush = new SolidBrush(textColor))
        using (var textFormat = new StringFormat())
        {
            var clientArea = new RectangleF(0, 0, Width - 0.5F, Height - 0.5F);
            var iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth,
                clientArea.Height);
            penBorder.Alignment = PenAlignment.Inset;
            textFormat.LineAlignment = StringAlignment.Center;

            //Draw surface
            graphics.FillRectangle(skinBrush, clientArea);
            //Draw text
            graphics.DrawString("   " + Text, Font, textBrush, clientArea, textFormat);
            //Draw open calendar icon highlight
            if (droppedDown) graphics.FillRectangle(openIconBrush, iconArea);
            //Draw border 
            if (borderSize >= 1)
                graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
            //Draw icon
            graphics.DrawImage(calendarIcon, Width - calendarIcon.Width - 9, (Height - calendarIcon.Height) / 2);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        var iconWidth = GetIconButtonWidth();
        iconButtonArea = new RectangleF(Width - iconWidth, 0, iconWidth, Height);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (iconButtonArea.Contains(e.Location))
            Cursor = Cursors.Hand;
        else Cursor = Cursors.Default;
    }

    //Private methods
    private int GetIconButtonWidth()
    {
        var textWidh = TextRenderer.MeasureText(Text, Font).Width;
        if (textWidh <= Width - (calendarIconWidth + 20))
            return calendarIconWidth;
        return arrowIconWidth;
    }
}