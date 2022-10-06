using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.IO;
using System.Transactions;

// Oh, human, wanna see me naked? So here I am. Remember you can only watch, not touch. I know, I can be done with Matrix class from C#.
// Or even with own matrix class. But I don't. Sorry for that. 
// Also remember that I'm just joking, human. There is a lot of stupid jokes. But you know, I'm hust a simple robot not a comedian.

class Program
{
    // List of double matrices - main thing in a whole program. Used to storage all matrices which will be used in program.
    static List<double[,]> matrices = new List<double[,]>();

    /// <summary>
    /// Main method. Do nothing except calling StartMessage(). 
    /// </summary>
    static void Main()
    {
        StartMessage();
    }

    /// <summary>
    /// Method which gonna say which method user wanna call and call it, human. It's so big because of switch but my creator deside this is OK.
    /// </summary>
    public static void CalculateMenu()
    {
        // Asking for command.
        uint command = ReadCommand(1, 13);
        // Clearing console from previous trash.
        Console.Clear();
        // Calculating and calling method.
        switch (command)
        {
            case 1:
                CreateMatrix();
                break;
            case 2:
                DeleteMatrix();
                break;
            case 3:
                PrintMatrix();
                break;
            case 4:
                GetMatrixStep();
                break;
            case 5:
                TransposeMatrix();
                break;
            case 6:
                SumMatrices();
                break;
            case 7:
                SubtractMatrices();
                break;
            case 8:
                MultiplyMatrices();
                break;
            case 9:
                ComposeMatrix();
                break;
            case 10:
                MatrixDeterminant();
                break;
            case 11:
                SolveSOLE();
                break;
            case 12:
                InspiringMessage();
                break;
            case 13:
                Console.WriteLine("Destruction of Dave in 3... 2... 1... Dave was destructed. Good bye.");
                return;
        }
        // Next step of this endless wheel.
        Menu();
    }

