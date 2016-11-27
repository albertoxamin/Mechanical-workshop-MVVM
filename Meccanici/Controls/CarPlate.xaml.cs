using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Meccanici.Controls
{
    /// <summary>
    /// Interaction logic for CarPlate.xaml
    /// </summary>
    public partial class CarPlate : UserControl
    {
        public CarPlate()
        {
            InitializeComponent();
        }

        private void plate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsActionKey(e.Key))
            {
                if (plate.Text.Length < 7)
                {
                    if ((plate.Text.Length < 2 || plate.Text.Length >= 5) && IsNumberKey(e.Key))
                        e.Handled = true;
                    else if ((plate.Text.Length >= 2 && plate.Text.Length < 5) && !IsNumberKey(e.Key))
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
        }

        private bool IsActionKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
        }

        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
