using System;
using Xamarin.Forms;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {

        String nb1 = null, nb2 = null, operation = "";
        bool isResult = false;
        float result = 0;

        public void insert(Button btn)
        {
            if (operation.Length != 0)
            {
                nb2 += btn.Text;
                lblCalcul.Text = convertToFloat(nb1) + operation + convertToFloat(nb2);
            }
            else
            {
                nb1 += btn.Text;
                lblCalcul.Text = convertToFloat(nb1) + "";
            }
        }

        public void delete(object sender, EventArgs e)
        {
            try
            {
                if (operation.Length != 0)
                {
                    if (nb2.Length > 1)
                    {
                        nb2 = nb2.Substring(0, nb2.Length - 1);
                    }
                    else
                        nb2 = "0";
                    lblCalcul.Text = convertToFloat(nb1) + operation + convertToFloat(nb2);
                }
                else
                {
                    if (nb1.Length > 1)
                    {
                        nb1 = nb1.Substring(0, nb1.Length - 1);
                    }
                    else
                        nb1 = "0";
                    lblCalcul.Text = convertToFloat(nb1) + "";
                }
            }catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public float convertToFloat(String nb_)
        {
            try
            {
                return float.Parse(nb_);
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
            return 0;
        }
        
        
        public void enterOperation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            bool isOp = false;
            String[] operations = { "+", "-", "*", "/" };
            for (int x = 0; x < operations.Length; x++)
            {
                if(lblCalcul.Text.IndexOf(operations[x]) != -1)
                {
                    isOp = true;
                    break;
                }
            }
            if (isOp)
                lblCalcul.Text = lblCalcul.Text.Substring(0, lblCalcul.Text.Length - 1);
            lblCalcul.Text = lblCalcul.Text + operation;
        }

        public void clear(object sender, EventArgs e)
        {
            nb1 = "";
            nb2 = "";
            operation = "";
            result = 0;
            lblCalcul.Text = "";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                lblCalcul.Text = lblCalcul.Text + btn.Text;
                if (isResult)
                {
                    nb1 = "";
                    nb2 = "";
                    operation = "";
                    result = 0;
                    lblCalcul.Text = btn.Text;
                    nb1 = btn.Text;
                    isResult = false;
                }
                else
                    insert(btn);
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public void _result(object sender, EventArgs e)
        {
            try
            {
                float nb1_ = convertToFloat(nb1);
                float nb2_ = convertToFloat(nb2.Substring(nb2.IndexOf(operation) + 1));

                switch (operation)
                {
                    case "+":
                        result = nb1_ + nb2_;
                        break;
                    case "-":
                        result = nb1_ - nb2_;
                        break;
                    case "/":
                        result = nb1_ / nb2_;
                        break;
                    case "*":
                        result = nb1_ * nb2_;
                        break;
                    default:
                        DisplayAlert("Error", "Cannot divide number by 0", "OK");
                        break;
                }
                lblCalcul.Text += "=" + result.ToString();
                isResult = true;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }


    }
}
