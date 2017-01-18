using System;
using System.Windows.Forms;

namespace ChordEditor.UserControls.DockingManager
{
    internal class DummyControl : Control
    {
        public DummyControl()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
