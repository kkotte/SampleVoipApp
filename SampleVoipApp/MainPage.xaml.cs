using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleVoipApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.theCallManager = new CallManager();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            theCallManager.Toggle();
        }

        public CallManager theCallManager { get; set; }
    }

    public class CallStateToGlyph : IValueConverter
    {
        public object Convert(object value, Type targetType, object paramater, string language)
        {
            CallState state = (CallState)Enum.Parse(typeof(CallState), value.ToString());
            return (state == CallState.NoCall) ? "\uE13A" : "\uE137";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException(); // Since this is a one-way binding
        }

    }

    public class CallStateToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object paramater, string language)
        {
            CallState state = (CallState)Enum.Parse(typeof(CallState), value.ToString());
            return (state == CallState.NoCall) ? new SolidColorBrush(Windows.UI.Colors.Green) : new SolidColorBrush(Windows.UI.Colors.Red); ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException(); // Since this is a one-way binding
        }

    }
}
