// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IUltimosProcessos } from '@/app/GerAdv_TS/UltimosProcessos/Interfaces/interface.UltimosProcessos';
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

interface UltimosProcessosFormProps {
    ultimosprocessosData: IUltimosProcessos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const UltimosProcessosForm: React.FC<UltimosProcessosFormProps> = ({
    ultimosprocessosData,
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

  if (ultimosprocessosData.id === 0) {
    ultimosprocessosData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        ultimosprocessosData.processo = e.id;
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
      const formElement = document.getElementById('UltimosProcessosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`UltimosProcessosForm-${ultimosprocessosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={ultimosprocessosData} isSubmitting={isSubmitting} onClose={onClose} formId={`UltimosProcessosForm-${ultimosprocessosData.id}`} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={ultimosprocessosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="quando"
label="Quando"
className="inputIncNome"
name="quando"
value={ultimosprocessosData.quando}
onChange={onChange}               
/>

<Input
type="text"
id="quem"
label="Quem"
className="inputIncNome"
name="quem"
value={ultimosprocessosData.quem}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 