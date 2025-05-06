// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaFinanceiro } from '@/app/GerAdv_TS/AgendaFinanceiro/Interfaces/interface.AgendaFinanceiro';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface AgendaFinanceiroFormProps {
    agendafinanceiroData: IAgendaFinanceiro;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaFinanceiroForm: React.FC<AgendaFinanceiroFormProps> = ({
    agendafinanceiroData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
            const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
            const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
            const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.advogado = getParamFromUrl("advogados");
  }
}
 
if (getParamFromUrl("funcionarios") > 0) {
  funcionariosApi
    .getById(getParamFromUrl("funcionarios"))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.funcionario = getParamFromUrl("funcionarios");
  }
}
 
if (getParamFromUrl("tipocompromisso") > 0) {
  tipocompromissoApi
    .getById(getParamFromUrl("tipocompromisso"))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.tipocompromisso = getParamFromUrl("tipocompromisso");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.usuario = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("prepostos") > 0) {
  prepostosApi
    .getById(getParamFromUrl("prepostos"))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendafinanceiroData.id === 0) {
    agendafinanceiroData.preposto = getParamFromUrl("prepostos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.advogado = e.id;
                      };
 const addValorFuncionario = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.funcionario = e.id;
                      };
 const addValorTipoCompromisso = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.tipocompromisso = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.cliente = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.justica = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.processo = e.id;
                      };
 const addValorUsuario = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.usuario = e.id;
                      };
 const addValorPreposto = (e: any) => {
                        if (e?.id>0)
                        agendafinanceiroData.preposto = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('AgendaFinanceiroForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`AgendaFinanceiroForm-${agendafinanceiroData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendafinanceiroData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaFinanceiroForm-${agendafinanceiroData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="idcob"
label="IDCOB"
className="inputIncNome"
name="idcob"
value={agendafinanceiroData.idcob}
onChange={onChange}               
/>

<Input
type="text"
id="idne"
label="IDNE"
className="inputIncNome"
name="idne"
value={agendafinanceiroData.idne}
onChange={onChange}               
/>

<Input
type="text"
id="prazoprovisionado"
label="PrazoProvisionado"
className="inputIncNome"
name="prazoprovisionado"
value={agendafinanceiroData.prazoprovisionado}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={agendafinanceiroData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="oculto"
label="Oculto"
className="inputIncNome"
name="oculto"
value={agendafinanceiroData.oculto}
onChange={onChange}               
/>

<Input
type="text"
id="cartaprecatoria"
label="CartaPrecatoria"
className="inputIncNome"
name="cartaprecatoria"
value={agendafinanceiroData.cartaprecatoria}
onChange={onChange}               
/>

<Input
type="text"
id="repetirdias"
label="RepetirDias"
className="inputIncNome"
name="repetirdias"
value={agendafinanceiroData.repetirdias}
onChange={onChange}               
/>

<Input
type="text"
id="hrfinal"
label="HrFinal"
className="inputIncNome"
name="hrfinal"
value={agendafinanceiroData.hrfinal}
onChange={onChange}               
/>

<Input
type="text"
id="repetir"
label="Repetir"
className="inputIncNome"
name="repetir"
value={agendafinanceiroData.repetir}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <AdvogadosComboBox
            name={'advogado'}
            value={agendafinanceiroData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

<Input
type="text"
id="eventogerador"
label="EventoGerador"
className="inputIncNome"
name="eventogerador"
value={agendafinanceiroData.eventogerador}
onChange={onChange}               
/>

<Input
type="text"
id="eventodata"
label="EventoData"
className="inputIncNome"
name="eventodata"
value={agendafinanceiroData.eventodata}
onChange={onChange}               
/>

            <FuncionariosComboBox
            name={'funcionario'}
            value={agendafinanceiroData.funcionario}
            setValue={addValorFuncionario}
            label={'Colaborador'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={agendafinanceiroData.data}
onChange={onChange}               
/>

<Input
type="text"
id="eventoprazo"
label="EventoPrazo"
className="inputIncNome"
name="eventoprazo"
value={agendafinanceiroData.eventoprazo}
onChange={onChange}               
/>

<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={agendafinanceiroData.hora}
onChange={onChange}               
/>

<Input
type="text"
id="compromisso"
label="Compromisso"
className="inputIncNome"
name="compromisso"
value={agendafinanceiroData.compromisso}
onChange={onChange}               
/>

            <TipoCompromissoComboBox
            name={'tipocompromisso'}
            value={agendafinanceiroData.tipocompromisso}
            setValue={addValorTipoCompromisso}
            label={'Tipo Compromisso'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={agendafinanceiroData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

</div><div className="grid-container">        
<Input
type="text"
id="ddias"
label="DDias"
className="inputIncNome"
name="ddias"
value={agendafinanceiroData.ddias}
onChange={onChange}               
/>

<Input
type="text"
id="dias"
label="Dias"
className="inputIncNome"
name="dias"
value={agendafinanceiroData.dias}
onChange={onChange}               
/>

<InputCheckbox label="Liberado" name="liberado" checked={agendafinanceiroData.liberado} onChange={onChange} />
<InputCheckbox label="Importante" name="importante" checked={agendafinanceiroData.importante} onChange={onChange} />
<InputCheckbox label="Concluido" name="concluido" checked={agendafinanceiroData.concluido} onChange={onChange} />
 
            <AreaComboBox
            name={'area'}
            value={agendafinanceiroData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={agendafinanceiroData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={agendafinanceiroData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="idhistorico"
label="IDHistorico"
className="inputIncNome"
name="idhistorico"
value={agendafinanceiroData.idhistorico}
onChange={onChange}               
/>

<Input
type="text"
id="idinsprocesso"
label="IDInsProcesso"
className="inputIncNome"
name="idinsprocesso"
value={agendafinanceiroData.idinsprocesso}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <OperadorComboBox
            name={'usuario'}
            value={agendafinanceiroData.usuario}
            setValue={addValorUsuario}
            label={'Operador'}
            />

            <PrepostosComboBox
            name={'preposto'}
            value={agendafinanceiroData.preposto}
            setValue={addValorPreposto}
            label={'Prepostos'}
            />

<Input
type="text"
id="quemid"
label="QuemID"
className="inputIncNome"
name="quemid"
value={agendafinanceiroData.quemid}
onChange={onChange}               
/>

<Input
type="text"
id="quemcodigo"
label="QuemCodigo"
className="inputIncNome"
name="quemcodigo"
value={agendafinanceiroData.quemcodigo}
onChange={onChange}               
/>

<Input
type="text"
id="status"
label="Status"
className="inputIncNome"
name="status"
value={agendafinanceiroData.status}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={agendafinanceiroData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="compromissohtml"
label="CompromissoHTML"
className="inputIncNome"
name="compromissohtml"
value={agendafinanceiroData.compromissohtml}
onChange={onChange}               
/>

<Input
type="text"
id="decisao"
label="Decisao"
className="inputIncNome"
name="decisao"
value={agendafinanceiroData.decisao}
onChange={onChange}               
/>

<InputCheckbox label="Revisar" name="revisar" checked={agendafinanceiroData.revisar} onChange={onChange} />
<InputCheckbox label="RevisarP2" name="revisarp2" checked={agendafinanceiroData.revisarp2} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="sempre"
label="Sempre"
className="inputIncNome"
name="sempre"
value={agendafinanceiroData.sempre}
onChange={onChange}               
/>

<Input
type="text"
id="prazodias"
label="PrazoDias"
className="inputIncNome"
name="prazodias"
value={agendafinanceiroData.prazodias}
onChange={onChange}               
/>

<Input
type="text"
id="protocolointegrado"
label="ProtocoloIntegrado"
className="inputIncNome"
name="protocolointegrado"
value={agendafinanceiroData.protocolointegrado}
onChange={onChange}               
/>

<Input
type="text"
id="datainicioprazo"
label="DataInicioPrazo"
className="inputIncNome"
name="datainicioprazo"
value={agendafinanceiroData.datainicioprazo}
onChange={onChange}               
/>

<InputCheckbox label="UsuarioCiente" name="usuariociente" checked={agendafinanceiroData.usuariociente} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 