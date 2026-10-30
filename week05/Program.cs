// DGD721 - Week 5 Practice Sheet

// ===== Part A =====
// A1: 5        (11 / 4 = 2, 11 % 4 = 3 -> 2 + 3)
// A2: Hurt     (45 is not > 50, but 45 > 20)
// A3: 4        (i=1: -1, i=2: +2, i=3: -1, i=4: +4 -> -1 + 2 - 1 + 4)
// A4: 14       (Twice(3) = 6, Twice(6 + 1) = 14)

// ===== B1 =====
{
    int baseDamage = 40;
    int armor = 15;
    int level = 4;
    PrintDamage(baseDamage, armor, level);

    // test with level = 6
    PrintDamage(baseDamage, armor, 6);

    // test with armor = 50
    PrintDamage(baseDamage, 50, level);
}

// ===== B2 =====
{
    int gold = 120;
    int choice = 2;

    string item = "";
    int price = 0;

    switch (choice)
    {
        case 1:
            item = "Sword";
            price = 100;
            break;
        case 2:
            item = "Bow";
            price = 80;
            break;
        case 3:
            item = "Potion";
            price = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if (item != "")
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {item}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"Not enough gold! You need {price - gold} more gold.");
        }
    }
}

// ===== B3 =====
{
    for (int wave = 1; wave <= 30; wave++)
    {
        string monster;

        // check 3 and 5 together first, otherwise 15 would be "Slime"
        if (wave % 3 == 0 && wave % 5 == 0) monster = "BOSS";
        else if (wave % 3 == 0) monster = "Slime";
        else if (wave % 5 == 0) monster = "Bat";
        else monster = "empty";

        Console.WriteLine($"Wave {wave}: {monster}");
    }
}

// ===== B4 =====
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level < 5)
    {
        fights++;
        xp += 35;

        if (xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }

    Console.WriteLine($"Reached level {level} after {fights} fights (xp left: {xp})");
}

// ===== B5 =====
{
    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = Clamp(hp + 50, 0, 100);
    Console.WriteLine($"HP after potion: {hp}");
}

// ===== B6 =====
{
    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}

// ===== B7 =====
{
    int playerHp = 150;
    int playerDamage = 25;
    int bossHp = 120;
    int bossDamage = 25;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        // player attacks first
        bossHp = Attack(bossHp, playerDamage);
        if (!IsAlive(bossHp))
        {
            Console.WriteLine($"Turn {turn} | Boss: {bossHp}");
            break;
        }

        // every 3rd turn the boss hits for double damage
        int damage = bossDamage;
        if (turn % 3 == 0) damage = bossDamage * 2;
        playerHp = Attack(playerHp, damage);

        Console.WriteLine($"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
    }

    if (IsAlive(playerHp))
        Console.WriteLine($"You win in {turn} turns! HP left: {playerHp}");
    else
        Console.WriteLine($"You lose in {turn} turns! Boss HP left: {bossHp}");
}

// ===== B8 =====
{
    int secret = new Random().Next(1, 101); // bonus: random secret (was 42)
    int tries = 5;
    int used = 0;
    bool found = false;

    while (tries > 0 && !found)
    {
        Console.Write($"Guess ({tries} tries left): ");
        int guess = int.Parse(Console.ReadLine());
        tries--;
        used++;

        string hint = Hint(guess, secret);
        Console.WriteLine(hint);

        if (hint == "Correct!") found = true;
    }

    if (found)
        Console.WriteLine($"You found it in {used} tries!");
    else
        Console.WriteLine($"No tries left! The number was {secret}.");
}

// ===== Methods =====

void PrintDamage(int baseDamage, int armor, int level)
{
    int damage = baseDamage - armor;
    if (level >= 5) damage += 10;
    if (damage < 1) damage = 1;

    string label;
    if (damage >= 30) label = "Strong hit";
    else if (damage >= 10) label = "Normal hit";
    else label = "Weak hit";

    Console.WriteLine($"Damage: {damage} ({label})");
}

int Clamp(int value, int min, int max)
{
    if (value < min) return min;
    if (value > max) return max;
    return value;
}

string GetRank(int score)
{
    if (score >= 1000) return "Gold";
    if (score >= 500) return "Silver";
    if (score >= 1) return "Bronze";
    return "No medal";
}

int Attack(int hp, int damage)
{
    hp -= damage;
    if (hp < 0) hp = 0;
    return hp;
}

bool IsAlive(int hp)
{
    return hp > 0;
}

string Hint(int guess, int secret)
{
    if (guess < secret) return "Too low";
    if (guess > secret) return "Too high";
    return "Correct!";
}
