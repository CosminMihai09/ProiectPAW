using ProiectPAW.Classes;
using ProiectPAW.Data;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

public class LoanViewModel : INotifyPropertyChanged
{
    private LoanContext context;

    public BindingList<LoanViewModelItem> Loans { get; set; }
    private LoanViewModelItem selectedLoan;
    public LoanViewModelItem SelectedLoan
    {
        get => selectedLoan;
        set
        {
            selectedLoan = value;
            OnPropertyChanged(nameof(SelectedLoan));
        }
    }

    public BindingList<Client> Clients { get; set; }

    public LoanViewModel()
    {
        context = new LoanContext();
        LoadLoans();
        LoadClients();
    }

    public void LoadLoans()
    {
        var loans = context.Loans.Include(l => l.Client).ToList();
        Loans = new BindingList<LoanViewModelItem>(loans.Select(l => new LoanViewModelItem
        {
            LoanId = l.LoanId,
            Amount = l.Amount,
            InterestRate = l.InterestRate,
            DurationMonths = l.DurationMonths,
            ClientName = l.Client.Name,
            ClientId = l.ClientId
        }).ToList());
    }

    public void LoadClients()
    {
        var clients = context.Clients.OrderBy(c => c.Name).ToList();
        Clients = new BindingList<Client>(clients);
    }

    public void AddLoan(Loan loan)
    {
        context.Loans.Add(loan);
        context.SaveChanges();
        LoadLoans(); // Reload loans to update the view
    }

    public void UpdateLoan(Loan loan)
    {
        var existingLoan = context.Loans.Find(loan.LoanId);
        if (existingLoan != null)
        {
            context.Entry(existingLoan).CurrentValues.SetValues(loan);
            context.SaveChanges();
            LoadLoans(); // Reload loans to update the view
        }
    }

    public void DeleteLoan(Loan loan)
    {
        context.Loans.Remove(loan);
        context.SaveChanges();
        LoadLoans(); // Reload loans to update the view
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
