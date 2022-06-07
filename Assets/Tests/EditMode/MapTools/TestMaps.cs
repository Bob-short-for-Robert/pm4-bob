using System.Collections.Generic;

namespace Tests.EditMode.MapTools
{
    public class TestMaps
    {
        protected static List<List<bool>> GetRectangleMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetTwoFloorOMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, false, true, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetTwoFloorFixedOMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetTwoFloorLMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, false, true, false, false, false, false, true},
                new List<bool>(){true, false, true, true, true, false, false, true},
                new List<bool>(){true, false, false, false, true, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetTwoFloorFixedLMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, false, false, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, false, false, true},
                new List<bool>(){true, true, true, true, true, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetThreeFloorMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, true, false, true},
                new List<bool>(){true, false, false, false, true, true, false, true},
                new List<bool>(){true, false, false, false, true, false, false, true},
                new List<bool>(){true, false, false, false, true, true, true, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, false, true, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        
        protected static List<List<bool>> GetThreeFloorFixedMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true},
                new List<bool>(){true, false, false, false, false, true, true, true},
                new List<bool>(){true, false, false, false, true, true, true, true},
                new List<bool>(){true, false, false, false, true, true, true, true},
                new List<bool>(){true, false, false, false, true, true, true, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, false, false, false, false, true},
                new List<bool>(){true, true, true, true, true, true, true, true}
            };
        }
        protected static List<List<bool>> GetComplexMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, false, true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, true , true , true , true},
                new List<bool>(){true, true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, true , true , true},
                new List<bool>(){true, false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, true , true , true},
                new List<bool>(){true, false, true , false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, false, true , true},
                new List<bool>(){true, false, true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, false, false, true},
                new List<bool>(){true, false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, false, true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, false, false, true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, true , false, false, true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, true , false, false, true},
                new List<bool>(){true, true , true , true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , false, false, false, true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , false, false, true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, false, true , true , false, false, false, false, true , false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , false, false, false, false, false, false, false, false, false, true , false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, false, true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, false, false, false, true , true , true , false, false, false, false, false, false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , false, true , true , true , true , false, false, false, false, true , true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, true , true , false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, true , false, true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, true , true , false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , false, true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , false, false, true , false, false, true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , false, true , false, true , false, true , true , true , false, true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, true , false, false, true , false, false, true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
            };
        }
        
        protected static List<List<bool>> GetComplexFixedMap()
        {
            return new List<List<bool>>()
            {
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , false, false, true , true , false, false, false, false, true , false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , false, false, false, false, false, false, false, false, false, true , false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , false, false, false, false, true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, false, false, false, true , true , true , false, false, false, false, false, false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , false, true , true , true , true , false, false, false, false, true , true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, true , true , false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, true , false, true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, true , true , false, true , false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, true , true , false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, false, false, false, false, false, false, false, false, true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , false, false, false, true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
                new List<bool>(){true, true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true},
            };
        }

        protected static (List<List<bool>> matrix, (int x, int y) size, int randomFillPrecent) GeneratorTestMap()
        {
            return  (new List<List<bool>>()
            {
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, false, false, true, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true, true, true },
                new List<bool>(){true, true, true, true, true, true, true, false, false, true, true, true, false, false, false, false, true, true, true, true },
                new List<bool>(){true, true, true, false, false, false, false, false, false, false, true, true, true, false, false, false, false, true, true, true },
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, true, true, true, false, false, false, false, true, true, true },
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true},
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true },
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true },
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true },
                new List<bool>(){true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true},
                new List<bool>(){true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true},
                new List<bool>(){true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true },
                new List<bool>(){true, true, true, true, true, true, false, false, true, true, false, false, false, false, false, false, false, true, true, true},
                new List<bool>(){true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
            }, (20, 20), 50);
        }
    }
}
