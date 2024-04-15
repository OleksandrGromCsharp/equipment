using equipment.Entities;

namespace equipment.Infrastructure
{
    
    internal static class Generation
    {
        enum Symbol{ E, F, G, H, I, K, L, N, O, P, Q, R, S, T, U, W, X, Y }
        /// <summary>
        /// Генерація номера устаткування
        /// </summary>
        /// <param name="typeEquipment">Тип устаткування</param>
        /// <param name="producingCountry">Країна виробник устаткування</param>
        /// <param name="inventoryNumber">Інвентарний номер устаткування</param>
        /// <returns></returns>
        internal static string? EquipmentNumber(EnumTypeEquipment typeEquipment, EnumProducingCountry producingCountry, int inventoryNumber)
        {
            if (inventoryNumber is 0)
                return null;
            
            string strNumber = inventoryNumber.ToString("D9");

            var codeType = typeEquipment switch
            {
                EnumTypeEquipment.MachineryEntity => 11,
                EnumTypeEquipment.ComputerEntity => 12,
                EnumTypeEquipment.ComputerPeripheralsEntity => 13,
                EnumTypeEquipment.NetworkEquipmentEntity => 14,
                _ => 10,
            };

            _ = int.TryParse(strNumber[^3..^1], out int codeSymbol);

            _ = int.TryParse(codeSymbol.ToString()[..1], out int i);
            codeSymbol = i;
            _ = int.TryParse(codeSymbol.ToString()[1..], out i);

            codeSymbol += i;

            _ = int.TryParse(strNumber[^1..], out i);

            return codeType.ToString() + ((producingCountry is 0) ? "NN" : producingCountry) + strNumber[..6] + (Symbol)codeSymbol + i.ToString();
        }
    }
}
