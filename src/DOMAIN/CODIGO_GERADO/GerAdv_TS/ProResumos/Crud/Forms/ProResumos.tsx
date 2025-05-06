// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProResumos } from '@/app/GerAdv_TS/ProResumos/Interfaces/interface.ProResumos';
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

interface ProResumosFormProps {
    proresumosData: IProResumos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProResumosForm: React.FC<ProResumosFormProps> = ({
    proresumosData,
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

  if (proresumosData.id === 0) {
    proresumosData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        proresumosData.processo = e.id;
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
      const formElement = document.getElementById('ProResumosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ProResumosForm-${proresumosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={proresumosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProResumosForm-${proresumosData.id}`} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={proresumosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={proresumosData.data}
onChange={onChange}               
/>

<Input
type="text"
id="resumo"
label="Resumo"
className="inputIncNome"
name="resumo"
value={proresumosData.resumo}
onChange={onChange}               
/>

<Input
type="text"
id="tiporesumo"
label="TipoResumo"
className="inputIncNome"
name="tiporesumo"
value={proresumosData.tiporesumo}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 