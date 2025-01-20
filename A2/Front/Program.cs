// using static System.Console;
// using Model;
// using Model.Respository;
// using System.Linq;
// using DataBase;
// using System.Collections.Generic;


// // IRepository<Aluno> alunoRepo = new AlunoFakeRepository();
// // IRepository<Professor> professorRepo = new ProfessorFakeRepository();
// // IRepository<Disciplina> disciplinaRepo = new DisciplinaFakeRepository();
// // IRepository<Turma> turmaRepo = new TurmaFakeRepository();
// // IRepository<TurmaAlunos> turmaAlunosRepo = new TurmaAlunosFakeRepository();

// var dbAluno = DB<Aluno>.App;
// var dbProfessor = DB<Professor>.App;
// var dbDisciplina = DB<Disciplina>.App;
// var dbTurma = DB<Turma>.App;
// var dbTurmaAluno = DB<TurmaAlunos>.App;


// while (true) {
//     try
//     {
//         WriteLine("1 - Cadastrar Professor\n2 - Cadastrar Aluno\n3 - Ver Professores\n4 - Ver Alunos\n5 - Cadastrar Disciplina\n6 - Ver Disciplinas\n7 - Cadastrar Turmas\n8 - Cadastrar Alunos nas turmas\n9 - Ver Turmas\n0 - Sair");

//         int option = int.Parse(ReadLine());

//         switch (option)
//         {
//             case 1:
//                 Clear();
//                 Professor professor = new();
//                 // List<Professor> listProfessor = new();
//                 var listProfessor = dbProfessor.All;
//                 WriteLine("Digite o nome do professor: ");
//                 professor.Nome = ReadLine();
//                 WriteLine("Digite a formação do professor: ");
//                 professor.Formacao = ReadLine();
//                 // professorRepo.Add(professor);
//                 listProfessor.Add(professor);
//                 dbProfessor.Save(listProfessor);
//                 break;

//             case 2:
//                 Clear();
//                 Aluno aluno = new();
//                 // List<Aluno> listAluno = new();
//                 var listAluno = dbAluno.All;
//                 WriteLine("Digite o nome do aluno: ");
//                 aluno.Nome = ReadLine();
//                 WriteLine("Digite a idade do aluno: ");
//                 aluno.Idade = int.Parse(ReadLine());
//                 aluno.AlunoId = listAluno.Any() ? listAluno.Max(a => a.AlunoId) + 1 : 1;
//                 // alunoRepo.Add(aluno);
//                 listAluno.Add(aluno);
//                 dbAluno.Save(listAluno);
//                 break;

//             case 3:
//                 // var profs = professorRepo.All;
//                 var profs = dbProfessor.All;
//                 Clear();
//                 WriteLine("\nProfessores:\n");
//                 foreach (var prof in profs) {
//                     WriteLine($"{prof.Nome} - {prof.Formacao}");
//                 }
//                 WriteLine();
//                 break;

//             case 4:
//                 // var alunos = alunoRepo.All;
//                 var alunos = dbAluno.All;
//                 Clear();
//                 WriteLine("\nAlunos:\n");
//                 foreach (var student in alunos) {
//                     WriteLine($"{student.Nome} - {student.Idade}");
//                 }
//                 WriteLine();
//                 break;

//             case 5:
//                 Clear();
//                 Disciplina disciplina = new();
//                 // List<Disciplina> listDisciplina = new();
//                 var listDisciplina = dbDisciplina.All;
//                 WriteLine("Digite o nome da disciplina: ");
//                 disciplina.Nome = ReadLine();
//                 WriteLine("Digite a descrição da disciplina: ");
//                 disciplina.Descricao = ReadLine();
//                 // disciplinaRepo.Add(disciplina);
//                 listDisciplina.Add(disciplina);
//                 dbDisciplina.Save(listDisciplina);
//                 break;

//             case 6:
//                 // var disciplinas = disciplinaRepo.All;
//                 var disciplinas = dbDisciplina.All;
//                 Clear();
//                 WriteLine("\nDisciplinas:\n");
//                 foreach (var disci in disciplinas) {
//                     WriteLine($"{disci.Nome} - {disci.Descricao}");
//                 }
//                 WriteLine();
//                 break;

