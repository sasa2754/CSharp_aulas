var builder = Company.GetBuilder();

builder
    .SetName("Mercado Libre")
    .InArgentina()
    .SetInitialCapital(20_000_000);

builder
    .AddEmploye("Marquitos Guapo", 50_000)
    .AddEmploye("Paulito Pino", 20_000);
Company.New(builder);

Console.WriteLine(Company.Current.Name);

// foreach (var item in Company.Current.Employes){
//     Console.WriteLine($"{item.Name} - {item.Wage}");
    
// }


// Me rendí, me voy a Brasil
builder = Company.GetBuilder();
builder
    .SetName("Ambev")
    .InBrazil()
    .SetInitialCapital(1_000_000);

builder
    .AddEmploye("Marcos Bonito", 2_500)
    .AddEmploye("Paulo Pinheiro", 1_000);

Company.New(builder);
Employe employe = new Employe();
employe.Name = "Xispita";
employe.Wage = 2_000;
Company.Current.Contract(employe);
Company.Current.Dismiss("Marcos Bonito");
Company.Current.PayWages();

Console.WriteLine(Company.Current.Name);


// I gave up, I'm going to the USA
builder = Company.GetBuilder();
builder
    .SetName("Microsoft")
    .InEUA()
    .SetInitialCapital(25_000);

builder
    .AddEmploye("Billie Bob", 25)
    .AddEmploye("Richard Cox", 100)
    .AddEmploye("James Michael", 20);

Company.New(builder);

Console.WriteLine(Company.Current.Name);
