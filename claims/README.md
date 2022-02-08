<style>
    span {
        color: powderblue;
    }
</style>

# Claims

Traduzido por "declarações"

https://docs.microsoft.com/en-us/dotnet/api/system.security.claims?view=net-6.0

<details><summary>Claim</summary>
    <p>Representa uma declaração</p>

```c#
public class Claim    
```

O exemplo a seguir extrai as declarações associadas ao usuário autenticado executando uma solicitação HTTP e as grava na resposta HTTP.
O usuário atual é lido no <span>HttpContext</span> como um <span>ClaimsPrincipal</span> e as declarações são lidas a partir dele.
As declarações são gravadas no <span>HttpResponse</span>
    
```c#
ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;  
if (null != principal)  
{  
   foreach (Claim claim in principal.Claims)  
   {  
      Response.Write("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");  
   }  

}    
```
    
</details>    
