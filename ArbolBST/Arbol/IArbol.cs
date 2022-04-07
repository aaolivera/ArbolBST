using System;

namespace ArbolBST.Arbol
{
    interface IArbol<T> where T : IComparable<T>
    {
        void Insertar(T nodo);
        void InsertarRecursivo(T dato);
        bool Existe(T clave);
        bool ExisteRecursivo(T clave);
        int Altura();

        public int RecorridosEnUltimaBusqueda { get; }
        public int Cantidad { get; }
    }
}
