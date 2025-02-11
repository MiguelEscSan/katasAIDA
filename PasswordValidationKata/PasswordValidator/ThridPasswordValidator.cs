
namespace PasswordValidator;

public class ThirdPasswordValidator: IPasswordValidator{

    public ThirdPasswordValidator(){

        }

    public bool ValidatePassword(string password)
    {
        if(password.Length < 16) return false;

        if(!password.Any(char.IsUpper)) return false;

        if(!password.Any(char.IsLower)) return false;

        return true;
    }
}
