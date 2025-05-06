// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IApenso2 } from '@/app/GerAdv_TS/Apenso2/Interfaces/interface.Apenso2';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';

interface Apenso2FormProps {
    apenso2Data: IApenso2;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const Apenso2Form: React.FC<Apenso2FormProps> = ({
    apenso2Data,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (apenso2Data.id === 0) {
    apenso2Data.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        apenso2Data.processo = e.id;
                      };

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
      const formElement = document.getElementById('Apenso2Form');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`Apenso2Form-${apenso2Data.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={apenso2Data} isSubmitting={isSubmitting} onClose={onClose} formId={`Apenso2Form-${apenso2Data.id}`} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={apenso2Data.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="apensado"
label="Apensado"
className="inputIncNome"
name="apensado"
value={apenso2Data.apensado}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 