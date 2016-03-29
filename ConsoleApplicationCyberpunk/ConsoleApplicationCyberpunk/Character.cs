using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCyberpunk
{

    enum Career
    {
        Rockerboy           
        , Solo               
        , Netrunner          
        , Techie              
        , Media              
        , Cop             
        , Corporate             
        , Fixer            
        , Nomad              
    }
    

    public class Character
    {
        public int CharacterID { get; set; }

        public string CharacterRole { get; set; }
        public Int16 RoleID { get; set; }
        public Int16 SpecialAbilityLevel {get; set;}

        public virtual Int16 INT { get; set; }
        public virtual Int16 REF { get; set; }
        public virtual Int16 TECH { get; set; }
        public virtual Int16 COOL { get; set; }
        public virtual Int16 ATTR { get; set; }
        public virtual Int16 LUCK { get; set; }
        public virtual Int16 MA { get; set; }
        public virtual Int16 BODY { get; set; }
        public virtual Int16 EMP { get; set; }
        public virtual Int16 TotalStats { get; set; }

        public int CareerSpecialAbilityID { get; set; }

        public int CareerSkillID1 { get; set; }
        public int CareerSkillID2 { get; set; }
        public int CareerSkillID3 { get; set; }
        public int CareerSkillID4 { get; set; }
        public int CareerSkillID5 { get; set; }
        public int CareerSkillID6 { get; set; }
        public int CareerSkillID7 { get; set; }
        public int CareerSkillID8 { get; set; }
        public int CareerSkillID9 { get; set; }

        public bool bAdvancedNPCYN { get; set; }
        public int PickupSkillID1 { get; set; }
        public int PickupSkillID2 { get; set; }
        public int PickupSkillID3 { get; set; }
        public int PickupSkillID4 { get; set; }
        public int PickupSkillID5 { get; set; }

        public Int16 CareerSkillPoints;
        private Int16 CareerSkillPointsAssigned;
        private const Int16 BaseCareerPoints = 40;

        public Int16 CareerSpecialAbilityLevel { get; set; }
        public Int16[] CareerSkills;
        public Int16[] PickupSkills;

        public Int16 PickupSkillPointsInitial { get; set; }

        public void CreateFastDirtyExpandable(bool bprint)
        {
            DiceBag fdedicebag = new DiceBag();

            FDE1_GenerateStats(fdedicebag);
            FDE21_RoleAndSkills();
            FDE22_Advanced();
            FDE3_Cyberwear();
            FDE4_ArmorAndWeapons();

            if (bprint)
            {
                FDE5_PrintCharacter();
            }

        }

        private void FDE1_GenerateStats(DiceBag mydicebag)
        {
            //DiceBag hand = new DiceBag();
            DiceBag hand = mydicebag;

            INT = hand.ThrowDice(2, 6, 11);
            REF = hand.ThrowDice(2, 6, 11);
            TECH = hand.ThrowDice(2, 6, 11);
            COOL = hand.ThrowDice(2, 6, 11);
            ATTR = hand.ThrowDice(2, 6, 11);
            LUCK = hand.ThrowDice(2, 6, 11);
            MA = hand.ThrowDice(2, 6, 11);
            BODY = hand.ThrowDice(2, 6, 11);
            EMP = hand.ThrowDice(2, 6, 11);
        }

        public void FDE21_RoleAndSkills()
        {
            DiceBag hand = new DiceBag();

            RoleID = hand.ThrowDice(1, 9);
            CharacterRole = GetRole();

            DistributeCareerPoints(BaseCareerPoints, 1);
        }
        public void FDE22_Advanced()
        {
            FDE_DistributePickupSkills();
        }

        public void FDE3_Cyberwear()
        {
            DiceBag mydicebag = new DiceBag();

            //not done yet.
            string[] cyberoptics = new string[] { "IR" , "LL", "DC", "DE", "AD", "TA"};
            string[] cyberarm = new string[] { "Med. Pistol", "Light Pistol", "Med. Pistol", "Light Submachinegun", "Very Heavy Pistol", "Heavy Pistol" };
            string[] cyberaudio = new string[] { "Wearman", "Radio Splice", "Phone Link", "Amplified Hearing", "Sound Editing", "Digital Recording Link" };
            
            string[] cyberwear = new string[]{};

            Int16 nbrdice = 3;
            if (CharacterRole == "Solo")
            {
                nbrdice = 6;
            }

            Int16[] handresultcyberwear = new Int16[nbrdice];

            mydicebag.RollDice(nbrdice, 6, true);
            handresultcyberwear = mydicebag.handresult;

            DiceBag myseconddicebag = new DiceBag();


            for (Int16 i = 0; i <= nbrdice; i++)
            {
                myseconddicebag.RollDice(1, 6);

                switch (handresultcyberwear[i])
                {
                    case 1: //Cyberoptic
                        //cyberwear[i] = cyberoptics[myseconddicebag.handresult];
                        break;
                    case 2: //Cyberarm
                        break;
                    case 3: //Cyberaudio
                        break;
                    case 4 : //Big Knucks
                        break;
                    case 5: //Rippers
                        break;
                    case 6: //Vampires
                        break;
                    case 7: //Slice n dice
                        break;
                    case 8: //Reflex Boost (Kerenzikov)
                        break;
                    case 9: //Reflex Boost (Sandevistan)
                        break;
                    case 10:    //Nothing
                        break;
                    default:
                        break;
                }
            }


        }
        public void FDE4_ArmorAndWeapons()
        {
            //not done yet.
        }

        public void FDE_PrintCharacter()
        {
            FDE5_PrintCharacter();
        }

        public void FDE5_PrintCharacter()
        {
            FDE_PrintStats(); 
            FDE_PrintRole();
            FDE_PrintCareerSkills();
            FDE_PrintPickupSkills();

            
        }

        public void FDE_PrintStats()
        {
            Console.WriteLine();
            Console.WriteLine("INT:{0}   REF:{1}   TECH:{2}", INT.ToString(), REF.ToString(), TECH.ToString());
            Console.WriteLine("COOL:{0}  ATTR:{1}  LUCK:{2}", COOL.ToString(), ATTR.ToString(), LUCK.ToString());
            Console.WriteLine("MA:{0}    BODY:{1}  EMP:{2}", MA.ToString(), BODY.ToString(), EMP.ToString());
            Console.WriteLine();
        }

        public void FDE_PrintRole()
        {
            Console.WriteLine();
            Console.WriteLine(CharacterRole);
            //Console.WriteLine("Special Ability Level :" + CareerSpecialAbilityLevel.ToString());
        }

        public void FDE_PrintCareerSkills()
        {
            Console.WriteLine("Career Skill Points : {0}", CareerSkillPoints.ToString());
            for (Int16 i = 0; i <= 9; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Special Ability Level :" + CareerSpecialAbilityLevel.ToString());
                    //Console.WriteLine("Special Ability Level :" + CareerSkills[i].ToString());
                }
                else
                {
                    Console.WriteLine("Skill Level :" + CareerSkills[i].ToString());
                }
            }
        }
        public void FDE_PrintPickupSkills()
        {
            if (PickupSkills != null)
            {
                Console.WriteLine();
                Console.WriteLine("Pickup Skill Points : {0}", PickupSkills[0].ToString());
                Console.WriteLine("Pickup Skills (1-{0})", ((PickupSkills.Length) - 1).ToString());

                Int16 NbrPickupskills = 0;
                NbrPickupskills = (Int16)(PickupSkills.Length);

                for (Int16 i = 1; i <= NbrPickupskills - 1; i++)
                {
                    if (PickupSkills[i] > 0)
                        Console.WriteLine("Pickup Skill #{0} : {1}", i, PickupSkills[i].ToString());
                }
                //Console.WriteLine("Pickup Skills (1-5) : {0}, {1}, {2}, {3}, {4} ", PickupSkills[1].ToString(), PickupSkills[2].ToString(), PickupSkills[3].ToString(), PickupSkills[4].ToString(), PickupSkills[5].ToString());
            }
        }

        public Int16 GetRoleID(string charRole)
        {
            Career mycareer;
            Int16 retvalue = 0;

            if (Enum.TryParse<Career>(charRole, true, out mycareer))
            {
               
                switch (mycareer)
                {
                    case Career.Rockerboy:
                        retvalue = 1;
                        break;
                    case Career.Solo:
                        retvalue = 2;
                        break;
                    case Career.Netrunner:
                        retvalue = 3;
                        break;
                    case Career.Techie:
                        retvalue = 4;
                        break;
                    case Career.Media:
                        retvalue = 5;
                        break;
                    case Career.Cop:
                        retvalue = 6;
                        break;
                    case Career.Corporate:
                        retvalue = 7;
                        break;
                    case Career.Fixer:
                        retvalue = 8;
                        break;
                    case Career.Nomad:
                        retvalue = 9;
                        break;
                    default:
                        retvalue = 0;
                        break;
                }
            }
            else
            {
                retvalue = 0;
            }
            return retvalue;
        }

        public string GetRole()
        {
            String retValue = "";

            switch (RoleID)
            {
                case 1:
                    retValue= "Rockerboy";
                    break;
                case 2:
                    retValue = "Solo";
                    break;
                case 3 :
                    retValue = "Netrunner";
                    break;
                case 4:
                    retValue = "Techie";
                    break;
                case 5:
                    retValue = "Media";
                    break;
                case 6:
                    retValue = "Cop";
                    break;
                case 7:
                    retValue = "Corporate";
                    break;
                case 8:
                    retValue = "Fixer";
                    break;
                case 9:
                    retValue = "Nomad";
                    break;
                default:
                    retValue = "";
                    break;
            }
            return retValue;

        }

        public void DistributeCareerPoints(Int16 CareerPoints, Int16 CharacterClassLevel)
        {
            /*
             CharacterClassLevel
             1 : SpecialAbility 1-5, InitialSkillLevel : 1, MaxSkillLevel : 10, SkillIncrement: 1
             2 : SpecialAbility 2-6, InitialSkillLevel : 1, MaxSkillLevel : 10, SkillIncrement: 1
             3 : SpecialAbility 3-7, InitialSkillLevel : 1, MaxSkillLevel : 10, SkillIncrement: 1
             4 : SpecialAbility 4-8, InitialSkillLevel : 2, MaxSkillLevel : 10, SkillIncrement: 1
             5 : SpecialAbility 5-9, InitialSkillLevel : 2, MaxSkillLevel : 10, SkillIncrement: 1
             6 : SpecialAbility 6-10, InitialSkillLevel : 2, MaxSkillLevel : 10, SkillIncrement: 1
             */

            /*  Steps to distribute a full Career (Special Ability and 9 Career Skill points

            1) Assign Special Ability Level based on CharacterClassLevel
            2) Assign InitialSkillLevel to each skill in array CareerSkills
            3) Calculate balance of points (CareerPoints (40) - SpecialAbilityLEvel - (InitialSkillLevel * 9 stats)
            4) Roll 1-9, add +1 to that array position
             *  make sure it does not exceed MaxSkillLevel per ChracterClassLevel

            */

            CareerSpecialAbilityLevel = DistributeCareerPoints_SpecialAbility(CharacterClassLevel);

            Int16 InitialSkillLevel = 0;

            Int16[] mycareerskills = new Int16[10];
            switch (CharacterClassLevel)
            {
                case 1:
                    InitialSkillLevel = 1;
                    break;
                case 2:
                    InitialSkillLevel = 1;
                    break;
                case 3:
                    InitialSkillLevel = 1;
                    break;
                case 4:
                    InitialSkillLevel = 1;
                    break;
                case 5:
                    InitialSkillLevel = 2;
                    break;
                case 6:
                    InitialSkillLevel = 2;
                    break;
                default:
                    break;
            }


            mycareerskills[0] = CareerSpecialAbilityLevel;

            Int16 CareerSkillsAssigned = 0;

            for (Int16 i = 1; i <= 9; i++)
            {
                mycareerskills[i] = InitialSkillLevel;
                CareerSkillsAssigned += InitialSkillLevel;
            }


            Int16 CareerBalancePoints = 0;
            //CareerBalancePoints = (Int16)(CareerPoints - CareerSpecialAbilityLevel - CareerSkillsAssigned);

            DiceBag hand = new DiceBag();
            Int16 skillincrement = 1;
            Int16 statposition;

            CareerBalancePoints = (Int16)(CareerPoints - (CareerSpecialAbilityLevel + CareerSkillsAssigned));
            do
            {
                //find what stat is increased
                
                statposition = hand.ThrowDice(1, 9);

                //Increase that stat position (0 is special ability, 1-9 is the career skill)
                if (mycareerskills[statposition] + skillincrement <= 10)
                {
                    CareerBalancePoints -= skillincrement;

                    mycareerskills[statposition] += skillincrement;
                    
                    CareerSkillsAssigned = 0;
                    for (Int16 i = 1; i <= 9; i++)
                    {
                        CareerSkillsAssigned += mycareerskills[i];
                    }
                    CareerSkillPointsAssigned = CareerSkillsAssigned;
                    
                    //CareerBalancePoints = (Int16)(CareerPoints - CareerSpecialAbilityLevel - CareerSkillPointsAssigned);
                }
   
            }
            while (CareerBalancePoints > 0);

            CareerSkillPoints = (Int16)(CareerSpecialAbilityLevel + CareerSkillPointsAssigned);
            CareerSkills = mycareerskills;
            
        }

        //  Fast Dirty Expandable Pickup Skills (for advanced NPC only)
        public void FDE_DistributePickupSkills()
        {
            //If advanced NPC, roll an additional 2D10 and distribute these points among 5 pickup skills.

            Int16 myPickupskillsPoints = 0;

            if (bAdvancedNPCYN)
            {
                DiceBag hand = new DiceBag();
                hand.RollDice(2,10);

                myPickupskillsPoints = hand.handresult[0];
                PickupSkillPointsInitial = myPickupskillsPoints;

                Int16 PickupSkillsBalancePoints = myPickupskillsPoints;

                Int16[] mypickupkills = new Int16[6];
                mypickupkills[0] = 0;
                Int16 skillincrement = 1;

                //distribute this total of pickup skill points into 5 skills at random (like other methods).
                do
                {
                    Int16 statposition;

                    //we randomly select a position 1 to 5 to determine which pickup skill will get the increment.
                    statposition = hand.ThrowDice(1, 5);
                    if (mypickupkills[statposition] + skillincrement <= 10)
                    {
                        mypickupkills[statposition] += skillincrement;
                    }

                    //the space [0] contains the total points assigned this loop.
                    mypickupkills[0] += skillincrement;

                    //we reduce the number of points to assign by the increment;
                    PickupSkillsBalancePoints -= skillincrement;
                }
                while (PickupSkillsBalancePoints > 0);
                
                //cleanup the array by removing the skills that have zero level.
                Int16[] mypickupkillsCleared = new Int16[6];

                mypickupkillsCleared[0] = mypickupkills[0];
                Int16 nClearedPosCtr = 0;

                for (Int16 i = 1; i <= 5; i++)
                {                        
                    if (mypickupkills[i] > 0)
                    {
                        nClearedPosCtr += 1;
                        mypickupkillsCleared[nClearedPosCtr] = mypickupkills[i];
                    }                 
                }
                
                PickupSkills = mypickupkillsCleared;
            }
            else
            {
                // No pickup skills because this NPC is not "Advanced".
            }
            
        }
        

        private Int16 DistributeCareerPoints_SpecialAbility(Int16 CharacterClassLevel)
        {
            Int16 SkillLevel;
            SkillLevel = 0;
            DiceBag hand = new DiceBag();

            switch (CharacterClassLevel)
            {
                case 0:SkillLevel = hand.ThrowDice(1, 10);
                        break;
                case 1:SkillLevel = hand.ThrowDice(1, 5);
                    break;
                case 2:SkillLevel = 6;
                    break;
                case 3:SkillLevel = 7;
                    break;
                case 4:SkillLevel = 8;
                    break;
                case 5:SkillLevel = 9;
                    break;
                case 6:SkillLevel = 10;
                    break;
                default:
                    SkillLevel = hand.ThrowDice(1, 10);;
                    break;
            }
            return SkillLevel;

        }

    }

}
