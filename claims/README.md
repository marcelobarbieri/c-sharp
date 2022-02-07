# Apresentando Claims [Editado]

[Macoratti.net](http://www.macoratti.net/21/03/c_claims1.htm) 05/01/2022 

Hoje vamos apresentar o conceito de Claims e o seu papel e funcionamento na plataforma .NET.

Para garantir a segurança de um aplicativo em relação ao usuário temos um processo em duas partes:

1. Autenticação - Primeiro, os usuários precisam ser autenticados;
2. Autorização - A seguir precisam ser autorizados, ou seja, precisamos verificar se eles têm permissão para usar os recursos solicitados;

Com isso definido veremos agora como obter informações sobre usuários usando os recursos **identity** e **principals**.

Para tratar com as informações dos usuários temos que entender o papel de duas classes no namespaces **System.Security.Principal** que são:

1. **IIdentity** -  Contém o nome do usuário autenticado e o tipo de autenticação que está sendo usada: **cookieAutentication**, **TokenAutentication**, etc.;
 
2. **IPrincipal** - Contém a informação sobre permissões e autorização do usuário no contexto que ele está inserido.

E uma das maneiras de construir uma identidade para um usuário e e usar as classes **ClaimsPrincipal** e **ClaimsIdentity** que herdam as respectivas interfaces **IPrincipal** e **IIdentity**.

Assim temos que :

1. **ClaimsIdentity** - Representa uma identidade baseada em claims ou declarações; Sendo que uma declaração é uma instrução sobre uma entidade feita por um emissor que descreve uma propriedade ou alguma outra qualidade dessa entidade, e,  esta declaração é representada pela classe Claim.

Então para criamos uma identidade devemos definir declarações ou claims usando a classe Claim e através da classe ClaimsIdentity criar a identidade.

Exemplo:

```c#
//Criando as declarações ou claims
Claim claimName = new Claim(ClaimTypes.Name, "Macoratti");
Claim claimEmail = new Claim(ClaimTypes.Role, "macoratti@yahoo.com");
Claim claimRole = new Claim(ClaimTypes.Role, "Admin");
IList<Claim> Claims = new List<Claim>()
{
    claimName, claimEmail, claimRole
};

 //Criando a Identidade
ClaimsIdentity identity = new ClaimsIdentity(Claims, "Macoratti.net");
```

Para criar as *claims* usamos a classe **ClaimTypes** que define constantes para os tipos de claim conhecidos que podem ser atribuídos a uma entidade.

Após definir uma coleção de *claims* usamos **ClaimsIdentity** para criar a identidade com o nome 'Macoratti'.

Agora para poder atribuir a identidade ao ambiente podemos usar a classe **ClaimsPrincipal**:

```c#
...
ClaimsPrincipal principal = new ClaimsPrincipal(identity);

Thread.CurrentPrincipal = principal;
```

Agora podemos obter a identidade e verificar se ele esta autenticado consultando a propriedade **IsAuthenticated** usando o código abaixo:

```c#
Console.WriteLine($"Identidade: {Thread.CurrentPrincipal.Identity.Name}\n");
Console.WriteLine($"Usuário Autenticado: {Thread.CurrentPrincipal.Identity.IsAuthenticated}\n");
Console.ReadLine();
```

Resultado:

```ps
Identidade: Macoratti
Usuário Autenticado: True
```

Podemos criar uma identidade usando diretamente a classe ClaimsIdentity:

E podemos percorrer as claims ou declarações feitas usando o código a seguir:

```c#
foreach (Claim ci in principal.Claims)
    Console.WriteLine(ci.Value);
    
Console.WriteLine(principal.Identity.Name + " Pertence a role Admin ? \n" 
              + principal.IsInRole("Admin"));
Console.ReadLine();
```

Resultado:

```ps
Identidade: Macoratti

Usuário Autenticado: True

Macoratti
macoratti@yahoo.com
Admin

Macoratti Pertence a role Admin ?
True
```

Observe que podemos verificar se o usuário faz parte de uma determinar role ou perfil.

```c#
principal.IsInRole("Admin")
```

E para percorrer cada claim na coleção das declarações usamos o laço foreach:

```c#
foreach (Claim ci in principal.Claims)
    Console.WriteLine(ci.Value);
```    

Como todas as classes principal derivam da classe base **ClaimsPrincipal**, dessa forma é possível acessar claims ou declarações dos usuários usando a propriedade Claims de um objeto principal.

Além disso podemos testar se uma claim está disponível, usando o método HasClaim :

```c#
bool TemNome = identity.HasClaim (c => c.Type == ClaimTypes.Name);
```

E também podemos recuperar claims específicas, usando o método **FindAll** usando um predicado para definir uma correspondência:

```c#
var groupClaims = identity.FindAll (c => c.Type == ClaimTypes.GroupSid);
```

Esses conceitos são importantes e são muito usados em aplicações ASP .NET Core.


