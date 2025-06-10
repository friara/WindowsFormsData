using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public class MaterialCalculator
    {
        public static long materialCalculate(int productTypeId,
                                     int materialTypeId,
                                     int productCount,
                                     double productParametr1,
                                     double productParametr2)
        {
            
            if (productParametr1 <= 0 || productParametr2 <= 0 || productCount < 0)
            {
                return -1;
            }


            FrichProbnicDemoContext context = FrichProbnicDemoContext.Instance();

            long materialCount = -1;

            
            var productType = context.ProductTypes.Find(productTypeId);
            var materialType = context.MaterialTypes.Find(materialTypeId);

            
            if (productType == null || materialType == null ||
                productType.ProductTypeRate <= 0 || materialType.DefectivePercent < 0)
            {
                return -1;
            }
            try
            {
                double productTypeRate = productType.ProductTypeRate;
                double materialDefectRate = materialType.DefectivePercent;

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
