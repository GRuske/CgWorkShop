﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Cliente
    {
        //Declarando os atributos da Classe: Cliente
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }
}
