using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace DebuggingSilverlightApp
{
    public partial class MainPage
    {
        public event EventHandler DummyEvent = delegate { };

        public int Counter { get; set; }

        public MainPage()
        {
            InitializeComponent();

            UpdateDisplayCounter();
        }

        private void btnHangTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception("Dummy exception");
            }
            catch
            {
                // oh dear, we're swallowing the exception - bad programming!
            }
            Thread.Sleep(30000);
            btnHangTime.Content = "Pushed"; 
        }

        
        private void btnMemoryLeak_Click(object sender, RoutedEventArgs e)
        {
            // remove the view
            ViewContainer.Children.Clear();

            // create a new instance of the view
            var newView = new TestView();
            
            // the following line is the source of the memory leak, when the
            // view is cleared the previous view cannot be garbage collected
            DummyEvent += newView.EventHandler;

            // add the view to the stackpanel
            ViewContainer.Children.Add(newView);

            // increment our display counter
            this.Counter++;
            UpdateDisplayCounter();
        }
        
        private void UpdateDisplayCounter()
        {
            this.CounterTextBlock.Text = Counter.ToString(CultureInfo.InvariantCulture);
        }
    }
}
