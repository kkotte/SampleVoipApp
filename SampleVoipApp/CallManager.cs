using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        
        public void Toggle()
        {
            CallState = (CallState == CallState.NoCall) ? CallState.InCall : CallState.NoCall;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
