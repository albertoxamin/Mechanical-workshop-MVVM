using Meccanici.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Meccanici.View
{
    /// <summary>
    /// Logica di interazione per ClientiView.xaml
    /// </summary>
    public partial class ClientiView : Page
    {
        public ClientiView()
        {
            DataContext = ViewModelLocator.ClientiViewModel;
            InitializeComponent();
        }

        public ClientiView(bool employee)
        {
            DataContext = ViewModelLocator.MeccaniciViewModel;
            InitializeComponent();
        }


        ClientiViewModel viewModel;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = DataContext as ClientiViewModel;
            viewModel.editingAnimation = SetEditing;
        }

        public void SetEditing()
        {
            if (viewModel.IsEditing)
                (this.Resources["StartedEditingAnimation"] as Storyboard).Begin();
            else
                (this.Resources["StoppedEditingAnimation"] as Storyboard).Begin();
        }

    }
}
