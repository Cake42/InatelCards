namespace InatelCards
{
	using System;
	using UnityEngine;

	public class Deck
	{
		public const int DefaultCardQuantity = 8;
		
		public Deck()
		{
			this.Cards = new Card[DefaultCardQuantity];
		}

		public Card[] Cards { get; set; }

		public void DrawCards()
		{
			for (int i = 0; i < this.Cards.Length; i++)
			{
				this.Cards[i] = Card.CreateCard((
					ProfessorCards)UnityEngine.Random.Range(
						0,
						Enum.GetValues(typeof(ProfessorCards)).Length));
			}
		}
	}
}
