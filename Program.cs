﻿


//Этот код создает игру морской бой для консоли, где компьютер размещает корабли
//на поле а игрок должен попытаться потопить их, стреляя по координатам клеток.



int[,] board = new int[10, 10]; // Создание двумерного массива для хранения поля игры

int x, y;

// Размещение кораблей на поле игры
PlaceShip(4, board); // Корабль длиной 4 клетки
PlaceShip(3, board); // Корабль длиной 3 клетки
PlaceShip(2, board); // Корабль длиной 2 клетки
PlaceShip(1, board); // Корабль длиной 1 клетки



int attempts = 0; // Количество попыток
int hits = 0; // Количество попаданий

// Игра продолжается до тех пор, пока не будут потоплены все корабли
while (hits < 10)
{
    // Вывод на экран текущего состояния поля игры
    Console.WriteLine("Battleship - ход " + (attempts + 1));
    for (int i = 1; i <= 10; i++)
    {
        for (int j = 1; j <= 10; j++)
        {
            string state = " ";
            if (board[i - 1, j - 1] == 9) state = "x"; // Промах
            if (board[i - 1, j - 1] == 1) state = "-"; // корабль
            if (board[i - 1, j - 1] == 0) state = "-"; // пустая клетка
            if (board[i - 1, j - 1] == -1) state = "*"; // Попадание

            Console.Write(state + " ");
        }
        Console.WriteLine();
    }


    // Запрос координаты выстрела
    while (true)
    {
        Console.WriteLine("Введите координаты x и y (от 1 до 10): ");
        try
        {
            y = Convert.ToInt32(Console.ReadLine());
            x = Convert.ToInt32(Console.ReadLine());
            // Проверяем что координаты в диапазоне от 1 до 10 включително
            if (x < 1 || x > 10 || y < 1 || y > 10)
                throw new Exception("Координаты должны быть в диапазоне от 1 до 10 включительно!");
            x--; // Уменьшаем на 1, чтобы получить индекс в массиве
            y--; // Уменьшаем на 1, чтобы получить индекс в массиве
            break; // Если координаты правильные, выходим из цикла
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }


    // Обработка выстрела
    if (!(board[x, y] == -1 || board[x, y] == 0 || board[x, y] == 9))
    {
        Console.WriteLine("Попадание!");
        board[x, y] = -1; // Пометка попадания на поле игры
        hits++; // Увеличение счетчика попаданий
    }
    else
    {
        Console.WriteLine("Промах!");
        board[x, y] = 9;
    }

    attempts++; // Увеличение количества попыток
}

Console.WriteLine("Игра окончена. Вы сделали " + attempts + " попыток.");


// Размещение корабля на поле игры
static void PlaceShip(int size, int[,] board)
{
    Random rand = new Random(); // Генератор случайных чисел

    // Определение ориентации корабля (горизонтальное или вертикальное расположение)
    bool horizontal = rand.Next(2) == 1;

    // Определение начальной позиции корабля
    int x, y;
    while (true)
    {
        x = rand.Next(10 - size);
        y = rand.Next(10 - size);
        if (board[x, y] == 0) break; // Если клетка свободна, то корабль может быть размещен здесь
    }

    // Размещение корабля
    for (int i = 0; i < size; i++)
    {
        if (horizontal) board[x, y + i] = 1; // Горизонтальное расположение
        else board[x + i, y] = 1; // Вертикальное расположение
    }
}


