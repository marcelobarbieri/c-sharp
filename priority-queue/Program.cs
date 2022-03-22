using PriorityQueueExample;

var queue1 = new PriorityQueue<string, int>();

queue1.Enqueue("Item 1", 0);
queue1.Enqueue("Item 2", 4);
queue1.Enqueue("Item 3", 2);
queue1.Enqueue("Item 4", 1);

while (queue1.TryDequeue(out var item, out var priority))
    Console.WriteLine($"Item: {item}. Prioridade: {priority}");

// Item: Item 1. Prioridade: 0
// Item: Item 4. Prioridade: 1
// Item: Item 3. Prioridade: 2
// Item: Item 2. Prioridade: 4

Console.ReadLine();

Console.Clear();

var queue2 = new PriorityQueue<Student, string>(new RoleComparer());

queue2.Enqueue(new Student("Spiderman"), "student");
queue2.Enqueue(new Student("Ironman"), "premium");
queue2.Enqueue(new Student("Batman"), "admin");

while (queue2.TryDequeue(out var item, out var priority))
    Console.WriteLine($"Aluno: {item.Name}. Prioridade: {priority}");

//Aluno: Batman.Prioridade: admin
//Aluno: Ironman.Prioridade: premium
//Aluno: Spiderman.Prioridade: student

Console.ReadLine();