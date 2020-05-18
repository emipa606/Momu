using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Momu
{
	// Token: 0x02000006 RID: 6
	public class CompProperties_FoodPoisonProtection : CompProperties
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000026FA File Offset: 0x000008FA
		public CompProperties_FoodPoisonProtection()
		{
			this.compClass = typeof(CompFoodPoisonProtection);
		}

		// Token: 0x04000008 RID: 8
		public bool Poisonable = true;

		// Token: 0x04000009 RID: 9
		public List<FoodTypeFlags> FoodTypeFlags = new List<FoodTypeFlags>();

		// Token: 0x0400000A RID: 10
		public List<FoodPoisonCause> FoodPoisonCause = new List<FoodPoisonCause>();
	}
}
