using System.Text.RegularExpressions;


public static class StringExtension
{
    public static readonly string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
    public static readonly string phoneNumber = @"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";

    public static bool IsValidEmail(this string str)
    {
        return Regex.IsMatch(str, emailPattern);
    }
    public static bool IsValidPhoneNumber(this string str)
    {
        return Regex.IsMatch(str, phoneNumber);
    }

}