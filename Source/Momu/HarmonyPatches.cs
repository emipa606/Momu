using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Momu
{
	// Token: 0x02000008 RID: 8
	[StaticConstructorOnStartup]
	public static class HarmonyPatches
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002740 File Offset: 0x00000940
		static HarmonyPatches()
		{
			var harmonyInstance = new Harmony("rimworld.ogliss.momu.harmony");
			Type typeFromHandle = typeof(HarmonyPatches);
			harmonyInstance.Patch(AccessTools.Method(typeof(FoodUtility), "AddFoodPoisoningHediff", null, null), new HarmonyMethod(typeFromHandle, "Pre_AddFoodPoisoningHediff_CompCheck", null), null, null);
			harmonyInstance.Patch(AccessTools.Method(typeof(ApparelUtility), "HasPartsToWear", new Type[]
			{
				typeof(Pawn),
				typeof(ThingDef)
			}, null), null, new HarmonyMethod(typeFromHandle, "Post_HasPartsToWear_BodyTypeRestriction", null), null);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000027DC File Offset: 0x000009DC
		public static void Post_HasPartsToWear_BodyTypeRestriction(Pawn p, ThingDef apparel, ref bool __result)
		{
			bool flag = apparel.HasComp(typeof(CompApparelBodyRestriction));
			if (flag)
			{
				CompProperties_ApparelBodyRestriction compProperties = apparel.GetCompProperties<CompProperties_ApparelBodyRestriction>();
				bool flag2 = compProperties != null;
				if (flag2)
				{
					bool flag3 = !compProperties.AllowedBodyTypes.Contains(p.story.bodyType);
					if (flag3)
					{
						__result = false;
					}
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002838 File Offset: 0x00000A38
		public static bool Pre_AddFoodPoisoningHediff_CompCheck(Pawn pawn, Thing ingestible, FoodPoisonCause cause)
		{
			CompFoodPoisonProtection compFoodPoisonProtection = pawn.TryGetComp<CompFoodPoisonProtection>();
			bool flag = compFoodPoisonProtection != null;
			if (flag)
			{
				bool flag2 = !compFoodPoisonProtection.Props.Poisonable;
				if (flag2)
				{
					return false;
				}
				bool flag3 = !compFoodPoisonProtection.Props.FoodTypeFlags.NullOrEmpty<FoodTypeFlags>();
				if (flag3)
				{
					foreach (FoodTypeFlags foodTypeFlags in compFoodPoisonProtection.Props.FoodTypeFlags)
					{
						bool flag4 = foodTypeFlags == ingestible.def.ingestible.foodType;
						if (flag4)
						{
							return false;
						}
					}
				}
				bool flag5 = !compFoodPoisonProtection.Props.FoodPoisonCause.NullOrEmpty<FoodPoisonCause>();
				if (flag5)
				{
					foreach (FoodPoisonCause foodPoisonCause in compFoodPoisonProtection.Props.FoodPoisonCause)
					{
						bool flag6 = foodPoisonCause == cause;
						if (flag6)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}
