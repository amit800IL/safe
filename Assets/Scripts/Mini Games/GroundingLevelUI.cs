using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

class GroundingLevelUI : LevelUI<LevelDataObject_grounding>
{
	public Button[] ChoiceButtons;
	public Button SomethingElseButton;
	[FormerlySerializedAs("Jar")] public Image JarImage;

	public override void InitData()
	{
		base.InitData();
		if (!GetDataAsType(out var groundingData)) return;
		if(JarImage != null)
			JarImage.sprite = groundingData.JarSprite;
	}
	
	private bool GetDataAsType(out LevelDataObject_grounding groundingData)
	{
		groundingData = LevelData as LevelDataObject_grounding;
		if (groundingData != null) return true;
		var type = LevelData.GetType();
		Debug.LogError($"{type} is the wrong type for this level. Please assign the right type:`LevelDataObject_grounding`");
		return false;
	}
}