using System;
using UnityEngine;
//Original repo https://github.com/adammyhre/Unity-Utils
namespace UnityUsefulUtils
{
    // Defines a basic structure for a timer using an interface.
    public interface ITimer
    {
        bool IsRunning { get; }
        void Start();
        void Stop();
        void Resume();
        void Pause();
        void Tick(float deltaTime);
    }

    // Abstract base class for all timers.
    public abstract class Timer : ITimer
    {
        protected float initialTime; // Initial time value when the timer starts.
        protected float time; // Current time value, managed internally.
        public bool IsRunning { get; protected set; } // Indicates if the timer is running.

        // Events for different timer actions.
        public event Action OnTimerStart = delegate { };
        public event Action OnTimerStop = delegate { };

        // Constructor initializing the timer with a specific time value.
        protected Timer(float value)
        {
            initialTime = value;
            IsRunning = false;
        }

        // Starts the timer and triggers an event.
        public void Start()
        {
            if (!IsRunning)
            {
                time = initialTime;
                IsRunning = true;
                OnTimerStart.Invoke();
            }
        }

        // Stops the timer and triggers an event.
        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                OnTimerStop.Invoke();
            }
        }

        // Resumes a paused timer.
        public void Resume()
        {
            IsRunning = true;
        }

        // Pauses the timer.
        public void Pause()
        {
            IsRunning = false;
        }

        // Abstract method to be implemented for updating the timer with delta time.
        public abstract void Tick(float deltaTime);
    }

    // Countdown timer that counts downwards.
    public class CountdownTimer : Timer
    {
        public CountdownTimer(float value) : base(value) { }

        // Updates the countdown timer, reducing the time.
        public override void Tick(float deltaTime)
        {
            if (!IsRunning) return;

            time -= deltaTime;
            if (time <= 0)
            {
                Stop();
            }
        }

        // Checks if the timer has finished.
        public bool isFinished => time <= 0;

        // Resets the timer to the initial set time.
        public void ResetToInitialTime() => time = initialTime;

        // Resets the timer with a new time and restarts.
        public void ResetToNewTime(float newTime)
        {
            initialTime = newTime;
            ResetToInitialTime();
        }
    }

    // Stopwatch timer that counts upwards.
    public class StopwatchTimer : Timer
    {
        public StopwatchTimer() : base(0) { }

        // Updates the stopwatch timer by increasing the time.
        public override void Tick(float deltaTime)
        {
            if (IsRunning)
            {
                time += deltaTime;
            }
        }

        // Resets the stopwatch to zero.
        public void ResetToInitialTime() => time = 0;

        // Retrieves the current time value.
        public float GetTime() => time;
    }
}
