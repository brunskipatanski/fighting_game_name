
using UnityEngine;

public class COMMENTHERE : MonoBehaviour
{
    // < for short 1 line comments👓
    /* < for long multi line comments👓 */

    /*didnt know how to create a text file in unity so comment here. i made soem changes...👓
     * i made the camera size 4.64, need it to be smaller for scrolling the stage. also made some fallback elements like ground and walls.👓
     * good if we cant load some assets or just need to test out shit like chars...👓*/

    /*note that 6.10.2023 we have mot yet implemented stage scrolling or upward scrolling as players go up, so they will see the backgrounds
     * end when camera is implemented👓*/

    // and we are using scenes in this project guys. each stage has theyr own scene. main menus and shit. dont need to make every part of the game on the same page/scene. Basic_FallBack_stage is for testing and fallback👓
}





// ok we use transform for horizontal movement and rb for jumps and shit👓
//use tags!👓


/*12.10,,, i started working on some more movement code mainly focusing on the jump since the jump is really important in fgs. got the char to jump but got some other problems. 👓
 * char rn wont jump by pressing W for some reason idk maybe tags arent set up right. jumping with fixedupdate doesnt work well rn. so i made the entire move method just an update. we should figure out how to get it working in fixed👓
 * since other wise the movement will depend on the hardwares fps. i also set up some tags for the stage and players. idk if i did it good tho.  /*👓



23.10,,, got the jump working as we want. small bug with highspeed jumps. most of the info is in the movement script👓
Jump feel can be discussed between the 3 of us. next up im working on double jump and air dash. 👓


27.10,,, not sure with what kinds of thing you changed AT, like character size, just feels really tiny, like the chars are the things you are looking at the most, so why not make them bigger👓
feels wierd to ahve them take it sucha  small amount of screen space. 👓
idk w´hy you made the background like that, maybe comsentate with the char size? now it looks like complete ass and is blurred to hell. i get that its a test background and shit. but we cant just make every background like that👓
we should make them to fit the stage not just bigger so they do. the background i amde was made for the stage. 👓
I changed some of the jump code to implement the double jump. it now checks, if (Grounded == true),,, after Input W. and if else if (Grounded == false && DoubleJumped == false) it does the double jump. 👓
isnt working 100% correctly yeat got it to jump but wont register my left adn right movemtns and only does a nautral jump.👓
1 big improment would be to change all the KeyCode.W´shits and ll that to just be controles. like if jump == true; does shit. so we can set up the controls, also allows for more code in the future👓



31.10,,, got the double jumo working. had an issue where i was deleting any forces before the double jump, so the character didnt stack the velocity up and become a bullet. 👓
also lets the char do like a fake jump. where they jump forward and then double jump back. works the other way around 2. im happy :)👓
if u guys are reading this, main thing someoen shoudl rly focus on rn is making all the inputs and options. like instead of getkeydown blah blah its just a designated key the user can set.👓
once we have that we cna start implementing the player 2 character cos we can seperate the controlrs. and ofc once we got 2 players. we cant get the actual game working and stuff like the camera working 2.👓



6.11,,, yo we now have 2 players on screen just made it so they pass-trhu each other should not cause issues this way.👓
heres a list of all the moves the basic stickman guy will have (dummy 2).👓
5A, 2A, JA. 5B, 2B, JB
the numbers are numpad notiations. like   9  8  7
                                          4  5  6
                                          1  2  3
so something like a 5A would be nautral A, or standing A
J stands for "jump" so any moves in the air

5A: basic strike, doesnt deal 2 much damage and on hit combos into 2B or 5B. should be un-punishable on block. if possible this should work as the anti air if not make another move like 4B that does a dp 👓
2A basic low, hits low, better range then 5A. should be slower then 5A but not by a lot. should still be able to combo off something like JA 2A 2B for example.👓
JA basic attack in the air. on grounded hit on opponent should combo into 5A or 2A, 2B 2 but not 5B. on block should be minus but not so much its punishable👓
👓
5B basic fireball. goes fullscreen, no combo on hit. but can be comboed into when close. from, 5A, 2A.👓
2B a sweep, knockdown allowing for oki. deals less damage then 5b fireball. should have greater range then 2A, can be comboed into from 5A, 2A, JA👓
JB a air fireball that shoots FORWARD not super usefull but can allow some players to play more of a zoning type game.  IMPORANT IN SHOOTS DIRECTLY FORWARD, IF IMPLEMENTED IN A WAY WHERE IT SHOOTS DOWNWARD WILL BE ANNOYING AF👓

grab, basic grab, we dont even need to implement a way to tech the grab. just make it so when you are in the air the grab cant hit u. and ofc goes trhu blocks, also grabs attacks in the start up frames of their attack👓

basic combos. 
jump-in
JA > 2A > 5B
Ja > 5A > 2B
you can do either 2A or 5A after JA hit, and depending on range hit 5B or 2B
counter poke
2A > 5B
2A > 2B knockdown

THIS IS A CANCEL BASED SYSTEM! kinda like footsies, you cancel the endlag/recovery of your move into another move👓
hit glasses up for more details on spesific moves. ill update this with frame data and all that later👓
























vv look at this dude bruh

/* Sneaky Baller lurking here hehe!
 * 
 * He is not down completely */
