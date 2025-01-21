// using static System.Console;
using System.Linq;
using System.Runtime.CompilerServices;
using Universidades;

var uni = new Universidade();

var query1 =
    from dep in uni.Departamentos
    join dis in uni.Disciplinas
    on dep.Id equals dis.DepartamentoId
    select new { DepartamentoNome = dep.Nome, DisciplinaNome = dis.Nome } into r
    group r by r.DepartamentoNome into g
    orderby g.Key
    select g;

var query2 = uni.Alunos
    .Select(aluno => new
    {
        Aluno = aluno.Nome,
        Idade = aluno.Idade,
        Professores = aluno.Matriculas
            .Select(matriculaId => uni.Turmas
                .FirstOrDefault(t => t.Id == matriculaId)?.ProfessorId)
            .Select(professorId => uni.Professores.FirstOrDefault(p => p.Id == professorId)?.Nome)
    });


var query3 = uni.Professores
    .Select(professor => new
    {
        Professor = professor.Nome, 
        Salario = professor.Salario, 
        Alunos = uni.Alunos
            .Where(aluno => aluno.Matriculas
                .Any(matriculaId => uni.Turmas
                    .Any(turma => turma.Id == matriculaId && turma.ProfessorId == professor.Id)))
            .Select(aluno => aluno.Nome)
    });

var query4 = uni.Professores
    .Select(professor => new
    {
        Professor = professor.Nome, 
        Salario = professor.Salario, 
        Alunos = uni.Alunos
            .Where(aluno => aluno.Matriculas
                .Any(matriculaId => uni.Turmas
                    .Any(turma => turma.Id == matriculaId && turma.ProfessorId == professor.Id)))
            .Select(aluno => aluno.Nome).Count()
    });

query4 = query4.Take(5).OrderByDescending(aluno => aluno.Alunos);


var query5 = 
    from p in uni.Professores
    join t in uni.Turmas
    on p.Id equals t.ProfessorId
    join a in uni.Alunos
    on t.Id equals a.Matriculas.FirstOrDefault()
    group a by new { p.Nome, p.Salario, t.Id } into g
    select new {
        Alunos = g.Select(a => a.Nome).Distinct(),
        CustoPorAluno = 300 + (g.Key.Salario / g.Count())
    };





Console.WriteLine("Os departamentos, em ordem alfabética, com o número de disciplinas: ");
Console.WriteLine();

Console.WriteLine($"Quantidade de disciplinas: {uni.Disciplinas.Count()}");

foreach (var group in query1)
{
    Console.WriteLine();
    Console.WriteLine($"Departamento: {group.Key}");
    Console.WriteLine();

    foreach (var item in group)
    {
        Console.WriteLine($"  Disciplina: {item.DisciplinaNome}");
    }
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
 

Console.WriteLine("Liste os alunos e suas idades com seus respectivos professores.");
Console.WriteLine();

foreach (var group in query2)
{
    Console.WriteLine();
    Console.WriteLine($"Aluno: {group.Aluno} - Idade: {group.Idade}");
    Console.WriteLine();

    foreach (var item in group.Professores.Where(p => p != null))
    {
        Console.WriteLine($"  Professor: {item}");
    }
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Liste os professores e seus salários com seus respectivos alunos.");
Console.WriteLine();

foreach (var professor in query3)
{
    Console.WriteLine();
    Console.WriteLine($"Professor: {professor.Professor} - Salário: {professor.Salario}");
    if (professor.Alunos.Any())
    {
        Console.WriteLine("  Alunos:");
        foreach (var aluno in professor.Alunos)
        {
            Console.WriteLine($"    - {aluno}");
        }
    }
    else
    {
        Console.WriteLine("  Sem alunos.");
    }
}



Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Top 5 Professores com mais alunos da universidade.");
Console.WriteLine();


foreach (var item in query4){
    Console.WriteLine($"Professor: {item.Professor} - Quantidade de Alunos: {item.Alunos}");  
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine(
    """
    Considerando que todo aluno custa 300 reais, mais o salário dos seus professores
    divido entre seus colegas de classe. Liste os alunos e seus respectivos custos.
    """
);

Console.WriteLine();

foreach (var turma in query5)
{
    foreach (var aluno in turma.Alunos)
    {
        Console.WriteLine($"Aluno: {aluno} - Custo: {turma.CustoPorAluno:C}");
    }
}


Console.ReadKey(true);

public record Professor(
    int Id,
    string Nome,
    int Idade,
    int DepartamentoId,
    decimal Salario
);

public record Departamento(
    int Id, 
    string Nome
);

public record Disciplina(
    int Id,
    string Nome,
    int DepartamentoId
);

public record Turma(
    int Id,
    int DisciplinaId,
    int ProfessorId,
    string Codigo
);

public record Aluno(
    int Id,
    string Nome,
    int Idade,
    List<int> Matriculas
);
