namespace LoginForm
{
    using LoginForm;
    using Microsoft.Maui.Controls;
    using Syncfusion.Maui.DataForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignInFormBehavior : Behavior<ContentPage>
    {

        /// <summary>
        /// Holds the data form object.
        /// </summary>
        private SfDataForm dataForm;

        /// <summary>
        /// Holds the sign in button instance.
        /// </summary>
        private Button signInButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("signInForm");
            if (dataForm != null)
            {
                this.dataForm.GenerateDataFormItem += this.OnGenerateDataFormItem;
            }

            this.signInButton = bindable.FindByName<Button>("signInButton");

            if (this.signInButton != null)
            {
                this.signInButton.Clicked += OnSignInButtonCliked;
            }
        }

        /// <summary>
        /// Invokes on each data form item generation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.FieldName == nameof(SignInFormModel.UserName) && e.DataFormItem is DataFormTextEditorItem textItem)
            {
                textItem.Keyboard = Keyboard.Email;
            }
        }

        /// <summary>
        /// Invokes on sign in button click.
        /// </summary>
        /// <param name="sender">The sign in button.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnSignInButtonCliked(object sender, EventArgs e)
        {
            if(this.dataForm != null && App.Current?.MainPage != null)
            {
                if(this.dataForm.Validate())
                {
                    await App.Current.MainPage.DisplayAlert("", "Signed in successfully", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.signInButton != null)
            {
                this.signInButton.Clicked -= OnSignInButtonCliked;  
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= this.OnGenerateDataFormItem;
            }
        }
    }
}
