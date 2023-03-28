namespace LoginForm
{
    /// <summary>
    /// Represents the view model class for data form.
    /// </summary>
    public class DataFormViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormViewModel" /> class.
        /// </summary>
        public DataFormViewModel()
        {
            this.LoginFormModel = new LoginFormModel();
        }

        /// <summary>
        /// Gets or sets the login form model.
        /// </summary>
        public LoginFormModel LoginFormModel { get; set; }
    }
}
