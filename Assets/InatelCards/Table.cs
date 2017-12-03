namespace InatelCards
{
	using UnityEngine;

	public class Table : MonoBehaviour
	{
		private Card card1Player1;

		private Card card2Player1;

		private Card card1Player2;

		private Card card2Player2;

		private Player winner;

		private Player loser;

		private bool suspend;

		private bool compare;

		[SerializeField]
		private GameController gameController;

		public void AddCard(PlayerNumber player, Card card)
		{
			const int Left = -20;
			const int Right = 6;
			const int Top = -18;
			const int Down = 1;

			card.transform.rotation = Quaternion.identity;
			if (player == PlayerNumber.Player1)
			{
				if (this.card1Player1 == null)
				{
					this.card1Player1 = card;
					this.card1Player1.transform.position = new Vector3(
						Left,
						Top,
						this.card1Player1.transform.position.z);
				}
				else
				{
					this.card2Player1 = card;
					this.card2Player1.transform.position = new Vector3(
						Left,
						Down,
						this.card1Player1.transform.position.z);
				}
			}
			else
			{
				if (this.card1Player2 == null)
				{
					this.card1Player2 = card;
					this.card1Player2.transform.position = new Vector3(
						Right,
						Top,
						this.card1Player1.transform.position.z);
				}
				else
				{
					this.card2Player2 = card;
					this.card2Player2.transform.position = new Vector3(
						Right,
						Down,
						this.card1Player1.transform.position.z);

					this.suspend = true;
					this.compare = true;
				}
			}
		}

		private void Update()
		{
			if (this.compare)
			{
				this.gameController.Player1.IsSuspended = true;
				this.gameController.Player2.IsSuspended = true;

				this.card1Player1.Unhide();
				this.card2Player1.Unhide();
				this.card1Player2.Unhide();
				this.card2Player2.Unhide();

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

				if (this.card2Player1 is Professor)
				{
					professor = (Professor)this.card2Player1;
					attack1 += professor.Attack;
					defense1 += professor.Defense;
				}

				if (this.card1Player2 is Professor)
				{
					professor = (Professor)this.card1Player2;
					attack2 += professor.Attack;
					defense2 += professor.Defense;
				}

				if (this.card2Player2 is Professor)
				{
					professor = (Professor)this.card2Player2;
					attack2 += professor.Attack;
					defense2 += professor.Defense;
				}
				
				if (attack1 > attack2)
				{
					if (attack1 > defense2)
					{
						this.winner = this.gameController.Player1;
						this.loser = this.gameController.Player2;
					}
					else
					{
						this.loser = null;
						this.winner = null;
					}
				}
				else if (attack2 > attack1)
				{
					if (attack2 > defense1)
					{
						this.winner = this.gameController.Player2;
						this.loser = this.gameController.Player1;
					}
					else
					{
						this.loser = null;
						this.winner = null;
					}
				}
				else
				{
					if (defense1 > defense2)
					{
						this.winner = this.gameController.Player1;
						this.loser = this.gameController.Player2;
					}
					else if (defense2 > defense1)
					{
						this.winner = this.gameController.Player2;
						this.loser = this.gameController.Player1;
					}
					else
					{
						this.loser = null;
						this.winner = null;
					}
				}

				/*if (attack1 > defense2)
				{
					if (attack2 > defense1)
					{
						this.winner = null;
						this.loser = null;
					}
					else
					{
						this.winner = this.gameController.Player1;
						this.loser = this.gameController.Player2;
					}
				}
				else if (attack2 > defense1)
				{
					this.winner = this.gameController.Player2;
					this.loser = this.gameController.Player1;
				}
				else
				{
					this.winner = null;
					this.loser = null;
				}*/

				this.compare = false;
			}
			else if (this.suspend && Input.GetKeyDown(KeyCode.Return))
			{
				bool gameWon = false;

				if (this.winner == null)
				{
					this.gameController.Player1.ReturnCards();
					this.gameController.Player2.ReturnCards();
					this.card1Player1.Kill();
					this.card2Player1.Kill();
					this.card1Player2.Kill();
					this.card2Player2.Kill();

					gameWon = this.gameController.Player1.CardQuantity == 0
						|| this.gameController.Player2.CardQuantity == 0;
				}
				else
				{
					gameWon = this.loser.CardQuantity == 0;

					this.winner.Score += 100;
					this.winner.ReturnCards(
						this.card1Player1,
						this.card2Player1,
						this.card1Player2,
						this.card2Player2);
					this.loser.ReturnCards();
				}

				this.suspend = false;
				this.loser = null;
				this.winner = null;
				this.card1Player1 = null;
				this.card2Player1 = null;
				this.card1Player2 = null;
				this.card2Player2 = null;

				if (gameWon)
				{
					this.gameController.EndGame();
				}
				else
				{
					this.gameController.ChangeTurn();
				}
			}
		}
	}
}
