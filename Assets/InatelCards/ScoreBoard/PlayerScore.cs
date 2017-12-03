namespace InatelCards.ScoreBoard
{
	using System;

	[Serializable]
	public struct PlayerScore : IComparable<PlayerScore>
	{
		public string Name;
		public int Score;

		public PlayerScore(int score, string name)
		{
			this.Name = name;
			this.Score = score;
		}

		public int CompareTo(PlayerScore other)
		{
			return this.Score.CompareTo(other.Score);
		}
	}
}
