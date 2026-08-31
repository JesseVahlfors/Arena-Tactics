# Arena Tactics — Prototype 1.0 Design Document

- **Project:** Arena Tactics
- **Engine:** Unity
- **Target:** PC / WebGL via Unity Play
- **Development Context:** Unity Junior Programmer Pathway portfolio project
- **Plan Version:** Prototype 1.0
- **Last Updated:** August 2026

---

## 1. Game Concept

**Arena Tactics** is a small tactical RPG / auto-battler in which the player acts as the commander of a party rather than directly controlling characters during combat.

Before a battle, the player configures the party's starting positions and tactical behaviour. Once combat begins, the characters act autonomously according to their roles and the player's decisions.

The player wins by defeating the opposing team. If the party is defeated, the player can adjust the setup and retry the encounter.

The Prototype 1.0 goal is to create a short but complete game that demonstrates the core Arena Tactics concept and the programming concepts learned during the Unity Junior Programmer Pathway.

---

## 2. Core Gameplay Loop

1. Select an encounter.
2. View the enemy composition.
3. Configure the party.
4. Arrange starting positions.
5. Configure simple tactical priorities.
6. Start the battle.
7. Characters fight autonomously.
8. Win or lose the encounter.
9. Adjust tactics and retry, or continue to the next encounter.

The important design principle is that **the player's decisions happen primarily before combat**.

The player should not need to directly move or attack with individual characters once the battle begins.

---

## 3. Prototype Player Party

The Prototype 1.0 party consists of three characters with clearly different combat roles.

### Guardian

**Role:** Tank / frontline

Intended behaviour:

- High health.
- Fights at melee range.
- Moves toward enemies.
- Protects more vulnerable party members by engaging enemies first.
- May eventually prioritize enemies threatening allies.

### Ranger

**Role:** Ranged damage

Intended behaviour:

- Attacks from range.
- Lower durability than the Guardian.
- Attempts to maintain useful attack distance.
- Can use targeting priorities to focus important enemies.
- More advanced kiting behaviour may be added after Prototype 1.0.

### Healer

**Role:** Support

Intended behaviour:

- Detects injured allies.
- Heals allies when required.
- Prioritizes healing according to configured behaviour.
- Can perform a secondary action when healing is unnecessary.

---

## 4. Prototype Enemy Roles

Enemy variety should introduce tactical problems rather than simply increasing health and damage.

### Raider

Basic enemy combatant.

- Approaches the player party.
- Uses melee attacks.
- Provides the standard enemy against which other enemy types can be compared.

### Brute

Heavy frontline enemy.

- High health.
- Strong melee attacks.
- Slower or otherwise less flexible than the Raider.
- Acts as a durable obstacle protecting other enemies.

### Shaman

Support / ranged enemy.

- Operates behind frontline enemies.
- Uses ranged attacks, healing, buffs, or another support ability.
- Provides an important priority target for the Ranger and tactical targeting system.

The exact enemy abilities may be simplified depending on Prototype 1.0 development time.

---

## 5. Arena

The game takes place in a small isometric fantasy arena.

Current visual direction:

- Rectangular arena.
- Isometric-style fixed camera.
- Fantasy / dungeon environment.
- Physical walls surrounding the playable space.
- Player and enemy teams begin on opposite sides.
- Entire battle should remain easy to observe from the main camera.

The arena should remain relatively small so that combat begins quickly and the player can understand what every character is doing.

---

## 6. Development Roadmap

### Stage 1 — Prototype Foundation

**Goal:** Establish the basic playable arena and technical foundation.

#### Arena

- [x] Create Unity project.
- [x] Create basic arena using primitive geometry.
- [x] Establish rectangular battlefield.
- [x] Add ground.
- [x] Add physical arena boundaries/walls.
- [x] Set up an isometric-style camera.
- [x] Frame the camera so the battle area can be observed at once.
- [x] Begin replacing prototype environment with fantasy/dungeon assets.

#### Characters

- [x] Create player-side characters in the scene.
- [x] Create enemy characters.
- [x] Replace primitive character placeholders with character assets.
- [x] Give characters Rigidbody-based movement.
- [x] Use configurable tags to distinguish opposing teams.

#### Basic AI

- [x] Find opposing characters in the scene.
- [x] Find the closest opponent.
- [x] Calculate direction toward the target.
- [x] Move autonomously toward the target.
- [x] Search for another target after the previous target disappears.

