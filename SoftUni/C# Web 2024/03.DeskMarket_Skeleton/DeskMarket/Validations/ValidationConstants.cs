namespace DeskMarket.Validations
{
    public static class ValidationConstants
    {
        //Product
        public const int ProductNameMaxLength = 60;
        public const int ProductNameMinLength = 2;

        public const int DescriptionMaxLength = 250;
        public const int DescriptionMinLength = 10;

        public const decimal PriceMinRange = 1.00m;
        public const decimal PriceMaxRange = 3000.00m;

        public const string DataFormat = "dd-MM-yyyy";

        //Category
        public const int CategoryNameMaxLength = 20;
        public const int CategoryNameMinLength = 3;
    }
}
