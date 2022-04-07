using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolBST.Arbol
{
    class Nodo<T>
    {
        public Nodo<T> HijoIzquierdo { get; set; }
        public Nodo<T> HijoDerecho { get; set; }

        public T Dato { get; set; }

    }
}
