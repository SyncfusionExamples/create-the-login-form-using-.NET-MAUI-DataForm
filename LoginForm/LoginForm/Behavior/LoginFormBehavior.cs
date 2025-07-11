﻿namespace LoginForm
{
    using LoginForm;
    using Microsoft.Maui.Controls;
    using Syncfusion.Maui.DataForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginFormBehavior : Behavior<ContentPage>
    {

        /// <summary>
        /// Holds the data form object.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// Holds the login button instance.
        /// </summary>
        private Button? loginButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("loginForm");
            this.dataForm.GenerateDataFormItem += this.OnGenerateDataFormItem;

            this.loginButton = bindable.FindByName<Button>("loginButton");

            if (this.loginButton != null)
            {
                this.loginButton.Clicked += OnLoginButtonCliked;
            }
        }

        /// <summary>
        /// Invokes on each data form item generation.
        /// </summary>
        /// <param name="sender">The data form.</param>
        /// <param name="e">The event arguments.</param>
        private void OnGenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.FieldName == nameof(LoginFormModel.Email) && e.DataFormItem is DataFormTextEditorItem textItem)
            {
                textItem.Keyboard = Keyboard.Email;
            }
        }

        /// <summary>
        /// Invokes on login button click.
        /// </summary>
        /// <param name="sender">The login button.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnLoginButtonCliked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                if (this.dataForm.Validate())
                {
                    await DisplayAlert("", "Signed in successfully", "OK");
                }
                else
                {
                    await DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.loginButton != null)
            {
                this.loginButton.Clicked -= OnLoginButtonCliked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= this.OnGenerateDataFormItem;
            }
        }

        /// <summary>
        /// Displays an alert dialog to the user.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="cancel">The text for the cancel button.</param>
        /// <returns>A task representing the asynchronous alert display operation.</returns>
        private Task DisplayAlert(string title, string message, string cancel)
        {
            return App.Current?.Windows?[0]?.Page!.DisplayAlert(title, message, cancel)
                   ?? Task.FromResult(false);
        }
    }
}
