﻿namespace InatelCards
{
    public abstract class Professor : Card
    {
		public const int DefaultHealthPoint = 100;

		public abstract int DefaultAttack { get; }

		public abstract int DefaultDefense { get; }

		public int Attack { get; set; }

		public int Defense { get; set; }

		public int HealthPoint { get; set; }

		protected override void Awake()
		{
			base.Awake();
			this.Attack = this.DefaultAttack;
			this.Defense = this.DefaultDefense;
			this.HealthPoint = Professor.DefaultHealthPoint;
		}
	}
}
