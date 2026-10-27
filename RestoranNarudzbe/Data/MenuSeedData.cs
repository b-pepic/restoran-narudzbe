using RestoranNarudzbe.Models;

namespace RestoranNarudzbe.Data;

// Jelovnik Bistro Attica (Pag). Žestoka pića i rakije su porcije od 0,03 l.
public static class MenuSeedData
{
    private const string Appetizers = "Predjela";
    private const string Soups = "Juhe";
    private const string VegetarianDishes = "Vegetarijanska jela";
    private const string PastaAndRisotto = "Tjestenina i rižoto";
    private const string Fish = "Riba";
    private const string Grill = "Jela s roštilja";
    private const string Pizza = "Pizza";
    private const string Salads = "Salate";
    private const string Sauces = "Umaci";
    private const string SideDishes = "Dodaci";
    private const string Desserts = "Deserti";
    private const string HotDrinks = "Topli napitci";
    private const string Water = "Voda";
    private const string SoftDrinks = "Gazirana pića";
    private const string Juices = "Prirodni sokovi";
    private const string Beer = "Pivo";
    private const string Cider = "Cider";
    private const string AperitifsAndCocktails = "Aperitivi i kokteli";
    private const string Brandy = "Rakije";
    private const string Liqueurs = "Likeri";
    private const string Spirits = "Žestoka pića";

