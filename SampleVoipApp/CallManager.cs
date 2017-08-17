using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SampleVoipApp
{
    public enum CallState
    {
        NoCall,
        InCall
    };

    public class CallManager : INotifyPropertyChanged
    {
        private Windows.Media.Capture.MediaCapture captureElement;
        public CallState _callState = CallState.NoCall;

        public CallState CallState
        {
            get { return _callState; }
            set
            {
                _callState = value;
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CallState"));
                }
            }
        }
        
        async public void Toggle(Windows.UI.Xaml.Controls.CaptureElement preview)
        {
            if (CallState == CallState.NoCall)
            {
                // Start call
                captureElement = new Windows.Media.Capture.MediaCapture();
                await captureElement.InitializeAsync();

                preview.Source = captureElement;
                await captureElement.StartPreviewAsync();

                CallState = CallState.InCall;
            }
            else if (CallState == CallState.InCall)
            {
                // Stop call
                await captureElement.StopPreviewAsync();
                preview.Source = null;

                captureElement.Dispose();
                captureElement = null;
                CallState = CallState.NoCall;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
