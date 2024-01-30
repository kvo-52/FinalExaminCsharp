namespace WebAppUser.Model
{
    public interface IUserAuthenticationService
    {
        UserModel Authenticate(LoginModel model);
    }
}
