using RimWorld;
using Verse;

namespace CombatBionics;

public class Projectile_ExplosiveStun : Projectile_Explosive
{
    protected override void Explode()
    {
        var map = Map;
        var position = Position;
        var explosionRadius = def.projectile.explosionRadius;
        var stun = DamageDefOf.Stun;
        var thing = launcher;
        var damageAmount = base.DamageAmount;
        var armorPenetration = base.ArmorPenetration;
        var soundExplode = def.projectile.soundExplode;
        var thingDef = equipmentDef;
        var thingDef2 = def;
        var thing2 = intendedTarget.Thing;
        var postExplosionSpawnThingDef = def.projectile.postExplosionSpawnThingDef;
        var postExplosionSpawnChance = def.projectile.postExplosionSpawnChance;
        var postExplosionSpawnThingCount = def.projectile.postExplosionSpawnThingCount;
        var preExplosionSpawnThingDef = def.projectile.preExplosionSpawnThingDef;
        var preExplosionSpawnChance = def.projectile.preExplosionSpawnChance;
        var preExplosionSpawnThingCount = def.projectile.preExplosionSpawnThingCount;
        var applyDamageToExplosionCellsNeighbors = def.projectile.applyDamageToExplosionCellsNeighbors;
        var explosionChanceToStartFire = def.projectile.explosionChanceToStartFire;
        var explosionDamageFalloff = def.projectile.explosionDamageFalloff;
        float? num = origin.AngleToFlat(destination);
        base.Explode();
        GenExplosion.DoExplosion(position, map, explosionRadius, stun, thing, damageAmount, armorPenetration,
            soundExplode, thingDef, thingDef2, thing2, postExplosionSpawnThingDef, postExplosionSpawnChance,
            postExplosionSpawnThingCount, null, null, 0, applyDamageToExplosionCellsNeighbors,
            preExplosionSpawnThingDef,
            preExplosionSpawnChance, preExplosionSpawnThingCount, explosionChanceToStartFire, explosionDamageFalloff,
            num);
    }
}