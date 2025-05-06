// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoValorProcesso } from '@/app/GerAdv_TS/TipoValorProcesso/Interfaces/interface.TipoValorProcesso';
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

interface TipoValorProcessoFormProps {
    tipovalorprocessoData: ITipoValorProcesso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoValorProcessoForm: React.FC<TipoValorProcessoFormProps> = ({
    tipovalorprocessoData,
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
      const formElement = document.getElementById('TipoValorProcessoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`TipoValorProcessoForm-${tipovalorprocessoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipovalorprocessoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoValorProcessoForm-${tipovalorprocessoData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={tipovalorprocessoData.descricao}
            placeholder={`Digite nome tipo valor processo`}
            onChange={onChange}
            required
            disabled={tipovalorprocessoData.id > 0}
          />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 