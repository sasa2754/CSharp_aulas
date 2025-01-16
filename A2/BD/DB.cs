using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using DataBase.Exceptions;

namespace DataBase;

public class DB<T> where T : DataBaseObject, new() {
    private string basePath;

    private DB(string basePath) => this.basePath = basePath;

    public string DBPath {
        get {
            var fileName = typeof(T).Name;
            var path = this.basePath + fileName + ".csv";
            return path;
        }
    }

    // Se o arquivo não existir, ele cria e usa o StreamReader para ler o conteúdo do arquivo, retornando uma lista de strings representando as linhas do arquivo
    private List<string> openFile() {
        List<string> lines = new();
        StreamReader reader = null;

        var path = this.DBPath;

        if (!File.Exists(path))
            File.Create(path).Close();

        try {
            reader = new StreamReader(path);
            while(!reader.EndOfStream)
                lines.Add(reader.ReadLine());
        } catch {
            lines = null;

        } finally {
            reader?.Close();
        }

        return lines;
    }


    // Cria o arquivo se ele não existir e usa o StreamWriter pra escrever as linhas
    private bool saveFile(List<string> lines) {
        StreamWriter writer = null;
        bool succes = true;
        var path = this.DBPath;

        if (!File.Exists(path))
            File.Create(path).Close();

        try {
            writer = new StreamWriter(path);
            for (int i = 0; i < lines.Count; i++) {
                var line = lines[i];
                writer.WriteLine(line);
            }

        } catch {
            succes = false;

        } finally {
            writer.Close();
        }

        return succes;
    }

    // Lê todos os objetos do banco de dados, para cada linha, ele cria uma instância de T e inicializa com os dados da linha
    public List<T> All {
        get {
            var lines = openFile();
            if (lines is null)
                throw new DataCannotBeOpenedException(this.DBPath);

            var all = new List<T>();

            try {
                for (int i = 0; i < lines.Count; i++) {
                    var line = lines[i];
                    var obj = new T();
                    var data = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    obj.LoadFrom(data);
                    all.Add(obj);
                }
            } catch {
                throw new ConvertObjectException();
            }

            return all.Count > 0 ? all : new List<T>();
        }
    }

    // Converte cada objeto em uma string CSV usando o saveTo, cria uma lista de strings, representando as linhas do arquivo, usa o save file pra gravar no arquivo
    public void Save (List<T> all) {
        List<string> lines = new();

        for (int i = 0; i < all.Count; i++) {
            var data = all[i].SaveTo();
            string line = string.Empty;
            for (int j = 0; j < data.Length; j++)
                line += data[j] + ',';
            lines.Add(line);
        }

        if (saveFile(lines))
            return;

        throw new DataCannotBeOpenedException(this.DBPath);
    }

    private static DB<T> temp = null;
    public static DB<T> Temp {
        get {
            if (temp == null)
                temp = new DB<T>(Path.GetTempPath());

            return temp;
        }
    }

    private static DB<T> app = null;
    public static DB<T> App {
        get {
            if (app == null)
                app = new DB<T>("");

            return app;
        }
    }

    private static DB<T> custom = null;
    public static DB<T> Custom {
        get {
            if (custom == null)
                throw new CustomNotDefinedException();

            return custom;
        }
    }


    public static void SetCustom(string path) => custom = new DB<T>(path);
}