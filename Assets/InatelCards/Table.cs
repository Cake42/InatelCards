namespace InatelCards
{
	using System.Collections.Generic;

	public static class Table
	{
		private static List<Card> cards;

		static Table()
		{
			Table.cards = new List<Card>();
		}

		public static void AddCard(Card card)
		{
			Table.cards.Add(card);
		}
	}
}
