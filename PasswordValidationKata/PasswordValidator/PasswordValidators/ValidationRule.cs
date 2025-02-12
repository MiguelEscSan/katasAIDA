namespace PasswordValidator;
public interface ValidationRule{

    public bool Validate(string password);
}