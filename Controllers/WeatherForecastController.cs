using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace First_Api.Controllers
{
    // Атрибут указывает, что этот класс — контроллер API
    [ApiController]

    // Определяет базовый маршрут для эндпоинтов этого контроллера
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        // Статический список имен — источник данных для API
        private static List<string> names = new List<string> { "Victor", "Oleg", "Alersandr", "Ruslan", "Ivan", "Kirill" };

        // Обработчик GET-запросов без дополнительных путей, возвращает все имена
        // с возможностью сортировки через параметр sortStrategy
        [HttpGet]
        public IActionResult GetAll(int? sortStrategy = null)
        {
            // Если параметр сортировки не указан, возвращает список как есть
            if (sortStrategy == null) return Ok(names);

            // Если sortStrategy == 1, сортировка по алфавиту по возрастанию
            if (sortStrategy == 1) return Ok(new List<string>(names).OrderBy(x => x));

            // Если sortStrategy == -1, сортировка по алфавиту по убыванию
            if (sortStrategy == -1) return Ok(new List<string>(names).OrderByDescending(x => x));

            // Если значение sortStrategy некорректное — возвращает ошибку 400
            return BadRequest("Некорректное значение параметра sortStrategy");
        }

        // Обработчик GET-запроса по индексу, например /Names/2
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            // Проверка, что индекс внутри допустимых границ
            if (index < 0 || index >= names.Count) return BadRequest("Некорректный индекс");
            // Возвращает имя по индексу
            return Ok(names[index]);
        }

        // Обработчик GET-запроса для подсчета количества вхождений имени
        // например /Names/count/Oleg
        [HttpGet("count/{name}")]
        public IActionResult CountByName(string name)
        {
            // Подсчет количества вхождений имени, регистронезависимо
            int count = names.Count(n => n.ToLower() == name.ToLower());
            return Ok(count);
        }

        // Обработчик POST-запроса для добавления нового имени
        // имя передается как параметр в теле запроса или как параметр строки запроса
        [HttpPost]
        public IActionResult Add(string name)
        {
            // Проверка, что имя не пустое или пробельное
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Имя не может быть пустым");
            // Добавление имени в список
            names.Add(name);
            // Возврат обновленного списка
            return Ok(names);
        }

        // Обработчик PUT-запроса для обновления имени по индексу
        // новый name передается так же, как и при добавлении
        [HttpPut("{index}")]
        public IActionResult Update(int index, string name)
        {
            // Проверка корректности индекса
            if (index < 0 || index >= names.Count) return BadRequest("Некорректный индекс");
            // Проверка, что имя не пустое
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Имя не может быть пустым");
            // Обновление имени по индексу
            names[index] = name;
            // Возврат обновленного списка
            return Ok(names);
        }

        // Обработчик DELETE-запроса для удаления имени по индексу
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            // Проверка индекса
            if (index < 0 || index >= names.Count) return BadRequest("Некорректный индекс");
            // Удаление элемента по индексу
            names.RemoveAt(index);
            // Возврат обновленного списка
            return Ok(names);
        }
    }
}
