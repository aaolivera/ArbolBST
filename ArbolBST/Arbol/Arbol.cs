using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolBST.Arbol
{
    public class Arbol<T> : IArbol<T> where T : IComparable<T>
    {
        private Nodo<T> raiz = null;
        private int cantidadDeNodos = 0;
        private int nodosRecorridosEnUltimaBusqueda = 0;

        public int RecorridosEnUltimaBusqueda { get { return nodosRecorridosEnUltimaBusqueda; } }
        public int Cantidad { get { return cantidadDeNodos; } }
        public int Altura()
        {
            if (raiz == null) return 0;
            return Altura(raiz) - 1;
        }

        private int Altura(Nodo<T> raiz)
        {
            if (raiz == null) return 0;
            return 1;
            //return 1 + Math.Max(Altura(raiz.HijoDerecho), Altura(raiz.HijoIzquierdo));
        }

        public bool Existe(T dato)
        {
            nodosRecorridosEnUltimaBusqueda = 0;
            var curr = raiz;

            while (curr != null)
            {
                nodosRecorridosEnUltimaBusqueda++;
                if (dato.CompareTo(curr.Dato) == 0)
                {
                    return true;
                }
                if (dato.CompareTo(curr.Dato) < 0)
                    curr = curr.HijoIzquierdo;
                else
                    curr = curr.HijoDerecho;
            }
            return false;
        }

        public bool ExisteRecursivo(T clave)
        {
            nodosRecorridosEnUltimaBusqueda = 0;
            return Existe(raiz, clave);
        }

        private bool Existe(Nodo<T> raiz, T clave)
        {
            nodosRecorridosEnUltimaBusqueda++;
            if (raiz == null)
            {
                return false;
            }
            if (raiz.Dato.CompareTo(clave) == 0)
            {
                return true;
            }
            if (clave.CompareTo(raiz.Dato) < 0)
            {
                return Existe(raiz.HijoIzquierdo, clave);
            }
            else
            {
                return Existe(raiz.HijoDerecho, clave);
            }
        }

        public void Insertar(T dato)
        {
            //raiz = Insertar(raiz, new Nodo<T> { Dato = dato });

            var toinsert = new Nodo<T> { Dato = dato };
            var curr = raiz;
            Nodo<T> prev = null;

            while (curr != null)
            {
                prev = curr;
                if (dato.CompareTo(curr.Dato) < 0)
                    curr = curr.HijoIzquierdo;
                else
                    curr = curr.HijoDerecho;
            }
            
            if (prev == null)
            {
                prev = toinsert;
                raiz = prev;
                cantidadDeNodos++;
            }
            else if (dato.CompareTo(prev.Dato) < 0)
            {
                cantidadDeNodos++;
                prev.HijoIzquierdo = toinsert;
            }

            else if(dato.CompareTo(prev.Dato) > 0)
            {
                cantidadDeNodos++;
                prev.HijoDerecho = toinsert;
            }
        }
        public void InsertarRecursivo(T dato)
        {
            raiz = Insertar(raiz, new Nodo<T> { Dato = dato });
        }

        private Nodo<T> Insertar(Nodo<T> raiz, Nodo<T> nodoAInsertar)
        {
            if(raiz == null)
            {
                cantidadDeNodos++;
                return nodoAInsertar;
            }
            if (nodoAInsertar.Dato.CompareTo(raiz.Dato) < 0)
            {
                raiz.HijoIzquierdo = Insertar(raiz.HijoIzquierdo, nodoAInsertar);
            }
            else if (nodoAInsertar.Dato.CompareTo(raiz.Dato) > 0)
            {
                raiz.HijoDerecho = Insertar(raiz.HijoDerecho, nodoAInsertar);
            }
            return raiz;
        }
    }
}
