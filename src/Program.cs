using CreatureWars.Class;
using CreatureWars.Formulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreatureWars
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConsoleAnnouncer announcer = new ConsoleAnnouncer();
            // using (GameContext context = new GameContext())
            // {
            //     Game game = Game.Init(announcer, context);
            // }

            // GlobalTimer.Go();

            // new FixturesDeserializer();

            // //Создание прототипа модификатора
            // ModifierPrototype forestGood = new ModifierPrototype("Лесное благославнление", "Леса будут с тобой!!!!!");
            // ModifierPrototype overPowered = new ModifierPrototype("Мощь переполняет", "Леса будут с тобой!!!!!");

            // AbilityPrototype fireball = new AbilityPrototype("Огненный шар", "Мощное огненное заклинание");
            // ModifierPrototype instantDamage = new ModifierPrototype("Урон от огненного шара", "");
            // instantDamage.Damage = 10;
            // instantDamage.PossibleTargets = PossibleTargets.Target;
            // ModifierPrototype periodicalDamage = new ModifierPrototype("Периодический урон от огненного шара", "");
            // periodicalDamage.Damage = 2;
            // periodicalDamage.Duration = 10;
            // periodicalDamage.PossibleTargets = PossibleTargets.Target;
            // fireball.ModifierPrototypes.Add(instantDamage);
            // fireball.ModifierPrototypes.Add(periodicalDamage);


            // forestGood.Duration = 2;
            // forestGood.Attributes.Str = 5;

            // overPowered.Attributes.Str = 200;
            // //

            // //Создание прототипа
            // CreaturePrototype creaturePrototype = (new FixturesDeserializer()).Deserialize()[0];
            // CreaturePrototype creaturePrototype2 = (new FixturesDeserializer()).Deserialize()[1];
            // // creaturePrototype.Name = "Рядовой Сосон";
            // // creaturePrototype.Attributes = new Attributes(3, 5, 3, 3);
            // // creaturePrototype.Modifiers.Add(forestGood);
            // //

            // //Создание экземпляров Сосонов
            // var c1 = creaturePrototype.CreateInstance(new MeleeHitHandler());
            // // c1.Name += " хитрый";
            // var c2 = creaturePrototype2.CreateInstance(new MeleeHitHandler());
            // c2.ApplyModifier(forestGood.CreateInstance());
            // // c2.ApplyModifier(overPowered.CreateInstance());
            // c2.Abilities.Add(fireball.CreateInstance());

            // //Бой сосонов
            // TimerCallback fight = new TimerCallback((object state) =>
            // {
            //     // c1.HitCreatureMelee(c2);
            //     // c2.HitCreatureMelee(c1);
            // });

            // c2.CastAbility(c1, c2.Abilities.First());

            // Timer timer = new Timer(fight, null, 0, 200);
        }
    }
}
