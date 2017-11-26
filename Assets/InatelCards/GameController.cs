namespace InatelCards
{
	using UnityEngine;

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private Card[] cardTypes;

		private PlayerNumber currentPlayer;

		private bool changeTurn;

		[SerializeField]
		private Player player1;

        [SerializeField]
        private Player player2;

		[SerializeField]
		private Table table;

		public Card[] CardTypes
		{
			get
			{
				return this.cardTypes;
			}
		}

		public PlayerNumber CurrentPlayer
		{
			get
			{
				return this.currentPlayer;
			}

			set
			{
				if (value == PlayerNumber.Player1)
				{
					this.player1.SetPosition(true);
					this.player2.SetPosition(false);
				}
				else if (value == PlayerNumber.Player2)
				{
					this.player1.SetPosition(false);
					this.player2.SetPosition(true);
				}
				else
				{
					throw new System.ArgumentException();
				}

				this.currentPlayer = value;
			}
		}

        public Player Player1
        {
            get { return this.player1; }
            set {  this.player1 = value; }
        }

        public Player Player2
        {
            get { return this.player2; }
            set { this.player2 = value; }
        }

		public Table Table
		{
			get { return this.table; }
			set { this.table = value; }
		}

		internal void ChangeTurn()
		{
			this.changeTurn = true;
		}

		private void Awake()
		{
            this.currentPlayer = PlayerNumber.Player1;
        }

		private void EndGame()
		{
			ScoreReaderWriter leaderboard = new ScoreReaderWriter();

			// TODO make an actual GUI for this
			leaderboard.SubmitScore(player1.Score, "AlunoInatel");
			leaderboard.SubmitScore(player2.Score, "AlunoInatel");
		}

		private void LateUpdate()
		{
			if (this.changeTurn)
			{
				this.CurrentPlayer = this.currentPlayer == PlayerNumber.Player1
					? PlayerNumber.Player2
					: PlayerNumber.Player1;
				this.changeTurn = false;
			}

			if (this.player1.CardQuantity == 0 || this.player2.CardQuantity == 0)
			{
				this.EndGame();
			}
		}
	}
}
