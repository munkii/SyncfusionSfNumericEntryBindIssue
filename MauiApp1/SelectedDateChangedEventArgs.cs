// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectedDateChangedEventArgs.cs" company="Magic Bullet Ltd">
//     Copyright (c) Magic Bullet Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ProjectBreatheApp.Maui.ViewModels.BloodGlucose
{
    using System;

    /// <summary>
    /// EventArgs class used by <see cref="BloodGlucoseCaptureViewModel"/> to communicate the SelectedDate change and what it is changing from.
    /// </summary>
    public class SelectedDateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedDateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="changingFrom">The date changing from.</param>
        /// <param name="changingTo">The date changing to.</param>
        public SelectedDateChangedEventArgs(DateTime? changingFrom, DateTime? changingTo)
        {
            this.ChangingFrom = changingFrom;
            this.ChangingTo = changingTo;
        }

        public DateTime? ChangingFrom { get; private set; }

        public DateTime? ChangingTo { get; private set; }
    }
}
