namespace InatelCards
{
	public class Renzo : Professor
	{
		public override int DefaultAttack
		{
			get
			{
				return 15;
			}
		}

		public override int DefaultDefense
		{
			get
			{
				return 20;
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
