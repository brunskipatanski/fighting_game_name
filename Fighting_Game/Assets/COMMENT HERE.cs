
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




































/* Sneaky Baller lurking here hehe!
 * 
 * He is not down completely */
