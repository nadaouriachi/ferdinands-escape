# ferdinands-escape
A Unity stealth-action game where you control Ferdinand, a prisoner trying to escape a facility guarded by robots, created as part of the 420-C1B-BB course. 

## 🎮 Gameplay Summary

- Control Ferdinand in third-person using `W`, `A`, `S`, `D` or arrow keys.
- Escape within 3 minutes or be captured.
- If a robot sees Ferdinand, all robots pursue him (shared awareness).
- Collect magnetic cubes to become invisible to robots for 5 seconds.
- Reach the exit door to win.

## 🤖 Enemy Types

1. **Patrollers**
   - Follow a path between 3+ waypoints.
   - Resume patrol if Ferdinand is no longer visible.

2. **Hunters**
   - Remain stationary while Ferdinand is hidden.
   - Pursue when he’s spotted and stay in place once he disappears.

Robots detect Ferdinand using a 160° field of view and a range of 25 units.

## 🧱 Magnetic Cubes

- 3 collectible cubes scattered in the complex.
- Float slightly above ground and rotate constantly.
- Deactivate robot detection for 5 seconds.

## 🎬 Animations and Sound

- Ferdinand and robots are animated with walk and idle states.
- Background music and cube pickup sound included.

## 💡 Cheat codes for debugging

- Press `T`: teleport near exit.
- Press `Y`: set timer to 3 seconds.

## 🔧 Technical Elements

- Unity 3D (v2022.3.17f1)
- C#
- NavMeshAgents for enemy pathfinding
- CharacterController for smooth player movement
- Modular GameController for centralized logic:
  - Timer management
  - Detection states
  - Game end conditions

## 📄 Details

- **Course**: 420-C1B-BB — Introduction à la programmation par le jeu vidéo
- **Name**: Nada Ouriachi
- **Date**: May 26, 2024
