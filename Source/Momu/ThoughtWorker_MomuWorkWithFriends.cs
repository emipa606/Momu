using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace Momu
{
	// Token: 0x02000005 RID: 5
	public class ThoughtWorker_MomuWorkWithFriends : ThoughtWorker
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002540 File Offset: 0x00000740
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			bool flag = !p.RaceProps.Humanlike;
			ThoughtState result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !p.def.defName.Contains("Momu");
				if (flag2)
				{
					result = ThoughtState.Inactive;
				}
				else
				{
					JobDriver curDriver = p.jobs.curDriver;
					bool flag3 = curDriver == null;
					if (flag3)
					{
						result = ThoughtState.Inactive;
					}
					else
					{
						bool flag4 = p.skills == null;
						if (flag4)
						{
							result = ThoughtState.Inactive;
						}
						else
						{
							bool flag5 = curDriver.ActiveSkill == null;
							if (flag5)
							{
								result = ThoughtState.Inactive;
							}
							else
							{
								SkillRecord skill = p.skills.GetSkill(curDriver.ActiveSkill);
								bool flag6 = skill == null;
								if (flag6)
								{
									result = ThoughtState.Inactive;
								}
								else
								{
									List<Pawn> list = p.Map.mapPawns.AllPawnsSpawned.FindAll((Pawn x) => x.def.defName.Contains("Momu"));
									bool flag7 = list.NullOrEmpty<Pawn>();
									if (flag7)
									{
										result = ThoughtState.Inactive;
									}
									else
									{
										List<Pawn> list2 = list.FindAll((Pawn x) => x.GetRelations(p) != null && x.relations.OpinionOf(p) > 50 && x != p);
										bool flag8 = list2.NullOrEmpty<Pawn>();
										if (flag8)
										{
											result = ThoughtState.Inactive;
										}
										else
										{
											bool flag9 = !list2.Any((Pawn x) => x.Position.InHorDistOf(p.Position, 10f));
											if (flag9)
											{
												result = ThoughtState.Inactive;
											}
											else
											{
												result = ThoughtState.ActiveDefault;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
	}
}
