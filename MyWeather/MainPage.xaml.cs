﻿using Microsoft.Azure.Amqp.Framing;
using MyWeather.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static MyWeather.Models.GetWeatherData;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await GetWeatherData.getOpentWether(); // mtweather se chua ket qua tra ve cua model
            string icon = string.Format("http://openweathermap.org/img/w/{0}.png",
                myWeather.weather[0].icon);
                ResultImager.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            ResultWeather.Text = myWeather.name + "-" +
                ((int)myWeather.main.temp).ToString() + "-" + myWeather.weather[0];

        }
    }
}
