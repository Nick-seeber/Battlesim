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
       static int enemyhp = 10;
       static bool turns = true;
       static bool playing = true;
       static string name = string.Empty;

        static void Main(string[] args)
        {
            battlesim();
            //Romulan();
            //enterprise();
            
            Console.ReadKey();
        }

        static void battlesim()
        {

            starfleet();
            Console.WriteLine("Please login with your name \n Login:");
            name = Console.ReadLine();
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

                
                if (playerhp <= 0)
                {


                    win();
                    //Console.ReadKey();
                }
                else if (enemyhp <= 0)
                {



                    Loose();


                   // Console.ReadKey();
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
            
            int sdamage = 0;
            int mdamage = 0;
            int HHP = 0;
            Random percentrng = new Random();
            int percent = percentrng.Next(1, 10);
            string attackinput = string.Empty;
            attackinput = Console.ReadLine();
            if (attackinput.Length < 1 || int.Parse(attackinput) > 3)
            {
                Console.WriteLine("You stumbled and lost your turn!");
                turns = false;
            }
            
            Random sword = new Random();
            Random magic = new Random();
            Random Heal = new Random();
            enterprise();
            if (attackinput == "1")
            {
                if (percent <= 8)
                {
                    
                    sdamage = sword.Next(20, 35);
                    enemyhp = enemyhp - sdamage;
                    Console.WriteLine("you attacked with a photon torpedo for " + sdamage + " damage");
                    Console.WriteLine("Romulan HP: " + enemyhp);
                }
                else if (percent > 
                    8)
                {
                    Console.WriteLine("You Missed!");
                }

                if (enemyhp <= 0)
                {
                    Console.WriteLine("You win!");
                    Console.WriteLine("Romulan HP: " + enemyhp);
                    Console.WriteLine(name.ToUpper() + " HP: "+ playerhp);
                    playing = false;
                }
                

            }
            else if (attackinput == "2")
            {
                enterprise();
                mdamage =  magic.Next(10, 15);
                enemyhp = enemyhp - mdamage;
                
                Console.WriteLine("you attacked with Phasers for " + mdamage + " damage" );
                Console.WriteLine("Romulan HP: " + enemyhp);
                

                
                
            }
            else if (attackinput == "3")
            {
                enterprise();
                HHP = Heal.Next(10, 20);
                playerhp = playerhp + HHP;
                Console.WriteLine("Your shields regenerated for " + HHP + "HP");
                Console.WriteLine("Romulan HP: " + enemyhp);
                
                
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();


        }

        static void defend()
        {
            int edamage = 0;

            Romulan();

            Random defendattack = new Random();
            Console.WriteLine("Romulans HP: " + enemyhp);
            

            edamage = defendattack.Next(5, 15);
            playerhp = playerhp - edamage;

            Console.WriteLine("The Romulans did " + edamage + " damage! \n" + name.ToUpper() + " HP is: " + playerhp );
            
            
           
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

            

            Console.WriteLine(@".                             
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
                              .");
Console.WriteLine("                               STARFLEET HEADQUARTERS");
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
            Console.WriteLine("You Win!");
        }

        static void Loose()
        {
            Console.Clear();
            Console.WriteLine("You Loose");
        }

       
    }

}

