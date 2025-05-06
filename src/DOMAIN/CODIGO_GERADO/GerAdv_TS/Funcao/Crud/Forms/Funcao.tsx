// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IFuncao } from '@/app/GerAdv_TS/Funcao/Interfaces/interface.Funcao';
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

interface FuncaoFormProps {
    funcaoData: IFuncao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const FuncaoForm: React.FC<FuncaoFormProps> = ({
    funcaoData,
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
      const formElement = document.getElementById('FuncaoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`FuncaoForm-${funcaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={funcaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`FuncaoForm-${funcaoData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={funcaoData.descricao}
            placeholder={`Digite nome função`}
            onChange={onChange}
            required
            disabled={funcaoData.id > 0}
          />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 