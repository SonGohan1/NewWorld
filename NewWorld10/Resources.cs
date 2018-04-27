namespace NewWorld10
{
    public abstract class Resources
    {
        public int Balance;
        public int BuyValue;
        public int SaleValue;

        protected Resources(int buyValue)
        {
            BuyValue = buyValue;
        }
    }

    public class Land : Resources
    {
        public int FreeLand = 2;

        public Land(int buyValue = 50) : base(buyValue)
        {
            Balance = 5;
            SaleValue = (int) (buyValue * 0.9);
        }
    }

    public class Grain : Resources
    {
        public Grain(int buyValue = 25) : base(buyValue)
        {
            Balance = 25;
            SaleValue = (int) (buyValue * 0.9);
        }
    }

    public class Oil : Resources
    {
        public Oil(int buyValue = 50) : base(buyValue)
        {
            Balance = 10;
            SaleValue = (int) (buyValue * 0.9);
        }
    }

    public class Metal : Resources
    {
        public Metal(int buyValue = 60) : base(buyValue)
        {
            Balance = 5;
            SaleValue = (int) (buyValue * 0.9);
        }
    }

    public class Crystal : Resources
    {
        public Crystal(int buyValue = 75) : base(buyValue)
        {
            Balance = 0;
            SaleValue = (int) (buyValue * 0.9);
        }
    }
}