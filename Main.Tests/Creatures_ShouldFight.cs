namespace Main.Tests;
using CreatureWars.Class;
using CreatureWars.Formulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Creatures_ShouldFight
{
    [Fact]
    public void GeneralFight()
    {
        ConsoleAnnouncer announcer = new ConsoleAnnouncer();
        using (GameContext context = new GameContext())
        {
            Game game = Game.Init(announcer, context);
        }

        GlobalTimer.Go();

        var fixtureProcessor = new FixtureProcessor();


        ModifierPrototype instantDamage = new ModifierPrototype("Урон от огненного шара", "");
        instantDamage.Damage = 10;
        instantDamage.PossibleTargets = PossibleTargets.Target;
        ModifierPrototype periodicalDamage = new ModifierPrototype("Периодический урон от огненного шара", "Горииииим аааааа");
        periodicalDamage.Damage = 5;
        periodicalDamage.Duration = 10;
        periodicalDamage.PossibleTargets = PossibleTargets.Target;
        var fireball = fixtureProcessor.Deserialize<AbilityPrototype>("Ability")[0];

        //Создание прототипа
        CreaturePrototype creaturePrototype = fixtureProcessor.Deserialize<CreaturePrototype>("Creature")[0];
        creaturePrototype.ItemTypes = fixtureProcessor.Deserialize<ItemType>("ItemType");
        CreaturePrototype creaturePrototype2 = fixtureProcessor.Deserialize<CreaturePrototype>("Creature")[1];
        // creaturePrototype.Name = "Рядовой Сосон";
        // creaturePrototype.Attributes = new Attributes(3, 5, 3, 3);
        // creaturePrototype.Modifiers.Add(forestGood);
        //

        creaturePrototype2.Abilities.Add(fireball);
        //Создание экземпляров Сосонов
        var c1 = creaturePrototype.CreateInstance(new MeleeHitHandler());
        // c1.Name += " хитрый";
        var c2 = creaturePrototype2.CreateInstance(new MeleeHitHandler());

        //Бой сосонов
        TimerCallback fight = new TimerCallback((object state) =>
        {
            c1.HitCreatureMelee(c2);
            c2.HitCreatureMelee(c1);
        });

        c2.CastAbility(c1, c2.Abilities.First());

        var Item = new Item();
        Item.Name = "Холщевый сверток";
        Item.Description = "Аттрибут бедных коконов";
        Item.ProgramName = "holsheviy_svertok";
        Item.Attributes = new Attributes(0, 0, 0, 0);
        var svertokModifier = new Modifier("Покров бедности", "БЕЕЕЕДНЫЫЫЫЫЙ КОКОН!");
        svertokModifier.Attributes = new Attributes(1, 1, 1, 1);
        svertokModifier.Heal = 7;
        svertokModifier.Duration = int.MaxValue;

        Item.Modifiers = new List<Modifier> { svertokModifier };

        c2.WearItem(Item);


        Timer timer = new Timer(fight, null, 0, 200);
        Console.ReadKey();
    }
}