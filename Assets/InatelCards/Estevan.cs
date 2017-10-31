namespace InatelCards
{
	public class Estevan : Professor
	{
		public override int DefaultAttack
		{
			get
			{
				return 20;
			}
		}

		public override int DefaultDefense
		{
			get
			{
				return 10;
			}
		}

		private void Awake()
		{
			this.Attack = this.DefaultAttack;
			this.Defense = this.DefaultDefense;
			this.HealthPoint = Professor.DefaultHealthPoint;
		}
	}
}
