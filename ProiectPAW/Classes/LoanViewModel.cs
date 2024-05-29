using ProiectPAW.Classes;
using ProiectPAW.Data;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;

public class LoanViewModel : INotifyPropertyChanged
{
    internal LoanContext context;

    public BindingList<LoanViewModelItem> Loans { get; set; }
    private LoanViewModelItem selectedLoan;
    public LoanViewModelItem SelectedLoan
    {
        get => this.selectedLoan;
        set
        {
            this.selectedLoan = value;
            this.OnPropertyChanged(nameof(this.SelectedLoan));
        }
    }

    public BindingList<Client> Clients { get; set; }

    public LoanViewModel()
    {
        context = new LoanContext();
        Loans = new BindingList<LoanViewModelItem>(); // Initialize Loans with an empty list
        this.LoadClients();
        this.LoadLoans();
        this.SelectedLoan = new LoanViewModelItem(); // Ensure SelectedLoan is initialized
    }

    public void LoadLoans()
    {
        var loans = this.context.Loans.Include(l => l.Client).ToList();
        this.Loans = new BindingList<LoanViewModelItem>(loans.Select(l => new LoanViewModelItem
        {
            LoanId = l.LoanId,
            Amount = l.Amount,
            InterestRate = l.InterestRate,
            DurationMonths = l.DurationMonths,
            ClientName = l.Client?.Name ?? string.Empty,
            ClientId = l.ClientId
        }).ToList());

        if (this.Loans.Count == 0)
        {
            this.Loans = new BindingList<LoanViewModelItem>();
        }
    }

    public void LoadClients()
    {
        var clients = this.context.Clients.OrderBy(c => c.Name).ToList();
        this.Clients = new BindingList<Client>(clients);

        if (this.Clients.Count == 0)
        {
            this.Clients = new BindingList<Client>();
        }
    }

    public void AddLoan(Loan loan)
    {
        this.context.Loans.Add(loan);
        this.context.SaveChanges();
        this.LoadLoans();
    }

    public void UpdateLoan(Loan loan)
    {
        var existingLoan = this.context.Loans.Find(loan.LoanId);
        if (existingLoan != null)
        {
            this.context.Entry(existingLoan).CurrentValues.SetValues(loan);
            this.context.SaveChanges();
            this.LoadLoans();
        }
    }

    public void DeleteLoan(Loan loan)
    {
        var existingLoan = this.context.Loans.Find(loan.LoanId);
        if (existingLoan != null)
        {
            this.context.Loans.Remove(existingLoan);
            this.context.SaveChanges();
            this.LoadLoans();
        }
        else
        {
            throw new InvalidOperationException("The loan to be deleted was not found.");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class LoanViewModelItem
{
    public int LoanId { get; set; }
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public int DurationMonths { get; set; }
    public string ClientName { get; set; }
    public int ClientId { get; set; }
}
