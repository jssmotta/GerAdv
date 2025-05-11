// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaStatus } from '@/app/GerAdv_TS/AgendaStatus/Interfaces/interface.AgendaStatus';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface AgendaStatusFormProps {
    agendastatusData: IAgendaStatus;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaStatusForm: React.FC<AgendaStatusFormProps> = ({
    agendastatusData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAgenda, setNomeAgenda] = useState('');
            const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("agenda") > 0) {
  agendaApi
    .getById(getParamFromUrl("agenda"))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendastatusData.id === 0) {
    agendastatusData.agenda = getParamFromUrl("agenda");
  }
}
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        agendastatusData.agenda = e.id;
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
        console.error("Erro ao submeter formulário de AgendaStatus:", error);
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
          target: document.getElementById(`AgendaStatusForm-${agendastatusData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AgendaStatus diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AgendaStatus' : 'form-container5 form-container-AgendaStatus'}>
       
            <form className='formInputCadInc' id={`AgendaStatusForm-${agendastatusData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendastatusData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaStatusForm-${agendastatusData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <AgendaComboBox
            name={'agenda'}
            value={agendastatusData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

<InputInput
type="text"
id="completed"
label="Completed"
className="inputIncNome"
name="completed"
value={agendastatusData.completed}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 