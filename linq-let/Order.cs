using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetExample
{
    public record Order(string Number, List<OrderLine> OrderLines);
    public record OrderLine(string Product, int Quantity, decimal Price);

    

}
