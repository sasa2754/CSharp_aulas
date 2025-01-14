using System;

namespace DataBase.Exceptions;

public class CustomNotDefinedException : Exception {
    public override string Message => "Custom não definido, use 'DC<T>.SetCustom' para definir seu local.";
}