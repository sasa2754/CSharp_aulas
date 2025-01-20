namespace Listinha;

public class List<T>(int size) {
    public int size { get; set; } // Tamanho que está o array
    public int count { get; private set; } // Count pra saber o quanto de elementos eu tenho no array
    T[] array = new T[size]; // Criação do array
    public T[] Array => array; // Get do array



    // Retorna o valor que está no index passado
    public T this[int index] {
        get {
            return Array[index];
        }
        set {
            Array[index] = value;
        }
    }


    public void add(T value) {
    // Verifica se o array está cheio
    if(array.Length == size) {
        // Cria um novo array com o dobro do tamanho
        T[] newArray = new T[size * 2];

        // Copia os dados do array antigo para o novo
        for (int i = 0; i < array.Length; i++) {
            newArray[i] = array[i];
        }

        // Atualiza o tamanho e o array original
        size *= 2;

        newArray[array.Length] = value; // Adiciona o novo valor na posição correta

        array = newArray; // Passa os dados e o tamanho do array novo pro array original
    } else {
        array[count] = value;
        count++;
    }
}

}