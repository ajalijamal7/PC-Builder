using System;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;

public static class ThemeManager
{
    public static bool IsDarkMode = false;

    public static void ApplyTheme(Form form)
    {
        Color backColor, foreColor, cardColor;

        if (IsDarkMode)
        {
            backColor = Color.FromArgb(34, 34, 34);
            foreColor = Color.White;
            cardColor = Color.FromArgb(45, 45, 48);
        }
        else
        {
            backColor = Color.White;
            foreColor = Color.Black;
            cardColor = Color.Gainsboro;
        }

        form.BackColor = backColor;
        ApplyToControls(form.Controls, foreColor, cardColor);
    }

    private static void ApplyToControls(Control.ControlCollection controls, Color foreColor, Color cardColor)
    {
        foreach (Control control in controls)
        {
            if (control is Label lbl)
            {
                lbl.ForeColor = foreColor;
            }
            else if (control is BunifuButton btn)
            {
                btn.IdleFillColor = cardColor;
                btn.IdleBorderColor = foreColor;
                btn.ForeColor = foreColor;
            }
            else if (control is Button stdBtn)
            {
                stdBtn.BackColor = cardColor;
                stdBtn.ForeColor = foreColor;
                stdBtn.FlatStyle = FlatStyle.Flat;
                stdBtn.FlatAppearance.BorderColor = foreColor;
            }
            else if (control is BunifuTextBox btxt)
            {
                btxt.FillColor = cardColor;
                btxt.ForeColor = foreColor;
                btxt.PlaceholderForeColor = Color.Gray;
                btxt.BorderColorIdle = foreColor;
            }
            else if (control is TextBox txt)
            {
                txt.BackColor = cardColor;
                txt.ForeColor = foreColor;
            }
            else if (control is Panel pnl)
            {
                pnl.BackColor = cardColor;
                ApplyToControls(pnl.Controls, foreColor, cardColor);
            }
            else if (control is BunifuCards card)
            {
                card.BackColor = cardColor;
                ApplyToControls(card.Controls, foreColor, cardColor);
            }
            else if (control.HasChildren)
            {
                ApplyToControls(control.Controls, foreColor, cardColor);
            }
        }
    }
}
