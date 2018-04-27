namespace NewWorld10
{
    public class Player
    {
        public readonly string Area;
        public readonly string Name;
        public Crystal Crystal = new Crystal();
        public Grain Grain = new Grain();
        public Land Land = new Land();
        public Metal Metal = new Metal();
        public Oil Oil = new Oil();

        public Player(string name, string area)
        {
            Name = name;
            Area = area;
        }

        public int Siedler { get; set; } = 20;
        public int Geld { get; set; } = 100;
        public int FreeMaschines { get; set; } = 0;
        public int GrainMaschines { get; set; } = 2;
        public int OilMaschines { get; set; } = 1;
        public int MetalMaschines { get; set; } = 0;
        public int CrystalMaschines { get; set; } = 0;
    }
}