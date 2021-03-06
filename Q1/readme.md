#  Задание

Напишите библиотеку для поставки внешним клиентам, которая умеет вычислять
площадь круга по радиусу и треугольника по трем сторонам. Дополнительно оценим:
Юнит-тесты Легкость добавления других фигур Вычисление площади фигуры без
знания типа фигуры Проверку на то, является ли треугольник прямоугольным.

# Замечания о реализации

Полноценная реализация такой библиотеки сильно зависит от потребностей.

Учитывая ограниченность времени, ограниченную точность вычислений с плавающей точкой, а также отсутствие требований со стороны потребителя, я выбрал API сходный с тем, что предоставляет .net в классе Math.

Плюсы подхода
* Знаком разработчикам по стандартному классу [System.Math]
* Позволяет проводить нетребовательные к точности вычисления в типовых приложениях без дополнительного инфраструктурного кода (как если бы это была библиотека для вычислений в шейдарах на GPU или численного моделирования).
* Легко расширяется добавлением новых методов и классов.

Минусы
* Предельная точность вычислений и ограничивает количество фактически предствимых через API объектов
* Она же ограничивает точность и абсолютную корректность результатов. В частности проверка треугольника на "прямоугольность" допускает лишь вероятностную оценку (ширина интервала отклонения задается параметром) 
* Тесты не могут проверить абсолютную корректность работы во всех случаях, т.к. часть математически верных ситуаций невыразимы в рамках выбранной системы типов.

От некоторых минусов можно избавиться переходом к другому способу описания объектов, но нужно оговориться, что построение универсально точного метода - очень трудоемко. И не везде нужно.

Одно из решений - абстрагировать класс фигуры. Использовать разные конструкторы для описния фигур различными способами (тот же треугольник можно задать стороной и углами, а круг - его площадью). 
Тогда в зависимости от способа задания фигуры те или иные алгоритмы будут давать лучшую точность.

Но это уже слишком далеко от тестового задания.
