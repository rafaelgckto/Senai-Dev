﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MedicalGroup.WebApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public DateTime DtAgendamento { get; set; }
        public string Descricao { get; set; }
        public int IdSituacao { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
