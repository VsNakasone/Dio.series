using System;
using System.Collections.Generic;
using Dio.series.Classes;
using Dio.series.Interfaces;
using static Dio.series.SerieRepositorio;

namespace Dio.series
{
    public class SerieRepositorio : IRepository<Serie>
    { 
        private int entradaGenero;
        
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }
        public List<Serie> Lista()
        {
            return listaSerie;
        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }    
        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }            

       public int EntradaGenero(int entrada)
       {
           this.entradaGenero = entrada;
           return  entradaGenero;
       }

    public interface IRepository<T>
    {
    }
    }
}