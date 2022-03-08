# Animancer Event Bug

A project for investigating a potential bug of the Animancer plugin for Unity.

Bug Report: https://github.com/KybernetikGames/animancer/issues/193

## To Run

1. Clone the repository
2. Open the `SampleScene` scene in Unity.
3. Press the `Play` button in the editor.

Once running, the square in the middle of the scene will move from left to right.

## Details

When using Animancer to play animations, Unity's standard animation events fire multiple times when playing an animation from the `OnEnd` event of another animation.

### To Observe the Bug

Press the spacebar. The square will move up and down a few times before returning to the left -> right animation. A message is logged to Unity's console window when the animation event fires.

**Expected Outcome**: When player presses the spacebar, only one message should be logged in Unity's console from the animation event firing one time.

**Actual Outcome**: When player presses the spacebar, multiple messages are logged in Unity's console from the animation event firing more than once.

## Navigating the Project

The `SampleScene` scene has the setup required to view the bug.

### Animations

There are two animations: `attack` and `idle`.

The `idle` animation...

- Loops
- Is played by default using Animancer when the `Square` script starts

The `attack` animation...

- Does not loop
- Has an Animation Event on the first frame that specifies a function to be called (`FireEvent`, contained in the `Square` script).

### Scripts

There is only one script in the project.

The `Square` script is attached the the `Square` game object in the `SampleScene` scene hierarchy. It contains the logic to play animations when input from the player (spacebar press) is received.

It plays the `idle` animation when the scene starts. When player input is received, it plays the `attack` animation once, then returns to the `idle` animation once the `attack` animation ends.
