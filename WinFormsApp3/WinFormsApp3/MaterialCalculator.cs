using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

namespace WinFormsApp3
{
    public class MaterialCalculator
    {
        public static long materialCalculate(int productTypeId, 
                                     int materialTypeId, 
                                     int productCount, 
                                     double productParametr1,
                                     double productParametr2)
        {
            // Проверка входных параметров
            if (productParametr1 <= 0 || productParametr2 <= 0 || productCount < 0)
            {
                return -1;
            }


            Partners03Context context = Partners03Context.Instance();

            long materialCount = -1;

            // Получаем данные из БД
            var productType = context.ProductTypes.Find(productTypeId);
            var materialType = context.MaterialTypes.Find(materialTypeId);

            // Проверка существования записей и коэффициентов
            if (productType == null || materialType == null ||
                productType.ProductRate <= 0 || materialType.DefectiveRate < 0)
            {
                return -1;
            }
            try
            {
                double productTypeRate = productType.ProductRate;
                double materialDefectRate = materialType.DefectiveRate;

                materialCount = (long)Math.Ceiling((productCount * productParametr1 * productParametr2 * productTypeRate * (1 + materialDefectRate)));

                if (materialCount > long.MaxValue) return -1;
            }
            catch (OverflowException)
            {
                return -1;
            }

            return materialCount;
        }
    }
}
