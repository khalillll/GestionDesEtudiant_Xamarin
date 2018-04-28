using Plugin.Messaging;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);


        }

        protected  override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new Login());
            return base.OnBackButtonPressed();

        }

        async private void Register_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (registerpassword.Text == cregisterpassword.Text)
                {
                    Admin admin = new Admin
                    {
                        Password = registerpassword.Text,
                        Username = adminnom.Text

                    };
                    await App.Database.Register_Admin(admin);
                    await Navigation.PushAsync(new MenuPage(admin));
                }
                else
                {
                    await DisplayAlert("Alert", "confirmer le mot de pass", "ok");
                    await Navigation.PushAsync(new Login());
                }
                
            }catch(Exception exx)
            {
                Console.WriteLine(exx);
                await Navigation.PushAsync(new Login());
            }
           
        }


        //async void Send_message(object sender, EventArgs e)
        //{
        //    var smsMessenger = CrossMessaging.Current.SmsMessenger;
        //    String number = phonenumber.Text;
            
        //    int value;
        //    if (int.TryParse(number, out value))
        //    {
        //        if (smsMessenger.CanSendSms)
        //        {
        //            Random rnd = new Random();
        //            int mm = rnd.Next(11111111, 99999999);
        //            String message = mm.ToString();
        //            smsMessenger.SendSms(number, "votre nouveau mot de pass est :"+message+"");
        //            await DisplayAlert("Alert", "message sent", "ok");
        //            await Navigation.PushAsync(new Login());
        //        }

        //    }
        //    else
        //    {
        //        await DisplayAlert("Alert", "numero de telephone n' est pas valide", "ok");
        //        await Navigation.PushAsync(new Login());
        //    }
               
        //}
        


        //async void send_mail(object sender, EventArgs e)
        //{
        //    if (IsValidEmail(email.Text))
        //    {

        //    }
        //    else
        //    {
        //        await DisplayAlert("Alert", "Email format n' est pas valide", "ok");
        //        await Navigation.PushAsync(new Login());
        //    }
        //}
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Admin a = await App.Database.GetAdminAsync(username.Text, password.Text);
                if (a != null)
                {
                    username.Text = "";
                    password.Text = "";
                    //Navigation.InsertPageBefore(new MenuPage(), this);
                    await Navigation.PushAsync(new MenuPage(a));
                }
                else
                {
                    await DisplayAlert("Alert", "le nom ou le mot de pass est inconrrct", "ok");
                    await Navigation.PushAsync(new Login());
                }
            }
            catch (Exception exep)
            {
                Console.WriteLine(exep);
                await Navigation.PushAsync(new Login());
            }



        }
        //protected async override void OnAppearing()
        //{
        //    await username.FadeTo(1, 1000, Easing.Linear);
        //    await password.FadeTo(1, 100, Easing.Linear);
        //    await login.FadeTo(1, 100, Easing.Linear);
        //    await register.FadeTo(1, 100, Easing.Linear);
        //}
    }
}