/*Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.*/

int GetNumber(string message) {
    int result = 0;
    while(true) {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out result) && (result > 0)) {
            break;
        }
        else {
            Console.WriteLine("Ввели не корректное число. Повторите ввод");
        }
    }
    return result;
}

int[,] InitMatrix(int rows, int columns) {
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            matrix[i,j]=rnd.Next(-10,11);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write($" {matrix[i,j] } ");
        }
        Console.WriteLine();
    }
}


double[,] ColumnAverageMatrix(int[,] matrix) {
    int[,] sum = new int[1,matrix.GetLength(1)];
    double[,] average = new double[1,matrix.GetLength(1)];
    for (int j = 0; j < matrix.GetLength(1); j++) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            sum[0,j] = sum[0,j] + matrix[i,j];
        }
        average[0,j] = (double) sum[0,j] / matrix.GetLength(0);
    }
    
    return average;
}

void PrintMatrixDouble(double[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
            Console.Write($" {Math.Round(matrix[i,j],2) } ");
        }
        Console.WriteLine();
    }
}

int rows = GetNumber("Введите количество строк");;
int columns = GetNumber("Введите количество столбцов");
Console.WriteLine();

int[,] matrix = InitMatrix(rows,columns);
PrintMatrix(matrix);
Console.WriteLine();

double[,] matrixNew = ColumnAverageMatrix(matrix);
Console.WriteLine("Среднее арифметическое каждого столбца:");
PrintMatrixDouble(matrixNew);