#### Enemy Spawning / Prototype Systems

- [x] Create an enemy spawning system.
- [x] Spawn enemies on the enemy side of the arena.
- [x] Support multiple enemies in the scene.
- [x] Test autonomous movement with multiple targets.

#### Assets and Presentation Foundation

- [x] Import replacement character assets.
- [x] Import fantasy/dungeon environment assets.
- [x] Import weapon/environment props.
- [x] Begin using particle effects.
- [x] Resolve rendering/material issues affecting WebGL particle effects.
- [x] Test WebGL builds.

#### Project / Development Foundation

- [x] Set up Git/GitHub version control.
- [x] Create a public-facing project README.
- [x] Establish Prototype 1.0 development plan.

**Stage 1 Status:** COMPLETE

---

### Stage 2 — Real Combat Loop

**Goal:** Replace the temporary collision/destruction prototype with an actual combat system.

#### Unit Health

- [ ] Create reusable health system.
- [ ] Give units maximum health.
- [ ] Track current health.
- [ ] Allow units to receive damage.
- [ ] Prevent health from producing invalid values.
- [ ] Expose health safely to other systems.

#### Attacking

- [ ] Give units attack damage.
- [ ] Give units attack range.
- [ ] Add attack cooldown / attack speed.
- [ ] Detect when a target is within attack range.
- [ ] Stop approaching when an appropriate attack position is reached.
- [ ] Damage the target instead of destroying it on collision.

#### Death

- [ ] Detect when health reaches zero.
- [ ] Mark the unit as dead.
- [ ] Prevent dead units from attacking.
- [ ] Prevent dead units from moving.
- [ ] Make AI ignore dead units when selecting targets.
- [ ] Play the character's death animation.
- [ ] Leave the dead character GameObject/corpse in the arena instead of destroying it.

#### Battle State

- [ ] Detect when all enemies are dead.
- [ ] Trigger victory.
- [ ] Detect when the entire player party is dead.
- [ ] Trigger defeat.
- [ ] Allow the battle to be restarted.

**Stage 2 completion condition:**

> Start a battle → units autonomously fight → units take damage and die → dead units are ignored → one team is eliminated → Victory or Defeat is triggered.

---

### Stage 3 — Distinct Roles and OOP Architecture

**Goal:** Create the three player roles and use the combat architecture to demonstrate the object-oriented programming principles required by the Unity Junior Programmer Pathway.

#### Shared Unit Architecture

- [ ] Create an appropriate shared unit/base class.
- [ ] Move genuinely shared unit data into the base class.
- [ ] Move genuinely shared combat behaviour into the base class.
- [ ] Avoid duplicating common functionality between character types.

Possible shared functionality:

- Health.
- Movement speed.
- Attack damage.
- Attack range.
- Current target.
- Taking damage.
- Healing.
- Moving toward a target.
- Dying.
- Target searching.

#### Guardian

- [ ] Implement Guardian combat behaviour.
- [ ] Give Guardian high durability.
- [ ] Use melee combat.
- [ ] Make Guardian naturally operate on the frontline.

#### Ranger

- [ ] Implement Ranger combat behaviour.
- [ ] Give Ranger ranged attacks.
- [ ] Stop Ranger at an appropriate attack distance.
- [ ] Add ranged attack animation/effect.

#### Healer

- [ ] Implement Healer combat behaviour.
- [ ] Detect injured allies.
- [ ] Select an ally to heal.
- [ ] Restore health.
- [ ] Give Healer useful behaviour when nobody requires healing.

#### Unity OOP Requirements

##### Inheritance

- [ ] Use inheritance where multiple unit types genuinely share functionality.
- [ ] Use the planned hierarchy `Unit` → `Guardian` / `Ranger` / `Healer` if implementation confirms that the three roles genuinely share an appropriate base abstraction.
- [ ] Keep reusable systems such as `Health` as components referenced by `Unit` rather than forcing them into the inheritance hierarchy.
- [ ] Mark a clear example with `// INHERITANCE`.

Planned example:

```text
Unit
├─ Guardian
├─ Ranger
└─ Healer
```

##### Polymorphism

- [ ] Allow subclasses to provide different implementations of shared behaviour.
- [ ] Use method overriding or another appropriate polymorphic design.
- [ ] Give the unit roles a shared behaviour such as `PerformCombatAction()` or `ChooseTarget()` that can vary by subtype.
- [ ] Mark a clear example with `// POLYMORPHISM`.

