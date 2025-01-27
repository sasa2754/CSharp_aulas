public class EUADismissalProcess : DismissalProcess {
    public override string Title => "Dismissal of Employees";
    public override void Apply(DismissalArgs args) {
        args.Company.Money -= 3 * args.Employe.Wage;
    }
}

public class EUAWagePaymentProcess : WagePaymentProcess {
    public override string Title => "Salary payment";
    public override void Apply(WagePaymentArgs args) {
        args.Company.Money -= 1.65m * args.Employe.Wage + 700;
    }
}

public class EUAHiringProcess : Hiringprocess
{
    public override string Title => "Hiring employees";

    public override void Apply(HiringArgs args) {
        // Console.WriteLine("Welcome!");
    }
}

public class EUAProcessFactory : IProcessFactory {
    public DismissalProcess CreateDismissalProcess()
        => new EUADismissalProcess();

    public Hiringprocess CreateHiringProcess()
        => new EUAHiringProcess();

    public WagePaymentProcess CreateWagePaymentProcess()
        => new EUAWagePaymentProcess();
}