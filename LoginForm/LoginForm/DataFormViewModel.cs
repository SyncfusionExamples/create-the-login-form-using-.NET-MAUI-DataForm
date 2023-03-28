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
            this.SignInFormModel = new SignInFormModel();
        }

        /// <summary>
        /// Gets or sets the sign in model.
        /// </summary>
        public SignInFormModel SignInFormModel { get; set; }
    }
}
