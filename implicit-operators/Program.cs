using ImplicitOperators;

// --- Built-in ------------------------------

int a = 100;
double b = a;
Console.WriteLine(b); // 100

// double c = 100.0;
// int d = c;
// Console.WriteLine(d);
// error CS0266: Não é possível converter implicitamente tipo "double" em "int". Existe uma conversão explícita (há uma conversão ausente?)

double e = 100.98;
int f = (int)e;
Console.WriteLine(f); // 100

// --- Strings ------------------------------

// cria um telefone (objeto)
var phone = new Phone("55", "11", "999999999");
// converte para string
Console.WriteLine(phone); // +55 (11) 999999999

// cria uma string
var telephone = "55 11 987765544";
// converte para um telefone (objeto)
phone = telephone;
Console.WriteLine(phone); // +55 (11) 987765544

// --- DTO e ViewModel ------------------------------

// cria uma instancia de um usuário
var user = new User
{
    Id = 1,
    Username = "balta",
    Password = "balta1234",
    Active = true
};

// cria uma instancia do ViewModel
// recebe um usuário (conversão implícita)
UserViewModel viewModel = user;

Console.WriteLine(user);
// Id: 1, Username: balta, Password: balta1234, Active: True
Console.WriteLine(viewModel);
// UserName: balta


