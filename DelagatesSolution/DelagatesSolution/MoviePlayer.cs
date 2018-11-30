using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelagatesSolution
{
    public class MoviePlayer
    {
        // C# supports delegates and events.
        // Can write a class that expects it's consumer
        // to actually "inject" behavior into it for it to use

        // this enables some Polymorphism

        public string CurrentMovie { get; set; }

        public delegate void MovieFinishedHandler();

        public delegate void MovieFinishedStringHandler(string title);

        // need delegate type to declare event,
        // all subscribing functions must match the delegate
        public event MovieFinishedStringHandler MovieFinished;

        // public event Action<string> MovieFinished;

        public void PlayMovie()
        {
            Thread.Sleep(3000); // wait for 3 seconds

            Console.WriteLine($"Finished movie {CurrentMovie}");

            // we'll fire an event when the movie is finished.
            // Any code using this movie player can subscribe to that event with some function/code they want.

            MovieFinished?.Invoke(CurrentMovie);

        }

    }
}