Planned example:

- Guardian performs a melee combat action against a nearby enemy.
- Ranger performs a ranged combat action while maintaining an appropriate distance.
- Healer prioritizes healing an injured ally and uses a secondary action when healing is unnecessary.

##### Encapsulation

- [ ] Protect internal unit state from inappropriate direct modification.
- [ ] Use properties/getters/setters where appropriate.
- [ ] Control health changes through methods such as damage/healing.
- [ ] Keep `currentHealth` private and expose only the read access required by UI, AI and targeting systems.
- [ ] Enforce valid health limits inside methods such as `TakeDamage()` and `Heal()` rather than allowing other systems to assign health directly.
- [ ] Mark a clear example with `// ENCAPSULATION`.

##### Abstraction

- [ ] Hide lower-level implementation behind meaningful methods.
- [ ] Keep higher-level AI/combat code readable.
- [ ] Use high-level operations such as `FindTarget()`, `MoveIntoRange()`, `PerformCombatAction()`, `TakeDamage()` and `Die()` so callers do not need to know their lower-level calculations or Unity component operations.
- [ ] Mark a clear example with `// ABSTRACTION`.

#### Version Control Requirement

- [ ] Develop a feature using a separate Git branch.
- [ ] Make multiple meaningful commits.
- [ ] Merge completed feature branch into the main development branch.

**Stage 3 completion condition:**

> Guardian, Ranger and Healer visibly perform different roles during autonomous combat, while the codebase contains clear and intentional examples of inheritance, polymorphism, encapsulation and abstraction.

---

### Stage 4 — Tactical Setup

**Goal:** Give the player meaningful decisions before combat.

This stage establishes the central identity of Arena Tactics.

#### Pre-Battle State

- [ ] Separate setup mode from active combat.
- [ ] Prevent combat AI from starting during setup.
- [ ] Add Start Battle button.
- [ ] Lock configuration when battle begins.

#### Starting Positions

- [ ] Create predefined player starting positions.
- [ ] Allow party members to be assigned/moved between starting positions.
- [ ] Clearly show valid positions.
- [ ] Prevent multiple characters from occupying the same position.

Prototype 1.0 should prefer a small number of predefined slots over unrestricted positioning unless unrestricted positioning proves easy and reliable.

#### Basic Tactical Behaviour

Implement a small targeting system rather than the eventual full tactics/gambit system.

Possible choices:

**Guardian**

- [ ] Closest enemy.
- [ ] Strongest enemy.

**Ranger**

- [ ] Closest enemy.
- [ ] Lowest-health enemy.
- [ ] Priority/support enemy.

**Healer**

- [ ] Lowest-health ally.
- [ ] Guardian priority.

Exact options can change during testing.

#### Tactical Feedback

- [ ] Display currently selected behaviour.
- [ ] Make tactical choices visibly affect combat.
- [ ] Allow the player to change setup after losing and retry.

**Stage 4 completion condition:**

> The player can make at least one meaningful pre-battle decision that can visibly change the outcome of the fight.

---

### Stage 5 — Complete Game Flow

**Goal:** Make Arena Tactics understandable and playable without the developer explaining it.

Target flow:

`Main Menu → Encounter → Party Setup → Battle → Victory/Defeat → Retry/Next/Menu`

#### Main Menu

- [ ] Arena Tactics title.
- [ ] Play button.
- [ ] How to Play / Instructions.
- [ ] Appropriate menu presentation.

#### Encounter Screen

- [ ] Display selected encounter.
- [ ] Show useful information about the enemy composition.
- [ ] Enter party setup.

#### Battle UI

- [ ] Display player health clearly.
- [ ] Display enemy health clearly.
- [ ] Identify character roles where necessary.
- [ ] Display current encounter.
- [ ] Provide Start Battle control.

#### Victory

- [ ] Clearly display victory.
- [ ] Allow player to continue to the next encounter.
- [ ] Allow return to menu.

#### Defeat

- [ ] Clearly display defeat.
- [ ] Allow immediate retry.
- [ ] Return player to tactical setup before retrying.
- [ ] Allow return to menu.

#### Usability

- [ ] Player can understand the basic objective without outside explanation.
- [ ] Player can understand how to start combat.
- [ ] Player can understand why they won or lost.
- [ ] Player can retry and modify their strategy.

**Stage 5 completion condition:**

