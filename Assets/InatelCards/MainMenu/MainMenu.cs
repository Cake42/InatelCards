namespace InatelCards.MainMenu
{
	using System.Linq;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using UnityEngine.UI;

	[DisallowMultipleComponent]
	public class MainMenu : MonoBehaviour
	{
		private static string name1;

		private static string name2;
		
		private enum Reason
		{
			None,
			IsNullOrEmpty,
			IsOnlyWhiteSpaces,
			TooBig
		}

		internal static string Name1
		{
			get
			{
				return MainMenu.name1;
			}

			set
			{
				MainMenu.name1 = value;
			}
		}

		internal static string Name2
		{
			get
			{
				return MainMenu.name2;
			}

			set
			{
				MainMenu.name2 = value;
			}
		}

		public void StartGamePressed()
		{
			string name1 = GameObject.Find("Text1").GetComponent<Text>().text;
			string name2 = GameObject.Find("Text2").GetComponent<Text>().text;

			Reason reason1 = this.IsValidName(name1);
			Reason reason2 = this.IsValidName(name2);

			if (reason1 == Reason.None && reason2 == Reason.None)
			{
				MainMenu.name1 = name1;
				MainMenu.name2 = name2;
				SceneManager.LoadScene("InatelCards");
			}
			else
			{
				string text1 = string.Empty;
				string text2 = string.Empty;

				if (reason1 == Reason.IsNullOrEmpty
					|| reason1 == Reason.IsOnlyWhiteSpaces)
				{
					text1 = "Nome não pode estar vazio!";
				}
				else if (reason1 == Reason.TooBig)
				{
					text1 = "Nome não pode ter mais que 10 caracteres!";
				}

				if (reason2 == Reason.IsNullOrEmpty
					|| reason2 == Reason.IsOnlyWhiteSpaces)
				{
					text2 = "Nome não pode estar vazio!";
				}
				else if (reason2 == Reason.TooBig)
				{
					text2 = "Nome não pode ter mais que 10 caracteres!";
				}

				GameObject.Find("Reason1").GetComponent<Text>().text = text1;
				GameObject.Find("Reason2").GetComponent<Text>().text = text2;
			}
		}

		private Reason IsValidName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return Reason.IsNullOrEmpty;
			}
			else if (name.All(c => char.IsWhiteSpace(c)))
			{
				return Reason.IsOnlyWhiteSpaces;
			}
			else if (name.Length > 10)
			{
				return Reason.TooBig;
			}
			else
			{
				return Reason.None;
			}
		}
	}
}
