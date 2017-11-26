namespace InatelCards
{
	using UnityEngine;

	public class Table : MonoBehaviour
	{
		private Card card1Player1;

		private Card card2Player1;

		private Card card1Player2;

		private Card card2Player2;

		[SerializeField]
		private GameController gameController;

		public void AddCard(PlayerNumber player, Card card)
		{
			if (player == PlayerNumber.Player1)
			{
				if (this.card1Player1 == null)
				{
					this.card1Player1 = card;
					this.card1Player1.transform.position = new Vector3(-1, -1);
				}
				else
				{
					this.card2Player1 = card;
					this.card2Player1.transform.position = new Vector3(1, -1);
				}
			}
			else
			{
				if (card1Player2 == null)
				{
					this.card1Player2 = card;
					this.card1Player2.transform.position = new Vector3(-1, 1);
				}
				else
				{
					this.card2Player2 = card;
					this.card2Player2.transform.position = new Vector3(1, 1);
				}
			}

			this.CompareCards();
		}

		private void CompareCards()
		{
			if (this.card1Player1 != null && this.card1Player2 != null
				&& this.card2Player1 != null && this.card2Player2 != null)
			{
				int attack1 = 0;
				int defense1 = 0;
				int attack2 = 0;
				int defense2 = 0;

				Professor professor;

				if (this.card1Player1 is Professor)
				{
					professor = (Professor)this.card1Player1;
					attack1 += professor.Attack;
					defense1 += professor.Defense;
				}

				if (card2Player1 is Professor)
				{
					professor = (Professor)this.card2Player1;
					attack1 += professor.Attack;
					defense1 += professor.Defense;
				}

				if (card1Player2 is Professor)
				{
					professor = (Professor)this.card1Player2;
					attack2 += professor.Attack;
					defense2 += professor.Defense;
				}

				if (card2Player2 is Professor)
				{
					professor = (Professor)this.card2Player2;
					attack2 += professor.Attack;
					defense2 += professor.Defense;
				}

				if (attack1 > defense2)
				{
					this.card1Player2.Kill(this.gameController.Player1);
					this.card2Player2.Kill(this.gameController.Player1);
					this.gameController.Player1.ReturnCards(
						this.card1Player1,
						this.card2Player1);
				}

				if (attack2 > defense1)
				{
					this.card1Player1.Kill(this.gameController.Player2);
					this.card2Player1.Kill(this.gameController.Player2);
					this.gameController.Player2.ReturnCards(
						this.card1Player2,
						this.card2Player2);
				}

				this.card1Player1 = null;
				this.card2Player1 = null;
				this.card1Player2 = null;
				this.card2Player2 = null;
			}
		}
	}
}
