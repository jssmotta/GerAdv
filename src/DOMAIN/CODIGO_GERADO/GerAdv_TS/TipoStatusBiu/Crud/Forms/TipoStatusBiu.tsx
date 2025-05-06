// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoStatusBiu } from '@/app/GerAdv_TS/TipoStatusBiu/Interfaces/interface.TipoStatusBiu';
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

interface TipoStatusBiuFormProps {
    tipostatusbiuData: ITipoStatusBiu;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoStatusBiuForm: React.FC<TipoStatusBiuFormProps> = ({
    tipostatusbiuData,
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
      const formElement = document.getElementById('TipoStatusBiuForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`TipoStatusBiuForm-${tipostatusbiuData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipostatusbiuData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoStatusBiuForm-${tipostatusbiuData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={tipostatusbiuData.nome}
            placeholder={`Digite nome staus  usuários`}
            onChange={onChange}
            required
          />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 