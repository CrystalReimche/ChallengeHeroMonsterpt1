using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonster
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creating hero 
            Character hero = new Character();
            hero.Name = "Xena: The Warrior Princess";
            hero.Health = 100;
            hero.DamageMaximum = 20;
            hero.AttackBonus = false;

            // Creating Monster
            Character monster = new Character();
            monster.Name = "The Cyclops";
            monster.Health = 100;
            monster.DamageMaximum = 20;
            monster.AttackBonus = true;

            int dmg = hero.Attack();    // Hero is calling Attack helper method to generate a random number that it attacks with
            monster.Defend(dmg);    // Monster is calling Defend helper method to subtract monster health after hero attack with dmg

            dmg = monster.Attack();
            hero.Defend(dmg);

            printStats(hero);
            printStats(monster);
        }

        private void printStats(Character character)
        {
            rLabel.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}<p>", 
                character.Name, 
                character.Health, 
                character.DamageMaximum.ToString(), 
                character.AttackBonus.ToString());
        }

    }

    public class Character
    {
        // Creating Character object properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        // Attack Method
        public int Attack()
        {
            Random rnd = new Random();
            int dmg = rnd.Next(this.DamageMaximum + 1);    // This is generating a random number up to the maximum that was set in line 18 & 25
            return dmg;
        }

        // Defend Method
        public void Defend(int dmg) // This isn't public int because it's not returning any value, it's only doing a calculation
        {
            this.Health -= dmg;
        }

        
    }
}