# DAR Conditions Checklist
## This is the list of available conditions in DAR according the [nexus](https://www.nexusmods.com/skyrimspecialedition/mods/33746).

### TODO
- OR Conditons Nesting
- IsActorValueEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValueBaseEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueBaseLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValueMaxEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValueMaxLessThan(GlobalVariable id, GlobalVariable value)
- IsActorValuePercentageEqualTo(GlobalVariable id, GlobalVariable value)
- IsActorValuePercentageLessThan(GlobalVariable id, GlobalVariable value)
- IsLevelLessThan(GlobalVariable level)
- CurrentGameTimeLessThan(GlobalVariable time)
- ValueEqualTo(GlobalVariable value1, GlobalVariable value2)
- ValueLessThan(GlobalVariable value1, GlobalVariable value2)
- IsFactionRankEqualTo(GlobalVariable rank, Faction faction)
- IsFactionRankLessThan(GlobalVariable rank, Faction faction)

### Completed
- ~~IsEquippedRight(Form item)~~
- ~~IsEquippedRightType(GlobalVariable type)~~
- ~~IsEquippedRightHasKeyword(Keyword keyword)~~
- ~~IsEquippedLeft(Form item)~~
- ~~IsEquippedLeftType(GlobalVariable type)~~
- ~~IsEquippedLeftHasKeyword(Keyword keyword)~~
- ~~IsEquippedShout(Form shout)~~
- ~~IsWorn(Form item) // TODO Verify Property Name~~
- ~~IsWornHasKeyword(Keyword keyword)~~
- ~~IsInFaction(Faction faction)~~
- ~~HasKeyword(Keyword keyword)~~
- ~~HasMagicEffect(MagicEffect magiceffect)~~
- ~~HasMagicEffectWithKeyword(Keyword keyword)~~
- ~~HasPerk(Perk perk)~~
- ~~HasSpell(Form spell)~~
- ~~IsActorBase(ActorBase actorbase)~~
- ~~IsRace(Race race)~~
- ~~CurrentWeather(Weather weather)~~
- ~~Random(GlobalVariable percentage)~~
- ~~IsClass(Class class)~~
- ~~IsCombatStyle(CombatStyle combatStyle)~~
- ~~IsVoiceType(VoiceType voiceType)~~
- ~~IsInLocation(Location location)~~
- ~~HasRefType(LocationRefType refType)~~
- ~~IsParentCell(Cell cell)~~
- ~~IsWorldSpace(WorldSpace worldSpace)~~
- ~~IsMovementDirection(GlobalVariable direction)~~

**These are covered by the base/default condition map.**
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