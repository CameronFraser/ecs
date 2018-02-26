# ECS/Scene Management Implementation
Entity-Component-System + Scene Management for Monogame

## Getting Started

1. Install Visual Studio
2. Open up Visual Studio at least once
3. Download and Install Monogame; Ensure the templates checkbox for your version of VS is selected
4. Pull this project and open in VS
5. Press start to run

## Current Functionality

Only the scene management exists currently. If you run the app there are some demo scenes set up
that only contain a background. By clicking on the window you will change scenes.

## TO-DO
1. Draw text to the screen for each scene to demonstrate usage of sprite batch and textures. This will require
either some passing around of ContentManager and GraphicsDevice or adding them to a DI container
2. Create World class which contains a dictionary of Entity and a list of System. This loops through all System types attached
to it and passes a list of Entity type to each System. Should be able to add Entity types, remove Entity types, lookup Entity types, set Entity types as active or inactive, and ensure no duplication in Entity id's.
3. Create Entity class which contains a unique ID and a list of Component type. 
4. Create System class which accepts a list of Entity type and loops through them looking for an Entity with a Component or set of Component that pertains to the System. An example is a render System which would act execute logic on Entities with appearance and position Components.
5. Create Component class, basically just data holders for now, we might want to extend some functionality
6. Research how to convert Tiled's .tmx format (http://www.mapeditor.org/) to something usable in game
7. Create tile engine that consumes data supplied from Tiled
8. Create player controlled player entity (create components for input from keyboard & mouse, gamepad, controllable, appearance, position and associated systems)
9. Demonstrate character walking on tilemap
10. Create collision detection components and systems
11. Create entities that do not allow another entity on their same position (rocks, trees, big bush) via usage of collision detection
12. Create day/night cycle
13. Create weather system
14. Create storyboarding system for outlining story progression, choices, decision trees
15. Quest system
16. Dialogue system
17. Economy
18. Basebuilding
