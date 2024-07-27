using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaDao
{
    public class DataContext
    {
        private static BibliotecaDataSet _data;

        public static BibliotecaDataSet getBibliotecaDataset()
        {
            if (_data == null)
            {
                _data = new BibliotecaDataSet();
            }
            return _data;
        }

        private DataContext() { }
    }
}
