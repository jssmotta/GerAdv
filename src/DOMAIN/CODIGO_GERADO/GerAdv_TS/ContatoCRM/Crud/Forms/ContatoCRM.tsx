// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IContatoCRM } from '@/app/GerAdv_TS/ContatoCRM/Interfaces/interface.ContatoCRM';
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

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import TipoContatoCRMComboBox from '@/app/GerAdv_TS/TipoContatoCRM/ComboBox/TipoContatoCRM';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { TipoContatoCRMApi } from '@/app/GerAdv_TS/TipoContatoCRM/Apis/ApiTipoContatoCRM';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ContatoCRMFormProps {
    contatocrmData: IContatoCRM;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContatoCRMForm: React.FC<ContatoCRMFormProps> = ({
    contatocrmData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoContatoCRM, setNomeTipoContatoCRM] = useState('');
            const tipocontatocrmApi = new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmData.id === 0) {
    contatocrmData.operador = getParamFromUrl("operador");
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

  if (contatocrmData.id === 0) {
    contatocrmData.cliente = getParamFromUrl("clientes");
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

  if (contatocrmData.id === 0) {
    contatocrmData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("tipocontatocrm") > 0) {
  tipocontatocrmApi
    .getById(getParamFromUrl("tipocontatocrm"))
    .then((response) => {
      setNomeTipoContatoCRM(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmData.id === 0) {
    contatocrmData.tipocontatocrm = getParamFromUrl("tipocontatocrm");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.operador = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.cliente = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.processo = e.id;
                      };
 const addValorTipoContatoCRM = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.tipocontatocrm = e.id;
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
        console.error("Erro ao submeter formulário de ContatoCRM:", error);
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
          target: document.getElementById(`ContatoCRMForm-${contatocrmData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ContatoCRM diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ContatoCRM' : 'form-container form-container-ContatoCRM'}>
       
            <form className='formInputCadInc' id={`ContatoCRMForm-${contatocrmData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={contatocrmData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMForm-${contatocrmData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="ageclienteavisado"
label="AgeClienteAvisado"
className="inputIncNome"
name="ageclienteavisado"
value={contatocrmData.ageclienteavisado}
onChange={onChange}               
/>

<InputInput
type="text"
id="docsviarecebimento"
label="DocsViaRecebimento"
className="inputIncNome"
name="docsviarecebimento"
value={contatocrmData.docsviarecebimento}
onChange={onChange}               
/>

<InputCheckbox label="NaoPublicavel" name="naopublicavel" checked={contatocrmData.naopublicavel} onChange={onChange} />
<InputCheckbox label="Notificar" name="notificar" checked={contatocrmData.notificar} onChange={onChange} />
<InputCheckbox label="Ocultar" name="ocultar" checked={contatocrmData.ocultar} onChange={onChange} />
        
<InputInput
type="text"
id="assunto"
label="Assunto"
className="inputIncNome"
name="assunto"
value={contatocrmData.assunto}
onChange={onChange}               
/>

<InputCheckbox label="IsDocsRecebidos" name="isdocsrecebidos" checked={contatocrmData.isdocsrecebidos} onChange={onChange} />
        
<InputInput
type="text"
id="quemnotificou"
label="QuemNotificou"
className="inputIncNome"
name="quemnotificou"
value={contatocrmData.quemnotificou}
onChange={onChange}               
/>

<InputInput
type="text"
id="datanotificou"
label="DataNotificou"
className="inputIncNome"
name="datanotificou"
value={contatocrmData.datanotificou}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <OperadorComboBox
            name={'operador'}
            value={contatocrmData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={contatocrmData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="horanotificou"
label="HoraNotificou"
className="inputIncNome"
name="horanotificou"
value={contatocrmData.horanotificou}
onChange={onChange}               
/>

<InputInput
type="text"
id="objetonotificou"
label="ObjetoNotificou"
className="inputIncNome"
name="objetonotificou"
value={contatocrmData.objetonotificou}
onChange={onChange}               
/>

<InputInput
type="text"
id="pessoacontato"
label="PessoaContato"
className="inputIncNome"
name="pessoacontato"
value={contatocrmData.pessoacontato}
onChange={onChange}               
/>

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={contatocrmData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="tempo"
label="Tempo"
className="inputIncNome"
name="tempo"
value={contatocrmData.tempo}
onChange={onChange}               
/>

<InputInput
type="text"
id="horainicial"
label="HoraInicial"
className="inputIncNome"
name="horainicial"
value={contatocrmData.horainicial}
onChange={onChange}               
/>

<InputInput
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={contatocrmData.horafinal}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={contatocrmData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

</div><div className="grid-container"><InputCheckbox label="Importante" name="importante" checked={contatocrmData.importante} onChange={onChange} />
<InputCheckbox label="Urgente" name="urgente" checked={contatocrmData.urgente} onChange={onChange} />
<InputCheckbox label="GerarHoraTrabalhada" name="gerarhoratrabalhada" checked={contatocrmData.gerarhoratrabalhada} onChange={onChange} />
<InputCheckbox label="ExibirNoTopo" name="exibirnotopo" checked={contatocrmData.exibirnotopo} onChange={onChange} />
 
            <TipoContatoCRMComboBox
            name={'tipocontatocrm'}
            value={contatocrmData.tipocontatocrm}
            setValue={addValorTipoContatoCRM}
            label={'Tipo Contato C R M'}
            />

<InputInput
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={contatocrmData.contato}
onChange={onChange}               
/>

<InputInput
type="text"
id="emocao"
label="Emocao"
className="inputIncNome"
name="emocao"
value={contatocrmData.emocao}
onChange={onChange}               
/>

<InputCheckbox label="Continuar" name="continuar" checked={contatocrmData.continuar} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 