namespace InatelCards.ScoreBoard
{
	using System;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	public class ScoreReaderWriter
    {
		public const string FileName = @"scores.dat";

		public ScoreReaderWriter()
		{
			if (!File.Exists(FileName))
			{
				File.Create(FileName).Dispose();
				this.Serialize(new PlayerScore[]
				{
					new PlayerScore(0, "AlunoInatel"),
					new PlayerScore(0, "AlunoInatel"),
					new PlayerScore(0, "AlunoInatel"),
					new PlayerScore(0, "AlunoInatel"),
					new PlayerScore(0, "AlunoInatel")
				});
			}
		}

		public PlayerScore[] HighScores
		{
			get
			{
				PlayerScore[] scores;

				using (Stream file = new FileStream(FileName, FileMode.Open, FileAccess.Read))
				{
					scores = (PlayerScore[])new BinaryFormatter().Deserialize(file);
				}

				return scores;
			}
		}

		public bool SubmitScore(int score, string name)
		{
			PlayerScore[] scores = this.HighScores;

			if (score > scores[4].Score)
			{
				scores[4] = new PlayerScore(score, name);
				this.BubbleSort(scores);
				this.Serialize(scores);
				return true;
			}

			return false;
		}

		private void BubbleSort(PlayerScore[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (array[i].CompareTo(array[j]) < 0)
					{
						PlayerScore temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		private void Serialize(PlayerScore[] scores)
		{
			using (Stream file = new FileStream(FileName, FileMode.Open, FileAccess.Write))
			{
				new BinaryFormatter().Serialize(file, scores);
			}
		}
    }
}
