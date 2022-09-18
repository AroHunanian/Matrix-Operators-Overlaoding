using Matrix_overlaoding_operators;
//Small Example
Matrix matrix = new Matrix(3, 1);
Matrix.CreateMatrix(matrix);
Matrix.PrintMatrix(matrix);
Console.WriteLine();
Matrix matrix1 = new Matrix(1, 3);
Matrix.CreateMatrix(matrix1);
Matrix.PrintMatrix(matrix1);
Console.WriteLine();
Matrix matrix2 = new Matrix();
matrix2 = matrix + matrix1;
Matrix.PrintMatrix(matrix2);
Console.WriteLine();