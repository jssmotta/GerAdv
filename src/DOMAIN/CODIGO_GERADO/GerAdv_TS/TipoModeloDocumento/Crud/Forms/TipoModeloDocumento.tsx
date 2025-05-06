// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoModeloDocumento } from '@/app/GerAdv_TS/TipoModeloDocumento/Interfaces/interface.TipoModeloDocumento';
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

interface TipoModeloDocumentoFormProps {
    tipomodelodocumentoData: ITipoModeloDocumento;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoModeloDocumentoForm: React.FC<TipoModeloDocumentoFormProps> = ({
    tipomodelodocumentoData,
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
      const formElement = document.getElementById('TipoModeloDocumentoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipomodelodocumentoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={tipomodelodocumentoData.nome}
            placeholder={`Digite nome tipo modelo documento`}
            onChange={onChange}
            required
          />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 