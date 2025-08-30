# Flappy Bird Game - Windows Forms Edition

A classic Flappy Bird game implementation using C# and Windows Forms, featuring smooth gameplay, dynamic difficulty, and a polished user interface.

![Flappy Bird Game](https://img.shields.io/badge/Game-Flappy%20Bird-blueviolet) ![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2+-blue) ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-C%23-green)

## 🎮 Features

- **Classic Flappy Bird Gameplay**: Navigate through pipes by tapping/clicking
- **Dynamic Difficulty**: Game speed increases as your score improves
- **Visual Polish**: Animated clouds and parallax scrolling effects
- **Sound Effects**: Background music and game over sounds
- **Menu System**: Start screen with options for play, credits, and quit
- **Countdown Timer**: 3-second countdown before game starts
- **Score Tracking**: Real-time score display with increasing challenge

## 🕹️ How to Play

1. Click "Start Game" from the main menu
2. Wait for the 3-second countdown to complete
3. Press the **SPACE BAR** to make the bird flap and avoid pipes
4. Try to achieve the highest score possible by navigating through pipes
5. The game gets progressively faster as your score increases

## 🛠️ Installation & Requirements

### System Requirements
- Windows OS (7, 8, 10, or 11)
- .NET Framework 4.7.2 or later

### Running the Game
1. Download the release package
2. Extract the files to a folder of your choice
3. Double-click `FlappyBird.exe` to launch the game

### Building from Source
1. Clone or download the project files
2. Open the solution in Visual Studio (2019 or later recommended)
3. Restore NuGet packages if prompted
4. Build the solution (Ctrl+Shift+B)
5. Run the application (F5)

## 🎨 Customization

### Difficulty Settings
You can adjust the game difficulty by modifying these variables in the code:

```csharp
int basePipeSpeed = 12;    // Initial pipe speed
int baseCloudSpeed = 8;    // Initial cloud speed
int gravity = 10;          // Default gravity
int speedIncrement = 1;    // Speed increase per difficulty level
int maxPipeSpeed = 20;     // Maximum pipe speed
int maxCloudSpeed = 20;    // Maximum cloud speed
```

### Custom Assets
Replace the following files in the Resources folder to customize the game:
- `bird.png` - Your character
- `pipe.png` and `pipedown.png` - Obstacles
- `ground.png` - Ground texture
- `Cloud.png` and `Clouds2.png` - Cloud decorations

### Sound Effects
Replace these audio files to customize sounds:
- `MarioPhonk.wav` - Background music
- `GameOver.wav` - Game over sound

## 📁 Project Structure

```
Flappy-Bird-Windows-Form/
│
├── Form1.cs                 # Main game logic and event handlers
├── Form1.Designer.cs        # Auto-generated UI code
├── Program.cs               # Application entry point
└── Resources/
    ├── bird.png             # Bird character sprite
    ├── pipe.png             # Bottom pipe obstacle
    ├── pipedown.png         # Top pipe obstacle
    ├── ground.png           # Ground texture
    ├── Cloud.png            # Cloud decoration
    ├── Clouds2.png          # Additional cloud decoration
    ├── MarioPhonk.wav       # Background music
    └── GameOver.wav         # Game over sound effect
```

## 🎵 Audio Features

- Background music loops during gameplay
- Special sound effect plays when game ends
- Audio file paths are configurable in the code

## 🚀 Performance Notes

- Game timer interval set to 20ms for smooth gameplay (50 FPS)
- Object positions reset efficiently when they move off-screen
- Memory management through proper disposal of resources

## 🔧 Troubleshooting

**Game won't start:**
- Ensure .NET Framework 4.7.2+ is installed
- Verify all resource files are in the correct directory

**No sound:**
- Check if audio files exist in the specified paths
- Verify system volume is not muted

**Game runs too fast/slow:**
- Adjust the `gameTimer.Interval` value in the code

## 👨‍💻 Development

This game was developed using:
- **IDE**: Visual Studio 2019/2022
- **Language**: C#
- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms

## 📜 Credits

- **Developer**: Malik
- **Game Concept**: Inspired by the original Flappy Bird by Dong Nguyen
- **Graphics**: Custom and modified sprites
- **Sound Effects**: Custom audio selections

## 📄 License

This project is for educational and personal use. Please respect copyrights for any assets used.

---

**Enjoy playing!** For any issues or suggestions, please check the code comments or adjust the parameters to suit your preferences.
