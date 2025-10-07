# API

## Введение
Данный проект представляет собой простой **Web API на ASP.NET Core**, позволяющий работать со списком имён.  
API даёт возможность просматривать, добавлять, изменять и удалять имена, а также выполнять сортировку и получать статистику по записям.  

---

## Необходимые условия
Для запуска проекта вам понадобятся:
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) или новее  
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Microsoft Visual Studio Code](https://code.visualstudio.com/)
- Браузер (автоматически подключается)  

---

## 🚀 Установка и запуск
1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/Virus903/Api.git
   cd - Api
   ```

2. Восстановите зависимости:
   ```bash
   dotnet restore
   ```

3. Запустите проект:
   ```bash
   dotnet run
   ```

4. Откройте браузер и перейдите по адресу:  

   ```
   https://localhost:7124/swagger
   ```

---

## 📌 Основные методы
- `GET /names` — получить все имена  
   - Доп. параметр: `sortStrategy`  
     - `null` — без сортировки  
     - `1` — сортировка по возрастанию  
     - `-1` — сортировка по убыванию  

- `GET /names/{index}` — получить имя по индексу  
- `GET /names/count/{name}` — получить количество вхождений имени  
- `POST /names?name=ИМЯ` — добавить имя  
- `PUT /names/{index}?name=ИМЯ` — обновить имя по индексу  
- `DELETE /names/{index}` — удалить имя  

---

## Галерея
![л](https://github.com/Virus903/Api/blob/main/Api.JPG)

## Итог
Проект демонстрирует базовую работу с **API, подходит для обучения основам серверного взаимодействия и управления данными.