    public static List<MenuItem> GetMenuItems()
    {
        return new List<MenuItem>
        {
            // Predjela
            Item("Carpaccio od bifteka", 17.00m, Appetizers),
            Item("Dalmatinski pršut (100 g)", 11.00m, Appetizers),
            Item("Paški sir (100 g)", 14.00m, Appetizers),
            Item("Kravlji sir (100 g)", 9.80m, Appetizers),
            Item("Kozji sir (100 g)", 11.80m, Appetizers),
            Item("Miješani sir (100 g)", 11.80m, Appetizers),
            Item("Marinirane masline", 6.60m, Appetizers),
            Item("Bruschetta s pršutom", 8.80m, Appetizers),
            Item("Bruschetta s rajčicom", 7.50m, Appetizers),
            Item("Dalmatinski pjat", 19.50m, Appetizers),
            Item("Hladna plata Attica (300 g)", 29.00m, Appetizers),
            Item("Plata sireva (300 g)", 29.00m, Appetizers),

            // Juhe
            Item("Dnevna juha", 6.00m, Soups),
            Item("Riblja juha", 6.00m, Soups),
            Item("Juha od rajčice", 6.00m, Soups),

            // Vegetarijanska jela
            Item("Pohani sir s pommesom", 10.90m, VegetarianDishes),
            Item("Proljetne rolice s pommesom", 9.80m, VegetarianDishes),
            Item("Pohani patlidžan s mladim krumpirom", 9.80m, VegetarianDishes),
            Item("Penne s povrćem", 10.90m, VegetarianDishes),
            Item("Vegetarijanski rižoto", 14.50m, VegetarianDishes),

            // Tjestenina i rižoto
            Item("Spaghetti aglio e olio", 11.00m, PastaAndRisotto),
            Item("Spaghetti bolognese", 12.80m, PastaAndRisotto),
            Item("Spaghetti carbonara", 13.00m, PastaAndRisotto),
            Item("Penne 4 vrste sira", 13.00m, PastaAndRisotto),
            Item("Penne s piletinom i gljivama", 14.70m, PastaAndRisotto),
            Item("Spaghetti frutti di mare", 15.50m, PastaAndRisotto),
            Item("Tagliatelle s kozicama", 16.70m, PastaAndRisotto),
            Item("Tagliatelle s pršutom i tartufima", 18.00m, PastaAndRisotto),
            Item("Rižoto s piletinom i vrganjima", 18.80m, PastaAndRisotto),
            Item("Rižoto s biftekom", 19.50m, PastaAndRisotto),
            Item("Rižoto plodovi mora", 18.00m, PastaAndRisotto),

            // Riba
            Item("Oborita riba (1 kg)", 85.00m, Fish),
            Item("Brancin/orada s blitvom i krumpirom (400 g)", 20.80m, Fish),
            Item("File brancina s mladim krumpirom (300 g)", 21.50m, Fish),
            Item("Tuna steak s blitvom i krumpirom (300 g)", 22.80m, Fish),
            Item("Lignje na žaru s blitvom i krumpirom (300 g)", 23.00m, Fish),
            Item("Pržene lignje s pommesom (300 g)", 20.90m, Fish),
            Item("Fritto misto s pommesom (250 g)", 19.90m, Fish),
            Item("Kozice u tempuri s pommesom", 20.50m, Fish),
            Item("Prženi gavuni s pommesom (300 g)", 13.80m, Fish),
            Item("Škampi na žaru (500 g)", 36.00m, Fish),
            Item("Škampi na buzaru (500 g)", 36.00m, Fish),
            Item("Dagnje na buzaru (500 g)", 15.00m, Fish),
            Item("Vongole na buzaru (500 g)", 15.00m, Fish),
            Item("Frigana riblja plata za 2 osobe", 33.00m, Fish),
            Item("Riblja plata za 2 osobe", 58.00m, Fish),

            // Jela s roštilja
            Item("Ćevapi u somunu (300 g)", 13.90m, Grill),
            Item("Ćevapi s pommesom (300 g)", 13.20m, Grill),
            Item("Punjena pljeskavica s pommesom (300 g)", 14.50m, Grill),
            Item("Punjena vješalica s mladim krumpirom (300 g)", 17.00m, Grill),
            Item("Pileći batak/zabatak bez kosti s mladim krumpirom (300 g)", 13.50m, Grill),
            Item("Lungić tagliata u umaku od vrganja s mladim krumpirom (300 g)", 18.90m, Grill),
            Item("Pileći file na žaru s pommesom (300 g)", 13.80m, Grill),
            Item("Pileći file s njokima u umaku od gorgonzole (300 g)", 16.80m, Grill),
            Item("Biftek na žaru s mladim krumpirom (250 g)", 35.00m, Grill),
            Item("Teleći vrat s mladim krumpirom (300 g)", 25.50m, Grill),
            Item("Ramsteka tagliata s povrćem na žaru i paškim sirom (250 g)", 28.50m, Grill),
            Item("Svinjski medaljoni u umaku od gljiva s rižom (300 g)", 17.50m, Grill),
            Item("Ramstek u umaku od crnog vina s mladim krumpirom (250 g)", 26.00m, Grill),
            Item("Mesni uštipci sa sirom u somunu (300 g)", 14.50m, Grill),
            Item("T-bone steak s mladim krumpirom i povrćem sa žara (650 g)", 47.00m, Grill),
            Item("Grill plata za dvije osobe", 42.00m, Grill),
            Item("Plata Attica za dvije osobe", 59.00m, Grill),

            // Pizza
            Item("Margherita", 11.50m, Pizza),
            Item("Vesuvio", 12.00m, Pizza),
            Item("Capricciosa", 12.90m, Pizza),
            Item("Slavonska", 13.80m, Pizza),
            Item("Salami", 12.20m, Pizza),
            Item("Quattro formaggi", 13.40m, Pizza),
            Item("Bianco", 13.00m, Pizza),
            Item("Vegetariana", 13.00m, Pizza),
            Item("Funghi", 12.00m, Pizza),
            Item("Frutti di mare", 14.80m, Pizza),
            Item("Dalmatinska", 15.20m, Pizza),
            Item("Tuna", 14.60m, Pizza),
            Item("Mexicana", 14.70m, Pizza),
            Item("Paška", 15.80m, Pizza),

            // Salate
            Item("Miješana salata", 5.20m, Salads),
            Item("Šopska salata", 6.00m, Salads),
            Item("Zelena salata", 5.00m, Salads),
            Item("Rajčica", 5.00m, Salads),
            Item("Kupus", 5.00m, Salads),
            Item("Krastavac s vrhnjem", 6.50m, Salads),
            Item("Caprese", 6.80m, Salads),
            Item("Cezar salata", 12.50m, Salads),
            Item("Tuna salata", 11.50m, Salads),
            Item("Biftek salata", 15.50m, Salads),
            Item("Vegan salata", 9.80m, Salads),

            // Umaci
            Item("Umak od zelenog papra", 5.50m, Sauces),
            Item("Umak 4 vrste sira", 5.50m, Sauces),
            Item("Umak od gorgonzole", 5.50m, Sauces),
            Item("Umak od gljiva", 5.50m, Sauces),
            Item("Umak od vrganja", 5.50m, Sauces),
            Item("Umak od crnog vina", 5.50m, Sauces),

            // Dodaci
            Item("Pizza kruh", 2.80m, SideDishes),
            Item("Somun", 3.00m, SideDishes),
            Item("Pommes", 5.00m, SideDishes),
            Item("Đuveč riža", 5.80m, SideDishes),
            Item("Mladi krumpir", 5.80m, SideDishes),
            Item("Povrće na žaru", 9.50m, SideDishes),
            Item("Gljive na žaru", 8.50m, SideDishes),
            Item("Blitva s krumpirom", 5.80m, SideDishes),

            // Deserti
            Item("Lava cake", 6.80m, Desserts),
            Item("Palačinke s marmeladom", 5.20m, Desserts),
            Item("Palačinke s nutelom", 5.70m, Desserts),
            Item("Palačinke sa sladoledom", 5.70m, Desserts),
            Item("Dnevni kolač", 6.50m, Desserts),
            Item("Kugla sladoleda", 2.80m, Desserts),

            // Topli napitci
            Item("Espresso", 2.20m, HotDrinks),
            Item("Macchiato mali", 2.40m, HotDrinks),
            Item("Macchiato veliki", 2.50m, HotDrinks),
            Item("Kava sa šlagom", 2.70m, HotDrinks),
            Item("Bijela kava", 2.80m, HotDrinks),
            Item("Kava bez kofeina", 2.90m, HotDrinks),
            Item("Cappuccino", 2.80m, HotDrinks),
            Item("Nescafe", 2.90m, HotDrinks),
            Item("Kakao", 2.90m, HotDrinks),
            Item("Čaj", 2.70m, HotDrinks),

            // Voda
            Item("Gazirana voda (1 l)", 5.50m, Water),
            Item("Gazirana voda (0,33 l)", 3.20m, Water),
            Item("Prirodna voda (1 l)", 5.50m, Water),
            Item("Prirodna voda (0,33 l)", 3.00m, Water),

            // Gazirana pića
            Item("Pepsi", 4.00m, SoftDrinks),
            Item("Seven Up", 4.00m, SoftDrinks),
            Item("Schweppes", 4.00m, SoftDrinks),
            Item("Nara", 4.00m, SoftDrinks),
            Item("Pipi", 4.00m, SoftDrinks),
            Item("Orangina", 4.20m, SoftDrinks),
            Item("Limona", 4.20m, SoftDrinks),
            Item("Cockta", 4.00m, SoftDrinks),
            Item("Ledeni čaj", 4.00m, SoftDrinks),
            Item("Sensation", 3.40m, SoftDrinks),
            Item("Red Bull", 5.40m, SoftDrinks),

            // Prirodni sokovi
            Item("Pago", 4.00m, Juices),
            Item("Svježe cijeđeni sok (0,2 l)", 5.00m, Juices),
            Item("Limunada (0,2 l)", 4.00m, Juices),
            Item("Cedevita", 3.40m, Juices),

            // Pivo
            Item("Pan (0,5 l)", 4.20m, Beer),
            Item("Pan (0,35 l)", 4.00m, Beer),
            Item("Zlatni Pan (0,5 l)", 4.20m, Beer),
            Item("Tamni Pan (0,5 l)", 4.40m, Beer),
            Item("Bezalkoholni Pan (0,5 l)", 4.40m, Beer),
            Item("Pan Radler (0,5 l)", 4.40m, Beer),
            Item("Tuborg (0,33 l)", 4.30m, Beer),
            Item("Budweiser (0,33 l)", 4.50m, Beer),
            Item("Corona (0,33 l)", 5.30m, Beer),
            Item("Heineken (0,25 l)", 4.60m, Beer),
            Item("Točeno pivo (0,5 l)", 4.30m, Beer),
            Item("Točeno pivo (0,3 l)", 3.50m, Beer),

            // Cider
            Item("Somersby (0,33 l)", 5.30m, Cider),

            // Aperitivi i kokteli
            Item("Aperol Spritz", 8.50m, AperitifsAndCocktails),
            Item("Hugo Spritz", 8.50m, AperitifsAndCocktails),
            Item("Martini (0,1 l)", 6.50m, AperitifsAndCocktails),

            // Rakije
            Item("Šljivovica", 3.00m, Brandy),
            Item("Travarica", 3.00m, Brandy),
            Item("Medica", 3.00m, Brandy),
            Item("Viljamovka", 4.20m, Brandy),
            Item("Marelica", 4.20m, Brandy),
            Item("Dunja", 4.20m, Brandy),

            // Likeri
            Item("Amaro", 3.00m, Liqueurs),
            Item("Teranino", 4.00m, Liqueurs),
            Item("Višnjevac", 3.00m, Liqueurs),
            Item("Borovnička", 3.00m, Liqueurs),
            Item("Orahovac", 3.00m, Liqueurs),
            Item("Pelinkovac", 3.00m, Liqueurs),
            Item("Pelinkovac Antique", 3.60m, Liqueurs),
            Item("Jägermeister", 3.60m, Liqueurs),
            Item("Campari", 3.60m, Liqueurs),

            // Žestoka pića
            Item("Martell", 5.50m, Spirits),
            Item("Jack Daniel's", 4.60m, Spirits),
            Item("Johnnie Walker Red Label", 4.60m, Spirits),
            Item("Johnnie Walker Black Label", 5.20m, Spirits),
            Item("Chivas Regal", 5.20m, Spirits),
            Item("Jameson", 5.20m, Spirits),
            Item("Bombay", 4.70m, Spirits),
            Item("Old Pilot's", 5.20m, Spirits),
            Item("Hendrick's", 5.20m, Spirits),
            Item("Bacardi", 4.40m, Spirits),
            Item("Havana", 4.40m, Spirits),
            Item("Malibu", 3.80m, Spirits),
            Item("San Jose Silver", 3.40m, Spirits),
            Item("San Jose Gold", 3.60m, Spirits),
            Item("Svarog", 3.40m, Spirits),
            Item("Grey Goose", 5.20m, Spirits)
        };
    }

    private static MenuItem Item(string name, decimal price, string category)
    {
        return new MenuItem
        {
            Name = name,
            Price = price,
            Category = category
        };
    }
}
