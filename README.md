<h1 align="center">
Air-o-Plane Project 🛩️
</h1>

## Hello Fellow Detectives! 👋
## Description
Air-O-Plane is a Unity gliding game where players navigate through the environment, avoiding collisions. The game is a work in progress, with continuous updates planned to enhance gameplay.

<div align="center" width="50">
  <kbd><img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExMWV5YzAxcW93bGVvZGc1Yzdyc3JkaDZnYzJ2ZHdndHlqcnppbnVmcCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/SOJHDkYW8aYWxZKawA/giphy-downsized-large.gif" alt="Welcome!" width="300"/></kbd>
</div>

## Controls
- Drag up or down to glide in the respective direction.

## Features
- Glide through a dynamic environment.
- Avoid collisions with obstacles.
- Basic player controls with drag gestures.
- Modular design principles for maintainability.
- Zenject for dependency injection so classes are not coupled.
- NUnit testing for ensuring code reliability.

## Installation
1. Clone the repository.
2. Open the project in Unity (version 21.3.2f1).
3. Navigate to the `Assets/Scenes` folder and open the `MainScene.unity` file.
4. Press the play button to run the game.

## File Structure
- **Art**: Contains art-related assets.
- **3rdParty**: Holds third-party assets.
- **Scripts**: All C# scripts for the project.
- ...

## Design Principles
The project follows modular design principles such as **(Factories, Observer, MVP, MVC , and SOLID Principles)** for better maintainability and extensibility. Each category of scripts has its own folder, promoting a clean and organised codebase.

## Zenject Setup
- **GameBindInstaller**: Binds normal classes.
- **GameConfig**: Binds Scriptable objects and instances used in the class.
- ...

## Player Class
The `Player` class is designed with basic functionality, utilizing a factory to obtain different player states. Current states include:
- PlayerMovingState
- PlayerIdleState
- PlayerDeadState

More states can be added in the future to enhance gameplay.

## Testing 🧪
The project includes NUnit testing to ensure the reliability of the code. Tests cover critical functionalities and can be found in the `Tests` folder.

## Currently Working On
- adding different type of obstacles example (Indiana jones style rolling rock following, Moving Platforms etc).

## Future Enhancements
Continuously update the game with new elements to make it more fun.
- Implement scoring system.
- Improve gliding mechanics.
- Consumable items
- ...

## Contributing
Feel free to contribute by forking the repository and submitting pull requests.


## Contact
For questions or feedback, contact at ridz_92@outlook.com

 
