using System;
using MaterialDesignThemes.Wpf;

namespace WpfUI.Model
{
    public class SnackbarMessageProvider
    {
        public static SnackbarMessageProvider Instance { get; } = new SnackbarMessageProvider();
        public SnackbarMessageQueue MessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));

        public void Enqueue(object content)
        {
            MessageQueue.Enqueue(content);
        }
    }
}
