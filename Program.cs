using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonest_dark
{
    class Program
    {
        static void Main(string[] args)
        {
            var rooms = Console.ReadLine()
                .Split('|')
                .ToList();
            var health = 100;
            var oldHealth = 0;
            var coins = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                var room = rooms[i].Split().ToList();
                if (room[0]=="potion")
                {
                    var potion = int.Parse(room[1]);
                    if (health + potion <= 100)
                    {
                        oldHealth = health;
                        health += potion;
                    }
                    else
                    {
                        oldHealth = health;
                        health = 100;
                    }
                    Console.WriteLine("You healed for {0} hp."
                        ,health-oldHealth );
                    Console.WriteLine("Current health: {0} hp."
                        ,health);

                }
                 else if (room[0]=="chest")
                {
                    var chest = int.Parse(room[1]);
                    coins += chest;
                    Console.WriteLine("You found {0} coins.",chest);
                }
                else
                {
                    var monstername = room[0];
                    var monster = int.Parse(room[1]);
                    health -= monster;
                    if (health<=0)
                    {
                        Console.WriteLine("You died! Killed by {0}."
                            ,monstername);
                        Console.WriteLine("Best room: {0}",i+1);
                        break;
                    }
                    Console.WriteLine("You slayed {0}."
                        ,monstername);
                }


            }
            if (health>0)
            {
                 Console.WriteLine("You've made it!");
                 Console.WriteLine("Coins: {0}",coins);
                 Console.WriteLine("Health: {0}",health);
            }
                 

            

        }
    }
}

