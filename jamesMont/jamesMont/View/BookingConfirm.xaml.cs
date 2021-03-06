﻿using jamesMont.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jamesMont.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingConfirm : ContentPage
	{
        string clientName5, procedure, email;
        int slots;
        DateTime picked;

		public BookingConfirm ( string bookingTime, string clientName, int slot, DateTime p, string pro)
		{
			InitializeComponent ();
            clientName5 = clientName;
            picked = p;
            slots = slot;
            procedure = pro;

            foreach (var item in MainPage.UserEmail)
            {
                email = item;
            }
            LabelBook.Text = "Booking time: "+ bookingTime;
            LabelBook2.Text = "Booking Date: " + p.ToString("dd/MM/yyyy");

		}
        AzureService2 azureService;
        async private void book_method(object sender, EventArgs e)
        {
            azureService = new AzureService2();
            await azureService.AddBooking(clientName5, slots, picked, procedure, email);

            await Navigation.PushAsync(new MenuPage(clientName5));
        }
    }
}