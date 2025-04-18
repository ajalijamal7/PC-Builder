using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Builder
{
    public partial class frm_settings: Form
    {
        public frm_settings()
        {
            InitializeComponent();
           // ThemeManager.ApplyTheme(this);
        }
        private void HighlightSelectedThemeCard()
        {
            if (ThemeManager.IsDarkMode)
            {
                crd_Light.color= Color.WhiteSmoke;
                crd_dark.color = Color.Crimson;
            }
            else if(!ThemeManager.IsDarkMode)
            {
                crd_dark.color = Color.White;
                crd_Light.color = Color.Crimson;
            }
        }

        private void pnl_settings_Load(object sender, EventArgs e)
        {

        }

        private void crd_Light_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void pnl_Light_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = false;
            ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        }

        private void crd_Light_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = false;
            ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        
    }

        private void crd_dark_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = true;
            ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        }

        private void lbl_light_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = false;
            ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        }

        private void pnl_Dark_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = true;
            ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        }

        private void lbl_Dark_Click(object sender, EventArgs e)
        {
            ThemeManager.IsDarkMode = true;
           ThemeManager.ApplyTheme(this);
            HighlightSelectedThemeCard();
        }

    }
}


