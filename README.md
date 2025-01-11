An addon for monogame that adds a component system, similar to unity. you can add the .cs files into your project or open the .sln file in visual studio to open a "setup project".

The system contains classes like: 

1. a static sprite, for decorations and such.
2.  a moveable sprite, perfect for a player
3.  a text class, to display text on the screen a lot easier!

it also contains components, like:

1. top down movement. just add it to you moveable sprite and it can now move!
2. rectangle collision. adds a simple rectangle collision to your object, being able to check if it collides with something.

You can add more components and classes as you wish. the system should be pretty flexible. by looking at the code you should be able to figure out how to add a component, but still. heres an example:

``` csharp
moveableSprite ball = new moveableSprite();

topDownMovementComp movementComp = new topDownMovementComp(5);

 movementComp.addComponent(ball);

```

 these 3 lines of code add a movement component to a sprite class, giving it a speed and making it able to move using arrow keys and wasd.
