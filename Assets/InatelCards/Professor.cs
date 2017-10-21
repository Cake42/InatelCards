namespace InatelCards
{
    public abstract class Professor : Card
    {
		public Professor(int attack, int defense)
		{
			this.Attack = attack;
			this.Defense = defense;
		}

		public int Attack { get; set; }

		public int Defense { get; set; }
    }
}
