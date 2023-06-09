# DAR Conditions Checklist
## This is the list of available conditions in DAR according the [nexus](https://www.nexusmods.com/skyrimspecialedition/mods/33746).
**Struckthrough items have been mapped.**

- IsEquippedRight(Form item)      // TODO Verify Property Name
- ~~IsEquippedRightType(GlobalVariable type)~~
- ~~IsEquippedRightHasKeyword(Keyword keyword)~~
- IsEquippedLeft(Form item)      // TODO Verify Property Name
- ~~IsEquippedLeftType(GlobalVariable type)~~
- ~~IsEquippedLeftHasKeyword(Keyword keyword)~~
- ~~IsEquippedShout(Form shout)~~
- IsWorn(Form item) // TODO Verify Property Name
- ~~IsWornHasKeyword(Keyword keyword)~~
- ~~IsInFaction(Faction faction)~~
- ~~HasKeyword(Keyword keyword)~~
- ~~HasMagicEffect(MagicEffect magiceffect)~~
- ~~HasMagicEffectWithKeyword(Keyword keyword)~~
- HasPerk(Perk perk)
- HasSpell(Form spell)
- IsActorValueEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValueBaseEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueBaseLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValueMaxEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueMaxLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValuePercentageEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValuePercentageLessThan(GlobalVariable id, GlobalVariable value)
- IsLevelLessThan(GlobalVariable level)
- ~~IsActorBase(ActorBase actorbase)~~
- IsRace(Race race)
- ~~CurrentWeather(Weather weather)~~
- CurrentGameTimeLessThan(GlobalVariable time)
- ValueEqualTo(GlobalVariable value1, GlobalVariable value2)
- ValueLessThan(GlobalVariable value1, GlobalVariable value2)
- ~~Random(GlobalVariable percentage)~~
- IsClass(Class class)
- IsCombatStyle(CombatStyle combatStyle)
- IsVoiceType(VoiceType voiceType)
- IsInLocation(Location location)
- HasRefType(LocationRefType refType)
- IsParentCell(Cell cell)
- IsWorldSpace(WorldSpace worldSpace)
- IsFactionRankEqualTo(GlobalVariable rank, Faction faction)
- IsFactionRankLessThan(GlobalVariable rank, Faction faction)
- ~~IsMovementDirection(GlobalVariable direction)~~

**These should all be covered by the base/default condition map.**
- IsUnique()
- IsAttacking()
- IsRunning()
- IsSneaking()
- IsSprinting()
- IsInAir()
- IsInCombat()
- IsWeaponDrawn()
- IsFemale()
- IsChild()
- IsPlayerTeammate()
- IsInInterior()