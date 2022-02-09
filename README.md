Forsbergs Group Unity Project Jan - Feb 2022


# Game Engineers

- Isac Lagerström
- Harry Heath
- Yasin Cakiroglu
- Pavel Sarmiento Kochersky

# Mechanics & AI Implentation
### Harry - Dash Mechanic

Description: 

*I implemented two different dash mechanics.*
*The first one "DashHH" is used by the Player in the LVL 1 Scene, and by the three unique dashing AI over the two scenes. By finding the golden skull in the first level the mechanic is upgraded for the player, allowing for multidirectional dashing (vertical/ horizontal inputs and combinations).*
*The second one "Dash2HH" is used by the player in the LVL 2 Scene as core movement.*


- Dash Mechanic
  - Implementation 1: "DashHH.cs" handles dash logic for player and 3 AI Variations. Has cooldown functionality.
  - Implementation 2: "Dash2HH.cs" alt dash mechanic for player. Near constant and replaces walk movement.
  - Implementation 3: "UpgradeUnlockHH" unlocks multidirectional dash for DashHH.cs script. Can dash diagonally.

- AI
  - Implementation 1: "PursuerAI Prefab" - uses DasHH mechanic to dashes towards player if they're within 10 blocks.
  - Implementation 2: "SkyDasherAI Prefab" - uses DashHH mechanic to dash up in the air and pursue player if they're within 5 blocks.
  - Implementation 3: "EvaderAI Prefab" - uses DashHH mechanic to dash towards player if they're within 10 blocks.
  - Extra: "EnemyColliderDamage.cs" - script that makes enemies cause damage to Player on contact and stay (if cooldown inactive).
  - Extra: Identifier scripts and Scriptable Objects for each enemy type


- General
  - "Health.cs" - manages Player and AI health/ death logic
  - "Food.cs" - adds health to Player onCollision if under maxHealth 
  - "DeathObstacle.cs" - when applied to objects like Spikes, causes them to insta-kill player on collision
  - "CameraController.cs" script - follow player script
  - "ResetHH" script - reset scene on Death
  - Camera Shake script - can be called via explosive actions to randomly shake the game screen
##
### Isac - Fly Mechanic
##
### Yasin - Shoot Mechanic
##
### Pavel - Explode Mechanic
