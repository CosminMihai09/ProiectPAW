using ProiectPAW.Classes;
using ProiectPAW.Data;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;

public class ClientViewModel : INotifyPropertyChanged
{
    private LoanContext context;

    public BindingList<Client> Clients { get; set; } = new BindingList<Client>();
    private Client selectedClient = new Client();
    public Client SelectedClient
    {
        get => selectedClient;
        set
        {
            selectedClient = value;
            OnPropertyChanged(nameof(SelectedClient));
        }
    }

    public ClientViewModel()
    {
        context = new LoanContext();
        LoadClients();
    }

    public void LoadClients()
    {
        var clients = context.Clients.Include(c => c.Loans).ToList();
        Clients = new BindingList<Client>(clients);

        if (Clients.Count == 0)
        {
            Clients = new BindingList<Client>();
        }

        if (SelectedClient == null && Clients.Count > 0)
        {
            SelectedClient = Clients.First();
        }
        else
        {
            SelectedClient = new Client();
        }
    }

    public void AddClient(Client client)
    {
        context.Clients.Add(client);
        context.SaveChanges();
        Clients.Add(client);
    }

    public void UpdateClient(Client client)
    {
        var existingClient = context.Clients.Find(client.ClientId);
        if (existingClient != null)
        {
            context.Entry(existingClient).CurrentValues.SetValues(client);
            context.SaveChanges();
        }
    }

    public void DeleteClient(Client client)
    {
        context.Clients.Remove(client);
        context.SaveChanges();
        Clients.Remove(client);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