> Someone unfamiliar with Arena Tactics can open the game, understand the basic objective, configure the party, fight a battle and retry or continue without developer assistance.

---

### Stage 6 — Prototype Encounter Progression

**Goal:** Turn the combat prototype into a short complete game.

Target: approximately **four encounters**.

#### Encounter 1 — Introduction

Purpose: Teach basic combat and party roles.

Possible enemies:

- 2 Raiders.

The player should normally win without requiring optimized tactics.

- [ ] Implement Encounter 1.
- [ ] Test as introductory difficulty.

#### Encounter 2 — Numbers

Purpose: Make positioning and frontline protection more important.

Possible enemies:

- 3–4 Raiders.

- [ ] Implement Encounter 2.

- [ ] Balance around positioning.

#### Encounter 3 — Priority Target

Purpose: Introduce a dangerous backline/support enemy.

Possible enemies:

- 2 Raiders.
- 1 Shaman.

The encounter should demonstrate why targeting priority matters.

- [ ] Implement Shaman/support behaviour.
- [ ] Implement Encounter 3.
- [ ] Test targeting choices.

#### Encounter 4 — Final Battle

Purpose: Combine the systems introduced in previous encounters.

Possible enemies:

- 1 Brute.
- 2 Raiders.
- 1 Shaman.

Alternative enemy assets, such as a large monster/golem, may be used to visually distinguish the final encounter.

- [ ] Implement Brute.
- [ ] Implement final encounter.
- [ ] Balance final battle.
- [ ] Add completion/victory screen for finishing Prototype 1.0.

**Stage 6 completion condition:**

> The player can complete a short sequence of increasingly difficult encounters that encourage use of the game's tactical systems.

---

### Stage 7 — Presentation and Unity Play Release

**Goal:** Turn the functional prototype into a presentable Unity Play submission and portfolio project.

#### Character Presentation

- [ ] Idle animations.
- [ ] Movement animations.
- [ ] Melee attack animations.
- [ ] Ranged attack animations.
- [ ] Healing/casting animations.
- [ ] Death animations.

#### Effects

- [ ] Melee feedback.
- [ ] Ranger projectile/attack effect.
- [ ] Healing effect.
- [ ] Appropriate death feedback.
- [ ] Victory/defeat feedback.

#### Audio

- [ ] Background music.
- [ ] Melee attack sounds.
- [ ] Ranged attack sounds.
- [ ] Healing sounds.
- [ ] Character/death sounds where appropriate.
- [ ] UI sounds.
- [ ] Reasonable audio levels.

#### Environment

- [ ] Replace remaining obvious prototype geometry where worthwhile.
- [ ] Improve arena composition.
- [ ] Add appropriate props.
- [ ] Improve lighting.
- [ ] Ensure characters remain visually readable against the environment.

#### UI

- [ ] Consistent visual style.
- [ ] Readable fonts.
- [ ] Clear buttons.
- [ ] Clear health bars.
- [ ] Clear tactical configuration.
- [ ] No development/debug UI visible in release.

#### WebGL / Unity Play

- [ ] Create final WebGL build.
- [ ] Verify materials.
- [ ] Verify particle effects.
- [ ] Verify animations.
- [ ] Verify audio.
- [ ] Test UI at Unity Play resolution.
- [ ] Test complete game from beginning to end in WebGL.
- [ ] Fix browser-specific problems.
- [ ] Upload release build to Unity Play.
- [ ] Complete Unity Junior Programmer Pathway submission.

**Stage 7 completion condition:**

> Arena Tactics Prototype 1.0 can be played from beginning to end on Unity Play and feels like a deliberately scoped small game rather than an unfinished development scene.

---

## 7. Prototype 1.0 Definition of Done

Prototype 1.0 is complete when:

- [ ] The game has a main menu.
- [ ] The player controls a party of Guardian, Ranger and Healer.
- [ ] Each class has a distinct autonomous combat role.
- [ ] The player can configure starting positions.
- [ ] The player can configure at least basic tactical behaviour.
- [ ] Characters use proper health, damage and death systems.
- [ ] Dead characters remain in the arena and are ignored by AI.
- [ ] Battles end in victory or defeat.
- [ ] The game contains multiple encounters.
- [ ] Encounters become meaningfully more difficult.
- [ ] The game has a complete retry/progression loop.
- [ ] Character animations are functional.
- [ ] Basic effects and audio are present.
- [ ] UI clearly communicates necessary information.
- [ ] Inheritance is demonstrated.
- [ ] Polymorphism is demonstrated.
- [ ] Encapsulation is demonstrated.
- [ ] Abstraction is demonstrated.
- [ ] Git branching/merging has been demonstrated.
- [ ] A WebGL build works correctly.
- [ ] The game is uploaded to Unity Play.
- [ ] A new player can understand and play the game without developer assistance.

