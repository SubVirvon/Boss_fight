using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandNormalSwordHit = "1";
            const string CommandHeal = "2";
            const string CommandFireSwordHit = "3";
            const string CommandChainSwordHit = "4";
            const string EnemyStateVariant1 = "Куча слизи и костей";
            const string EnemyStateVariant2 = "Куча покрыта слизью";
            const string EnemyStateVariant3 = "Куча покрыта щитом из костей";
            int swordStrength = 55;
            int healStrength = 100;
            int fireSwordStrength = 145;
            int chainSwordStrength = 80;
            int enemyNormalStrenth = 45;
            int enemySlimeStrenth = 100;
            int enemyBoneStrenth = 15;
            int playerMaxHealth = 430;
            int playerHealth = playerMaxHealth;
            int enemyHealth = 700;
            int healCoolDown = 5;
            int healCoolDownWait = 0;
            string enemyState = EnemyStateVariant1;
            Random random = new Random();
            int randomNumber;
            int minValue = 1;
            int maxValue = 3;
            bool playerIsHit = false;
            bool gameIsEnd = false;

            Console.WriteLine("Вы храбрый воин с мечом. Перед вами ужасная агрессивная куча слизи с костями. Вам предстоит убить ее.");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            Console.Write("Ваше здоровье: " + playerHealth + "\nЗдоровье врага: " + enemyHealth + "\nСостояние врага: " + enemyState);
            Console.SetCursorPosition(0, 0);

            while (gameIsEnd == false)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Ваше здоровье: " + playerHealth + "hp\nЗдоровье врага: " + enemyHealth + "hp\nСостояние врага: " + enemyState);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Аттакуйте босса\n");
                Console.Write(CommandNormalSwordHit + ". Удар мечом (" + swordStrength + "dm)\n" + CommandHeal + ". Забраться на дерево (+" + healStrength + "hp)\n" + CommandFireSwordHit + ". Удар огненным мечом по слизи (" + fireSwordStrength + "dm)\n" + CommandChainSwordHit + ". Удар цепным мечом по костям (" + chainSwordStrength + "dm)\n\nВыбери свое действие: ");

                switch (Console.ReadLine())
                {
                    case CommandNormalSwordHit:
                        enemyHealth -= swordStrength;
                        Console.WriteLine("Враг потерял " + swordStrength + "hp от вашего меча");
                        playerIsHit = true;
                        break;
                    case CommandHeal:
                        if(healCoolDownWait == 0)
                        {
                            int nowHeal;

                            playerHealth += healStrength;

                            if (playerHealth > playerMaxHealth)
                            {
                                nowHeal = healStrength - (playerHealth - playerMaxHealth);
                                playerHealth = playerMaxHealth;
                            }
                            else
                            {
                                nowHeal = healStrength;
                            }
                            
                            Console.WriteLine("Сидя на дереве, вы востановили " + nowHeal + "hp\nКуча не смогла добраться до вас");
                            healCoolDownWait = healCoolDown;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете все время бегать от боя, подождите еще " + healCoolDownWait + " хода");
                        }

                        playerIsHit = false;
                        break;
                    case CommandFireSwordHit:
                        if(enemyState == EnemyStateVariant2)
                        {
                            enemyHealth -= fireSwordStrength;
                            Console.WriteLine("Удар огненным мечем плавит слизь, враг теряет " + fireSwordStrength + "hp");
                            playerIsHit = true;
                        }
                        else
                        {
                            Console.WriteLine("Огненный меч может причинить вред только слизи");
                            playerIsHit = false;
                        }
                        break;
                    case CommandChainSwordHit:
                        if (enemyState == EnemyStateVariant3)
                        {
                            enemyHealth -= chainSwordStrength;
                            Console.WriteLine("Вы буквально пропиливаете кости врага, он теряет " + chainSwordStrength + "hp");
                            playerIsHit = true;
                        }
                        else
                        {
                            Console.WriteLine("Цепной меч может застрять в вязкой слизи");
                            playerIsHit = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Такого удара нет");
                        playerIsHit = false;
                        break;
                }

                if (playerIsHit)
                {
                    if (healCoolDownWait > 0)
                    {
                        healCoolDownWait--;
                    }

                    if (enemyState == EnemyStateVariant1)
                    {
                        playerHealth -= enemyNormalStrenth;
                        Console.WriteLine("Враг аттакует вас, вы теряете " + enemyNormalStrenth + "hp");
                    }
                    else if (enemyState == EnemyStateVariant2)
                    {
                        playerHealth -= enemySlimeStrenth;
                        Console.WriteLine("Враг швыряет в вас слизью, вы теряете " + enemySlimeStrenth + "hp");
                    }
                    else if (enemyState == EnemyStateVariant3)
                    {
                        playerHealth -= enemyBoneStrenth;
                        Console.WriteLine("Враг аттакует вас костью, вы теряете " + enemyBoneStrenth + "hp");
                    }

                    randomNumber = random.Next(minValue, maxValue + 1);

                    if (randomNumber == 1)
                    {
                        enemyState = EnemyStateVariant1;
                    }
                    else if (randomNumber == 2)
                    {
                        enemyState = EnemyStateVariant2;
                    }
                    else if (randomNumber == 3)
                    {
                        enemyState = EnemyStateVariant3;
                    }
                }

                if(playerHealth <= 0 && enemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Убив слизь, вы погибли");
                    Console.ReadKey();
                    break;
                }
                else if(playerHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы обрели вечный покой");
                    Console.ReadKey();
                    break;
                }
                else if (enemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы одержали победу! Впереди вас ждет долгий путь");
                    Console.ReadKey();
                    break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
 