﻿using System.Windows.Media;

namespace ColorPicker.Models
{
    public class NotifyableColor : NotifyableObject
    {
        IColorStateStorage storage;
        public NotifyableColor(IColorStateStorage colorStateStorage)
        {
            storage = colorStateStorage;
        }

        public void UpdateEverything(ColorState oldValue)
        {
            ColorState currentValue = storage.ColorState;
            if (currentValue.A != oldValue.A) RaisePropertyChanged(nameof(A));

            if (currentValue.A != oldValue.A || currentValue.RGB_R != oldValue.RGB_R || currentValue.RGB_G != oldValue.RGB_G || currentValue.RGB_B != oldValue.RGB_B)
                RaisePropertyChanged(nameof(RGBAColor));

            if (currentValue.RGB_R != oldValue.RGB_R) RaisePropertyChanged(nameof(RGB_R));
            if (currentValue.RGB_G != oldValue.RGB_G) RaisePropertyChanged(nameof(RGB_G));
            if (currentValue.RGB_B != oldValue.RGB_B) RaisePropertyChanged(nameof(RGB_B));

            if (currentValue.HSV_H != oldValue.HSV_H) RaisePropertyChanged(nameof(HSV_H));
            if (currentValue.HSV_S != oldValue.HSV_S) RaisePropertyChanged(nameof(HSV_S));
            if (currentValue.HSV_V != oldValue.HSV_V) RaisePropertyChanged(nameof(HSV_V));
        }

        public Color RGBAColor
        {
            get => Color.FromArgb((byte)(storage.ColorState.A * 255), (byte)(storage.ColorState.RGB_R * 255), (byte)(storage.ColorState.RGB_G * 255), (byte)(storage.ColorState.RGB_B * 255));
            set
            {
                var state = storage.ColorState;
                state.SetARGB(value.A / 255.0, value.R / 255.0, value.G / 255.0, value.B / 255.0);
                storage.ColorState = state;
            }
        }
        public double A
        {
            get => storage.ColorState.A * 255;
            set
            {
                var state = storage.ColorState;
                state.A = value / 255;
                storage.ColorState = state;
            }
        }

        public double RGB_R
        {
            get => storage.ColorState.RGB_R * 255;
            set
            {
                var state = storage.ColorState;
                state.RGB_R = value / 255;
                storage.ColorState = state;
            }
        }

        public double RGB_G
        {
            get => storage.ColorState.RGB_G * 255;
            set
            {
                var state = storage.ColorState;
                state.RGB_G = value / 255;
                storage.ColorState = state;
            }
        }

        public double RGB_B
        {
            get => storage.ColorState.RGB_B * 255;
            set
            {
                var state = storage.ColorState;
                state.RGB_B = value / 255;
                storage.ColorState = state;
            }
        }

        public double HSV_H
        {
            get => storage.ColorState.HSV_H;
            set
            {
                var state = storage.ColorState;
                state.HSV_H = value;
                storage.ColorState = state;
            }
        }

        public double HSV_S
        {
            get => storage.ColorState.HSV_S * 100;
            set
            {
                var state = storage.ColorState;
                state.HSV_S = value / 100;
                storage.ColorState = state;
            }
        }

        public double HSV_V
        {
            get => storage.ColorState.HSV_V * 100;
            set
            {
                var state = storage.ColorState;
                state.HSV_V = value / 100;
                storage.ColorState = state;
            }
        }
    }
}
