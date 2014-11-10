using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Battlesim
{
    class Program
    {
       static int playerhp = 100;
       static int enemyhp = 200;
       static bool turns = true;
       static bool playing = true;
       static string name = string.Empty;

        static void Main(string[] args)
        {
            //calling my battle simulator 
            battlesim();
            
            
            
            Console.ReadKey();
        }

        static void battlesim()
        {
            //starfleet function is ascii art
            starfleet();
            //Getting your name 
            Console.WriteLine("Please login with your name \n Login:");
            name = Console.ReadLine();
            //clearing the console to writing the welcome message and instructions
            Console.Clear();
            Console.WriteLine( "Welcome Captian " + name + " You are captian of the Starship Enterprise ");
            Thread.Sleep(100);
            Console.WriteLine("You are defending the neutral zone from the Romulans");
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("You have 2 weapons to choose from, Photon torpedos which does the most damage \n but will only hit 80% of the time ");
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("You also have Phasers you can use which will always \n hit but do less damage than Photon Torpedos.");
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("You can also regenerate your shields");
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("Choose your weapon! Press 1 for photon torpedos and 2 for phasers, \n or press 3 to regenrate shields");
            Thread.Sleep(100);
            Console.WriteLine();
            
            
            while (playing)
            {

                //loop to see if the game is still going and no one has died also to decide whos turn it is.
                if (playerhp <= 0)
                {


                    Loose();
                    //Console.ReadKey();
                    break;
                }
                else if (enemyhp <= 0)
                {



                    win();
                    break;


                   
                }
                else if (turns)
                {
                    attack();
                    turns = false;
                }
                else if (turns == false)
                {
                    defend();
                    turns = true;
                }
            }
        }

        static void attack()
        {
            //This function handles the attack on the enemy here I am declaring some variables.
            int sdamage = 0;
            int mdamage = 0;
            int HHP = 0;
            Random percentrng = new Random();
            int percent = percentrng.Next(1, 10);
            string attackinput = string.Empty.ToUpper();
            attackinput = Console.ReadLine();
            Random sword = new Random();
            Random magic = new Random();
            Random Heal = new Random();
            //This checkes to see if the user input is greater than 3 or more numbers that 1 number
            if (attackinput.Length < 1 || int.Parse(attackinput) > 3)
            {
                Console.WriteLine("You stumbled and lost your turn!");
                turns = false;
                Console.ReadKey();
            }
            
            
            //this is the photon torpedo if statement, you have a 8 in 10 chance of hitting. So 80%
             if (attackinput == "1")
            {
                 //This calls the function for attack ascii art
                     enterprise();
                if (percent <= 8)
                {
                    //
                    sdamage = sword.Next(20, 35);
                    enemyhp = enemyhp - sdamage;
                    Console.WriteLine("you attacked with a photon torpedo for " + sdamage + " damage");
                    Console.WriteLine("Romulan HP: " + enemyhp);
                    Console.WriteLine(name.ToUpper() + " HP:" + playerhp);
                }
                else if (percent > 
                    8)
                {
                    Console.WriteLine("You Missed!");
                }

                
                

            }
                 //this is for the phasers
            else if (attackinput == "2")
            {
                enterprise();
                mdamage =  magic.Next(10, 15);
                enemyhp = enemyhp - mdamage;
                
                Console.WriteLine("you attacked with Phasers for " + mdamage + " damage" );
                Console.WriteLine("Romulan HP: " + enemyhp);
                Console.WriteLine(name + " HP: " + playerhp);
                

                
                
            }
                 //this is for the shield regenreation
            else if (attackinput == "3")
            {
                enterprise();
                HHP = Heal.Next(10, 20);
                playerhp = playerhp + HHP;
                Console.WriteLine("Your shields regenerated for " + HHP + "HP");
                Console.WriteLine("Romulan HP: " + enemyhp);
                Console.WriteLine(name +" HP: " + playerhp);
                
                
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();


        }

        static void defend()
        {
            //the defend function handles when the player is being attacked by the romulans
            int edamage = 0;
            //this calls the romulan ascii art function.
            Romulan();
            //making a new random number
            Random defendattack = new Random();
            
            
            //edamage is the string that will hold the amount of damage the romulans do with the num generator
            // then I minus the edamage from the playerhp string.
            edamage = defendattack.Next(5, 15);
            playerhp = playerhp - edamage;
            //writing to the console 
            Console.WriteLine("The Romulans did " + edamage + " damage! \n" + name + " HP is: " + playerhp );
            Console.WriteLine("Romulans HP: " + enemyhp);
            
           
            Console.WriteLine("Choose Your Attack! Press 1 for Photon Torpedos. Press 2 for Phasers. \n Press 3 to regenerate shields!");

        }

        static void enterprise() 
        {
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Thread.Sleep(50);
                Console.Beep(600, 50);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(50);
                Console.Beep(500, 50);
                Console.Clear();


                Console.WriteLine(@" 
 ===-----------------------------!!*.               .--*--.
    ==IIII  ------- NCC-1701 -->-  !!**    I'''''''''''''''''''''''''''!
    =----------------------------I!!*'    !...........................!
                            !=!         /   /       ''=.=''
                            !=!        / ../
                            !=!       / ../
                            *'!.!''''''''''''L !
                        (''  ..  ... --->=I(!-
                            '''=.....        / !
                                    `'''''' ");
                

            }
            Console.Clear();

            
            
 
        }
        static void starfleet()
        {
            string starfleetstring = @".                             
                                          .:.                             
                                         .:::.                            
                                        .:::::.
                                    ***.:::::::.***                                        
                               *******.:::::::::.*******                                          
                             ********.:::::::::::.********                                       
                            ********.:::::::::::::.********                                          
                            *******.::::::'***`::::.*******                                           
                            ******.::::'*********`::.******                                             
                             ****.:::'*************`:.****                                              
                               *.::'*****************`.*                                               
                               .:'  ***************    .                                             
                              .";

            for (int i = 0; i < starfleetstring.Length - 1; i++)
            {

                Console.Write(starfleetstring[i]);
                Thread.Sleep(4);
            }
            
Console.WriteLine("  STARFLEET HEADQUARTERS");
        }

        static void Romulan()
        {
            
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Thread.Sleep(50);
                Console.Beep(100, 50);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(50);
                Console.Beep(100, 50);
                Console.Clear();
              



                Console.WriteLine(@"
                    ___.-----.n.----._________.-.______
           ___,----'     \|||||  _______________________`-._
       .--'    n                 \------------------, ` \___`.
  __,-' _____________             \          `-===|  \@\      \
 /-----'  /        __\______.......|____        ==|   \_) -----\
|@ .-----|        |         |      |_  /         -\     =======\`
|  `-----|        |_________|......|___\___________\          __\
 \-----.__\__________/             |_______.--------`._       `. \
  `-.__                           / _/                 `--.__   \|
       `-._u                    .'-'                         `-. |
            `---.___________.--'                                \|");
                
            }Console.Clear();
           
            
        }

        static void win()
        {
            Console.Clear();
            string winstring = @"
__   __            _    _ _       _ _ 
\ \ / /           | |  | (_)     | | |
 \ V /___  _   _  | |  | |_ _ __ | | |
  \ // _ \| | | | | |/\| | | '_ \| | |
  | | (_) | |_| | \  /\  / | | | |_|_|
  \_/\___/ \__,_|  \/  \/|_|_| |_(_|_) ";
            for (int i = 0; i <= winstring.Length - 1; i++)
            {
                Console.Write(winstring[i]);
                Thread.Sleep(5);
            }
                                      
                                      
            

        }

        static void Loose()
        {
            Console.Clear();
            string losestring = @"
__   __            _                    _ _ 
\ \ / /           | |                  | | |
 \ V /___  _   _  | |     ___  ___  ___| | |
  \ // _ \| | | | | |    / _ \/ __|/ _ \ | |
  | | (_) | |_| | | |___| (_) \__ \  __/_|_|
  \_/\___/ \__,_| \_____/\___/|___/\___(_|_)
                                            
                                            ";
            for(int i = 0; i <= losestring.Length - 1; i++)
            {
                
                Console.Write(losestring[i]);
                Thread.Sleep(5);

            }
        }

       
    }

}

