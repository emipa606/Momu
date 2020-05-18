using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Momu
{
	// Token: 0x02000003 RID: 3
	public class CompProperties_ApparelBodyRestriction : CompProperties
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002503 File Offset: 0x00000703
		public CompProperties_ApparelBodyRestriction()
		{
			this.compClass = typeof(CompApparelBodyRestriction);
		}

		// Token: 0x04000007 RID: 7
		public List<BodyTypeDef> AllowedBodyTypes = new List<BodyTypeDef>();
	}
}