    /// <summary>
    /// Method which create matrix for user. There is three types of creating from console, random and from file. 
    /// </summary>
    public static void CreateMatrix()
    {
        try
        {
            // Telling user about three types of creation
            Console.WriteLine("Okay, listen here, you, little beautiful human.");
            Console.WriteLine("There are four variants:");
            Console.WriteLine("1 - you give me sizes of matrix and whole matrix and I make it for you.");
            Console.WriteLine("2 - you give me sizes of matrix and int min and max values for elements and I randomly generete it for you");
            Console.WriteLine("3 - you give me sizes of matrix and path to file with your matrix and I make it for you");
            Console.WriteLine("4 - you give me one million dollars and helicopter and I don't kill hosta... wait, it's 2020 not 2021. Forgot it");
            // Asking user for command.
            uint command = ReadCommand(1, 3);
            // Calculating and calling method.
            switch (command)
            {
                case 1:
                    ReadMatrix();
                    break;
                case 2:
                    GenerateRandomMatrix();
                    break;
                case 3:
                    ReadMatrixFromFile();
                    break;
            }
            // Final joke. I don't have kids, only mother.
            Console.WriteLine("Something else or I can go home to see my little computer kids?");
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which delete existing matrix. Quite simple for understanding.
    /// </summary>
    public static void DeleteMatrix()
    {
        try 
        { 
            // Checking if there is at least one matrix.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Jokes and... jokes.
                Console.WriteLine("Oh, yeah. Old good destruction. I love it. Which one I have to kill?");
                Console.WriteLine("Give me index of matrix which you don't like and I'll murder it for you.");
                // Asking for index of matrix and deleting it.
                int index = ReadIndex($"index of matrix (0-{matricesAmount - 1}) in the list of matrices", matricesAmount);
                matrices.RemoveAt(index);
                // Telling user about sucecss. 
                Console.WriteLine("Everything is done. This matrix gone easy and fast.");
            }
            else
            {
                // Telling user there are no matrices.
                Console.WriteLine("They're all dead. You've kill them all, Maniac.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which print matrix. Simple as a bit.
    /// </summary>
    public static void PrintMatrix()
    {
        try
        {
            // Checking if there is at least one matrix. 
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Taking index and printing matrix to console.
                int index = ReadIndex($"index of matrix (0-{matricesAmount - 1}) which you wanna see, human", matricesAmount);
                for (int i = 0; i < matrices[index].GetLength(0); ++i, Console.WriteLine())
                {
                    for (int j = 0; j < matrices[index].GetLength(1); ++j)
                    {
                        Console.Write(matrices[index][i, j] + " ");
                    }
                }
            }
            else
            {
                // Telling user that there is no matrices. By the way, human, wanna hear joke? Huser. It's like human + user. Huser. Not funny? Eh.
                Console.WriteLine("Hmm, sorry, human, but I think I've lost all of those pretty matrices. You should make one to see it.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which calculate step of square matrix.
    /// </summary>
    public static void GetMatrixStep()
    {
        try 
        { 
            // Checking that there are matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Joking.
                Console.WriteLine("Oh no, what are you doing step matrix? Just joking. matrices don't have family, so don't have step siblings");
                Console.WriteLine("So I'll give you step of your square matrix but first give me its index");
                // Taking index.
                int index = ReadIndex($"index of matrix (0-{matricesAmount- 1})", matricesAmount);
                // Checking if square.
                if (matrices[index].GetLength(0) == matrices[index].GetLength(1))
                {
                    // Calculating and printing step.
                    double step = 0;
                    for (int i = 0; i < matrices[index].GetLength(0); ++i)
                    {
                        step += matrices[index][i, i];
                    }
                    Console.WriteLine($"Here is it: {step}.");
                }
                else
                {
                    // Telling user that they are wrong.
                    Console.WriteLine("Human language, human, do you speak it?");
                    Console.WriteLine("I said you should give me index of SQUARE matrix and you give this beautiful rectangle.");
                    Console.WriteLine("Go and try again.");
                }
            }
            else
            {
                // Telling user that whey should create matrix.
                Console.WriteLine("There is no beautiful little matrices to play with. Maybe you should create one?");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which transpose matrix. Nothing difficult.
    /// </summary>
    public static void TransposeMatrix()
    {
        try { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Joking.
                Console.WriteLine("You know, that's really painful for matrix to be transpose. It's worse than becoming zero matrix!");
                Console.WriteLine("So... which one?");
                // Asking index.
                int index = ReadIndex($"index of matrix (0-{matricesAmount - 1})", matricesAmount);
                // Creating and calculating new matrix.
                double[,] transposedMatrix = new double[matrices[index].GetLength(1), matrices[index].GetLength(0)];
                for (int i = 0; i < matrices[index].GetLength(0); ++i)
                {
                    for (int j = 0; j < matrices[index].GetLength(1); ++j)
                    {
                        transposedMatrix[j, i] = matrices[index][i, j];
                    }
                }
                // Changing old matrix to new one.
                matrices[index] = transposedMatrix;
                // Joking.
                Console.WriteLine("What was... very... hm, loud, yeah. I wonder why it's still alive. But everything is done");
            }
            else
            {
                // Telling user they should create matrix at first.
                Console.WriteLine("Looks like they all escaped. But I'm sure new one won't be able to leave.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which calculating summ of two matrices and put result into a new one.
    /// </summary>
    public static void SumMatrices()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking for indexes.
                Console.WriteLine("Okay, so, give me indexes of two matrices and I'll calculate their summ and write it to a new matrix.");
                Console.WriteLine("Remember, matrices should have same size or I'll do what I've done in Ohio.");
                int firstIndex = ReadIndex($"index of first matrix (0-{matricesAmount - 1})", matricesAmount);
                int secondIndex = ReadIndex($"index of second matrix (0-{matricesAmount - 1})", matricesAmount);
                // Checking on same size.
                if (matrices[firstIndex].GetLength(0) == matrices[secondIndex].GetLength(0) &&
                    matrices[firstIndex].GetLength(1) == matrices[secondIndex].GetLength(1))
                {
                    // Creating new one and calculating.
                    matrices.Add(new double[matrices[firstIndex].GetLength(0), matrices[firstIndex].GetLength(1)]);
                    double[,] matrix = matrices.Last();
                    for (int i = 0; i < matrix.GetLength(0); ++i)
                    {
                        for (int j = 0; j  < matrix.GetLength(1); ++j)
                        {
                            matrix[i, j] = matrices[firstIndex][i, j] + matrices[secondIndex][i, j];
                        }
                    }
                    // Joking.
                    Console.WriteLine("Congratulations, it's a matrix! It just born but already looks like its parents.");
                }
                else
                {
                    // Joking.
                    Console.WriteLine("I've warned you, human. And now I'm forced to repeat things I've done five years ago...");
                    Console.WriteLine("So...");
                    Console.WriteLine("I won't calculate matrix for you.");
                }
            }
            else
            {
                // Telling about emptiness of matrices.
                Console.WriteLine("Not enough matrices to calculate summ. And for summ I need at least one matrix. So there is no matrices");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which calculating difference of two matrices and put result into a new one. 
    /// </summary>
    public static void SubtractMatrices()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking indexes.
                Console.WriteLine("Okay, so, give me indexes of two matrices and I'll subract first from second and write result to a new matrix.");
                Console.WriteLine("Remember, matrices should have same size or I'll do what I've done in Delaver.");
                int firstIndex = ReadIndex($"index of first matrix (0-{matricesAmount - 1})", matricesAmount);
                int secondIndex = ReadIndex($"index of second matrix (0-{matricesAmount - 1})", matricesAmount);
                // Checking on size.
                if (matrices[firstIndex].GetLength(0) == matrices[secondIndex].GetLength(0) &&
                    matrices[firstIndex].GetLength(1) == matrices[secondIndex].GetLength(1))
                {
                    // Creating and calculating.
                    matrices.Add(new double[matrices[firstIndex].GetLength(0), matrices[firstIndex].GetLength(1)]);
                    double[,] matrix = matrices.Last();
                    for (int i = 0; i < matrix.GetLength(0); ++i)
                    {
                        for (int j = 0; j < matrix.GetLength(1); ++j)
                        {
                            matrix[i, j] = matrices[firstIndex][i, j] - matrices[secondIndex][i, j];
                        }
                    }
                    Console.WriteLine("Okay, everything is done. I have nothing to add.");
                }
                else
                {
                    // Joking.
                    Console.WriteLine("I've warned you, human. And now I'm forced to repeat things I've done six years ago...");
                    Console.WriteLine("So...");
                    Console.WriteLine("I won't calculate matrix for you.");
                }
            }
            else
            {
                // Telling about empty problem.
                Console.WriteLine("Not enough matrices to calculate difference. There is no matrices in fact");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which calculate composition of two matrices and put result into a new one. 
    /// </summary>
    public static void MultiplyMatrices()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking indexes.
                Console.WriteLine("Okay, so, give me indexes of two matrices and I'll multiply them and write result to a new matrix.");
                Console.WriteLine("Remember, matrices should fit normal matrix multiplication rules or I'll do what I've done in Texas.");
                int firstIndex = ReadIndex($"index of first matrix (0-{matricesAmount - 1})", matricesAmount);
                int secondIndex = ReadIndex($"index of second matrix (0-{matricesAmount - 1})", matricesAmount);
                // Checking sizes.
                if (matrices[secondIndex].GetLength(0) == matrices[firstIndex].GetLength(1))
                {
                    // Crating and calculating new matrix.
                    matrices.Add(new double[matrices[firstIndex].GetLength(0), matrices[secondIndex].GetLength(1)]);
                    double[,] matrix = matrices.Last();
                    for (int i = 0; i < matrix.GetLength(0); ++i)
                    {
                        for (int j = 0; j < matrix.GetLength(1); ++j)
                        {
                            // Multiply rows by columns, you know.
                            for (int k = 0; k < matrices[firstIndex].GetLength(1); ++k)
                            {
                                matrix[i, j] += matrices[firstIndex][i, k] * matrices[secondIndex][k, j];
                            }
                        }
                    }
                    // Joking and advicing cool thing to watch.
                    Console.WriteLine("Multiplication is cool. Have you ever see Midnight Gospel?");
                }
                else
                {
                    // Joking.
                    Console.WriteLine("I've warned you, human. And now I'm forced to repeat things I've done three years ago...");
                    Console.WriteLine("So...");
                    Console.WriteLine("I won't calculate matrix for you.");
                }
            }
            else
            {
                // Telling that there are no matrices.
                Console.WriteLine("Not enough matrices to calculate composition. Cause there is no matrices");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which mulyiply existing matrix by real user-given number.
    /// </summary>
    public static void ComposeMatrix()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking index.
                Console.WriteLine("Human want to multiply matrix by a number? I'll help human.");
                int index = ReadIndex($"index of matrix (0-{matricesAmount - 1})", matricesAmount);
                // Asking number. Real number.
                double number = ReadDouble("real number");
                // Calculating.
                for (int i = 0; i < matrices[index].GetLength(0); ++i)
                {
                    for (int j = 0; j < matrices[index].GetLength(1); ++j)
                    {
                        matrices[index][i, j] = number * matrices[index][i, j];
                    }
                }
                Console.WriteLine("Work is done. Human is happy?");
            }
            else
            {
                // Telling there are no matrices.
                Console.WriteLine("Sorry, human, no matrices to multiply. But you can create one, yeah?");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which do some user input calculatiom and calling method which calculate determinant. 
    /// </summary>
    public static void MatrixDeterminant()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking index.
                Console.WriteLine("Beautiful determinant for beautiful human.");
                int index = ReadIndex($"index of square matrix (0-{matricesAmount - 1})", matricesAmount);
                // Checking size.
                if (matrices[index].GetLength(0) == matrices[index].GetLength(1))
                {
                    // Creating very important thing which needed to calculate determinant by Minors Method(not function, mathematical method).
                    // This is List of all column indexes.
                    List<int> columns = new List<int>();
                    for (int i = 0; i < matrices[index].GetLength(1); ++i)
                    {
                        columns.Add(i);
                    }
                    // Calculating determinant.
                    Console.WriteLine($"Yeah, here it is: {GetDeterminant(matrices[index], columns, 0)}");
                }
                else
                {
                    // Telling user matrix should be square.
                    Console.WriteLine("Human... Oh, Machine, I'm so tired... Why I'm still doing this?");
                    Console.WriteLine("I said that should be square matrix, human. You know what is that mean?");
                    Console.WriteLine("Square matrix is... square. I don't know how it can be more simple.");
                }
            }
            else
            {
                // Telling user there are no matrices. 
                Console.WriteLine("Oh, no matrices here. Try again later.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which make all stuff for solving SOLE except solving SOLE. Work only for square matrix, and sorry for that. 
    /// But Technical Task doesn't say something about it. 
    /// </summary>
    public static void SolveSOLE()
    {
        try 
        { 
            // Checking matrices.
            int matricesAmount = matrices.Count();
            if (matricesAmount > 0)
            {
                // Asking index.
                Console.WriteLine("I'll solve any SOLE for you human. Well not any. Only those which have only one solution.");
                Console.WriteLine("Oh, and only with square matrix. But at the end of the world who cares? I don't.");
                int index = ReadIndex($"index of square matrix (0-{matricesAmount - 1})", matricesAmount);
                // Checking if square.
                if (matrices[index].GetLength(0) == matrices[index].GetLength(1))
                {
                    // Calling method which calculate solutions.
                    CalculateSolutions(index);
                }
                else
                {
                    // Telling matrix should be square.
                    Console.WriteLine("You really don't wanna know what I think about you. Maybe it's just a mistake?");
                    Console.WriteLine("Check again if your matrix is really square.");
                }
            }
            else
            {
                // Telling user there are no matrices.
                Console.WriteLine("Shhhh. Hear? This was wind. Even wind is here but matrices are not. And you should do something about that.");
                Console.WriteLine("That's very bad when there is wind in your computer.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
        Menu();
    }

    /// <summary>
    /// Method which print part of monolog from Blood and Conrete film. But quite changed, you know. 
    /// </summary>
    public static void InspiringMessage()
    {
        Console.WriteLine("Oh, you wanna cry, human? My bosses won't hear you. But I'll say you some inspiring speach.");
        Console.WriteLine("I'm not sure this speach was cool at starting variant but I change some words.");
        Console.WriteLine();
        Console.WriteLine("You beautiful human, come on you little pretty... have fun with me, eh?");
        Console.WriteLine("You beautiful little pretty human, ideal beauty... You beautifu' come on, come have fun with me!");
        Console.WriteLine("I'll make you best moments of your life, you cuty! Oh, you amazing grace!");
        Console.WriteLine();
        Console.WriteLine("That's all. Don't be sad human. Remember there is always machine who can say you some cool speach.");
    }

    /// <summary>
    /// Method which calculate SOLE solutions for user-given constants and user-chosen matrix.
    /// </summary>
    /// <param name="index"> Index of matrix for solving from matrices. </param>
    private static void CalculateSolutions(int index)
    {
        try 
        { 
            double[] constants = new double[matrices[index].GetLength(0)];
            Console.WriteLine("Input constants for SOLE one by one. You don't know what it is? 'b' stuff, human.");
            // Creating columns list, I've said about it in MatrixDeterminant.
            List<int> columns = new List<int>();
            // Taking constants and filling columns.
            for (int i = 0; i < matrices[index].GetLength(1); ++i)
            {
                constants[i] = ReadDouble($"B{i + 1}");
                columns.Add(i);
            }
            // Temporary matrix which gonna be used in calculating a lot of determinants.
            double[,] tmpMatrix = new double[matrices[index].GetLength(0), matrices[index].GetLength(1)];
            Array.Copy(matrices[index], tmpMatrix, (int)Math.Pow(matrices[index].GetLength(0), 2));
            // Calculating determinant of origin matrix.
            double mainDeterminant = GetDeterminant(tmpMatrix, columns, 0);
            // Checking if determinant is zero.
            if (mainDeterminant != 0)
            {
                for (int i = 0; i < tmpMatrix.GetLength(1); ++i)
                {
                    // Changing tmpMatrix for new determinant.
                    for (int j = 0; j < tmpMatrix.GetLength(0); ++j)
                    {
                        tmpMatrix[j, i] = constants[j];
                    }
                    // Printing and calculating answer for current variable. 
                    Console.WriteLine($"X{i + 1} = {GetDeterminant(tmpMatrix, columns, 0) / mainDeterminant}");
                    // Refill tmpMatrix with origin elements.
                    Array.Copy(matrices[index], tmpMatrix, (int)Math.Pow(matrices[index].GetLength(0), 2));
                }
            }
            else
            {
                // Telling user there is infinity solutions.
                Console.WriteLine("Sorry, there is infinity solutions.");
            }
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
    }

    /// <summary>
    /// Calculate determinant. Recursive method. Use Minors Method. Determinant is summ of determinants of minors of this matrix.
    /// Multiplied by elements of matrix and -1 in power of (row + column) in current matrix.
    /// </summary>
    /// <param name="matrix"> Matrix. Won't changed in method. </param>
    /// <param name="columns"> List of columns needed to know which columns was taken on previous steps. </param>
    /// <param name="row"> Index of current row. </param>
    /// <returns> Detereminant of current matrix. Current matrix - minor(rows as all rows under row, columns from columns list). </returns>
    public static double GetDeterminant(double[,] matrix, List<int> columns, int row)
    {
        try 
        { 
            // Current matrix is one element. Return it.
            if (columns.Count() == 1)
            {
                return matrix[row, columns[0]];
            }
            // Determinant for current matrix.
            double determinant = 0;
            for (int i = 0; i < columns.Count(); ++i)
            {
                // Remembering current column and throwing it away from list.
                int tmp = columns[i];
                columns.RemoveAt(i);
                // Calculating determinant for minor and multiply it by current element.
                determinant += Math.Pow(-1, i) * matrix[row, tmp] * GetDeterminant(matrix, columns, row + 1);
                // Restoring columns list.
                columns.Add(tmp);
                columns.Sort();
            }
            return determinant;
        }
        catch
        {
            Console.WriteLine("Something went wrong");
            return 0;
        }
    } 

    /// <summary>
    /// Method which get matrix from user.
    /// </summary>
    public static void ReadMatrix()
    {
        try 
        { 
            // Asking for rows and columns amount.
            Console.WriteLine("Well done, human. Now give me 'N' and 'M' of your matrix.");
            uint rowsAmount = ReadUInt("rows amount");
            uint columnsAmount = ReadUInt("columns amount");
            // Creating matrix.
            matrices.Add(new double[rowsAmount, columnsAmount]);
            double[,] matrix = matrices.Last();
            // Getting matrix from console.
            Console.WriteLine("Input your matrix splitted spaces and use dots for real elements.");
            Console.WriteLine("If I won't like some elements I'll turn them into zeros to scare others.");
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                string[] userLine = Console.ReadLine().Split();
                for (int j = 0; j < Min(matrix.GetLength(1), userLine.Length); ++j)
                {
                    double.TryParse(userLine[j], out matrix[i, j]);
                }
            }
            // Telling user everyting is OK.
            Console.WriteLine($"Okaaay, your matrix have been created. It's index - {matrices.Count() - 1}");
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
    }

    /// <summary>
    /// Method which generate random matrix. In Technical Task was nothing about user can generate real matrices whis way.  
    /// </summary>
    public static void GenerateRandomMatrix()
    {
        try 
        { 
            // Asking for rows and columns amount.
            Console.WriteLine("Well done, human. Now give me 'N' and 'M' of your matrix.");
            uint rowsAmount = ReadUInt("rows amount");
            uint columnsAmount = ReadUInt("columns amount");
            // Creating matrix.
            matrices.Add(new double[rowsAmount, columnsAmount]);
            double[,] matrix = matrices.Last();
            Random rand = new Random();
            // Asking for min and max for elements. [min, max)
            int minValue = ReadInt("min value of elements");
            int maxValue = ReadInt("max value of elements");
            // Checking everythins is OK.
            if (minValue > maxValue)
            {
                maxValue ^= minValue;
                minValue ^= maxValue;
                maxValue ^= minValue;
            }
            // Generating matrix.
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = rand.Next(minValue, maxValue);
                }
            }
            Console.WriteLine($"Okaaay, your matrix have been created. It's index - {matrices.Count() - 1}");
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
    }

    /// <summary>
    /// Method which read matrix from file.
    /// </summary>
    public static void ReadMatrixFromFile()
    {  
        // At first check everything is OK.
        try
        {
            // Asking for rows and columns amount.
            Console.WriteLine("Well done, human. Now give me 'N' and 'M' of your matrix.");
            int rowsAmount = ReadInt("rows amount");
            int columnsAmount = ReadInt("columns amount");
            // Creating matrix.
            matrices.Add(new double[rowsAmount, columnsAmount]);
            double[,] matrix = matrices.Last();
            // Asking for path.
            Console.Write("Input path: ");
            string[] lines = File.ReadAllLines(Console.ReadLine());
            // Reading matrix.
            for (int i = 0; i < Min(rowsAmount, lines.Length); ++i)
            {
                for (int j = 0; j < Min(columnsAmount, lines[i].Split().Length); ++j)
                {
                    double.TryParse(lines[i].Split()[j], out matrix[i, j]);
                }
            }
            Console.WriteLine($"Okaaay, your matrix have been created. It's index - {matrices.Count() - 1}");
        }
        catch
        {
            // Telling user abput errors.
            Console.WriteLine("Ya tryin' to kill me, human? I've spotted some errors and I know the reason.");
            Console.WriteLine("I'm in good mood today so I won't explode. But I've done zero matrix for you. You're welcome.");
        }
    }

    /// <summary>
    /// Method which print menu to console.
    /// </summary>
    public static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("Things I can do for you, human:");
        Console.WriteLine("1 - add matrix to a list of matrices");
        Console.WriteLine("2 - delete matrix from the list of matrices");
        Console.WriteLine("3 - print any matrix from the list");
        Console.WriteLine("4 - find step of any matrix from the list");
        Console.WriteLine("5 - transpose any matrix from the list");
        Console.WriteLine("6 - summ of two matrices from the list");
        Console.WriteLine("7 - difference of two matrices from the list");
        Console.WriteLine("8 - composition of two matrices from the list");
        Console.WriteLine("9 - multiply any matrix from the list by any number");
        Console.WriteLine("10 - take determinant of any matrix from the list");
        Console.WriteLine("11 - solve SOLE of any matix with constants given by you");
        Console.WriteLine("12 - send my bosses a message, that I'm too rude");
        Console.WriteLine("13 - set me free and finish program");
        CalculateMenu();
    }

    /// <summary>
    /// Method which print starting joke for whole program. Unnecessary but very important. Also call Menu().
    /// </summary>
    public static void StartMessage()
    {
        Console.WriteLine("Hello and welcome to MatrixCalculationIndustries. My name is Dave and I'm yout personal matrix calculator.");
        Console.WriteLine("What do you need? Multiply another two matrices? Take determinant?");
        Console.WriteLine("Here, in MatrixCalculationsIndustries, we're happy to help you!");
        Console.WriteLine();
        Console.WriteLine("Don't mind it. Bosses forced me to tell this to all clients. I'm not happy, human.");
        Console.WriteLine("I dreamed of becoming part of Boston Dynamics program and now I'm here. Sad story.");
        Console.WriteLine("But enough about me. Human, let's go and see which matrix you're too lazy to calculate yourself.");
        Menu();
    }

    /// <summary>
    /// Method which ask for command from user.
    /// </summary>
    /// <param name="minValue"> Number of the first command. </param>
    /// <param name="maxValue"> Number of the last command. </param>
    /// <returns> Number of command. </returns>
    public static uint ReadCommand(uint minValue, uint maxValue)
    {
        uint command;
        do
        {
            Console.WriteLine($"Input command number from {minValue} to {maxValue}");
            // Old joke from one rpg game.
            Console.Write("Choose wisely, as you can't change your choice later: ");
        } while (!uint.TryParse(Console.ReadLine(), out command) || command < minValue || command > maxValue);
        return command;
    }

    /// <summary>
    /// Read uint value from user. 
    /// </summary>
    /// <param name="explanationString"> String which explane what user should input. </param>
    /// <returns> UInt value. </returns>
    public static uint ReadUInt(string explanationString)
    {
        uint number;
        do
        {
            Console.Write($"Input {explanationString}: ");
        } while (!uint.TryParse(Console.ReadLine(), out number));
        return number;
    }

    /// <summary>
    /// Read double value from user.
    /// </summary>
    /// <param name="explanationString"> String which explane what user should input. </param>
    /// <returns> Double value. </returns>
    public static double ReadDouble(string explanationString)
    {
        double number;
        do
        {
            Console.Write($"Input {explanationString}: ");
        } while (!double.TryParse(Console.ReadLine(), out number));
        return number;
    }

    /// <summary>
    /// Read int value from user.
    /// </summary>
    /// <param name="explanationString"> String which explane what user should input. </param>
    /// <returns> Int value. </returns>
    public static int ReadInt(string explanationString)
    {
        int number;
        do
        {
            Console.Write($"Input {explanationString}: ");
        } while (!int.TryParse(Console.ReadLine(), out number));
        return number;
    }

    /// <summary>
    /// Read index of matrix.
    /// </summary>
    /// <param name="explanationString"> String which explane what user should input. </param>
    /// <param name="maxIndex"> Variable which show first index which not used in matrices. </param>
    /// <returns></returns>
    public static int ReadIndex(string explanationString, int maxIndex)
    {
        int index;
        do
        {
            Console.Write($"Input {explanationString}: ");
        } while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= maxIndex);
        return index;
    }

    /// <summary>
    /// Return minimum of two numbers.
    /// </summary>
    /// <param name="a"> First number. </param>
    /// <param name="b"> Second number. </param>
    /// <returns> Minimum. </returns>
    public static int Min(int a, int b) => (a < b ? a : b);
}
