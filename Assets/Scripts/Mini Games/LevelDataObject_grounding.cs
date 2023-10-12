using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Level Data/Create grounding level data", fileName = "Grounding level data", order = 0)]
class LevelDataObject_grounding : LevelDataObject
{
	[FormerlySerializedAs("Jar")] public Sprite JarSprite;
}