using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model.Annotations;

namespace Model
{
    public class FrameParametersModel: Model, IDataErrorInfo
    {
        private float _width;
        private float _height; 
        private float _dwidth;
        private float _dheight;
        
        public FrameParametersModel(): base() {}
        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyPropertyChanged();
            }
        }
        public float Height 
        { 
            get => _height;
            set
            {
                _height = value;
                NotifyPropertyChanged();
            } 
        }
        public float DHeight 
        {
            get => _dheight;
            set
            {
                _dheight = value;
                NotifyPropertyChanged();
            }
        }

        public float DWidth
        {
            get => _dwidth;
            set
            {
                _dwidth = value;
                NotifyPropertyChanged();
            }
            
        }
        
        public float Area => Width * Height - (Width - 2 * DWidth) * (Height - 2 * DHeight);

        public string Error { get; }

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Width":
                    {
                        if (!(Width >= 10 && Width <= 200))
                        {
                            result = "Width and Height should be between 10 and 200";
                        }

                        break;
                    }
                    case "Height":
                    {
                        if (!(Height >= 10 && Height <= 200))
                        {
                            result = "Width and Height should be between 10 and 200";
                        }

                        break;
                    }
                    case "DWidth":
                    {
                        if (!(DWidth >= 1 && DWidth <= 9))
                        {
                            result = "DWidth and DHeight should be between 1 and 9";
                        }

                        break;
                    }
                    case "DHeight":
                    {
                        if (!(DHeight >= 1 && DHeight <= 9))
                        {
                            result = "DWidth and DHeight should be between 1 and 9";
                        }

                        break;
                    }
                }

                return result;
            }
        }

        public bool Validate() => ValidateInner() && ValidateOuter();

        private bool ValidateOuter()
        {
            return (Width >= 10 && Width <= 200) && (Height >= 10 && Height <= 200);
        }
        
        private bool ValidateInner()
        {
            return (DWidth >= 1 && DWidth <= 9) && (DHeight >= 1 && DHeight <= 9);
        }

        public override string ToString()
        {
            return $"{Width}x{Height}x{DWidth}x{DHeight}";
        }
    }
}