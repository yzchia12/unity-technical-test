Documentation for Unity Technical Test (Time spent: 40 minutes)

-----

How to create new cards:

New card can be created following the steps

1. In the Unity Editor
    - Assets > Create > ScriptableObjects > Card
    - This create a new CardSO asset.
2. Move the Card to the correct folder
    - Placed it in Resources/ScriptableObjects/Card
3. (If needed) Add new ability to enum 
    - Open CardAbility.cs
    - Add the new ability to the Ability enum
4. Configure the Card properties
    - In the inspector, select the new card asset.
    - Set the following fields:
        Name(string)
        Health(int)
        Damage(int)
        Ability(enum)
        Card Image(Color)
5. Implement the effect in CardAbilityController
    - Open CardAbilityController.cs
    - In OnCardExecute(), handle the new ability
        case CardAbility.newAbility
        break;

-----

- Card Ability: (Time Spent: 1 hour)

I use ScriptableObject (CardSO.cs) to store card data and an enum (CardAbility.cs) to define all ability types

When a card is executed, I trigger an event from the UI(Hand.cs) which is listened to by (CardAbilityController.cs). I wish to do a decoupling between UI input and Game Logic. 

The UI only raises an intent and the controller handle that request. This let me decouple the system and makes it easier to maintain or extend the UI without touching the game logic.

I chose a switch-case structure to execute abilities because it's simple and readable for the current size of abilities

Improvement:

In the future I would implement a command pattern because the skill would expand indefinitely, we don't want an endless switch-case.

A SpawnController will also created to move the Spawn logic out of CardAbilityController, keeping it focused and easier to test

Object Pooling would also implemented for the Card and the Spawned Object.

I will use Constant or expose the ability value as [SerializeField] to make tuning easier.

I will centralize the event definition in GameEvents.cs static class

-----

- Card Visual: (Time Spent 40 minutes)

I added the necessary UI component(Button, Text) to the Card Prefab

I created a CardActionPanel that contains (ViewDetails, Execute) button where it will appear on top of the selected Card

I create a CardDetailPanel to display all the Card Information

-----

- UI: (Time Spent 1.5 hour)

I use (Hand.cs) as a UIManager to handle all the UI input & output

When a card is selected, I trigger an event from the UI (Card.cs) which is listened to by (Hand.cs).

I use event-based system between the UI to avoid hard reference.

Improvement:

I would create a UIManager separately to handle all the UI input & output

I will also create abstract class like Panel, Button, etc. So that we don't need to write repetitive code.

-----

Issue faced while implementing:

To decide whether use Event-based system or Hard Reference. At the end I pick Event-based system.