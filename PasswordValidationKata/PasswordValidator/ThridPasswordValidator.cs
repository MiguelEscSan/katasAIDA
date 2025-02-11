
namespace PasswordValidator;

public class ThirdPasswordValidator: IPasswordValidator{

    public ThirdPasswordValidator(){

        }

    public bool ValidatePassword(string password)
    {
        if(password.Length < 16) return false;

        return true;
    }
}
