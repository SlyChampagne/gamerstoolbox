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

        public Int16 CareerSpecialAbilityLevel { get; set; }
        public Int16[] CareerSkills;
        
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
            CareerBalancePoints = (Int16)(CareerPoints - CareerSpecialAbilityLevel - CareerSkillsAssigned);

            DiceBag hand = new DiceBag();
            Int16 skillincrement = 1;

            do
            {
                //find what stat is increased
                Int16 statposition;
                statposition = hand.ThrowDice(1, 9);

                //Increase that stat position (0 is special ability, 1-9 is the career skill)
                if (mycareerskills[statposition] + skillincrement <= 10)
                {
                    mycareerskills[statposition] += skillincrement;
                }

                CareerSkillsAssigned = 0;
                for (Int16 i = 1; i <= 9; i++)
                {

                    CareerSkillsAssigned += mycareerskills[i];
                }
                CareerBalancePoints = (Int16)(CareerPoints - CareerSpecialAbilityLevel - CareerSkillsAssigned);
            }
            while (CareerBalancePoints > 0);

            //Array.Copy(mycareerskills, CareerSkills, 10);
            //sourceArray.CopyTo(targetArray, 0);
            //mycareerskills.CopyTo(CareerSkills, 0);

            CareerSkills = mycareerskills;
 
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
