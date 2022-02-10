Forsbergs Group Unity Project Jan - Feb 2022


# Game Engineers

- [Harry Heath](https://github.com/HarryTheHeath)
- [Yasin Cakiroglu](https://github.com/y4sn)
- [Pavel Sarmiento Kochersky](https://github.com/Palutzii)

# Mechanics & AI Implentation
### Harry - Dash Mechanic

Description: 

*I implemented two different dash mechanics. I also built both levels and managed their prefabs (including Player).*

*The first one "DashHH" is used by the Player in the LVL 1 Scene, and by the three unique dashing AI over the two scenes. By finding the golden skull in the first level the mechanic is upgraded for the player, allowing for multidirectional dashing (vertical/ horizontal inputs and combinations). It applies velocity to the RigidBody.*

*The second one "Dash2HH" is used by the player in the LVL 2 Scene as core movement. It applies AddForce to the RigidBody.*


- Dash Mechanic
  - Implementation 1: "DashHH.cs" handles dash logic for player and 3 AI Variations. Has cooldown functionality.
  - Implementation 2: "Dash2HH.cs" alt dash mechanic for player. Near constant and replaces walk movement.
  - Implementation 3: "UpgradeUnlockHH" unlocks multidirectional dash for DashHH.cs script. Can dash diagonally.

- AI
  - Implementation 1: "PursuerAI Prefab" - uses DasHH mechanic to dashes towards player if they're within 10 blocks. In both levels.
  - Implementation 2: "SkyDasherAI Prefab" - uses DashHH mechanic to dash up in the air and pursue player if they're within 5 blocks. Only in level 2.
  - Implementation 3: "EvaderAI Prefab" - uses DashHH mechanic to dash towards player if they're within 10 blocks. In both levels.
  - Extra: "EnemyColliderDamage.cs" - script that makes enemies cause damage to Player on contact and stay (if cooldown inactive).
  - Extra: Identifier scripts and Scriptable Objects for each enemy type


- General
  - "Health.cs" - manages Player and AI health/ death logic
  - "Food.cs" - adds health to Player onCollision if under maxHealth 
  - "DeathObstacle.cs" - when applied to objects like Spikes, causes them to insta-kill player on collision
  - "CameraController.cs" - follow player script
  - "ResetHH.cs" script - reset scene on Death and spawn at last checkpoint location. There's two versions for two scenes as had to rush a bit.
  - "SceneLoader.cs" - loads next scene via string input
  - "CameraShake.cs" - can be called via explosive actions to randomly shake the game screen within given floats
##

### Yasin - Shoot Mechanic
	Description:

*I implemented two different shooting mechanics.*
*The first one is called "ShootingLongRange" and the second one is called "ShootingShortRange".* 
*You need to press "Mouse 1" to shoot.*
### Pavel - Explode Mechanic

Implemented Explosion mechanics

- Explode mechanic
  - "Explode.cs"Created a general adjustable explosive script where you can adjust the radius and also the force of it.
  - Created "Grenade.cs" that delays the grenade explosion
  - Created "GrenadeThrower.cs" that handles the trowing of the grenade with adjustable throwing force
  - Creted "ExplodingDeath.cs" which creates a adjustable explosion of enemy death or if the enemy gets close enough

Currently only the player can throw grenades

- AI
  - Exploding Enemy:
  Chases the player when the player is inside its detection radius. Chases until it gets killed or until its near enough which it then suicides and explodes and harms the player.
