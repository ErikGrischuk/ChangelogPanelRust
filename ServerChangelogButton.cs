using System;
using Rust.UI;
using UnityEngine;

public class ChangelogButton : MonoBehaviour
{
	private void Update()
	{
		BaseGameMode activeGameMode = BaseGameMode.GetActiveGameMode(false);
		if (activeGameMode != null)
		{
			if (this.CanvasGroup.alpha != 1f)
			{
				this.CanvasGroup.alpha = 1f;
				this.CanvasGroup.blocksRaycasts = true;
				this.Button.Text.SetPhrase(new Translate.Phrase(activeGameMode.shortname, activeGameMode.shortname), Array.Empty<object>());
				return;
			}
		}
		else if (this.CanvasGroup.alpha != 0f)
		{
			this.CanvasGroup.alpha = 0f;
			this.CanvasGroup.blocksRaycasts = false;
		}
	}

	public ChangelogButton()
	{
	}

	public RustButton Button;

	public CanvasGroup CanvasGroup;
}
