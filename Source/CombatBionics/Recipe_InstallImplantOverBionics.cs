using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace CombatBionics;

public class Recipe_InstallImplantOverBionics : Recipe_Surgery
{
    public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
    {
        return MedicalRecipesUtility.GetFixedPartsToApplyOn(recipe, pawn,
            record => pawn.health.hediffSet.GetNotMissingParts().Contains(record) &&
                      !pawn.health.hediffSet.hediffs.Any(x =>
                          x.Part == record && (x.def == recipe.addsHediff || !recipe.CompatibleWithHediff(x.def))));
    }

    public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
    {
        if (billDoer != null)
        {
            if (CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
            {
                return;
            }

            TaleRecorder.RecordTale(TaleDefOf.DidSurgery, billDoer, pawn);
        }

        pawn.health.AddHediff(recipe.addsHediff, part);
    }
}