# Arena Tactics

**Arena Tactics** is a small tactical RPG / auto-battler prototype being developed in Unity as part of my Unity Junior Programmer learning pathway and software development portfolio.

The player takes the role of a commander rather than directly controlling characters during combat. The goal is to prepare a party, configure their tactics and positioning, and then watch the characters fight autonomously.

> **Status:** 🚧 Work in Progress
> The project is currently under active development while I progress through the Unity Junior Programmer Pathway.

## 🎮 Game Concept

The core gameplay loop is planned around preparing for battles rather than controlling characters directly:

**Choose encounter → Configure party → Arrange starting positions → Start battle → Watch autonomous combat → Adjust tactics → Retry**

The long-term goal is to experiment with party AI and player-configurable behavior inspired by tactical RPG systems where characters can act independently according to predefined priorities.

## ⚔️ Planned Party Roles

The initial player party is designed around three distinct roles:

* **Guardian** – Frontline character focused on protecting the party and drawing enemy attention.
* **Ranger** – Ranged damage dealer that tries to maintain distance from enemies.
* **Healer** – Support character responsible for keeping party members alive.

Enemies will use their own roles and behaviors, with encounters becoming more difficult through different enemy compositions and improved AI behavior.

🛠️ Current Development

Arena Tactics has progressed from its initial Unity learning-pathway foundation into a functional autonomous combat prototype.

Implemented systems currently include:

Isometric arena and camera

Three distinct player roles: Guardian, Ranger, and Healer

Enemy combat units with configurable stats

Reusable health, damage, attack range, and cooldown systems

Autonomous target selection and retargeting

Rigidbody-based movement and range-aware combat

Melee and ranged combat behaviour

Healing and support behaviour

Role-specific AI built on a shared Unit base class

Death handling and animation without removing defeated units from the arena

Victory and defeat detection

Battle restart functionality

Character movement, attack, and death animations

Git/GitHub feature-branch development workflow

The current development focus is Stage 4: Tactical Setup, which introduces the player's first meaningful pre-battle decisions. This includes a separate setup phase, predefined starting positions, party placement, a Start Battle flow, and configurable targeting priorities for each party role.

These systems form the foundation for the larger goal of Arena Tactics: allowing the player to configure a party before battle and then watch those tactical decisions play out through autonomous combat.

## 🧠 Development Approach

Arena Tactics is also a learning project.

The project intentionally starts with small, straightforward implementations before introducing more generalized systems. As repeated patterns emerge, systems can be refactored into reusable components.

This allows me to practice Unity and C# concepts while gradually building toward a larger playable prototype.

## 🗺️ Planned Development

Future development is expected to include:

* Multiple autonomous party members
* Character health and combat
* Different character and enemy roles
* Target selection and priorities
* Healing and support AI
* Tanking and defensive behavior
* Ranged positioning and kiting
* Player-configurable tactics
* Starting-position configuration
* Win and loss conditions
* Encounter selection
* UI and menus
* Audio and visual polish

The final scope may change as the project develops.

## 💻 Technologies

* **Unity**
* **C#**
* **Git**
* **GitHub**

## 📚 Project Background

Arena Tactics began as my personal project for the **Unity Junior Programmer Pathway**.

Instead of building unrelated exercises for each section of the pathway, I am using the concepts I learn to gradually develop a single larger project. This repository therefore also documents my progression with Unity, C#, game development, and software architecture.

## 📌 Current Status

**In development — not yet a finished game.**

The repository is public so that my development progress, code structure, and learning process can be followed as the project evolves.
