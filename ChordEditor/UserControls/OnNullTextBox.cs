using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChordEditor.UserControls
{
    public partial class OnNullTextBox : TextBox
    {
        // Within your class or scoped in a more appropriate location:
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        public OnNullTextBox()
        {
            InitializeComponent();
        }

        private string mNullString = null;
        public string NullString
        {
            get { return mNullString; }
            set 
            {
                mNullString = value;
                SendMessage(Handle, 0x1501, 1, mNullString != null ? mNullString : "" );
            }
        }

    }
}
