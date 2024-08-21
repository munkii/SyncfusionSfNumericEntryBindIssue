//-----------------------------------------------------------------------
// <copyright file="SfSchedulerSelectionChangedToSimpleCommandBehavior.cs" company="Magic Bullet Ltd">
//     Copyright (c) Magic Bullet Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ProjectBreatheApp.Maui.Behaviors
{
    using System;
    using System.Windows.Input;
    using ProjectBreatheApp.Maui.ViewModels.BloodGlucose;
    using Syncfusion.Maui.Scheduler;

    /// <summary>
    /// Behavior that maps the SelectionChanged event on <see cref="SfScheduler"/> to a simpler command that just takes a DateTime, see <see cref="DateTimeCommandProperty"/>.
    /// </summary>
    public class SfSchedulerSelectionChangedToSimpleCommandBehavior : Behavior<SfScheduler>
    {
        public static readonly BindableProperty DateChangedSimpleCommandProperty =
                    BindableProperty.Create("DateChangedSimpleCommand", typeof(Command<SelectedDateChangedEventArgs>), typeof(SfSchedulerSelectionChangedToSimpleCommandBehavior), propertyChanged: OnDateTimeCommandChanged);

        public ICommand DateChangedSimpleCommand
        {
            get
            {
                return (Command<SelectedDateChangedEventArgs>)this.GetValue(DateChangedSimpleCommandProperty);
            }

            set
            {
                this.SetValue(DateChangedSimpleCommandProperty, value);
            }
        }

        public static void OnDateTimeCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SfSchedulerSelectionChangedToSimpleCommandBehavior behavior = bindable as SfSchedulerSelectionChangedToSimpleCommandBehavior;
            behavior.DateChangedSimpleCommand = newValue as Command<SelectedDateChangedEventArgs>;
        }

        protected override void OnAttachedTo(SfScheduler calendar)
        {
            calendar.SelectionChanged += this.Calendar_SelectionChanged;
            calendar.BindingContextChanged += this.Calendar_BindingContextChanged;
            base.OnAttachedTo(calendar);
        }

        protected override void OnDetachingFrom(SfScheduler calendar)
        {
            this.BindingContext = null;
            calendar.SelectionChanged -= this.Calendar_SelectionChanged;
            calendar.BindingContextChanged -= this.Calendar_BindingContextChanged;
            base.OnDetachingFrom(calendar);
        }

        private void Calendar_SelectionChanged(object sender, SchedulerSelectionChangedEventArgs e)
        {
            if (this.DateChangedSimpleCommand != null)
            {
                this.DateChangedSimpleCommand.Execute(new SelectedDateChangedEventArgs(e.OldValue, e.NewValue));
            }
        }

        private void Calendar_BindingContextChanged(object sender, EventArgs e)
        {
            // This is required as the Behavior does not get a BindingContext by default.
            var calendar = sender as SfScheduler;
            this.BindingContext = calendar.BindingContext;
        }
    }
}
