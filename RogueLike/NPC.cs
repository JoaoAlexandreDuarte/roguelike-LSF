using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    /// <summary>
    /// Creates an NPC
    /// </summary>
    class NPC : IHasHp {
        // Receves a premade Random Speed
        Random rnd;

        // Set total max Hp and max AttackPower
        private readonly float maxHp = 100;
        private readonly float maxAp = 100;

        // Set a base level for Hp and Ap
        private readonly float baseVal = 5;
        private readonly float ApMultiplier = 0.3f;
        private readonly float HpMultiplier = 0.4f;

        // Set Hostile Chance multiplier, max chance
        private readonly float multiplier = 0.02f;
        private readonly float maxChance = 0.8f;

        // Set hostile Change
        private float hostileChance;

        // Set max Hp and Attack Power for this level
        private float maxHpFtl;
        private float maxApFtl;

        /// <summary>
        /// NPC Hp, Attack Power and Type
        /// </summary>
        public float Hp { get; set; }
        public float AttackPower { get; set; }
        public NPCType Type { get; set; }

        /// <summary>
        /// Constructs a new NPC
        /// </summary>
        /// <param name="level">Current level</param>
        /// <param name="rnd">Preveosly generated Random Seed</param>
        public NPC(int level, Random rnd) {
            this.rnd = rnd;
            maxHpFtl = baseVal * (level * HpMultiplier);
            maxApFtl = baseVal * (level * ApMultiplier);
            Randomize(level);
        }

        /// <summary>
        /// Randomizes all the NPC Values
        /// </summary>
        /// <param name="level">Current Level</param>
        private void Randomize(int level) {
            // Randomize Hp and reset it to it's max Value in case it surpasses it
            Hp = (float)rnd.NextDouble() * maxHpFtl;
            if (Hp > maxHp) Hp = maxHp;
            // Randomize AttackPower and reset it to it's max Value in case it surpasses it
            AttackPower = maxApFtl;
            if (AttackPower > maxAp) AttackPower = maxAp;

            // Randomize the Hostile chance and reset it to it's max value in case it surpasses it
            hostileChance = level * multiplier;
            if (hostileChance > maxChance) hostileChance = maxChance;

            // Give the NPC a type based on a random chance
            Type = rnd.NextDouble() < hostileChance ? NPCType.Hostile : NPCType.Neutral;
        }

        public override string ToString() {
            string returnNPC;
            if (Type == NPCType.Neutral) {
                returnNPC = "NPC (Neutral)";
            } else {
                returnNPC = string.Format("NPC (Hostile, Hp={0:f2}, Ap={1:f2})", Hp, AttackPower);
            }
            return returnNPC;
        }
    }
}
