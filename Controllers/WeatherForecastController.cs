using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace First_Api.Controllers
{
    // ������� ���������, ��� ���� ����� � ���������� API
    [ApiController]

    // ���������� ������� ������� ��� ���������� ����� �����������
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        // ����������� ������ ���� � �������� ������ ��� API
        private static List<string> names = new List<string> { "Victor", "Oleg", "Alersandr", "Ruslan", "Ivan", "Kirill" };

        // ���������� GET-�������� ��� �������������� �����, ���������� ��� �����
        // � ������������ ���������� ����� �������� sortStrategy
        [HttpGet]
        public IActionResult GetAll(int? sortStrategy = null)
        {
            // ���� �������� ���������� �� ������, ���������� ������ ��� ����
            if (sortStrategy == null) return Ok(names);

            // ���� sortStrategy == 1, ���������� �� �������� �� �����������
            if (sortStrategy == 1) return Ok(new List<string>(names).OrderBy(x => x));

            // ���� sortStrategy == -1, ���������� �� �������� �� ��������
            if (sortStrategy == -1) return Ok(new List<string>(names).OrderByDescending(x => x));

            // ���� �������� sortStrategy ������������ � ���������� ������ 400
            return BadRequest("������������ �������� ��������� sortStrategy");
        }

        // ���������� GET-������� �� �������, �������� /Names/2
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            // ��������, ��� ������ ������ ���������� ������
            if (index < 0 || index >= names.Count) return BadRequest("������������ ������");
            // ���������� ��� �� �������
            return Ok(names[index]);
        }

        // ���������� GET-������� ��� �������� ���������� ��������� �����
        // �������� /Names/count/Oleg
        [HttpGet("count/{name}")]
        public IActionResult CountByName(string name)
        {
            // ������� ���������� ��������� �����, ������������������
            int count = names.Count(n => n.ToLower() == name.ToLower());
            return Ok(count);
        }

        // ���������� POST-������� ��� ���������� ������ �����
        // ��� ���������� ��� �������� � ���� ������� ��� ��� �������� ������ �������
        [HttpPost]
        public IActionResult Add(string name)
        {
            // ��������, ��� ��� �� ������ ��� ����������
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("��� �� ����� ���� ������");
            // ���������� ����� � ������
            names.Add(name);
            // ������� ������������ ������
            return Ok(names);
        }

        // ���������� PUT-������� ��� ���������� ����� �� �������
        // ����� name ���������� ��� ��, ��� � ��� ����������
        [HttpPut("{index}")]
        public IActionResult Update(int index, string name)
        {
            // �������� ������������ �������
            if (index < 0 || index >= names.Count) return BadRequest("������������ ������");
            // ��������, ��� ��� �� ������
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("��� �� ����� ���� ������");
            // ���������� ����� �� �������
            names[index] = name;
            // ������� ������������ ������
            return Ok(names);
        }

        // ���������� DELETE-������� ��� �������� ����� �� �������
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            // �������� �������
            if (index < 0 || index >= names.Count) return BadRequest("������������ ������");
            // �������� �������� �� �������
            names.RemoveAt(index);
            // ������� ������������ ������
            return Ok(names);
        }
    }
}
