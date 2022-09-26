using System.ComponentModel;

namespace TemplateApi.Domain.Models.ViewModels;

public class PersonViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private string? id;

    public string? Id
    {
        get { return id; }
        set
        {

            if (id != value)
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
    }

    private string? name;

    public string? Name
    {
        get { return name; }
        set
        {
            if (name != value)
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }

    private string? surname;

    public string? Surname
    {
        get { return surname; }
        set
        {
            if (surname != value)
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }
    }

    private string? cpf;

    public string? Cpf
    {
        get { return cpf; }
        set
        {
            if (cpf != value)
            {
                cpf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cpf)));
            }
        }
    }

    private DateOnly? birthday;

    public DateOnly? Birthday
    {
        get { return birthday; }
        set
        {
            if (birthday != value)
            {
                birthday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(birthday)));
            }
        }
    }
}
