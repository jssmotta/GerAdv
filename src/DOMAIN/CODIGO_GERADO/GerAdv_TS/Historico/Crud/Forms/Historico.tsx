// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IHistorico } from '@/app/GerAdv_TS/Historico/Interfaces/interface.Historico';
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

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import PrecatoriaComboBox from '@/app/GerAdv_TS/Precatoria/ComboBox/Precatoria';
import ApensoComboBox from '@/app/GerAdv_TS/Apenso/ComboBox/Apenso';
import FaseComboBox from '@/app/GerAdv_TS/Fase/ComboBox/Fase';
import StatusAndamentoComboBox from '@/app/GerAdv_TS/StatusAndamento/ComboBox/StatusAndamento';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { PrecatoriaApi } from '@/app/GerAdv_TS/Precatoria/Apis/ApiPrecatoria';
import { ApensoApi } from '@/app/GerAdv_TS/Apenso/Apis/ApiApenso';
import { FaseApi } from '@/app/GerAdv_TS/Fase/Apis/ApiFase';
import { StatusAndamentoApi } from '@/app/GerAdv_TS/StatusAndamento/Apis/ApiStatusAndamento';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface HistoricoFormProps {
    historicoData: IHistorico;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const HistoricoForm: React.FC<HistoricoFormProps> = ({
    historicoData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrecatoria, setNomePrecatoria] = useState('');
            const precatoriaApi = new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeApenso, setNomeApenso] = useState('');
            const apensoApi = new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFase, setNomeFase] = useState('');
            const faseApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeStatusAndamento, setNomeStatusAndamento] = useState('');
            const statusandamentoApi = new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (historicoData.id === 0) {
    historicoData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("precatoria") > 0) {
  precatoriaApi
    .getById(getParamFromUrl("precatoria"))
    .then((response) => {
      setNomePrecatoria(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (historicoData.id === 0) {
    historicoData.precatoria = getParamFromUrl("precatoria");
  }
}
 
if (getParamFromUrl("apenso") > 0) {
  apensoApi
    .getById(getParamFromUrl("apenso"))
    .then((response) => {
      setNomeApenso(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (historicoData.id === 0) {
    historicoData.apenso = getParamFromUrl("apenso");
  }
}
 
if (getParamFromUrl("fase") > 0) {
  faseApi
    .getById(getParamFromUrl("fase"))
    .then((response) => {
      setNomeFase(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (historicoData.id === 0) {
    historicoData.fase = getParamFromUrl("fase");
  }
}
 
if (getParamFromUrl("statusandamento") > 0) {
  statusandamentoApi
    .getById(getParamFromUrl("statusandamento"))
    .then((response) => {
      setNomeStatusAndamento(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (historicoData.id === 0) {
    historicoData.statusandamento = getParamFromUrl("statusandamento");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        historicoData.processo = e.id;
                      };
 const addValorPrecatoria = (e: any) => {
                        if (e?.id>0)
                        historicoData.precatoria = e.id;
                      };
 const addValorApenso = (e: any) => {
                        if (e?.id>0)
                        historicoData.apenso = e.id;
                      };
 const addValorFase = (e: any) => {
                        if (e?.id>0)
                        historicoData.fase = e.id;
                      };
 const addValorStatusAndamento = (e: any) => {
                        if (e?.id>0)
                        historicoData.statusandamento = e.id;
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
        console.error("Erro ao submeter formulário de Historico:", error);
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
          target: document.getElementById(`HistoricoForm-${historicoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Historico diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Historico' : 'form-container form-container-Historico'}>
       
            <form className='formInputCadInc' id={`HistoricoForm-${historicoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={historicoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HistoricoForm-${historicoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="extraid"
label="ExtraID"
className="inputIncNome"
name="extraid"
value={historicoData.extraid}
onChange={onChange}               
/>

<InputInput
type="text"
id="idne"
label="IDNE"
className="inputIncNome"
name="idne"
value={historicoData.idne}
onChange={onChange}               
/>

<InputInput
type="text"
id="liminarorigem"
label="LiminarOrigem"
className="inputIncNome"
name="liminarorigem"
value={historicoData.liminarorigem}
onChange={onChange}               
/>

<InputCheckbox label="NaoPublicavel" name="naopublicavel" checked={historicoData.naopublicavel} onChange={onChange} />
 
            <ProcessosComboBox
            name={'processo'}
            value={historicoData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <PrecatoriaComboBox
            name={'precatoria'}
            value={historicoData.precatoria}
            setValue={addValorPrecatoria}
            label={'Precatoria'}
            />

            <ApensoComboBox
            name={'apenso'}
            value={historicoData.apenso}
            setValue={addValorApenso}
            label={'Apenso'}
            />

<InputInput
type="text"
id="idinstprocesso"
label="IDInstProcesso"
className="inputIncNome"
name="idinstprocesso"
value={historicoData.idinstprocesso}
onChange={onChange}               
/>

            <FaseComboBox
            name={'fase'}
            value={historicoData.fase}
            setValue={addValorFase}
            label={'Fase'}
            />

</div><div className="grid-container">        
<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={historicoData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={historicoData.observacao}
onChange={onChange}               
/>

<InputCheckbox label="Agendado" name="agendado" checked={historicoData.agendado} onChange={onChange} />
<InputCheckbox label="Concluido" name="concluido" checked={historicoData.concluido} onChange={onChange} />
<InputCheckbox label="MesmaAgenda" name="mesmaagenda" checked={historicoData.mesmaagenda} onChange={onChange} />
        
<InputInput
type="text"
id="sad"
label="SAD"
className="inputIncNome"
name="sad"
value={historicoData.sad}
onChange={onChange}               
/>

<InputCheckbox label="Resumido" name="resumido" checked={historicoData.resumido} onChange={onChange} />
 
            <StatusAndamentoComboBox
            name={'statusandamento'}
            value={historicoData.statusandamento}
            setValue={addValorStatusAndamento}
            label={'Status Andamento'}
            />

<InputCheckbox label="Top" name="top" checked={historicoData.top} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 