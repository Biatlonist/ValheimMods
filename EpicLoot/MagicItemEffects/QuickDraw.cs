﻿using System;
using HarmonyLib;
using JetBrains.Annotations;

namespace EpicLoot.MagicItemEffects
{
	[HarmonyPatch(typeof(Player), "GetSkillFactor")]
	public class QuickDrawBowSkillIncrease_Player_GetSkillFactor_Patch
	{
		[UsedImplicitly]
		private static void Postfix(Player __instance, Skills.SkillType skill, ref float __result)
		{
			if (skill == Skills.SkillType.Bows && __instance.GetEquipmentOfType(ItemDrop.ItemData.ItemType.Bow)?.GetMagicItem()?.GetTotalEffectValue(MagicEffectType.QuickDraw, 0.01f) is float bowDrawTimeReduction)
			{
				__result = Math.Min(1, __result + bowDrawTimeReduction);
			}
		}
	}
}