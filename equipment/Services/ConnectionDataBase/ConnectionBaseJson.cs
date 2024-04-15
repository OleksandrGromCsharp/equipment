using System.IO;
using System.Text.Json;
using equipment.Entities.Interfaces;
using equipment.Services.ConnectionDataBase.Interface;

namespace equipment.Services.ConnectionDataBase
{
    internal class ConnectionBaseJson<T> : IConnectionDataBase<T> where T : IEntities
    {
        /// <summary>
        /// Місцерозташування бази даних технологічного обладнання
        /// </summary>
        private static readonly string _pathMachinery = Path.Combine(Directory.GetCurrentDirectory(), "Data", "equipment.json");

        /// <summary>
        /// Місцерозташування бази даних комп'ютерів
        /// </summary>
        private static readonly string _pathComputer = Path.Combine(Directory.GetCurrentDirectory(), "Data", "computer.json");

        /// <summary>
        /// Місцерозташування бази даних комп'ютерної периферії
        /// </summary>
        private static readonly string _pathComputerPeripherals = Path.Combine(Directory.GetCurrentDirectory(), "Data", "peripherals.json");

        /// <summary>
        /// Місцерозташування бази даних мережевого обладнання
        /// </summary>
        private static readonly string _pathNetworkEquipment = Path.Combine(Directory.GetCurrentDirectory(), "Data", "network.json");

        /// <summary>
        /// Місцерозташування бази даних
        /// </summary>
        private readonly string _pathJson;

        /// <summary>
        /// Параметр запису JSON (стуктурування)
        /// </summary>
        private readonly JsonSerializerOptions writeOptions = new() { WriteIndented = true };

        /// <summary>
        /// Параметр зчитування JSON (забирає лишні коми)
        /// </summary>
        private readonly JsonSerializerOptions readOptions = new() { AllowTrailingCommas = true };

        /// <summary>
        /// Створення рядка даних
        /// </summary>
        /// <param name="entities">Список екземплярів колекції типом IEnumerable<typeparamref name="T"/></param>
        /// <returns>JSON-рядок даних, що надані</returns>
        /// <exception cref="NotSupportedException"></exception>
        private string? Serialize(IEnumerable<T> entities)
        {
            try { return JsonSerializer.Serialize(entities, writeOptions); }
            catch (NotSupportedException) { throw new NotSupportedException("There are no compatible JsonConverter objects for TValue or its serializable members"); }
        }

        /// <summary>
        /// Зчитування JSON файлу із даними
        /// </summary>
        /// <returns>Список екземплярів JSON файлу у вигляді List<typeparamref name="T"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        private List<T>? Deserialize()
        {
            try { return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_pathJson), readOptions); }
            catch (ArgumentNullException) { throw new ArgumentNullException("JSON is null"); }
            catch (JsonException) { throw new JsonException("Invalid JSON -or- TValue is not compatible with JSON -or- There is more than one JSON value left in the row."); }
            catch (NotSupportedException) { throw new NotSupportedException("There are no compatible JsonConverter objects for TValue or its serializable members"); }
        }

        /// <summary>
        /// Завантаження даних з бази даних
        /// </summary>
        /// <param name="entities">Список колекції у вигляді List<typeparamref name="T"/></param>
        /// <param name="exception">Текст помилок при роботі з базою даних</param>
        /// <returns>bool значення виконаної процедури</returns>
        public bool LoadingEntities(ref List<T> entities, ref string? exception)
        {
            if (!File.Exists(_pathJson))
            {
                exception = $"The database {typeof(T)} file is missing";
                return false;
            }

            try
            {
                var _entities = Deserialize();
                if (entities != null)
                    entities = _entities;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                File.Move(_pathJson, Path.Combine(Directory.GetCurrentDirectory(), "Data", DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + "_error_equipment.json"));
                return false;
            }
        }

        /// <summary>
        /// Оновлення даних в базі даних
        /// </summary>
        /// <param name="entities">Список колекції у вигляді List<typeparamref name="T"/></param>
        /// <param name="exception">Текст помилок при роботі з базою даних</param>
        /// <returns>bool значення виконаної процедури</returns>
        public bool RefreshEntities(List<T> entities, ref string? exception)
        {
            if (!File.Exists(_pathJson))
            { using FileStream fileStream = File.Create(_pathJson); }

            try
            {
                var resultSerialize = Serialize(entities);
                if (resultSerialize != "")
                    File.WriteAllText(_pathJson, resultSerialize);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Підключення до бази даних та визначення типу бази даних
        /// </summary>
        /// <param name="nameTypeEquipment">Тип екземплярів колекції</param>
        public ConnectionBaseJson(string nameTypeEquipment = null)
        {
            switch (nameTypeEquipment)
            {
                case "MachineryEntity":
                    _pathJson = _pathMachinery;
                    break;
                case "ComputerEntity":
                    _pathJson = _pathComputer;
                    break;
                case "ComputerPeripheralsEntity":
                    _pathJson = _pathComputerPeripherals;
                    break;
                case "NetworkEquipmentEntity":
                    _pathJson = _pathNetworkEquipment;
                    break;
                    default: break;

            }
        }
    }
}
