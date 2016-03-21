using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCyberpunk
{
    class Program
    {
        static void Main(string[] args)
        {

            //ask how many characters to create
            //loop
            FastDirtyExpandable();
            Console.ReadLine();

        }

        
        static void FastDirtyExpandable()
        {
            Character punk = new Character();
            DiceBag hand = new DiceBag();
            
            //Step 1 Stats
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
            Console.WriteLine("INT:" + punk.INT.ToString());
            Console.WriteLine("REF:" + punk.REF.ToString());
            Console.WriteLine("TECH:" + punk.TECH.ToString());
            Console.WriteLine("COOL:" + punk.COOL.ToString());
            Console.WriteLine("ATTR:" + punk.ATTR.ToString());
            Console.WriteLine("LUCK:" + punk.LUCK.ToString());
            Console.WriteLine("MA:" + punk.MA.ToString());
            Console.WriteLine("BODY:" + punk.BODY.ToString());
            Console.WriteLine("EMP:" + punk.EMP.ToString());

            punk.DistributeCareerPoints(40, 1);
            Console.WriteLine("Special Ability Level :" + punk.CareerSpecialAbilityLevel.ToString());

            for (Int16 i = 0; i <= 9; i++)
            {
                Console.WriteLine("Skill Level :" + punk.CareerSkills[i].ToString());
            }
        }
    }
}
