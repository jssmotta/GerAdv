"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
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

interface AgendaFormProps {
    agendaData: IAgenda;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaForm: React.FC<AgendaFormProps> = ({
    agendaData,
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

  if (agendaData.id === 0) {
    agendaData.advogado = getParamFromUrl("advogados");
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

  if (agendaData.id === 0) {
    agendaData.funcionario = getParamFromUrl("funcionarios");
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

  if (agendaData.id === 0) {
    agendaData.tipocompromisso = getParamFromUrl("tipocompromisso");
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

  if (agendaData.id === 0) {
    agendaData.cliente = getParamFromUrl("clientes");
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

  if (agendaData.id === 0) {
    agendaData.area = getParamFromUrl("area");
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

  if (agendaData.id === 0) {
    agendaData.justica = getParamFromUrl("justica");
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

  if (agendaData.id === 0) {
    agendaData.processo = getParamFromUrl("processos");
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

  if (agendaData.id === 0) {
    agendaData.usuario = getParamFromUrl("operador");
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

  if (agendaData.id === 0) {
    agendaData.preposto = getParamFromUrl("prepostos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        agendaData.advogado = e.id;
                      };
 const addValorFuncionario = (e: any) => {
                        if (e?.id>0)
                        agendaData.funcionario = e.id;
                      };
 const addValorTipoCompromisso = (e: any) => {
                        if (e?.id>0)
                        agendaData.tipocompromisso = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        agendaData.cliente = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        agendaData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        agendaData.justica = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        agendaData.processo = e.id;
                      };
 const addValorUsuario = (e: any) => {
                        if (e?.id>0)
                        agendaData.usuario = e.id;
                      };
 const addValorPreposto = (e: any) => {
                        if (e?.id>0)
                        agendaData.preposto = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeAdvogados && (<h2>{nomeAdvogados}</h2>)}
{nomeFuncionarios && (<h2>{nomeFuncionarios}</h2>)}
{nomeTipoCompromisso && (<h2>{nomeTipoCompromisso}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeArea && (<h2>{nomeArea}</h2>)}
{nomeJustica && (<h2>{nomeJustica}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}
{nomePrepostos && (<h2>{nomePrepostos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="idcob"
label="IDCOB"
className="inputIncNome"
name="idcob"
value={agendaData.idcob}
onChange={onChange}               
/>

<Checkbox label="ClienteAvisado" name="clienteavisado" checked={agendaData.clienteavisado} onChange={onChange} />
<Checkbox label="RevisarP2" name="revisarp2" checked={agendaData.revisarp2} onChange={onChange} />
        
<Input
type="text"
id="idne"
label="IDNE"
className="inputIncNome"
name="idne"
value={agendaData.idne}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={agendaData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="oculto"
label="Oculto"
className="inputIncNome"
name="oculto"
value={agendaData.oculto}
onChange={onChange}               
/>

<Input
type="text"
id="cartaprecatoria"
label="CartaPrecatoria"
className="inputIncNome"
name="cartaprecatoria"
value={agendaData.cartaprecatoria}
onChange={onChange}               
/>

<Checkbox label="Revisar" name="revisar" checked={agendaData.revisar} onChange={onChange} />
        
<Input
type="text"
id="hrfinal"
label="HrFinal"
className="inputIncNome"
name="hrfinal"
value={agendaData.hrfinal}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <AdvogadosComboBox
            name={'advogado'}
            value={agendaData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

<Input
type="text"
id="eventogerador"
label="EventoGerador"
className="inputIncNome"
name="eventogerador"
value={agendaData.eventogerador}
onChange={onChange}               
/>

<Input
type="text"
id="eventodata"
label="EventoData"
className="inputIncNome"
name="eventodata"
value={agendaData.eventodata}
onChange={onChange}               
/>

            <FuncionariosComboBox
            name={'funcionario'}
            value={agendaData.funcionario}
            setValue={addValorFuncionario}
            label={'Colaborador'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={agendaData.data}
onChange={onChange}               
/>

<Input
type="text"
id="eventoprazo"
label="EventoPrazo"
className="inputIncNome"
name="eventoprazo"
value={agendaData.eventoprazo}
onChange={onChange}               
/>

<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={agendaData.hora}
onChange={onChange}               
/>

<Input
type="text"
id="compromisso"
label="Compromisso"
className="inputIncNome"
name="compromisso"
value={agendaData.compromisso}
onChange={onChange}               
/>

            <TipoCompromissoComboBox
            name={'tipocompromisso'}
            value={agendaData.tipocompromisso}
            setValue={addValorTipoCompromisso}
            label={'Tipo Compromisso'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={agendaData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

</div><div className="grid-container"><Checkbox label="Liberado" name="liberado" checked={agendaData.liberado} onChange={onChange} />
<Checkbox label="Importante" name="importante" checked={agendaData.importante} onChange={onChange} />
<Checkbox label="Concluido" name="concluido" checked={agendaData.concluido} onChange={onChange} />
 
            <AreaComboBox
            name={'area'}
            value={agendaData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={agendaData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={agendaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="idhistorico"
label="IDHistorico"
className="inputIncNome"
name="idhistorico"
value={agendaData.idhistorico}
onChange={onChange}               
/>

<Input
type="text"
id="idinsprocesso"
label="IDInsProcesso"
className="inputIncNome"
name="idinsprocesso"
value={agendaData.idinsprocesso}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'usuario'}
            value={agendaData.usuario}
            setValue={addValorUsuario}
            label={'Operador'}
            />

            <PrepostosComboBox
            name={'preposto'}
            value={agendaData.preposto}
            setValue={addValorPreposto}
            label={'Prepostos'}
            />

</div><div className="grid-container">        
<Input
type="text"
id="quemid"
label="QuemID"
className="inputIncNome"
name="quemid"
value={agendaData.quemid}
onChange={onChange}               
/>

<Input
type="text"
id="quemcodigo"
label="QuemCodigo"
className="inputIncNome"
name="quemcodigo"
value={agendaData.quemcodigo}
onChange={onChange}               
/>

<Input
type="text"
id="status"
label="Status"
className="inputIncNome"
name="status"
value={agendaData.status}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={agendaData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="decisao"
label="Decisao"
className="inputIncNome"
name="decisao"
value={agendaData.decisao}
onChange={onChange}               
/>

<Input
type="text"
id="sempre"
label="Sempre"
className="inputIncNome"
name="sempre"
value={agendaData.sempre}
onChange={onChange}               
/>

<Input
type="text"
id="prazodias"
label="PrazoDias"
className="inputIncNome"
name="prazodias"
value={agendaData.prazodias}
onChange={onChange}               
/>

<Input
type="text"
id="protocolointegrado"
label="ProtocoloIntegrado"
className="inputIncNome"
name="protocolointegrado"
value={agendaData.protocolointegrado}
onChange={onChange}               
/>

<Input
type="text"
id="datainicioprazo"
label="DataInicioPrazo"
className="inputIncNome"
name="datainicioprazo"
value={agendaData.datainicioprazo}
onChange={onChange}               
/>

<Checkbox label="UsuarioCiente" name="usuariociente" checked={agendaData.usuariociente} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda2agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?agenda=${agendaData.id}`)}>Agenda2 Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarecords${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?agenda=${agendaData.id}`)}>Agenda Records</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendastatus${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?agenda=${agendaData.id}`)}>Agenda Status</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/alarmsms${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?agenda=${agendaData.id}`)}>Alarm S M S</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/recados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?agenda=${agendaData.id}`)}>Recados</div>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 