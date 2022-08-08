

var packages = new List<Package>();

Console.WriteLine("----- DevTrackR - Serviço de Postagem -----");

ShowMainMsg();

var option = Console.ReadLine();
while (option != "0") {
    switch (option) {
        case "1": //Cadastrar pacote
            RegisterPackage();
            break;
        case "2": //Atualizar pacote
            UpdatePackage();
            break;
        case "3": //Consultar pacote
            ConsultPackage();
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    ShowMainMsg();
    option = Console.ReadLine();
}

void RegisterPackage() {
    Console.Write("Digite o Título: ");
    var title = Console.ReadLine();
    Console.Write("Digite o Descrição: ");
    var description = Console.ReadLine();

    var package = new Package(title, description);
    packages.Add(package);

    Console.WriteLine($"\nPacote com código: {package.TrackCode} Foi registado com sucesso.\n");
}

void ShowMainMsg() { 
    Console.WriteLine("|---------------------------------------------------|\nDigite o número de acordo com o a opção que desejas.");
    Console.WriteLine("1 - Cadastro de Pacote");
    Console.WriteLine("2 - Atualizar Pacote");
    Console.WriteLine("3 - Consultar Pacote");
    Console.WriteLine("0 - Sair da aplicação.");
}

void UpdatePackage() {
    Console.WriteLine("Digite o código do pacote.");
    var trackCode = Console.ReadLine();

    var package = packages.SingleOrDefault(p => p.TrackCode == trackCode);

    if (package == null) {
        Console.WriteLine("Pacote não encontrado!");
        return;
    }

    Console.WriteLine("Digite o status atual.");
    var status = Console.ReadLine();

    package.UpdateStatus(status);
}



void ConsultPackage() {
    Console.WriteLine("Digite o código do Pacote.");
    var trackCode = Console.ReadLine();

    var package = packages.SingleOrDefault(p => p.TrackCode == trackCode);

    if (package == null) {
        Console.WriteLine("Pacote não encontrado!");
        return;
    }

    package.ShowDetails();
}

var premiumPackage = new PremiumPackage("Premium", "Um pacote premium", "Air");
var package = new Package("Normal", "Um pacote normal");
var packageList = new List<Package> { premiumPackage, package };

foreach (var item in packageList) {
    item.ShowDetails();
}

#region Models
public class Package {
    public Package(string title, string description)
    {
        Title = title;
        Description = description;
        TrackCode = GetCode();
        PostedAt = DateTime.Now;
        Status = "Posted";
    }

    private string GetCode() {
        return Guid.NewGuid().ToString();
    }
    public virtual void ShowDetails() {
        Console.WriteLine($"\nPacote: {Title} \nCódigo: {TrackCode} \nStatus: {Status}");
    }
    public void UpdateStatus (string status) {
        Status = status;
        Console.WriteLine ("Pacote atualizado com sucesso.");
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string TrackCode {get; private set; }
    public DateTime PostedAt { get; private set; }

    public string Status { get; private set; }

}

public class PremiumPackage : Package
{
    public PremiumPackage(string title, string description, string transport) : base(title, description)
    {
        Transport = transport;
    }

    public string Transport { get; private set; }

    public override void ShowDetails() {
        base.ShowDetails();
    Console.WriteLine($"Transporte: {Transport}");   
    }
}

#endregion