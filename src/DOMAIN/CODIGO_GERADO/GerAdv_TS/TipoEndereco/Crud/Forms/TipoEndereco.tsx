// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoEndereco } from '@/app/GerAdv_TS/TipoEndereco/Interfaces/interface.TipoEndereco';
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

interface TipoEnderecoFormProps {
    tipoenderecoData: ITipoEndereco;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoEnderecoForm: React.FC<TipoEnderecoFormProps> = ({
    tipoenderecoData,
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
      const formElement = document.getElementById('TipoEnderecoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`TipoEnderecoForm-${tipoenderecoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipoenderecoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoEnderecoForm-${tipoenderecoData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={tipoenderecoData.descricao}
            placeholder={`Digite nome tipo endereco`}
            onChange={onChange}
            required
            disabled={tipoenderecoData.id > 0}
          />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 