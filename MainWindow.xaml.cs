using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace StopwatchApp
{
    public partial class MainWindow : Window
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private bool _isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDisplay(_stopwatch.Elapsed);
        }

        private void UpdateDisplay(TimeSpan elapsed)
        {
            tbHours.Text   = ((int)elapsed.TotalHours).ToString("D2");
            tbMinutes.Text = elapsed.Minutes.ToString("D2");
            tbSeconds.Text = elapsed.Seconds.ToString("D2");
        }

        private void BtnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _stopwatch.Stop();
                _timer.Stop();
                // Lưu kết quả
                var elapsed = _stopwatch.Elapsed;
                tbLastRecord.Text = $"{(int)elapsed.TotalHours:D2} : {elapsed.Minutes:D2} : {elapsed.Seconds:D2}";
                btnStartStop.Content = "▶  Start";
                _isRunning = false;
            }
            else
            {
                _stopwatch.Start();
                _timer.Start();
                btnStartStop.Content = "⏸  Pause";
                _isRunning = true;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Reset();
            _timer.Stop();
            _isRunning = false;
            UpdateDisplay(TimeSpan.Zero);
            btnStartStop.Content = "▶  Start";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
