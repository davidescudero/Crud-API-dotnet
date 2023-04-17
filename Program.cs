var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Todo> BDMemory = new List<Todo>();

Todo todo = new Todo();

todo.Id = 1;
todo.Nombre = "sacar perro";
todo.Completado = true;



Todo todo1 = new Todo();

todo1.Id = 2;
todo1.Nombre = "sacar gato";
todo1.Completado = true;

BDMemory.Add(todo);
BDMemory.Add(todo1);

app.MapGet("/api/v1/todo", () => {
    return Results.Ok(BDMemory);
});

app.MapGet("/api/v1/todo/{id}", (int id) => {
    return Results.Ok(BDMemory.Single(todo=>todo.Id == id));
});

app.MapPost("/api/v1/todo", (Todo todo) => {
    BDMemory.Add(todo);
    return Results.Ok(BDMemory);
});

app.MapPut("/api/v1/todo/{id}", (int id, Todo todo) => {
    Todo registro = BDMemory.Single(todo=>todo.Id == id);
    registro.Completado = todo.Completado;
    return Results.Ok(BDMemory);
});

app.MapDelete("/api/v1/todo/{id}", (int id) => {
    
    return Results.Ok(BDMemory.RemoveAll(todo=>todo.Id == id));
});

app.Run();


public class Todo{
    public int Id{get; set;}

    public string  Nombre{get; set;}

    public bool Completado{get; set;}
}