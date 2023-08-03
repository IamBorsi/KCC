# KCC
 This is my first attempt at creating a Kinematic Character Controller in Unity (KCC in short). I recently picked up Unity as a personal learning project during the summer break at University and immediately became interested in creating a character controller.
 From the ground up, I will try to learn how to build a KCC and document my learning curve in this public repository.
 
## Input System
In this project, I will be using the new Unity Input System to manage all the player inputs. It works by creating new input actions and adding different behaviors you want to implement. In order to use such inputs you first need to enable them through code.
To do that I personally like to use an empty GameObject in my Scene to manage all the input called "InputManager". This GameObject has a Script attached to it that makes it easy to track in one place every input and fast to debug whenever necessary. I also like to make all my Managers Singleton Classes.
