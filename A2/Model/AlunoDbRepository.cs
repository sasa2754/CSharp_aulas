using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class AlunoDbRepository : IRepository<Aluno> {

    protected DBSqlSrv<Aluno> db;

    public AlunoDbRepository() {
        db = new DBSqlSrv<Aluno> (
            "CA-C-00652\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<Aluno> All => db.All;

    public void Add(Aluno obj)
    {
        db.Save(obj);
    }
}