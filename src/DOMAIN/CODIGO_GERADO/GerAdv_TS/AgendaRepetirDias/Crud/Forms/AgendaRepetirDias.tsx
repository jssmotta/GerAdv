// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaRepetirDias } from '@/app/GerAdv_TS/AgendaRepetirDias/Interfaces/interface.AgendaRepetirDias';
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

import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface AgendaRepetirDiasFormProps {
    agendarepetirdiasData: IAgendaRepetirDias;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaRepetirDiasForm: React.FC<AgendaRepetirDiasFormProps> = ({
    agendarepetirdiasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
        console.error("Erro ao submeter formulário de AgendaRepetirDias:", error);
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
          target: document.getElementById(`AgendaRepetirDiasForm-${agendarepetirdiasData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AgendaRepetirDias diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AgendaRepetirDias' : 'form-container5 form-container-AgendaRepetirDias'}>
       
            <form className='formInputCadInc' id={`AgendaRepetirDiasForm-${agendarepetirdiasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendarepetirdiasData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRepetirDiasForm-${agendarepetirdiasData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={agendarepetirdiasData.horafinal}
onChange={onChange}               
/>

<InputInput
type="text"
id="master"
label="Master"
className="inputIncNome"
name="master"
value={agendarepetirdiasData.master}
onChange={onChange}               
/>

<InputInput
type="text"
id="dia"
label="Dia"
className="inputIncNome"
name="dia"
value={agendarepetirdiasData.dia}
onChange={onChange}               
/>

<InputInput
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={agendarepetirdiasData.hora}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 