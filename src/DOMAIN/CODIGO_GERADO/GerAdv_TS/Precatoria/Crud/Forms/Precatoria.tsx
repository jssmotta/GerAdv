// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPrecatoria } from '@/app/GerAdv_TS/Precatoria/Interfaces/interface.Precatoria';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Precatoria:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`PrecatoriaForm-${precatoriaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Precatoria diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Precatoria' : 'form-container5 form-container-Precatoria'}>
       
            <form className='formInputCadInc' id={`PrecatoriaForm-${precatoriaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={precatoriaData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrecatoriaForm-${precatoriaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
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

<InputInput
type="text"
id="precatoriax"
label="Precatoria"
className="inputIncNome"
name="precatoriax"
value={precatoriaData.precatoriax}
onChange={onChange}               
/>

<InputInput
type="text"
id="deprecante"
label="Deprecante"
className="inputIncNome"
name="deprecante"
value={precatoriaData.deprecante}
onChange={onChange}               
/>

<InputInput
type="text"
id="deprecado"
label="Deprecado"
className="inputIncNome"
name="deprecado"
value={precatoriaData.deprecado}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 