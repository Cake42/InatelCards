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
			card.transform.rotation = Quaternion.identity;
			if (player == PlayerNumber.Player1)
			{
				if (this.card1Player1 == null)
				{
					this.card1Player1 = card;
					this.card1Player1.transform.position = new Vector3(
						-20,
						-18,
						this.card1Player1.transform.position.z);
				}
				else
				{
					this.card2Player1 = card;
					this.card2Player1.transform.position = new Vector3(
						6,
						-18,
						this.card1Player1.transform.position.z);
				}
			}
			else
			{
				if (card1Player2 == null)
				{
					this.card1Player2 = card;
					this.card1Player2.transform.position = new Vector3(
						-20,
						1,
						this.card1Player1.transform.position.z);
				}
				else
				{
					this.card2Player2 = card;
					this.card2Player2.transform.position = new Vector3(
						6,
						1,
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

				card1Player1.Unhide();
				card2Player1.Unhide();
				card1Player2.Unhide();
				card2Player2.Unhide();

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
				}

				this.compare = false;
			}
			else if (this.suspend && Input.GetKeyDown(KeyCode.Return))
			{
				if (this.winner == null)
				{
					this.gameController.Player1.ReturnCards(
						this.card1Player1,
						this.card2Player1);
					this.gameController.Player2.ReturnCards(
						this.card1Player2,
						this.card2Player2);
				}
				else
				{
					this.winner.Score += 100;
					this.winner.ReturnCards(
						this.card1Player1,
						this.card2Player1,
						this.card1Player2,
						this.card2Player2);
					this.loser.ReturnCards();
				}

				this.suspend = false;
				this.gameController.Player1.IsSuspended = false;
				this.gameController.Player2.IsSuspended = false;
				this.loser = null;
				this.winner = null;
				this.card1Player1 = null;
				this.card2Player1 = null;
				this.card1Player2 = null;
				this.card2Player2 = null;

				Camera.main.GetComponent<CameraController>().Next();
			}
		}
	}
}
