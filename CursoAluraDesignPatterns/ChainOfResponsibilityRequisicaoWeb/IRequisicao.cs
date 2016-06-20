﻿using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public interface IRequisicao
    {
        IRequisicao ProximaRequisicao { set; }

        string Requisitar(Conta conta, FormatoRequisicao formato);
    }
}
