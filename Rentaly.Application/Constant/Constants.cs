namespace Rentaly.Application.Constant;
public static class Constants
{
    public const decimal AdditionalFeeForMoreThan3Accessories = 20;

    public const string Price_DESC = "price_desc";

    public const string Price_ASC = "price_asc";

    public const string Admin = "Admin";
    public static List<int> AdminUserUseCaseIds => 
        new List<int> { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12, 15, 16, 17, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 32, 33, 50 };
    public static List<int> AnonimousUserUseCaseIds =>  new List<int> { 1, 5, 31, 10, 4, 3, 7, 35, 30, 36, 20, 34, 25, 21, 23 };
    public static List<int> RegularUserUseCaseIds => new List<int> { 8, 9, 10, 13, 14, 17, 18, 20, 21, 23, 24, 25, 28, 30, 31 };
}

