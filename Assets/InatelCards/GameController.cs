namespace InatelCards
{
	using InatelCards.ScoreBoard;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[DisallowMultipleComponent]
	public class GameController : MonoBehaviour
	{
		private PlayerNumber currentPlayer;

		private bool changeTurn;

		[SerializeField]
		private Player player1;

        [SerializeField]
        private Player player2;

		[SerializeField]
		private Table table;

		private bool gameStarted;

		public PlayerNumber CurrentPlayer
		{
			get { return this.currentPlayer; }
		}

        public Player Player1
        {
            get { return this.player1; }
            set { this.player1 = value; }
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

		internal bool IsDisabled { get; set; }

		internal void ChangeTurn()
		{
			this.changeTurn = true;
		}

		internal void EndGame()
		{
			ScoreReaderWriter leaderboard = new ScoreReaderWriter();
			
			leaderboard.SubmitScore(this.player1.Score, MainMenu.MainMenu.Name1);
			leaderboard.SubmitScore(this.player2.Score, MainMenu.MainMenu.Name2);

			SceneManager.LoadScene("ScoreBoard");
		}

		private void Awake()
		{
            this.currentPlayer = PlayerNumber.None;
        }

		private void Start()
		{
			this.player1.HideCards();
			this.player2.HideCards();
		}

		private void LateUpdate()
		{
			if (this.changeTurn)
			{
				if (this.currentPlayer == PlayerNumber.None)
				{
					this.currentPlayer = PlayerNumber.Player1;
					this.player1.ResetPosition();
					this.player2.ResetPosition();
				}
				else if (this.currentPlayer == PlayerNumber.Player1)
				{
					this.currentPlayer = PlayerNumber.Player2;
					this.player1.ResetPosition();
					this.player2.ResetPosition();
				}
				else
				{
					this.currentPlayer = PlayerNumber.None;
				}

				this.player1.HideCards();
				this.player2.HideCards();

				this.changeTurn = false;
				Camera.main.GetComponent<CameraController>().Next();
			}

			if (!this.gameStarted && Input.GetKeyDown(KeyCode.Return))
			{
				this.gameStarted = true;
				this.changeTurn = true;
			}
		}
	}
}
