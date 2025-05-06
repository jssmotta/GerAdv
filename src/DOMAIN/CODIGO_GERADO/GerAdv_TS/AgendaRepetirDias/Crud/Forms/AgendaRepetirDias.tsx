// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaRepetirDias } from '@/app/GerAdv_TS/AgendaRepetirDias/Interfaces/interface.AgendaRepetirDias';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';

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
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
      const formElement = document.getElementById('AgendaRepetirDiasForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AgendaRepetirDiasForm-${agendarepetirdiasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendarepetirdiasData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRepetirDiasForm-${agendarepetirdiasData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={agendarepetirdiasData.horafinal}
onChange={onChange}               
/>

<Input
type="text"
id="master"
label="Master"
className="inputIncNome"
name="master"
value={agendarepetirdiasData.master}
onChange={onChange}               
/>

<Input
type="text"
id="dia"
label="Dia"
className="inputIncNome"
name="dia"
value={agendarepetirdiasData.dia}
onChange={onChange}               
/>

<Input
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
        
    </>
     );
};
 