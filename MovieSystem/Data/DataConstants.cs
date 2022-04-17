namespace MovieSystem.Data
{
    public class DataConstants
    {
        public class Actior
        {
            public const int NameMaxLength = 75;

            public const int BiographyMaxLength = 5000;
        }

        public class Producer
        {
            public const int NameMaxLength = 85;

            public const int BiographyMaxLength = 5000;
        }

        public class Cinema
        {
            public const int NameMaxLength = 80;

            public const int DescrpMaxLength = 4000;
        }

        public class Movie
        {
            public const int NameMaxLength = 100;

            public const int NameMinLength = 10;

            public const int DescrMaxLength = 3500;

            public const int DescrMingLength = 20;

            public const double MaxPrice = 1000;

            public const double MinPrice = 5;
        }

        public class ApplicationUser
        {
            public const int NameMinLength = 7;
            public const int NameMaxLength = 30;

            public const int PassWordMinLength = 5;          
            public const int PassWordMaxLength = 50;
        }
    }
}
