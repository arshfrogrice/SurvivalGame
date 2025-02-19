# SurvivalGame
FrostWreck is an immersive survival game set in the harsh, frozen wilderness after a devastating plane crash. Stranded and alone, the player must navigate through a dangerous, snow-covered terrain while battling extreme cold, hunger, and hostile creatures like wolves and bears.

The game challenges players to gather resources, craft tools, and follow clues to uncover their ultimate goal: contacting emergency services and returning to their family. With a dynamic day-night cycle, realistic survival mechanics, and a captivating storyline, FrostWreck delivers a thrilling and immersive experience where every decision can mean the difference between life and death.


Functionality of each script is explained as below: 

AI_Movement.cs :- This script controls AI movement in Unity using a NavMeshAgent and animations. The AI randomly chooses a direction (forward, left, right, or backward) to walk for a set duration, then stops and waits before choosing a new direction, with animations toggling between running and idle states.

Animal.cs :- This script manages an animal's health, damage, and death in Unity. It tracks player proximity, updates a health bar UI, triggers animations for taking damage or dying, and plays a death sound before destroying the animal object when its health reaches zero.

BookPanelHandler.cs- This script hides a book panel UI element and resumes the game when the spacebar is pressed, by deactivating the panel and setting the time scale back to 1 (normal speed).

BookTrigger.cs- This script triggers a quest update when the player enters a collider tagged as "Player" and the current quest stage is "FindBook." It updates the quest stage to "ReadBook" using the QuestManager.

Campfire.cs- This script manages the player's interaction with a campfire in Unity. When the player enters the campfire's trigger area, it signals the `TemperatureManager` to increase the player's temperature. When the player exits, it stops the temperature increase. Debug logs are included for tracking player proximity to the campfire.

CampfireTrigger.cs- This script updates the quest stage to "FindMansion" when the player enters the trigger area, but only if the current quest stage is "FindCampfire." It uses the QuestManager to handle the quest progression.

DayNightCycle.cs- This script simulates a day-night cycle in Unity by adjusting a skybox material's blend value over time. It tracks the current time, allows for time scaling, and provides methods to check if it's nighttime, get the current time, or convert the time to a 24-hour format.

EndPanel.cs- This script provides functionality for an end panel in Unity, allowing the player to either load the main menu scene ("Menu") or quit the game entirely. It resets the time scale to normal before loading the menu and logs a message when quitting the game.

EndSceneManager.cs- This script displays the player's survival time and best time on the end scene using TextMeshProUGUI elements. It retrieves the times from PlayerPrefs, formats them into a "MM:SS " string, and updates the UI text accordingly.

EnemyAi.cs- This script controls an enemy AI in Unity using NavMesh for navigation. The enemy patrols randomly within a defined range, chases the player when within sight, and attacks by shooting projectiles when in attack range. It also handles taking damage, health management, and visual debugging for sight and attack ranges.

EquipSystem.cs- This script manages tool equipping in Unity. It allows the player to equip a tool (e.g., an axe) by instantiating the corresponding prefab from the Resources/Tools folder, updating the tool's damage value, and tracking whether an axe is equipped. It also handles destroying previously equipped tools.

FoodItem.cs- This script defines a food item in Unity, specifying its name (e.g., "Green Apple") and the amount of hunger it restores when consumed (e.g., 20). It serves as a simple data container for food-related properties.

Health.cs- This script manages a character's health in Unity. It initializes the health to a maximum value, updates a health bar UI when damage is taken, and allows testing damage input (e.g., pressing the spacebar reduces health by 20). The health bar is updated using the HealthBarScript.

HealthBarScript.cs- This script controls a health bar UI element using a Slider. It sets the maximum health value and updates the slider's value to reflect the current health, providing a visual representation of health changes in the game.

HungerBar:- This script manages a hunger bar UI element using a Slider. It sets the maximum hunger value and updates the slider's value to reflect the current hunger level, providing a visual representation of hunger changes in the game.

InventoryManager.cs- This script manages an inventory system in Unity. It allows adding, removing, and displaying items in the inventory UI, with functionality to interact with items (e.g., consume food, equip tools, open books, or radios). The inventory can be toggled open/closed with a key press (e.g., "B"), and it handles UI visibility, cursor state, and player movement during inventory interactions.

Item.cs- This script defines an Item class as a ScriptableObject in Unity, allowing for the creation of customizable inventory items. Each item has properties like ID, name, icon, stackability, type (e.g., Food, Tool, Book, Radio), and additional attributes such as value or damage. It is used to create and manage item assets in the game.

ItemController.cs- This script serves as a simple controller for an item in Unity. It holds a reference to an Item object (likely defined as a ScriptableObject), allowing the game object to represent and interact with the item's data (e.g., name, icon, type) in the game world.

ItemPickup.cs- This script allows the player to pick up an item when they are within range and press the "E" key. It checks for player proximity using a trigger collider, adds the item to the inventory via the InventoryManager, and destroys the item object in the scene after pickup.

Leaderboard.cs- This script manages a leaderboard system in Unity. It tracks the player's survival time, updates the best time if the current survival time is higher, and displays both times in a formatted "MM:SS " string on the UI. It also handles saving and loading times using PlayerPrefs, and can pause the game and show/hide the leaderboard panel when the game ends.

