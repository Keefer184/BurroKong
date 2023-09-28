# BurroKong
Repository for my work on the C# and Unity Live Project.  The premise was to design a classic arcade game with a modern feel.  I was responsible for building a Donkey Kong style game for this purpose.  This game took a 2D classic game and was made entirely with 3D objects.  All of the code you will see was researched, but is entirely original.

## Skills Aquired
- Animated actors using both new and legacy animations
- Creating attack system to destroy objects
- Procedural level generation
- Utilizing C# to script movement, AI behavior, collsion events, scene events and level behavior
- Level refresh with score and life carryover utilizing Do Not Destroy on Load
- Creating scoring system utilizing capsule collisions and varied target values
- Implementing a personal High Score script
- Creating respawn system and life counter
- Creating winning and game over conditions and scenes
- Customizing sound effects and background audio
- Collaboration with team utilizing Microsoft Azure DevOps
- Experience working within an Agile/Scrum environment

### Level
Each new level was procedurally generated from an array of prefab pieces.

![Level Generator Code](./BKGifandSS/LeftSideLevelGen.png)

Depending on what level you are on, the application chooses from a range of specific indecies.  For example, level 1 will only choose the base prefabs, while level 10 can choose from any prefab.  The lower levels seem identical, but the later levels have much variability so that the player is not playing the same game twice.

![Next Level](./BKGifandSS/Procedural_and_win.gif)

In this clip you can also see that there is a win condition on level 10, and it sends the player to a game win scene.

### Scenes
There are four main scenes in this game.  The first is the opening scene in which the user is greeted by Burro Kong himself performing a simple haka to ward off the player.  He is accompanied by the controls list, the scoring regime and an entrance button to move to the next scene.

![Opening](./BKGifandSS/BKOpening.gif)

From there the player moves into the main scene which is where the game takes place.  The goal for each level is to reach the princess being guarded by Burro Kong. A capsule collider trigger is what generates the next level.

![Collisions](./BKGifandSS/PlayerCollisionConditions.png)

From the code you can see that level 10 is the highest level and will trigger the winning scene with high score once the reach it.

![Next Level](./BKGifandSS/NextLevel.gif)

The final scene is a game over scene that a player reaches if they have either been struck by a barrel or fallen off the map three times.  From here they can either return to the main menu or try again from level one.

![GameOver](./BKGifandSS/GameOverScene.gif)

### Main Character
