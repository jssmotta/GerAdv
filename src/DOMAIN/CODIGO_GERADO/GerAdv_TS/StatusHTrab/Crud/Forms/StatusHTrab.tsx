// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IStatusHTrab } from '@/app/GerAdv_TS/StatusHTrab/Interfaces/interface.StatusHTrab';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputDescription from '@/app/components/Inputs/InputDescription';

interface StatusHTrabFormProps {
    statushtrabData: IStatusHTrab;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const StatusHTrabForm: React.FC<StatusHTrabFormProps> = ({
    statushtrabData,
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
      const formElement = document.getElementById('StatusHTrabForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`StatusHTrabForm-${statushtrabData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={statushtrabData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusHTrabForm-${statushtrabData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={statushtrabData.descricao}
            placeholder={`Digite nome status h trab`}
            onChange={onChange}
            required
            disabled={statushtrabData.id > 0}
          />

<Input
type="text"
id="resid"
label="ResID"
className="inputIncNome"
name="resid"
value={statushtrabData.resid}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 