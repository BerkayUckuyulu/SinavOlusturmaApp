using Microsoft.AspNetCore.Identity;

namespace UI.CustomErrorDescriber
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = $"Parola en az {length} karakter olmalıdır." };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new() { Code = "PasswordRequiresNonAlphanumeric", Description = $"Parola en az bir alfanümerik(özel karakter) harf içermelidir." };

        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"{userName} zaten alınmış." };
        }
        
        
    }
}
