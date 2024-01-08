using Microsoft.Maui.Graphics;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HangmanSystem
{
    public class Letter : INotifyPropertyChanged
    {
        string _publicValue = "";
        string _privateValue = "";
        bool _clickEnabled = true;
        System.Drawing.Color _color = Game.InitialLetterColor;
        System.Drawing.Color _backColor = Game.InitialBackColor;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string PublicValue
        {
            get => _publicValue;
            internal set
            {
                _publicValue = value;
                InvokePropertyChanged();
            }
        }
        internal string PrivateValue
        {
            get => _privateValue;
            set
            {
                _privateValue = value;
                InvokePropertyChanged();
            }
        }
        public bool IsEnabled
        {
            get => _clickEnabled;
            internal set
            {
                _clickEnabled = value;
                InvokePropertyChanged();
            }
        }
        public System.Drawing.Color Color
        {
            get => _color;
            internal set
            {
                _color = value;
                InvokePropertyChanged();
                InvokePropertyChanged("ColorMaui");
            }
        }
        public Microsoft.Maui.Graphics.Color ColorMaui
        {
            get
            {
                return ConvertToMauiColor(Color);
            }
        }

        public System.Drawing.Color BackColor
        {
            get => _backColor;
            internal set
            {
                _backColor = value;
                InvokePropertyChanged();
                InvokePropertyChanged("BackColorMaui");
            }
        }
        public Microsoft.Maui.Graphics.Color BackColorMaui
        {
            get
            {
                return ConvertToMauiColor(BackColor);
            }
        }


        internal void Reset(bool values, bool enabled = true, bool colors = true)
        {
            if (values)
            {
                PublicValue = "";
                PrivateValue = "";
            }
            if (colors)
            {
                Color = Game.InitialLetterColor;
                BackColor = Game.InitialBackColor;
            }
            if (enabled)
            {
                this.IsEnabled = true;
            }
        }

        void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Microsoft.Maui.Graphics.Color ConvertToMauiColor(System.Drawing.Color systemColor)
        {
            float red = systemColor.R / 255f;
            float green = systemColor.G / 255f;
            float blue = systemColor.B / 255f;
            float alpha = systemColor.A / 255f;

            return new Microsoft.Maui.Graphics.Color(red, green, blue, alpha);
        }
    }
}
