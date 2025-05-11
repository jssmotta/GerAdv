// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgenda2Agenda } from '@/app/GerAdv_TS/Agenda2Agenda/Interfaces/interface.Agenda2Agenda';
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

interface Agenda2AgendaFormProps {
    agenda2agendaData: IAgenda2Agenda;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const Agenda2AgendaForm: React.FC<Agenda2AgendaFormProps> = ({
    agenda2agendaData,
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

  if (agenda2agendaData.id === 0) {
    agenda2agendaData.agenda = getParamFromUrl("agenda");
  }
}
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        agenda2agendaData.agenda = e.id;
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
        console.error("Erro ao submeter formulário de Agenda2Agenda:", error);
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
          target: document.getElementById(`Agenda2AgendaForm-${agenda2agendaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Agenda2Agenda diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Agenda2Agenda' : 'form-container5 form-container-Agenda2Agenda'}>
       
            <form className='formInputCadInc' id={`Agenda2AgendaForm-${agenda2agendaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agenda2agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`Agenda2AgendaForm-${agenda2agendaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="master"
label="Master"
className="inputIncNome"
name="master"
value={agenda2agendaData.master}
onChange={onChange}               
/>

            <AgendaComboBox
            name={'agenda'}
            value={agenda2agendaData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 