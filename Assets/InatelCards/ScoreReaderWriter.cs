namespace InatelCards
{
	using System;
	using System.IO;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Formatters.Binary;
	using UnityEngine;

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
					try
					{
						scores = (PlayerScore[])new BinaryFormatter().Deserialize(file);
					}
					catch (SerializationException e)
					{
						Debug.Log("Failed to deserialize: " + e.Message);
						throw;
					}
				}

				return scores;
			}
		}

		public bool SubmitScore(int score, string name)
		{
			PlayerScore[] scores = this.HighScores;

			if (score > scores[0].Score)
			{
				scores[0] = new PlayerScore(score, name);
				Array.Sort(scores);
				this.Serialize(scores);
				return true;
			}

			return false;
		}

		private void Serialize(PlayerScore[] scores)
		{
			using (Stream file = new FileStream(FileName, FileMode.Open, FileAccess.Write))
			{
				try
				{
					new BinaryFormatter().Serialize(file, scores);
				}
				catch (SerializationException e)
				{
					Debug.Log("Failed to serialize: " + e.Message);
					throw;
				}
			}
		}
    }
}
