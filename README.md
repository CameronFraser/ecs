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
