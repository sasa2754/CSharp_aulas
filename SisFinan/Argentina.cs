public class ArgentinaDismissalProcess : DismissalProcess {
    public override string Title => "Despido de Empleados";
    public override void Apply(DismissalArgs args) {
        args.Company.Money -= 3 * args.Employe.Wage;
    }
}

public class ArgentinaWagePaymentProcess : WagePaymentProcess {
    public override string Title => "Pago de salario";
    public override void Apply(WagePaymentArgs args) {
        args.Company.Money -= 1.65m * args.Employe.Wage + 700;
    }
}

public class ArgentinaHiringProcess : Hiringprocess
{
    public override string Title => "Contratación de empleados";

    public override void Apply(HiringArgs args) {
        // Console.WriteLine("Bienvenido!");
    }
}

public class ArgentinaProcessFactory : IProcessFactory {
    public DismissalProcess CreateDismissalProcess()
        => new ArgentinaDismissalProcess();

    public Hiringprocess CreateHiringProcess()
        => new ArgentinaHiringProcess();

    public WagePaymentProcess CreateWagePaymentProcess()
        => new ArgentinaWagePaymentProcess();
}