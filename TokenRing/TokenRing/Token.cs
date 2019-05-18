using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenRing
{
    class Token : INotifyPropertyChanged
    {
        private bool _IsFree;
        private int _Source;
        private int _Destination;
        private int _CurrentCalculator;
        private string _msg;
        private string _response;
        private bool _IsAnswer;

        public bool IsFree
        {
            get { return _IsFree; }
            set
            {
                _IsFree = value;
                propChanged(nameof(IsFree));
            }
        }
        public int Source {
            get { return _Source; }
            set
            {
                _Source = value;
                propChanged(nameof(Source));
            }
        }

        public int Destination
        {
            get { return _Destination; }
            set
            {
                _Destination = value;
                propChanged(nameof(Destination));
            }
        }

        public int CurrentCalculator {
            get { return _CurrentCalculator; }
            set
            {
                _CurrentCalculator = value;
                propChanged(nameof(CurrentCalculator));
            }
        }

        public string msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                propChanged(nameof(msg));
            }
        }
        public string response
        {
            get { return _response; }
            set
            {
                _response = value;
                propChanged(nameof(response));
            }
        }
        public bool IsAnswer
        {
            get { return _IsAnswer; }
            set
            {
                _IsAnswer = value;
                propChanged(nameof(IsAnswer));
            }
        }



        public Token()
        {
            this.IsFree = true;

        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private void propChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
