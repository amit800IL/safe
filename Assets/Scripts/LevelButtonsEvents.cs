using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelButtonsEvents
{
   public static Action<int, List<LevelObject>> OnLevelDone { get; set; }
}