---

## 8. Features Outside Prototype 1.0 Scope

The following ideas are intentionally **not required** for the Unity Pathway submission.

They may be developed afterward if they improve Arena Tactics as a portfolio project.

### Advanced Tactical AI

- Dragon Age / FFXII-style conditional tactics.
- Multiple ordered behaviour rules.
- Conditional health thresholds.
- Conditional enemy selection.
- Ability priorities.
- Saveable tactics presets.

Example future rules:

`IF ally health < 40% → Heal`

`IF enemy is Shaman → Prioritize target`

`IF enemy within melee range → Move away`

### Advanced Combat

- Threat / aggro system.
- Guardian taunting.
- Advanced Ranger kiting.
- Crowd control.
- Buffs and debuffs.
- Status effects.
- Special abilities.
- Resource systems.
- Ability cooldown management.

### Party Development

- Additional classes.
- Party composition selection.
- Character progression.
- Equipment.
- Stats.
- Unlockable abilities.

### Game Progression

- Larger encounter selection.
- Campaign structure.
- Difficulty modes.
- Boss encounters.
- Persistent progression.

These systems should only be added after Prototype 1.0 is complete and the Unity Junior Programmer Pathway submission has been released.

---

## 9. Development Principles

### Keep Prototype 1.0 Small

The objective is not to build the complete future version of Arena Tactics.

The objective is to create a **small, complete and understandable implementation of its central idea**.

New features should be evaluated by asking:

> Does this feature help demonstrate the core tactical gameplay or make Prototype 1.0 feel complete?

If not, it should probably wait until after Prototype 1.0.

### Build Systems Before Content

Combat should work reliably before adding many enemy types.

One polished encounter is more useful during development than several encounters built on unstable systems.

### Add Complexity When Repetition Appears

Begin with straightforward implementations.

Generalize systems when multiple characters or enemies genuinely require the same behaviour rather than predicting every future requirement in advance.

### Player Decisions Must Matter

Arena Tactics is not intended to be a game where the player simply presses Start and watches an inevitable result.

Starting positions, targeting priorities and other tactical decisions should create observable differences in battle outcomes.

### Autonomous Combat Must Be Readable

The player needs to understand what the AI is doing.

Character movement, targeting, attacks, healing, damage and death should therefore have clear visual feedback.

### Prototype Complete Before Expansion

Once Stage 7 and the Prototype 1.0 Definition of Done are satisfied, release the prototype.

Do not delay the Unity Pathway submission by continuously adding systems from the post-1.0 feature list.

---

## 10. Major Development Milestones

### Milestone A — Combat Prototype

**Stages 1–2**

A complete autonomous battle can occur.

### Milestone B — Programming Theory

**Stage 3**

Distinct character roles work and the project clearly demonstrates the four required OOP principles.

### Milestone C — Arena Tactics Gameplay

**Stage 4**

The player's pre-battle tactical decisions affect combat.

### Milestone D — Playable Game

**Stage 5**

A new player can independently play, win, lose and retry.

### Milestone E — Complete Prototype

**Stage 6**

The game contains a short progression of tactical encounters.

### Milestone F — Prototype 1.0 Release

**Stage 7**

The polished WebGL build is published to Unity Play and submitted for the Unity Junior Programmer Pathway.

---

## 11. Current Development Status

**Current milestone:** Transition from Prototype Foundation to Real Combat Loop.

Stage 1 established the arena, autonomous target-seeking movement, multiple characters, replacement assets, spawning, camera and WebGL foundation.

The next development priority is **Stage 2: Real Combat Loop**.

The current temporary behaviour where characters are destroyed through collision should be replaced with:

`Target → Approach → Attack → Damage → Death → Retarget → Victory/Defeat`

Dead characters should remain in the scene so their death animations and final positions can be preserved, while all AI systems must treat them as invalid targets.

Once this combat foundation is reliable, development can move into the distinct Guardian, Ranger and Healer behaviours required by Stage 3.
