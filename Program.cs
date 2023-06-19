﻿


//Этот код создает игру морской бой для консоли, где компьютер размещает корабли
//на поле и игрок должен попытаться потопить их, стреляя по координатам клеток.



int[,] board = new int[10, 10]; // Создание двумерного массива для хранения поля игры

// Размещение кораблей на поле игры
PlaceShip(4, board); // Корабль длиной 4 клетки
PlaceShip(3, board); // Корабль длиной 3 клетки
PlaceShip(2, board); // Корабль длиной 2 клетки
PlaceShip(1, board); // Корабль длиной 2 клетки



int attempts = 0; // Количество попыток
int hits = 0; // Количество попаданий

// Игра продолжается до тех пор, пока не будут потоплены все корабли
while (hits < 10)
{
    // Вывод на экран текущего состояния поля игры
    Console.WriteLine("Battleship - ход " + (attempts + 1));
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            string state = " ";
            if (board[i, j] == -1) state = "*"; // Попадание
            else if (board[i, j] == 0) state = "-"; // Промах
            Console.Write(state + " ");
        }
        Console.WriteLine();
    }

    // Запрос координаты выстрела
    Console.WriteLine("Введите координаты x и y: ");
    int x = Convert.ToInt32(Console.ReadLine());
    int y = Convert.ToInt32(Console.ReadLine());

    // Обработка выстрела
    if (board[x, y] == -1 || board[x, y] == 0)
    {
        Console.WriteLine("Попадание!");
        board[x, y] = -1; // Пометка попадания на поле игры
        hits++; // Увеличение счетчика попаданий
    }
    else Console.WriteLine("Промах!");

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
    int x = 0;
    int y = 0;
    while (true)
    {
        x = rand.Next(10);
        y = rand.Next(10);
        if (board[x, y] == 0) break; // Если клетка свободна, то корабль может быть размещен здесь
    }

    // Размещение корабля
    for (int i = 0; i < size; i++)
    {
        if (horizontal) board[x, y + i] = 1; // Горизонтальное расположение
        else board[x + i, y] = 1; // Вертикальное расположение
    }
}


