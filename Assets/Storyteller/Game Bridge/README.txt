REQUIRES STORYTELLER 2019.3 or newer.


1 Requires Storyteller 2019.3.3 or higher

2 Launch Storyteller . Tools > DaiMangou > Storyteller

3 start a new story or open a preexisting project.

4 Make sure you are in a new storyteller scene.

5 Launch Game Bridge . Right click on the canvas to open the context menu.Go to Windows > Templates. double click on the Dating sim template to load it into the scene.

6 Create a new SceneDataAsset by ging to Assets > Create > Game Bridge > SceneData

7 Select your newly created SceneDataAsset. 

8 Your Game Bridge Editor Window should now be showing a Scene Icon, Double click on the scene icon in the Game Bridge Editor Window then click the push button to send the Dating im scene data over into the SceneData Asset.

9 This is how you push data from Storyteller.

10 Now that you have successfully pushed dats from Storyteller. create a new gameobject or select a gameobject from the Hierarchy and then in the Game Bridge window, click on Dialoguer. 

11 You have now added a Dialoguer component to your gameobjet.

12 Select the gameobject , drag and drop the SceneData in the SceneData object area in the inspecto of the Dialoguer.

13 go back to the storyteller window and select the character who you wish to be your player.

14 Select the gameobject with the Dialogue component.

15 In the inspector you will see a button says "Setup/ Re-Setup Character" , press it.

16 In the inspector you will see information of the selected node diplayed . Click the "Is not Player. Turn On Player?" button. Once you see the Golden crown, your player has been fully setup

At this point  you now know how to setup your Dialoguer.

17 Open the Dating Sim Scene.We have a fully setup example scene . please take a look at how the UI is setup.

18 you may design and ue any UI you want , Jut ensure you assign UI values in the Dialoguer inspector as showin in the example scenes.

FOR SETTING UP CHARACTER COMPONENT  , as seen in the NPC walkup scene.

1 Load the NPC Walkup template into a empty storyteller scene.

2 Create your SceneData and push a the NPC walkup scene data to it just as you did before.

3 This time assign a Character compent to each character in your game scene who you wish to represent a character in your story.

4 Assign the Scene Data Asset to each Charactrs Character Component SceneData Object area.

4 You can go ahead and press "Setup/ Re-Setup Character" on each character in your scene.

5 Now go ahead and turn on the yellow crown for your player by pressing the "Is not Player. Turn On Player?" button.

6 Each Character has a "Matching Route Number" value section in the inspector . for each character, make this number match the characters route path value in Storyteller. (see example scene for clarification)

6 Now you know how to setup a Dynamic Dynogue system for a RPG style NPC dialogue.

7 Please see the NPC Walkup example scene and look at how each component of UI is setup.

Send all further questions to daimangou@gmail.com