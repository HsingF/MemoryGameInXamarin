using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMemoria
{
	public partial class MainPage : ContentPage
	{
        private MatrizMemoria mm;
        private Button primero;
        private Button segundo;

		public MainPage()
		{
            mm = new MatrizMemoria();
            mm.GenerarMatriz();
            primero = null;
            segundo = null;
			InitializeComponent();
		}

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (primero == null)
            { // there is no button selected yet
                primero = button;
                primero.Text = GetByPosition(button);
                primero.BackgroundColor = Color.YellowGreen;
            }
            else if (segundo == null)
            { // there is only one button selected
                if (primero != button)
                {
                    segundo = button;
                    segundo.Text = GetByPosition(button);
                    segundo.BackgroundColor = Color.YellowGreen;
                }
            }
            else
            { // there are 2 buttons selected
                if (CheckMatch() && (button == primero || button == segundo)) // true if there was a match
                    primero = null;
                else // wasnt a match
                {
                    primero = button;
                    primero.Text = GetByPosition(button);
                    primero.BackgroundColor = Color.YellowGreen;
                }
                segundo = null;
            }
        }

        async void PrintClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Answer",mm.GetAnswer(), "CLOSE");
        }

        public string GetByPosition(Button b)
        {
            int r1 = (int)Char.GetNumericValue(b.AutomationId[0]);
            int c1 = (int)Char.GetNumericValue(b.AutomationId[1]);
            return mm.GetByPosition(r1,c1);
        }

        public bool CheckMatch() // true if there is a match between primero and segundo
        {
            int r1 = (int)Char.GetNumericValue(primero.AutomationId[0]);
            int c1 = (int)Char.GetNumericValue(primero.AutomationId[1]);
            int r2 = (int)Char.GetNumericValue(segundo.AutomationId[0]);
            int c2 = (int)Char.GetNumericValue(segundo.AutomationId[1]);
            if (mm.GetByPosition(r1, c1) == mm.GetByPosition(r2, c2)) // match
            {
                primero.BackgroundColor = Color.Gray;
                segundo.BackgroundColor = Color.Gray;
                primero.IsEnabled = false;
                segundo.IsEnabled = false;
                return true;
            }
            else //no match
            {
                primero.BackgroundColor = Color.Orange;
                segundo.BackgroundColor = Color.Orange;
                primero.Text = " ";
                segundo.Text = " ";
                return false;
            }
        }
        
    }
}