//             case 7:
//                 Clear();
//                 Turma turma = new();
//                 // List<Turma> listTurma = new();
//                 var listTurma = dbTurma.All;
//                 WriteLine("Digite o nome da turma: ");
//                 turma.Nome = ReadLine();
//                 WriteLine("Digite o semestre da turma: ");
//                 turma.Semestre = int.Parse(ReadLine());
//                 turma.TurmaId = listTurma.Any() ? listTurma.Max(t => t.TurmaId) + 1 : 1;
//                 // turmaRepo.Add(turma);
//                 listTurma.Add(turma);
//                 dbTurma.Save(listTurma);
//                 break;

//             case 8:
//                 Clear();
//                 // var turmasA = turmaRepo.All;
//                 // var AlunosA = alunoRepo.All;
//                 var turmasA = dbTurma.All;
//                 var AlunosA = dbAluno.All;

//                 WriteLine("Digite o nome da turma que você quer adicionar alunos: ");
//                 var searchTurma = ReadLine();
//                 var turmaId = 0;
//                 var achadoTurma = false;
//                 for (int i = 0; i < turmasA.Count; i++) {
//                     if (turmasA[i].Nome == searchTurma) {
//                         turmaId = turmasA[i].TurmaId;
//                         achadoTurma = true;
//                     }
//                 }

//                 if (!achadoTurma) {
//                     WriteLine("Turma não encontrada!");
//                     break;
//                 }

//                 WriteLine("Digite o nome do aluno: ");
//                 var searchAluno = ReadLine();

//                 var alunoId = 0;
//                 var achadoAluno = false;

//                 for (int i = 0; i < AlunosA.Count; i++) {
//                     if (AlunosA[i].Nome == searchAluno) {
//                         alunoId = AlunosA[i].AlunoId;
//                         achadoAluno = true;
//                     }
//                 }

//                 if (!achadoAluno) {
//                     WriteLine("Aluno não encontrado!");
//                     break;
//                 }
//                 // List<TurmaAlunos> listTurmaAluno = new();
//                 var listTurmaAluno = dbTurmaAluno.All;

//                 TurmaAlunos turmaAluno = new();
//                 turmaAluno.AlunosId = alunoId;
//                 turmaAluno.TurmaId = turmaId;


//                 // turmaAlunosRepo.Add(turmaAluno);
//                 listTurmaAluno.Add(turmaAluno);
//                 dbTurmaAluno.Save(listTurmaAluno);
//                 break;

//             case 9:
//                 Clear();
//                 // var alunosA = alunoRepo.All;
//                 // var turmas = turmaRepo.All;
//                 // var turmaAlunosRelacoes = turmaAlunosRepo.All;
//                 var turmas = dbTurma.All;
//                 var alunosA = dbAluno.All;
//                 var turmaAlunosRelacoes = dbTurmaAluno.All;


//                 WriteLine("\nTurmas com Alunos:\n");


//                 foreach (var turmaA in turmas)
//                 {
//                     WriteLine($"Turma: {turmaA.Nome} - Semestre: {turmaA.Semestre}");


//                     var alunosDaTurmaIds = turmaAlunosRelacoes
//                         .Where(ta => ta.TurmaId == turmaA.TurmaId)
//                         .Select(ta => ta.AlunosId);


//                     var alunosDaTurma = alunosA
//                         .Where(a => alunosDaTurmaIds.Contains(a.AlunoId))
//                         .ToList();

//                     if (alunosDaTurma.Any())
//                     {
//                         WriteLine("Alunos:");
//                         foreach (var alunoA in alunosDaTurma)
//                         {
//                             WriteLine($"- {alunoA.Nome}, Idade: {alunoA.Idade}");
//                         }
//                     }
//                     else
//                     {
//                         WriteLine("Nenhum aluno associado a esta turma.");
//                     }

//                     WriteLine();
//                 }
//                 WriteLine();
//                 break;


//             case 0:
//                 WriteLine("Até mais!");
//                 return;
//                 // break; 
//         }
//     }
//     catch (System.Exception ex)
//     {
//         WriteLine($"Não foi possível abrir o sistema! Tente novamente outra hora!");
//         // WriteLine($"StackTrace: {ex.StackTrace}");
//     }
// }


using Model;
using Model.Respository;

Aluno aluno = new();
aluno.Nome = "Sabrina";
aluno.Idade = 20;
aluno.AlunoId = 1;
var aRepo = new AlunoDbRepository();
aRepo.Add(aluno);

var list = aRepo.All;

foreach (var item in list) {
    System.Console.WriteLine(item.Nome);
}

System.Console.WriteLine();
