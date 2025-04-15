"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProcessos } from '../../Interfaces/interface.Processos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import SituacaoComboBox from '@/app/GerAdv_TS/Situacao/ComboBox/Situacao';
import RitoComboBox from '@/app/GerAdv_TS/Rito/ComboBox/Rito';
import AtividadesComboBox from '@/app/GerAdv_TS/Atividades/ComboBox/Atividades';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { SituacaoApi } from '@/app/GerAdv_TS/Situacao/Apis/ApiSituacao';
import { RitoApi } from '@/app/GerAdv_TS/Rito/Apis/ApiRito';
import { AtividadesApi } from '@/app/GerAdv_TS/Atividades/Apis/ApiAtividades';

interface ProcessosFormProps {
    processosData: IProcessos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProcessosForm: React.FC<ProcessosFormProps> = ({
    processosData,
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
const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
            const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOponentes, setNomeOponentes] = useState('');
            const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeSituacao, setNomeSituacao] = useState('');
            const situacaoApi = new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeRito, setNomeRito] = useState('');
            const ritoApi = new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAtividades, setNomeAtividades] = useState('');
            const atividadesApi = new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosData.id === 0) {
    processosData.advopo = getParamFromUrl("advogados");
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

  if (processosData.id === 0) {
    processosData.justica = getParamFromUrl("justica");
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

  if (processosData.id === 0) {
    processosData.preposto = getParamFromUrl("prepostos");
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

  if (processosData.id === 0) {
    processosData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("oponentes") > 0) {
  oponentesApi
    .getById(getParamFromUrl("oponentes"))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosData.id === 0) {
    processosData.oponente = getParamFromUrl("oponentes");
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

  if (processosData.id === 0) {
    processosData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("situacao") > 0) {
  situacaoApi
    .getById(getParamFromUrl("situacao"))
    .then((response) => {
      setNomeSituacao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosData.id === 0) {
    processosData.situacao = getParamFromUrl("situacao");
  }
}
 
if (getParamFromUrl("rito") > 0) {
  ritoApi
    .getById(getParamFromUrl("rito"))
    .then((response) => {
      setNomeRito(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosData.id === 0) {
    processosData.rito = getParamFromUrl("rito");
  }
}
 
if (getParamFromUrl("atividades") > 0) {
  atividadesApi
    .getById(getParamFromUrl("atividades"))
    .then((response) => {
      setNomeAtividades(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosData.id === 0) {
    processosData.atividade = getParamFromUrl("atividades");
  }
}
 const addValorAdvOpo = (e: any) => {
                        if (e?.id>0)
                        processosData.advopo = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        processosData.justica = e.id;
                      };
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        processosData.advogado = e.id;
                      };
 const addValorPreposto = (e: any) => {
                        if (e?.id>0)
                        processosData.preposto = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        processosData.cliente = e.id;
                      };
 const addValorOponente = (e: any) => {
                        if (e?.id>0)
                        processosData.oponente = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        processosData.area = e.id;
                      };
 const addValorSituacao = (e: any) => {
                        if (e?.id>0)
                        processosData.situacao = e.id;
                      };
 const addValorRito = (e: any) => {
                        if (e?.id>0)
                        processosData.rito = e.id;
                      };
 const addValorAtividade = (e: any) => {
                        if (e?.id>0)
                        processosData.atividade = e.id;
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
{nomeJustica && (<h2>{nomeJustica}</h2>)}
{nomePrepostos && (<h2>{nomePrepostos}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeOponentes && (<h2>{nomeOponentes}</h2>)}
{nomeArea && (<h2>{nomeArea}</h2>)}
{nomeSituacao && (<h2>{nomeSituacao}</h2>)}
{nomeRito && (<h2>{nomeRito}</h2>)}
{nomeAtividades && (<h2>{nomeAtividades}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nropasta"
            label="nropasta"
            className="inputIncNome"
            name="nropasta"
            value={processosData.nropasta}
            onChange={onChange}
            required
          />

<Input
type="text"
id="advparc"
label="AdvParc"
className="inputIncNome"
name="advparc"
value={processosData.advparc}
onChange={onChange}               
/>

<Checkbox label="AJGPedidoNegado" name="ajgpedidonegado" checked={processosData.ajgpedidonegado} onChange={onChange} />
<Checkbox label="AJGCliente" name="ajgcliente" checked={processosData.ajgcliente} onChange={onChange} />
<Checkbox label="AJGPedidoNegadoOPO" name="ajgpedidonegadoopo" checked={processosData.ajgpedidonegadoopo} onChange={onChange} />
<Checkbox label="NotificarPOE" name="notificarpoe" checked={processosData.notificarpoe} onChange={onChange} />
        
<Input
type="text"
id="valorprovisionado"
label="ValorProvisionado"
className="inputIncNome"
name="valorprovisionado"
value={processosData.valorprovisionado}
onChange={onChange}               
/>

<Checkbox label="AJGOponente" name="ajgoponente" checked={processosData.ajgoponente} onChange={onChange} />
        
<Input
type="text"
id="valorcachecalculo"
label="ValorCacheCalculo"
className="inputIncNome"
name="valorcachecalculo"
value={processosData.valorcachecalculo}
onChange={onChange}               
/>

<Checkbox label="AJGPedidoOPO" name="ajgpedidoopo" checked={processosData.ajgpedidoopo} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="valorcachecalculoprov"
label="ValorCacheCalculoProv"
className="inputIncNome"
name="valorcachecalculoprov"
value={processosData.valorcachecalculoprov}
onChange={onChange}               
/>

<Checkbox label="ConsiderarParado" name="considerarparado" checked={processosData.considerarparado} onChange={onChange} />
<Checkbox label="ValorCalculado" name="valorcalculado" checked={processosData.valorcalculado} onChange={onChange} />
<Checkbox label="AJGConcedidoOPO" name="ajgconcedidoopo" checked={processosData.ajgconcedidoopo} onChange={onChange} />
<Checkbox label="Cobranca" name="cobranca" checked={processosData.cobranca} onChange={onChange} />
        
<Input
type="text"
id="dataentrada"
label="DataEntrada"
className="inputIncNome"
name="dataentrada"
value={processosData.dataentrada}
onChange={onChange}               
/>

<Checkbox label="Penhora" name="penhora" checked={processosData.penhora} onChange={onChange} />
<Checkbox label="AJGPedido" name="ajgpedido" checked={processosData.ajgpedido} onChange={onChange} />
        
<Input
type="text"
id="tipobaixa"
label="TipoBaixa"
className="inputIncNome"
name="tipobaixa"
value={processosData.tipobaixa}
onChange={onChange}               
/>

<Input
type="text"
id="classrisco"
label="ClassRisco"
className="inputIncNome"
name="classrisco"
value={processosData.classrisco}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="IsApenso" name="isapenso" checked={processosData.isapenso} onChange={onChange} />
        
<Input
type="text"
id="valorcausainicial"
label="ValorCausaInicial"
className="inputIncNome"
name="valorcausainicial"
value={processosData.valorcausainicial}
onChange={onChange}               
/>

<Checkbox label="AJGConcedido" name="ajgconcedido" checked={processosData.ajgconcedido} onChange={onChange} />
        
<Input
type="text"
id="obsbcx"
label="ObsBCX"
className="inputIncNome"
name="obsbcx"
value={processosData.obsbcx}
onChange={onChange}               
/>

<Input
type="text"
id="valorcausadefinitivo"
label="ValorCausaDefinitivo"
className="inputIncNome"
name="valorcausadefinitivo"
value={processosData.valorcausadefinitivo}
onChange={onChange}               
/>

<Input
type="text"
id="percprobexito"
label="PercProbExito"
className="inputIncNome"
name="percprobexito"
value={processosData.percprobexito}
onChange={onChange}               
/>

<Checkbox label="MNA" name="mna" checked={processosData.mna} onChange={onChange} />
        
<Input
type="text"
id="percexito"
label="PercExito"
className="inputIncNome"
name="percexito"
value={processosData.percexito}
onChange={onChange}               
/>

<Input
type="text"
id="nroextra"
label="NroExtra"
className="inputIncNome"
name="nroextra"
value={processosData.nroextra}
onChange={onChange}               
/>

            <AdvogadosComboBox
            name={'advopo'}
            value={processosData.advopo}
            setValue={addValorAdvOpo}
            label={'Advogados'}
            />

</div><div className="grid-container"><Checkbox label="Extra" name="extra" checked={processosData.extra} onChange={onChange} />
 
            <JusticaComboBox
            name={'justica'}
            value={processosData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

            <AdvogadosComboBox
            name={'advogado'}
            value={processosData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

<Input
type="text"
id="nrocaixa"
label="NroCaixa"
className="inputIncNome"
name="nrocaixa"
value={processosData.nrocaixa}
onChange={onChange}               
/>

            <PrepostosComboBox
            name={'preposto'}
            value={processosData.preposto}
            setValue={addValorPreposto}
            label={'Prepostos'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={processosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

            <OponentesComboBox
            name={'oponente'}
            value={processosData.oponente}
            setValue={addValorOponente}
            label={'Oponentes'}
            />

            <AreaComboBox
            name={'area'}
            value={processosData.area}
            setValue={addValorArea}
            label={'Area'}
            />

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={processosData.cidade}
onChange={onChange}               
/>

            <SituacaoComboBox
            name={'situacao'}
            value={processosData.situacao}
            setValue={addValorSituacao}
            label={'Situacao'}
            />

</div><div className="grid-container"><Checkbox label="IDSituacao" name="idsituacao" checked={processosData.idsituacao} onChange={onChange} />
        
<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={processosData.valor}
onChange={onChange}               
/>

            <RitoComboBox
            name={'rito'}
            value={processosData.rito}
            setValue={addValorRito}
            label={'Rito'}
            />

<Input
type="text"
id="fato"
label="Fato"
className="inputIncNome"
name="fato"
value={processosData.fato}
onChange={onChange}               
/>

            <AtividadesComboBox
            name={'atividade'}
            value={processosData.atividade}
            setValue={addValorAtividade}
            label={'Atividades'}
            />

<Input
type="text"
id="caixamorto"
label="CaixaMorto"
className="inputIncNome"
name="caixamorto"
value={processosData.caixamorto}
onChange={onChange}               
/>

<Checkbox label="Baixado" name="baixado" checked={processosData.baixado} onChange={onChange} />
        
<Input
type="text"
id="dtbaixa"
label="DtBaixa"
className="inputIncNome"
name="dtbaixa"
value={processosData.dtbaixa}
onChange={onChange}               
/>

<Input
type="text"
id="motivobaixa"
label="MotivoBaixa"
className="inputIncNome"
name="motivobaixa"
value={processosData.motivobaixa}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={processosData.obs}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="Printed" name="printed" checked={processosData.printed} onChange={onChange} />
        
<Input
type="text"
id="zkey"
label="ZKey"
className="inputIncNome"
name="zkey"
value={processosData.zkey}
onChange={onChange}               
/>

<Input
type="text"
id="zkeyquem"
label="ZKeyQuem"
className="inputIncNome"
name="zkeyquem"
value={processosData.zkeyquem}
onChange={onChange}               
/>

<Input
type="text"
id="zkeyquando"
label="ZKeyQuando"
className="inputIncNome"
name="zkeyquando"
value={processosData.zkeyquando}
onChange={onChange}               
/>

<Input
type="text"
id="resumo"
label="Resumo"
className="inputIncNome"
name="resumo"
value={processosData.resumo}
onChange={onChange}               
/>

<Checkbox label="NaoImprimir" name="naoimprimir" checked={processosData.naoimprimir} onChange={onChange} />
<Checkbox label="Eletronico" name="eletronico" checked={processosData.eletronico} onChange={onChange} />
        
<Input
type="text"
id="nrocontrato"
label="NroContrato"
className="inputIncNome"
name="nrocontrato"
value={processosData.nrocontrato}
onChange={onChange}               
/>

<Input
type="text"
id="percprobexitojustificativa"
label="PercProbExitoJustificativa"
className="inputIncNome"
name="percprobexitojustificativa"
value={processosData.percprobexitojustificativa}
onChange={onChange}               
/>

<Input
type="text"
id="honorariovalor"
label="HonorarioValor"
className="inputIncNome"
name="honorariovalor"
value={processosData.honorariovalor}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="honorariopercentual"
label="HonorarioPercentual"
className="inputIncNome"
name="honorariopercentual"
value={processosData.honorariopercentual}
onChange={onChange}               
/>

<Input
type="text"
id="honorariosucumbencia"
label="HonorarioSucumbencia"
className="inputIncNome"
name="honorariosucumbencia"
value={processosData.honorariosucumbencia}
onChange={onChange}               
/>

<Input
type="text"
id="faseauditoria"
label="FaseAuditoria"
className="inputIncNome"
name="faseauditoria"
value={processosData.faseauditoria}
onChange={onChange}               
/>

<Input
type="text"
id="valorcondenacao"
label="ValorCondenacao"
className="inputIncNome"
name="valorcondenacao"
value={processosData.valorcondenacao}
onChange={onChange}               
/>

<Input
type="text"
id="valorcondenacaocalculado"
label="ValorCondenacaoCalculado"
className="inputIncNome"
name="valorcondenacaocalculado"
value={processosData.valorcondenacaocalculado}
onChange={onChange}               
/>

<Input
type="text"
id="valorcondenacaoprovisorio"
label="ValorCondenacaoProvisorio"
className="inputIncNome"
name="valorcondenacaoprovisorio"
value={processosData.valorcondenacaoprovisorio}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarepetir${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Agenda Repetir</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/andamentosmd${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Andamentos M D</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/apenso${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Apenso</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/apenso2${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Apenso2</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contacorrente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Conta Corrente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contatocrm${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Contato C R M</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contratos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Contratos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/documentos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Documentos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/enderecosistema${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Endereco Sistema</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/historico${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Historico</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/honorariosdadoscontrato${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Honorarios Dados Contrato</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/horastrab${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Horas Trab</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/instancia${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Instancia</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/ligacoes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Ligacoes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/livrocaixa${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Livro Caixa</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/nenotas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>N E Notas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parceriaproc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Parceria Proc</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/partecliente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Parte Cliente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parteclienteoutras${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Parte Cliente Outras</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parteoponente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Parte Oponente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/penhora${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Penhora</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/precatoria${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Precatoria</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/probarcode${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Bar C O D E</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/procda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro C D A</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processosobsreport${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Processos Obs Report</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processosparados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Processos Parados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processoutputrequest${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Process Output Request</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prodepositos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Depositos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prodespesas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Despesas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/proobservacoes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Observacoes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/propartes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Partes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/proprocuradores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Procuradores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/proresumos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Resumos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prosucumbencia${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Sucumbencia</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/provalores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Pro Valores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/recados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Recados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/terceiros${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Terceiros</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/ultimosprocessos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Ultimos Processos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarelatorio${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?processos=${processosData.id}`)}>Agenda Relatorio</div>

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
 