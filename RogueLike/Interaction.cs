using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    /// <summary>
    /// Responsible for all Interactions the player has
    /// </summary>
    class Interaction {
        // Pre Generated Random seed
        Random rnd;

        /// <summary>
        /// Interaction Objects
        /// </summary>
        private World myWorld;
        private Player myPlayer;
        private Draw myDrawing;
        private Generator myGenerator;

        /// <summary>
        /// Constructor for Interaction takes in 3 arguments
        /// </summary>
        /// <param name="player">My Player</param>
        /// <param name="world">My World</param>
        /// <param name="draw">My Drawing</param>
        public Interaction(Player player, World world, Draw draw, Generator generator, Random rnd) {
            this.rnd = rnd;
            myWorld = world;
            myPlayer = player;
            myDrawing = draw;
            myGenerator = generator;
        }

        /// <summary>
        /// Pick up items from the ground
        /// </summary>
        public void PickItems() {
            int i = 1;
            string input;
            IStuff[] myi = new IStuff[10];

            // Draw Header
            myDrawing.ItemInteraction("PickUp");

            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is IStuff) {
                    myi[i] = (obj as IStuff);
                    Console.WriteLine(i + " " + obj);
                    i++;
                } else if (obj is Map) {
                    myGenerator.myMap.UseMap(myWorld);
                    myWorld.myTiles[myPlayer.y, myPlayer.x].Remove(obj);
                    return;
                }
            }
            if (myi[1] != null) {
                input = Console.ReadLine();
                for (i = 0; i < myi.Length; i++) {
                    if (myi[i] != null && input == Convert.ToString(i)) {
                        if (((myPlayer.myInventory.Weight + myi[i].Weight) / myPlayer.Weight) <= 1) {
                            myWorld.myTiles[myPlayer.y, myPlayer.x].Remove(myi[i]);
                            myPlayer.myInventory.Add(myi[i]);
                        } else {
                            Console.WriteLine("Not enough Space!");
                            Console.ReadKey();
                        }
                    }
                }
                NpcChecker();
            }
        }

        public void DropItems() {
            int i = 1;
            string input;
            IStuff[] myi = new IStuff[myPlayer.myInventory.Count() + 1];

            // Draw Header
            myDrawing.ItemInteraction("Drop");

            foreach (IStuff stuff in myPlayer.myInventory) {
                myi[i] = stuff;
                Console.WriteLine(i + " " + stuff);
                i++;
            }

            if (myi.Length > 1) {
                input = Console.ReadLine();
                for (i = 0; i < myi.Length; i++) {
                    if (myi[i] != null && input == Convert.ToString(i)) {
                        myWorld.myTiles[myPlayer.y, myPlayer.x].Insert(0, myi[i]);
                        myPlayer.myInventory.Remove(myi[i]);
                    }
                }
                NpcChecker();
            }
        }

        public void UseItems() {
            int i = 1;
            string input;

            /* Create a new IStuff array with the size of the player 
             * inventory plus what he has equiped */
            IStuff[] myi = new IStuff[myPlayer.myInventory.Count() + 1];

            // DrawHeader
            myDrawing.ItemInteraction("Use");

            foreach (IStuff stuff in myPlayer.myInventory) {
                myi[i] = stuff;
                Console.WriteLine(i + " " + stuff);
                i++;
            }
            if (myi.Length > 1) {
                input = Console.ReadLine();
                for (i = 1; i < myi.Length; i++) {
                    if (myi[i] != null && input == Convert.ToString(i)) {
                        if (myi[i] is Food && myPlayer.Hp < 100) {
                            myPlayer.Hp += (myi[i] as Food).Heal;
                            myPlayer.myInventory.Remove(myi[i]);
                            if (myPlayer.Hp > 100) {
                                myPlayer.Hp = 100;
                            }
                        } else if (myi[i] is Weapon) {
                            if (myPlayer.equiptSlot != null) {
                                myPlayer.myInventory.Add(myPlayer.equiptSlot);
                            }
                            myPlayer.equiptSlot = (myi[i] as Weapon);
                            myPlayer.myInventory.Remove(myi[i]);
                        }
                    }
                }
                NpcChecker();
            }
        }

        /// <summary>
        /// Checks the tile list for traps that damage the player
        /// </summary>
        public void TrapChecker() {
            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is Trap) {
                    if (!(obj as Trap).FallenInto) {
                        // Get Random Damage
                        float myDamage = (float)(rnd.NextDouble() *
                            myWorld.myTiles[myPlayer.y, myPlayer.x].GetObjects<Trap>().Damage);

                        (obj as Trap).FallenInto = true;
                        // Take random damage from the trap
                        myPlayer.Hp -= myDamage;

                        // Update Last Interaction
                        myPlayer.LastInteraction = string.Format("You fell in a trap and lost " +
                            "{0:f2} Hp.", myDamage);
                    }
                }
            }
        }

        public void NpcChecker() {
            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is NPC) {
                    if ((obj as NPC).Type == NPCType.Hostile) {
                        // Give Damage to the Player
                        myPlayer.Hp -= (
                            myWorld.myTiles[myPlayer.y, myPlayer.x].GetObjects<NPC>().AttackPower *
                            (float)rnd.NextDouble());

                        // Update Last Interaction
                        myPlayer.LastInteraction = "You where attack by a hostile NPC and lost " +
                            myWorld.myTiles[myPlayer.y, myPlayer.x].GetObjects<NPC>().AttackPower +
                            "Hp.";
                    }
                }
            }
        }

        public void Fight() {
            int i = 0;
            string input;
            NPC[] myi = new NPC[10];

            // Draw Header
            myDrawing.FightInteraction();

            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is NPC) {
                    if ((obj as NPC).Type == NPCType.Hostile)
                        myi[i] = (obj as NPC);
                    Console.WriteLine(i + " " + obj);
                    i++;
                }
            }
            if (myi[0] != null && (myPlayer.equiptSlot != default(Weapon))) {
                input = Console.ReadLine();
                for (i = 0; i < myi.Length; i++) {
                    if (myi[i] != null && input == Convert.ToString(i)) {
                        // Attack the Npc
                        float myDamage = (float)(rnd.NextDouble() * myPlayer.equiptSlot.AttackPower);
                        myi[i].Hp -= myDamage;

                        // Check NPC's Hp
                        if (myi[i].Hp <= 0) {
                            myWorld.myTiles[myPlayer.y, myPlayer.x].Remove(myi[i]);
                        }

                        // Check if the weapon will break
                        if (rnd.NextDouble() > myPlayer.equiptSlot.Durability) {
                            myPlayer.equiptSlot = default(Weapon);
                        }

                        myPlayer.LastInteraction = "You attacked a NPC, and did: " +
                            myDamage + " Damage";
                    }
                }

            }

            NpcChecker();
        }

        public void Quit() {
            string input;
            Console.Clear();
            Console.Write("Are you sure you want to quit? (y/n)");
            input = Console.ReadLine();
            if (input == "y") {
                myPlayer.Hp = 0;
            } else {
                return;
            }
        }
    }
}
