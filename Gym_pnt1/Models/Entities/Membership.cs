using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Gym_pnt1.Models.Entities
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; } // Atributo Id de Membership
        public const int PRICE_BRONZE = 100;
        public const int PRICE_SILVER = 500;
        public const int PRICE_GOLD = 1000;
        public const int SILVER_LIMIT = 4;
        public const int BRONZE_LIMIT = 2;
        public const int SILVER_EXTRA = 20;
        public const int BRONZE_EXTRA = 10;
        public int NumberOfEntries { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipCategory Category { get; set; }
        public Membership(DateTime endDate, MembershipCategory category)
        {
            EndDate = endDate;
            Category = category;
            this.NumberOfEntries = 0;
        }

        public MembershipCategory getCategory()
        {
            return Category;
        }

        public int getPrice()
        {
            int price = 0;
            int extraEntries;
            string category = Category.ToString();
            switch (category)
            {
                case "GOLD":
                    price = PRICE_GOLD;
                    break;
                case "SILVER":
                    if(NumberOfEntries > SILVER_LIMIT)
                    {
                        extraEntries = (SILVER_LIMIT - NumberOfEntries) * SILVER_EXTRA;
                        price = PRICE_SILVER + extraEntries;
                    }
                    else
                    {
                        price = PRICE_SILVER;
                    }
                    break;
                case "BRONZE":
                    if (NumberOfEntries > BRONZE_LIMIT)
                    {
                        extraEntries = (BRONZE_LIMIT - NumberOfEntries) * BRONZE_EXTRA;
                        price = PRICE_BRONZE + extraEntries;
                    }
                    else
                    {
                        price = PRICE_BRONZE;
                    }
                    break;
            }
            return price;
        }

        public void addEntry()
        {
            this.NumberOfEntries++;
        }



    }
}
