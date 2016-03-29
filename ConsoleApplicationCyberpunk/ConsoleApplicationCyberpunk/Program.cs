using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCyberpunk
{
    class Program
    {

        enum eCharacterType
        {
            FastDirtyExpandable
            , StandardMethod1

        }

        static void Main(string[] args)
        {

            //ask how many characters to create
            //loop
            //FastDirtyExpandable_Old();
            
            GenerateCharacter("FastDirtyExpandable", true);

            Console.WriteLine("Press <enter> to exit.");
            Console.ReadLine();

        }


        static void GenerateCharacter(string sNPCType, bool bprintyn)
        {
            //sType 0 : Fast Dirty Expandable
            eCharacterType myType;

            if (Enum.TryParse<eCharacterType>(sNPCType, true, out myType))
            {
                switch (myType)
                {
                    case eCharacterType.FastDirtyExpandable:
                        FastDirtyExpandable(bprintyn);
                        break;
                    case eCharacterType.StandardMethod1:
                        break;
                    default:
                        break;
                }
            }
        }

        static void FastDirtyExpandable(Boolean bprintyn)
        {
            Character punk = new Character();

            Console.Write("Is this an advanced NPC (Y/N) :");
            ConsoleKeyInfo result = Console.ReadKey();

            punk.bAdvancedNPCYN = (result.Key == ConsoleKey.Y);
            punk.CreateFastDirtyExpandable(bprintyn);
            //punk.FDE_PrintCharacter();
        }

        static void FastDirtyExpandable_old()
        {
            Character punk = new Character();
            DiceBag hand = new DiceBag();
            
            //Step 1 Stats
            //2D6 nine times
            //Index 0 always has to total for all the dice rolled.
            punk.INT = hand.ThrowDice(2, 6, 11);
            punk.REF = hand.ThrowDice(2, 6, 11);
            punk.TECH = hand.ThrowDice(2, 6, 11);
            punk.COOL = hand.ThrowDice(2, 6, 11);
            punk.ATTR = hand.ThrowDice(2, 6, 11);
            punk.LUCK = hand.ThrowDice(2, 6, 11);
            punk.MA = hand.ThrowDice(2, 6, 11);
            punk.BODY = hand.ThrowDice(2, 6, 11);
            punk.EMP = hand.ThrowDice(2, 6, 11);
            
            //Step 2 Role & Skills
            punk.RoleID = hand.ThrowDice(1, 9);
            punk.CharacterRole = punk.GetRole();

            Console.WriteLine(punk.CharacterRole);
            //Console.WriteLine("INT:" + punk.INT.ToString());
            //Console.WriteLine("REF:" + punk.REF.ToString());
            //Console.WriteLine("TECH:" + punk.TECH.ToString());
            Console.WriteLine("INT:{0}   REF:{1}   TECH:{2}", punk.INT.ToString(), punk.REF.ToString(), punk.TECH.ToString());
            Console.WriteLine("COOL:{0}  ATTR:{1}  LUCK:{2}", punk.COOL.ToString(), punk.ATTR.ToString(), punk.LUCK.ToString());
            Console.WriteLine("MA:{0}    BODY:{1}  EMP:{2}", punk.MA.ToString(), punk.BODY.ToString(), punk.EMP.ToString());
            Console.WriteLine();

            //Console.WriteLine("Press <ENTER> to view Skills...");          
            //Console.ReadLine();

            punk.DistributeCareerPoints(40, 1);
            Console.WriteLine("Special Ability Level :" + punk.CareerSpecialAbilityLevel.ToString());

            for (Int16 i = 0; i <= 9; i++)
            {
                Console.WriteLine("Skill Level :" + punk.CareerSkills[i].ToString());
            }

            //Step 2.2 Pickup Skills for advanced NPC
            //ask if Advanced NPC Y/N : ?

            //bool bAdvancedNPCYN = false;

            Console.Write("Is this an advanced NPC (Y/N) :");
            ConsoleKeyInfo result = Console.ReadKey();

            //bAdvancedNPCYN = (result.Key == ConsoleKey.Y);

            punk.bAdvancedNPCYN = (result.Key == ConsoleKey.Y);
            punk.FDE_DistributePickupSkills();
            if (punk.bAdvancedNPCYN)
            {
                //Console.WriteLine();
                //Console.WriteLine(punk.PickupSkillPointsInitial.ToString());

                //punk.DisplayPickupSkills();
            }
            else
                Console.WriteLine();



            //Step 3 Pick Cyberwear
            //Roll 1D10. Solos roll 6 times. all others roll 3 times.
            //if duplicates rolls, re-roll.



        }
    }
}
