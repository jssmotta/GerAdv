// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPrecatoria } from '@/app/GerAdv_TS/Precatoria/Interfaces/interface.Precatoria';
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

interface PrecatoriaFormProps {
    precatoriaData: IPrecatoria;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PrecatoriaForm: React.FC<PrecatoriaFormProps> = ({
    precatoriaData,
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

  if (precatoriaData.id === 0) {
    precatoriaData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        precatoriaData.processo = e.id;
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
      const formElement = document.getElementById('PrecatoriaForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`PrecatoriaForm-${precatoriaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={precatoriaData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrecatoriaForm-${precatoriaData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="dtdist"
label="DtDist"
className="inputIncNome"
name="dtdist"
value={precatoriaData.dtdist}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={precatoriaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="precatoriax"
label="Precatoria"
className="inputIncNome"
name="precatoriax"
value={precatoriaData.precatoriax}
onChange={onChange}               
/>

<Input
type="text"
id="deprecante"
label="Deprecante"
className="inputIncNome"
name="deprecante"
value={precatoriaData.deprecante}
onChange={onChange}               
/>

<Input
type="text"
id="deprecado"
label="Deprecado"
className="inputIncNome"
name="deprecado"
value={precatoriaData.deprecado}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={precatoriaData.obs}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 