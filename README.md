Задание №2:
Юнит-тесты, добавления других фигур, вычисление площади в compile-time, проверка на прямоугольник(а точнее проверка на наличие прямого угла для фигуры) были добавлены.
Кратко описание:
Класс Figure является базовым для Circle, Triangle и OtherFigure. В базовом классе есть виртуальные методы для требуемого по заданию функционала, а
их переопределение написано в классах-наследниках для каждой отдельной фигуры.
В run-time`e можно через меню просить вводить название фигуры и используя switch/if конструкции создавать объект ссылочного типа Figure,
который будет указывать на нужную нам фигуру(данный функционал не был реализован, поскольку просили лишь библиотеку, однако всё же был добавлен файл, 
являющийся точкой входа в программу, с несколькими примерами работы программы).
Касательно compile-time: не совсем было понятно, что именно требовалось, поэтому были написаны конструкторы с разной сигнатурой(использовалось
только количество параметров), которые в зависимости от переданного количества аргументов создавали нужный нам класс, не указывая его явно,
а сам объект присваивался полю. В самих виртуальных методах просто возвращались реализации для ссылки на объект созданного класса.
Касательно добавления других фигур: был создан универсальный класс-наследник, при создании объекта которого нужно указать имя фигуры,
передать формулу, написанную с помощью интерполяции строк, список аргументов для формулы, а также bool`евскую переменную, сообщающую
о наличии о фигуры прямого угла.
Также были добавлены некоторые проверки на корректность ввода данных: радиус и стороны > 0 и сумма 2-х сторон строго больше 3-й, если
данные условия не выполняются, то будет выброшено исключение, которые нужно отловить, поэтому создание объектов рекомендуется делать
используя try-catch блоки.

Задание №3:
Созданы две таблицы(Products и Categories) с целочисленными первичными ключами, а также именами типа TEXT, которые не могут быть равны NULL.
Предварительно была создана и использовалась БД ProdCat. В таблице ProductsCategories были пары "продукт-категория", которые при SELECT запросы
выводили название продукта и категории, а если значения в совместной таблице не было, то брали имя продукта и NULL в качестве имени категории.