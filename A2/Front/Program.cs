using static System.Console;
using Model;
using Model.Respository;
using System.Linq;


IRepository<Aluno> alunoRepo = new AlunoFakeRepository();
IRepository<Professor> professorRepo = new ProfessorFakeRepository();
IRepository<Disciplina> disciplinaRepo = new DisciplinaFakeRepository();
IRepository<Turma> turmaRepo = new TurmaFakeRepository();
IRepository<TurmaAlunos> turmaAlunosRepo = new TurmaAlunosFakeRepository();

while (true) {
    try
    {
        WriteLine("1 - Cadastrar Professor\n2 - Cadastrar Aluno\n3 - Ver Professores\n4 - Ver Alunos\n5 - Cadastrar Disciplina\n6 - Ver Disciplinas\n7 - Cadastrar Turmas\n8 - Cadastrar Alunos nas turmas\n9 - Ver Turmas\n0 - Sair");

        int option = int.Parse(ReadLine());

        switch (option)
        {
            case 1:
                Clear();
                Professor professor = new();
                WriteLine("Digite o nome do professor: ");
                professor.Nome = ReadLine();
                WriteLine("Digite a formação do professor: ");
                professor.Formacao = ReadLine();
                professorRepo.Add(professor);
                break;

            case 2:
                Clear();
                Aluno aluno = new();
                WriteLine("Digite o nome do aluno: ");
                aluno.Nome = ReadLine();
                WriteLine("Digite a idade do aluno: ");
                aluno.Idade = int.Parse(ReadLine());
                var alunosQuantidade = alunoRepo.All.Count;
                aluno.AlunoId = alunosQuantidade + 1;
                alunoRepo.Add(aluno);
                break;

            case 3:
                var profs = professorRepo.All;
                Clear();
                WriteLine("\nProfessores:\n");
                foreach (var prof in profs) {
                    WriteLine($"{prof.Nome} - {prof.Formacao}");
                }
                WriteLine();
                break;

            case 4:
                var alunos = alunoRepo.All;
                Clear();
                WriteLine("\nAlunos:\n");
                foreach (var student in alunos) {
                    WriteLine($"{student.Nome} - {student.Idade}");
                }
                WriteLine();
                break;

            case 5:
                Clear();
                Disciplina disciplina = new();
                WriteLine("Digite o nome da disciplina: ");
                disciplina.Nome = ReadLine();
                WriteLine("Digite a descrição da disciplina: ");
                disciplina.Descricao = ReadLine();
                disciplinaRepo.Add(disciplina);
                break;

            case 6:
                var disciplinas = disciplinaRepo.All;
                Clear();
                WriteLine("\nDisciplinas:\n");
                foreach (var disciplina1 in disciplinas) {
                    WriteLine($"{disciplina1.Nome} - {disciplina1.Descricao}");
                }
                WriteLine();
                break;

            case 7:
                Clear();
                Turma turma = new();
                WriteLine("Digite o nome da turma: ");
                turma.Nome = ReadLine();
                WriteLine("Digite o semestre da turma: ");
                turma.Semestre = int.Parse(ReadLine());
                var turmasQuantidade = turmaRepo.All.Count;
                turma.TurmaId = turmasQuantidade + 1;
                turmaRepo.Add(turma);
                break;

            case 8:
                Clear();
                var turmasA = turmaRepo.All;
                var AlunosA = alunoRepo.All;
                WriteLine("Digite o nome da turma que você quer adicionar alunos: ");
                var searchTurma = ReadLine();
                var turmaId = 0;
                var achadoTurma = false;
                for (int i = 0; i < turmasA.Count; i++) {
                    if (turmasA[i].Nome == searchTurma) {
                        turmaId = turmasA[i].TurmaId;
                        achadoTurma = true;
                    }
                }

                if (!achadoTurma) {
                    WriteLine("Turma não encontrada!");
                    break;
                }

                WriteLine("Digite o nome do aluno: ");
                var searchAluno = ReadLine();

                var alunoId = 0;
                var achadoAluno = false;

                for (int i = 0; i < AlunosA.Count; i++) {
                    if (AlunosA[i].Nome == searchAluno) {
                        alunoId = AlunosA[i].AlunoId;
                        achadoAluno = true;
                    }
                }

                if (!achadoAluno) {
                    WriteLine("Aluno não encontrado!");
                    break;
                }

                TurmaAlunos turmaAluno = new();
                turmaAluno.AlunosId = alunoId;
                turmaAluno.TurmaId = turmaId;


                turmaAlunosRepo.Add(turmaAluno);
                break;

            case 9:
                Clear();
                var alunosA = alunoRepo.All;
                var turmas = turmaRepo.All;
                var turmaAlunosRelacoes = turmaAlunosRepo.All;

                WriteLine("\nTurmas com Alunos:\n");


                foreach (var turmaA in turmas)
                {
                    WriteLine($"Turma: {turmaA.Nome} - Semestre: {turmaA.Semestre}");


                    var alunosDaTurmaIds = turmaAlunosRelacoes
                        .Where(ta => ta.TurmaId == turmaA.TurmaId)
                        .Select(ta => ta.AlunosId);


                    var alunosDaTurma = alunosA
                        .Where(a => alunosDaTurmaIds.Contains(a.AlunoId))
                        .ToList();

                    if (alunosDaTurma.Any())
                    {
                        WriteLine("Alunos:");
                        foreach (var alunoA in alunosDaTurma)
                        {
                            WriteLine($"- {alunoA.Nome}, Idade: {alunoA.Idade}");
                        }
                    }
                    else
                    {
                        WriteLine("Nenhum aluno associado a esta turma.");
                    }

                    WriteLine();
                }
                WriteLine();
                break;


            case 0:
                WriteLine("Até mais!");
                return;
                // break; 
        }
    }
    catch (System.Exception)
    {
        
        WriteLine("Não foi possível abrir o sistema! Tente novamente outra hora!");
    }
}
