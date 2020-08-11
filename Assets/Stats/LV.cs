using UnityEngine;

namespace Stats
{
    public class Lv
    {
        private int _lv = 1, _exp, _maxExp = 10;
        
        
        public int GetLV()
        {
            return _lv;
        }
        
        public int GetExp()
        {
            return _exp;
        }
        
        public int GetMaxExp()
        {
            return _maxExp;
        }
        
        
    }
}
