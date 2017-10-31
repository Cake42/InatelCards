namespace InatelCards
{
	using UnityEngine;

    public abstract class Professor : Card
    {
		public const int DefaultHealthPoint = 100;

		private Card otherCard;

		public abstract int DefaultAttack { get; }

		public abstract int DefaultDefense { get; }

		public int Attack { get; set; }

		public int Defense { get; set; }

		public int HealthPoint { get; set; }

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{

			}
		}
	}
}
