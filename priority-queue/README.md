# Priority Queue

**Priority Queue** ou fila prioritária é um tipo de lista inclusa no C# 10 que permite que os itens sejam ordenados por uma prioridade previamente definida.

## Priority Queue

O **Priority Queue** funciona como uma fila normal no C#, onde usa-se **Enqueue** para adicionar um item e **Dequeue** para remove-lo, porém, neste caso, pode-se informar uma prioridade.

Desta forma, ao desenfileirar os itens, esta prioridade será considerada como fonte primária de ordenação.

```c#
var queue = new PriorityQueue<string, int>();
```

Neste caso, tem-se uma fila que conterá itens do tipo **String** e sua ordenação (menor para maior) será dada por um inteiro (**int**).

## Adicionando itens à fila

Para adicionar itens à fila, pode-se utilizar o método **Enqueue** que conta com dois argumentos, uma **String** que define o item que será enfileirado e um **int** que define a prioridade.

```c#
queue.Enqueue("Item 1",0);
queue.Enqueue("Item 2",4);
queue.Enqueue("Item 3",2);
queue.Enqueue("Item 4",1);
```

## Percorrendo a fila

Para percorrer a fila tomando como base a prioridade (**int**) definida previamente, pode-se utilizar o método **TryDequeue**, que resultará em duas variáveis, sendo **item** do tipo **String** e **priority** do tipo **int**.

> IMPORTANTE: A ordem de desenfileiramento será feita automaticamente do menor para o maior. Mais adiante será visto como mudar a ordem.

```c#
while(queue.TryDequeue(out var item, out var priority))
    Console.WriteLine(#"Item: {item}. Prioridade: {priority}");
```

### Resultado da execução

```ps
Item: Item 1. Prioridade: 0
Item: Item 4. Prioridade: 1
Item: Item 3. Prioridade: 2
Item: Item 2. Prioridade: 4
```

## Customizando a prioridade

No cenário acima, utilizamos a ordenação padrão aplicada pelo .NET/C#, que neste caso considera sempre do menor para o maior.

Como foi definida a prioridade como um inteiro (**int**), os itens foram ordenados de 0 a 4.

```c#
// INT é tipo da prioridade
var queue = new PriorityQueue<string,int>();
```

## Ordenando por Strings

Embora a ordenação via inteiros pareça uma boa opção, há cenários onde deseja-se ordenar por cadeia de caracteres. Será tomado como base um usuário do sistema que pode ter diferentes perfis.

Neste cenário, os perfis podem ser **Admin** que tem privilégios totais, **Premium** que tem acesso à todos os cursos e **Aluno** que é um usuário regular.

Será iniciado pela definição do usuário como um novo **Record**, apenas para demonstração.

```c#
public record Student(string Name);
```

## Comparadores Customizados

Um **Priority Queue** se baseia em um comparaddor para realizar a ordenação dos itens, e este ordenador nada mais é do que uma classe que implementa a interface **ICompared<T>**.

Sendo assim, pode-se criar um comparador chamado **RoleComparer** que recebe um perfil (role) do tipo **String** e o compara com outro perfil (role), também do tipo **String**.

Ao implementar a interface **IComparer<T>** será necessário definir seu tipo, que neste caso será **String**, afinal o perfil aqui é apenas uma **String**. Porém nada impede que **T** seja um tipo complexo, como uma entidade **Role** por exemplo.

Obrigatoriamente, tem-se um método chamado **Compare** que receberá dois objetos do mesmo tipo e deverá retornar o seguinte:

- 0: os itens são iguais
- -1: A é maior que B
- 1: A é menor que B

Como resultado tem-se o seguinte trecho de código, apenas para intuito de demonstração do **Priority Queue**

```c#
public class RoleComparer : IComparer<string>
{
    public int Compare(string? roleA, string? roleB)
    {
        if (roleA == roleB)
            return 0;

        return roleA switch
        {
            "admin" => -1,
            "premium" => -1,
            _ => 1
        };
    }
}
```

## Utilizando um comparador customizado

Agora que se criou um comparador customizado, pode-se dizer à fila que o mesmo deve ser utilizado, informando uma instância do mesmo no construtor.

```c#
var queue = new PriorityQueue<Student, string>(new RoleComparer());
```

Note que neste exemplo tem-se uma **Priority Queue** de **Student** e suas prioridades são do tipo **String**. Isto ocorre pois assume-se que os perfis (roles) são do tipo **String** para intuito desta demonstração.

Com a fila definida, pode-se enfileirar e desenfileirar os itens utilizando as prioridades definidas.

```c#
queue.Enqueue(new Student("Spiderman"), "student");
queue.Enqueue(new Student("Ironman"), "premium");
queue.Enqueue(new Student("Batman"), "admin");

while (queue.TryDequeue(out var item, out var priority))
    Console.WriteLine($"Aluno: {item.Name}. Prioridade: {priority}");
```

Como resultado, tem-se os itens sendo exibidos conforme definido na classe **RoleComparer** onde **admin** é mais prioritário que **premium**, que por sua vez é mais prioritário que **student**.

### Resultado da execução

```ps
Aluno: Batman. Prioridade: admin
Aluno: Ironman. Prioridade: premium
Aluno: Spiderman. Prioridade: student
```

## Conclusão
 
 O C# possui um enorme leque de formar para se trabalhar com listas e filas. É muito comum trabalhar com **List**, **Enumerable** e esquecer-se de outros tipos como o **Priority Queue**. Porém conhecer bem estes tipos pode aumentar ainda mais seu leque de opções.