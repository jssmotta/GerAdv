// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessos } from '@/app/GerAdv_TS/Processos/Interfaces/interface.Processos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
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
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Processos:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ProcessosForm-${processosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Processos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Processos' : 'form-container form-container-Processos'}>
       
            <form className='formInputCadInc' id={`ProcessosForm-${processosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosForm-${processosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nropasta"
            label="NroPasta"
            className="inputIncNome"
            name="nropasta"
            value={processosData.nropasta}
            placeholder={`Informe NroPasta`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="advparc"
label="AdvParc"
className="inputIncNome"
name="advparc"
value={processosData.advparc}
onChange={onChange}               
/>

<InputCheckbox label="AJGPedidoNegado" name="ajgpedidonegado" checked={processosData.ajgpedidonegado} onChange={onChange} />
<InputCheckbox label="AJGCliente" name="ajgcliente" checked={processosData.ajgcliente} onChange={onChange} />
<InputCheckbox label="AJGPedidoNegadoOPO" name="ajgpedidonegadoopo" checked={processosData.ajgpedidonegadoopo} onChange={onChange} />
<InputCheckbox label="NotificarPOE" name="notificarpoe" checked={processosData.notificarpoe} onChange={onChange} />
        
<InputInput
type="text"
id="valorprovisionado"
label="ValorProvisionado"
className="inputIncNome"
name="valorprovisionado"
value={processosData.valorprovisionado}
onChange={onChange}               
/>

<InputCheckbox label="AJGOponente" name="ajgoponente" checked={processosData.ajgoponente} onChange={onChange} />
        
<InputInput
type="text"
id="valorcachecalculo"
label="ValorCacheCalculo"
className="inputIncNome"
name="valorcachecalculo"
value={processosData.valorcachecalculo}
onChange={onChange}               
/>

<InputCheckbox label="AJGPedidoOPO" name="ajgpedidoopo" checked={processosData.ajgpedidoopo} onChange={onChange} />
</div><div className="grid-container">        
<InputInput
type="text"
id="valorcachecalculoprov"
label="ValorCacheCalculoProv"
className="inputIncNome"
name="valorcachecalculoprov"
value={processosData.valorcachecalculoprov}
onChange={onChange}               
/>

<InputCheckbox label="ConsiderarParado" name="considerarparado" checked={processosData.considerarparado} onChange={onChange} />
<InputCheckbox label="ValorCalculado" name="valorcalculado" checked={processosData.valorcalculado} onChange={onChange} />
<InputCheckbox label="AJGConcedidoOPO" name="ajgconcedidoopo" checked={processosData.ajgconcedidoopo} onChange={onChange} />
<InputCheckbox label="Cobranca" name="cobranca" checked={processosData.cobranca} onChange={onChange} />
        
<InputInput
type="text"
id="dataentrada"
label="DataEntrada"
className="inputIncNome"
name="dataentrada"
value={processosData.dataentrada}
onChange={onChange}               
/>

<InputCheckbox label="Penhora" name="penhora" checked={processosData.penhora} onChange={onChange} />
<InputCheckbox label="AJGPedido" name="ajgpedido" checked={processosData.ajgpedido} onChange={onChange} />
        
<InputInput
type="text"
id="tipobaixa"
label="TipoBaixa"
className="inputIncNome"
name="tipobaixa"
value={processosData.tipobaixa}
onChange={onChange}               
/>

<InputInput
type="text"
id="classrisco"
label="ClassRisco"
className="inputIncNome"
name="classrisco"
value={processosData.classrisco}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="IsApenso" name="isapenso" checked={processosData.isapenso} onChange={onChange} />
        
<InputInput
type="text"
id="valorcausainicial"
label="ValorCausaInicial"
className="inputIncNome"
name="valorcausainicial"
value={processosData.valorcausainicial}
onChange={onChange}               
/>

<InputCheckbox label="AJGConcedido" name="ajgconcedido" checked={processosData.ajgconcedido} onChange={onChange} />
        
<InputInput
type="text"
id="obsbcx"
label="ObsBCX"
className="inputIncNome"
name="obsbcx"
value={processosData.obsbcx}
onChange={onChange}               
/>

<InputInput
type="text"
id="valorcausadefinitivo"
label="ValorCausaDefinitivo"
className="inputIncNome"
name="valorcausadefinitivo"
value={processosData.valorcausadefinitivo}
onChange={onChange}               
/>

<InputInput
type="text"
id="percprobexito"
label="PercProbExito"
className="inputIncNome"
name="percprobexito"
value={processosData.percprobexito}
onChange={onChange}               
/>

<InputCheckbox label="MNA" name="mna" checked={processosData.mna} onChange={onChange} />
        
<InputInput
type="text"
id="percexito"
label="PercExito"
className="inputIncNome"
name="percexito"
value={processosData.percexito}
onChange={onChange}               
/>

<InputInput
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

</div><div className="grid-container"><InputCheckbox label="Extra" name="extra" checked={processosData.extra} onChange={onChange} />
 
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

<InputInput
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

<InputInput
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

</div><div className="grid-container"><InputCheckbox label="IDSituacao" name="idsituacao" checked={processosData.idsituacao} onChange={onChange} />
        
<InputInput
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

<InputInput
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

<InputInput
type="text"
id="caixamorto"
label="CaixaMorto"
className="inputIncNome"
name="caixamorto"
value={processosData.caixamorto}
onChange={onChange}               
/>

<InputCheckbox label="Baixado" name="baixado" checked={processosData.baixado} onChange={onChange} />
        
<InputInput
type="text"
id="dtbaixa"
label="DtBaixa"
className="inputIncNome"
name="dtbaixa"
value={processosData.dtbaixa}
onChange={onChange}               
/>

<InputInput
type="text"
id="motivobaixa"
label="MotivoBaixa"
className="inputIncNome"
name="motivobaixa"
value={processosData.motivobaixa}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={processosData.obs}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Printed" name="printed" checked={processosData.printed} onChange={onChange} />
        
<InputInput
type="text"
id="zkey"
label="ZKey"
className="inputIncNome"
name="zkey"
value={processosData.zkey}
onChange={onChange}               
/>

<InputInput
type="text"
id="zkeyquem"
label="ZKeyQuem"
className="inputIncNome"
name="zkeyquem"
value={processosData.zkeyquem}
onChange={onChange}               
/>

<InputInput
type="text"
id="zkeyquando"
label="ZKeyQuando"
className="inputIncNome"
name="zkeyquando"
value={processosData.zkeyquando}
onChange={onChange}               
/>

<InputInput
type="text"
id="resumo"
label="Resumo"
className="inputIncNome"
name="resumo"
value={processosData.resumo}
onChange={onChange}               
/>

<InputCheckbox label="NaoImprimir" name="naoimprimir" checked={processosData.naoimprimir} onChange={onChange} />
<InputCheckbox label="Eletronico" name="eletronico" checked={processosData.eletronico} onChange={onChange} />
        
<InputInput
type="text"
id="nrocontrato"
label="NroContrato"
className="inputIncNome"
name="nrocontrato"
value={processosData.nrocontrato}
onChange={onChange}               
/>

<InputInput
type="text"
id="percprobexitojustificativa"
label="PercProbExitoJustificativa"
className="inputIncNome"
name="percprobexitojustificativa"
value={processosData.percprobexitojustificativa}
onChange={onChange}               
/>

<InputInput
type="text"
id="honorariovalor"
label="HonorarioValor"
className="inputIncNome"
name="honorariovalor"
value={processosData.honorariovalor}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="honorariopercentual"
label="HonorarioPercentual"
className="inputIncNome"
name="honorariopercentual"
value={processosData.honorariopercentual}
onChange={onChange}               
/>

<InputInput
type="text"
id="honorariosucumbencia"
label="HonorarioSucumbencia"
className="inputIncNome"
name="honorariosucumbencia"
value={processosData.honorariosucumbencia}
onChange={onChange}               
/>

<InputInput
type="text"
id="faseauditoria"
label="FaseAuditoria"
className="inputIncNome"
name="faseauditoria"
value={processosData.faseauditoria}
onChange={onChange}               
/>

<InputInput
type="text"
id="valorcondenacao"
label="ValorCondenacao"
className="inputIncNome"
name="valorcondenacao"
value={processosData.valorcondenacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="valorcondenacaocalculado"
label="ValorCondenacaoCalculado"
className="inputIncNome"
name="valorcondenacaocalculado"
value={processosData.valorcondenacaocalculado}
onChange={onChange}               
/>

<InputInput
type="text"
id="valorcondenacaoprovisorio"
label="ValorCondenacaoProvisorio"
className="inputIncNome"
name="valorcondenacaoprovisorio"
value={processosData.valorcondenacaoprovisorio}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 