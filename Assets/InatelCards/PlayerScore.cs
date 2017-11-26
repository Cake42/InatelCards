namespace InatelCards
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
			return Score.CompareTo(other.Score);
		}
	}
}
