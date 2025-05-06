// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IArea } from '@/app/GerAdv_TS/Area/Interfaces/interface.Area';
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
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface AreaFormProps {
    areaData: IArea;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AreaForm: React.FC<AreaFormProps> = ({
    areaData,
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
      const formElement = document.getElementById('AreaForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AreaForm-${areaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={areaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AreaForm-${areaData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={areaData.descricao}
            placeholder={`Digite nome area`}
            onChange={onChange}
            required
            disabled={areaData.id > 0}
          />

                <InputCheckbox label="Top" name="top" checked={areaData.top} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 