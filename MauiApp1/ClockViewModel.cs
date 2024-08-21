using ProjectBreatheApp.Maui.ViewModels.BloodGlucose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiApp1
{
    class ClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int?[] slots = new int?[8];
        private int? slotValue;
        private int slotIndex;

        public ClockViewModel()
        {
            this.PropertyChanged += this.OnPropertyChanged; 
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            
        }

        public Command<SelectedDateChangedEventArgs> SelectedDateChangedCommand
        {
            get
            {
                return new Command<SelectedDateChangedEventArgs>(this.SelectedDateChangedAsync);
            }
        }

        private void SelectedDateChangedAsync(SelectedDateChangedEventArgs args)
        {
            //if (args.ChangingFrom.HasValue && args.ChangingFrom.Value.Day >= 1 && args.ChangingFrom.Value.Day <= 8)
            //{
            //    this.slots[args.ChangingFrom.Value.Day - 1] = this.SlotValue.HasValue ? this.SlotValue.Value : null;
            //}

            if (args.ChangingTo.HasValue && args.ChangingTo.Value.Day >= 1 && args.ChangingTo.Value.Day <= 8)
            {
                this.SlotIndex = args.ChangingTo.Value.Day - 1;
            }

        }

        public int? SlotValue
        {
            get => slotValue;
            set
            {
                if (slotValue != value)
                {
                    slotValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SlotValue)));
                }
            }

        }

        public int SlotIndex
        {
            get => slotIndex;
            set
            {
                if (slotIndex != value)
                {
                    this.SlotIndexAboutToChange(this.slotIndex, value);
                    slotIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SlotIndex)));
                    this.SlotIndexChanged();
                }
            }

        }

        private void SlotIndexChanged()
        {
            this.SlotValue = this.slots[slotIndex]; 
        }

        private void SlotIndexAboutToChange(int currentSlotIndex, int newSlotIndex)
        {
            this.slots[slotIndex] = this.SlotValue.HasValue ? this.SlotValue.Value : null;
        }
    }
}