MainMenu.cs- This script provides basic functionality for a main menu in Unity. It allows the player to start the game by loading the next scene in the build index or quit the game entirely, logging a message when quitting.

MansionTrigger.cs- This script updates the quest stage to "FindBook" when the player enters the trigger area, but only if the current quest stage is "FindMansion." It uses the QuestManager to handle the quest progression and logs a message when the quest is updated.

MouseMovement.cs- This script controls first-person camera and player rotation using mouse input. It rotates the camera vertically (up-down) and the player body horizontally (left-right), with sensitivity adjustments and clamping to prevent over-rotation. The cursor is locked to the center of the screen for a smoother experience.

NPCGizmos.cs- This script draws three colored wireframe spheres around an NPC in the Unity Editor: red (7 units), blue (18 units), and green (21 units). These gizmos are visible in the Scene view and can be used for debugging or visualizing NPC interaction ranges.

PauseMenu.cs- This script manages a pause menu in Unity. It allows the player to pause and resume the game using the "Escape" key, toggle the visibility of the pause menu, options menu, and controls menu, and provides functionality to quit the game or return to the main menu. It also handles cursor visibility and lock state during menu interactions.

PlayerControl.cs- This script is a basic template for player control in Unity. Currently, it contains empty Start and Update methods, which can be expanded to implement player movement, input handling, or other gameplay logic.

PlayerInteraction.cs- This script is intended to handle player interaction with items in Unity, such as picking them up. It defines a pickup range and uses a layer mask to detect items within that range. However, the actual pickup logic (e.g., detecting items and triggering pickup) is currently commented out and needs to be implemented. The main camera is referenced for potential raycasting or interaction purposes.

PlayerMovement.cs- This script controls player movement in Unity, including walking, running, jumping, and gravity. It uses a CharacterController for movement, checks for ground contact, and toggles animations (idle, walking, running) based on player input. It also allows toggling cursor visibility with the "Q" key and integrates with a PlayerStatsManager to track movement states.

PlayerStatsManager.cs- This script manages the player's hunger and health stats in Unity. It decreases hunger over time when the player is moving, reduces health if hunger reaches zero, and increases health when hunger is replenished. It updates UI sliders for hunger and health, and triggers game-over logic (e.g., leaderboard update) when health drops to zero. It also supports taking damage from external sources (e.g., temperature).

QuestManager.cs- This script manages quest progression in Unity by tracking the current quest stage and updating objectives accordingly. It logs the current objective to the console based on the quest stage (e.g., finding a campfire, mansion, book, or lost item) and initializes the default objective at the start of the game.

QuestUIManager.cs- This script manages the quest UI in Unity, updating the displayed quest objective based on the current quest stage from the `QuestManager`. It toggles the visibility of the quest panel when the "F" key is pressed and ensures the quest text is updated dynamically. Debug logs are included for tracking UI updates.

RoomTrigger.cs- This script updates the quest stage to "FindLostItem" when the player enters the trigger area, but only if the current quest stage is "ReadBook." It uses the QuestManager to handle the quest progression and logs a message when the quest is updated.

SnowstormBoundary.cs- This script applies damage to the player when they are inside a snowstorm boundary area. It checks for player presence using a trigger collider, tracks frames to apply damage periodically (every 10 frames), and uses the `PlayerStatsManager` to handle health reduction. Debug logs are included for tracking player entry and exit.

SnowstormTrigger.cs- This script applies periodic damage to the player when they are inside a snowstorm trigger area. It detects player entry and exit using a trigger collider, tracks frames to apply damage every 10 frames, and uses the `PlayerStatsManager` to handle health reduction. Debug logs are included for tracking player presence and damage application.

TemperatureScript.cs- This script manages a temperature UI slider in Unity. It sets the maximum temperature value and updates the slider to reflect the current temperature, providing a visual representation of temperature changes in the game.

TimeController.cs- This script simulates a dynamic day-night cycle in Unity. It controls the rotation of the sun and moon, updates ambient lighting and light intensities based on the time of day, and displays the current time in a 24-hour format. The time progresses based on a customizable multiplier, and the script provides a method to retrieve the current time in hours.

ToolClickHandler- This script allows players to click on a tool in the game world to add it to their inventory. When the tool is clicked, it is added to the `InventoryManager` and then destroyed in the scene. If the `InventoryManager` instance is not found, an error is logged.

VolumeManager.cs- This script manages music volume in Unity using a UI slider. It initializes the slider to match the current volume of an `AudioSource` and updates the volume dynamically as the slider value changes. The `SetMusicVolume` method ensures the `AudioSource` volume reflects the slider's value.

Weapon.cs- This script manages weapon functionality in Unity, allowing the player to attack animals (e.g., wolves) with either fists or an equipped weapon. It tracks whether the player is within an animal's trigger collider, handles left-click attacks, and adjusts damage based on whether a weapon is equipped. Debug logs are included for tracking attacks and trigger states.

WolfAttackState.cs- This script controls a wolf's behavior in Unity during its attack state. The wolf patrols between random waypoints, attacks the player if within range, and takes damage if the player attacks it. It handles movement, attacking, health management, and death, with debug logs for tracking actions and waypoint changes.
