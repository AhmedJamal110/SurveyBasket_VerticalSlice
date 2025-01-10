namespace SurveyBasket_VerticalSlice.Errors
{
    public class UserError
    {
        public static readonly Error EmailDuplicated
           = new("Email.Duplicated", "Email is alreday Exist Try anothr one");

        public static readonly Error EmailNotConfirmed
            = new("user.EmailConfirmed", "Please Confirmed your Email");


        public static readonly Error IvalidCredentials
            = new("user.notFound", "Email Or Password wrong Try again");

        public static readonly Error TokenError
        = new("user.Token", "Token Is wrong Try again");

        public static readonly Error InvalidCode
                = new("user.Code", "Code Is wrong Try again");

        public static readonly Error ConfirmEmailDuplicated
           = new("Email.ConfirmEmail", "Email is alreday Confirmed");


    }
}
