// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IServicos } from '@/app/GerAdv_TS/Servicos/Interfaces/interface.Servicos';
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

interface ServicosFormProps {
    servicosData: IServicos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ServicosForm: React.FC<ServicosFormProps> = ({
    servicosData,
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
      const formElement = document.getElementById('ServicosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ServicosForm-${servicosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={servicosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ServicosForm-${servicosData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={servicosData.descricao}
            placeholder={`Digite nome serviço`}
            onChange={onChange}
            required
            disabled={servicosData.id > 0}
          />

                <InputCheckbox label="Cobrar" name="cobrar" checked={servicosData.cobrar} onChange={onChange} />
<InputCheckbox label="Basico" name="basico" checked={servicosData.basico} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 