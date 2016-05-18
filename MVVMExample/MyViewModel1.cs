using System.ComponentModel;
using System.Windows.Input;

namespace MVVMExample
{
    class MyViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Left
        private int left;
        public int Left
        {
            get { return left; }
            set
            {
                left = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Left"));
            }
        }

        #endregion

        #region Right
        private int right;
        public int Right
        {
            get { return right; }
            set
            {
                right = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Right"));
            }
        }
        #endregion

        #region Result
        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }
        #endregion


        #region AddCommand
        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new AppCommand((object obj) =>
                    {
                        switch (selectedOperation)
                        {
                            case "+":
                                Result = Left + Right;
                                break;

                            case "-":
                                Result = Left - Right;
                                break;

                            case "*":
                                Result = (double)Left * (double)Right;
                                break;

                            case "/":
                                Result = (double)Left / (double)Right;
                                break;
                        }

                        PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                    }));
            }
        }
        #endregion


        #region Operations
        private string[] operations = new string[4] { "+", "-", "*", "/" };

        public string[] Operations
        {
            get
            {
                return operations;
            }
        }
        #endregion

        #region SelectedOperation
        private string selectedOperation;

        public string SelectedOperation
        {
            get { return selectedOperation; }
            set
            {
                if (selectedOperation == value)
                    return;

                selectedOperation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedOperation"));
            }
        }
        #endregion operation
    }
}
