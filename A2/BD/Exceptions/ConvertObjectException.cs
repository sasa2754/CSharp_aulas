using System;

namespace DataBase.Exceptions;

public class ConvertObjectException : Exception {
    public override string Message => "Algum elemento no banco está mal formatado e não pode ser convertido";
}