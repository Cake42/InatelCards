namespace InatelCards
{
	using System.Collections.Generic;

	public static class Table
	{
		private static Card card1Player1;
		private static Card card2Player1;
		private static Card card1Player2;
		private static Card card2Player2;

		public static void AddCard(PlayerNumber player, Card card)
		{
			if (player == PlayerNumber.Player1)
			{
				if (card1Player1 == null)
				{
					card1Player1 = card;
				}
				else
				{
					card2Player2 = card;
				}
			}
			else
			{
				if (card1Player2 == null)
				{
					card1Player2 = card;
				}
				else
				{
					card2Player2 = card;
				}
			}
		}
	}
}
