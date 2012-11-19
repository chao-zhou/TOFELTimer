using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TOFELTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tasks = new TaskManager().GetTasks();
            comboTask.ItemsSource = Tasks;
            comboTask.SelectedIndex = 0;

            Timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            Timer.Tick += Timer_Tick;

            NotificationManager = new NotificationManager();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Play();
        }

        private void Play()
        {
            Timer.Stop();

            var task = comboTask.SelectedItem as Task;
            if(task == null)
                return;

            CurrentTask = task;
            CurrentStep = 0;
            PassedSeconds = GetCurrentStepSeconds();
            secondShow.Text = PassedSeconds.ToString();

            Timer.Start();
            NotificationManager.ShowToast("Prepare Time is Start!");

        }



        void Timer_Tick(object sender, object e)
        {
            PassedSeconds--;

            if (PassedSeconds <=0 && CurrentStep == 0)
            {
                CurrentStep = 1;
                PassedSeconds = GetCurrentStepSeconds();
                /*Notify Step One Complete*/
                NotificationManager.ShowToast("Prepare Time is End! Response Time Start!");
            }
            else if (PassedSeconds <= 0 && CurrentStep == 1)
            {
                /*Notify Step One Complete*/
                Timer.Stop();
                NotificationManager.ShowToast("Response Time End!");
            }

            Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                     () =>
                                         {
                                             secondShow.Text = PassedSeconds.ToString();
                                         });

        }

        int GetCurrentStepSeconds()
        {
            return CurrentStep == 0 ? CurrentTask.PreparedSeconds : CurrentTask.ResponseSeconds;
        }


        private static Task CurrentTask { get; set; }
        private static int CurrentStep { get; set; }
        private static int PassedSeconds { get; set; }

        private IEnumerable<Task> Tasks { get; set; }
        private DispatcherTimer Timer { get; set; }
        private NotificationManager NotificationManager { get; set; }


       
       
    }
}
