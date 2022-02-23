# Action e Action Chaining no C#

As **Actions** no C# funcionam como uma espécie de delegate onde podemos armazenar ações para serem executadas posteriormente.

## Action

Um **Action** no C# é um tipo que pode receber uma função.

Para definir uma **Action** basta criar seu tipo e apontar para uma função seja no momento da declaração da variável ou posteriormente.

```c#
Action acao;

acao = MinhaFuncao;

acao();

void MinhaFuncao()
{
    Console.WriteLine("Eu sou uma função");
}
```

No exemplo acima, temos uma função chamada **MinhaFuncao** que imprime um texto na tela.
Após definida, podemos criar uma ação como definimos em **Action acao** e depois assimilar a função a esta ação, como fizemos com **acao = MinhaFuncao**.

Por fim podemos executar esta ação invocando-a, como fazemos com qualquer função (abrindo e fechando parênteses) desta forma **acao()**

## Funções Anônimas

Data uma função que não recebe parâmetros (**parameterless**) podemos assimila-la diretamente a um **Action** como fizemos anteriormente em **acao = MinhaFuncao**

Porém quando temos parâmetros, a invocação da função exige os mesmos, e neste caso, precisamos da assinatura completa da função para poder invoca-la posteriormente.

Isto pode ser feito utilizando as funções anônimas do C#, que podem ser definidas como **() =>** e são exemplificadas abaixo.

```c#
Action acao;

acao = () => MinhaFuncao("Eu sou um parâmetro");

acao();

void MinhaFuncao(string texto)
    => Console.WriteLine(texto);
```

Note que neste caso, é como se estivéssemos executando a função, podemos passar os parâmetros necessários para ela ser executadada, tudo conforme estamos acostumados já no C#.

Porém, a execução desta função não será realizada no momento que associamos ela com a **Action** e sim na hora que executamos a **Action**, neste caso a linha **acao()**.

## Action Chaining

Mas qual a vantagem de ter uma função que armazena uma função?
Bem, uma delas é o **Action Chaining** ou **encadeamento de funções**.

Vamos tomar como base um cadastro de novos clientes/alunos com os seguintes métodos abaixo.

```c#
Action handle;

handle = VerificaRequisicao;
handle += VerificaSeEmailEstaEmUso;
handle += GeraOUsuario;
handle += GeraOAluno;
handle += PersisteOsDados;
handle += EnviaCodigoDeAtivacao;
handle += LogaANovaContaCriada;

handle();

void VerificaRequisicao() { }
void VerificaSeEmailEstaEmUso() { }
void GeraOUsuario() { }
void GeraOAluno() { }
void PersisteOsDados() { }
void EnviaCodigoDeAtivacao() { }
void LogaANovaContaCriada() { }
```

Neste caso, podemos utilizar o operador **+=** para anexar funções ao **Action** e posteriormente executá-las na ordem que foram atribuídas.

Utilizamos este modelo por conta do reuso das funções em diversar partes do sistema.

Imagina uma simples validação de e-mail.
Queremos saber se o e-mail já está cadastrado em nossa base, então isto vira uma função que pode ser invocada em diferentes **Handlers**

# Conclusão

O C# permite criarmos ações ou cadeia delas para serem executas posteriormente.
Isto permite uma maior reusabilidade das funções e alocação dinâmica das mesmas.

# Referências

- [Balta.io](https://balta.io/blog/csharp-action)
